#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace Syncfusion.LinearGaugeDemos.WinUI
{
    using Syncfusion.DemosCommon.WinUI;
    using System.Collections.Generic;

    class SamplesConfiguration
    {
        public SamplesConfiguration()
        {
            DemoInfo gettingStartedDemo = new DemoInfo()
            {
                Name = "Getting started",
                Description = "This sample explains the steps required for the addition of linear gauge and its elements such as axis, range, and pointer.",
                Category = "Getting started",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.GettingStarted)
            };

            DemoInfo thermometerDemo = new DemoInfo()
            {
                Name = "Thermometer",
                Description = "This sample showcases how to design a thermometer using the linear gauge.",
                Category = "Showcase",
                DemoType = DemoTypes.Showcase | DemoTypes.None,
                DemoView = typeof(Views.ThermometerDemo)
            };

            DemoInfo HeightCalculatorDemo = new DemoInfo()
            {
                Name = "Height calculator",
                Description = "This sample showcases how to design a height calculator using the linear gauge.",
                Category = "Showcase",
                DemoType = DemoTypes.Showcase | DemoTypes.None,
                DemoView = typeof(Views.HeightCalculatorDemo)
            };

            DemoInfo waterLevelIndicatorDemo = new DemoInfo()
            {
                Name = "Water level indicator",
                Description = "This sample showcases how to design a water level indicator using the linear gauge.",
                Category = "Showcase",
                DemoType = DemoTypes.Showcase | DemoTypes.None,
                DemoView = typeof(Views.WaterLevelIndicatorDemo)
            };

            DemoInfo volumeSettingsDemo = new DemoInfo()
            {
                Name = "Volume settings",
                Description = "This sample showcases how to design a volume controller using the linear gauge.",
                Category = "Showcase",
                DemoType = DemoTypes.Showcase | DemoTypes.None,
                DemoView = typeof(Views.VolumeSettingsDemo)
            };

            DemoInfo progressBarDemo = new DemoInfo()
            {
                Name = "Progress bar",
                Description = "This sample showcases how to design a progress bar using the linear gauge.",
                Category = "Showcase",
                DemoType = DemoTypes.Showcase | DemoTypes.None,
                DemoView = typeof(Views.ProgressBarDemo)
            };

            DemoInfo sleepWatchScoreDemo = new DemoInfo()
            {
                Name = "Sleep watch score",
                Description = "This sample showcases how to design a sleep watch using the linear gauge.",
                Category = "Showcase",
                DemoType = DemoTypes.Showcase | DemoTypes.None,
                DemoView = typeof(Views.SleepWatchScore)
            };

            DemoInfo stepsCounterDemo = new DemoInfo()
            {
                Name = "Steps counter",
                Description = "This sample showcases how to design a steps counter using linear gauge.",
                Category = "Showcase",
                DemoType = DemoTypes.Showcase | DemoTypes.None,
                DemoView = typeof(Views.StepsCounter)
            };

            DemoInfo batteryIndicatorDemo = new DemoInfo()
            {
                Name = "Battery indicator",
                Description = "This sample showcases how to design a battery indicator using the linear gauge.",
                Category = "Showcase",
                DemoType = DemoTypes.Showcase | DemoTypes.None,
                DemoView = typeof(Views.BatteryDemo)
            };

            DemoInfo bulletGraphDemo = new DemoInfo()
            {
                Name = "Bullet Chart",
                Description = "This sample shows how to design a bullet graph using linear gauge.",
                Category = "Showcase",
                DemoType = DemoTypes.Showcase | DemoTypes.None,
                DemoView = typeof(Views.BulletGraphDemo)
            };

            DemoInfo defaultAxisDemo = new DemoInfo()
            {
                Name = "Default Axis",
                Description = "This sample shows the default axis view of the linear gauge.",
                Category = "Axis",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.DefaultAxis)
            };

            DemoInfo axisCornerDemo = new DemoInfo()
            {
                Name = "Corner style",
                Description = "This sample shows the corner style customization of the linear axis in linear gauge.",
                Category = "Axis",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.AxisCornerStyle)
            };

            DemoInfo tickCustomizationDemo = new DemoInfo()
            {
                Name = "Tick customization",
                Description = "This sample shows the major and minor tick customization of the linear gauge.",
                Category = "Axis",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.TickCustomization)
            };

            DemoInfo labelCustomizationDemo = new DemoInfo()
            {
                Name = "Label customization",
                Description = "This sample shows the customization of the label, such as custom fonts and post fix.",
                Category = "Axis",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.LabelCustomization)
            };

            DemoInfo textLabelDemo = new DemoInfo()
            {
                Name = "Text label",
                Description = "This sample shows the custom label capabilities of the linear gauge.",
                Category = "Axis",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.TextLabel)
            };

            DemoInfo inversedAxisDemo = new DemoInfo()
            {
                Name = "Inversed axis",
                Description = "This sample shows the inversed support in linear gauge.",
                Category = "Axis",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.InversedAxis)
            };

            DemoInfo verticalAxisDemo = new DemoInfo()
            {
                Name = "Vertical axis",
                Description = "This sample shows the vertical support in linear gauge.",
                Category = "Axis",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.VerticalAxis)
            };

            DemoInfo linearRangeDemo = new DemoInfo()
            {
                Name = "Linear range",
                Description = "This sample shows the range support capabilities of linear gauge.",
                Category = "Range",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.LinearRange)
            };

            DemoInfo multipleRangesDemo = new DemoInfo()
            {
                Name = "Multiple ranges",
                Description = "This sample shows multiple range support and its child capabilities of linear gauge.",
                Category = "Range",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.MultipleRanges)
            };

            DemoInfo useRangeColorForAxisDemo = new DemoInfo()
            {
                Name = "Range colors for axis",
                Description = "This sample shows how to use the respective range color to the axis elements such as ticks and labels in linear gauge.",
                Category = "Range",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.UseRangeColorForAxisDemo)
            };

            DemoInfo verticalRangesDemo = new DemoInfo()
            {
                Name = "Vertical ranges",
                Description = "This sample shows vertical range support capabilities of linear gauge.",
                Category = "Range",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.VerticalRanges)
            };

            DemoInfo barPointerDemo = new DemoInfo()
            {
                Name = "Bar pointer",
                Description = "This sample showcases the linear gauge’s bar pointer feature.",
                Category = "Pointers",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.BarPointer)
            };

            DemoInfo multiplePointersDemo = new DemoInfo()
            {
                Name = "Multiple pointers",
                Description = "This demo shows how to add multiple pointer in linear gauge.",
                Category = "Pointers",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.MultiplePointers)
            };

            DemoInfo contentPointersDemo = new DemoInfo()
            {
                Name = "Custom pointer",
                Description = "This sample shows the capabilities of custom view pointer in linear gauge.",
                Category = "Pointers",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.ContentPointer)
            };

            List<DemoInfo> demos = new List<DemoInfo>()
            {
                gettingStartedDemo,
                thermometerDemo,
                HeightCalculatorDemo,
                waterLevelIndicatorDemo,
                volumeSettingsDemo,
                progressBarDemo,
                sleepWatchScoreDemo,
                stepsCounterDemo,
                batteryIndicatorDemo,
                bulletGraphDemo,
                defaultAxisDemo,
                axisCornerDemo,
                tickCustomizationDemo,
                labelCustomizationDemo,
                textLabelDemo,
                inversedAxisDemo,
                verticalAxisDemo,
                linearRangeDemo,
                multipleRangesDemo,
                useRangeColorForAxisDemo,
                verticalRangesDemo,
                barPointerDemo,
                multiplePointersDemo,
                contentPointersDemo
            };

            ControlInfo controlInfo = new ControlInfo()
            {
                Control = DemoControl.SfLinearGauge,
                Description = "The WinUI Linear Gauge is a data visualization control that can be used to display data on a linear scale in either horizontal or vertical orientation.",
                ControlCategory = ControlCategory.DataVisualization,
                ControlBadge = ControlBadge.None,
                Glyph = "\ue712",
                ImageSource="LinearGauge.png"
            };

            controlInfo.Demos.AddRange(demos);
            DemoHelper.ControlInfos.Add(controlInfo);
        }
    }
}