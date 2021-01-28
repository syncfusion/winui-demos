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
    using Syncfusion.UI.Xaml.Core;
    using Syncfusion.UI.Xaml.Gauges;
    using syncfusion.radialgaugedemos.winui;
    using System;
    using System.Linq;
    using System.Globalization;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RadialRangeSlider : Page, IDisposable
    {
        private RadialRangeSliderViewModel viewModel;
        public RadialRangeSlider()
        {
            this.InitializeComponent();
            this.viewModel = this.DataContext as RadialRangeSliderViewModel;
        }

        private void firstMarker_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            this.viewModel.FirstMarkerValue = e.Value;
            double value = Math.Abs(this.viewModel.FirstMarkerValue - this.viewModel.SecondMarkerValue);
            this.CalculateMinutes(value);
        }

        private void firstMarker_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            double newValue = e.NewValue;
            if (newValue >= this.secondMarker.Value || Math.Abs(newValue - this.firstMarker.Value) > 1)
            {
                if (newValue >= this.secondMarker.Value)
                {
                    if (Math.Abs(newValue - this.firstMarker.Value) > 1)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        this.firstMarker.Value = this.secondMarker.Value = newValue;
                        this.range.StartValue = this.range.EndValue = newValue;
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }

            this.range.StartValue = this.firstMarker.Value;
        }

        private void secondMarker_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            this.viewModel.SecondMarkerValue = e.Value;
            double value = Math.Abs(this.viewModel.SecondMarkerValue - this.viewModel.FirstMarkerValue);
            this.CalculateMinutes(value);
        }

        private void secondMarker_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            double newValue = e.NewValue;
            if (newValue <= this.firstMarker.Value || Math.Abs(newValue - this.secondMarker.Value) > 1)
            {
                if (newValue <= this.firstMarker.Value)
                {
                    if (Math.Abs(newValue - this.secondMarker.Value) > 1)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        this.firstMarker.Value = this.secondMarker.Value = newValue;
                        this.range.StartValue = this.range.EndValue = newValue;
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }

            this.range.EndValue = this.secondMarker.Value;
        }

        private void CalculateMinutes(double value)
        {
            int hour = Convert.ToInt32(Math.Floor(value));
            float digit = hour / 10f;
            bool isHourSingleDigit = digit >= 1 ? false : true;

            var min = Math.Floor((value - hour) * 60);
            digit = (float)min / 10f;
            bool isMinuteSingleDigit = digit >= 1 ? false : true;

            string hourValue = isHourSingleDigit ? "0" + hour : hour.ToString(CultureInfo.CurrentCulture);
            string minutesValue = isMinuteSingleDigit ? "0" + min : min.ToString(CultureInfo.CurrentCulture);
            this.viewModel.AnnotationString = hourValue + "hr " + minutesValue + "min";
        }

        public void Dispose()
        {
            firstMarker.ValueChanged -= firstMarker_ValueChanged;
            firstMarker.ValueChanging -= firstMarker_ValueChanging;
            secondMarker.ValueChanged -= secondMarker_ValueChanged;
            secondMarker.ValueChanging -= secondMarker_ValueChanging;
        }
    }
}