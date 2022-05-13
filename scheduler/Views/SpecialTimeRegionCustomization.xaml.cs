#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace syncfusion.schedulerdemos.winui
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class SpecialTimeRegionCustomization : Page, IDisposable
	{
		public SpecialTimeRegionCustomization()
		{
			this.InitializeComponent();
			this.scheduler.DaysViewSettings.SpecialTimeRegions = GetSpecialTimeRegions();
			this.scheduler.TimelineViewSettings.SpecialTimeRegions = GetSpecialTimeRegions();
			this.scheduler.DaysViewSettings.MinimumAppointmentDuration = new TimeSpan(0, 30, 0);
			this.scheduler.TimelineViewSettings.MinimumAppointmentDuration = new TimeSpan(0, 30, 0);
		}

		private ObservableCollection<SpecialTimeRegion> GetSpecialTimeRegions()
		{
			var currentDate = DateTime.Now.AddMonths(-3);
			var nonWorkingHours1 = new SpecialTimeRegion();
			nonWorkingHours1.StartTime = new DateTime(currentDate.Year, currentDate.Month, 1, 10, 0, 0);
			nonWorkingHours1.EndTime = nonWorkingHours1.StartTime.AddHours(1);
			nonWorkingHours1.RecurrenceRule = "FREQ=DAILY;INTERVAL=1";
			nonWorkingHours1.CanEdit = false;

			var nonWorkingHours2 = new SpecialTimeRegion();
			nonWorkingHours2.StartTime = new DateTime(currentDate.Year, currentDate.Month, 1, 13, 0, 0);
			nonWorkingHours2.EndTime = nonWorkingHours2.StartTime.AddHours(1);
			nonWorkingHours2.RecurrenceRule = "FREQ=DAILY;INTERVAL=1";
			nonWorkingHours2.CanMergeAdjacentRegions = true;
			nonWorkingHours2.CanEdit = false;

			var specialTimeRegions = new ObservableCollection<SpecialTimeRegion>();
			specialTimeRegions.Add(nonWorkingHours1);
			specialTimeRegions.Add(nonWorkingHours2);

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


			if (this.DataContext is SchedulerBindingViewModel)
			{
				(this.DataContext as SchedulerBindingViewModel).Dispose();
				this.DataContext = null;
			}
		}
	}
}
