using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using PipelineSimulation.Core;
using System.Diagnostics;

namespace PipelineSimulation.WinForm
{
    public partial class PipelineSimulator : Form
    {
        //these attributes could be used in a method/class to create all needed
        //objects & threads to start the simulation
        string core1FilePath = null;
        string core2FilePath = null;
        string core3FilePath = null;
        string core4FilePath = null;
        int coreNumber = 1;

        public PipelineSimulator()
        {
            InitializeComponent();
            nextClockBtn.Enabled = false;   //cannot go to next clock without loading program
            initialCoreSetup();
        }

        private void Begin_Click(object sender, EventArgs e)
        {
            if (ConfigIsValid() == true)
            {
                //begin simulation, spawn the correct number of CPU classes/threads & pass into them the appropriate file paths
            }

            MessageBox.Show("Please open files for all enabled cores", "Pipeline Simulator");
        }

        private void initialCoreSetup()
        {
            this.coreNumber = 1;
            Core1ItemsVisible();
            Core2ItemsHide();
            Core3ItemsHide();
            Core4ItemsHide();
        }

        private void Core1ItemsVisible()
        {
            core1Box.Visible = true;
            core1Label.Visible = true;
            core1ProgBox.Visible = true;
            core1ProgLabel.Visible = true;
        }

        private void Core1ItemsHide()
        {
            core1Box.Visible = false;
            core1Label.Visible = false;
            core1ProgBox.Visible = false;
            core1ProgLabel.Visible = false;
        }

        private void Core2ItemsVisible()
        {
            core2Box.Visible = true;
            core2Label.Visible = true;
            core2ProgBox.Visible = true;
            core2ProgLabel.Visible = true;
        }

        private void Core2ItemsHide()
        {
            core2Box.Visible = false;
            core2Label.Visible = false;
            core2ProgBox.Visible = false;
            core2ProgLabel.Visible = false;
        }

        private void Core3ItemsVisible()
        {
            core3Box.Visible = true;
            core3Label.Visible = true;
            core3ProgBox.Visible = true;
            core3ProgLabel.Visible = true;
        }

        private void Core3ItemsHide()
        {
            core3Box.Visible = false;
            core3Label.Visible = false;
            core3ProgBox.Visible = false;
            core3ProgLabel.Visible = false;
        }

        private void Core4ItemsVisible()
        {
            core4Box.Visible = true;
            core4Label.Visible = true;
            core4ProgBox.Visible = true;
            core4ProgLabel.Visible = true;
        }

        private void Core4ItemsHide()
        {
            core4Box.Visible = false;
            core4Label.Visible = false;
            core4ProgBox.Visible = false;
            core4ProgLabel.Visible = false;
        }

        //Change cores to 1
        private void changeCores_1(object sender, EventArgs e)
        {
            this.coreNumber = 1;
            Core1ItemsVisible();
            Core2ItemsHide();
            Core3ItemsHide();
            Core4ItemsHide();
        }

        //Change cores to 2
        private void changeCores_2(object sender, EventArgs e)
        {
            this.coreNumber = 2;
            Core1ItemsVisible();
            Core2ItemsVisible();
            Core3ItemsHide();
            Core4ItemsHide();
        }

        //Change cores to 3
        private void changeCores_3(object sender, EventArgs e)
        {
            this.coreNumber = 3;
            Core1ItemsVisible();
            Core2ItemsVisible();
            Core3ItemsVisible();
            Core4ItemsHide();
        }

        //Change cores to 4
        private void changeCores_4(object sender, EventArgs e)
        {
            this.coreNumber = 4;
            Core1ItemsVisible();
            Core2ItemsVisible();
            Core3ItemsVisible();
            Core4ItemsVisible();
        }

        //Closes program
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            while(MessageBox.Show("Exit simulator?", "Pipeline Simulator", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            Application.Exit();
        }


        //maybe using a sleep function would be more useful in a multithreaded environment. Maybe this could be a functionality to pause/play
        private void nxtClockBtn_Click(object sender, EventArgs e)
        {
            
        }

        private string openFile()
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileName;
                }
            }

            return null;
        }

        private void core1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.core1FilePath = openFile();
        }

        private void core2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.core2FilePath = openFile();
        }

        private void core3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.core3FilePath = openFile();
        }

        private void core4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.core4FilePath = openFile();
        }

        private bool ConfigIsValid()
        {
            switch (this.coreNumber)
            {
                case 1:
                    if(core1FilePath != null)
                    {
                        return true;
                    }
                    return false;
                case 2:
                    if(core2FilePath != null && core1FilePath != null)
                    {
                        return true;
                    }
                    return false;
                case 3:
                    if(core3FilePath != null && core2FilePath != null && core3FilePath != null)
                    {
                        return true;
                    }
                    return false;
                case 4:
                    if(core4FilePath != null && core3FilePath != null && core2FilePath != null && core1FilePath != null)
                    {
                        return true;
                    }
                    return false;
            }

            return false;
        }

        //TODO Remove this - it is only here to test the formatted string
        private void button3_Click(object sender, EventArgs e)
        {
            String s = String.Format("{0,-15} {1,-15} {2,-15} {3,-15} {4,-15} {5,-15}\n\n", "Fetch", "Decode", "MemRead", "Execute", "MemWrite", "RegWrite");
            s += String.Format      ("{0,-15} {1,-15} {2,-15} {3,-15} {4,-15} {5,-15}\n", "MOV R1,15", "FADD R4, R3", "ADD 15, 15", "ADD 0x01A45C", "test instruction", "test test");

            Debug.WriteLine(s);

            core1Box.Text = s;
            core2Box.Text = s;
            core3Box.Text = s;
            core4Box.Text = s;
        }
    }
}
