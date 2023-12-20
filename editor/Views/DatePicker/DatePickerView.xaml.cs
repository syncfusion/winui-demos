#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;
using System;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Syncfusion.EditorDemos.WinUI.Views.DatePicker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DatePickerView : Page, IDisposable
    {
        public DatePickerView()
        {
            this.InitializeComponent();
            this.datePickerViewPanel.PointerPressed += OnDatePickerViewPanelPointerPressed;
        }

        private void OnDatePickerViewPanelPointerPressed(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            // To restrict the focus on first control when clicking on empty area.
            e.Handled = true;
        }

        private void languages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedLang = languages.SelectedValue.ToString();
            if (Windows.Globalization.Language.IsWellFormed(selectedLang))
            {
                datePicker2.Language = selectedLang;
            }
        }

        /// <summary>
        /// To dispose objects.
        /// </summary>
        public void Dispose()
        {
            if (this.datePicker1 != null)
            {
                this.datePicker1.Dispose();
                this.datePicker1 = null;
            }

            if (this.datePicker2 != null)
            {
                this.datePicker2.Dispose();
                this.datePicker2 = null;
            }

            if (this.datePicker3 != null)
            {
                this.datePicker3.Dispose();
                this.datePicker3 = null;
            }

            if (this.datePicker4 != null)
            {
                this.datePicker4.Dispose();
                this.datePicker4 = null;
            }

            if (this.MinimumDatePicker != null)
            {
                this.MinimumDatePicker.Dispose();
                this.MinimumDatePicker = null;
            }

            if (this.MaximumDatePicker != null)
            {
                this.MaximumDatePicker.Dispose();
                this.MaximumDatePicker = null;
            }
            
            if (this.datePickerViewPanel != null)
            {
               this.datePickerViewPanel.PointerPressed -= OnDatePickerViewPanelPointerPressed;
               this.datePickerViewPanel = null;
            }
        }
    }
}
