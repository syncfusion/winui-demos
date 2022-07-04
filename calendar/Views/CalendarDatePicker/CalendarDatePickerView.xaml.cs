#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Microsoft.UI.Xaml.Controls;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Syncfusion.CalendarDemos.WinUI.Views.CalendarDatePicker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CalendarDatePickerView : Page , IDisposable
    {
        public CalendarDatePickerView()
        {
            this.InitializeComponent();
            this.calendarDatePickerViewPanel.PointerPressed += OnCalendarDatePickerViewPanelPointerPressed;
        }

        private void OnCalendarDatePickerViewPanelPointerPressed(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            // To restrict the focus on first control when clicking on empty area.
            e.Handled = true;
        }

        private void languages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedLang = languages.SelectedValue.ToString();
            if (Windows.Globalization.Language.IsWellFormed(selectedLang))
            {
                calendarDatePicker3.Language = selectedLang;
            }
        }

        private async void OnSubmitButtonClick(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            var cd = new ContentDialog
            {
                Title = "Warning!",
                Content = "Enter valid expiry date.",
                CloseButtonText = "Ok"
            };

            if (cardExpiryDate.SelectedDate != null)
            {
                if ((otherAmountButton.IsChecked == true && !double.IsNaN(otherDueAmount.Value)) || otherAmountButton.IsChecked != true)
                {
                    cd.Title = "Due payment Succeed!";
                    cd.Content = "Notification sent to registered email address regarding bill payment.";
                    cardExpiryDate.SelectedDate = null;
                    otherDueAmount.Value = double.NaN;
                }
                else
                {
                    cd.Content = "Enter valid amount.";
                }
            }

            cd.XamlRoot = this.Content.XamlRoot;
            var result = await cd.ShowAsync();
        }
        public void Dispose()
        {
            this.calendarDatePickerViewPanel.PointerPressed -= OnCalendarDatePickerViewPanelPointerPressed;
            if (this.calendarDatePicker1 != null)
            {
                this.calendarDatePicker1.Dispose();
                this.calendarDatePicker1 = null;
            }

            if (this.calendarDatePicker2 != null)
            {
                this.calendarDatePicker2.Dispose();
                this.calendarDatePicker2 = null;
            }

            if (this.calendarDatePicker3 != null)
            {
                this.calendarDatePicker3.Dispose();
                this.calendarDatePicker3 = null;
            }

            if (this.calendarDatePicker4 != null)
            {
                this.calendarDatePicker4.Dispose();
                this.calendarDatePicker4 = null;
            }

            if (this.calendarDatePicker5 != null)
            {
                this.calendarDatePicker5.Dispose();
                this.calendarDatePicker5 = null;
            }

            if (this.cardExpiryDate != null)
            {
                this.cardExpiryDate.Dispose();
                this.cardExpiryDate = null;
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
