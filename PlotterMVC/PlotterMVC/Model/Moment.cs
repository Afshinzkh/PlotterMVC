using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace MVCTest.Model
{
	public class Moment
	{
		public List<double> Matrix { get; set; }
		public string ID { get; set; }
		public string Type { get; set; }
		public string Unit { get; set; }
        public string Width { get; set; }
        public int contactLines = 0;
        


        public Moment()
		{
			Matrix = new List<double>();
		}
       
		public void readMoment(XElement el)
		{

            ID = el.Attribute("id").ToString();
            if (el.Attribute("unit") != null)
                Unit = el.Attribute("unit").ToString();
            Type = el.Attribute("type").ToString();

            Width = el.ToString().Split('>', '<')[2];

            foreach (XElement c in el.Descendants("c"))
			{
				// the elements of matrix will be added by the order which exist in the file
				// can be also convered to a two dimensional array
				Matrix.Add(double.Parse(c.Value, CultureInfo.InvariantCulture));
			}

            foreach (XElement r in el.Descendants("r"))
                contactLines++;

		}


    }
}
