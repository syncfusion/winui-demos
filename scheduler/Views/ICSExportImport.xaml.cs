using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.SchedulerDemos.WinUI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ICSExportImport : Page, IDisposable
    {
        /// <summary>
        /// current day meetings 
        /// </summary>
        private List<string> currentDayMeetings;

        /// <summary>
        /// Notes Collection.
        /// </summary>
        private List<string> notesCollection;

        /// <summary>
        /// minimum time meetings
        /// </summary>
        private List<string> minTimeMeetings;

        /// <summary>
        /// time collection.
        /// </summary>
        List<Point> randomTimeCollection;

        /// <summary>
        /// the appointment collections.
        /// </summary>
        private ObservableCollection<Event> appointments;

        /// <summary>
        /// Initializes a new instance of the <see cref="ICSExportImport"/> class.
        /// </summary>
        public ICSExportImport()
        {
            this.InitializeComponent();
            this.scheduler.DaysViewSettings.MinimumAppointmentDuration = new TimeSpan(0, 30, 0);
            this.scheduler.TimelineViewSettings.MinimumAppointmentDuration = new TimeSpan(0, 30, 0);
            this.scheduler.DaysViewSettings.TimeInterval = new System.TimeSpan(0, 30, 0);
            this.scheduler.TimelineViewSettings.TimeInterval = new System.TimeSpan(0, 30, 0);
            this.scheduler.DaysViewSettings.TimeIntervalSize = 60;
            this.scheduler.TimelineViewSettings.TimeIntervalSize = 60;
            this.appointments = new ObservableCollection<Event>();
            InitializeDataForBookings();
            IntializeAppoitments();
            this.scheduler.ItemsSource = this.appointments;
        }

        /// <summary>
        /// Dispose all the allocated resources.
        /// </summary>
        public void Dispose()
        {
            if (this.scheduler != null)
            {
                this.scheduler.Dispose();
                this.scheduler = null;
            }

            if (this.DataContext is SchedulerBindingViewModel)
            {
                (this.DataContext as SchedulerBindingViewModel).Dispose();
                this.DataContext = null;
            }
        }

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

            this.randomTimeCollection = new List<Point>();
            this.randomTimeCollection.Add(new Point(9, 11));
            this.randomTimeCollection.Add(new Point(12, 14));
            this.randomTimeCollection.Add(new Point(15, 17));
        }

        /// <summary>
        /// Method for initialize appoitments.
        /// </summary>
        private void IntializeAppoitments()
        {
            Random randomTime = new Random();

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
                        int hour = randomTime.Next((int)this.randomTimeCollection[additionalAppointmentIndex].X, (int)this.randomTimeCollection[additionalAppointmentIndex].Y);
                        meeting.From = new DateTime(date.Year, date.Month, date.Day, hour, 0, 0);
                        meeting.To = meeting.From.AddHours(1);
                        meeting.EventName = this.currentDayMeetings[randomTime.Next(9)];
                        meeting.IsAllDay = false;
                        meeting.Notes = this.notesCollection[randomTime.Next(9)];
                        meeting.StartTimeZone = string.Empty;
                        meeting.EndTimeZone = string.Empty;
                        this.appointments.Add(meeting);
                    }
                }
                else
                {
                    Event meeting = new Event();
                    meeting.From = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(9, 11), 0, 0);
                    meeting.To = meeting.From.AddDays(2).AddHours(1);
                    meeting.EventName = this.currentDayMeetings[randomTime.Next(9)];
                    meeting.IsAllDay = true;
                    meeting.Notes = this.notesCollection[randomTime.Next(9)];
                    meeting.StartTimeZone = string.Empty;
                    meeting.EndTimeZone = string.Empty;
                    this.appointments.Add(meeting);
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
                meeting.Notes = this.notesCollection[randomTime.Next(0, 4)];
                meeting.StartTimeZone = string.Empty;
                meeting.EndTimeZone = string.Empty;

                this.appointments.Add(meeting);
            }
        }

        #endregion InitializeDataForBookings

        /// <summary>
        /// Exports the scheduler appointments to a local .ics file.
        /// </summary>
        private async void OnExportClicked(object sender, RoutedEventArgs e)
        {
            if (this.scheduler == null)
            {
                return;
            }

            bool exported = await this.scheduler.ExportToICalendar("CalendarICS");
            if (exported)
            {
                ContentDialog successDialog = new ContentDialog
                {
                    Title = "Success",
                    Content = "Appointments exported successfully to the Downloads folder.",
                    CloseButtonText = "OK",
                    XamlRoot = this.XamlRoot
                };

                await successDialog.ShowAsync();
            }
        }

        /// <summary>
        /// Imports scheduled appointments from a user-picked .ics file.
        /// </summary>
        private async void OnImportClicked(object sender, RoutedEventArgs e)
        {
            if (this.scheduler == null)
            {
                return;
            }

            bool imported = await this.scheduler.ImportICalendar();
            if (imported)
            {
                ContentDialog importDialog = new ContentDialog
                {
                    Title = "Success",
                    Content = "Appointments imported successfully.",
                    CloseButtonText = "OK",
                    XamlRoot = this.XamlRoot
                };

                await importDialog.ShowAsync();
            }
        }
    }
}
