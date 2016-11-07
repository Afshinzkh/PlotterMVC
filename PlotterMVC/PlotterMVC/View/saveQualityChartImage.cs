using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MVCTest.View
{
    class saveQualityChartImage
    {
        Chart theChart;
        System.Drawing.Font oldFont1 = new System.Drawing.Font("Trebuchet MS", 35F, System.Drawing.FontStyle.Bold);
        System.Drawing.Font oldFont2 = new System.Drawing.Font("Trebuchet MS", 15F, System.Drawing.FontStyle.Bold);
        System.Drawing.Font oldFont3 = new System.Drawing.Font("Trebuchet MS", 35F, System.Drawing.FontStyle.Bold);
        System.Drawing.Font oldLegendFont = new System.Drawing.Font("Trebuchet MS", 35F, System.Drawing.FontStyle.Bold);

        int oldLineWidth1;
        int oldLineWidth2;
        int oldLineWidth3;
        int oldLineWidth4;
        int oldMarkerSize;

        int oldWidth;
        int oldHeight;
        public saveQualityChartImage(Chart inputChart)
        {
            if (!(inputChart.Series.Count > 0))
            {
                return;
            }
            theChart = inputChart;
            if (inputChart.Titles.Count > 0)
            {
                oldFont1 = inputChart.Titles[0].Font;
            }
            oldFont2 = inputChart.ChartAreas[0].AxisX.LabelStyle.Font;
            oldFont3 = inputChart.ChartAreas[0].AxisX.TitleFont;

            oldLegendFont = theChart.Legends[0].Font;
            
            oldLineWidth1 = theChart.ChartAreas[0].AxisX.LineWidth;
            oldLineWidth2 = theChart.ChartAreas[0].AxisX.MajorTickMark.LineWidth;
            oldLineWidth3 = theChart.Series[0].BorderWidth;
            oldLineWidth4 = theChart.ChartAreas[0].AxisY.MajorGrid.LineWidth;
            oldMarkerSize = theChart.Series[0].MarkerSize;
            oldWidth = theChart.Width;
            oldHeight = theChart.Height;

            saveimage();
        }

        public void saveimage()
        {
            theChart.Visible = false;
            System.Drawing.Font chtFont = new System.Drawing.Font("Trebuchet MS", 35F, System.Drawing.FontStyle.Bold);
            System.Drawing.Font smallFont = new System.Drawing.Font("Trebuchet MS", 15F, System.Drawing.FontStyle.Bold);
            if (theChart.Titles.Count > 0)
            {
                theChart.Titles[0].Font = chtFont;
            }

            theChart.ChartAreas[0].AxisX.TitleFont = chtFont;
            theChart.ChartAreas[0].AxisX.LineWidth = 3;
            theChart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 3;
            theChart.ChartAreas[0].AxisX.LabelStyle.Font = smallFont;
            theChart.ChartAreas[0].AxisX.MajorTickMark.LineWidth = 3;

            theChart.ChartAreas[0].AxisY.TitleFont = chtFont;
            theChart.ChartAreas[0].AxisY.LineWidth = 3;

            theChart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 3;
            theChart.ChartAreas[0].AxisY.LabelStyle.Font = smallFont;
            theChart.ChartAreas[0].AxisY.MajorTickMark.LineWidth = 3;
            if (theChart.Legends.Count > 0)
            {
                foreach (Legend legends in theChart.Legends)
                {
                    legends.Font = smallFont;
                }
            }


            foreach (Series series in theChart.Series)
            {
                series.BorderWidth = 5;
                series.MarkerSize = 10;
                

            }

            theChart.Width = 1800;
            theChart.Height = 1200;

            SaveFileDialog theDialog = new SaveFileDialog();
            theDialog.Title = "Save Chart";
            theDialog.Filter = "PNG Image|*.png|JPeg Image|*.jpeg";
            theDialog.RestoreDirectory = false;

            theDialog.FileName = theChart.Tag.ToString();
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                if (theDialog.FilterIndex == 1) theChart.SaveImage(theDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                else if (theDialog.FilterIndex == 2) theChart.SaveImage(theDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
                //SaveFileDialog save = new SaveFileDialog();
                //save.DefaultExt = ".png";
                //if (save.ShowDialog() == DialogResult.OK)
                //{
               // theChart.SaveImage(save.FileName, ChartImageFormat.Png);
            //}
            resetOldValues();

        }

        private void resetOldValues()
        {
            if (theChart.Titles.Count > 0)
            {
                theChart.Titles[0].Font = oldFont1;
            }

            theChart.ChartAreas[0].AxisX.TitleFont = oldFont3;
            theChart.ChartAreas[0].AxisX.LineWidth = oldLineWidth1;
            theChart.ChartAreas[0].AxisX.MajorGrid.LineWidth = oldLineWidth4;
            theChart.ChartAreas[0].AxisX.LabelStyle.Font = oldFont2;
            theChart.ChartAreas[0].AxisX.MajorTickMark.LineWidth = oldLineWidth2;

            theChart.ChartAreas[0].AxisY.TitleFont = oldFont3;
            theChart.ChartAreas[0].AxisY.LineWidth = oldLineWidth1;
            theChart.ChartAreas[0].AxisY.MajorGrid.LineWidth = oldLineWidth4;
            theChart.ChartAreas[0].AxisY.LabelStyle.Font = oldFont2;
            theChart.ChartAreas[0].AxisY.MajorTickMark.LineWidth = oldLineWidth2;

            foreach (Legend legends in theChart.Legends)
            {
                legends.Font = oldLegendFont;
            }



            foreach (Series series in theChart.Series)
            {
                series.BorderWidth = oldLineWidth3;
                series.MarkerSize = oldMarkerSize;

            }

            theChart.Width = oldWidth;
            theChart.Height = oldHeight;
            theChart.Visible = true;
        }
    }
}
