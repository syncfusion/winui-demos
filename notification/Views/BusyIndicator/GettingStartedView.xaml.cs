#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Syncfusion.UI.Xaml.Notifications;

namespace Syncfusion.NotificationDemos.WinUI.Views.BusyIndicator
{
    public sealed partial class GettingStartedView : Page
    {
        public GettingStartedView()
        {
            this.InitializeComponent();
        }

        private void ContentPositionCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (contentPositionCombo.SelectedIndex)
            {
                case 0:
                    animation1.BusyContentPosition = BusyIndicatorContentPosition.Top;
                    animation2.BusyContentPosition = BusyIndicatorContentPosition.Top;
                    animation3.BusyContentPosition = BusyIndicatorContentPosition.Top;
                    animation4.BusyContentPosition = BusyIndicatorContentPosition.Top;
                    animation5.BusyContentPosition = BusyIndicatorContentPosition.Top;
                    animation6.BusyContentPosition = BusyIndicatorContentPosition.Top;
                    animation7.BusyContentPosition = BusyIndicatorContentPosition.Top;
                    break;
                case 1:
                    animation1.BusyContentPosition = BusyIndicatorContentPosition.Bottom;
                    animation2.BusyContentPosition = BusyIndicatorContentPosition.Bottom;
                    animation3.BusyContentPosition = BusyIndicatorContentPosition.Bottom;
                    animation4.BusyContentPosition = BusyIndicatorContentPosition.Bottom;
                    animation5.BusyContentPosition = BusyIndicatorContentPosition.Bottom;
                    animation6.BusyContentPosition = BusyIndicatorContentPosition.Bottom;
                    animation7.BusyContentPosition = BusyIndicatorContentPosition.Bottom;
                    break;
            }
        }

        private void SizeFactorSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
           animation1.SizeFactor = e.NewValue;
           animation2.SizeFactor = e.NewValue;
           animation3.SizeFactor = e.NewValue;
           animation4.SizeFactor = e.NewValue;
           animation5.SizeFactor = e.NewValue;
           animation6.SizeFactor = e.NewValue;
           animation7.SizeFactor = e.NewValue;
        }

        private void DurationFactorSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            animation1.DurationFactor = e.NewValue;
            animation2.DurationFactor = e.NewValue;
            animation3.DurationFactor = e.NewValue;
            animation4.DurationFactor = e.NewValue;
            animation5.DurationFactor = e.NewValue;
            animation6.DurationFactor = e.NewValue;
            animation7.DurationFactor = e.NewValue;
        }

        private void ColorPicker_ColorChanged(ColorPicker sender, ColorChangedEventArgs args)
        {
            animation1.Color = new SolidColorBrush(args.NewColor);
            animation2.Color = new SolidColorBrush(args.NewColor);
            animation3.Color = new SolidColorBrush(args.NewColor);
            animation4.Color = new SolidColorBrush(args.NewColor);
            animation5.Color = new SolidColorBrush(args.NewColor);
            animation6.Color = new SolidColorBrush(args.NewColor);
            animation7.Color = new SolidColorBrush(args.NewColor);
        }
    }
}
