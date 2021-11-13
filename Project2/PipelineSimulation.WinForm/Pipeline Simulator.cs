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
        CPU cpu;
        
        public PipelineSimulator()
        {
            InitializeComponent();
            cpu = new CPU();
            nextClockBtn.Enabled = false;   //cannot go to next clock without loading program
            initialCoreSetup();
        }


        private void initialCoreSetup()
        {
            core1Box.Visible = true;
            core1Label.Visible = true;
            core1PipelineLabel.Visible = true;

            core2Box.Visible = false;
            core2Label.Visible = false;
            core2PipelineLabel.Visible = false;

            core3Box.Visible = false;
            core3Label.Visible = false;
            core3PipelineLabel.Visible = false;

            core4Box.Visible = false;
            core4Label.Visible = false;
            core4PipelineLabel.Visible = false;
        }

        //Change cores to 1
        private void changeCores_1(object sender, EventArgs e)
        {
            core1Box.Visible = true;
            core1Label.Visible = true;
            core1PipelineLabel.Visible = true;

            core2Box.Visible = false;
            core2Label.Visible = false;
            core2PipelineLabel.Visible = false;

            core3Box.Visible = false;
            core3Label.Visible = false;
            core3PipelineLabel.Visible = false;

            core4Box.Visible = false;
            core4Label.Visible = false;
            core4PipelineLabel.Visible = false;
        }

        //Change cores to 2
        private void changeCores_2(object sender, EventArgs e)
        {
            core1Box.Visible = true;
            core1Label.Visible = true;
            core1PipelineLabel.Visible = true;

            core2Box.Visible = true;
            core2Label.Visible = true;
            core3PipelineLabel.Visible = true;

            core3Box.Visible = false;
            core3Label.Visible = false;
            core3PipelineLabel.Visible = false;

            core4Box.Visible = false;
            core4Label.Visible = false;
            core4PipelineLabel.Visible = false;
        }

        //Change cores to 3
        private void changeCores_3(object sender, EventArgs e)
        {
            core1Box.Visible = true;
            core1Label.Visible = true;
            core1PipelineLabel.Visible = true;

            core2Box.Visible = true;
            core2Label.Visible = true;
            core2PipelineLabel.Visible = true;

            core3Box.Visible = true;
            core3Label.Visible = true;
            core3PipelineLabel.Visible = true;

            core4Box.Visible = false;
            core4Label.Visible = false;
            core4PipelineLabel.Visible = false;
        }

        //Change cores to 4
        private void changeCores_4(object sender, EventArgs e)
        {
            core1Box.Visible = true;
            core1Label.Visible = true;
            core1PipelineLabel.Visible = true;

            core2Box.Visible = true;
            core2Label.Visible = true;
            core2PipelineLabel.Visible = true;

            core3Box.Visible = true;
            core3Label.Visible = true;
            core3PipelineLabel.Visible = true;

            core4Box.Visible = true;
            core4Label.Visible = true;
            core4PipelineLabel.Visible = true;
        }

        //Open file
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
           
            using(OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    cpu.Rd.fileStr = openFileDialog.FileName;
                    cpu.Rd.OpenFile();

                    //TODO: Display program code after being parsed/decoded in Reader class

                }
            }
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

        private void nxtClockBtn_Click(object sender, EventArgs e)
        {
            cpu.NextClockCycle();
        }
    }
}
