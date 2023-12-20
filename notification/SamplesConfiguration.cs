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
                Glyph = "\uE706",
                ImageSource = "Badge.png"
            };
            badge.Demos.Add(badgeDemo);

            DemoInfo busyIndicatorDemo = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "BusyIndicator",
                Description = "This sample showcases the basic features such as animation types, duration factor, size factor, busy content, content position and indicator color.",
                DemoView = typeof(Views.BusyIndicator.GettingStartedView),
                ShowInfoPanel = false,
                DemoType = DemoTypes.None
            };


            var busyIndicator = new ControlInfo()
            {
                Control = DemoControl.SfBusyIndicator,
                ControlCategory = ControlCategory.Notification,
                ControlBadge = ControlBadge.None, 
                Description = "The Busy Indicator control is used to display a predefined built-in animation when an operation runs in the background of your application to await completion.",
                Glyph = "\uE723",
                ImageSource= "BusyIndicator.png",
                IsPreview = false,
            };
            busyIndicator.Demos.Add(busyIndicatorDemo);

            var controlInfos = new List<ControlInfo>()
            {
                badge,
                busyIndicator
            };

            DemoHelper.ControlInfos.AddRange(controlInfos);
        }
    }
}
