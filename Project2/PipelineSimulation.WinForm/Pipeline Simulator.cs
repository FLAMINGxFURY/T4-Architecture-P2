using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PipelineSimulation.WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

        }

        //Closes program
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            while(MessageBox.Show("Exit simulator?", "", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            Application.Exit();
        }
    }
}
