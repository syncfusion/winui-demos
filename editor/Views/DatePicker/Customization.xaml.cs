#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.Editors;
using System;
using System.Collections.Generic;
using System.Linq;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Syncfusion.EditorDemos.WinUI.Views.DatePicker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Customization : Page, IDisposable
    {
        public Customization()
        {
            this.InitializeComponent();
            DepartDatePicker.MinDate = DateTimeOffset.Now.Date;
            DepartDatePicker.MaxDate = DateTimeOffset.Now.AddYears(1);
            ReturnDatePicker.MinDate = DateTimeOffset.Now.Date;
            ReturnDatePicker.MaxDate = DateTimeOffset.Now.AddYears(1);
            this.customizationViewPanel.PointerPressed += OnCustomizationViewPanelPointerPressed;
        }

        private void OnCustomizationViewPanelPointerPressed(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            // To restrict the focus on first control when clicking on empty area.
            e.Handled = true;
        }

        /// <summary>
        /// Helps to set the custom format and ItemTemplate for day column using DateFieldPrepared event of <see cref="DateTimeSpinnerBase"/>.
        /// </summary>
        private void OnDateFieldPrepared(object sender, Syncfusion.UI.Xaml.Editors.DateTimeFieldPreparedEventArgs e)
        {
            if (e.Column != null && e.Column.Field == Syncfusion.UI.Xaml.Editors.DateTimeField.Day)
            {
                e.Column.Format = "ddd dd";
                e.Column.ItemTemplate = this.Resources["CustomFormatTemplate"] as DataTemplate;
            }
        }

        /// <summary>
        /// Helps to set the custom ItemTemplate for Blackout dates using DateFieldPrepared event of <see cref="DateTimeSpinnerBase"/>.
        /// </summary>
        private void OnDateFieldItemPrepared(object sender, Syncfusion.UI.Xaml.Editors.DateTimeFieldItemPreparedEventArgs e)
        {
            if (this.BlackoutPicker == null)
            {
                return;
            }

            var blackoutDates = this.BlackoutPicker.BlackoutDates;
            if (blackoutDates != null && e.ItemInfo != null && e.ItemInfo.Field == Syncfusion.UI.Xaml.Editors.DateTimeField.Day &&
                e.ItemInfo.DateTime != null &&  blackoutDates.Any() && blackoutDates.Contains(e.ItemInfo.DateTime.Value.Date))
            {
                e.Element.ContentTemplate = this.Resources["BlackoutWeekendTemplate"] as DataTemplate;
            }
        }


        /// <summary>
        /// Helps to update the ItemsSource of Day column by excluding weekend days using DateFieldPrepared event of <see cref="DateTimeSpinnerBase"/>.
        /// </summary>
        private void ExcludeWeekEndDatesOnDateFieldPrepared(object sender, Syncfusion.UI.Xaml.Editors.DateTimeFieldPreparedEventArgs e)
        {
            var spinnerBase = sender as DateTimeSpinnerBase;
            if (e.Column != null && spinnerBase.SelectedDateTime != null && e.Column.Field == Syncfusion.UI.Xaml.Editors.DateTimeField.Day)
            {
                e.Column.Format = "ddd dd";
                e.Column.ItemsSource = this.RemoveWeekendItems(spinnerBase.SelectedDateTime, e.Column);
            }
        }

        /// <summary>
        /// Helps to update the ItemsSource of Day column by excluding weekend days.
        /// </summary>
        /// <param name="Date">The SelectedDateTime value of DateTimeSpinnerBase.</param>
        /// <param name="column">The day column.</param>
        /// <returns>The day column ItemsSource.</returns>
        private IEnumerable<object> RemoveWeekendItems(System.DateTimeOffset? Date, SpinnerColumn column)
        {
            var itemsSource = new List<object>();
            foreach(var item in column.ItemsSource)
            {
                int day = int.Parse(item.ToString());
                if (day <= DateTime.DaysInMonth(Date.Value.Year, Date.Value.Month))
                {
                    var dateTime = new DateTime(Date.Value.Year, Date.Value.Month, day);
                    if (dateTime.DayOfWeek != DayOfWeek.Saturday && dateTime.DayOfWeek != DayOfWeek.Sunday)
                    {
                        itemsSource.Add(item);
                    }
                }
            }

            return itemsSource;
        }

        /// <summary>
        /// Helps to update the style for weekend dates using DateFieldItemPrepared event Of <see cref="DateTimeSpinnerBase"/>.
        /// </summary>
        /// <param name="sender">The DateTimeSpinnerBase.</param>
        /// <param name="e">The DateTimeFieldItemPreparedEventArgs.</param>
        private void StyleWeekEndDatesOnDateFieldItemPrepared(object sender, DateTimeFieldItemPreparedEventArgs e)
        {
            if (e.ItemInfo.Field == DateTimeField.Day)
            {
                var dateTime = (sender as DateTimeSpinnerBase).SelectedDateTime;
                if (dateTime.Value.Date != e.ItemInfo.DateTime.Value.Date && (e.ItemInfo.DateTime.Value.DayOfWeek == DayOfWeek.Saturday || e.ItemInfo.DateTime.Value.DayOfWeek == DayOfWeek.Sunday))
                {
                    e.Element.Style = this.Resources["SpinnerItemStyle"] as Style;
                    e.ItemInfo.DisplayText = e.ItemInfo.DateTime.Value.ToString("ddd dd", System.Globalization.CultureInfo.CurrentUICulture);
                }
            }
        }


        /// <summary>
        /// Invoked when clicking book button in Style and template demo.
        /// </summary>
        private async void OnButtonClick(object sender, RoutedEventArgs e)
        {
            var cd = new ContentDialog
            {
                Title = "Warning!",
                Content = "Enter valid input.",
                CloseButtonText = "OK"
            };

            if (((oneWayRadioButton.IsChecked == true && DepartDatePicker.SelectedDate != null) || (roundTripRadioButton.IsChecked == true && ReturnDatePicker.SelectedDate != null)) &&
                DepartComboBox.SelectedItem != null && DropOffComboBox.SelectedItem != null && passengers.Value > 0 && EstimatedCostNumberBox.Value > 0)
            {
                cd.Title = "Thank you for booking!";
                cd.Content = "Notification sent to registered email address regarding payment and flight details.";
            }

            cd.XamlRoot = this.Content.XamlRoot;
            var result = await cd.ShowAsync();
        }

        /// <summary>
        /// Helps to estimate the cost based on passengers.
        /// </summary>
        private void OnDateChanged(object sender, SelectedDateTimeChangedEventArgs e)
        {
            if (DepartDatePicker.SelectedDate != null && ReturnDatePicker.SelectedDate != null &&
                ReturnDatePicker.SelectedDate < DepartDatePicker.SelectedDate)
            {
                ReturnDatePicker.SelectedDate = DepartDatePicker.SelectedDate;
                ReturnDatePicker.MinDate = DepartDatePicker.SelectedDate.Value;
            }

            this.UpdateEstimatedCost();
        }

        /// <summary>
        /// Called when radio button is checked.
        /// </summary>
        private void OneWayRadioButtonChecked(object sender, RoutedEventArgs e)
        {
            if (ReturnDatePicker != null)
            {
                if (ReturnDatePicker.SelectedDate != null)
                {
                    ReturnDatePicker.SelectedDate = null;
                }

                if (this.ReturnDatePicker.IsEnabled)
                {
                    this.ReturnDatePicker.IsEnabled = false;
                }
            }

            this.UpdateEstimatedCost();
        }

        /// <summary>
        /// Called when ComboBox selection is changed.
        /// </summary>
        private void OnComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.UpdateEstimatedCost();
        }

        private void OnNumberBoxValueChanged(Microsoft.UI.Xaml.Controls.NumberBox sender, NumberBoxValueChangedEventArgs args)
        {
            this.UpdateEstimatedCost();
        }

        /// <summary>
        /// Called when radio button is checked.
        /// </summary>
        private void OnRoundTripRadioButtonChecked(object sender, RoutedEventArgs e)
        {
            if (!this.ReturnDatePicker.IsEnabled)
            {
                this.ReturnDatePicker.IsEnabled = true;
            }

            this.UpdateEstimatedCost();
        }

        /// <summary>
        /// Helps to update the estimated cost value based on trip selected and entered details while booking flight ticket.
        /// </summary>
        private void UpdateEstimatedCost()
        {
            if (((oneWayRadioButton?.IsChecked == true && DepartDatePicker?.SelectedDate != null) || 
                 (roundTripRadioButton?.IsChecked == true && DepartDatePicker?.SelectedDate != null && ReturnDatePicker?.SelectedDate != null)) &&
                 DepartComboBox?.SelectedItem != null && DropOffComboBox?.SelectedItem != null)
            {
                EstimatedCostNumberBox.Value = oneWayRadioButton.IsChecked == true ? passengers.Value * 5000 : passengers.Value * 10000;
            }
        }

        /// <summary>
        /// Helps to handle key down functionality of NumberBox, since NumberBox does not have read only property.
        /// </summary>
        private void OnNumberBoxPreviewKeyDown(object sender, Microsoft.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            e.Handled = true;
        }

        /// <summary>
        /// To dispose objects.
        /// </summary>
        public void Dispose()
        {
            if (this.DepartDatePicker != null)
            {
                this.DepartDatePicker.Dispose();
                this.DepartDatePicker = null;
            }

            if (this.ReturnDatePicker != null)
            {
                this.ReturnDatePicker.Dispose();
                this.ReturnDatePicker = null;
            }

            if (this.CustomDatePicker != null)
            {
                this.CustomDatePicker.Dispose();
                this.CustomDatePicker = null;
            }

            if (this.CustomDropDownDatePicker != null)
            {
                this.CustomDropDownDatePicker.Dispose();
                this.CustomDropDownDatePicker = null;
            }

            if (this.CustomItemTemplateDatePicker != null)
            {
                this.CustomItemTemplateDatePicker.Dispose();
                this.CustomItemTemplateDatePicker = null;
            }

            if (this.BlackoutPicker != null)
            {
                this.BlackoutPicker.Dispose();
                this.BlackoutPicker = null;
            }

            if (this.CustomStylePicker != null)
            {
                this.CustomStylePicker.Dispose();
                this.CustomStylePicker = null;
            }

            if (this.customizationViewPanel != null)
            {
                this.customizationViewPanel.PointerPressed -= OnCustomizationViewPanelPointerPressed;
                this.customizationViewPanel = null;
            }            
        }
    }
}
