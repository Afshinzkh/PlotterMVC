using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Collections;
using MVCTest.Model;


namespace MVCTest
{
    public delegate void gearModelHandler<IModel>(IModel sender, gearModelEventArgs e);
    public delegate void eingriffModelHandler<IModel>(IModel sender, eingriffModelEventArgs e);
    public delegate void matrixModelHandler<IModel>(IModel sender, matrixModelEventArgs e);
    // The ModelEventArgs classes which is derived from th EventArgs class to 
    // be passed on to the controller when the value is changed, same naming as viewEventArgs
    public class gearModelEventArgs : EventArgs
    {
        public int gearCount;
        public string width;
        public gearModelEventArgs(int gcount, string gwidth)
        {
            gearCount = gcount;
            width = gwidth;
        }
    }
    public class eingriffModelEventArgs : EventArgs
    {
        //public int newval;
        public int eingriffCount;

        public eingriffModelEventArgs(int ecount)
        {
            eingriffCount = ecount;
        }
    }
    public class matrixModelEventArgs : EventArgs
    {
        //public int newval;
        public List<double> theMatrix;
        public int eingriffCount;
        public int gearCount;
        public string unit;
        public int ContactLines;

        public matrixModelEventArgs(List<double> Mat, int gCount, int eCount, string u, int c)
        {
            theMatrix = Mat;
            gearCount = gCount;
            eingriffCount = eCount;
            unit = u;
            ContactLines = c;
            
        }
    }

    // The interface which the form/view must implement so that, the event will be
    // fired when a value is changed in the model.
    public interface IModelObserver
    {
        void GearsCounted(IModel model, gearModelEventArgs e);
        void EingriffsCounted(IModel model, eingriffModelEventArgs e);
        void ysisoAddtoList(IModel model, matrixModelEventArgs e);
        void ysidinisoAddtoList(IModel model, matrixModelEventArgs e);
        void momentAddtoList(IModel model, matrixModelEventArgs e);
        void forceAddtoList(IModel model, matrixModelEventArgs e);
        void stressAddtoList(IModel model, matrixModelEventArgs e);
        void extraAddtoList(IModel model, matrixModelEventArgs e);
    }

    // The Model interface where we can attach the function to be notified when value
    // is changed. An actual data manipulation function increment which increments the value
    // A setvalue function which sets the value when users changes the textbox
    public interface IModel
    {
        void attach(IModelObserver imo);

        void parse(string path);
        void EingriffCount(int gearNum);
        void YsisoMatrix(int gearNum);
        void YsidinisoMatrix(int gearNum);
        void MomentMatrix(int gearNum, int eingriffNum);
        void ForceMatrix(int gearNum, int eingriffNum);
        void StressMatrix(int gearNum, int eingriffNum);
        void ExtraMatrix(int gearNum, int eingriffNum);
        void Clear();
    }

    public class IncModel : IModel
    {
        public event gearModelHandler<IncModel> gearChanged;
        public event eingriffModelHandler<IncModel> eingriffChanged;
        public event matrixModelHandler<IncModel> momentAdded;
        public event matrixModelHandler<IncModel> forceAdded;
        public event matrixModelHandler<IncModel> stressAdded;
        public event matrixModelHandler<IncModel> extraAdded;
        public event matrixModelHandler<IncModel> ysisoAdded;
        public event matrixModelHandler<IncModel> ysidinisoAdded;

        List<Gear> gears = new List<Gear>();


        
        // Attach the function which is implementing the IModelObserver so that it can be
        // notified when a value is changed
        public void attach(IModelObserver imo)
        {
            gearChanged += new gearModelHandler<IncModel>(imo.GearsCounted);
            eingriffChanged += new eingriffModelHandler<IncModel>(imo.EingriffsCounted);
            momentAdded += new matrixModelHandler<IncModel>(imo.momentAddtoList);
            forceAdded += new matrixModelHandler<IncModel>(imo.forceAddtoList);
            stressAdded += new matrixModelHandler<IncModel>(imo.stressAddtoList);
            extraAdded += new matrixModelHandler<IncModel>(imo.extraAddtoList);
            ysisoAdded += new matrixModelHandler<IncModel>(imo.ysisoAddtoList);
            ysidinisoAdded += new matrixModelHandler<IncModel>(imo.ysidinisoAddtoList);
        }

        public void parse(string path)
        {
            var gearElements = XDocument.Load(path).Descendants("components").Single().Elements("component");


            
            foreach (XElement el in gearElements)
            {
                var g = new Gear();
                g.readGear(el);
                
                gears.Add(g);
            }

            //this command gives the number of gears and sends it to view to add them on the droplist
            gearChanged.Invoke(this, new gearModelEventArgs(gears.Count, gears[0].Attributes[1].Width));
            	

        }

        //this class gives the number of eingriffs and sends it to view to add them on the droplist
        public void EingriffCount(int gearNum )
        {
            
            eingriffChanged.Invoke(this, new eingriffModelEventArgs(gears[gearNum-1].SubGears.Count));
        }

        public void YsisoMatrix(int gearNum)
        {
            List<double> yMatrix;
            string unit;
            if (gears[gearNum - 1].Attributes.Count > 2)
            {
                yMatrix = gears[gearNum - 1].Attributes[2].Matrix;
                unit = gears[gearNum - 1].Attributes[2].Unit;
                ysisoAdded.Invoke(this, new matrixModelEventArgs(yMatrix, gearNum, 0, unit, 1));
            }
        }
    

        public void YsidinisoMatrix(int gearNum)
        {
            List<double> ydMatrix;
            string unit;
            if (gears[gearNum - 1].Attributes.Count > 3)
            {
                ydMatrix = gears[gearNum - 1].Attributes[3].Matrix;
                unit = gears[gearNum - 1].Attributes[3].Unit;
                ysidinisoAdded.Invoke(this, new matrixModelEventArgs(ydMatrix, gearNum, 0, unit, 1));
            }
        }
        public void MomentMatrix(int gearNum, int eingriffNum)
        {
            List<double> mMatrix;
            string unit;
            int contactLines;
            mMatrix = gears[gearNum-1].SubGears[eingriffNum-1].Attributes[0].Matrix;
            unit = gears[gearNum - 1].SubGears[eingriffNum - 1].Attributes[0].Unit;
            contactLines = gears[gearNum - 1].SubGears[eingriffNum - 1].Attributes[0].contactLines;
            momentAdded.Invoke(this, new matrixModelEventArgs(mMatrix, gearNum, eingriffNum,unit, contactLines));
        }

        public void ForceMatrix(int gearNum, int eingriffNum)
        {
            List<double> fMatrix;
            string unit;
            int contactLines;
            fMatrix = gears[gearNum - 1].SubGears[eingriffNum - 1].Attributes[1].Matrix;
            unit = gears[gearNum - 1].SubGears[eingriffNum - 1].Attributes[1].Unit;
            contactLines = gears[gearNum - 1].SubGears[eingriffNum - 1].Attributes[0].contactLines;
            forceAdded.Invoke(this, new matrixModelEventArgs(fMatrix, gearNum, eingriffNum,unit, contactLines));
        }

        public void StressMatrix(int gearNum, int eingriffNum)
        {
            List<double> sMatrix;
            string unit;
            int contactLines;
            sMatrix = gears[gearNum - 1].SubGears[eingriffNum - 1].Attributes[2].Matrix;
            unit = gears[gearNum - 1].SubGears[eingriffNum - 1].Attributes[2].Unit;
            contactLines = gears[gearNum - 1].SubGears[eingriffNum - 1].Attributes[0].contactLines;
            stressAdded.Invoke(this, new matrixModelEventArgs(sMatrix, gearNum, eingriffNum,unit, contactLines));

        }

        // If there is an extra matrix in each engriff, we read it here
        public void ExtraMatrix(int gearNum, int eingriffNum)
        {
            List<double> exMatrix;
            string unit;
            int contactLines;
            if ( gears[gearNum - 1].SubGears[eingriffNum - 1].Attributes.Count > 3)
            {
                exMatrix = gears[gearNum - 1].SubGears[eingriffNum - 1].Attributes[3].Matrix;
                unit = gears[gearNum - 1].SubGears[eingriffNum - 1].Attributes[3].Unit;
                contactLines = gears[gearNum - 1].SubGears[eingriffNum - 1].Attributes[0].contactLines;
                extraAdded.Invoke(this, new matrixModelEventArgs(exMatrix, gearNum, eingriffNum, unit, contactLines));
            }
        }

        public void Clear()
        {
            this.gears.Clear();
        }
    }
}



