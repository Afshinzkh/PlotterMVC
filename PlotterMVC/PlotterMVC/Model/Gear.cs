using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Collections;

namespace MVCTest.Model
{
    public class Gear
    {

        public string ID { get; set; }
		public string Type { get; set; }
        public List<Moment> Attributes { get; set; }
		public List<Gear> SubGears { get; set; }

		public Gear()
		{
			Attributes = new List<Moment>();
			SubGears = new List<Gear>();
		}


		public void readGear(XElement el)
		{
			ID = el.Attribute("id").ToString();
			Type = el.Attribute("type").ToString();
            
           
			foreach (XElement subEl in el.Descendants("component"))
			{
				var subGear = new Gear();
				subGear.readGear(subEl);
				SubGears.Add(subGear);
			}

			foreach (XElement subEl in el.Elements("attribute"))
			{
                
                //Width = subEl.Attribute("type").Value;
               
                var m = new Moment();
				m.readMoment(subEl);
				Attributes.Add(m);
			}


		}
    }
}
