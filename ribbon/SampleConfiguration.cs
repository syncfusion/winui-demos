#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.DemosCommon.WinUI;

namespace Syncfusion.RibbonDemos.WinUI
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
                Description = "Ribbon gallery displays the collection of items in a uniform order. It allows you to view items by grouping while the control is expanded.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.Ribbon.RibbonGalleryView),
                ShowInfoPanel = true
            }; 

            List<Documentation> ribbongallerydocumentations = new List<Documentation>();
            ribbongallerydocumentations.Add(new Documentation() { Content = "Ribbon - API Reference Documentation", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Ribbon.html") });
            ribbongallerydocumentations.Add(new Documentation() { Content = "Ribbon - Getting Started Documentation", Uri = new Uri("https://help.syncfusion.com/winui/ribbon/getting-started") });

            ribbongalleryDemo.Documentation.AddRange(ribbongallerydocumentations);

            DemoInfo ribbonKeyTipDemo = new DemoInfo()
            {
                Name = "KeyTip",
                Category = "Ribbon",
                Description = "Ribbon supports key tips, which are shortcut key combinations that activate controls. They are also known as access keys or accelerators. When you press the Alt key, key tips appear on the Ribbon.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.Ribbon.RibbonKeyTip),
                ShowInfoPanel = false
            };

            DemoInfo tabgroupviewDemo = new DemoInfo()
            {
                Name = "Contextual Tab Group",
                Category = "Ribbon",
                Description = "Contextual tab groups are used to group the Ribbon tabs for easier navigation. The contextual tab groups appear when a user enables their context.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.Ribbon.ContextualTabGroupView),
                ShowInfoPanel = false
            };

            DemoInfo ribbonResizeViewDemo = new DemoInfo()
            {
                Name = "Resizing",
                Category = "Ribbon",
                Description = "Resize the ribbon items to fit into the available size.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.Ribbon.RibbonResizeView),
                ShowInfoPanel = false
            };

            DemoInfo ribbonCompactSize = new DemoInfo()
            {
                Name = "Compact Sizing",
                Category = "Ribbon",
                Description = "Compact size allows for dense, information-rich ribbon control groups that are primarily intended to handle pointer input.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.Ribbon.RibbonCompactSize),
                ShowInfoPanel = true
            };

            List<Documentation> ribboncompactsizedocumentations = new List<Documentation>();
            ribboncompactsizedocumentations.Add(new Documentation() { Content = "Ribbon - API Reference Documentation", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Ribbon.html") });
            ribboncompactsizedocumentations.Add(new Documentation() { Content = "Compact Sizing Documentation", Uri = new Uri("https://help.syncfusion.com/winui/common/compact-sizing") });

            ribbonCompactSize.Documentation.AddRange(ribboncompactsizedocumentations);

            DemoInfo ribbonScreenTip = new DemoInfo()
            {
                Name = "ScreenTip",
                Category = "Ribbon",
                Description = "Ribbon supports screen tip, it shows a pop-up window when the pointer hovers over a ribbon item to provide details about the ribbon item's function.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.Ribbon.ScreenTip),
                ShowInfoPanel = false
            };

            DemoInfo ribbonQAT = new DemoInfo()
            {
                Name = "Quick Access Toolbar",
                Category = "Ribbon",
                Description = "The Ribbon control allows you to render a set of ribbon items that are commonly used in applications at the top-left corner of a ribbon or window to make it more accessible.",
                DemoType = DemoTypes.Updated,
                DemoView = typeof(Views.Ribbon.RibbonQAT),
                ShowInfoPanel = false
            };

            var ribbonControlInfo = new ControlInfo()
            {
                Control = DemoControl.SfRibbon,
                ControlBadge = ControlBadge.None,
                ControlCategory = ControlCategory.Navigation,
                Description = "The WinUI Ribbon control supports all the basic features and functionality including Ribbon Tab which contains controls like Button, SplitButton, DropdownButton etc.",
                Glyph = "\uE70f",
                ImageSource = "Ribbon.png"
            };

            ribbonControlInfo.Demos.Add(ribbonDemo);
            ribbonControlInfo.Demos.Add(simplifiedribbonDemo);
            ribbonControlInfo.Demos.Add(ribbongalleryDemo);
            ribbonControlInfo.Demos.Add(ribbonKeyTipDemo);
            ribbonControlInfo.Demos.Add(tabgroupviewDemo);
            ribbonControlInfo.Demos.Add(ribbonResizeViewDemo);
            ribbonControlInfo.Demos.Add(ribbonCompactSize);
            ribbonControlInfo.Demos.Add(ribbonScreenTip);
            ribbonControlInfo.Demos.Add(ribbonQAT);

            var controlInfos = new List<ControlInfo>()
            {
                ribbonControlInfo
            };

            DemoHelper.ControlInfos.AddRange(controlInfos);
        }
    }
}
