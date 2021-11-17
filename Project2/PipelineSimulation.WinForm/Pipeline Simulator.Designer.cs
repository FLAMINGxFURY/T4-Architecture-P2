
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
            this.core1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.core2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.core3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.core4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.core1ProgBox = new System.Windows.Forms.RichTextBox();
            this.core1ProgLabel = new System.Windows.Forms.Label();
            this.core1Box = new System.Windows.Forms.RichTextBox();
            this.core1Label = new System.Windows.Forms.Label();
            this.core3Box = new System.Windows.Forms.RichTextBox();
            this.core2Label = new System.Windows.Forms.Label();
            this.core3Label = new System.Windows.Forms.Label();
            this.core4Box = new System.Windows.Forms.RichTextBox();
            this.core4Label = new System.Windows.Forms.Label();
            this.core2Box = new System.Windows.Forms.RichTextBox();
            this.nextClockBtn = new System.Windows.Forms.Button();
            this.core3ProgBox = new System.Windows.Forms.RichTextBox();
            this.core3ProgLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.core4ProgBox = new System.Windows.Forms.RichTextBox();
            this.core4ProgLabel = new System.Windows.Forms.Label();
            this.core2ProgBox = new System.Windows.Forms.RichTextBox();
            this.core2ProgLabel = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
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
            this.menuStrip1.Size = new System.Drawing.Size(1872, 24);
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
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.core1ToolStripMenuItem,
            this.core2ToolStripMenuItem,
            this.core3ToolStripMenuItem,
            this.core4ToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // core1ToolStripMenuItem
            // 
            this.core1ToolStripMenuItem.Name = "core1ToolStripMenuItem";
            this.core1ToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.core1ToolStripMenuItem.Text = "Core 1";
            this.core1ToolStripMenuItem.Click += new System.EventHandler(this.core1ToolStripMenuItem_Click);
            // 
            // core2ToolStripMenuItem
            // 
            this.core2ToolStripMenuItem.Name = "core2ToolStripMenuItem";
            this.core2ToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.core2ToolStripMenuItem.Text = "Core 2";
            this.core2ToolStripMenuItem.Click += new System.EventHandler(this.core2ToolStripMenuItem_Click);
            // 
            // core3ToolStripMenuItem
            // 
            this.core3ToolStripMenuItem.Name = "core3ToolStripMenuItem";
            this.core3ToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.core3ToolStripMenuItem.Text = "Core 3";
            this.core3ToolStripMenuItem.Click += new System.EventHandler(this.core3ToolStripMenuItem_Click);
            // 
            // core4ToolStripMenuItem
            // 
            this.core4ToolStripMenuItem.Name = "core4ToolStripMenuItem";
            this.core4ToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.core4ToolStripMenuItem.Text = "Core 4";
            this.core4ToolStripMenuItem.Click += new System.EventHandler(this.core4ToolStripMenuItem_Click);
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
            // core1ProgBox
            // 
            this.core1ProgBox.Location = new System.Drawing.Point(23, 178);
            this.core1ProgBox.Name = "core1ProgBox";
            this.core1ProgBox.Size = new System.Drawing.Size(181, 292);
            this.core1ProgBox.TabIndex = 2;
            this.core1ProgBox.Text = "";
            // 
            // core1ProgLabel
            // 
            this.core1ProgLabel.AutoSize = true;
            this.core1ProgLabel.Location = new System.Drawing.Point(23, 160);
            this.core1ProgLabel.Name = "core1ProgLabel";
            this.core1ProgLabel.Size = new System.Drawing.Size(53, 15);
            this.core1ProgLabel.TabIndex = 3;
            this.core1ProgLabel.Text = "Program";
            // 
            // core1Box
            // 
            this.core1Box.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.core1Box.Location = new System.Drawing.Point(226, 160);
            this.core1Box.Name = "core1Box";
            this.core1Box.ReadOnly = true;
            this.core1Box.Size = new System.Drawing.Size(714, 310);
            this.core1Box.TabIndex = 4;
            this.core1Box.Text = "";
            this.core1Box.WordWrap = false;
            // 
            // core1Label
            // 
            this.core1Label.AutoSize = true;
            this.core1Label.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.core1Label.Location = new System.Drawing.Point(23, 116);
            this.core1Label.Name = "core1Label";
            this.core1Label.Size = new System.Drawing.Size(582, 30);
            this.core1Label.TabIndex = 5;
            this.core1Label.Text = "Core 1                                                                           " +
    "         ";
            // 
            // core3Box
            // 
            this.core3Box.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.core3Box.Location = new System.Drawing.Point(228, 534);
            this.core3Box.Name = "core3Box";
            this.core3Box.ReadOnly = true;
            this.core3Box.Size = new System.Drawing.Size(714, 316);
            this.core3Box.TabIndex = 8;
            this.core3Box.Text = "";
            // 
            // core2Label
            // 
            this.core2Label.AutoSize = true;
            this.core2Label.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.core2Label.Location = new System.Drawing.Point(955, 116);
            this.core2Label.Name = "core2Label";
            this.core2Label.Size = new System.Drawing.Size(582, 30);
            this.core2Label.TabIndex = 7;
            this.core2Label.Text = "Core 2                                                                           " +
    "         ";
            // 
            // core3Label
            // 
            this.core3Label.AutoSize = true;
            this.core3Label.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.core3Label.Location = new System.Drawing.Point(25, 490);
            this.core3Label.Name = "core3Label";
            this.core3Label.Size = new System.Drawing.Size(582, 30);
            this.core3Label.TabIndex = 9;
            this.core3Label.Text = "Core 3                                                                           " +
    "         ";
            // 
            // core4Box
            // 
            this.core4Box.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.core4Box.Location = new System.Drawing.Point(1151, 534);
            this.core4Box.Name = "core4Box";
            this.core4Box.ReadOnly = true;
            this.core4Box.Size = new System.Drawing.Size(721, 316);
            this.core4Box.TabIndex = 10;
            this.core4Box.Text = "";
            // 
            // core4Label
            // 
            this.core4Label.AutoSize = true;
            this.core4Label.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.core4Label.Location = new System.Drawing.Point(955, 490);
            this.core4Label.Name = "core4Label";
            this.core4Label.Size = new System.Drawing.Size(582, 30);
            this.core4Label.TabIndex = 11;
            this.core4Label.Text = "Core 4                                                                           " +
    "         ";
            // 
            // core2Box
            // 
            this.core2Box.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.core2Box.Location = new System.Drawing.Point(1151, 160);
            this.core2Box.Name = "core2Box";
            this.core2Box.ReadOnly = true;
            this.core2Box.Size = new System.Drawing.Size(721, 310);
            this.core2Box.TabIndex = 12;
            this.core2Box.Text = "";
            // 
            // nextClockBtn
            // 
            this.nextClockBtn.Location = new System.Drawing.Point(214, 47);
            this.nextClockBtn.Name = "nextClockBtn";
            this.nextClockBtn.Size = new System.Drawing.Size(135, 58);
            this.nextClockBtn.TabIndex = 17;
            this.nextClockBtn.Text = "Next Clock Cycle";
            this.nextClockBtn.UseVisualStyleBackColor = true;
            this.nextClockBtn.Click += new System.EventHandler(this.nxtClockBtn_Click);
            // 
            // core3ProgBox
            // 
            this.core3ProgBox.Location = new System.Drawing.Point(25, 552);
            this.core3ProgBox.Name = "core3ProgBox";
            this.core3ProgBox.Size = new System.Drawing.Size(181, 298);
            this.core3ProgBox.TabIndex = 18;
            this.core3ProgBox.Text = "";
            // 
            // core3ProgLabel
            // 
            this.core3ProgLabel.AutoSize = true;
            this.core3ProgLabel.Location = new System.Drawing.Point(25, 534);
            this.core3ProgLabel.Name = "core3ProgLabel";
            this.core3ProgLabel.Size = new System.Drawing.Size(53, 15);
            this.core3ProgLabel.TabIndex = 19;
            this.core3ProgLabel.Text = "Program";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 58);
            this.button1.TabIndex = 20;
            this.button1.Text = "Begin";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Begin_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(371, 47);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 58);
            this.button2.TabIndex = 21;
            this.button2.Text = "Run to End";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // core4ProgBox
            // 
            this.core4ProgBox.Location = new System.Drawing.Point(955, 552);
            this.core4ProgBox.Name = "core4ProgBox";
            this.core4ProgBox.Size = new System.Drawing.Size(181, 298);
            this.core4ProgBox.TabIndex = 22;
            this.core4ProgBox.Text = "";
            // 
            // core4ProgLabel
            // 
            this.core4ProgLabel.AutoSize = true;
            this.core4ProgLabel.Location = new System.Drawing.Point(955, 534);
            this.core4ProgLabel.Name = "core4ProgLabel";
            this.core4ProgLabel.Size = new System.Drawing.Size(53, 15);
            this.core4ProgLabel.TabIndex = 23;
            this.core4ProgLabel.Text = "Program";
            // 
            // core2ProgBox
            // 
            this.core2ProgBox.Location = new System.Drawing.Point(955, 172);
            this.core2ProgBox.Name = "core2ProgBox";
            this.core2ProgBox.Size = new System.Drawing.Size(181, 298);
            this.core2ProgBox.TabIndex = 24;
            this.core2ProgBox.Text = "";
            // 
            // core2ProgLabel
            // 
            this.core2ProgLabel.AutoSize = true;
            this.core2ProgLabel.Location = new System.Drawing.Point(955, 154);
            this.core2ProgLabel.Name = "core2ProgLabel";
            this.core2ProgLabel.Size = new System.Drawing.Size(53, 15);
            this.core2ProgLabel.TabIndex = 25;
            this.core2ProgLabel.Text = "Program";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(521, 65);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 26;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // PipelineSimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(968, 505);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.core2ProgLabel);
            this.Controls.Add(this.core2ProgBox);
            this.Controls.Add(this.core4ProgLabel);
            this.Controls.Add(this.core4ProgBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.core3ProgLabel);
            this.Controls.Add(this.core3ProgBox);
            this.Controls.Add(this.nextClockBtn);
            this.Controls.Add(this.core2Box);
            this.Controls.Add(this.core4Label);
            this.Controls.Add(this.core4Box);
            this.Controls.Add(this.core3Label);
            this.Controls.Add(this.core2Label);
            this.Controls.Add(this.core3Box);
            this.Controls.Add(this.core1Label);
            this.Controls.Add(this.core1Box);
            this.Controls.Add(this.core1ProgLabel);
            this.Controls.Add(this.core1ProgBox);
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
        private System.Windows.Forms.RichTextBox core1ProgBox;
        private System.Windows.Forms.Label core1ProgLabel;
        private System.Windows.Forms.RichTextBox core1Box;
        private System.Windows.Forms.Label core1Label;
        private System.Windows.Forms.RichTextBox core2Box;
        private System.Windows.Forms.Label core2Label;
        private System.Windows.Forms.RichTextBox core3Box;
        private System.Windows.Forms.Label core3Label;
        private System.Windows.Forms.RichTextBox core4Box;
        private System.Windows.Forms.Label core4Label;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.Button nextClockBtn;
        private System.Windows.Forms.RichTextBox core3ProgBox;
        private System.Windows.Forms.Label core3ProgLabel;
        private System.Windows.Forms.ToolStripMenuItem core1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem core2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem core3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem core4ToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox core4ProgBox;
        private System.Windows.Forms.Label core4ProgLabel;
        private System.Windows.Forms.RichTextBox core2ProgBox;
        private System.Windows.Forms.Label core2ProgLabel;
        private System.Windows.Forms.Button button3;
    }
}

