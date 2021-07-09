using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SchedulerWPF
{
    public class SchedulerViewModel : INotifyPropertyChanged
    {
        private ScheduleAppointmentCollection events;
        public SchedulerViewModel()
        {
            this.Events = new ScheduleAppointmentCollection();
            var scheduleAppointment = new ScheduleAppointment()
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(1),
                AppointmentBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF339933")),
                Subject = "Conference",
                Reminders = new ObservableCollection<SchedulerReminder>
                {
                    new SchedulerReminder { ReminderTimeInterval = new TimeSpan(0)},
                }
            };
            Events.Add(scheduleAppointment);
        }
                
        public ScheduleAppointmentCollection Events
        {
            get
            {
                return this.events;
            }
            set
            {
                this.events = value;
                this.RaiseOnPropertyChanged("ScheduleAppointmentCollection");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaiseOnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
