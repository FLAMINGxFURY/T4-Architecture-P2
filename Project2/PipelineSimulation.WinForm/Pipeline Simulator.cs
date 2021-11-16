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

namespace PipelineSimulation.WinForm
{
    public partial class PipelineSimulator : Form
    {
        CPU cpu;        //maybe move to another class to decouple from frontend

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
            cpu = new CPU();
            nextClockBtn.Enabled = false;   //cannot go to next clock without loading program
            initialCoreSetup();
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
            core1PipelineLabel.Visible = true;
            core1ProgBox.Visible = true;
            core1ProgLabel.Visible = true;
        }

        private void Core1ItemsHide()
        {
            core1Box.Visible = false;
            core1Label.Visible = false;
            core1PipelineLabel.Visible = false;
            core1ProgBox.Visible = false;
            core1ProgLabel.Visible = false;
        }

        private void Core2ItemsVisible()
        {
            core2Box.Visible = true;
            core2Label.Visible = true;
            core2PipelineLabel.Visible = true;
            core2ProgBox.Visible = true;
            core2ProgLabel.Visible = true;
        }

        private void Core2ItemsHide()
        {
            core2Box.Visible = false;
            core2Label.Visible = false;
            core2PipelineLabel.Visible = false;
            core2ProgBox.Visible = false;
            core2ProgLabel.Visible = false;
        }

        private void Core3ItemsVisible()
        {
            core3Box.Visible = true;
            core3Label.Visible = true;
            core3PipelineLabel.Visible = true;
            core3ProgBox.Visible = true;
            core3ProgLabel.Visible = true;
        }

        private void Core3ItemsHide()
        {
            core3Box.Visible = false;
            core3Label.Visible = false;
            core3PipelineLabel.Visible = false;
            core3ProgBox.Visible = false;
            core3ProgLabel.Visible = false;
        }

        private void Core4ItemsVisible()
        {
            core4Box.Visible = true;
            core4Label.Visible = true;
            core4PipelineLabel.Visible = true;
            core4ProgBox.Visible = true;
            core4ProgLabel.Visible = true;
        }

        private void Core4ItemsHide()
        {
            core4Box.Visible = false;
            core4Label.Visible = false;
            core4PipelineLabel.Visible = false;
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
            cpu.NextClockCycle();
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

        private void Begin_Click(object sender, EventArgs e)
        {
            if(ConfigIsValid() == true)
            {
                //begin simulation
            }

            MessageBox.Show("Please open files for all cores", "Pipeline Simulator");
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
    }
}
