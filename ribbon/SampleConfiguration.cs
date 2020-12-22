#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using syncfusion.demoscommon.winui;

namespace syncfusion.ribbondemos.winui
{
    public class SamplesConfiguration
    {
        public SamplesConfiguration()
        {
            DemoInfo ribbonDemo = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "Ribbon",
                Description = "The WinUI Ribbon control supports all the basic features and functionality including Ribbon Tab which contains controls like Button, SplitButton, DropdownButton etc.",
                DemoType = DemoTypes.New,
                DemoView = typeof(Views.Ribbon.RibbonView)
            };
            ribbonDemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "Ribbon - API", Uri = new Uri("https://help.syncfusion.com") } });

           
            var ribbonControlInfo = new ControlInfo()
            {
                Control = DemoControl.SfRibbon,
                ControlBadge = ControlBadge.New,
                ControlCategory = ControlCategory.Navigation,
                Description = "The WinUI Ribbon control supports all the basic features and functionality including Ribbon Tab which contains controls like Button, SplitButton, DropdownButton etc.",
                Glyph = "\uE70f"
            };
            ribbonControlInfo.Demos.Add(ribbonDemo);

           
            var controlInfos = new List<ControlInfo>()
            {
                ribbonControlInfo
            };

            DemoHelper.ControlInfos.AddRange(controlInfos);
        }
    }
}
