#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Media;
using Syncfusion.UI.Xaml.Core;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI;
using Windows.UI;

namespace syncfusion.schedulerdemos.winui
{
    public class GettingStartedViewModel : NotificationObject, IDisposable
    {
        private ScheduleAppointmentCollection events;

        public GettingStartedViewModel()
        {
            Events = GenerateRandomAppointments();
            MinDate = DateTime.Now.Date.AddMonths(-3);
            MaxDate = DateTime.Now.AddMonths(3);
            DisplayDate = DateTime.Now.Date.AddHours(9);
            this.SchedulerViewTypes = SchedulerViewTypeHelper.GetSchedulerViewTypes();
            this.TimelineViewTypes = SchedulerViewTypeHelper.GetTimelineViewTypes();
        }

        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }
        public DateTime DisplayDate { get; set; }

        /// <summary>
        /// Gets or sets scheduler view type collection
        /// </summary>
        public ObservableCollection<SchedulerViewTypeModel> SchedulerViewTypes { get; set; }

        /// <summary>
        /// Gets or sets scheduler view type collection
        /// </summary>
        public ObservableCollection<SchedulerViewTypeModel> TimelineViewTypes { get; set; }

        public ScheduleAppointmentCollection Events
        {
            get { return events; }
            set
            {
                events = value;
                RaisePropertyChanged("Events");
            }
        }

        /// <summary>
        /// Method to dispose objects.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isdisposable)
        {
            if (isdisposable)
            {
                if (this.Events != null)
                {
                    this.Events.Clear();
                    this.Events = null;
                }

                if (this.SchedulerViewTypes != null)
                {
                    this.SchedulerViewTypes.Clear();
                    this.SchedulerViewTypes = null;
                }

                if (this.TimelineViewTypes != null)
                {
                    this.TimelineViewTypes.Clear();
                    this.TimelineViewTypes = null;
                }
            }
        }

        /// <summary>
        /// Method to get foreground color based on background.
        /// </summary>
        /// <param name="backgroundColor"></param>
        /// <returns></returns>
        private Brush GetAppointmentForeground(Brush backgroundColor)
        {
            var brush = backgroundColor as SolidColorBrush;

            if (brush.Color.ToString().Equals("#FF8551F2") || brush.Color.ToString().Equals("#FF5363FA") || brush.Color.ToString().Equals("#FF2D99FF"))
                return new SolidColorBrush(Microsoft.UI.Colors.White);
            else
                return new SolidColorBrush(Color.FromArgb(255, 51, 51, 51));
        }

        private ScheduleAppointmentCollection GenerateRandomAppointments()
        {
            var WorkWeekDays = new ObservableCollection<DateTime>();
            var WorkWeekSubjects = new ObservableCollection<string>()
                                                           { "GoToMeeting", "Business Meeting", "Conference", "Project Status Discussion",
                                                             "Auditing", "Client Meeting", "Generate Report", "Target Meeting", "General Meeting" };

            var NonWorkingDays = new ObservableCollection<DateTime>();
            var NonWorkingSubjects = new ObservableCollection<string>()
                                                           { "Go to party", "Order Pizza", "Buy Gift",
                                                             "Vacation" };
            var YearlyOccurrance = new ObservableCollection<DateTime>();
            var YearlyOccurranceSubjects = new ObservableCollection<string>() { "Wedding Anniversary", "Sam's Birthday", "Jenny's Birthday" };
            var MonthlyOccurrance = new ObservableCollection<DateTime>();
            var MonthlyOccurranceSubjects = new ObservableCollection<string>() { "Pay House Rent", "Car Service", "Medical Check Up" };
            var WeekEndOccurrance = new ObservableCollection<DateTime>();
            var WeekEndOccurranceSubjects = new ObservableCollection<string>() { "FootBall Match", "TV Show" };


            var brush = new ObservableCollection<SolidColorBrush>();

            brush.Add(new SolidColorBrush(Color.FromArgb(255, 133, 81, 242)));
            brush.Add(new SolidColorBrush(Color.FromArgb(255, 140, 245, 219)));
            brush.Add(new SolidColorBrush(Color.FromArgb(255, 83, 99, 250)));
            brush.Add(new SolidColorBrush(Color.FromArgb(255, 255, 222, 133)));
            brush.Add(new SolidColorBrush(Color.FromArgb(255, 45, 153, 255)));
            brush.Add(new SolidColorBrush(Color.FromArgb(255, 253, 183, 165)));
            brush.Add(new SolidColorBrush(Color.FromArgb(255, 198, 237, 115)));
            brush.Add(new SolidColorBrush(Color.FromArgb(255, 253, 185, 222)));
            brush.Add(new SolidColorBrush(Color.FromArgb(255, 83, 99, 250)));

            Random ran = new Random();
            DateTime today = DateTime.Now;
            if (today.Month == 12)
            {
                today = today.AddMonths(-1);
            }
            else if (today.Month == 1)
            {
                today = today.AddMonths(1);
            }

            DateTime startMonth = new DateTime(today.Year, today.Month - 1, 1, 0, 0, 0);
            DateTime endMonth = new DateTime(today.Year, today.Month + 1, 30, 0, 0, 0);
            DateTime dt = new DateTime(today.Year, today.Month, 15, 0, 0, 0);
            int day = (int)startMonth.DayOfWeek;
            DateTime CurrentStart = startMonth.AddDays(-day);

            var appointments = new ScheduleAppointmentCollection();
            for (int i = 0; i < 90; i++)
            {
                if (i % 7 == 0 || i % 7 == 6)
                {
                    //add weekend appointments
                    NonWorkingDays.Add(CurrentStart.AddDays(i));
                }
                else
                {
                    //Add Workweek appointment
                    WorkWeekDays.Add(CurrentStart.AddDays(i));
                }
            }

            for (int i = 0; i < 50; i++)
            {
                DateTime date = WorkWeekDays[ran.Next(0, WorkWeekDays.Count)].AddHours(ran.Next(9, 17));

                var appointment = new ScheduleAppointment();

                appointment.StartTime = date;
                appointment.EndTime = date.AddHours(1);
                appointment.AppointmentBackground = brush[i % brush.Count];
                appointment.Foreground = GetAppointmentForeground(appointment.AppointmentBackground);
                appointment.Subject = WorkWeekSubjects[i % WorkWeekSubjects.Count];

                appointments.Add(appointment);
            }
            int j = 0;
            int k = 0;
            int l = 0;

            while (j < YearlyOccurranceSubjects.Count)
            {
                DateTime date = NonWorkingDays[ran.Next(0, NonWorkingDays.Count)];
                var appointment = new ScheduleAppointment();

                appointment.StartTime = date;
                appointment.EndTime = date.AddHours(1);
                appointment.AppointmentBackground = brush[1];
                appointment.Foreground = GetAppointmentForeground(appointment.AppointmentBackground);
                appointment.Subject = YearlyOccurranceSubjects[j];

                appointments.Add(appointment);
                j++;
            }
            while (k < MonthlyOccurranceSubjects.Count)
            {
                DateTime date = NonWorkingDays[ran.Next(0, NonWorkingDays.Count)].AddHours(ran.Next(9, 23));
                var appointment = new ScheduleAppointment();

                appointment.StartTime = date;
                appointment.EndTime = date.AddHours(1);
                appointment.AppointmentBackground = brush[k];
                appointment.Foreground = GetAppointmentForeground(appointment.AppointmentBackground);
                appointment.Subject = MonthlyOccurranceSubjects[k];

                appointments.Add(appointment);
                k++;
            }
            while (l < WeekEndOccurranceSubjects.Count)
            {
                DateTime date = NonWorkingDays[ran.Next(0, NonWorkingDays.Count)].AddHours(ran.Next(0, 23));
                var appointment = new ScheduleAppointment();

                appointment.StartTime = date;
                appointment.EndTime = date.AddHours(1);
                appointment.AppointmentBackground = brush[l];
                appointment.Foreground = GetAppointmentForeground(appointment.AppointmentBackground);
                appointment.Subject = WeekEndOccurranceSubjects[l];

                appointments.Add(appointment);
                l++;
            }

            return appointments;
        }
    }
}
