
namespace PipelineSimulation.WinForm
{
    partial class PipelineSimulator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PipelineSimulator));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeCoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.core1Box = new System.Windows.Forms.RichTextBox();
            this.core1Label = new System.Windows.Forms.Label();
            this.core3Box = new System.Windows.Forms.RichTextBox();
            this.core2Label = new System.Windows.Forms.Label();
            this.core3Label = new System.Windows.Forms.Label();
            this.core4Box = new System.Windows.Forms.RichTextBox();
            this.core4Label = new System.Windows.Forms.Label();
            this.core2Box = new System.Windows.Forms.RichTextBox();
            this.core1PipelineLabel = new System.Windows.Forms.Label();
            this.core2PipelineLabel = new System.Windows.Forms.Label();
            this.core3PipelineLabel = new System.Windows.Forms.Label();
            this.core4PipelineLabel = new System.Windows.Forms.Label();
            this.nextClockBtn = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.propertiesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1139, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeCoresToolStripMenuItem});
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.propertiesToolStripMenuItem.Text = "Properties";
            // 
            // changeCoresToolStripMenuItem
            // 
            this.changeCoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5});
            this.changeCoresToolStripMenuItem.Name = "changeCoresToolStripMenuItem";
            this.changeCoresToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.changeCoresToolStripMenuItem.Text = "Change Cores";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem2.Text = "1";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.changeCores_1);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem3.Text = "2";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.changeCores_2);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem4.Text = "3";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.changeCores_3);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem5.Text = "4";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.changeCores_4);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentationToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // documentationToolStripMenuItem
            // 
            this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            this.documentationToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.documentationToolStripMenuItem.Text = "Documentation";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(157, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(32, 182);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(181, 563);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Program";
            // 
            // core1Box
            // 
            this.core1Box.Location = new System.Drawing.Point(272, 86);
            this.core1Box.Name = "core1Box";
            this.core1Box.Size = new System.Drawing.Size(371, 292);
            this.core1Box.TabIndex = 4;
            this.core1Box.Text = "";
            // 
            // core1Label
            // 
            this.core1Label.AutoSize = true;
            this.core1Label.Location = new System.Drawing.Point(272, 47);
            this.core1Label.Name = "core1Label";
            this.core1Label.Size = new System.Drawing.Size(41, 15);
            this.core1Label.TabIndex = 5;
            this.core1Label.Text = "Core 1";
            // 
            // core3Box
            // 
            this.core3Box.Location = new System.Drawing.Point(272, 447);
            this.core3Box.Name = "core3Box";
            this.core3Box.Size = new System.Drawing.Size(371, 298);
            this.core3Box.TabIndex = 8;
            this.core3Box.Text = "";
            // 
            // core2Label
            // 
            this.core2Label.AutoSize = true;
            this.core2Label.Location = new System.Drawing.Point(703, 47);
            this.core2Label.Name = "core2Label";
            this.core2Label.Size = new System.Drawing.Size(41, 15);
            this.core2Label.TabIndex = 7;
            this.core2Label.Text = "Core 2";
            // 
            // core3Label
            // 
            this.core3Label.AutoSize = true;
            this.core3Label.Location = new System.Drawing.Point(272, 404);
            this.core3Label.Name = "core3Label";
            this.core3Label.Size = new System.Drawing.Size(41, 15);
            this.core3Label.TabIndex = 9;
            this.core3Label.Text = "Core 3";
            // 
            // core4Box
            // 
            this.core4Box.Location = new System.Drawing.Point(697, 447);
            this.core4Box.Name = "core4Box";
            this.core4Box.Size = new System.Drawing.Size(377, 298);
            this.core4Box.TabIndex = 10;
            this.core4Box.Text = "";
            // 
            // core4Label
            // 
            this.core4Label.AutoSize = true;
            this.core4Label.Location = new System.Drawing.Point(697, 404);
            this.core4Label.Name = "core4Label";
            this.core4Label.Size = new System.Drawing.Size(41, 15);
            this.core4Label.TabIndex = 11;
            this.core4Label.Text = "Core 4";
            // 
            // core2Box
            // 
            this.core2Box.Location = new System.Drawing.Point(703, 87);
            this.core2Box.Name = "core2Box";
            this.core2Box.Size = new System.Drawing.Size(371, 292);
            this.core2Box.TabIndex = 12;
            this.core2Box.Text = "";
            // 
            // core1PipelineLabel
            // 
            this.core1PipelineLabel.AutoSize = true;
            this.core1PipelineLabel.Location = new System.Drawing.Point(272, 68);
            this.core1PipelineLabel.Name = "core1PipelineLabel";
            this.core1PipelineLabel.Size = new System.Drawing.Size(347, 15);
            this.core1PipelineLabel.TabIndex = 13;
            this.core1PipelineLabel.Text = "Fetch     Decode    MemRead     Execute     MemWrite     RegWrite";
            // 
            // core2PipelineLabel
            // 
            this.core2PipelineLabel.AutoSize = true;
            this.core2PipelineLabel.Location = new System.Drawing.Point(703, 69);
            this.core2PipelineLabel.Name = "core2PipelineLabel";
            this.core2PipelineLabel.Size = new System.Drawing.Size(347, 15);
            this.core2PipelineLabel.TabIndex = 14;
            this.core2PipelineLabel.Text = "Fetch     Decode    MemRead     Execute     MemWrite     RegWrite";
            // 
            // core3PipelineLabel
            // 
            this.core3PipelineLabel.AutoSize = true;
            this.core3PipelineLabel.Location = new System.Drawing.Point(272, 429);
            this.core3PipelineLabel.Name = "core3PipelineLabel";
            this.core3PipelineLabel.Size = new System.Drawing.Size(347, 15);
            this.core3PipelineLabel.TabIndex = 15;
            this.core3PipelineLabel.Text = "Fetch     Decode    MemRead     Execute     MemWrite     RegWrite";
            // 
            // core4PipelineLabel
            // 
            this.core4PipelineLabel.AutoSize = true;
            this.core4PipelineLabel.Location = new System.Drawing.Point(697, 429);
            this.core4PipelineLabel.Name = "core4PipelineLabel";
            this.core4PipelineLabel.Size = new System.Drawing.Size(347, 15);
            this.core4PipelineLabel.TabIndex = 16;
            this.core4PipelineLabel.Text = "Fetch     Decode    MemRead     Execute     MemWrite     RegWrite";
            // 
            // button1
            // 
            this.nextClockBtn.Location = new System.Drawing.Point(47, 68);
            this.nextClockBtn.Name = "button1";
            this.nextClockBtn.Size = new System.Drawing.Size(135, 58);
            this.nextClockBtn.TabIndex = 17;
            this.nextClockBtn.Text = "Next Clock Cycle";
            this.nextClockBtn.UseVisualStyleBackColor = true;
            this.nextClockBtn.Click += new System.EventHandler(this.nxtClockBtn_Click);
            // 
            // PipelineSimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 796);
            this.Controls.Add(this.nextClockBtn);
            this.Controls.Add(this.core4PipelineLabel);
            this.Controls.Add(this.core3PipelineLabel);
            this.Controls.Add(this.core2PipelineLabel);
            this.Controls.Add(this.core1PipelineLabel);
            this.Controls.Add(this.core2Box);
            this.Controls.Add(this.core4Label);
            this.Controls.Add(this.core4Box);
            this.Controls.Add(this.core3Label);
            this.Controls.Add(this.core2Label);
            this.Controls.Add(this.core3Box);
            this.Controls.Add(this.core1Label);
            this.Controls.Add(this.core1Box);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PipelineSimulator";
            this.Text = "Pipeline Simulator";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeCoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox core1Box;
        private System.Windows.Forms.Label core1Label;
        private System.Windows.Forms.RichTextBox core2Box;
        private System.Windows.Forms.Label core2Label;
        private System.Windows.Forms.RichTextBox core3Box;
        private System.Windows.Forms.Label core3Label;
        private System.Windows.Forms.RichTextBox core4Box;
        private System.Windows.Forms.Label core4Label;
        private System.Windows.Forms.Label core1PipelineLabel;
        private System.Windows.Forms.Label core2PipelineLabel;
        private System.Windows.Forms.Label core3PipelineLabel;
        private System.Windows.Forms.Label core4PipelineLabel;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.Button nextClockBtn;
    }
}

