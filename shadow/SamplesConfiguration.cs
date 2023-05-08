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

namespace Syncfusion.ShadowDemos.WinUI
{
    public class SamplesConfiguration
    {
        public SamplesConfiguration()
        {
            DemoInfo shadowDemo = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "Shadow",
                Description = "Shadow control is used to apply the shadow effects to any framework element to display with a beautiful and attractive UI.",
                DemoView = typeof(Views.Shadow.ShadowView),
                DemoType = DemoTypes.None,
                ShowInfoPanel = false,
            };

            var shadow = new ControlInfo()
            {
                Control = DemoControl.SfShadow,
                ControlCategory = ControlCategory.Miscellaneous,
                ControlBadge = ControlBadge.None,
                Description = "Shadow control is used to apply the shadow effects to any framework element to display with a beautiful and attractive UI.",
                Glyph = "\ue722",
                ImageSource = "Shadow.png",
                IsPreview = true,   
            };
            shadow.Demos.Add(shadowDemo);

            var controlInfos = new List<ControlInfo>()
            {
                shadow,
            };

            DemoHelper.ControlInfos.AddRange(controlInfos);
        }
    }
}
