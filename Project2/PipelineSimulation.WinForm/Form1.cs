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

        }

        //Change cores to 2
        private void changeCores_2(object sender, EventArgs e)
        {

        }

        //Change cores to 3
        private void changeCores_3(object sender, EventArgs e)
        {

        }

        //Change cores to 4
        private void changeCores_4(object sender, EventArgs e)
        {

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
