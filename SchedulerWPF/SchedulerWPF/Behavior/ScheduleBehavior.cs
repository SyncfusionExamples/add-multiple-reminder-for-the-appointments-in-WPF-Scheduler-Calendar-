using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SchedulerWPF
{
    public class ScheduleBehavior : Behavior<Grid>
    {
        Grid grid;
        SfScheduler schedule;
        protected override void OnAttached()
        {
            grid = this.AssociatedObject as Grid;
            schedule = grid.Children[0] as SfScheduler;
            schedule.AppointmentEditorOpening += OnAppointmentEditorOpening;
        }

        private void OnAppointmentEditorOpening(object sender, AppointmentEditorOpeningEventArgs e)
        {
            e.AppointmentEditorOptions = AppointmentEditorOptions.All | (~AppointmentEditorOptions.Background & ~AppointmentEditorOptions.Foreground & ~AppointmentEditorOptions.Reminder & ~AppointmentEditorOptions.Resource);
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            grid = null;
            schedule = null;
        }
    }
}
