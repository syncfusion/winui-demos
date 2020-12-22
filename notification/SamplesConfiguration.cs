#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.winui;
using System;
using System.Collections.Generic;

namespace syncfusion.notificationdemos.winui
{
    public class SamplesConfiguration
    {
        public SamplesConfiguration()
        {
            DemoInfo badgeDemo = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "Badge",
                Description = "The Badge control is used to notify users about new or unread messages, notifications, or the status of something.",
                DemoView = typeof(Views.Badge.BadgeView)
            };
            badgeDemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "SfBadge - API", Uri = new Uri("https://help.syncfusion.com"), } });

            var badge = new ControlInfo()
            {
                Control = DemoControl.SfBadge,
                ControlCategory = ControlCategory.Notification,
                Description = "The Badge control is used to notify users about new or unread messages, notifications, or the status of something.",
                Glyph = "\uE706"
            };
            badge.Demos.Add(badgeDemo);

            var controlInfos = new List<ControlInfo>()
            {
                badge,
            };

            DemoHelper.ControlInfos.AddRange(controlInfos);
        }
    }
}
