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
    using Microsoft.UI.Xaml.Media;
    using Syncfusion.UI.Xaml.Gauges;
    using Windows.UI;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ThermometerDemo : Page, IDisposable
    {
        public ThermometerDemo()
        {
            this.InitializeComponent();
        }

        private void shapePointer_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (e.Value >= 38)
            {
                this.shapePointer.Fill = new SolidColorBrush(Color.FromArgb(0xff, 0xff, 0x7b, 0x7b));
                this.shapePointer.Stroke = new SolidColorBrush(Color.FromArgb(0xff, 0xff, 0x7b, 0x7b));
                this.barPointer.Background = new SolidColorBrush(Color.FromArgb(0xff, 0xff, 0x7b, 0x7b));
                this.contentPointer.Background = new SolidColorBrush(Color.FromArgb(0xff, 0xff, 0x7b, 0x7b));
            }
            else
            {
                this.shapePointer.Fill = new SolidColorBrush(Color.FromArgb(0xff, 0x21, 0x94, 0xf3));
                this.shapePointer.Stroke = new SolidColorBrush(Color.FromArgb(0xff, 0x21, 0x94, 0xf3));
                this.barPointer.Background = new SolidColorBrush(Color.FromArgb(0xff, 0x21, 0x94, 0xf3));
                this.contentPointer.Background = new SolidColorBrush(Color.FromArgb(0xff, 0x21, 0x94, 0xf3));
            }
        }

        /// <summary>
        /// To dispose the events.
        /// </summary>
        public void Dispose()
        {
            this.shapePointer.ValueChanged -= this.shapePointer_ValueChanged;
            this.gauge1.Dispose();
            this.gauge2.Dispose();
        }
    }
}