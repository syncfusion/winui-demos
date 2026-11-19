#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
#endregion
using Syncfusion.DemosCommon.WinUI;
using System;
using System.Collections.Generic;

namespace Syncfusion.DockingManagerDemos.WinUI
{
    public class SamplesConfiguration
    {
        public SamplesConfiguration()
        {
            DemoInfo dockingManagerGettingStartedDemo = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "DockingManager",
                Description = "This sample showcases the DockingManager control with basic functionalities.",
                DemoView = typeof(Views.DockingManager.GettingStartedView),
                DemoType = DemoTypes.New
            };

            var dockingManager = new ControlInfo()
            {
                Control = DemoControl.SfDockingManager,
                ControlCategory = ControlCategory.Layout,
                ControlBadge = ControlBadge.New,
                Description = "The WinUI DockingManager control provides an interface to create Visual Studio-like dockable windows in your applications.",
                Glyph = "\uE72b",
                ImageSource = "DockingManager.png",
            };
            dockingManager.Demos.Add(dockingManagerGettingStartedDemo);

            var controlInfos = new List<ControlInfo>()
            {
                dockingManager,
            };
            DemoHelper.ControlInfos.AddRange(controlInfos);
        }
    }
}