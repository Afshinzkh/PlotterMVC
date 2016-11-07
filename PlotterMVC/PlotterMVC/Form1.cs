using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Windows.Forms.DataVisualization.Charting;
using MVCTest.View;
using MVCTest.Properties;
using AwokeKnowing.GnuplotCSharp;

namespace MVCTest
{

    // Form is reallly the view component which will implement the IModelObserver interface 
    // so that, it can invoke the valueIncremented function which is the implementation
    // Form also implements the IView interface to send the view changed event and to
    // set the controller associated with the view

    public partial class Form1 : Form, IView, IModelObserver
    {

        IController controller;


        
        public int[] lastIndex = new int[] {0,0};
        public double gearWidth;
        public int lastButtonClick = 0;
        public bool Graph2DButtonClick = false;

        public event gearViewHandler<IView> opened;
        public event gearViewHandler<IView> gearSelected;
        public event gearViewHandler<IView> ysiso_button_clicked;
        public event gearViewHandler<IView> ysidiniso_button_clicked;
        public event eingriffViewHandler<IView> moment_button_clicked;
        public event eingriffViewHandler<IView> force_button_clicked;
        public event eingriffViewHandler<IView> stress_button_clicked;
        public event eingriffViewHandler<IView> extra_button_clicked;

        // View will set the associated controller, this is how view is linked to the controller.
        public void setController(IController cont)
        {
            controller = cont;
        }
        
        public Form1()
        {
            InitializeComponent();
        }



        public void GearsCounted(IModel m, gearModelEventArgs e)
        {
            for(int i=1; i<=e.gearCount; i++)
            {
                GearBox.Items.Add("Gear " + i);
            }
            gearWidth = double.Parse(e.width, System.Globalization.CultureInfo.InvariantCulture);
        }

        public void EingriffsCounted(IModel m, eingriffModelEventArgs e)
        {
            for (int i = 1; i <= e.eingriffCount; i++)
            {
                EingriffBox.Items.Add("Eingriff " + i);
            }
        }

        public void ysisoAddtoList(IModel m, matrixModelEventArgs e)
        {
            double gearWidth = this.gearWidth;
            //Add List
            listBox1.Visible = true;
            listBox1.DataSource = e.theMatrix;

            ContactLineCheckBox.Items.Clear();
            ContactLineCheckBox.Visible = true;
            
            //Add Chart
            chart1.Series.Clear();
            chart1.Titles.Clear();
            Title tt = new Title();
            tt.Name = "ysisoTitle";
            tt.Text = "Max of Ysiso for Gear:" + e.gearCount;
            chart1.Titles.Add(tt);
            chart1.Tag = "Gear" + e.gearCount + "_maxYSISO";
            chart1.Visible = true;

            saveChartToolStripMenuItem.Enabled = true;
            gNUPlotToolStripMenuItem.Enabled = true;
            labelsToolStripMenuItem.Enabled = true;
            toolStripStatusLabel1.Text = "Save Chart!";
            

            chart1.ChartAreas[0].AxisX.Maximum = gearWidth;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Interval = 2;
            chart1.ChartAreas[0].AxisX.Title = ("Width (mm)");
            // This next Line is just added becsause there is a problem with xml, reading the unit
            string newUnit = e.unit.Split('"', '"')[1];
            chart1.ChartAreas[0].AxisY.Title = ("YSISO (" + newUnit + ")");

            int pointsNum = e.theMatrix.Count;
            double xwidth = gearWidth / (double)pointsNum;

            chart1.Series.Add("Max YSISO");
            chart1.Series[0].MarkerStyle = MarkerStyle.Circle;
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            ContactLineCheckBox.Items.Add("Max YSISO", true);
            double startPoint = 0.5555;
            for (int i = 0; i < pointsNum; i++)
            {
                chart1.Series["Max YSISO"].Points.AddXY((startPoint + i) * xwidth, e.theMatrix[i]);
                
            }


        }

        public void ysidinisoAddtoList(IModel m, matrixModelEventArgs e)
        {
            double gearWidth = this.gearWidth;
            //Add List
            listBox1.Visible = true;
            listBox1.DataSource = e.theMatrix;

            ContactLineCheckBox.Items.Clear();
            ContactLineCheckBox.Visible = true;


            //Add Chart
            chart1.Series.Clear();
            chart1.Titles.Clear();
            Title tt = new Title();
            tt.Name = "ysidinisoTitle";
            tt.Text = "Max of YSIDINISO for Gear:" + e.gearCount;
            chart1.Titles.Add(tt);
            chart1.Tag = "Gear" + e.gearCount + "_maxYSIDINISO";
            chart1.Visible = true;
            

            saveChartToolStripMenuItem.Enabled = true;
            gNUPlotToolStripMenuItem.Enabled = true;
            labelsToolStripMenuItem.Enabled = true;
            toolStripStatusLabel1.Text = "Save Chart!";

            chart1.ChartAreas[0].AxisX.Maximum = gearWidth;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Interval = 2;
            chart1.ChartAreas[0].AxisX.Title = ("Width (mm)");
            // This next Line is just added becsause there is a problem with xml, reading the unit
            string newUnit = e.unit.Split('"', '"')[1];
            chart1.ChartAreas[0].AxisY.Title = ("YSIDINISO (" + newUnit + ")");

            int pointsNum = e.theMatrix.Count;
            double xwidth = gearWidth / (double)pointsNum;

            chart1.Series.Add("Max YSIDINISO");
            chart1.Series[0].MarkerStyle = MarkerStyle.Circle;
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            ContactLineCheckBox.Items.Add("Max YSIDINISO", true);

            double startPoint = 0.5555;
            for (int i = 0; i < pointsNum; i++)
            {
                chart1.Series["Max YSIDINISO"].Points.AddXY((startPoint + i) * xwidth, e.theMatrix[i]);

            }


        }
        public void momentAddtoList(IModel m, matrixModelEventArgs e)
        {
            // get the width from global geraWidth value
            double gearWidth = this.gearWidth;
            //Add List
            listBox1.Visible = true;
            listBox1.DataSource = e.theMatrix;
            //MessageBox.Show(listBox1.Items.Count.ToString());
            //Add CheckBox
            ContactLineCheckBox.Items.Clear();
            ContactLineCheckBox.Visible = true;
            
            //Add Chart
            chart1.Series.Clear();
            chart1.Titles.Clear();
            Title tt = new Title();
            tt.Name = "MomentTitle";
            tt.Text = "Bending Moment for Gear:" + e.gearCount + " Mesh:" + e.eingriffCount;
            chart1.Titles.Add(tt);
            chart1.Tag = "Gear" + e.gearCount + "_Meshing" + e.eingriffCount + "_BendingMoment";
            chart1.Visible = true;

            saveChartToolStripMenuItem.Enabled = true;
            gNUPlotToolStripMenuItem.Enabled = true;
            labelsToolStripMenuItem.Enabled = true;
            toolStripStatusLabel1.Text = "Save Chart!";

            chart1.ChartAreas[0].AxisX.Maximum = gearWidth;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Interval = 2;
            chart1.ChartAreas[0].AxisX.Title = ("Width (mm)");

            // This next Line is just added becsause there is a problem with xml, reading the unit
            string newUnit = e.unit.Split('"', '"')[1];
            chart1.ChartAreas[0].AxisY.Title = ("Moment (" + newUnit + ")");

            // we devide points by three because we have 3 contact lines this can change
            // accroding to number of contact lines

            int contactLines = e.ContactLines;
            int pointsNum = e.theMatrix.Count / contactLines;
            double xwidth = gearWidth / (double)pointsNum;
            double startPoint = 0.5555;
           
            
            for(int seriesNum=0; seriesNum<contactLines; seriesNum++)
            {
                chart1.Series.Add("Moment " + (seriesNum + 1));
                chart1.Series[seriesNum].MarkerStyle = MarkerStyle.Diamond;
                chart1.Series[seriesNum].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                ContactLineCheckBox.Items.Add("Moment " + (seriesNum + 1), true);    
            }
            int flag = 0;
            for (int i=0; i<contactLines; i++)
            {
                for(int j=0; j<pointsNum; j++)
                    chart1.Series[i].Points.AddXY((startPoint + j) * xwidth, e.theMatrix[j + (pointsNum*flag)]);
                flag++;    
            }

            
            
        }

        public void forceAddtoList(IModel m, matrixModelEventArgs e)
        {
            double gearWidth = this.gearWidth;
            //Add List
            listBox1.Visible = true;
            listBox1.DataSource = e.theMatrix;

            ContactLineCheckBox.Items.Clear();
            ContactLineCheckBox.Visible = true;

            //Add Chart
            chart1.Series.Clear();
            chart1.Titles.Clear();
            Title tt = new Title();
            tt.Name = "ForceTitle";
            tt.Text = "Surrounding Force for Gear:" + e.gearCount + " Mesh:" + e.eingriffCount;
            chart1.Titles.Add(tt);
            chart1.Tag = "Gear" + e.gearCount + "_Meshing" + e.eingriffCount + "_SurroundingForce";
            chart1.Visible = true;

            saveChartToolStripMenuItem.Enabled = true;
            gNUPlotToolStripMenuItem.Enabled = true;
            labelsToolStripMenuItem.Enabled = true;
            toolStripStatusLabel1.Text = "Save Chart!";

            chart1.ChartAreas[0].AxisX.Maximum = gearWidth;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Interval = 2;
            chart1.ChartAreas[0].AxisX.Title = ("Width (mm)");
            // This next Line is just added becsause there is a problem with xml, reading the unit
            string newUnit = e.unit.Split('"', '"')[1];
            chart1.ChartAreas[0].AxisY.Title = ("Force (" + newUnit + ")");

            int contactLines = e.ContactLines;
            int pointsNum = e.theMatrix.Count / contactLines;
            double xwidth = gearWidth / (double)pointsNum;
            double startPoint = 0.5555;

            for (int seriesNum = 0; seriesNum < contactLines; seriesNum++)
            {
                chart1.Series.Add("Force " + (seriesNum + 1));
                chart1.Series[seriesNum].MarkerStyle = MarkerStyle.Circle;
                chart1.Series[seriesNum].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                ContactLineCheckBox.Items.Add("Force " + (seriesNum + 1), true);
            }

            int flag = 0;
            for (int i = 0; i < contactLines; i++)
            {
                for (int j = 0; j < pointsNum; j++)
                    chart1.Series[i].Points.AddXY((startPoint + j) * xwidth, e.theMatrix[j + (pointsNum * flag)]);
                flag++;
            }
        }

        public void stressAddtoList(IModel m, matrixModelEventArgs e)
        {
            double gearWidth = this.gearWidth;
            //Add List
            listBox1.Visible = true;
            listBox1.DataSource = e.theMatrix;

            ContactLineCheckBox.Items.Clear();
            ContactLineCheckBox.Visible = true;

            //Add Chart
            chart1.Series.Clear();
            chart1.Titles.Clear();
            Title tt = new Title();
            tt.Name = "StressTitle";
            tt.Text = "Bending Stress for Gear:" + e.gearCount + " Mesh:" + e.eingriffCount;
            chart1.Titles.Add(tt);
            chart1.Tag = "Gear" + e.gearCount + "_Meshing" + e.eingriffCount + "_BendingStress";
            chart1.Visible = true;

            saveChartToolStripMenuItem.Enabled = true;
            gNUPlotToolStripMenuItem.Enabled = true;
            labelsToolStripMenuItem.Enabled = true;
            toolStripStatusLabel1.Text = "Save Chart!";

            chart1.ChartAreas[0].AxisX.Maximum = gearWidth;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Interval = 2;
            chart1.ChartAreas[0].AxisX.Title = ("Width (mm)");
            // This next Line is just added becsause there is a problem with xml, reading the unit
            string newUnit = e.unit.Split('"', '"')[1];
            chart1.ChartAreas[0].AxisY.Title = ("Stress (" + newUnit + ")");

            int contactLines = e.ContactLines;
            int pointsNum = e.theMatrix.Count / contactLines;
            double xwidth = gearWidth / (double)pointsNum;
            double startPoint = 0.5555;

            for (int seriesNum = 0; seriesNum < contactLines; seriesNum++)
            {
                chart1.Series.Add("Stress " + (seriesNum + 1));
                chart1.Series[seriesNum].MarkerStyle = MarkerStyle.Square;
                chart1.Series[seriesNum].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                ContactLineCheckBox.Items.Add("Stress " + (seriesNum + 1), true);
            }

            int flag = 0;
            for (int i = 0; i < contactLines; i++)
            {
                for (int j = 0; j < pointsNum; j++)
                    chart1.Series[i].Points.AddXY((startPoint + j) * xwidth, e.theMatrix[j + (pointsNum * flag)]);
                flag++;
            }
        }

        public void extraAddtoList(IModel m, matrixModelEventArgs e)
        {
            double gearWidth = this.gearWidth;
            //Add List
            listBox1.Visible = true;
            listBox1.DataSource = e.theMatrix;

            ContactLineCheckBox.Items.Clear();
            ContactLineCheckBox.Visible = true;

            //Add Chart
            chart1.Series.Clear();
            chart1.Titles.Clear();
            Title tt = new Title();
            tt.Name = "ExtraTitle";
            tt.Text = "Extra Variable for Gear:" + e.gearCount + " Mesh:" + e.eingriffCount;
            chart1.Titles.Add(tt);
            chart1.Tag = "Gear" + e.gearCount + "_Meshing" + e.eingriffCount + "_ExtraValue";
            chart1.Visible = true;

            saveChartToolStripMenuItem.Enabled = true;
            gNUPlotToolStripMenuItem.Enabled = true;
            labelsToolStripMenuItem.Enabled = true;
            toolStripStatusLabel1.Text = "Save Chart!";

            chart1.ChartAreas[0].AxisX.Maximum = gearWidth;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Interval = 2;
            chart1.ChartAreas[0].AxisX.Title = ("Width (mm)");
            // This next Line is just added becsause there is a problem with xml, reading the unit
            string newUnit = e.unit.Split('"', '"')[1];
            chart1.ChartAreas[0].AxisY.Title = ("ExtraValue (" + newUnit + ")");

            int contactLines = e.ContactLines;
            int pointsNum = e.theMatrix.Count / contactLines;
            double xwidth = gearWidth / (double)pointsNum;
            double startPoint = 0.5555;

            for (int seriesNum = 0; seriesNum < contactLines; seriesNum++)
            {
                chart1.Series.Add("ExtraValue " + (seriesNum + 1));
                chart1.Series[seriesNum].MarkerStyle = MarkerStyle.Square;
                chart1.Series[seriesNum].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                ContactLineCheckBox.Items.Add("ExtraValue " + (seriesNum + 1), true);
            }

            int flag = 0;
            for (int i = 0; i < contactLines; i++)
            {
                for (int j = 0; j < pointsNum; j++)
                    chart1.Series[i].Points.AddXY((startPoint + j) * xwidth, e.theMatrix[j + (pointsNum * flag)]);
                flag++;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void gearItem_Change(object sender, EventArgs e)
        {
            
            int gearNumber = GearBox.SelectedIndex;
            EingriffBox.Items.Clear();
            EingriffBox.Items.Insert(0, "Select Eingriff");
            EingriffBox.SelectedIndex = 0;
            if (gearNumber != 0)
            {
                switch (lastButtonClick)
                {
                    case 4:
                        ysiso_button_clicked.Invoke(this, new gearViewEventArgs(gearNumber));
                        break;
                    case 5:
                        ysidiniso_button_clicked.Invoke(this, new gearViewEventArgs(gearNumber));
                        break;
                }
                        EingriffBox.Visible = true;
                ysiso_button.Visible = true;
                ysidiniso_button.Visible = true;
                gearSelected.Invoke(this, new gearViewEventArgs(gearNumber));
            }
       
        }

        private void eingriffItem_Change(object sender, EventArgs e)
        {
            int gearNumber = GearBox.SelectedIndex;
            int eingriffNumber = EingriffBox.SelectedIndex;
            
            if (eingriffNumber!=0)
            {
                switch(lastButtonClick)
                {
                    case 1:
                        moment_button_clicked.Invoke(this, new eingriffViewEventArgs(eingriffNumber, gearNumber));
                        break;
                    case 2:
                        force_button_clicked.Invoke(this, new eingriffViewEventArgs(eingriffNumber, gearNumber));
                        break;
                    case 3:
                        stress_button_clicked.Invoke(this, new eingriffViewEventArgs(eingriffNumber, gearNumber));
                        break;
                    case 6:
                        extra_button_clicked.Invoke(this, new eingriffViewEventArgs(eingriffNumber, gearNumber));
                        break;

                }

                moment_button.Visible = true;
                force_button.Visible = true;
                stress_button.Visible = true;
                extra_button.Visible = true;
            }
        }

        /***************** Implementation of toolStrip Buttons Click ********************/
        /********************************************************************************/

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GearBox.Items.Clear();
            EingriffBox.Items.Clear();
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "XML files|*.xml";
            //theDialog.InitialDirectory = openFilePath;
            //String path = "C:\\";
            
            theDialog.RestoreDirectory = false;
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                
                Graph_2D.Enabled = true;
                toolStripStatusLabel1.Text = "Choose your graph from Draw toolbar!";
                opened(this, new gearViewEventArgs(theDialog.FileName.ToString()));
                //  openFilePath = theDialog.FileName.ToString();
                if (Graph2DButtonClick )
                    Graph_2D_Click(this, e);

            }
        } // End of openToolStrip

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by:\nAfshin Loni\nTobias Pauker\nNovember 2015 ");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
          this.Close();
        }

       
        private void Graph_2D_Click(object sender, EventArgs e)
        {
            Graph2DButtonClick = true;
            toolStripStatusLabel1.Text = "Ready!";
            GearBox.Visible = true;
            GearBox.Items.Insert(0,  "Select Gear");
            GearBox.SelectedIndex = 0;
            
        }

        private void saveChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveQualityChartImage Thechart = new saveQualityChartImage(chart1);
            toolStripStatusLabel1.Text = "Ready!";
            
        } //end of saveChartToolStripMenuItem_Click

        private void gNUPlotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            double gearWidth = this.gearWidth;
      
            int numberOfPoints = chart1.Series[0].Points.Count();
            int contactLines = chart1.Series.Count();

            double xwidth = gearWidth / (double)numberOfPoints;
            double startPoint = 0.5555;

            // Each contact Line has a matrix, and if there is less than 4 the series are not gonna be used 
            double[] Series_X = new double[numberOfPoints];
            double[] Series1_Y = new double[numberOfPoints];
            double[] Series2_Y = new double[numberOfPoints];
            double[] Series3_Y = new double[numberOfPoints];
            double[] Series4_Y = new double[numberOfPoints];
            double[] Series5_Y = new double[numberOfPoints];
            List<double[]> Series_Y_List = new List<double[]>();

            // Add arrays to the list according to the number of contact lines
            for (int i= 0; i<contactLines; i++)
            {
                Series_Y_List.Add(new double[numberOfPoints]);
            }


            // First fill in the x Series
            for (int i = 0; i < numberOfPoints; i++)
            {
                Series_X[i] = (startPoint + i) * xwidth;
            }

            // Now Fill in the y series
            for (int i = 0; i < contactLines; i++)
            {
                for (int j = 0; j < numberOfPoints; j++)
                {
                    Series_Y_List[i][j] = Convert.ToDouble(listBox1.Items[i * numberOfPoints + j].ToString());
                }
            }

            //// First fill in the x Series
            //for (int i = 0; i < numberOfPoints; i++)
            //{
            //    Series_X[i] = (startPoint + i) * xwidth;
            //}
            
            //// Now the Y Series
            //for (int i=0; i<numberOfPoints; i++)
            //{
            //    Series1_Y[i] = Convert.ToDouble(listBox1.Items[0 * numberOfPoints + i].ToString());
            //    if (contactLines > 1)
            //        Series2_Y[i] = Convert.ToDouble(listBox1.Items[1 * numberOfPoints + i].ToString());
            //    if (contactLines > 2)
            //        Series3_Y[i] = Convert.ToDouble(listBox1.Items[2 * numberOfPoints + i].ToString());
            //    if (contactLines > 3)
            //        Series4_Y[i] = Convert.ToDouble(listBox1.Items[3 * numberOfPoints + i].ToString());
            //    if (contactLines > 4)
            //        Series5_Y[i] = Convert.ToDouble(listBox1.Items[4 * numberOfPoints + i].ToString());
            //    if (contactLines > 5)
            //        throw new Exception("Contact Lines are more than five the code needs change for GNU Plot");
            //}


            GnuPlot.HoldOn();
            GnuPlot.Set("key outside");

            // To just get the checked items and see which series are unchecked
            var legendsTitle = ContactLineCheckBox.CheckedItems;


            GnuPlot.setStringValue("GraphTT ", chart1.Titles[0].Text);
            GnuPlot.setStringValue("AxX", chart1.ChartAreas[0].AxisX.Title);
            GnuPlot.setStringValue("AxY", chart1.ChartAreas[0].AxisY.Title);

            GnuPlot.Set("title GraphTT");
            GnuPlot.Set("xlabel AxX");
            GnuPlot.Set("ylabel AxY");


            // String list for Legend Titles
            List < string > TT = new List<string>();

            for (int i = 0; i < legendsTitle.Count; i++)
                TT.Add("TT" + i);

            // Add the PLots
            for (int i = 0; i < legendsTitle.Count; i++)
            {
                GnuPlot.setStringValue(TT[i], legendsTitle[i].ToString());
                GnuPlot.Plot(Series_X, Series_Y_List[i], "title " + TT[i] + " with linespoints");

                //switch(series[i])
                //{
                //    case 0:
                //        GnuPlot.setStringValue("TT1", legendsTitle[i].ToString());
                //        GnuPlot.Plot(Series_X, Series1_Y, "title TT1 with linespoints");
                //        break;
                //    case 1:
                //        GnuPlot.setStringValue("TT2", legendsTitle[i].ToString());
                //        GnuPlot.Plot(Series_X, Series2_Y, "title TT2 with linespoints");
                //        break;
                //    case 2:
                //        GnuPlot.setStringValue("TT3", legendsTitle[i].ToString());
                //        GnuPlot.Plot(Series_X, Series3_Y, "title TT3 with linespoints");
                //        break;
                //    case 3:
                //        GnuPlot.setStringValue("TT4", legendsTitle[i].ToString());
                //        GnuPlot.Plot(Series_X, Series4_Y, "title TT4 with linespoints");
                //        break;
                //    case 4:
                //        GnuPlot.setStringValue("TT5", legendsTitle[i].ToString());
                //        GnuPlot.Plot(Series_X, Series5_Y, "title TT5 with linespoints");
                //        break;
                //}
            }
               
        }

        /***************** End Implementation of toolStrip Buttons Click ********************/
        /************************************************************************************/


        /**************** Implementation of Buttons Clicks on the main window ************/
        /*********************************************************************************/
        private void moment_button_Click(object sender, EventArgs e)

        {
            
            lastButtonClick = 1;
            int eingriffNumber = EingriffBox.SelectedIndex;
            int gearNumber = GearBox.SelectedIndex;
            moment_button_clicked.Invoke(this, new eingriffViewEventArgs(eingriffNumber, gearNumber));
         

        }

 
        private void force_button_Click(object sender, EventArgs e)
        {
            
            lastButtonClick = 2;
            int eingriffNumber = EingriffBox.SelectedIndex;
            int gearNumber = GearBox.SelectedIndex;
            force_button_clicked.Invoke(this, new eingriffViewEventArgs(eingriffNumber, gearNumber));
        }

        private void stress_button_Click(object sender, EventArgs e)
        {
            
            lastButtonClick = 3;
            int eingriffNumber = EingriffBox.SelectedIndex;
            int gearNumber = GearBox.SelectedIndex;
            stress_button_clicked.Invoke(this, new eingriffViewEventArgs(eingriffNumber, gearNumber));

        }

        private void ysiso_button_click(object sender, EventArgs e)
        {
            
            lastButtonClick = 4;
            int gearNumber = GearBox.SelectedIndex;
            ysiso_button_clicked.Invoke(this, new gearViewEventArgs(gearNumber));
        }

        private void ysidiniso_button_Click(object sender, EventArgs e)
        {
            
            lastButtonClick = 5;
            int gearNumber = GearBox.SelectedIndex;
            ysidiniso_button_clicked.Invoke(this, new gearViewEventArgs(gearNumber));
        }

        private void extra_button_Click(object sender, EventArgs e)
        {
            lastButtonClick = 6;
            int eingriffNumber = EingriffBox.SelectedIndex;
            int gearNumber = GearBox.SelectedIndex;
            extra_button_clicked.Invoke(this, new eingriffViewEventArgs(eingriffNumber, gearNumber));
        }

        /**************** End of Implementation of Buttons Clicks on the main window ************/
        /****************************************************************************************/


        /********* Add or Remove a Contact Line from the chart ********************/
        /**************************************************************************/
        private void ContactLineCheckBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(chart1.Series[ContactLineCheckBox.SelectedIndex].Enabled == false)
                chart1.Series[ContactLineCheckBox.SelectedIndex].Enabled = true;
            else
                chart1.Series[ContactLineCheckBox.SelectedIndex].Enabled = false;
        }

        /********* Emphasizing the point selected in ListBox ********************/
        /**************************************************************************/
        // So here when you select a point on the list box the point will be 
        // Bold and bigger in the chart so you can see where is your point
        // if you want to restore to default, click on the corresponding drawing button again
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart1.Series[lastIndex[0]].Points[lastIndex[1]].MarkerSize = 5;
            int SerieIndex = listBox1.SelectedIndex / 18;
            int Pointindex = listBox1.SelectedIndex % 18;
            chart1.Series[SerieIndex].Points[Pointindex].MarkerSize += 3;
            lastIndex[0] = SerieIndex;
            lastIndex[1] = Pointindex;
        }

        private void labelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LabelSettingForm lForm = new LabelSettingForm(this);
            lForm.Show();
        }

        //The Following class is called from LabelSettingForm and changes the name of Labels
        public void chartLabelChange(string XAxis, string YAxis, string newTitle, string newLegend)
        {
            if (!string.IsNullOrWhiteSpace(XAxis))
                chart1.ChartAreas[0].AxisX.Title = XAxis;
            if (!string.IsNullOrWhiteSpace(YAxis))
                chart1.ChartAreas[0].AxisY.Title = YAxis;
            if (!string.IsNullOrWhiteSpace(newTitle))
            {
                chart1.Titles.Clear();
                Title tt = new Title();
                tt.Text = newTitle;
                chart1.Titles.Add(tt);
            }

            string[] legends = newLegend.Split(',');
            for(int i=0; i<legends.Count(); i++)
            {
                if (!string.IsNullOrWhiteSpace(legends[i]))
                    chart1.Series[i].Name = legends[i];
            }
        }


    }
    


}
