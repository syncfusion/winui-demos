#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.SchedulerDemos.WinUI
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class AppointmentCustomaization : Page, IDisposable
	{
        private ObservableCollection<Event> appointments;

        public AppointmentCustomaization()
		{
			this.InitializeComponent();
			this.scheduler.ViewChanged += OnSchedulerViewChanged;
		}

        private void OnSchedulerViewChanged(object sender, ViewChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                var viewModel = this.scheduler.DataContext as SchedulerBindingViewModel;
                var startDate = e.NewValue.StartDate;
                var random = new Random();
                appointments = new ObservableCollection<Event>();
                if (this.scheduler.ViewType == SchedulerViewType.Week || this.scheduler.ViewType == SchedulerViewType.WorkWeek)
                {
                    List<DateTime> visibleDates = new List<DateTime>();

                    for (DateTime date = startDate; date <= e.NewValue.EndDate; date = date.AddDays(1))
                    {
                        visibleDates.Add(date.Date);
                    }
                    if (!visibleDates.Contains(DateTime.Now.Date))
                    {
                        this.scheduler.ItemsSource = appointments;
                    }
                    else
                    {
                        startDate = startDate.AddDays(1);
                        for (int i = 0; i < 5; i++)
                        {
                            Event schedulerModel = new Event();
                            schedulerModel.Color = viewModel.DayViewColors[i];
                            schedulerModel.From = startDate.AddDays(i).AddHours(10);
                            schedulerModel.To = startDate.AddDays(i).AddHours(16);
                            schedulerModel.EventName = viewModel.DayViewAppointments[i];
                            schedulerModel.TimeValue = "Time: " + schedulerModel.From.ToShortTimeString() + " - " + schedulerModel.To.ToShortTimeString();
                            schedulerModel.Notes = viewModel.DayViewNotes[i];
                            appointments.Add(schedulerModel);
                        }
                        this.scheduler.ItemsSource = appointments;
                    }
                }

                else
                {
                    for (DateTime date = startDate; date <= e.NewValue.EndDate; date = date.AddDays(1))
                    {
                        Event schedulerModel = new Event();
                        schedulerModel.Color = viewModel.ColorCollection[random.Next(0, 9)];
                        schedulerModel.From = date.AddHours(random.Next(9, 13));
                        schedulerModel.To = schedulerModel.From.AddHours(4);
                        schedulerModel.EventName = viewModel.TeamManagement[random.Next(0, 9)];
                        schedulerModel.TimeValue = schedulerModel.From.ToShortTimeString();
                        appointments.Add(schedulerModel);
                    }

                    for (DateTime date = startDate; date <= e.NewValue.EndDate; date = date.AddDays(2))
                    {
                        Event schedulerModel = new Event();
                        schedulerModel.Color = viewModel.ColorCollection[random.Next(0, 9)];
                        schedulerModel.From = date.AddHours(random.Next(13, 16));
                        schedulerModel.To = schedulerModel.From.AddHours(4);
                        schedulerModel.EventName = viewModel.TeamManagement[random.Next(0, 9)];
                        schedulerModel.TimeValue = schedulerModel.From.ToShortTimeString();
                        appointments.Add(schedulerModel);
                    }
                    this.scheduler.ItemsSource = appointments;
                }
            }
        }

        /// <summary>
        /// Dispose all the allocated resources.
        /// </summary>
        public void Dispose()
        {
            if (this.scheduler != null)
            {
                this.scheduler.ViewChanged -= OnSchedulerViewChanged;
                this.scheduler.Dispose();
                this.scheduler = null;
            }

            if (this.DataContext is SchedulerBindingViewModel)
            {
                (this.DataContext as SchedulerBindingViewModel).Dispose();
                this.DataContext = null;
            }
        }
    }
}
