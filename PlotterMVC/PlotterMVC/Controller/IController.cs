using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCTest
{
    public interface IController
    {
    }

    public class IncController : IController
    {
        IView view;
        IModel model;

        // The controller which implements the IController interface ties the view and model 
        // together and attaches the view via the IModelInterface and addes the event
        // handler to the view_changed function. The view ties the controller to itself.
        public IncController(IView v, IModel m)
        {
            view = v;
            model = m;
            view.setController(this);
            model.attach((IModelObserver)view);
            view.opened += new gearViewHandler<IView>(this.xmlOpen);
            view.gearSelected += new gearViewHandler<IView>(this.selectGear);
            view.ysiso_button_clicked += new gearViewHandler<IView>(this.selectYsiso);
            view.ysidiniso_button_clicked += new gearViewHandler<IView>(this.selectYsidiniso);
            view.moment_button_clicked += new eingriffViewHandler<IView>(this.selectMoment);
            view.force_button_clicked += new eingriffViewHandler<IView>(this.selectForce);
            view.stress_button_clicked += new eingriffViewHandler<IView>(this.selectStress);
            view.extra_button_clicked += new eingriffViewHandler<IView>(this.selectExtra);
        }

        // events which gets fired from the view when the users changes the value

        public void xmlOpen(IView v, gearViewEventArgs e)
        {
            model.Clear();
            model.parse(e.path);
        }

        public void selectGear(IView v, gearViewEventArgs e)
        {
            model.EingriffCount(e.gearnumber);
            
        }

        public void selectYsiso(IView v, gearViewEventArgs e)
        {
            model.YsisoMatrix(e.gearnumber);

        }

        public void selectYsidiniso(IView v, gearViewEventArgs e)
        {
            model.YsidinisoMatrix(e.gearnumber);

        }

        public void selectMoment(IView v, eingriffViewEventArgs e)
        {

            model.MomentMatrix(e.gearNumber, e.eingriffNumber);
        }

        public void selectForce(IView v, eingriffViewEventArgs e)
        {

            model.ForceMatrix(e.gearNumber, e.eingriffNumber);
        }

        public void selectStress(IView v, eingriffViewEventArgs e)
        {

            model.StressMatrix(e.gearNumber, e.eingriffNumber);
        }
        public void selectExtra(IView v, eingriffViewEventArgs e)
        {

            model.ExtraMatrix(e.gearNumber, e.eingriffNumber);
        }
    }
}
