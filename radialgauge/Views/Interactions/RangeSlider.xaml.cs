#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace syncfusion.radialgaugedemos.winui.Views
{
    using Microsoft.UI.Xaml.Controls;
    using Microsoft.UI.Xaml.Data;
    using System;
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

        public void Dispose()
        {
            rangePointer.ValueChanged -= rangePointer_ValueChanged;
            rangePointer.ValueChanging -= rangePointer_ValueChanging;
        }
    }
}