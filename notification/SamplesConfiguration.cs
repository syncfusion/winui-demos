#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.DemosCommon.WinUI;
using System;
using System.Collections.Generic;

namespace Syncfusion.NotificationDemos.WinUI
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
                DemoView = typeof(Views.Badge.BadgeView),
                ShowInfoPanel = true
            };

            List<Documentation> documentations = new List<Documentation>();
            documentations.Add(new Documentation() { Content = "Badge - API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Notifications.SfBadge.html") });
            documentations.Add(new Documentation() { Content = "Badge - Getting Started", Uri = new Uri("https://help.syncfusion.com/winui/badge/getting-started") });
            documentations.Add(new Documentation() { Content = "Badge - Alignment and Positioning", Uri = new Uri("https://help.syncfusion.com/winui/badge/alignment-positioning") });
            documentations.Add(new Documentation() { Content = "Badge - Custom Alignment and Positioning", Uri = new Uri("https://help.syncfusion.com/winui/badge/alignment-positioning#custom-alignment-and-positioning-of-badge") });
            documentations.Add(new Documentation() { Content = "Badge - Customization", Uri = new Uri("https://help.syncfusion.com/winui/badge/badge-customization") });

            badgeDemo.Documentation.AddRange(documentations);
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
