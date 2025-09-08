#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;
using System;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.SchedulerDemos.WinUI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MonthCellCustomization : Page, IDisposable
    {
        public MonthCellCustomization()
        {
            this.InitializeComponent();
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

        /// <summary>
        /// Event handler for when the "Week Views" toggle switch is toggled.
        /// </summary>
        /// <param name="sender">The object.</param>
        /// <param name="e">The event args.</param>
        private void OnWeekViewsToggled(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch == null)
            {
                return;
            }

            this.scheduler.MonthViewSettings.NumberOfVisibleWeeks = toggleSwitch.IsOn ? 3 : 6;
        }

        /// <summary>
        /// Event handler for when the "Week Number" toggle switch is toggled.
        /// </summary>
        /// <param name="sender">The object.</param>
        /// <param name="e">The event args.</param>
        private void OnWeekNumberToggled(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch == null)
            {
                return;
            }

            this.scheduler.MonthViewSettings.ShowWeekNumber = toggleSwitch.IsOn;
        }
    }
}