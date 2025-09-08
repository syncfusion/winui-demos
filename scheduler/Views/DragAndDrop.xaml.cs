#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
	public sealed partial class DragAndDrop : Page
	{
		private DateTime droppingTime;

		public DragAndDrop()
		{
			this.InitializeComponent();
		}

		private void Scheduler_AppointmentDropping(object sender, AppointmentDroppingEventArgs e)
		{
			droppingTime = e.DropTime;
		}

		private void listView_DragStarting(UIElement sender, DragStartingEventArgs args)
		{
			var appointment = (sender as Grid).DataContext as Event;

			if (appointment != null)
			{
				args.Data.Properties.Add("listViewAppointment", appointment);
			}
		}

		private void scheduler_Drop(object sender, DragEventArgs e)
		{
			var appointment = e.DataView.Properties["listViewAppointment"] as Event;
			if (appointment == null)
				return;

			TimeSpan timeInterval;
			if (scheduler.ViewType == SchedulerViewType.TimelineDay || scheduler.ViewType == SchedulerViewType.TimelineWeek || scheduler.ViewType == SchedulerViewType.TimelineWorkWeek)
				timeInterval = scheduler.TimelineViewSettings.TimeInterval;
			else
				timeInterval = scheduler.DaysViewSettings.TimeInterval;

			appointment.From = (DateTime)droppingTime;
			appointment.To = appointment.From.Add(timeInterval);

			var viewModel = this.DataContext as SchedulerBindingViewModel;
			// condition to remove appointment from list view items source.
			if (viewModel.ListViewAppointments.Contains(appointment))
			{
				viewModel.ListViewAppointments.Remove(appointment);
			}
			// condition to add appointment into scheduler items source.
			if (!viewModel.DragAndDropAppointments.Contains(appointment))
			{
				viewModel.DragAndDropAppointments.Add(appointment);
			}
		}

		private void listView_DragLeave(object sender, DragEventArgs e)
		{
			var app = e.DataView.Properties["Appointment"] as ScheduleAppointment;
			if (app == null)
				return;

			var appointment = app.Data as Event;
			var viewModel = this.DataContext as SchedulerBindingViewModel;

			if (appointment.EventName == string.Empty)
				appointment.EventName = "(No title)";

			// condition to Remove appointment from scheduler items source.
			if (viewModel.DragAndDropAppointments.Contains(appointment))
			{
				viewModel.DragAndDropAppointments.Remove(appointment);
			}
			//// condition to add appointment into listview items source.
			if (!viewModel.ListViewAppointments.Contains(appointment))
			{
				viewModel.ListViewAppointments.Insert(0, appointment);
			}
		}
	}
}
