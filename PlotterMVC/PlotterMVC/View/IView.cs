using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCTest
{
        //This Handler is used for gear number and also the path of our xml file
        public delegate void gearViewHandler<IView>(IView sender, gearViewEventArgs e);
        // this Handler is used for eingriff number
        public delegate void eingriffViewHandler<IView>(IView sender, eingriffViewEventArgs e);
        
        
        // The event arguments class that will be used while firing the events
        public class gearViewEventArgs: EventArgs 
        {
            public int gearnumber;
            public string path;
            public gearViewEventArgs(int gNumber) { gearnumber = gNumber; }
            public gearViewEventArgs(string p) { path = p; }
        }
        public class eingriffViewEventArgs: EventArgs 
        {
            public int eingriffNumber;
            public int gearNumber;
            public eingriffViewEventArgs(int eNumber, int gNumber)
            {
                eingriffNumber = eNumber;
                gearNumber = gNumber;
            }
        }


        // Currently, the interface only contains the method to set the controller to which
        // it is tied. The rest of the view related code is implemented in the form.
        public interface IView
        {
            event gearViewHandler<IView> opened;
            event gearViewHandler<IView> gearSelected;
            event gearViewHandler<IView> ysiso_button_clicked;
            event gearViewHandler<IView> ysidiniso_button_clicked;
            event eingriffViewHandler<IView> moment_button_clicked;
            event eingriffViewHandler<IView> force_button_clicked;
            event eingriffViewHandler<IView> stress_button_clicked;
            event eingriffViewHandler<IView> extra_button_clicked;
            void setController(IController cont);
        }

}
