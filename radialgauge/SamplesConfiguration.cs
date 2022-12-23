#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace Syncfusion.RadialGaugeDemos.WinUI
{
    using Syncfusion.DemosCommon.WinUI;
    using System.Collections.Generic;

    class SamplesConfiguration
    {
        public SamplesConfiguration()
        {
            DemoInfo gettingStartedSample = new DemoInfo()
            {
                Name = "Getting started",
                Description = "This sample explains the steps required for the addition of radial gauge and its elements such as axis, range, pointer and annotation.",
                Category = "Getting started",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.GettingStarted)
            };

            DemoInfo sleepTrackerShowCaseSample = new DemoInfo()
            {
                Name = "Sleep tracker",
                Description = "This sample showcases how to design the sleep tracker view using the free rotation of content pointer and ranges features of radial gauge.",
                Category = "Product Showcase",
                DemoType = DemoTypes.Showcase | DemoTypes.None,
                DemoView = typeof(Views.SleepTracker)
            };

            DemoInfo carDashboardShowCaseSample = new DemoInfo()
            {
                Name = "Car dashboard",
                Description = "This sample showcases how to design the car dashboard view using the various radial gauge features.",
                Category = "Product Showcase",
                DemoType = DemoTypes.Showcase,
                DemoView = typeof(Views.CarDashboard)
            };

            DemoInfo clockShowCaseSample = new DemoInfo()
            {
                Name = "Clock",
                Description = "This sample showcases how to create an analog clock using a radial gauge with different needles and inner dials.",
                Category = "Product Showcase",
                DemoType = DemoTypes.Showcase,
                DemoView = typeof(Views.Clock)
            };

            DemoInfo tempMontiorShowCaseSample = new DemoInfo()
            {
                Name = "Temperature monitor",
                Description = "This sample showcases how to design a temperature monitor using a radial gauge control with various color ranges, a needle pointer and annotations to indicate the current temperature value.",
                Category = "Product Showcase",
                DemoType = DemoTypes.Showcase,
                DemoView = typeof(Views.TempMonitor)
            };

            DemoInfo distanceTrackerShowCaseSample = new DemoInfo()
            {
                Name = "Distance tracker",
                Description = "This sample shows how to design a distance tracker using a radial gauge with a gradient range pointer and annotations.",
                Category = "Product Showcase",
                DemoType = DemoTypes.Showcase | DemoTypes.None,
                DemoView = typeof(Views.DistanceTracker)
            };

            DemoInfo axisCustomScale = new DemoInfo()
            {
                Name = "Custom scale",
                Description = "This sample shows a custom scale of non-linear scale intervals.",
                Category = "Axis",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.CustomScale)
            };

            DemoInfo axisCustomLabels = new DemoInfo()
            {
                Name = "Custom labels",
                Description = "This sample shows the custom label capabilities of the radial gauge using the LabelPrepared event.",
                Category = "Axis",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.CustomLabels)
            };

            DemoInfo defaultView = new DemoInfo()
            {
                Name = "Default view",
                Description = "This sample shows the default axis view of the radial gauge control.",
                Category = "Axis",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.DefaultView)
            };

            DemoInfo axisMultipleAxis = new DemoInfo()
            {
                Name = "Multiple axis",
                Description = "This sample shows the multi-axis capability of the radial gauge control.",
                Category = "Axis",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.MultipleAxis)
            };

            DemoInfo axisLabelCustomization = new DemoInfo()
            {
                Name = "Label customization",
                Description = "This sample shows the customization of the label, such as custom fonts and post fix.",
                Category = "Axis",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.LabelCustomization)
            };

            DemoInfo axisTickCustomization = new DemoInfo()
            {
                Name = "Tick customization",
                Description = "This sample shows the major and minor tick customization of the radial gauge.",
                Category = "Axis",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.TickCustomization)
            };

            DemoInfo axisRangeColorForAxis = new DemoInfo()
            {
                Name = "Range colors for axis",
                Description = "This sample shows how to use the respective range color to the axis elements such as ticks and labels.",
                Category = "Axis",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.RangeColorForAxis)
            };

            DemoInfo axisBackgroundContent = new DemoInfo()
            {
                Name = "Axis background",
                Description = "This sample shows how to design a compass using the radial gauge with a shape pointer, annotations and background content.",
                Category = "Axis",
                DemoView = typeof(Views.BackgroundContent)
            };

            DemoInfo rangePointer = new DemoInfo()
            {
                Name = "Range pointer",
                Description = "This sample shows the addition of a range pointer with a gradient in the radial gauge.",
                Category = "Pointers",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.RangePointer)
            };

            DemoInfo textPointer = new DemoInfo()
            {
                Name = "Content pointer",
                Description = "This sample shows how to add content to display information using the content pointer support.",
                Category = "Pointers",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.TextPointer)
            };

            DemoInfo multipleNeedle = new DemoInfo()
            {
                Name = "Multiple needle",
                Description = "This sample shows the multi-axis and needle pointer capabilities of the radial gauge.",
                Category = "Pointers",
                DemoView = typeof(Views.MultipleNeedle)
            };

            DemoInfo markerPointer = new DemoInfo()
            {
                Name = "Shape pointer",
                Description = "This sample shows the addition of the shape pointer support to the radial gauge.",
                Category = "Pointers",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.MarkerPointer)
            };

            DemoInfo multipleRanges = new DemoInfo()
            {
                Name = "Multiple ranges",
                Description = "This sample shows the multiple range capabilities of the radial gauge control.",
                Category = "Ranges",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.MultipleRanges)
            };

            DemoInfo rangeThickness = new DemoInfo()
            {
                Name = "Range thickness",
                Description = "This sample shows the range start and end width adjustment capabilities of the radial gauge.",
                Category = "Ranges",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.RangeThickness)
            };

            DemoInfo rangelabel = new DemoInfo()
            {
                Name = "Range label",
                Description = "This sample shows the range label capabilities of the radial gauge.",
                Category = "Ranges",
                DemoView = typeof(Views.RangeLabel)
            };

            DemoInfo AnnotationDirectionCompass = new DemoInfo()
            {
                Name = "Direction compass",
                Description = "This sample shows the direction in a compass using the radial gauge annotations support.",
                Category = "Annotation",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.DirectionCompass)
            };

            DemoInfo textAnnotation = new DemoInfo()
            {
                Name = "Text annotation",
                Description = "This sample shows how to add text to the respective position by using an annotation support.",
                Category = "Annotation",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.TextAnnotation)
            };

            DemoInfo tempTracker = new DemoInfo()
            {
                Name = "Image annotation",
                Description = "This sample shows how to add images to different positions using an annotation support.",
                Category = "Annotation",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.TempTracker)
            };

            DemoInfo pointerRangeSlider = new DemoInfo()
            {
                Name = "Radial slider",
                Description = "This sample shows how to create a radial slider using the radial gauge with range pointer, shape pointer and drag interaction support.",
                Category = "Pointer interaction",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.RangeSlider)
            };

            DemoInfo radialRangeSlider = new DemoInfo()
            {
                Name = "Radial range slider",
                Description = "This sample shows how to create a radial range slider using the radial gauge with shape pointer and drag interaction support.",
                Category = "Pointer interaction",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.RadialRangeSlider)
            };

            DemoInfo animationDemo = new DemoInfo()
            {
                Name = "Pointer animation",
                Description = "This sample shows the pointer animation capabilities of the radial gauge control.",
                Category = "Animation",
                DemoView = typeof(Views.Animation)
            };

            List<DemoInfo> demos = new List<DemoInfo>()
            {
                gettingStartedSample,
                sleepTrackerShowCaseSample,
                carDashboardShowCaseSample,
                clockShowCaseSample,
                tempMontiorShowCaseSample,
                distanceTrackerShowCaseSample,
                defaultView,
                axisMultipleAxis,
                axisLabelCustomization,
                axisTickCustomization,
                axisCustomScale,
                axisCustomLabels,
                axisRangeColorForAxis,
                axisBackgroundContent,
                rangePointer,
                multipleNeedle,
                markerPointer,
                textPointer,
                multipleRanges,
                rangeThickness,
                rangelabel,
                AnnotationDirectionCompass,
                textAnnotation,
                tempTracker,
                pointerRangeSlider,
                radialRangeSlider,
                animationDemo
            };

            ControlInfo controlInfo = new ControlInfo()
            {
                Control = DemoControl.SfRadialGauge,
                Description = "The Radial Gauge is a multi-purpose data visualization control to create modern, interactive and animated gauges.",
                ControlCategory = ControlCategory.DataVisualization,
                ControlBadge = ControlBadge.None,
                Glyph = "\ue703",
                ImageSource= "RadialGauge.png"
            };

            controlInfo.Demos.AddRange(demos);
            DemoHelper.ControlInfos.Add(controlInfo);
        }
    }
}