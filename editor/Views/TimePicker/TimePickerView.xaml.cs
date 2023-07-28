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

namespace Syncfusion.EditorDemos.WinUI.Views.TimePicker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TimePickerView : Page, IDisposable
    {
        public TimePickerView()
        {
            this.InitializeComponent();
            this.timePickerViewPanel.PointerPressed += OnTimePickerViewPanelPointerPressed;
        }

        private void OnTimePickerViewPanelPointerPressed(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            // To restrict the focus on first control when clicking on empty area.
            e.Handled = true;
        }

        private void languages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedLang = languages.SelectedValue.ToString();
            if (Windows.Globalization.Language.IsWellFormed(selectedLang))
            {
                timePicker2.Language = selectedLang;
            }
        }

        /// <summary>
        /// To dispose objects.
        /// </summary>
        public void Dispose()
        {
            if (this.timePicker1 != null)
            {
                this.timePicker1.Dispose();
                this.timePicker1 = null;
            }

            if (this.timePicker2 != null)
            {
                this.timePicker2.Dispose();
                this.timePicker2 = null;
            }

            if (this.timePicker3 != null)
            {
                this.timePicker3.Dispose();
                this.timePicker3 = null;
            }

            if (this.timePicker4 != null)
            {
                this.timePicker4.Dispose();
                this.timePicker4 = null;
            }

            if (this.MinimumTimePicker != null)
            {
                this.MinimumTimePicker.Dispose();
                this.MinimumTimePicker = null;
            }

            if (this.MaximumTimePicker != null)
            {
                this.MaximumTimePicker.Dispose();
                this.MaximumTimePicker = null;
            }
            
            if (this.timePickerViewPanel != null)
            {
                this.timePickerViewPanel.PointerPressed += OnTimePickerViewPanelPointerPressed;
                this.timePickerViewPanel = null;
            }
        }
    }
}
