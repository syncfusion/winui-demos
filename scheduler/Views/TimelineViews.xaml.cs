#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.ObjectModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace syncfusion.schedulerdemos.winui
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TimelineViews : Page, IDisposable
    {
        public TimelineViews()
        {
            this.InitializeComponent();
            this.scheduler.TimelineViewSettings.SpecialTimeRegions = GetSpecialTimeRegions();
            this.scheduler.TimelineViewSettings.MinimumAppointmentDuration = new TimeSpan(0, 30, 0);
        }

        private ObservableCollection<SpecialTimeRegion> GetSpecialTimeRegions()
        {
            var currentDate = DateTime.Now.AddMonths(-3);
            var nonWorkingHours1 = new SpecialTimeRegion();
            nonWorkingHours1.StartTime = new DateTime(currentDate.Year, currentDate.Month, 1, 13, 0, 0);
            nonWorkingHours1.EndTime = nonWorkingHours1.StartTime.AddHours(1);
            nonWorkingHours1.RecurrenceRule = "FREQ=DAILY;INTERVAL=1";
            nonWorkingHours1.Text = "Lunch";
            nonWorkingHours1.CanEdit = false;

            var specialTimeRegions = new ObservableCollection<SpecialTimeRegion>();
            specialTimeRegions.Add(nonWorkingHours1);

            return specialTimeRegions;
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

            if (this.DataContext is GettingStartedViewModel)
            {
                (this.DataContext as GettingStartedViewModel).Dispose();
                this.DataContext = null;
            }
        }
    }
}
