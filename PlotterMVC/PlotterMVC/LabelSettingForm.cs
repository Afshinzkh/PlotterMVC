using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MVCTest.View
{
    public partial class LabelSettingForm : Form
    {
        private Form1 mainForm;
        public LabelSettingForm(Form1 mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.AcceptButton = saveLabelButton;
        }

        
        private void saveLabelButton_Click(object sender, EventArgs e)
        {
            mainForm.chartLabelChange(AxisXLabelTextbox.Text, AxisYLabelTextbox.Text, TitleTextbox.Text, LegendTextbox.Text);
            this.Close();
            
        }
    }
}
