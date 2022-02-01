#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Globalization;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.Calendar;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace syncfusion.calendardemos.winui.Views.CalendarDateRangePicker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CalendarDateRangePickerView : Page
    {
        private ListBox listBox;
        public CalendarDateRangePickerView()
        {
            this.InitializeComponent();
            this.calendarDateRangePickerViewPanel.PointerPressed += OnCalendarDateRangePickerViewPanelPointerPressed;
        }

        private void OnCalendarDateRangePickerViewPanelPointerPressed(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            // To restrict the focus on first control when clicking on empty area.
            e.Handled = true;
        }

        private void languages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedLang = languages.SelectedValue.ToString();
            if (Windows.Globalization.Language.IsWellFormed(selectedLang))
            {
                CalendarTypes.Language = selectedLang;
            }
        }

        private void MaxText_ValueChanged(NumberBox sender, NumberBoxValueChangedEventArgs args)
        {
            ulong? nullableCount;
            ulong i;
            if (ulong.TryParse(maxText.Value.ToString(), out i))
            {
                nullableCount = i;
            }
            else
            {
                nullableCount = null;
            }

            calendarDateRangePicker1.MaxDatesCountInRange = nullableCount;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listBox = sender as ListBox;
            if (listBox.SelectedItem.ToString() == "This Week")
            {
                DateTimeOffset startdate = DateTimeOffset.Now.AddDays(-(DateTimeOffset.Now.DayOfWeek - this.GetFirstDayOfWeek(calendarDateRangePicker2.FirstDayOfWeek)));
                this.calendarDateRangePicker2.SelectedRange = new Syncfusion.UI.Xaml.Calendar.DateTimeOffsetRange(startdate, startdate.AddDays(6));
            }
            else if (listBox.SelectedItem.ToString() == "This Month")
            {
                DateTimeOffset startdate = DateTimeOffset.Now.AddDays(-(DateTimeOffset.Now.Date.Day - 1));
                this.calendarDateRangePicker2.SelectedRange = new Syncfusion.UI.Xaml.Calendar.DateTimeOffsetRange(startdate, startdate.AddDays(DateTime.DaysInMonth(startdate.Year, startdate.Month) - 1));
            }
            else if (listBox.SelectedItem.ToString() == "Last Month")
            {
                DateTimeOffset startdate = DateTimeOffset.Now.AddMonths(-1).AddDays(-(DateTimeOffset.Now.Date.Day - 1));
                this.calendarDateRangePicker2.SelectedRange = new Syncfusion.UI.Xaml.Calendar.DateTimeOffsetRange(startdate, startdate.AddDays(DateTime.DaysInMonth(startdate.Year, startdate.Month) - 1));
            }
            else if (listBox.SelectedItem.ToString() == "This Year")
            {
                DateTimeOffset startdate = DateTimeOffset.Now.AddMonths(-(DateTimeOffset.Now.Month - 1)).AddDays(-(DateTimeOffset.Now.Date.Day - 1));
                this.calendarDateRangePicker2.SelectedRange = new Syncfusion.UI.Xaml.Calendar.DateTimeOffsetRange(startdate, startdate.AddMonths(11).AddDays(DateTime.DaysInMonth(startdate.Year, startdate.Month) - 1));
            }
            else if (listBox.SelectedItem.ToString() == "Custom Range" && this.calendarDateRangePicker2.SelectedRange != null &&  this.calendarDateRangePicker2.SelectedRange.EndDate != null)
            {
                this.calendarDateRangePicker2.SelectedRange = null;
            }
        }

        private void Blackout_ItemPrepared(object sender, Syncfusion.UI.Xaml.Calendar.CalendarItemPreparedEventArgs e)
        {
            if (e.ItemInfo.ItemType == CalendarItemType.Day &&
                (e.ItemInfo.Date.DayOfWeek == DayOfWeek.Saturday ||
                e.ItemInfo.Date.DayOfWeek == DayOfWeek.Sunday))
            {
                e.ItemInfo.IsBlackout = true;
            }
        }

        private void calendarDateRangePicker2_SelectedDateRangeChanged(object sender, SelectedDateRangeChangedEventArgs e)
        {
            if (listBox != null && ((e.RangeStartNewValue != null && e.RangeEndNewValue == null) || (e.RangeStartOldValue != null && e.RangeEndOldValue != null && e.RangeEndNewValue == null)))
            {
                listBox.SelectedIndex = 4;
            }
        }

        private DayOfWeek GetFirstDayOfWeek(FirstDayOfWeek firstDayOfWeek)
        {
            switch (firstDayOfWeek)
            {
                case FirstDayOfWeek.Sunday:
                    return DayOfWeek.Sunday;
                case FirstDayOfWeek.Monday:
                    return DayOfWeek.Monday;
                case FirstDayOfWeek.Tuesday:
                    return DayOfWeek.Tuesday;
                case FirstDayOfWeek.Wednesday:
                    return DayOfWeek.Wednesday;
                case FirstDayOfWeek.Thursday:
                    return DayOfWeek.Thursday;
                case FirstDayOfWeek.Friday:
                    return DayOfWeek.Friday;
                case FirstDayOfWeek.Saturday:
                    return DayOfWeek.Saturday;
                default:
                    return CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            }
        }

    }
}
