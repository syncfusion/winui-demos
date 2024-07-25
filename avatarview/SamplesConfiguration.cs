#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.DemosCommon.WinUI;
using System;
using System.Collections.Generic;

namespace Syncfusion.AvatarViewDemos.WinUI
{
    public class SamplesConfiguration
    {
        public SamplesConfiguration()
        {
            DemoInfo avatarViewGettingStarted = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "AvatarView",
                Description = "This sample showcases the basic features such as avatar name, content type, initial type, visual styles and background in avatar view control.",
                DemoView = typeof(Views.GettingStartedView),
                DemoType =DemoTypes.None,
                ShowInfoPanel = false,
            };

            DemoInfo avatarGroupView = new DemoInfo()
            {
                Name = "Group View",
                Category = "AvatarView",
                Description = "This sample showcases the various group view representations of avatar view control.",
                DemoView = typeof(Views.GroupView),
                DemoType = DemoTypes.None,
                ShowInfoPanel = false,
            };

            var avatarView = new ControlInfo()
            {
                Control = DemoControl.SfAvatarView,
                ControlCategory = ControlCategory.Miscellaneous,
                ControlBadge = ControlBadge.None,
                Description = "SfAvatarView is a graphical representation of the user image that allows you to customize the view by adding an image, background color, icon, text, etc.",
                Glyph = "\uE726",
                ImageSource = "AvatarView.png",
            };
            avatarView.Demos.Add(avatarViewGettingStarted);
            avatarView.Demos.Add(avatarGroupView);

            var controlInfo = new List<ControlInfo>()
            {
                avatarView,
            };
            DemoHelper.ControlInfos.AddRange(controlInfo);
        }
    }
}
