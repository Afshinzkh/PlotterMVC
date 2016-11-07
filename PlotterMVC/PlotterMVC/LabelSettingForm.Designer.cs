namespace MVCTest.View
{
    partial class LabelSettingForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AxisXLabelTextbox = new System.Windows.Forms.TextBox();
            this.LegendTextbox = new System.Windows.Forms.TextBox();
            this.TitleTextbox = new System.Windows.Forms.TextBox();
            this.AxisYLabelTextbox = new System.Windows.Forms.TextBox();
            this.saveLabelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "AxisX Label";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Legend (Seperate with ,)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Title";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "AxisY Label";
            // 
            // AxisXLabelTextbox
            // 
            this.AxisXLabelTextbox.Location = new System.Drawing.Point(202, 17);
            this.AxisXLabelTextbox.Name = "AxisXLabelTextbox";
            this.AxisXLabelTextbox.Size = new System.Drawing.Size(369, 26);
            this.AxisXLabelTextbox.TabIndex = 4;
            // 
            // LegendTextbox
            // 
            this.LegendTextbox.Location = new System.Drawing.Point(202, 113);
            this.LegendTextbox.Name = "LegendTextbox";
            this.LegendTextbox.Size = new System.Drawing.Size(369, 26);
            this.LegendTextbox.TabIndex = 7;
            // 
            // TitleTextbox
            // 
            this.TitleTextbox.Location = new System.Drawing.Point(202, 81);
            this.TitleTextbox.Name = "TitleTextbox";
            this.TitleTextbox.Size = new System.Drawing.Size(369, 26);
            this.TitleTextbox.TabIndex = 6;
            // 
            // AxisYLabelTextbox
            // 
            this.AxisYLabelTextbox.Location = new System.Drawing.Point(202, 49);
            this.AxisYLabelTextbox.Name = "AxisYLabelTextbox";
            this.AxisYLabelTextbox.Size = new System.Drawing.Size(369, 26);
            this.AxisYLabelTextbox.TabIndex = 5;
            // 
            // saveLabelButton
            // 
            this.saveLabelButton.Location = new System.Drawing.Point(35, 147);
            this.saveLabelButton.Name = "saveLabelButton";
            this.saveLabelButton.Size = new System.Drawing.Size(275, 41);
            this.saveLabelButton.TabIndex = 8;
            this.saveLabelButton.Text = "Save Changes";
            this.saveLabelButton.UseVisualStyleBackColor = true;
            this.saveLabelButton.Click += new System.EventHandler(this.saveLabelButton_Click);
            // 
            // LabelSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 210);
            this.Controls.Add(this.saveLabelButton);
            this.Controls.Add(this.AxisYLabelTextbox);
            this.Controls.Add(this.TitleTextbox);
            this.Controls.Add(this.LegendTextbox);
            this.Controls.Add(this.AxisXLabelTextbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "LabelSettingForm";
            this.Text = "LabelSettingForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox AxisXLabelTextbox;
        private System.Windows.Forms.TextBox LegendTextbox;
        private System.Windows.Forms.TextBox TitleTextbox;
        private System.Windows.Forms.TextBox AxisYLabelTextbox;
        private System.Windows.Forms.Button saveLabelButton;
    }
}