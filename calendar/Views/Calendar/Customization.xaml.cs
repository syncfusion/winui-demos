#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.Calendar;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Syncfusion.CalendarDemos.WinUI.Views.Calendar
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
            // To restrict the focus on first control when clicking on empty area.
            e.Handled = true;
        }

        private void Blackout_ItemPrepared(object sender, CalendarItemPreparedEventArgs e)
        {
            if (e.ItemInfo.ItemType == CalendarItemType.Day &&
                (e.ItemInfo.Date.DayOfWeek == DayOfWeek.Saturday ||
                e.ItemInfo.Date.DayOfWeek == DayOfWeek.Sunday))
            {
                e.ItemInfo.IsBlackout = true;
            }
        }

        public void Dispose()
        {
            this.customizationViewPanel.PointerPressed -= OnCustomizationViewPanelPointerPressed;
            if (this.calendar4 != null)
            {
                this.calendar4.Dispose();
                this.calendar4 = null;
            }

            if (this.calendar5 != null)
            {
                this.calendar5.Dispose();
                this.calendar5 = null;
            }

            if (this.calendar6 != null)
            {
                this.calendar6.Dispose();
                this.calendar6 = null;
            }

            if (this.weekNumber != null)
            {
                this.weekNumber.Dispose();
                this.weekNumber = null;
            }
        }
    }
}
