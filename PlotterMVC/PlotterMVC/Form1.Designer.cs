namespace MVCTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gNUPlotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Graph_2D = new System.Windows.Forms.ToolStripMenuItem();
            this.dGraphToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instructionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.GearBox = new System.Windows.Forms.ComboBox();
            this.EingriffBox = new System.Windows.Forms.ComboBox();
            this.moment_button = new System.Windows.Forms.Button();
            this.force_button = new System.Windows.Forms.Button();
            this.stress_button = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ysiso_button = new System.Windows.Forms.Button();
            this.ysidiniso_button = new System.Windows.Forms.Button();
            this.ContactLineCheckBox = new System.Windows.Forms.CheckedListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.extra_button = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.drawToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1124, 33);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(148, 30);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gNUPlotToolStripMenuItem,
            this.saveChartToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(148, 30);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // gNUPlotToolStripMenuItem
            // 
            this.gNUPlotToolStripMenuItem.Enabled = false;
            this.gNUPlotToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("gNUPlotToolStripMenuItem.Image")));
            this.gNUPlotToolStripMenuItem.Name = "gNUPlotToolStripMenuItem";
            this.gNUPlotToolStripMenuItem.Size = new System.Drawing.Size(186, 30);
            this.gNUPlotToolStripMenuItem.Text = "GNU Plot";
            this.gNUPlotToolStripMenuItem.Click += new System.EventHandler(this.gNUPlotToolStripMenuItem_Click);
            // 
            // saveChartToolStripMenuItem
            // 
            this.saveChartToolStripMenuItem.Enabled = false;
            this.saveChartToolStripMenuItem.Name = "saveChartToolStripMenuItem";
            this.saveChartToolStripMenuItem.Size = new System.Drawing.Size(186, 30);
            this.saveChartToolStripMenuItem.Text = "Save Chart!";
            this.saveChartToolStripMenuItem.Click += new System.EventHandler(this.saveChartToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(148, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // labelsToolStripMenuItem
            // 
            this.labelsToolStripMenuItem.Enabled = false;
            this.labelsToolStripMenuItem.Name = "labelsToolStripMenuItem";
            this.labelsToolStripMenuItem.Size = new System.Drawing.Size(146, 30);
            this.labelsToolStripMenuItem.Text = "Labels";
            this.labelsToolStripMenuItem.Click += new System.EventHandler(this.labelsToolStripMenuItem_Click);
            // 
            // drawToolStripMenuItem
            // 
            this.drawToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Graph_2D,
            this.dGraphToolStripMenuItem1});
            this.drawToolStripMenuItem.Name = "drawToolStripMenuItem";
            this.drawToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.drawToolStripMenuItem.Text = "Draw";
            // 
            // Graph_2D
            // 
            this.Graph_2D.Enabled = false;
            this.Graph_2D.Name = "Graph_2D";
            this.Graph_2D.Size = new System.Drawing.Size(173, 30);
            this.Graph_2D.Text = "2D Graph";
            this.Graph_2D.Click += new System.EventHandler(this.Graph_2D_Click);
            // 
            // dGraphToolStripMenuItem1
            // 
            this.dGraphToolStripMenuItem1.Enabled = false;
            this.dGraphToolStripMenuItem1.Name = "dGraphToolStripMenuItem1";
            this.dGraphToolStripMenuItem1.Size = new System.Drawing.Size(173, 30);
            this.dGraphToolStripMenuItem1.Text = "3D Graph";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instructionsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // instructionsToolStripMenuItem
            // 
            this.instructionsToolStripMenuItem.Name = "instructionsToolStripMenuItem";
            this.instructionsToolStripMenuItem.Size = new System.Drawing.Size(189, 30);
            this.instructionsToolStripMenuItem.Text = "Instructions";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(189, 30);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 567);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1124, 30);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(92, 25);
            this.toolStripStatusLabel1.Text = "Open File!";
            // 
            // GearBox
            // 
            this.GearBox.BackColor = System.Drawing.SystemColors.Window;
            this.GearBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GearBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GearBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.GearBox.Location = new System.Drawing.Point(12, 46);
            this.GearBox.Name = "GearBox";
            this.GearBox.Size = new System.Drawing.Size(175, 28);
            this.GearBox.TabIndex = 4;
            this.GearBox.Tag = "";
            this.GearBox.Visible = false;
            this.GearBox.SelectedIndexChanged += new System.EventHandler(this.gearItem_Change);
            // 
            // EingriffBox
            // 
            this.EingriffBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EingriffBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EingriffBox.Location = new System.Drawing.Point(12, 80);
            this.EingriffBox.Name = "EingriffBox";
            this.EingriffBox.Size = new System.Drawing.Size(175, 28);
            this.EingriffBox.TabIndex = 5;
            this.EingriffBox.Visible = false;
            this.EingriffBox.SelectedIndexChanged += new System.EventHandler(this.eingriffItem_Change);
            // 
            // moment_button
            // 
            this.moment_button.Location = new System.Drawing.Point(12, 243);
            this.moment_button.Name = "moment_button";
            this.moment_button.Size = new System.Drawing.Size(175, 48);
            this.moment_button.TabIndex = 6;
            this.moment_button.Text = "Bending Moment";
            this.moment_button.UseVisualStyleBackColor = true;
            this.moment_button.Visible = false;
            this.moment_button.Click += new System.EventHandler(this.moment_button_Click);
            // 
            // force_button
            // 
            this.force_button.Location = new System.Drawing.Point(12, 297);
            this.force_button.Name = "force_button";
            this.force_button.Size = new System.Drawing.Size(175, 48);
            this.force_button.TabIndex = 7;
            this.force_button.Text = "Surrounding Force";
            this.force_button.UseVisualStyleBackColor = true;
            this.force_button.Visible = false;
            this.force_button.Click += new System.EventHandler(this.force_button_Click);
            // 
            // stress_button
            // 
            this.stress_button.Location = new System.Drawing.Point(12, 351);
            this.stress_button.Name = "stress_button";
            this.stress_button.Size = new System.Drawing.Size(175, 48);
            this.stress_button.TabIndex = 8;
            this.stress_button.Text = "Bending Stress";
            this.stress_button.UseVisualStyleBackColor = true;
            this.stress_button.Visible = false;
            this.stress_button.Click += new System.EventHandler(this.stress_button_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(200, 179);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(148, 264);
            this.listBox1.TabIndex = 9;
            this.listBox1.Visible = false;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(415, 46);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(640, 480);
            this.chart1.TabIndex = 10;
            this.chart1.Text = "chart1";
            this.chart1.Visible = false;
            // 
            // ysiso_button
            // 
            this.ysiso_button.Location = new System.Drawing.Point(12, 125);
            this.ysiso_button.Name = "ysiso_button";
            this.ysiso_button.Size = new System.Drawing.Size(175, 48);
            this.ysiso_button.TabIndex = 11;
            this.ysiso_button.Text = "Max YSISO";
            this.ysiso_button.UseVisualStyleBackColor = true;
            this.ysiso_button.Visible = false;
            this.ysiso_button.Click += new System.EventHandler(this.ysiso_button_click);
            // 
            // ysidiniso_button
            // 
            this.ysidiniso_button.Location = new System.Drawing.Point(12, 179);
            this.ysidiniso_button.Name = "ysidiniso_button";
            this.ysidiniso_button.Size = new System.Drawing.Size(175, 48);
            this.ysidiniso_button.TabIndex = 12;
            this.ysidiniso_button.Text = "Max YSDINISO";
            this.ysidiniso_button.UseVisualStyleBackColor = true;
            this.ysidiniso_button.Visible = false;
            this.ysidiniso_button.Click += new System.EventHandler(this.ysidiniso_button_Click);
            // 
            // ContactLineCheckBox
            // 
            this.ContactLineCheckBox.CheckOnClick = true;
            this.ContactLineCheckBox.FormattingEnabled = true;
            this.ContactLineCheckBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.ContactLineCheckBox.Location = new System.Drawing.Point(200, 52);
            this.ContactLineCheckBox.Name = "ContactLineCheckBox";
            this.ContactLineCheckBox.Size = new System.Drawing.Size(148, 88);
            this.ContactLineCheckBox.TabIndex = 14;
            this.ContactLineCheckBox.Visible = false;
            this.ContactLineCheckBox.SelectedIndexChanged += new System.EventHandler(this.ContactLineCheckBox_SelectedIndexChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // extra_button
            // 
            this.extra_button.Location = new System.Drawing.Point(12, 405);
            this.extra_button.Name = "extra_button";
            this.extra_button.Size = new System.Drawing.Size(175, 48);
            this.extra_button.TabIndex = 15;
            this.extra_button.Text = "ExtraValue";
            this.extra_button.UseVisualStyleBackColor = true;
            this.extra_button.Visible = false;
            this.extra_button.Click += new System.EventHandler(this.extra_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 597);
            this.Controls.Add(this.extra_button);
            this.Controls.Add(this.ContactLineCheckBox);
            this.Controls.Add(this.ysidiniso_button);
            this.Controls.Add(this.ysiso_button);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.stress_button);
            this.Controls.Add(this.force_button);
            this.Controls.Add(this.moment_button);
            this.Controls.Add(this.EingriffBox);
            this.Controls.Add(this.GearBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graph Drawer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem drawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Graph_2D;
        private System.Windows.Forms.ToolStripMenuItem dGraphToolStripMenuItem1;
        private System.Windows.Forms.ComboBox GearBox;
        private System.Windows.Forms.ComboBox EingriffBox;
        private System.Windows.Forms.Button moment_button;
        private System.Windows.Forms.Button force_button;
        private System.Windows.Forms.Button stress_button;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button ysiso_button;
        private System.Windows.Forms.Button ysidiniso_button;
        private System.Windows.Forms.CheckedListBox ContactLineCheckBox;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gNUPlotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveChartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instructionsToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem labelsToolStripMenuItem;
        private System.Windows.Forms.Button extra_button;
    }
}

