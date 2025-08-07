#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.RadialGaugeDemos.WinUI.Views
{
    using System;
    using System.Globalization;
    using Microsoft.UI.Xaml.Controls;
    using Syncfusion.UI.Xaml.Gauges;
    using Syncfusion.RadialGaugeDemos.WinUI;

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

        private void firstShape_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            this.viewModel.FirstShapeValue = e.Value;
            double value = Math.Abs(this.viewModel.FirstShapeValue - this.viewModel.SecondShapeValue);
            this.CalculateMinutes(value);
        }

        private void firstShape_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            double newValue = e.NewValue;
            if (newValue >= this.secondShape.Value || Math.Abs(newValue - this.firstShape.Value) > 1)
            {
                if (newValue >= this.secondShape.Value)
                {
                    if (Math.Abs(newValue - this.firstShape.Value) > 1)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        this.firstShape.Value = this.secondShape.Value = newValue;
                        this.range.StartValue = this.range.EndValue = newValue;
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }

            this.range.StartValue = this.firstShape.Value;
        }

        private void secondShape_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            this.viewModel.SecondShapeValue = e.Value;
            double value = Math.Abs(this.viewModel.SecondShapeValue - this.viewModel.FirstShapeValue);
            this.CalculateMinutes(value);
        }

        private void secondShape_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            double newValue = e.NewValue;
            if (newValue <= this.firstShape.Value || Math.Abs(newValue - this.secondShape.Value) > 1)
            {
                if (newValue <= this.firstShape.Value)
                {
                    if (Math.Abs(newValue - this.secondShape.Value) > 1)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        this.firstShape.Value = this.secondShape.Value = newValue;
                        this.range.StartValue = this.range.EndValue = newValue;
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }

            this.range.EndValue = this.secondShape.Value;
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

        /// <summary>
        /// To dispose objects.
        /// </summary>
        public void Dispose()
        {
            this.firstShape.ValueChanged -= this.firstShape_ValueChanged;
            this.firstShape.ValueChanging -= this.firstShape_ValueChanging;
            this.secondShape.ValueChanged -= this.secondShape_ValueChanged;
            this.secondShape.ValueChanging -= this.secondShape_ValueChanging;

            this.gauge.Dispose();
            this.DataContext = this.viewModel = null;
        }
    }
}