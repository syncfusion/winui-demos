#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.Editors;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Syncfusion.EditorDemos.WinUI.Views.TimePicker
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

        private void OnTimeFieldPrepared(object sender, Syncfusion.UI.Xaml.Editors.DateTimeFieldPreparedEventArgs e)
        {
            if (e.Column.Field == DateTimeField.Minute || e.Column.Field == DateTimeField.Second)
            {
                e.Column.ItemsSource = GetMinutesOrSeconds(e.Column.Format);
            }
        }

        /// <summary>
        /// Get the ItemsSource for minute or second column.
        /// </summary>
        /// <returns>Return the ItemsSource for minute or second column.</returns>
        private static ObservableCollection<string> GetMinutesOrSeconds(string pattern)
        {
            ObservableCollection<string> minutes = new ObservableCollection<string>();
            NumberFormatInfo provider = new NumberFormatInfo();
            for (int i = 0; i < 60; i = i + 5)
            {
                if (i > 9 || pattern == "%s" || pattern == "{second.integer}" || pattern == "%m" || pattern == "{minute.integer}")
                {
                    minutes.Add(i.ToString(provider));
                }
                else
                {
                    minutes.Add("0" + i.ToString(provider));
                }
            }

            return minutes;
        }

        /// <summary>
        /// To dispose objects.
        /// </summary>
        public void Dispose()
        {
            if (this.CustomTimePicker != null)
            {
                this.CustomTimePicker.Dispose();
                this.CustomTimePicker = null;
            }

            if (this.CustomItemTemplateTimePicker != null)
            {
                this.CustomItemTemplateTimePicker.Dispose();
                this.CustomItemTemplateTimePicker = null;
            }

            if (this.CustomIntervalTimePicker != null)
            {
                this.CustomIntervalTimePicker.Dispose();
                this.CustomIntervalTimePicker = null;
            }
            
            if (this.customizationViewPanel != null)
            {
                this.customizationViewPanel.PointerPressed -= OnCustomizationViewPanelPointerPressed;
                this.customizationViewPanel = null;
            }
        }
    }
}
