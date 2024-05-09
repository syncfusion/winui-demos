#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
    using Syncfusion.UI.Xaml.Gauges;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SleepWatchScore : Page, IDisposable
    {
        public SleepWatchScore()
        {
            this.InitializeComponent();
        }

        private void sleepCalculatorshapePointer_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (e.Value > 430)
            {
                this.sleepCalculatorContentPointer.Foreground = todayRange4.Background;
                this.sleepCalculatorshapePointer.Fill = todayRange4.Background;
            }
            else if (e.Value > 320)
            {
                this.sleepCalculatorContentPointer.Foreground = todayRange3.Background;
                this.sleepCalculatorshapePointer.Fill = todayRange3.Background;
            }
            else if (e.Value > 200)
            {
                this.sleepCalculatorContentPointer.Foreground = todayRange2.Background;
                this.sleepCalculatorshapePointer.Fill = todayRange2.Background;
            }
            else
            {
                this.sleepCalculatorContentPointer.Foreground = todayRange1.Background;
                this.sleepCalculatorshapePointer.Fill = todayRange1.Background;
            }
        }

        private void overallCalculatorshapePointer_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (e.Value > 430)
            {
                this.overallCalculatorContentPointer.Foreground = overallRange4.Background;
                this.overallCalculatorshapePointer.Fill = overallRange4.Background;
            }
            else if (e.Value > 320)
            {
                this.overallCalculatorContentPointer.Foreground = overallRange3.Background;
                this.overallCalculatorshapePointer.Fill = overallRange3.Background;
            }
            else if (e.Value > 200)
            {
                this.overallCalculatorContentPointer.Foreground = overallRange2.Background;
                this.overallCalculatorshapePointer.Fill = overallRange2.Background;
            }
            else
            {
                this.overallCalculatorContentPointer.Foreground = overallRange1.Background;
                this.overallCalculatorshapePointer.Fill = overallRange1.Background;
            }
        }

        /// <summary>
        /// To dispose the events.
        /// </summary>
        public void Dispose()
        {
            this.sleepCalculatorshapePointer.ValueChanged -= this.sleepCalculatorshapePointer_ValueChanged;
            this.overallCalculatorshapePointer.ValueChanged -= this.overallCalculatorshapePointer_ValueChanged;
            this.todayCalculatorGauge.Dispose();
            this.overallCalculatorGauge.Dispose();
        }
    }
}