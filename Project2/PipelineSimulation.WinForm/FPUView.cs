using System;
using System.Windows.Forms;
using PipelineSimulation.Core.Functional_Units;

namespace PipelineSimulation.WinForm
{
    public partial class FPUView : Form
    {
        public FPU WorkingFPU { get; set; }

        public FPUView()
        {
            InitializeComponent();
        }

        private void FPUView_Load(object sender, EventArgs e)
        {
            
        }

        public void UpdateFromFPU()
        {
            lblTop.Text = $"TOP: {WorkingFPU.TOP}";
            txtStack1.Text = WorkingFPU.Read(0).ToString();
            txtStack2.Text = WorkingFPU.Read(1).ToString();
            txtStack3.Text = WorkingFPU.Read(2).ToString();
            txtStack4.Text = WorkingFPU.Read(3).ToString();
            txtStack5.Text = WorkingFPU.Read(4).ToString();
            txtStack6.Text = WorkingFPU.Read(5).ToString();
            txtStack7.Text = WorkingFPU.Read(6).ToString();
            txtStack8.Text = WorkingFPU.Read(7).ToString();
        }
    }
}
