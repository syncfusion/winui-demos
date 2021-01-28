#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.sliderdemos.winui
{
    using syncfusion.demoscommon.winui;
    using System.Collections.Generic;

    class SamplesConfiguration
    {
        public SamplesConfiguration()
        {
            #region Slider config

            DemoInfo sliderGettingStartedSample = new DemoInfo()
            {
                Name = "Getting started",
                Description = "This sample explains the steps required for the addition of slider and its elements such as ticks, labels and divisors.",
                Category = "Getting started",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.Slider.GettingStarted)
            };

            DemoInfo sliderCustomScaleSample = new DemoInfo()
            {
                Name = "Logarithmic range",
                Description = "This sample shows the slider's custom range capabilities.",
                Category = "Custom range",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.Slider.CustomRange)
            };

            DemoInfo sliderTrackCustomizationSample = new DemoInfo()
            {
                Name = "Track",
                Description = "This sample shows the track customization capability of slider.",
                Category = "Customization",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.Slider.TrackCustomization)
            };

            DemoInfo sliderThumbCustomizationSample = new DemoInfo()
            {
                Name = "Thumb",
                Description = "This sample shows the thumb customization capability of slider.",
                Category = "Customization",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.Slider.ThumbCustomization)
            };

            DemoInfo sliderTickCustomizationSample = new DemoInfo()
            {
                Name = "Tick",
                Description = "This sample shows the tick customization capability of slider.",
                Category = "Customization",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.Slider.TickCustomization)
            };

            DemoInfo sliderLabelCustomizationSample = new DemoInfo()
            {
                Name = "Label",
                Description = "This sample shows the label customization capability of slider.",
                Category = "Customization",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.Slider.LabelCustomization)
            };

            DemoInfo sliderDivisorCustomizationSample = new DemoInfo()
            {
                Name = "Divisor",
                Description = "This sample shows the divisor customization capability of slider.",
                Category = "Customization",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.Slider.DivisorCustomization)
            };

            DemoInfo sliderToolTipCustomizationSample = new DemoInfo()
            {
                Name = "ToolTip",
                Description = "This sample shows the tooltip customization capability of slider.",
                Category = "Customization",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.Slider.ToolTipCustomization)
            };

            List<DemoInfo> sliderDemos = new List<DemoInfo>()
            {
                sliderGettingStartedSample,
                sliderCustomScaleSample,
                sliderTrackCustomizationSample,
                sliderThumbCustomizationSample,
                sliderTickCustomizationSample,
                sliderLabelCustomizationSample,
                sliderDivisorCustomizationSample,
                sliderToolTipCustomizationSample
            };

            ControlInfo sliderControlInfo = new ControlInfo()
            {
                Control = DemoControl.SfSlider,
                ControlBadge = ControlBadge.New,
                Description = "The Slider is a highly interactive UI control, allowing users to select a single value from a range of values. It provides rich features such as labels, ticks, divisors, thumb, and tooltips.",
                ControlCategory = ControlCategory.Editors,
                Glyph = "\ue70d"
            };

            sliderControlInfo.Demos.AddRange(sliderDemos);
            DemoHelper.ControlInfos.Add(sliderControlInfo);

            #endregion

            #region Range slider config

            DemoInfo rangeSliderGettingStartedSample = new DemoInfo()
            {
                Name = "Getting started",
                Description = "This sample explains the steps required for the addition of range slider and its elements such as ticks, labels and divisors.",
                Category = "Getting started",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.RangeSlider.GettingStarted)
            };

            DemoInfo rangeSliderCustomScaleSample = new DemoInfo()
            {
                Name = "Logarithmic range",
                Description = "This sample shows the slider's custom range capabilities.",
                Category = "Custom range",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.RangeSlider.CustomRange)
            };

            DemoInfo rangeSliderTrackCustomizationSample = new DemoInfo()
            {
                Name = "Track",
                Description = "This sample shows the track customization capability of range slider.",
                Category = "Customization",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.RangeSlider.TrackCustomization)
            };

            DemoInfo rangeSliderThumbCustomizationSample = new DemoInfo()
            {
                Name = "Thumb",
                Description = "This sample shows the thumb customization capability of range slider.",
                Category = "Customization",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.RangeSlider.ThumbCustomization)
            };

            DemoInfo rangeSliderTickCustomizationSample = new DemoInfo()
            {
                Name = "Tick",
                Description = "This sample shows the tick customization capability of range slider.",
                Category = "Customization",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.RangeSlider.TickCustomization)
            };

            DemoInfo rangeSliderLabelCustomizationSample = new DemoInfo()
            {
                Name = "Label",
                Description = "This sample shows the label customization capability of range slider.",
                Category = "Customization",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.RangeSlider.LabelCustomization)
            };

            DemoInfo rangeSliderDivisorCustomizationSample = new DemoInfo()
            {
                Name = "Divisor",
                Description = "This sample shows the divisor customization capability of range slider.",
                Category = "Customization",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.RangeSlider.DivisorCustomization)
            };

            DemoInfo rangeSliderToolTipCustomizationSample = new DemoInfo()
            {
                Name = "ToolTip",
                Description = "This sample shows the tooltip customization capability of range slider.",
                Category = "Customization",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.RangeSlider.ToolTipCustomization)
            };

            List<DemoInfo> rangeSliderDemos = new List<DemoInfo>()
            {
                rangeSliderGettingStartedSample,
                rangeSliderCustomScaleSample,
                rangeSliderTrackCustomizationSample,
                rangeSliderThumbCustomizationSample,
                rangeSliderTickCustomizationSample,
                rangeSliderLabelCustomizationSample,
                rangeSliderDivisorCustomizationSample,
                rangeSliderToolTipCustomizationSample
            };

            ControlInfo rangeSliderControlInfo = new ControlInfo()
            {
                Control = DemoControl.SfRangeSlider,
                ControlBadge = ControlBadge.New,
                Description = "The Range Slider is a highly interactive UI control, allowing users to select a smaller range from a larger data set. It provides rich features such as labels, ticks, divisors, thumb, and tooltips.",
                ControlCategory = ControlCategory.Editors,
                Glyph = "\ue70e"
            };

            rangeSliderControlInfo.Demos.AddRange(rangeSliderDemos);
            DemoHelper.ControlInfos.Add(rangeSliderControlInfo);

            #endregion
        }
    }
}