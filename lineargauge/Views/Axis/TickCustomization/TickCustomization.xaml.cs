#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.LinearGaugeDemos.WinUI.Views
{
    using System;
    using Microsoft.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TickCustomization : Page, IDisposable
    {
        public TickCustomization()
        {
            this.InitializeComponent();
        }

        private void TickPositionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.TickPositionComboBox.SelectedIndex == 2)
            {
                this.TickOffsetSlider.IsEnabled = false;
            }
            else
            {
                this.TickOffsetSlider.IsEnabled = true;
            }
        }

        /// <summary>
        /// To dispose the events.
        /// </summary>
        public void Dispose()
        {
            this.TickPositionComboBox.SelectionChanged -= this.TickPositionComboBox_SelectionChanged;
            this.gauge.Dispose();
        }
    }
}