#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace syncfusion.schedulerdemos.winui
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class RecursiveExceptionAppointment : Page, IDisposable
	{
		public RecursiveExceptionAppointment()
		{
			this.InitializeComponent();
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

		private void OnViewTypeComboboxSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (viewtypecombobox.SelectedValue != null)
			{
				if (viewtypecombobox.SelectedValue.ToString() == "TimelineMonth")
					this.scheduler.TimelineViewSettings.TimeIntervalSize = 150;
				else
					this.scheduler.TimelineViewSettings.TimeIntervalSize = 50;
			}
			else if (viewtypecombobox.SelectedIndex < 0)
				viewtypecombobox.SelectedIndex = 1;
		}
	}
}
