#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Microsoft.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Syncfusion.CalendarDemos.WinUI.Views.CalendarDateRangePicker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Customization : Page, IDisposable
    {
        public Customization()
        {
            this.InitializeComponent();
            this.customizationViewPanel.PointerPressed += OnCustomizationViewPanelPointerPressed;
        }

        private void OnCustomizationViewPanelPointerPressed(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            //To restrict the focus on first control when clicking on empty area.
            e.Handled = true;
        }

        public void Dispose()
        {
            this.customizationViewPanel.PointerPressed -= OnCustomizationViewPanelPointerPressed;
            if (this.calendarDateRangePicker1 != null)
            {
                this.calendarDateRangePicker1.Dispose();
                this.calendarDateRangePicker1 = null;
            }

            if (this.calendarDateRangePicker2 != null)
            {
                this.calendarDateRangePicker2.Dispose();
                this.calendarDateRangePicker2 = null;
            }
        }
    }
}
