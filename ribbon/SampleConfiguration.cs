#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
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
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.Ribbon.RibbonView),
                ShowInfoPanel = true
            };

            
            List<Documentation> documentations = new List<Documentation>();
            documentations.Add(new Documentation() { Content = "Ribbon - API Reference Documentation", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Ribbon.html") });
            documentations.Add(new Documentation() { Content = "Ribbon - Getting Started Documentation", Uri = new Uri("https://help.syncfusion.com/winui/ribbon/getting-started") });
            
            ribbonDemo.Documentation.AddRange(documentations);

            DemoInfo simplifiedribbonDemo = new DemoInfo()
            {
                Name = "Simplified Ribbon",
                Category = "Ribbon",
                Description = "Ribbon supports the simplified mode with Ribbon items arranged in single row arrangements and some ribbon items are moved to overflow menu.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.Ribbon.SimplifiedRibbonView),
                ShowInfoPanel = true
            };


            List<Documentation> simplifiedribbondocumentations = new List<Documentation>();
            simplifiedribbondocumentations.Add(new Documentation() { Content = "Ribbon - API Reference Documentation", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Ribbon.html") });
            simplifiedribbondocumentations.Add(new Documentation() { Content = "Ribbon - Getting Started Documentation", Uri = new Uri("https://help.syncfusion.com/winui/ribbon/getting-started") });

            simplifiedribbonDemo.Documentation.AddRange(simplifiedribbondocumentations);

            DemoInfo ribbongalleryDemo = new DemoInfo()
            {
                Name = "Ribbon Gallery",
                Category = "Ribbon",
                Description = "RibbonGallery displays the collection of items in a uniform order. It allows you to view items by grouping while the control is expanded.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.Ribbon.RibbonGalleryView),
                ShowInfoPanel = true
            };


            List<Documentation> ribbongallerydocumentations = new List<Documentation>();
            ribbongallerydocumentations.Add(new Documentation() { Content = "Ribbon - API Reference Documentation", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Ribbon.html") });
            ribbongallerydocumentations.Add(new Documentation() { Content = "Ribbon - Getting Started Documentation", Uri = new Uri("https://help.syncfusion.com/winui/ribbon/getting-started") });

            ribbongalleryDemo.Documentation.AddRange(ribbongallerydocumentations);

            var ribbonControlInfo = new ControlInfo()
            {
                Control = DemoControl.SfRibbon,
                ControlBadge = ControlBadge.None,
                ControlCategory = ControlCategory.Navigation,
                Description = "The WinUI Ribbon control supports all the basic features and functionality including Ribbon Tab which contains controls like Button, SplitButton, DropdownButton etc.",
                Glyph = "\uE70f"
            };
            ribbonControlInfo.Demos.Add(ribbonDemo);
            ribbonControlInfo.Demos.Add(simplifiedribbonDemo);
            ribbonControlInfo.Demos.Add(ribbongalleryDemo);

           
            var controlInfos = new List<ControlInfo>()
            {
                ribbonControlInfo
            };

            DemoHelper.ControlInfos.AddRange(controlInfos);
        }
    }
}
