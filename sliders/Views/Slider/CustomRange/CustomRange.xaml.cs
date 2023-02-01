#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.SliderDemos.WinUI.Views.Slider
{
    using System;
    using Microsoft.UI.Xaml.Controls;
    using Syncfusion.UI.Xaml.Sliders;
    using System.Collections.Generic;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomRange : Page
    {
        public CustomRange()
        {
            this.InitializeComponent();
        }
    }

    public class LogarithmicSlider : SfSlider
    {
        int labelsCount;

        public override List<SliderLabelInfo> GenerateVisibleLabels()
        {
            List<SliderLabelInfo> labelInfos = new List<SliderLabelInfo>();
            int minimum = (int)LogBase(this.Minimum, 10);
            int maximum = (int)LogBase(this.Maximum, 10);
            for (int i = minimum; i <= maximum; i++)
            {
                double value = Math.Floor(Math.Pow(10, i)); // logBase  value is 10
                SliderLabelInfo label = new SliderLabelInfo()
                {
                    Value = value,
                    Text = value.ToString()
                };
                labelInfos.Add(label);
            }

            labelsCount = labelInfos.Count;
            return labelInfos;
        }

        private double LogBase(double value, int baseValue)
        {
            return Math.Log(value) / Math.Log(baseValue);
        }

        public override double ValueToFactor(double value)
        {
            return LogBase(value, 10) / (labelsCount - 1);
        }

        public override double FactorToValue(double factor)
        {
            return Math.Pow(Math.E, factor * (labelsCount - 1) * Math.Log(10));
        }
    }
}