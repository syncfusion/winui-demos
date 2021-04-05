#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace syncfusion.schedulerdemos.winui
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class TimeslotCustomization : Page , IDisposable
	{
		public TimeslotCustomization()
		{
			this.InitializeComponent();
			this.datePicker.SelectedDate = new DateTimeOffset(this.scheduler.DisplayDate.Date);
			this.scheduler.DaysViewSettings.MinimumAppointmentDuration = new TimeSpan(0, 30, 0);
			this.scheduler.TimelineViewSettings.MinimumAppointmentDuration = new TimeSpan(0, 30, 0);
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

		private void OnTimeRulerClick(object sender, RoutedEventArgs e)
		{
			if ((bool)timeRuler.IsChecked)
			{
				this.scheduler.DaysViewSettings.TimeRulerSize = 52;
				this.scheduler.TimelineViewSettings.TimeRulerSize = 30;
			}
			else
			{
				this.scheduler.DaysViewSettings.TimeRulerSize = 0;
				this.scheduler.TimelineViewSettings.TimeRulerSize = 0;
			}
		}

		private void OnShowHeaderClick(object sender, RoutedEventArgs e)
		{
			if ((bool)showHeader.IsChecked)
			{
				this.scheduler.DaysViewSettings.ViewHeaderHeight = 50;
				this.scheduler.TimelineViewSettings.ViewHeaderHeight = 32;
			}
			else
			{
				this.scheduler.DaysViewSettings.ViewHeaderHeight = 0;
				this.scheduler.TimelineViewSettings.ViewHeaderHeight = 0;
			}
		}

		private void OnViewTypeComboboxSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (viewtypecombobox.SelectedValue != null)
			{
				if (viewtypecombobox.SelectedValue.ToString() == "TimelineMonth")
					this.scheduler.TimelineViewSettings.TimeIntervalSize = 150;
				else
					this.scheduler.TimelineViewSettings.TimeIntervalSize = 50;
			}
		}
	}
}
