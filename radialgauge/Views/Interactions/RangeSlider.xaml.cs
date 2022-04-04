#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace syncfusion.radialgaugedemos.winui.Views
{
    using System;
    using Microsoft.UI.Xaml.Controls;
    using Syncfusion.UI.Xaml.Gauges;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RangeSlider : Page, IDisposable
    {
        public RangeSlider()
        {
            this.InitializeComponent();
        }

        private void rangePointer_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            if (e.NewValue < 6)
            {
                e.Cancel = true;
            }
        }

        private void rangePointer_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            this.markerPointer.Value = e.Value - 1.5;
        }

        /// <summary>
        /// To dispose objects.
        /// </summary>
        public void Dispose()
        {
            this.rangePointer.ValueChanged -= this.rangePointer_ValueChanged;
            this.rangePointer.ValueChanging -= this.rangePointer_ValueChanging;

#if WinUI_Desktop
            this.gauge.Dispose();
#endif
        }
    }
}