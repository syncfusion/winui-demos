#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Syncfusion.UI.Xaml.Core;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI;

namespace Syncfusion.SchedulerDemos.WinUI
{
    /// <summary>
    /// Load on demand view model.
    /// </summary>
    public class LoadOnDemandViewModel : NotificationObject, IDisposable
    {
        #region Fields

        /// <summary>
        /// Gets or Sets event collection.
        /// </summary>
        private IEnumerable events;

        /// <summary>
        /// Gets or sets a value indicating whether to show the busy indicator.
        /// </summary>
        private bool showBusyIndicator;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets load on demand command.
        /// </summary>
        public DelegateCommand LoadOnDemandCommand { get; set; }

        /// <summary>
        /// Gets or sets event collection.
        /// </summary>
        public IEnumerable Events
        {
            get { return events; }
            set
            {
                events = value;
                this.RaisePropertyChanged("Events");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show the busy indicator.
        /// </summary>
        public bool ShowBusyIndicator
        {
            get { return showBusyIndicator; }
            set
            {
                showBusyIndicator = value;
                this.RaisePropertyChanged("ShowBusyIndicator");
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

        /// <summary>
        /// Gets or sets scheduler view type collection
        /// </summary>
        public ObservableCollection<SchedulerViewTypeModel> SchedulerViewTypes { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LoadOnDemandViewModel" /> class.
        /// </summary>
        public LoadOnDemandViewModel()
        {
            this.DisplayDate = DateTime.Now.Date.AddHours(9);
            MinDate = DateTime.Now.Date;
            MaxDate = DateTime.Now.Date.AddMonths(6);
            this.LoadOnDemandCommand = new DelegateCommand(ExecuteOnDemandLoading, CanExecuteOnDemandLoading);
            this.SchedulerViewTypes = SchedulerViewTypeHelper.GetSchedulerViewTypes();
        }

        #endregion

        #region Methods
        /// <summary>
        /// Method to excute load on demand command and set scheduler appointments.
        /// </summary>
        /// <param name="parameter">QueryAppointmentsEventArgs object.</param>
        public async void ExecuteOnDemandLoading(object parameter)
        {
            if (parameter == null)
            {
                return;
            }

            this.ShowBusyIndicator = true;
            await Task.Delay(300);
            Application.Current.Resources.DispatcherQueue.TryEnqueue(() =>
            {
                this.Events = this.GenerateSchedulerAppointments((parameter as QueryAppointmentsEventArgs).VisibleDateRange);
            });
            this.ShowBusyIndicator = false;
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
                    if (this.Events is IList)
                    {
                        (this.Events as IList).Clear();
                    }

                    this.Events = null;
                }

                if (this.LoadOnDemandCommand != null)
                {
                    this.LoadOnDemandCommand = null;
                }

                if (this.SchedulerViewTypes != null)
                {
                    this.SchedulerViewTypes.Clear();
                    this.SchedulerViewTypes = null;
                }
            }
        }

        /// <summary>
        /// Method to check whether the load on demand command can be invoked or not.
        /// </summary>
        /// <param name="sender">QueryAppointmentsEventArgs object.</param>
        private bool CanExecuteOnDemandLoading(object sender)
        {
            return true;
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

        /// <summary>
        /// Method to generate scheduler appointments based on current visible date range.
        /// </summary>
        /// <param name="dateRange">Current visible date range.</param>
        private IEnumerable GenerateSchedulerAppointments(DateRange dateRange)
        {
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

            var subjectCollection = new ObservableCollection<string>();
            subjectCollection.Add("Business Meeting");
            subjectCollection.Add("Conference");
            subjectCollection.Add("Medical check up");
            subjectCollection.Add("Performance Check");
            subjectCollection.Add("Consulting");
            subjectCollection.Add("Project Status Discussion");
            subjectCollection.Add("Client Meeting");
            subjectCollection.Add("General Meeting");
            subjectCollection.Add("Yoga Therapy");
            subjectCollection.Add("GoToMeeting");
            subjectCollection.Add("Plan Execution");
            subjectCollection.Add("Project Plan");

            Random ran = new Random();
            int daysCount = (dateRange.ActualEndDate - dateRange.ActualStartDate).Days;
            var appointments = new ObservableCollection<Event>();
            for (int i = 0; i < 50; i++)
            {
                var startTime = dateRange.ActualStartDate.AddDays(ran.Next(0, daysCount + 1)).AddHours(ran.Next(0, 24));
                Event meeting = new Event();
                meeting.From = startTime;
                meeting.To = startTime.AddHours(1);
                meeting.EventName = subjectCollection[ran.Next(0, subjectCollection.Count)];
                meeting.Color = brush[ran.Next(0, brush.Count)];
                meeting.ForegroundColor = GetAppointmentForeground(meeting.Color);

                appointments.Add(meeting);
            }
            return appointments;
        }
        #endregion
    }
}
