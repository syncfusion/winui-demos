#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Microsoft.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Syncfusion.CalendarDemos.WinUI.Views.Calendar
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CalendarView : Page, IDisposable
    {
        public CalendarView()
        {
            this.InitializeComponent();
            this.calendarViewPanel.PointerPressed += OnCalendarViewPanelPointerPressed;
        }

        private void OnCalendarViewPanelPointerPressed(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            // To restrict the focus on first control when clicking on empty area.
            e.Handled = true;
        }

        private void languages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedLang = languages.SelectedValue.ToString();
            if (Windows.Globalization.Language.IsWellFormed(selectedLang))
            {
                calendar3.Language = selectedLang;
            }
        }

        public void Dispose()
        {
            this.calendarViewPanel.PointerPressed -= OnCalendarViewPanelPointerPressed;
            if (this.calendar1 != null)
            {
                this.calendar1.Dispose();
                this.calendar1 = null;
            }

            if (this.calendar2 != null)
            {
                this.calendar2.Dispose();
                this.calendar2 = null;
            }

            if (this.calendar3 != null)
            {
                this.calendar3.Dispose();
                this.calendar3 = null;
            }

            if (this.optionDatePicker1 != null)
            {
                this.optionDatePicker1.Dispose();
                this.optionDatePicker1 = null;
            }

            if (this.optionDatePicker2 != null)
            {
                this.optionDatePicker2.Dispose();
                this.optionDatePicker2 = null;
            }
        }
    }
}
