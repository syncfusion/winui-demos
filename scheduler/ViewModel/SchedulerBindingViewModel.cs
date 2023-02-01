#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Syncfusion.UI.Xaml.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI;
using Windows.UI;
using Windows.Foundation;

namespace Syncfusion.SchedulerDemos.WinUI
{
    public class SchedulerBindingViewModel : NotificationObject, IDisposable
    {
        #region Fields

        /// <summary>
        /// team management
        /// </summary>
        internal List<string> TeamManagement;

        /// <summary>
        /// Day view appointments
        /// </summary>
        internal List<string> DayViewAppointments;

        /// <summary>
        /// color collection
        /// </summary>
        internal List<Brush> ColorCollection;

        /// <summary>
        /// Day view notes
        /// </summary>
        internal List<string> DayViewNotes;

        /// <summary>
        /// Day view colors
        /// </summary>
        internal List<Brush> DayViewColors;

        /// <summary>
        /// current day meetings 
        /// </summary>
        private List<string> currentDayMeetings;

        /// <summary>
        /// Notes Collection.
        /// </summary>
        private List<string> notesCollection;

        /// <summary>
        /// Notes Collection.
        /// </summary>
        private List<string> noteCollection;
        /// <summary>
        /// minimum time meetings
        /// </summary>
        private List<string> minTimeMeetings;

        /// <summary>
        /// start time collection
        /// </summary>
        private List<DateTime> startTimeCollection;

        /// <summary>
        /// end time collection
        /// </summary>
        private List<DateTime> endTimeCollection;

        /// <summary>
        /// random numbers
        /// </summary>
        ////creating random number collection
        private List<int> randomNums = new List<int>();

        /// <summary>
        /// resource collection.
        /// </summary>
        private ObservableCollection<object> resources;

        /// <summary>
        /// Name collection for meeting.
        /// </summary>
        private List<string> nameCollection;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleViewModel" /> class.
        /// </summary>
        public SchedulerBindingViewModel()
        {
            this.Appointments = new ObservableCollection<Event>();
            this.MonthCellAppointments = new ObservableCollection<Airline>();
            this.CreateRandomNumbersCollection();
            this.CreateStartTimeCollection();
            this.CreateEndTimeCollection();
            this.CreateSubjectCollection();
            this.CreateColorCollection();
            this.InitializeDataForBookings();
            this.IntializeAppoitments();
            this.CreateRecurrsiveExceptionAppointments();
            this.CreateRecurrsiveAppointments();
            this.InitializeResources();
            this.BookingResourceAppointments();
            this.CreateMonthCellAppointments();
            this.CreateSpecialTimeRegionAppointments();
            this.InitializeAppointmentCustomization();
            this.CreateListViewAppointments();
            this.CreateDragDropAppointments();
            this.SchedulerViewTypes = SchedulerViewTypeHelper.GetSchedulerViewTypes();
            this.ResourceSchedulerViewTypes = SchedulerViewTypeHelper.GetResourceSchedulerViewTypes();
            DisplayDate = DateTime.Now.Date.AddHours(9);
            MinDate = DateTime.Now.Date;
            MaxDate = DateTime.Now.Date.AddMonths(6);
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets scheduler view type collection
        /// </summary>
        public ObservableCollection<SchedulerViewTypeModel> SchedulerViewTypes { get; set; }

        /// <summary>
        /// Gets or sets scheduler view type collection for Appointment customizaton sample.
        /// </summary>
        public ObservableCollection<SchedulerViewTypeModel> AppointmentCustomizationViewTypes { get; set; }

        /// <summary>
        /// Gets or sets scheduler view type collection for resource view sample.
        /// </summary>
        public ObservableCollection<SchedulerViewTypeModel> ResourceSchedulerViewTypes { get; set; }

        /// <summary>
        /// Gets or sets scheduler view type collection for time slot customization sample.
        /// </summary>
        public ObservableCollection<SchedulerViewTypeModel> TimeSlotCustomizationViewTypes { get; set; }

        /// <summary>
        /// Gets or sets appointments
        /// </summary>
        public ObservableCollection<Event> Appointments { get; set; }

        /// <summary>
        /// Gets or sets appointments for fare calendar
        /// </summary>
        public ObservableCollection<Airline> MonthCellAppointments { get; set; }

        /// <summary>
        /// Gets or sets recursive appointments.
        /// </summary>
        public ObservableCollection<Event> RecursiveAppointmentCollection { get; set; }

        /// <summary>
        /// Gets or sets recursive exception appointments.
        /// </summary>
        public ObservableCollection<Event> RecursiveExceptionAppointmentCollection { get; set; }

        /// <summary>
        /// Gets or sets resource appointments.
        /// </summary>
        public ObservableCollection<Event> ResourceAppointments { get; set; }

        /// <summary>
        /// Gets or sets appointments for special time region sample.
        /// </summary>
        public ObservableCollection<Event> SpecialTimeRegionAppointments { get; set; }

        /// <summary>
        /// Gets or sets list view appointments.
        /// </summary>
        public ObservableCollection<Event> ListViewAppointments { get; set; }

        /// <summary>
        /// Gets or sets drag and drop appointments.
        /// </summary>
        public ObservableCollection<Event> DragAndDropAppointments { get; set; }

        /// <summary>
        /// Gets or sets resource collection.
        /// </summary>
        public ObservableCollection<object> Resources
        {
            get
            {
                return resources;
            }

            set
            {
                resources = value;
                this.RaisePropertyChanged("Resources");
            }
        }

        /// <summary>
        /// Gets or sets display date
        /// </summary>
        public DateTime DisplayDate { get; set; }

        /// <summary>
        /// Gets or sets scheduler minimum  date
        /// </summary>
        public DateTime MinDate { get; set; }

        /// <summary>
        /// Gets or sets scheduler maximum date
        /// </summary>
        public DateTime MaxDate { get; set; }

        #endregion

        #region Methods

        #region creating RecurrsiveAppointments

        /// <summary>
        /// recursive appointments
        /// </summary>
        ////creating RecurrsiveAppointments
        private void CreateRecurrsiveExceptionAppointments()
        {
            this.RecursiveExceptionAppointmentCollection = new ObservableCollection<Event>();

            DateTime currentDate = DateTime.Now.AddMonths(-1);

            Event dailyEvent = new Event
            {
                EventName = "Daily scrum meeting",
                From = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 10, 0, 0),
                To = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 11, 0, 0),
                Color = new SolidColorBrush((Color.FromArgb(255, 191, 235, 97))),
                ForegroundColor = new SolidColorBrush(Color.FromArgb(255, 51, 51, 51)),
                RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=50",
                Id = 1
            };

            RecursiveExceptionAppointmentCollection.Add(dailyEvent);

            //Add ExceptionDates to avoid occurrence on specific dates.
            DateTime changedExceptionDate1 = DateTime.Now.AddDays(-1).Date;
            DateTime changedExceptionDate2 = DateTime.Now.Date.AddDays(4).Date;
            DateTime deletedExceptionDate1 = DateTime.Now.Date.AddDays(2);
            DateTime deletedExceptionDate2 = DateTime.Now.Date.AddDays(6);
            DateTime deletedExceptionDate3 = DateTime.Now.Date.AddDays(8);

            dailyEvent.RecurrenceExceptions = new ObservableCollection<DateTime>()
            {
                changedExceptionDate1,
                changedExceptionDate2,
                deletedExceptionDate1,
                deletedExceptionDate2,
            };

            //Change start time or end time of an occurrence.
            Event changedEvent = new Event
            {
                EventName = "Scrum meeting - Changed Occurrence",
                From = new DateTime(changedExceptionDate1.Year, changedExceptionDate1.Month, changedExceptionDate1.Day, 12, 0, 0),
                To = new DateTime(changedExceptionDate1.Year, changedExceptionDate1.Month, changedExceptionDate1.Day, 13, 0, 0),
                Color = new SolidColorBrush((Color.FromArgb(255, 45, 216, 175))),
                ForegroundColor = new SolidColorBrush(Color.FromArgb(255, 51, 51, 51)),
                RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=10",
                Id = 2,
                RecurrenceId = 1
            };
            RecursiveExceptionAppointmentCollection.Add(changedEvent);

            Event changedEvent1 = new Event
            {
                EventName = "Scrum meeting - Changed Occurrence",
                From = new DateTime(changedExceptionDate2.Year, changedExceptionDate2.Month, changedExceptionDate2.Day, 12, 0, 0),
                To = new DateTime(changedExceptionDate2.Year, changedExceptionDate2.Month, changedExceptionDate2.Day, 13, 0, 0),
                Color = new SolidColorBrush((Color.FromArgb(255, 83, 99, 250))),
                ForegroundColor = new SolidColorBrush((Color.FromArgb(255, 255, 255, 255))),

                Id = 3,
                RecurrenceId = 1
            };
            RecursiveExceptionAppointmentCollection.Add(changedEvent1);
        }

        #endregion creating RecurrsiveAppointments

        #region creating RecurrsiveAppointments

        /// <summary>
        /// recursive appointments
        /// </summary>
        ////creating RecurrsiveAppointments
        private void CreateRecurrsiveAppointments()
        {
            this.RecursiveAppointmentCollection = new ObservableCollection<Event>();

            DateTime currentDate = DateTime.Now.AddMonths(-1);

            Event dailyEvent = new Event
            {
                EventName = "Daily recurring meeting",
                From = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 9, 0, 0),
                To = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 10, 0, 0),
                Color = new SolidColorBrush((Color.FromArgb(255, 191, 235, 97))),
                ForegroundColor = new SolidColorBrush(Color.FromArgb(255, 51, 51, 51)),
                RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=100",
                RecurrenceExceptions = new ObservableCollection<DateTime>()
            };

            RecursiveAppointmentCollection.Add(dailyEvent);

            Event weeklyEvent = new Event
            {
                EventName = "Weekly recurring meeting",
                From = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 11, 0, 0),
                To = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 12, 0, 0),
                Color = new SolidColorBrush((Color.FromArgb(255, 45, 216, 175))),
                ForegroundColor = new SolidColorBrush(Color.FromArgb(255, 51, 51, 51)),
                RecurrenceRule = "FREQ=WEEKLY;BYDAY=MO,WE,FR;INTERVAL=1;COUNT=20",
                RecurrenceExceptions = new ObservableCollection<DateTime>()
            };

            RecursiveAppointmentCollection.Add(weeklyEvent);

            Event monthlyEvent = new Event
            {
                EventName = "Monthly recurring Meeting",
                From = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 12, 0, 0),
                To = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 13, 0, 0),
                Color = new SolidColorBrush(Microsoft.UI.Colors.Red),
                RecurrenceRule = "FREQ=MONTHLY;BYDAY=TU;BYSETPOS=1;INTERVAL=1;COUNT=50",
                RecurrenceExceptions = new ObservableCollection<DateTime>()
            };

            RecursiveAppointmentCollection.Add(monthlyEvent);

            Event yearlyEvent = new Event
            {
                EventName = "Yearly recurring Meeting",
                From = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 2, 0, 0),
                To = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 3, 0, 0),
                Color = new SolidColorBrush(Microsoft.UI.Colors.Yellow),
                RecurrenceRule = "FREQ=YEARLY;BYMONTHDAY=3;BYMONTH=5;INTERVAL=1;COUNT=50",
                RecurrenceExceptions = new ObservableCollection<DateTime>()
            };

            RecursiveAppointmentCollection.Add(yearlyEvent);
        }

        #endregion creating RecurrsiveAppointments

        #region Create month cell customization appointment
        /// <summary>
        /// Method to create appointments for fare calender
        /// </summary>
        private void CreateMonthCellAppointments()
        {
            List<string> Fares = new List<string>()
             {   "$134.50", "$305.00", "$152.66", "$267.09", "$189.20", "$212.10", "$238.83",
                 "$100.17", "$101.72", "$332.48" ,"$100.17", "$449.68", "$378.44", "$273.45",
                 "$134.50", "$305.00", "$152.66", "$267.09", "$189.20", "$212.10", "$238.83",
            };

            List<string> FlightNames = new List<string>() { "Airways 1", "Airways 2", "Airways 3" };
            Random random = new Random();

            var startDate = DateTime.Now.AddMonths(-1).Date.AddHours(9);
            for (int i = 0; i < 300; i++)
            {
                var airlineName = FlightNames[random.Next(0, 3)];
                this.MonthCellAppointments.Add(new Airline()
                {
                    Name = airlineName,
                    Fare = Fares[random.Next(0, 20)],
                    Color = GetAirlineColor(airlineName),
                    Date = startDate.AddDays(i),
                });
            }
        }
        #endregion

        private void InitializeResources()
        {
            Random random = new Random();
            this.Resources = new ObservableCollection<object>();
            this.nameCollection = new List<string>();
            this.nameCollection.Add("Sophia");
            this.nameCollection.Add("Danial William");
            this.nameCollection.Add("Stephen");
            this.nameCollection.Add("Kinsley Elena");
            this.nameCollection.Add("Emilia William");
            this.nameCollection.Add("James William");
            this.nameCollection.Add("Kinsley Ruby");
            this.nameCollection.Add("Emilia");
            this.nameCollection.Add("Stephen Addison");
            this.nameCollection.Add("Adeline Elena");
            this.nameCollection.Add("Danial Addison");
            this.nameCollection.Add("Daniel");
            this.nameCollection.Add("Zoey Addison");
            this.nameCollection.Add("Brooklyn");
            for (int i = 0; i < 7; i++)
            {
                Employee employee = new Employee();
                employee.Name = nameCollection[i];
                employee.BackgroundBrush = this.ColorCollection[random.Next(9)];
                employee.ID = i.ToString();
#if Main_SB
                employee.ImageSource = "/Scheduler/Assets/Scheduler/People_Circle" + i.ToString() + ".png";
#else
                employee.ImageSource = "/Assets/Scheduler/People_Circle" + i.ToString() + ".png";
#endif

                Resources.Add(employee);
            }
        }

        private Brush GetAirlineColor(string airlineName)
        {
            if (airlineName == "Airways 1")
                return new SolidColorBrush(Colors.Red);
            else if (airlineName == "Airways 2")
                return new SolidColorBrush(Colors.Green);
            else
                return new SolidColorBrush(Colors.Gray);
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
                if (this.Appointments != null)
                {
                    this.Appointments.Clear();
                    this.Appointments = null;
                }

                if (this.MonthCellAppointments != null)
                {
                    this.MonthCellAppointments.Clear();
                    this.MonthCellAppointments = null;
                }

                if (this.RecursiveAppointmentCollection != null)
                {
                    this.RecursiveAppointmentCollection.Clear();
                    this.RecursiveAppointmentCollection = null;
                }

                if (this.RecursiveExceptionAppointmentCollection != null)
                {
                    this.RecursiveExceptionAppointmentCollection.Clear();
                    this.RecursiveExceptionAppointmentCollection = null;
                }

                if (this.ResourceAppointments != null)
                {
                    this.ResourceAppointments.Clear();
                    this.ResourceAppointments = null;
                }

                if (this.SpecialTimeRegionAppointments != null)
                {
                    this.SpecialTimeRegionAppointments.Clear();
                    this.SpecialTimeRegionAppointments = null;
                }

                if (this.Resources != null)
                {
                    this.Resources.Clear();
                    this.Resources = null;
                }

                if (this.SchedulerViewTypes != null)
                {
                    this.SchedulerViewTypes.Clear();
                    this.SchedulerViewTypes = null;
                }

                if (this.AppointmentCustomizationViewTypes != null)
                {
                    this.AppointmentCustomizationViewTypes.Clear();
                    this.AppointmentCustomizationViewTypes = null;
                }

                if (this.ResourceSchedulerViewTypes != null)
                {
                    this.ResourceSchedulerViewTypes.Clear();
                    this.ResourceSchedulerViewTypes = null;
                }

                if (this.TimeSlotCustomizationViewTypes != null)
                {
                    this.TimeSlotCustomizationViewTypes.Clear();
                    this.TimeSlotCustomizationViewTypes = null;
                }
            }
        }

        #region BookingAppointments

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

        /// <summary>
        /// Method for booking appointments.
        /// </summary>
        private void BookingResourceAppointments()
        {
            Random randomTime = new Random();
            List<Point> randomTimeCollection = this.GettingTimeRanges();
            ResourceAppointments = new ObservableCollection<Event>();
            DateTime date;
            DateTime dateFrom = DateTime.Now.AddDays(-80);
            DateTime dateTo = DateTime.Now.AddDays(80);
            DateTime dateRangeStart = DateTime.Now.AddDays(-70);
            DateTime dateRangeEnd = DateTime.Now.AddDays(70);

            for (date = dateFrom; date < dateTo; date = date.AddDays(1))
            {
                if ((DateTime.Compare(date, dateRangeStart) > 0) && (DateTime.Compare(date, dateRangeEnd) < 0))
                {
                    for (int additionalAppointmentIndex = 0; additionalAppointmentIndex < 8; additionalAppointmentIndex++)
                    {
                        Event meeting = new Event();
                        meeting.From = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(0, 23), 0, 0);
                        meeting.To = meeting.From.AddHours(randomTime.Next(1, 3));
                        meeting.EventName = this.currentDayMeetings[randomTime.Next(9)];
                        meeting.Color = this.ColorCollection[randomTime.Next(9)];
                        meeting.ForegroundColor = GetAppointmentForeground(meeting.Color);
                        meeting.IsAllDay = false;

                        var coll = new ObservableCollection<object>
                            {
                                (resources[randomTime.Next(Resources.Count)] as Employee).ID
                            };
                        meeting.Resources = coll;

                        this.ResourceAppointments.Add(meeting);
                    }

                    for (int additionalAppointmentIndex = 0; additionalAppointmentIndex < 8; additionalAppointmentIndex++)
                    {
                        Event meeting = new Event();
                        meeting.From = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(7, 12), 0, 0);
                        meeting.To = meeting.From.AddHours(randomTime.Next(1, 3));
                        meeting.EventName = this.currentDayMeetings[randomTime.Next(9)];
                        meeting.Color = this.ColorCollection[randomTime.Next(9)];
                        meeting.ForegroundColor = GetAppointmentForeground(meeting.Color);
                        meeting.IsAllDay = false;

                        var coll = new ObservableCollection<object>
                            {
                                (resources[randomTime.Next(Resources.Count)] as Employee).ID
                            };
                        meeting.Resources = coll;

                        this.ResourceAppointments.Add(meeting);
                    }
                }
                else
                {
                    Event meeting = new Event();
                    meeting.From = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(0, 23), 0, 0);
                    meeting.To = meeting.From.AddDays(2).AddHours(1);
                    meeting.EventName = this.currentDayMeetings[randomTime.Next(9)];
                    meeting.Color = this.ColorCollection[randomTime.Next(9)];
                    meeting.ForegroundColor = GetAppointmentForeground(meeting.Color);
                    meeting.IsAllDay = true;
                    var coll = new ObservableCollection<object>
                            {
                                (resources[randomTime.Next(Resources.Count)] as Employee).ID
                            };
                    meeting.Resources = coll;
                    this.ResourceAppointments.Add(meeting);
                }

            }

            for (int i = 0; i < 3; i++)
            {
                Event meeting1 = new Event();
                meeting1.From = DateTime.Now.Date.AddHours(10);
                meeting1.To = meeting1.From.AddHours(randomTime.Next(1, 3));
                meeting1.EventName = this.currentDayMeetings[randomTime.Next(0, 10)];
                meeting1.Color = this.ColorCollection[randomTime.Next(0, 9)];
                meeting1.ForegroundColor = GetAppointmentForeground(meeting1.Color);
                meeting1.IsAllDay = false;

                var resourceCollection = new ObservableCollection<object>
                {
                    "1"
                };

                meeting1.Resources = resourceCollection;
                this.ResourceAppointments.Add(meeting1);
            }
        }

        #endregion BookingAppointments

        #region GettingTimeRanges

        /// <summary>
        /// Method for get timing range.
        /// </summary>
        /// <returns>return time collection</returns>
        private List<Point> GettingTimeRanges()
        {
            List<Point> randomTimeCollection = new List<Point>();
            randomTimeCollection.Add(new Point(9, 11));
            randomTimeCollection.Add(new Point(12, 14));
            randomTimeCollection.Add(new Point(15, 17));

            return randomTimeCollection;
        }

        #endregion GettingTimeRanges

        #region InitializeDataForBookings

        /// <summary>
        /// Method for initialize data bookings.
        /// </summary>
        private void InitializeDataForBookings()
        {
            this.currentDayMeetings = new List<string>();
            this.currentDayMeetings.Add("General Meeting");
            this.currentDayMeetings.Add("Plan Execution");
            this.currentDayMeetings.Add("Project Plan");
            this.currentDayMeetings.Add("Consulting");
            this.currentDayMeetings.Add("Performance Check");
            this.currentDayMeetings.Add("Yoga Therapy");
            this.currentDayMeetings.Add("Plan Execution");
            this.currentDayMeetings.Add("Project Plan");
            this.currentDayMeetings.Add("Consulting");
            this.currentDayMeetings.Add("Performance Check");

            // MinimumHeight Appointment Subjects
            this.minTimeMeetings = new List<string>();
            this.minTimeMeetings.Add("Work log alert");
            this.minTimeMeetings.Add("Birthday wish alert");
            this.minTimeMeetings.Add("Task due date");
            this.minTimeMeetings.Add("Status mail");
            this.minTimeMeetings.Add("Start sprint alert");

            this.notesCollection = new List<string>();
            this.notesCollection.Add("Consulting firm laws with business advisers");
            this.notesCollection.Add("Execute Project Scope");
            this.notesCollection.Add("Project Scope & Deliverables");
            this.notesCollection.Add("Executive summary");
            this.notesCollection.Add("Try to reduce the risks");
            this.notesCollection.Add("Encourages the integration of mind, body, and spirit");
            this.notesCollection.Add("Execute Project Scope");
            this.notesCollection.Add("Project Scope & Deliverables");
            this.notesCollection.Add("Executive summary");
            this.notesCollection.Add("Try to reduce the risk");

            this.noteCollection = new List<string>();
            this.noteCollection.Add("To show the status of multiple underlying simple alerts with one overall status.");
            this.noteCollection.Add("25th Celebration");
            this.noteCollection.Add("Date by which member should complete a task");
            this.noteCollection.Add("Helps you to establish reports for company, team, and individual usage");
            this.noteCollection.Add("Receive a warning regarding scope");
        }

        #endregion InitializeDataForBookings

        #region InitializeAppointments
        /// <summary>
        /// Initialize appointments
        /// </summary>
        /// <param name="count">count value</param>
        private void IntializeAppoitments()
        {
            Random randomTime = new Random();
            List<Point> randomTimeCollection = this.GettingTimeRanges();

            DateTime date;
            DateTime dateFrom = DateTime.Now.AddDays(-100);
            DateTime dateTo = DateTime.Now.AddDays(100);
            var random = new Random();
            var dateCount = random.Next(4);
            DateTime dateRangeStart = DateTime.Now.AddDays(0);
            DateTime dateRangeEnd = DateTime.Now.AddDays(1);

            for (date = dateFrom; date < dateTo; date = date.AddDays(1))
            {
                if (date.Day % 7 != 0)
                {
                    for (int additionalAppointmentIndex = 0; additionalAppointmentIndex < 1; additionalAppointmentIndex++)
                    {
                        Event meeting = new Event();
                        int hour = randomTime.Next((int)randomTimeCollection[additionalAppointmentIndex].X, (int)randomTimeCollection[additionalAppointmentIndex].Y);
                        meeting.From = new DateTime(date.Year, date.Month, date.Day, hour, 0, 0);
                        meeting.To = meeting.From.AddHours(1);
                        meeting.EventName = this.currentDayMeetings[randomTime.Next(9)];
                        meeting.Color = this.ColorCollection[randomTime.Next(9)];
                        meeting.ForegroundColor = GetAppointmentForeground(meeting.Color);
                        meeting.IsAllDay = false;
                        meeting.Notes = this.notesCollection[randomTime.Next(9)];
                        meeting.StartTimeZone = string.Empty;
                        meeting.EndTimeZone = string.Empty;
                        this.Appointments.Add(meeting);
                    }
                }
                else
                {
                    Event meeting = new Event();
                    meeting.From = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(9, 11), 0, 0);
                    meeting.To = meeting.From.AddDays(2).AddHours(1);
                    meeting.EventName = this.currentDayMeetings[randomTime.Next(9)];
                    meeting.Color = this.ColorCollection[randomTime.Next(9)];
                    meeting.ForegroundColor = GetAppointmentForeground(meeting.Color);
                    meeting.IsAllDay = true;
                    meeting.Notes = this.notesCollection[randomTime.Next(9)];
                    meeting.StartTimeZone = string.Empty;
                    meeting.EndTimeZone = string.Empty;
                    this.Appointments.Add(meeting);
                }
            }

            // Minimum Height Meetings
            DateTime minDate;
            DateTime minDateFrom = DateTime.Now.AddDays(-2);
            DateTime minDateTo = DateTime.Now.AddDays(2);

            for (minDate = minDateFrom; minDate < minDateTo; minDate = minDate.AddDays(1))
            {
                Event meeting = new Event();
                meeting.From = new DateTime(minDate.Year, minDate.Month, minDate.Day, randomTime.Next(9, 18), 30, 0);
                meeting.To = meeting.From;
                meeting.EventName = this.minTimeMeetings[randomTime.Next(0, 4)];
                meeting.Color = this.ColorCollection[randomTime.Next(9)];
                meeting.ForegroundColor = GetAppointmentForeground(meeting.Color);
                meeting.Notes = this.noteCollection[randomTime.Next(0, 4)];
                meeting.StartTimeZone = string.Empty;
                meeting.EndTimeZone = string.Empty;

                this.Appointments.Add(meeting);
            }
        }

        #endregion InitializeAppointments

        #region SubjectCollection

        /// <summary>
        /// Subject collection
        /// </summary>
        ////creating subject collection
        private void CreateSubjectCollection()
        {
            this.TeamManagement = new List<string>();
            this.TeamManagement.Add("General Meeting");
            this.TeamManagement.Add("Plan Execution");
            this.TeamManagement.Add("Project Plan");
            this.TeamManagement.Add("Consulting");
            this.TeamManagement.Add("Performance Check");
            this.TeamManagement.Add("General Meeting");
            this.TeamManagement.Add("Plan Execution");
            this.TeamManagement.Add("Project Plan");
            this.TeamManagement.Add("Consulting");
            this.TeamManagement.Add("Performance Check");
        }

        #endregion SubjectCollection

        #region creating color collection

        /// <summary>
        /// color collection
        /// </summary>
        ////creating color collection
        private void CreateColorCollection()
        {
            this.ColorCollection = new List<Brush>();
            this.ColorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 133, 81, 242)));
            this.ColorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 140, 245, 219)));
            this.ColorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 83, 99, 250)));
            this.ColorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 255, 222, 133)));
            this.ColorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 45, 153, 255)));
            this.ColorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 253, 183, 165)));
            this.ColorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 198, 237, 115)));
            this.ColorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 253, 185, 222)));
            this.ColorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 83, 99, 250)));
        }

        #endregion creating color collection

        #region CreateRandomNumbersCollection

        /// <summary>
        /// random numbers collection
        /// </summary>
        private void CreateRandomNumbersCollection()
        {
            this.randomNums = new List<int>();

            Random rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                int random = rand.Next(9, 15);
                this.randomNums.Add(random);
            }
        }

        #endregion CreateRandomNumbersCollection

        #region CreateStartTimeCollection

        /// <summary>
        /// start time collection
        /// </summary>
        //// creating StartTime collection
        private void CreateStartTimeCollection()
        {
            this.startTimeCollection = new List<DateTime>();
            DateTime currentDate = DateTime.Now;

            int count = 0;
            for (int i = -5; i < 5; i++)
            {
                DateTime startTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, this.randomNums[count], 0, 0);
                DateTime startDateTime = startTime.AddDays(i);
                this.startTimeCollection.Add(startDateTime);
                count++;
            }
        }

        #endregion CreateStartTimeCollection

        #region CreateEndTimeCollection

        /// <summary>
        /// end time collection
        /// </summary>
        ////  creating EndTime collection
        private void CreateEndTimeCollection()
        {
            this.endTimeCollection = new List<DateTime>();
            DateTime currentDate = DateTime.Now;
            int count = 0;
            for (int i = -5; i < 5; i++)
            {
                DateTime endTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, this.randomNums[count] + 1, 0, 0);
                DateTime endDateTime = endTime.AddDays(i);
                if (i == -3 || i == 3)
                {
                    endDateTime = endTime.AddDays(i).AddHours(22);
                }

                this.endTimeCollection.Add(endDateTime);
                count++;
            }
        }

        #endregion CreateEndTimeCollection

        #region SpecialTimeRegion appointments

        /// <summary>
        /// Method to create appointments for special time region sample.
        /// </summary>
        private void CreateSpecialTimeRegionAppointments()
        {
            Random randomTime = new Random();
            List<int> randomTimeCollection = new List<int>() { 9, 11, 12, 14, 15, 16, 17, 18 };
            this.SpecialTimeRegionAppointments = new ObservableCollection<Event>();
            DateTime date;
            DateTime dateFrom = DateTime.Now.AddDays(-100);
            DateTime dateTo = DateTime.Now.AddDays(100);
            var random = new Random();
            var dateCount = random.Next(4);
            DateTime dateRangeStart = DateTime.Now.AddDays(0);
            DateTime dateRangeEnd = DateTime.Now.AddDays(1);

            for (date = dateFrom; date < dateTo; date = date.AddDays(1))
            {
                if (date.Day % 7 != 0)
                {
                    // Normal meetings.
                    for (int additionalAppointmentIndex = 0; additionalAppointmentIndex < 1; additionalAppointmentIndex++)
                    {
                        Event meeting = new Event();
                        int hour = randomTimeCollection[randomTime.Next(0, 7)];
                        meeting.From = new DateTime(date.Year, date.Month, date.Day, hour, 0, 0);
                        meeting.To = meeting.From.AddHours(1);
                        meeting.EventName = this.currentDayMeetings[randomTime.Next(9)];
                        meeting.Color = this.ColorCollection[randomTime.Next(9)];
                        meeting.ForegroundColor = GetAppointmentForeground(meeting.Color);
                        meeting.IsAllDay = false;
                        meeting.Notes = this.notesCollection[randomTime.Next(9)];
                        meeting.StartTimeZone = string.Empty;
                        meeting.EndTimeZone = string.Empty;
                        this.SpecialTimeRegionAppointments.Add(meeting);
                    }
                }
                else
                {
                    // All day meetings.
                    Event meeting = new Event();
                    meeting.From = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(14, 17), 0, 0);
                    meeting.To = meeting.From.AddDays(2).AddHours(1);
                    meeting.EventName = this.currentDayMeetings[randomTime.Next(9)];
                    meeting.Color = this.ColorCollection[randomTime.Next(9)];
                    meeting.ForegroundColor = GetAppointmentForeground(meeting.Color);
                    meeting.IsAllDay = true;
                    meeting.Notes = this.notesCollection[randomTime.Next(9)];
                    meeting.StartTimeZone = string.Empty;
                    meeting.EndTimeZone = string.Empty;
                    this.SpecialTimeRegionAppointments.Add(meeting);
                }
            }

            // Minimum Height Meetings.
            DateTime minDate;
            DateTime minDateFrom = DateTime.Now.AddDays(-2);
            DateTime minDateTo = DateTime.Now.AddDays(2);

            for (minDate = minDateFrom; minDate < minDateTo; minDate = minDate.AddDays(1))
            {
                Event meeting = new Event();
                meeting.From = new DateTime(minDate.Year, minDate.Month, minDate.Day, randomTimeCollection[randomTime.Next(0, 7)], 30, 0);
                meeting.To = meeting.From;
                meeting.EventName = this.minTimeMeetings[randomTime.Next(0, 4)];
                meeting.Color = this.ColorCollection[randomTime.Next(9)];
                meeting.ForegroundColor = GetAppointmentForeground(meeting.Color);
                meeting.Notes = this.noteCollection[randomTime.Next(0, 4)];
                meeting.StartTimeZone = string.Empty;
                meeting.EndTimeZone = string.Empty;

                this.SpecialTimeRegionAppointments.Add(meeting);
            }
        }

        #endregion

        #region Appointment customization
        private void InitializeAppointmentCustomization()
        {
            this.DayViewAppointments = new List<string>()
            {
                "Environmental Discussion", "Health Checkup", "Cancer awareness", "Happiness", "Tourism"
            };

            this.DayViewNotes = new List<string>()
            {
                "A day that creates awareness to promote the healthy planet and reduce the air pollution crisis on nature earth.",
                "A day that raises awareness on different healthy issue. It marks the anniversary of the foundation of WHO.",
                "A day that raises awareness on cancer and its preventive measures. Early detection saves life.",
                "A general idea is to promote happiness and smile around the world.",
                "A day that raises awareness on the role of tourism and its effect on social and economic values."
            };

            this.DayViewColors = new List<Brush>()
            {
                new SolidColorBrush(Color.FromArgb(255, 70, 173, 62)),
                new SolidColorBrush(Color.FromArgb(255, 42, 110, 173)),
                new SolidColorBrush(Color.FromArgb(255, 154, 194, 21)),
                new SolidColorBrush(Color.FromArgb(255, 232, 176, 123)),
                new SolidColorBrush(Color.FromArgb(255, 123, 232, 212))
            };
        }

        #endregion

        #region List view appointments

        private void CreateListViewAppointments()
        {
            var date = DateTime.Now.Date;
            this.ListViewAppointments = new ObservableCollection<Event>();
            ListViewAppointments.Add(new Event() { From = date.AddHours(2), To = date.AddHours(4), 
                Color = this.ColorCollection[0], 
                ForegroundColor = new SolidColorBrush(Colors.White),
                EventName = "Business Meeting", Notes = "Consulting firm laws with business advisers",
                ImageData = "M15.879996,10.113017C13.015996,10.113017,10.620996,11.846014,10.072996,14.141009L21.686996,14.141009C21.138997,11.846014,18.743997,10.113017,15.879996,10.113017z M25.014999,9.3680315C23.987999,9.3680315 22.996999,9.6370325 22.168999,10.125033 22.937999,10.833035 23.553999,11.669037 23.973,12.577039L29.858,12.577039C29.325001,10.737035,27.356,9.3680315,25.014999,9.3680315z M6.9839983,9.3680315C4.6439991,9.3680315,2.6749992,10.737035,2.1419992,12.577039L7.7879982,12.577039C8.2239981,11.632037 8.8709979,10.767035 9.6829977,10.043034 8.8839979,9.6060324 7.947998,9.3680315 6.9839983,9.3680315z M25.015001,2.2980337C23.901001,2.2980333 22.994001,3.2190302 22.994001,4.3500266 22.994001,5.4810228 23.901001,6.4010196 25.015001,6.4010196 26.129001,6.4010196 27.036001,5.4810228 27.036001,4.3500266 27.036001,3.2190302 26.129001,2.2980333 25.015001,2.2980337z M6.9839973,2.2980337C5.8699975,2.2980333 4.9629974,3.2190302 4.9629974,4.3500266 4.9629974,5.4810228 5.8699975,6.4010196 6.9839973,6.4010196 8.0979977,6.4010196 9.0049975,5.4810228 9.0049973,4.3500266 9.0049975,3.2190302 8.0979977,2.2980333 6.9839973,2.2980337z M15.879995,1.9999924C14.522002,1.9999924 13.417998,3.121021 13.417998,4.4979692 13.417998,5.8749781 14.522002,6.996007 15.879995,6.996007 17.237997,6.996007 18.342,5.8749781 18.342,4.4979692 18.342,3.121021 17.237997,1.9999924 15.879995,1.9999924z M15.879995,0C18.339993,-3.8718645E-07 20.341999,2.0179978 20.341999,4.4979692 20.341999,6.1261315 19.479807,7.5544706 18.191797,8.3440638L18.103837,8.3950968 18.234103,8.4295387C18.83861,8.5966454,19.412279,8.8263502,19.945421,9.1100578L20.079164,9.1844196 20.096013,9.168746C20.790442,8.5561762,21.618791,8.0848093,22.520437,7.7782722L22.761075,7.702734 22.610778,7.5949593C21.629981,6.8554015 20.994,5.6758657 20.994,4.3500266 20.994,2.1150339 22.798001,0.2980401 25.015001,0.29803993 27.232001,0.2980401 29.036001,2.1150339 29.036001,4.3500266 29.036001,5.6758657 28.400021,6.8554015 27.419224,7.5949593L27.270109,7.7018862 27.414391,7.7453652C30.087769,8.6170445,32,10.902035,32,13.577041L32,14.577044 23.779284,14.577044 23.798166,14.847279C23.802706,14.944695,23.804997,15.042619,23.804997,15.141007L23.804997,16.141006 7.9549956,16.141006 7.9549956,15.141007C7.9549956,15.042619,7.9572875,14.944695,7.9618263,14.847278L7.9807093,14.577044 0,14.577044 0,13.577041C0,10.902035,1.9122314,8.6170445,4.5851316,7.7453652L4.7290363,7.701992 4.5797744,7.5949593C3.598978,6.8554015 2.9629974,5.6758657 2.9629974,4.3500266 2.9629974,2.1150339 4.7669973,0.2980401 6.9839973,0.29803993 9.2009976,0.2980401 11.004998,2.1150339 11.004998,4.3500266 11.004998,5.6758657 10.369017,6.8554015 9.3882203,7.5949593L9.243361,7.6988349 9.414917,7.7508168C10.290422,8.0384464,11.096006,8.4835453,11.790043,9.0703621L11.827369,9.1035471 12.084475,8.972744C12.539793,8.7515211,13.022134,8.5687943,13.52589,8.4295387L13.656156,8.3950968 13.568195,8.3440638C12.280188,7.5544706 11.417999,6.1261315 11.417999,4.4979692 11.417999,2.0179978 13.419997,-3.8718645E-07 15.879995,0z"
            });
            ListViewAppointments.Add(new Event() { From = date.AddDays(1).AddHours(6), To = date.AddDays(1).AddHours(8), 
                Color = this.ColorCollection[1],
                ForegroundColor = new SolidColorBrush(Colors.Black),
                EventName = "Conference", Notes = "Attend 2nd international conference about WinRT Development" ,
                ImageData= "M19.886933,22.000057L19.922878,22.126386C20.005204,22.445684 20.049003,22.780313 20.049003,23.125001 20.049003,24.503751 19.348222,25.721563 18.284062,26.441036L18.170931,26.513624 18.382488,26.597173C19.458902,27.053149,20.37553,27.814669,21.023056,28.772413L21.048829,28.812582 21.074942,28.772418C21.722468,27.814676,22.639098,27.053169,23.715512,26.597202L23.927103,26.513642 23.813944,26.441036C22.749784,25.721563 22.049003,24.503751 22.049003,23.125001 22.049003,22.780313 22.092802,22.445684 22.175128,22.126386L22.211073,22.000057z M26.049003,21.125001C24.946003,21.125001 24.049003,22.022001 24.049003,23.125001 24.049003,24.228001 24.946003,25.125001 26.049003,25.125001 27.152003,25.125001 28.049003,24.228001 28.049003,23.125001 28.049003,22.022001 27.152003,21.125001 26.049003,21.125001z M16.049003,21.125001C15.704316,21.125001,15.379745,21.212599,15.09638,21.366706L15.028553,21.40795 15.043833,21.699182C15.047268,21.798165,15.049003,21.898438,15.049003,22.000001L14.396575,22.000001 14.390985,22.007472C14.175144,22.32672 14.049003,22.711376 14.049003,23.125001 14.049003,24.228001 14.946003,25.125001 16.049003,25.125001 17.152003,25.125001 18.049003,24.228001 18.049003,23.125001 18.049003,22.022001 17.152003,21.125001 16.049003,21.125001z M9.0490026,10.500001C7.946003,10.500001 7.0490026,11.397 7.0490026,12.500001 7.0490026,13.603001 7.946003,14.500001 9.0490026,14.500001 10.152003,14.500001 11.049003,13.603001 11.049003,12.500001 11.049003,11.397 10.152003,10.500001 9.0490026,10.500001z M2,2L2,20.000001 3.3089714,20.000001 3.3191547,19.960938C3.9043083,17.929688,5.3888025,16.679688,7.2665348,16.210938L7.455574,16.168118 7.316206,16.105021C5.9757862,15.458286 5.0490026,14.085563 5.0490026,12.500001 5.0490026,10.294001 6.8430033,8.5 9.0490026,8.5 11.255003,8.5 13.049003,10.294001 13.049003,12.500001 13.049003,14.085563 12.12222,15.458286 10.7818,16.105021L10.642432,16.168118 10.831471,16.210938C12.509694,16.629884,13.873803,17.672883,14.562483,19.339936L14.586886,19.402841 14.674926,19.368072C15.103593,19.210846 15.566441,19.125001 16.049003,19.125001 16.945191,19.125001 17.773382,19.421081 18.440918,19.920582L18.542004,20.000057 23.556002,20.000057 23.657088,19.920582C24.324624,19.421081 25.152816,19.125001 26.049003,19.125001 26.94519,19.125001 27.773382,19.421081 28.440918,19.920582L28.541933,20.000001 30.000001,20.000001 30.000001,2z M1,0L31.000001,0C31.553,0,32.000001,0.4470005,32.000001,1L32.000001,21.000001C32.000001,21.553001,31.553,22.000001,31.000001,22.000001L29.886916,22.000001 29.922878,22.126386C30.005204,22.445684 30.049003,22.780313 30.049003,23.125001 30.049003,24.503751 29.348222,25.721563 28.284061,26.441036L28.170899,26.513644 28.382485,26.597202C30.535316,27.509136,32.048992,29.64323,32.048992,32.125042L30.048992,32.125042C30.048992,29.918987 28.255016,28.125042 26.048992,28.125042 23.911936,28.125042 22.16152,29.808618 22.054206,31.919474L22.048998,32.124804 20.048992,32.125042 20.043789,31.919438C19.936476,29.808628 18.186066,28.125001 16.049003,28.125001 13.843003,28.125001 12.049003,29.919001 12.049003,32.125001L10.049003,32.125001C10.049003,29.643251,11.562691,27.509126,13.715518,26.597173L13.927075,26.513624 13.813945,26.441036C12.749784,25.721563 12.049003,24.503751 12.049003,23.125001 12.049003,22.228813 12.345083,21.400622 12.844584,20.733086L12.903605,20.658016 12.868902,20.516847C12.361769,18.660157 10.841378,18.000001 9.0490026,18.000001 6.8430033,18.000001 5.0490026,19.000001 5.0490026,22.000001L5.000001,22.000001 3.0490036,22.000001 1,22.000001C0.4470005,22.000001,0,21.553001,0,21.000001L0,1C0,0.4470005,0.4470005,0,1,0z"
            });
            ListViewAppointments.Add(new Event() { From = date.AddDays(-2).AddHours(4), To = date.AddDays(-2).AddHours(6), 
                Color = this.ColorCollection[2],
                ForegroundColor = new SolidColorBrush(Colors.White),
                EventName = "Medical check up", Notes = "Brooklyn medical university. Dental checkup",
                ImageData= "M11.000003,12.100011L13.6,12.100011 13.6,15.199987 16.699999,15.199987 16.699999,17.799995 13.6,17.799995 13.6,20.900001 11.000003,20.900001 11.000003,17.799995 7.9000042,17.799995 7.9000042,15.199987 11.000003,15.199987z M16.000002,5.5000021L6.5000032,12.699986 6.5000032,27.000009 9.6999996,27.000009 11.799998,27.000009 20.1,27.000009 22.6,27.000009 25.500002,27.000009 25.500002,12.699986z M16.000002,0L32,12.199986 29.5,15.500005 27.799995,14.199987 27.799995,29.299999 4.2000001,29.299999 4.2000001,14.199987 2.5000039,15.500005 0,12.199986 5.7999986,7.7999908 9.9000042,4.6000077z"
            });
            ListViewAppointments.Add(new Event() { From = date.AddDays(-2).AddHours(4), To = date.AddDays(-2).AddHours(6),
                Color = this.ColorCollection[3],
                ForegroundColor = new SolidColorBrush(Colors.Black),
                EventName = "Performance Check", Notes = "Search for and enter performance notes.",
                ImageData= "M4.7159762,14.793012C5.2519755,14.793012 5.6859751,15.227006 5.6859751,15.762999 5.6859751,16.297992 5.2519755,16.731986 4.7159762,16.731986 4.1799769,16.731986 3.7459776,16.297992 3.7459774,15.762999 3.7459776,15.227006 4.1799769,14.793012 4.7159762,14.793012z M25.697008,14.441995C26.233007,14.441995 26.667007,14.875996 26.667007,15.410996 26.667007,15.946998 26.233007,16.381 25.697008,16.381 25.161009,16.381 24.727011,15.946998 24.727011,15.410996 24.727011,14.875996 25.161009,14.441995 25.697008,14.441995z M16,12.601998L14.248991,18.308991 16,20.118989 17.751009,18.308991z M6.2530789,9.2403326C6.4093571,9.2444067 6.5669227,9.2864485 6.7118936,9.3701801 7.1757998,9.6381226 7.3347673,10.230993 7.0668216,10.693892 6.7988758,11.157791 6.205996,11.316756 5.7430892,11.048815 5.2791834,10.781873 5.1202154,10.189002 5.3881612,9.7251034 5.5716863,9.4061728 5.9092665,9.2313709 6.2530789,9.2403326z M25.747288,9.2403278C26.090841,9.2313662 26.428637,9.406167 26.61285,9.7250977 26.880796,10.187997 26.721828,10.780868 26.257923,11.04881 25.794016,11.316751 25.201136,11.157785 24.934191,10.693887 24.666245,10.229988 24.825212,9.6371174 25.289118,9.3701754 25.433777,9.2864437 25.591127,9.2444019 25.747288,9.2403278z M16,5.9910069L19.941021,18.834991 16,22.907985 12.058979,18.834991z M21.668095,5.1753445C21.824377,5.1794486 21.981947,5.2214894 22.126923,5.3052201 22.590843,5.5721574 22.749815,6.165019 22.481861,6.6289105 22.213907,7.092802 21.621008,7.2517653 21.158087,6.9838276 20.694166,6.7158904 20.535194,6.1230288 20.803148,5.6591373 20.986679,5.340899 21.32427,5.1663146 21.668095,5.1753445z M10.33225,5.174324C10.675804,5.1653619 11.013599,5.3401608 11.197812,5.6590862 11.465757,6.1229777 11.306789,6.7158394 10.842883,6.9827771 10.378977,7.2507143 9.7860975,7.0917516 9.5191507,6.6288595 9.2512054,6.164968 9.4101734,5.5721068 9.8740797,5.3041692 10.018738,5.220439 10.176088,5.1783977 10.33225,5.174324z M15.999987,3.6869845C16.535978,3.6869843 16.969973,4.1209903 16.969973,4.6569982 16.969973,5.193006 16.535978,5.6270123 15.999987,5.6270123 15.464993,5.6270123 15.030999,5.193006 15.030999,4.6569982 15.030999,4.1209903 15.464993,3.6869843 15.999987,3.6869845z M16,0C24.822998,-4.5496404E-07 32,7.071012 32,15.762996 32,20.110009 30.138,24.310996 26.890015,27.29L25.579041,25.860984C28.469055,23.210015 30.061035,19.62301 30.061035,15.762996 30.061035,8.1400118 23.753052,1.9389943 16,1.9389944 8.2470093,1.9389943 1.9400024,8.1400118 1.9400024,15.762996 1.9400024,19.62301 3.5320435,23.210015 6.4210205,25.860984L5.1110229,27.29C1.8630371,24.310996 0,20.110009 0,15.762996 0,7.071012 7.1780396,-4.5496404E-07 16,0z"
            });
            ListViewAppointments.Add(new Event() { From = date.AddDays(-2).AddHours(4), To = date.AddDays(-2).AddHours(6), 
                Color = this.ColorCollection[4],
                ForegroundColor = new SolidColorBrush(Colors.White),
                EventName = "Consulting", Notes = "Executive summary.", 
                ImageData= "M10.998368,22.949026L11.797754,22.991034 10.998283,22.951023z M17.419995,11.186981L18.581997,12.814983 11.641049,17.772804 11.643018,17.775679C13.132887,20.059933,13.00338,22.916651,12.99638,23.054018L11.797754,22.991034 11.997331,23.001021 10.998368,22.949026 10.998764,22.93969C11.006163,22.735838 11.070255,19.884661 9.4572079,18.225283 8.7317977,17.479824 7.8172688,17.085001 6.5715914,17.012682L6.4952497,17.009716 6.4373255,17.011879C5.2031331,17.082115 4.2702279,17.479384 3.5448179,18.225794 1.8797369,19.938873 2.0017424,22.922011 2.0037432,22.952013L0.005645752,23.055018C-0.0023546219,22.89801 -0.17036343,19.188837 2.1017475,16.841728 3.0922327,15.817119 4.3712211,15.21767 5.9145737,15.049281L5.9778852,15.043806 5.9770384,15.001461C6.1052947,14.999211,6.2319884,14.999504,6.3571115,15.002339L6.4986501,15.008497 6.6455736,15.002193C6.7705059,14.999453,6.8969808,14.99927,7.0249872,15.001644L7.0241361,15.044208 7.0889378,15.049835C8.5369134,15.208225,9.7492015,15.743772,10.711216,16.654263L10.855224,16.796774 10.419984,16.186989z M6.8260174,7.8349854C5.6650224,7.8349854 4.720027,8.7799865 4.720027,9.9419881 4.720027,11.10399 5.6650224,12.048991 6.8260174,12.048991 7.9870124,12.048991 8.9320083,11.10399 8.9320083,9.9419881 8.9320083,8.7799865 7.9870124,7.8349854 6.8260174,7.8349854z M22.001013,6.9999777L28.001013,6.9999777 28.001013,8.9999772 22.001013,8.9999772z M6.8260174,5.834983C9.0910075,5.834983 10.931999,7.6769854 10.931999,9.9419881 10.931999,12.206991 9.0910075,14.048993 6.8260174,14.048993 4.5610275,14.048993 2.7200356,12.206991 2.7200356,9.9419881 2.7200356,7.6769854 4.5610275,5.834983 6.8260174,5.834983z M19.001013,3.9999779L28.001013,3.9999779 28.001013,5.9999777 19.001013,5.9999777z M12.001013,0L32.001013,0 32.001013,14 21.001013,14 21.001013,12 30.001013,12 30.001013,1.9999999 14.001013,1.9999999 14.001013,11 12.001013,11z"
            });
            ListViewAppointments.Add(new Event() { From = date.AddDays(-2).AddHours(4), To = date.AddDays(-2).AddHours(6),
                Color = this.ColorCollection[5],
                ForegroundColor = new SolidColorBrush(Colors.Black),
                EventName = "Project Status Discussion", Notes = "provides an opportunity to share information across the whole team.",
                ImageData= "M5.3719988,22.213019C4.7179995,22.213019 4.1859989,22.777021 4.1859989,23.472025 4.1859989,24.165028 4.7179995,24.730031 5.3719988,24.730031 6.0259991,24.730031 6.5589991,24.165028 6.5589991,23.472025 6.5589991,22.777021 6.0259991,22.213019 5.3719988,22.213019z M22.863002,22.212884C22.208995,22.212884 21.676997,22.776852 21.676998,23.471924 21.676997,24.16492 22.208995,24.729864 22.863002,24.729864 23.517001,24.729864 24.049998,24.16492 24.049998,23.471924 24.049998,22.776852 23.517001,22.212884 22.863002,22.212884z M5.3719988,20.213008C7.1289988,20.213009 8.5589981,21.675016 8.5589981,23.472025 8.5589981,24.426155 8.1554146,25.28602 7.5136223,25.882497L7.4698925,25.921236 7.6994877,26.028022C9.4999886,26.920477 10.744998,28.814534 10.744998,31.000991 10.744998,31.553995 10.296998,32.000999 9.744998,32.000999 9.1929989,32.000999 8.7449989,31.553995 8.7449989,31.000991 8.7449989,29.061975 7.2319994,27.482961 5.3719997,27.482961 3.5130005,27.482961 2,29.061975 2,31.000991 2,31.553995 1.552,32.000999 1,32.000999 0.44799995,32.000999 0,31.553995 0,31.000991 0,28.814534 1.2450104,26.920477 3.0451393,26.028022L3.2745914,25.92128 3.2308292,25.882497C2.5893002,25.28602 2.1859989,24.426155 2.1859989,23.472025 2.1859989,21.675016 3.6149998,20.213009 5.3719988,20.213008z M22.863002,20.212874C24.619998,20.212874 26.049998,21.674918 26.049998,23.471924 26.049998,24.426064 25.646414,25.28591 25.004622,25.882366L24.960452,25.921494 25.189491,26.028022C26.989992,26.920477 28.235002,28.814534 28.235002,31.000991 28.235002,31.553995 27.787002,32.000999 27.235002,32.000999 26.683002,32.000999 26.235003,31.553995 26.235003,31.000991 26.235003,29.061975 24.722003,27.482961 22.862003,27.482961 21.003004,27.482961 19.490004,29.061975 19.490004,31.000991 19.490004,31.553995 19.042004,32.000999 18.490004,32.000999 17.938005,32.000999 17.490005,31.553995 17.490005,31.000991 17.490005,28.814534 18.735014,26.920477 20.535144,26.028022L20.765345,25.920931 20.721828,25.882366C20.0803,25.28591 19.676998,24.426064 19.676998,23.471924 19.676998,21.674918 21.105998,20.212874 22.863002,20.212874z M14.541,11.597999C15.093,11.597999,15.541,12.046,15.541,12.598001L15.541,14.136013 24.004002,14.136013 24.004002,16.854C24.004002,17.405998 23.556002,17.853995 23.004002,17.853996 22.452002,17.853995 22.004002,17.405998 22.004002,16.854L22.004002,16.136003 6.2320042,16.136003 6.2320042,16.854C6.2320042,17.405998 5.7840042,17.853995 5.2320042,17.853996 4.6790047,17.853995 4.2320051,17.405998 4.2320051,16.854L4.2320051,14.136013 13.541,14.136013 13.541,12.598001C13.541,12.046,13.989,11.597999,14.541,11.597999z M14.541003,2.0000095C13.887003,2.0000095 13.354003,2.5640125 13.354003,3.259016 13.354003,3.9530182 13.887003,4.5170221 14.541003,4.5170221 15.195003,4.5170221 15.727003,3.9530182 15.727003,3.259016 15.727003,2.5640125 15.195003,2.0000095 14.541003,2.0000095z M14.541003,0C16.298003,0 17.727003,1.4620075 17.727003,3.259016 17.727003,4.2131453 17.323701,5.0730104 16.682174,5.669487L16.637627,5.7089653 16.867492,5.8158417C18.667993,6.708003 19.913002,8.6015368 19.913002,10.787985 19.913002,11.339988 19.465002,11.78799 18.913003,11.78799 18.361003,11.78799 17.913003,11.339988 17.913003,10.787985 17.913003,8.8489752 16.400003,7.2709675 14.540004,7.2709675 12.681004,7.2709675 11.168004,8.8489752 11.168004,10.787985 11.168004,11.339988 10.720004,11.78799 10.168005,11.78799 9.6160049,11.78799 9.168005,11.339988 9.168005,10.787985 9.168005,8.6015368 10.413014,6.708003 12.213144,5.8158417L12.443605,5.7086649 12.39938,5.669487C11.757588,5.0730104 11.354004,4.2131453 11.354004,3.259016 11.354004,1.4620075 12.784004,0 14.541003,0z"
            });
            ListViewAppointments.Add(new Event() { From = date.AddDays(-2).AddHours(4), To = date.AddDays(-2).AddHours(6), 
                Color = this.ColorCollection[6],
                ForegroundColor = new SolidColorBrush(Colors.White),
                EventName = "Client Meeting", Notes = "Way to understand their needs and how you can help support them.",
                ImageData= "M9.2087464,2.0000226C7.4257641,2.0000224,5.9737787,3.4510215,5.9737787,5.2340206L5.9737787,6.6620196C5.9737787,7.8830188 6.6877713,9.0240182 7.7937608,9.5680178 8.1887565,9.7620171 8.4107547,10.194017 8.3387551,10.629017 8.2657561,11.064016 7.9177594,11.400017 7.4797635,11.457016 3.3388042,11.992016 2.315814,14.115015 2.0718164,15.299014L17.05767,15.299014C16.96367,14.835014 16.749673,14.227014 16.278677,13.627015 15.339686,12.432015 13.719702,11.694016 11.464725,11.434016 11.025729,11.383016 10.672732,11.051017 10.593733,10.617017 10.515734,10.183018 10.731732,9.7490176 11.125728,9.5490178 12.225717,8.9900178 12.90971,7.8840188 12.90971,6.6620196L12.90971,5.2340206C12.90971,3.4510215,11.458724,2.0000224,9.6757421,2.0000226z M22.539979,3.5280435E-05C25.426872,3.5464926E-05,27.774786,2.348034,27.774786,5.234032L27.774786,6.662031C27.774786,7.8460306 27.378801,8.9630297 26.681827,9.862029 29.092738,10.556028 30.370691,11.810028 31.041666,12.847027 32.104628,14.491026 32.060629,16.174024 31.924635,16.602024 31.788639,17.027025 31.395653,17.299024 30.971668,17.299024 30.870672,17.299024 30.769676,17.283024 30.667681,17.251024 30.174699,17.094025 29.887709,16.590025 29.992705,16.093025 30.001705,15.952025 30.044703,14.775026 29.143736,13.627026 28.203771,12.431027 26.58483,11.694028 24.328913,11.434029 23.890929,11.383028 23.536942,11.051028 23.458944,10.617028 23.380947,10.182029 23.59694,9.7480296 23.990925,9.5490292 25.090885,8.9900292 25.774859,7.8830303 25.774859,6.662031L25.774859,5.234032C25.774859,3.4500333 24.323913,2.0000342 22.539979,2.000034 21.987998,2.0000342 21.540015,1.5520345 21.540015,1.0000349 21.540015,0.44703519 21.987998,3.5464926E-05 22.539979,3.5280435E-05z M9.2087464,2.3838132E-05L9.6757421,2.3838132E-05C12.561714,2.3746183E-05,14.909691,2.3480223,14.909691,5.2340206L14.909691,6.6620196C14.909691,7.8470186 14.514695,8.9630183 13.816701,9.8620175 16.227678,10.556017 17.506665,11.810017 18.176658,12.848016 19.239648,14.491014 19.195649,16.175012 19.05965,16.602013 18.926651,17.017013 18.542655,17.299013 18.106659,17.299013L1.0228271,17.299013C0.5878315,17.299013 0.20183563,17.017013 0.069836617,16.602013 -0.064162254,16.180014 -0.10916138,14.514014 0.93082809,12.882015 1.5798216,11.864016 2.8108091,10.630017 5.1227865,9.9190177 4.3947935,9.0050181 3.9737978,7.8580188 3.9737978,6.6620196L3.9737978,5.2340206C3.9737978,2.3480223,6.3217754,2.3746183E-05,9.2087464,2.3838132E-05z M15.607005,0L16.072991,0C18.959914,-1.7591628E-07,21.307792,2.3480207,21.307792,5.2340053L21.307792,6.6619829C21.307792,7.8460029 20.91181,8.9630068 20.214813,9.8619927 22.625738,10.556023 23.903708,11.80999 24.574705,12.846976 25.637655,14.491018 25.593651,16.174 25.457669,16.601978 25.321688,17.027027 24.928697,17.299 24.5047,17.299 24.40369,17.299 24.302681,17.283008 24.200695,17.251026 23.707731,17.093983 23.420754,16.590015 23.525731,16.093006 23.534702,15.952016 23.577731,14.775015 22.676762,13.627005 21.736793,12.431022 20.117832,11.694023 17.86193,11.434013 17.423957,11.382988 17.069966,11.051018 16.991966,10.616998 16.913965,10.182 17.129961,9.747979 17.523929,9.5490044 18.623866,8.9899844 19.307863,7.8829902 19.307863,6.6619829L19.307863,5.2340053C19.307863,3.4500097,17.856925,1.9999986,16.072991,1.9999983L15.607005,1.9999983C15.054046,1.9999986 14.60704,1.5520008 14.60704,0.99999916 14.60704,0.447021 15.054046,-1.7591628E-07 15.607005,0z"
            });
            ListViewAppointments.Add(new Event() { From = date.AddDays(-2).AddHours(4), To = date.AddDays(-2).AddHours(6),
                Color = this.ColorCollection[7],
                ForegroundColor = new SolidColorBrush(Colors.Black),
                EventName = "General Meeting", Notes = "Meeting of all the shareholders of a company.",
                ImageData= "M16.485048,11.615066C13.010075,11.615066,10.182073,14.44307,10.182073,17.918048L10.182073,20.706074 22.788024,20.706074 22.788024,17.918048C22.788024,14.44307,19.960083,11.615066,16.485048,11.615066z M16.485048,9.676039C21.030029,9.6760393,24.727049,13.374039,24.727049,17.918048L24.727049,22.64504 8.2430484,22.64504 8.2430484,17.918048C8.2430484,13.374039,11.941045,9.6760393,16.485048,9.676039z M26.168022,8.4040185C29.660028,8.4040183,32.001034,10.742021,32.001034,14.222025L32.001034,20.040032 25.631395,20.040032 25.631395,18.101029 30.062029,18.101029 30.062029,14.222025C30.062029,11.829022 28.572027,10.343021 26.175022,10.343021 24.996019,10.343021 23.857018,10.818021 23.042016,11.646022L21.659014,10.28602C22.837015,9.0890191,24.480019,8.4040183,26.168022,8.4040185z M6.3570112,8.404018C8.1380143,8.4040183,9.9490175,9.1250192,11.09202,10.286021L9.7100171,11.646022C8.9300157,10.854021 7.6180133,10.343021 6.3660108,10.343021 4.1620069,10.343021 1.9400029,11.675022 1.9400029,14.222025L1.9400029,18.101029 7.3396385,18.101029 7.3396385,20.040032 0,20.040032 0,14.222025C0,10.905021,2.7330046,8.4040183,6.3570112,8.404018z M26.181997,2.8080306C25.209997,2.8080306 24.420998,3.5980282 24.420998,4.5690246 24.420998,5.5400214 25.209997,6.330019 26.181997,6.330019 27.152998,6.330019 27.941998,5.5400214 27.941998,4.5690246 27.941998,3.5980282 27.152998,2.8080306 26.181997,2.8080306z M6.3500191,2.8080306C5.379019,2.8080306 4.590019,3.5980282 4.5900192,4.5690246 4.590019,5.5400214 5.379019,6.330019 6.3500191,6.330019 7.3220187,6.330019 8.1110186,5.5400214 8.1110184,4.5690246 8.1110186,3.5980282 7.3220187,2.8080306 6.3500191,2.8080306z M16.445042,1.9389987C14.997042,1.9389987 13.819043,3.1169982 13.819043,4.5649972 13.819043,6.0129964 14.997042,7.1909959 16.445042,7.1909957 17.893041,7.1909959 19.07104,6.0129964 19.07104,4.5649972 19.07104,3.1169982 17.893041,1.9389987 16.445042,1.9389987z M26.181997,0.86903667C28.221998,0.86903667 29.881998,2.5290313 29.881998,4.5690246 29.881998,6.6090181 28.221998,8.2690126 26.181997,8.2690126 24.140998,8.2690126 22.480998,6.6090181 22.480998,4.5690246 22.480998,2.5290313 24.140998,0.86903667 26.181997,0.86903667z M6.3500191,0.86903667C8.3910186,0.86903667 10.051018,2.5290313 10.051018,4.5690246 10.051018,6.6090181 8.3910186,8.2690126 6.3500191,8.2690126 4.310019,8.2690126 2.6500192,6.6090181 2.6500192,4.5690246 2.6500192,2.5290313 4.310019,0.86903667 6.3500191,0.86903667z M16.445042,0C18.96204,0 21.010039,2.0479984 21.010039,4.5649972 21.010039,7.081996 18.96204,9.1299948 16.445042,9.1299946 13.928043,9.1299948 11.880044,7.081996 11.880044,4.5649972 11.880044,2.0479984 13.928043,0 16.445042,0z"
            });
            ListViewAppointments.Add(new Event() {  From = date.AddDays(-2).AddHours(4), To = date.AddDays(-2).AddHours(6), 
                Color = this.ColorCollection[8],
                ForegroundColor = new SolidColorBrush(Colors.White),
                EventName = "Yoga Therapy",
                Notes = "Encourages the integration of mind, body, and spirit.",
                ImageData = "M16.073033,13.912994L16.073033,23.354004 18.95505,22.559021C19.054049,22.559021,19.15305,22.459961,19.253056,22.459961L17.961047,21.664978C17.265034,21.167969,17.066035,20.372986,17.265034,19.677002L17.265034,13.912994z M7.8239708,13.912994L7.8239708,20.27298 7.5259642,20.27298C7.5259642,20.77002,7.2279653,21.266968,6.7309603,21.664978L5.438951,22.459961 5.8369565,22.459961C6.1349549,22.459961,6.3339538,22.459961,6.6319604,22.559021L8.4199757,23.055969 8.4199757,13.912994z M9.413979,8.7449951L15.377028,8.7449951C17.861041,8.7449951,19.948054,10.634003,19.948054,13.21698L19.948054,13.912994 19.948054,18.583984C19.948054,18.583984,20.04806,18.583984,20.04806,18.682983L24.023095,21.365967C24.818099,21.862976 25.01709,22.95697 24.520092,23.851013 24.023095,24.546997 23.129076,24.844971 22.433072,24.546997 22.731078,25.539978 22.433072,26.533997 21.737069,27.22998 22.433072,27.924988 22.731078,28.919006 22.433072,29.912964 22.135081,31.106018 21.042071,32 19.750054,32 19.452048,32 19.253056,32 18.95505,31.901001L12.793002,30.210999 6.6319604,31.901001C6.4329614,31.800964 6.1349549,31.800964 5.935956,31.800964 4.6439466,31.800964 3.5509364,31.005981 3.2529375,29.713989 2.9549312,28.719971 3.2529375,27.72699 3.9479425,27.031006 3.2529375,26.334961 2.9549312,25.34198 3.2529375,24.347961 3.3519375,24.049988 3.4519367,23.851013 3.5509364,23.552979L2.7559321,24.148987C1.9609283,24.645996 0.86791787,24.447021 0.27091334,23.651978 -0.22609199,22.95697 -0.027093017,21.862976 0.7679188,21.266968L4.6439466,18.682983 4.6439466,13.912994 4.6439466,13.316986C4.6439466,10.733002,6.8299598,8.7449951,9.413979,8.7449951z M12.495002,0C14.681015,0 16.47003,1.7890015 16.47003,3.9750061 16.47003,6.1609802 14.681015,7.9499817 12.495002,7.9499817 10.30899,7.9499817 8.5199752,6.1609802 8.5199752,3.9750061 8.5199752,1.7890015 10.30899,0 12.495002,0z"
            });
            ListViewAppointments.Add(new Event() { From = date.AddDays(-2).AddHours(4), To = date.AddDays(-2).AddHours(6), 
                Color = this.ColorCollection[0],
                ForegroundColor = new SolidColorBrush(Colors.White),
                EventName = "GoToMeeting", Notes = "User to meet with other users, customers, clients or colleagues.",
                ImageData= "M13.720991,20.66501L13.556989,21.246004 14.145002,21.089998C14.145002,21.089998,13.777998,21.063005,13.720991,20.66501z M16.852006,17.065004L14.138014,19.778002C14.138014,19.778002 14.311995,19.998003 14.159986,20.240999 14.159986,20.240999 14.638991,20.203005 14.57701,20.688005 14.57701,20.688005 14.728987,20.505999 15.017012,20.688005L17.762011,17.94301C17.762011,17.94301,17.041001,17.906008,16.852006,17.065004z M17.680009,16.278002C17.646012,16.278002,17.612015,16.282,17.578995,16.291002L17.017991,16.852007C17.017991,16.852007,17.09401,17.655001,17.97301,17.77701L18.504992,17.246004C18.504992,17.246004 18.640002,17.110002 18.353015,16.701006 18.353015,16.701006 18.009997,16.283998 17.680009,16.278002z M15.975998,14.490999C18.384997,14.490999 20.337025,16.44301 20.337025,18.852007 20.337025,21.260012 18.384997,23.213001 15.975998,23.213001 13.568006,23.213001 11.616008,21.260012 11.616008,18.852007 11.616008,16.44301 13.568006,14.490999 15.975998,14.490999z M24.960992,13.746004L27.720029,13.746004C29.986998,13.746004 31.59503,15.548998 31.817017,17.800005 31.856019,18.171999 31.921998,18.617006 31.999999,19.104998L24.783013,19.104998C24.637994,18.097002 24.483025,17.296999 24.405022,16.643999 24.332024,15.645006 24.041985,14.722002 23.653006,13.904009 24.054986,13.795 24.491997,13.746004 24.960992,13.746004z M4.2619974,13.746004L7.0199959,13.746004C7.3909981,13.746004 7.7399976,13.795 8.0669934,13.824999 7.6579968,14.667009 7.3989937,15.623003 7.290992,16.660006 7.2569954,17.319002 7.1209785,18.104998 6.9589912,19.104998L0,19.104998C0.069000308,18.619005 0.12799084,18.175005 0.16299438,17.800005 0.36599765,15.546999 1.9939899,13.746004 4.2619974,13.746004z M14.121992,11.626009L17.617997,11.626009C20.470021,11.626009 22.50701,13.92 22.801993,16.752001 22.869986,17.404009 22.997,18.211 23.142997,19.104998L21.244008,19.104998 21.249989,18.852007C21.249989,15.944002 18.884021,13.578005 15.975998,13.578005 13.069012,13.578005 10.702983,15.944002 10.702983,18.852007L10.708995,19.104998 8.6290061,19.104998C8.7609946,18.214998 8.8759849,17.410006 8.9379966,16.752001 9.2020051,13.918001 11.255993,11.626009 14.121992,11.626009z M26.340022,4.4870004C28.744992,4.4870004 30.723021,6.5090036 30.723021,8.8690042 30.723021,11.31801 28.744992,13.253008 26.340022,13.253008 23.936028,13.253008 21.957999,11.31801 21.957999,8.8690042 21.957999,6.5090036 23.936028,4.4870004 26.340022,4.4870004z M5.6399896,4.4870004C8.0449903,4.4870004 10.022989,6.5090036 10.022989,8.8690042 10.022989,11.31801 8.0449903,13.253008 5.6399896,13.253008 3.2359955,13.253008 1.2579968,11.31801 1.257997,8.8690042 1.2579968,6.5090036 3.2359955,4.4870004 5.6399896,4.4870004z M15.87001,0C18.908984,1.2219764E-07 21.423024,2.4400029 21.423024,5.5180063 21.423024,8.5989999 18.908984,11.031008 15.87001,11.031008 12.790997,11.031008 10.314982,8.5989999 10.314982,5.5180063 10.314982,2.4400029 12.790997,1.2219764E-07 15.87001,0z"
            });
        }

        private void CreateDragDropAppointments()
        {
            var date = DateTime.Now.Date;
            this.DragAndDropAppointments = new ObservableCollection<Event>();
            DragAndDropAppointments.Add(new Event() { From = date.AddHours(10), To = date.AddHours(11),
                Color = this.ColorCollection[0],
                ForegroundColor = new SolidColorBrush(Colors.White),
                EventName = "Business Meeting", Notes = "Consulting firm laws with business advisers",
                ImageData= "M15.879996,10.113017C13.015996,10.113017,10.620996,11.846014,10.072996,14.141009L21.686996,14.141009C21.138997,11.846014,18.743997,10.113017,15.879996,10.113017z M25.014999,9.3680315C23.987999,9.3680315 22.996999,9.6370325 22.168999,10.125033 22.937999,10.833035 23.553999,11.669037 23.973,12.577039L29.858,12.577039C29.325001,10.737035,27.356,9.3680315,25.014999,9.3680315z M6.9839983,9.3680315C4.6439991,9.3680315,2.6749992,10.737035,2.1419992,12.577039L7.7879982,12.577039C8.2239981,11.632037 8.8709979,10.767035 9.6829977,10.043034 8.8839979,9.6060324 7.947998,9.3680315 6.9839983,9.3680315z M25.015001,2.2980337C23.901001,2.2980333 22.994001,3.2190302 22.994001,4.3500266 22.994001,5.4810228 23.901001,6.4010196 25.015001,6.4010196 26.129001,6.4010196 27.036001,5.4810228 27.036001,4.3500266 27.036001,3.2190302 26.129001,2.2980333 25.015001,2.2980337z M6.9839973,2.2980337C5.8699975,2.2980333 4.9629974,3.2190302 4.9629974,4.3500266 4.9629974,5.4810228 5.8699975,6.4010196 6.9839973,6.4010196 8.0979977,6.4010196 9.0049975,5.4810228 9.0049973,4.3500266 9.0049975,3.2190302 8.0979977,2.2980333 6.9839973,2.2980337z M15.879995,1.9999924C14.522002,1.9999924 13.417998,3.121021 13.417998,4.4979692 13.417998,5.8749781 14.522002,6.996007 15.879995,6.996007 17.237997,6.996007 18.342,5.8749781 18.342,4.4979692 18.342,3.121021 17.237997,1.9999924 15.879995,1.9999924z M15.879995,0C18.339993,-3.8718645E-07 20.341999,2.0179978 20.341999,4.4979692 20.341999,6.1261315 19.479807,7.5544706 18.191797,8.3440638L18.103837,8.3950968 18.234103,8.4295387C18.83861,8.5966454,19.412279,8.8263502,19.945421,9.1100578L20.079164,9.1844196 20.096013,9.168746C20.790442,8.5561762,21.618791,8.0848093,22.520437,7.7782722L22.761075,7.702734 22.610778,7.5949593C21.629981,6.8554015 20.994,5.6758657 20.994,4.3500266 20.994,2.1150339 22.798001,0.2980401 25.015001,0.29803993 27.232001,0.2980401 29.036001,2.1150339 29.036001,4.3500266 29.036001,5.6758657 28.400021,6.8554015 27.419224,7.5949593L27.270109,7.7018862 27.414391,7.7453652C30.087769,8.6170445,32,10.902035,32,13.577041L32,14.577044 23.779284,14.577044 23.798166,14.847279C23.802706,14.944695,23.804997,15.042619,23.804997,15.141007L23.804997,16.141006 7.9549956,16.141006 7.9549956,15.141007C7.9549956,15.042619,7.9572875,14.944695,7.9618263,14.847278L7.9807093,14.577044 0,14.577044 0,13.577041C0,10.902035,1.9122314,8.6170445,4.5851316,7.7453652L4.7290363,7.701992 4.5797744,7.5949593C3.598978,6.8554015 2.9629974,5.6758657 2.9629974,4.3500266 2.9629974,2.1150339 4.7669973,0.2980401 6.9839973,0.29803993 9.2009976,0.2980401 11.004998,2.1150339 11.004998,4.3500266 11.004998,5.6758657 10.369017,6.8554015 9.3882203,7.5949593L9.243361,7.6988349 9.414917,7.7508168C10.290422,8.0384464,11.096006,8.4835453,11.790043,9.0703621L11.827369,9.1035471 12.084475,8.972744C12.539793,8.7515211,13.022134,8.5687943,13.52589,8.4295387L13.656156,8.3950968 13.568195,8.3440638C12.280188,7.5544706 11.417999,6.1261315 11.417999,4.4979692 11.417999,2.0179978 13.419997,-3.8718645E-07 15.879995,0z"
            });
            DragAndDropAppointments.Add(new Event() { From = date.AddDays(1).AddHours(11), To = date.AddDays(1).AddHours(12), 
                Color = this.ColorCollection[1],
                ForegroundColor = new SolidColorBrush(Colors.Black),
                EventName = "Conference", Notes = "Attend 2nd international conference about WinRT Development",
                ImageData= "M19.886933,22.000057L19.922878,22.126386C20.005204,22.445684 20.049003,22.780313 20.049003,23.125001 20.049003,24.503751 19.348222,25.721563 18.284062,26.441036L18.170931,26.513624 18.382488,26.597173C19.458902,27.053149,20.37553,27.814669,21.023056,28.772413L21.048829,28.812582 21.074942,28.772418C21.722468,27.814676,22.639098,27.053169,23.715512,26.597202L23.927103,26.513642 23.813944,26.441036C22.749784,25.721563 22.049003,24.503751 22.049003,23.125001 22.049003,22.780313 22.092802,22.445684 22.175128,22.126386L22.211073,22.000057z M26.049003,21.125001C24.946003,21.125001 24.049003,22.022001 24.049003,23.125001 24.049003,24.228001 24.946003,25.125001 26.049003,25.125001 27.152003,25.125001 28.049003,24.228001 28.049003,23.125001 28.049003,22.022001 27.152003,21.125001 26.049003,21.125001z M16.049003,21.125001C15.704316,21.125001,15.379745,21.212599,15.09638,21.366706L15.028553,21.40795 15.043833,21.699182C15.047268,21.798165,15.049003,21.898438,15.049003,22.000001L14.396575,22.000001 14.390985,22.007472C14.175144,22.32672 14.049003,22.711376 14.049003,23.125001 14.049003,24.228001 14.946003,25.125001 16.049003,25.125001 17.152003,25.125001 18.049003,24.228001 18.049003,23.125001 18.049003,22.022001 17.152003,21.125001 16.049003,21.125001z M9.0490026,10.500001C7.946003,10.500001 7.0490026,11.397 7.0490026,12.500001 7.0490026,13.603001 7.946003,14.500001 9.0490026,14.500001 10.152003,14.500001 11.049003,13.603001 11.049003,12.500001 11.049003,11.397 10.152003,10.500001 9.0490026,10.500001z M2,2L2,20.000001 3.3089714,20.000001 3.3191547,19.960938C3.9043083,17.929688,5.3888025,16.679688,7.2665348,16.210938L7.455574,16.168118 7.316206,16.105021C5.9757862,15.458286 5.0490026,14.085563 5.0490026,12.500001 5.0490026,10.294001 6.8430033,8.5 9.0490026,8.5 11.255003,8.5 13.049003,10.294001 13.049003,12.500001 13.049003,14.085563 12.12222,15.458286 10.7818,16.105021L10.642432,16.168118 10.831471,16.210938C12.509694,16.629884,13.873803,17.672883,14.562483,19.339936L14.586886,19.402841 14.674926,19.368072C15.103593,19.210846 15.566441,19.125001 16.049003,19.125001 16.945191,19.125001 17.773382,19.421081 18.440918,19.920582L18.542004,20.000057 23.556002,20.000057 23.657088,19.920582C24.324624,19.421081 25.152816,19.125001 26.049003,19.125001 26.94519,19.125001 27.773382,19.421081 28.440918,19.920582L28.541933,20.000001 30.000001,20.000001 30.000001,2z M1,0L31.000001,0C31.553,0,32.000001,0.4470005,32.000001,1L32.000001,21.000001C32.000001,21.553001,31.553,22.000001,31.000001,22.000001L29.886916,22.000001 29.922878,22.126386C30.005204,22.445684 30.049003,22.780313 30.049003,23.125001 30.049003,24.503751 29.348222,25.721563 28.284061,26.441036L28.170899,26.513644 28.382485,26.597202C30.535316,27.509136,32.048992,29.64323,32.048992,32.125042L30.048992,32.125042C30.048992,29.918987 28.255016,28.125042 26.048992,28.125042 23.911936,28.125042 22.16152,29.808618 22.054206,31.919474L22.048998,32.124804 20.048992,32.125042 20.043789,31.919438C19.936476,29.808628 18.186066,28.125001 16.049003,28.125001 13.843003,28.125001 12.049003,29.919001 12.049003,32.125001L10.049003,32.125001C10.049003,29.643251,11.562691,27.509126,13.715518,26.597173L13.927075,26.513624 13.813945,26.441036C12.749784,25.721563 12.049003,24.503751 12.049003,23.125001 12.049003,22.228813 12.345083,21.400622 12.844584,20.733086L12.903605,20.658016 12.868902,20.516847C12.361769,18.660157 10.841378,18.000001 9.0490026,18.000001 6.8430033,18.000001 5.0490026,19.000001 5.0490026,22.000001L5.000001,22.000001 3.0490036,22.000001 1,22.000001C0.4470005,22.000001,0,21.553001,0,21.000001L0,1C0,0.4470005,0.4470005,0,1,0z"
            });
            DragAndDropAppointments.Add(new Event() { From = date.AddDays(-2).AddHours(12), To = date.AddDays(-2).AddHours(13),
                Color = this.ColorCollection[2],
                ForegroundColor = new SolidColorBrush(Colors.White),
                EventName = "Medical check up", Notes = "Brooklyn medical university. Dental checkup",
                ImageData= "M11.000003,12.100011L13.6,12.100011 13.6,15.199987 16.699999,15.199987 16.699999,17.799995 13.6,17.799995 13.6,20.900001 11.000003,20.900001 11.000003,17.799995 7.9000042,17.799995 7.9000042,15.199987 11.000003,15.199987z M16.000002,5.5000021L6.5000032,12.699986 6.5000032,27.000009 9.6999996,27.000009 11.799998,27.000009 20.1,27.000009 22.6,27.000009 25.500002,27.000009 25.500002,12.699986z M16.000002,0L32,12.199986 29.5,15.500005 27.799995,14.199987 27.799995,29.299999 4.2000001,29.299999 4.2000001,14.199987 2.5000039,15.500005 0,12.199986 5.7999986,7.7999908 9.9000042,4.6000077z"
            });
            DragAndDropAppointments.Add(new Event() { From = date.AddDays(3).AddHours(13), To = date.AddDays(3).AddHours(14),
                Color = this.ColorCollection[3],
                ForegroundColor = new SolidColorBrush(Colors.White),
                EventName = "Performance Check", Notes = "Search for and enter performance notes.",
                ImageData= "M4.7159762,14.793012C5.2519755,14.793012 5.6859751,15.227006 5.6859751,15.762999 5.6859751,16.297992 5.2519755,16.731986 4.7159762,16.731986 4.1799769,16.731986 3.7459776,16.297992 3.7459774,15.762999 3.7459776,15.227006 4.1799769,14.793012 4.7159762,14.793012z M25.697008,14.441995C26.233007,14.441995 26.667007,14.875996 26.667007,15.410996 26.667007,15.946998 26.233007,16.381 25.697008,16.381 25.161009,16.381 24.727011,15.946998 24.727011,15.410996 24.727011,14.875996 25.161009,14.441995 25.697008,14.441995z M16,12.601998L14.248991,18.308991 16,20.118989 17.751009,18.308991z M6.2530789,9.2403326C6.4093571,9.2444067 6.5669227,9.2864485 6.7118936,9.3701801 7.1757998,9.6381226 7.3347673,10.230993 7.0668216,10.693892 6.7988758,11.157791 6.205996,11.316756 5.7430892,11.048815 5.2791834,10.781873 5.1202154,10.189002 5.3881612,9.7251034 5.5716863,9.4061728 5.9092665,9.2313709 6.2530789,9.2403326z M25.747288,9.2403278C26.090841,9.2313662 26.428637,9.406167 26.61285,9.7250977 26.880796,10.187997 26.721828,10.780868 26.257923,11.04881 25.794016,11.316751 25.201136,11.157785 24.934191,10.693887 24.666245,10.229988 24.825212,9.6371174 25.289118,9.3701754 25.433777,9.2864437 25.591127,9.2444019 25.747288,9.2403278z M16,5.9910069L19.941021,18.834991 16,22.907985 12.058979,18.834991z M21.668095,5.1753445C21.824377,5.1794486 21.981947,5.2214894 22.126923,5.3052201 22.590843,5.5721574 22.749815,6.165019 22.481861,6.6289105 22.213907,7.092802 21.621008,7.2517653 21.158087,6.9838276 20.694166,6.7158904 20.535194,6.1230288 20.803148,5.6591373 20.986679,5.340899 21.32427,5.1663146 21.668095,5.1753445z M10.33225,5.174324C10.675804,5.1653619 11.013599,5.3401608 11.197812,5.6590862 11.465757,6.1229777 11.306789,6.7158394 10.842883,6.9827771 10.378977,7.2507143 9.7860975,7.0917516 9.5191507,6.6288595 9.2512054,6.164968 9.4101734,5.5721068 9.8740797,5.3041692 10.018738,5.220439 10.176088,5.1783977 10.33225,5.174324z M15.999987,3.6869845C16.535978,3.6869843 16.969973,4.1209903 16.969973,4.6569982 16.969973,5.193006 16.535978,5.6270123 15.999987,5.6270123 15.464993,5.6270123 15.030999,5.193006 15.030999,4.6569982 15.030999,4.1209903 15.464993,3.6869843 15.999987,3.6869845z M16,0C24.822998,-4.5496404E-07 32,7.071012 32,15.762996 32,20.110009 30.138,24.310996 26.890015,27.29L25.579041,25.860984C28.469055,23.210015 30.061035,19.62301 30.061035,15.762996 30.061035,8.1400118 23.753052,1.9389943 16,1.9389944 8.2470093,1.9389943 1.9400024,8.1400118 1.9400024,15.762996 1.9400024,19.62301 3.5320435,23.210015 6.4210205,25.860984L5.1110229,27.29C1.8630371,24.310996 0,20.110009 0,15.762996 0,7.071012 7.1780396,-4.5496404E-07 16,0z"
            });
            DragAndDropAppointments.Add(new Event() { From = date.AddDays(-3).AddHours(14), To = date.AddDays(-3).AddHours(15),
                Color = this.ColorCollection[4],
                ForegroundColor = new SolidColorBrush(Colors.White),
                EventName = "Consulting", Notes = "Executive summary.",
                ImageData = "M10.998368,22.949026L11.797754,22.991034 10.998283,22.951023z M17.419995,11.186981L18.581997,12.814983 11.641049,17.772804 11.643018,17.775679C13.132887,20.059933,13.00338,22.916651,12.99638,23.054018L11.797754,22.991034 11.997331,23.001021 10.998368,22.949026 10.998764,22.93969C11.006163,22.735838 11.070255,19.884661 9.4572079,18.225283 8.7317977,17.479824 7.8172688,17.085001 6.5715914,17.012682L6.4952497,17.009716 6.4373255,17.011879C5.2031331,17.082115 4.2702279,17.479384 3.5448179,18.225794 1.8797369,19.938873 2.0017424,22.922011 2.0037432,22.952013L0.005645752,23.055018C-0.0023546219,22.89801 -0.17036343,19.188837 2.1017475,16.841728 3.0922327,15.817119 4.3712211,15.21767 5.9145737,15.049281L5.9778852,15.043806 5.9770384,15.001461C6.1052947,14.999211,6.2319884,14.999504,6.3571115,15.002339L6.4986501,15.008497 6.6455736,15.002193C6.7705059,14.999453,6.8969808,14.99927,7.0249872,15.001644L7.0241361,15.044208 7.0889378,15.049835C8.5369134,15.208225,9.7492015,15.743772,10.711216,16.654263L10.855224,16.796774 10.419984,16.186989z M6.8260174,7.8349854C5.6650224,7.8349854 4.720027,8.7799865 4.720027,9.9419881 4.720027,11.10399 5.6650224,12.048991 6.8260174,12.048991 7.9870124,12.048991 8.9320083,11.10399 8.9320083,9.9419881 8.9320083,8.7799865 7.9870124,7.8349854 6.8260174,7.8349854z M22.001013,6.9999777L28.001013,6.9999777 28.001013,8.9999772 22.001013,8.9999772z M6.8260174,5.834983C9.0910075,5.834983 10.931999,7.6769854 10.931999,9.9419881 10.931999,12.206991 9.0910075,14.048993 6.8260174,14.048993 4.5610275,14.048993 2.7200356,12.206991 2.7200356,9.9419881 2.7200356,7.6769854 4.5610275,5.834983 6.8260174,5.834983z M19.001013,3.9999779L28.001013,3.9999779 28.001013,5.9999777 19.001013,5.9999777z M12.001013,0L32.001013,0 32.001013,14 21.001013,14 21.001013,12 30.001013,12 30.001013,1.9999999 14.001013,1.9999999 14.001013,11 12.001013,11z"
            });
            DragAndDropAppointments.Add(new Event() { From = date.AddDays(4).AddHours(15), To = date.AddDays(4).AddHours(16),
                Color = this.ColorCollection[5],
                ForegroundColor = new SolidColorBrush(Colors.Black),
                EventName = "Project Status Discussion", Notes = "provides an opportunity to share information across the whole team.",
                ImageData = "M5.3719988,22.213019C4.7179995,22.213019 4.1859989,22.777021 4.1859989,23.472025 4.1859989,24.165028 4.7179995,24.730031 5.3719988,24.730031 6.0259991,24.730031 6.5589991,24.165028 6.5589991,23.472025 6.5589991,22.777021 6.0259991,22.213019 5.3719988,22.213019z M22.863002,22.212884C22.208995,22.212884 21.676997,22.776852 21.676998,23.471924 21.676997,24.16492 22.208995,24.729864 22.863002,24.729864 23.517001,24.729864 24.049998,24.16492 24.049998,23.471924 24.049998,22.776852 23.517001,22.212884 22.863002,22.212884z M5.3719988,20.213008C7.1289988,20.213009 8.5589981,21.675016 8.5589981,23.472025 8.5589981,24.426155 8.1554146,25.28602 7.5136223,25.882497L7.4698925,25.921236 7.6994877,26.028022C9.4999886,26.920477 10.744998,28.814534 10.744998,31.000991 10.744998,31.553995 10.296998,32.000999 9.744998,32.000999 9.1929989,32.000999 8.7449989,31.553995 8.7449989,31.000991 8.7449989,29.061975 7.2319994,27.482961 5.3719997,27.482961 3.5130005,27.482961 2,29.061975 2,31.000991 2,31.553995 1.552,32.000999 1,32.000999 0.44799995,32.000999 0,31.553995 0,31.000991 0,28.814534 1.2450104,26.920477 3.0451393,26.028022L3.2745914,25.92128 3.2308292,25.882497C2.5893002,25.28602 2.1859989,24.426155 2.1859989,23.472025 2.1859989,21.675016 3.6149998,20.213009 5.3719988,20.213008z M22.863002,20.212874C24.619998,20.212874 26.049998,21.674918 26.049998,23.471924 26.049998,24.426064 25.646414,25.28591 25.004622,25.882366L24.960452,25.921494 25.189491,26.028022C26.989992,26.920477 28.235002,28.814534 28.235002,31.000991 28.235002,31.553995 27.787002,32.000999 27.235002,32.000999 26.683002,32.000999 26.235003,31.553995 26.235003,31.000991 26.235003,29.061975 24.722003,27.482961 22.862003,27.482961 21.003004,27.482961 19.490004,29.061975 19.490004,31.000991 19.490004,31.553995 19.042004,32.000999 18.490004,32.000999 17.938005,32.000999 17.490005,31.553995 17.490005,31.000991 17.490005,28.814534 18.735014,26.920477 20.535144,26.028022L20.765345,25.920931 20.721828,25.882366C20.0803,25.28591 19.676998,24.426064 19.676998,23.471924 19.676998,21.674918 21.105998,20.212874 22.863002,20.212874z M14.541,11.597999C15.093,11.597999,15.541,12.046,15.541,12.598001L15.541,14.136013 24.004002,14.136013 24.004002,16.854C24.004002,17.405998 23.556002,17.853995 23.004002,17.853996 22.452002,17.853995 22.004002,17.405998 22.004002,16.854L22.004002,16.136003 6.2320042,16.136003 6.2320042,16.854C6.2320042,17.405998 5.7840042,17.853995 5.2320042,17.853996 4.6790047,17.853995 4.2320051,17.405998 4.2320051,16.854L4.2320051,14.136013 13.541,14.136013 13.541,12.598001C13.541,12.046,13.989,11.597999,14.541,11.597999z M14.541003,2.0000095C13.887003,2.0000095 13.354003,2.5640125 13.354003,3.259016 13.354003,3.9530182 13.887003,4.5170221 14.541003,4.5170221 15.195003,4.5170221 15.727003,3.9530182 15.727003,3.259016 15.727003,2.5640125 15.195003,2.0000095 14.541003,2.0000095z M14.541003,0C16.298003,0 17.727003,1.4620075 17.727003,3.259016 17.727003,4.2131453 17.323701,5.0730104 16.682174,5.669487L16.637627,5.7089653 16.867492,5.8158417C18.667993,6.708003 19.913002,8.6015368 19.913002,10.787985 19.913002,11.339988 19.465002,11.78799 18.913003,11.78799 18.361003,11.78799 17.913003,11.339988 17.913003,10.787985 17.913003,8.8489752 16.400003,7.2709675 14.540004,7.2709675 12.681004,7.2709675 11.168004,8.8489752 11.168004,10.787985 11.168004,11.339988 10.720004,11.78799 10.168005,11.78799 9.6160049,11.78799 9.168005,11.339988 9.168005,10.787985 9.168005,8.6015368 10.413014,6.708003 12.213144,5.8158417L12.443605,5.7086649 12.39938,5.669487C11.757588,5.0730104 11.354004,4.2131453 11.354004,3.259016 11.354004,1.4620075 12.784004,0 14.541003,0z"
            });
            DragAndDropAppointments.Add(new Event() { From = date.AddDays(2).AddHours(14), To = date.AddDays(2).AddHours(15),
                Color = this.ColorCollection[6],
                ForegroundColor = new SolidColorBrush(Colors.White),
                EventName = "Client Meeting", Notes = "Way to understand their needs and how you can help support them.",
                ImageData = "M9.2087464,2.0000226C7.4257641,2.0000224,5.9737787,3.4510215,5.9737787,5.2340206L5.9737787,6.6620196C5.9737787,7.8830188 6.6877713,9.0240182 7.7937608,9.5680178 8.1887565,9.7620171 8.4107547,10.194017 8.3387551,10.629017 8.2657561,11.064016 7.9177594,11.400017 7.4797635,11.457016 3.3388042,11.992016 2.315814,14.115015 2.0718164,15.299014L17.05767,15.299014C16.96367,14.835014 16.749673,14.227014 16.278677,13.627015 15.339686,12.432015 13.719702,11.694016 11.464725,11.434016 11.025729,11.383016 10.672732,11.051017 10.593733,10.617017 10.515734,10.183018 10.731732,9.7490176 11.125728,9.5490178 12.225717,8.9900178 12.90971,7.8840188 12.90971,6.6620196L12.90971,5.2340206C12.90971,3.4510215,11.458724,2.0000224,9.6757421,2.0000226z M22.539979,3.5280435E-05C25.426872,3.5464926E-05,27.774786,2.348034,27.774786,5.234032L27.774786,6.662031C27.774786,7.8460306 27.378801,8.9630297 26.681827,9.862029 29.092738,10.556028 30.370691,11.810028 31.041666,12.847027 32.104628,14.491026 32.060629,16.174024 31.924635,16.602024 31.788639,17.027025 31.395653,17.299024 30.971668,17.299024 30.870672,17.299024 30.769676,17.283024 30.667681,17.251024 30.174699,17.094025 29.887709,16.590025 29.992705,16.093025 30.001705,15.952025 30.044703,14.775026 29.143736,13.627026 28.203771,12.431027 26.58483,11.694028 24.328913,11.434029 23.890929,11.383028 23.536942,11.051028 23.458944,10.617028 23.380947,10.182029 23.59694,9.7480296 23.990925,9.5490292 25.090885,8.9900292 25.774859,7.8830303 25.774859,6.662031L25.774859,5.234032C25.774859,3.4500333 24.323913,2.0000342 22.539979,2.000034 21.987998,2.0000342 21.540015,1.5520345 21.540015,1.0000349 21.540015,0.44703519 21.987998,3.5464926E-05 22.539979,3.5280435E-05z M9.2087464,2.3838132E-05L9.6757421,2.3838132E-05C12.561714,2.3746183E-05,14.909691,2.3480223,14.909691,5.2340206L14.909691,6.6620196C14.909691,7.8470186 14.514695,8.9630183 13.816701,9.8620175 16.227678,10.556017 17.506665,11.810017 18.176658,12.848016 19.239648,14.491014 19.195649,16.175012 19.05965,16.602013 18.926651,17.017013 18.542655,17.299013 18.106659,17.299013L1.0228271,17.299013C0.5878315,17.299013 0.20183563,17.017013 0.069836617,16.602013 -0.064162254,16.180014 -0.10916138,14.514014 0.93082809,12.882015 1.5798216,11.864016 2.8108091,10.630017 5.1227865,9.9190177 4.3947935,9.0050181 3.9737978,7.8580188 3.9737978,6.6620196L3.9737978,5.2340206C3.9737978,2.3480223,6.3217754,2.3746183E-05,9.2087464,2.3838132E-05z M15.607005,0L16.072991,0C18.959914,-1.7591628E-07,21.307792,2.3480207,21.307792,5.2340053L21.307792,6.6619829C21.307792,7.8460029 20.91181,8.9630068 20.214813,9.8619927 22.625738,10.556023 23.903708,11.80999 24.574705,12.846976 25.637655,14.491018 25.593651,16.174 25.457669,16.601978 25.321688,17.027027 24.928697,17.299 24.5047,17.299 24.40369,17.299 24.302681,17.283008 24.200695,17.251026 23.707731,17.093983 23.420754,16.590015 23.525731,16.093006 23.534702,15.952016 23.577731,14.775015 22.676762,13.627005 21.736793,12.431022 20.117832,11.694023 17.86193,11.434013 17.423957,11.382988 17.069966,11.051018 16.991966,10.616998 16.913965,10.182 17.129961,9.747979 17.523929,9.5490044 18.623866,8.9899844 19.307863,7.8829902 19.307863,6.6619829L19.307863,5.2340053C19.307863,3.4500097,17.856925,1.9999986,16.072991,1.9999983L15.607005,1.9999983C15.054046,1.9999986 14.60704,1.5520008 14.60704,0.99999916 14.60704,0.447021 15.054046,-1.7591628E-07 15.607005,0z"
            });
            DragAndDropAppointments.Add(new Event() { From = date.AddDays(-1).AddHours(12), To = date.AddDays(-1).AddHours(13), 
                Color = this.ColorCollection[7],
                ForegroundColor = new SolidColorBrush(Colors.Black),
                EventName = "General Meeting", Notes = "Meeting of all the shareholders of a company.",
                ImageData = "M16.485048,11.615066C13.010075,11.615066,10.182073,14.44307,10.182073,17.918048L10.182073,20.706074 22.788024,20.706074 22.788024,17.918048C22.788024,14.44307,19.960083,11.615066,16.485048,11.615066z M16.485048,9.676039C21.030029,9.6760393,24.727049,13.374039,24.727049,17.918048L24.727049,22.64504 8.2430484,22.64504 8.2430484,17.918048C8.2430484,13.374039,11.941045,9.6760393,16.485048,9.676039z M26.168022,8.4040185C29.660028,8.4040183,32.001034,10.742021,32.001034,14.222025L32.001034,20.040032 25.631395,20.040032 25.631395,18.101029 30.062029,18.101029 30.062029,14.222025C30.062029,11.829022 28.572027,10.343021 26.175022,10.343021 24.996019,10.343021 23.857018,10.818021 23.042016,11.646022L21.659014,10.28602C22.837015,9.0890191,24.480019,8.4040183,26.168022,8.4040185z M6.3570112,8.404018C8.1380143,8.4040183,9.9490175,9.1250192,11.09202,10.286021L9.7100171,11.646022C8.9300157,10.854021 7.6180133,10.343021 6.3660108,10.343021 4.1620069,10.343021 1.9400029,11.675022 1.9400029,14.222025L1.9400029,18.101029 7.3396385,18.101029 7.3396385,20.040032 0,20.040032 0,14.222025C0,10.905021,2.7330046,8.4040183,6.3570112,8.404018z M26.181997,2.8080306C25.209997,2.8080306 24.420998,3.5980282 24.420998,4.5690246 24.420998,5.5400214 25.209997,6.330019 26.181997,6.330019 27.152998,6.330019 27.941998,5.5400214 27.941998,4.5690246 27.941998,3.5980282 27.152998,2.8080306 26.181997,2.8080306z M6.3500191,2.8080306C5.379019,2.8080306 4.590019,3.5980282 4.5900192,4.5690246 4.590019,5.5400214 5.379019,6.330019 6.3500191,6.330019 7.3220187,6.330019 8.1110186,5.5400214 8.1110184,4.5690246 8.1110186,3.5980282 7.3220187,2.8080306 6.3500191,2.8080306z M16.445042,1.9389987C14.997042,1.9389987 13.819043,3.1169982 13.819043,4.5649972 13.819043,6.0129964 14.997042,7.1909959 16.445042,7.1909957 17.893041,7.1909959 19.07104,6.0129964 19.07104,4.5649972 19.07104,3.1169982 17.893041,1.9389987 16.445042,1.9389987z M26.181997,0.86903667C28.221998,0.86903667 29.881998,2.5290313 29.881998,4.5690246 29.881998,6.6090181 28.221998,8.2690126 26.181997,8.2690126 24.140998,8.2690126 22.480998,6.6090181 22.480998,4.5690246 22.480998,2.5290313 24.140998,0.86903667 26.181997,0.86903667z M6.3500191,0.86903667C8.3910186,0.86903667 10.051018,2.5290313 10.051018,4.5690246 10.051018,6.6090181 8.3910186,8.2690126 6.3500191,8.2690126 4.310019,8.2690126 2.6500192,6.6090181 2.6500192,4.5690246 2.6500192,2.5290313 4.310019,0.86903667 6.3500191,0.86903667z M16.445042,0C18.96204,0 21.010039,2.0479984 21.010039,4.5649972 21.010039,7.081996 18.96204,9.1299948 16.445042,9.1299946 13.928043,9.1299948 11.880044,7.081996 11.880044,4.5649972 11.880044,2.0479984 13.928043,0 16.445042,0z"
            });
            DragAndDropAppointments.Add(new Event() { From = date.AddDays(-5).AddHours(18), To = date.AddDays(-5).AddHours(19),
                Color = this.ColorCollection[8],
                ForegroundColor = new SolidColorBrush(Colors.White),
                EventName = "Yoga Therapy", Notes = "Encourages the integration of mind, body, and spirit.",
                ImageData = "M16.073033,13.912994L16.073033,23.354004 18.95505,22.559021C19.054049,22.559021,19.15305,22.459961,19.253056,22.459961L17.961047,21.664978C17.265034,21.167969,17.066035,20.372986,17.265034,19.677002L17.265034,13.912994z M7.8239708,13.912994L7.8239708,20.27298 7.5259642,20.27298C7.5259642,20.77002,7.2279653,21.266968,6.7309603,21.664978L5.438951,22.459961 5.8369565,22.459961C6.1349549,22.459961,6.3339538,22.459961,6.6319604,22.559021L8.4199757,23.055969 8.4199757,13.912994z M9.413979,8.7449951L15.377028,8.7449951C17.861041,8.7449951,19.948054,10.634003,19.948054,13.21698L19.948054,13.912994 19.948054,18.583984C19.948054,18.583984,20.04806,18.583984,20.04806,18.682983L24.023095,21.365967C24.818099,21.862976 25.01709,22.95697 24.520092,23.851013 24.023095,24.546997 23.129076,24.844971 22.433072,24.546997 22.731078,25.539978 22.433072,26.533997 21.737069,27.22998 22.433072,27.924988 22.731078,28.919006 22.433072,29.912964 22.135081,31.106018 21.042071,32 19.750054,32 19.452048,32 19.253056,32 18.95505,31.901001L12.793002,30.210999 6.6319604,31.901001C6.4329614,31.800964 6.1349549,31.800964 5.935956,31.800964 4.6439466,31.800964 3.5509364,31.005981 3.2529375,29.713989 2.9549312,28.719971 3.2529375,27.72699 3.9479425,27.031006 3.2529375,26.334961 2.9549312,25.34198 3.2529375,24.347961 3.3519375,24.049988 3.4519367,23.851013 3.5509364,23.552979L2.7559321,24.148987C1.9609283,24.645996 0.86791787,24.447021 0.27091334,23.651978 -0.22609199,22.95697 -0.027093017,21.862976 0.7679188,21.266968L4.6439466,18.682983 4.6439466,13.912994 4.6439466,13.316986C4.6439466,10.733002,6.8299598,8.7449951,9.413979,8.7449951z M12.495002,0C14.681015,0 16.47003,1.7890015 16.47003,3.9750061 16.47003,6.1609802 14.681015,7.9499817 12.495002,7.9499817 10.30899,7.9499817 8.5199752,6.1609802 8.5199752,3.9750061 8.5199752,1.7890015 10.30899,0 12.495002,0z"
            });
            DragAndDropAppointments.Add(new Event() { From = date.AddDays(6).AddHours(14), To = date.AddDays(6).AddHours(15),
                Color = this.ColorCollection[0],
                ForegroundColor = new SolidColorBrush(Colors.White),
                EventName = "GoToMeeting", Notes = "User to meet with other users, customers, clients or colleagues.",
                ImageData = "M13.720991,20.66501L13.556989,21.246004 14.145002,21.089998C14.145002,21.089998,13.777998,21.063005,13.720991,20.66501z M16.852006,17.065004L14.138014,19.778002C14.138014,19.778002 14.311995,19.998003 14.159986,20.240999 14.159986,20.240999 14.638991,20.203005 14.57701,20.688005 14.57701,20.688005 14.728987,20.505999 15.017012,20.688005L17.762011,17.94301C17.762011,17.94301,17.041001,17.906008,16.852006,17.065004z M17.680009,16.278002C17.646012,16.278002,17.612015,16.282,17.578995,16.291002L17.017991,16.852007C17.017991,16.852007,17.09401,17.655001,17.97301,17.77701L18.504992,17.246004C18.504992,17.246004 18.640002,17.110002 18.353015,16.701006 18.353015,16.701006 18.009997,16.283998 17.680009,16.278002z M15.975998,14.490999C18.384997,14.490999 20.337025,16.44301 20.337025,18.852007 20.337025,21.260012 18.384997,23.213001 15.975998,23.213001 13.568006,23.213001 11.616008,21.260012 11.616008,18.852007 11.616008,16.44301 13.568006,14.490999 15.975998,14.490999z M24.960992,13.746004L27.720029,13.746004C29.986998,13.746004 31.59503,15.548998 31.817017,17.800005 31.856019,18.171999 31.921998,18.617006 31.999999,19.104998L24.783013,19.104998C24.637994,18.097002 24.483025,17.296999 24.405022,16.643999 24.332024,15.645006 24.041985,14.722002 23.653006,13.904009 24.054986,13.795 24.491997,13.746004 24.960992,13.746004z M4.2619974,13.746004L7.0199959,13.746004C7.3909981,13.746004 7.7399976,13.795 8.0669934,13.824999 7.6579968,14.667009 7.3989937,15.623003 7.290992,16.660006 7.2569954,17.319002 7.1209785,18.104998 6.9589912,19.104998L0,19.104998C0.069000308,18.619005 0.12799084,18.175005 0.16299438,17.800005 0.36599765,15.546999 1.9939899,13.746004 4.2619974,13.746004z M14.121992,11.626009L17.617997,11.626009C20.470021,11.626009 22.50701,13.92 22.801993,16.752001 22.869986,17.404009 22.997,18.211 23.142997,19.104998L21.244008,19.104998 21.249989,18.852007C21.249989,15.944002 18.884021,13.578005 15.975998,13.578005 13.069012,13.578005 10.702983,15.944002 10.702983,18.852007L10.708995,19.104998 8.6290061,19.104998C8.7609946,18.214998 8.8759849,17.410006 8.9379966,16.752001 9.2020051,13.918001 11.255993,11.626009 14.121992,11.626009z M26.340022,4.4870004C28.744992,4.4870004 30.723021,6.5090036 30.723021,8.8690042 30.723021,11.31801 28.744992,13.253008 26.340022,13.253008 23.936028,13.253008 21.957999,11.31801 21.957999,8.8690042 21.957999,6.5090036 23.936028,4.4870004 26.340022,4.4870004z M5.6399896,4.4870004C8.0449903,4.4870004 10.022989,6.5090036 10.022989,8.8690042 10.022989,11.31801 8.0449903,13.253008 5.6399896,13.253008 3.2359955,13.253008 1.2579968,11.31801 1.257997,8.8690042 1.2579968,6.5090036 3.2359955,4.4870004 5.6399896,4.4870004z M15.87001,0C18.908984,1.2219764E-07 21.423024,2.4400029 21.423024,5.5180063 21.423024,8.5989999 18.908984,11.031008 15.87001,11.031008 12.790997,11.031008 10.314982,8.5989999 10.314982,5.5180063 10.314982,2.4400029 12.790997,1.2219764E-07 15.87001,0z"
            });
        }

        #endregion

        #endregion Methods
    }
}
