#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.DemosCommon.WinUI;
using System;
using System.Collections.Generic;

namespace Syncfusion.ShimmerDemos.WinUI
{
    public class SamplesConfiguration
    {
        public SamplesConfiguration()
        {
            DemoInfo shimmerGettingStarted = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "Shimmer",
                Description = "This sample showcases the basic features of shimmer control.",
                DemoView = typeof(Views.GettingStartedView),
                DemoType = DemoTypes.None,
                ShowInfoPanel = false,
            };

            DemoInfo shimmerCustomView = new DemoInfo()
            {
                Name = "Custom Layout",
                Category = "Shimmer",
                Description = "This sample showcases adding custom layout for shimmer effect to load the content.",
                DemoView = typeof(Views.CustomView),
                DemoType = DemoTypes.None,
                ShowInfoPanel = false,
            };

            var shimmer = new ControlInfo()
            {
                Control = DemoControl.SfShimmer,
                ControlCategory = ControlCategory.Miscellaneous,
                ControlBadge = ControlBadge.None,
                Description = "SfShimmer control enhances app responsiveness, displaying a contemporary shimmer effect during background data loading.",
                Glyph = "\uE727",
                ImageSource = "SfShimmer.png",
            };
            shimmer.Demos.Add(shimmerGettingStarted);
            shimmer.Demos.Add(shimmerCustomView);

            var controlInfo = new List<ControlInfo>()
            {
                shimmer,
            };
            DemoHelper.ControlInfos.AddRange(controlInfo);
        }
    }
}
