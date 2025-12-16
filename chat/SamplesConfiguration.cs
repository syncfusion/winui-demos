#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.DemosCommon.WinUI;
using System;
using System.Collections.Generic;

namespace Syncfusion.ChatDemos.WinUI
{
    public class SamplesConfiguration
    {
        public SamplesConfiguration()
        {
            DemoInfo chatAIAssistView = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "Chat",
                Description = "This sample demonstrates the default functionality of the AIAssistView component, offering a simple chat interface for communicating with an AI service. ",
                DemoView = typeof(Views.AssistView),
                DemoType = DemoTypes.AISamples | DemoTypes.Updated,
                ShowInfoPanel = false,
            };

            DemoInfo composeView = new DemoInfo()
            {
                Name = "Reservation",
                Category = "Chat",
                Description = "This sample demonstrates a reservation chatbot that provide a user-friendly interface for booking appointments and managing reservations.",
                DemoView = typeof(Views.ComposeView),
                DemoType = DemoTypes.AISamples | DemoTypes.None,
                ShowInfoPanel = false,
            };

            DemoInfo chatAIIntegration = new DemoInfo()
            {
                Name = "Flyout",
                Category = "Chat",
                Description = "This example showcases how to host the AIAssistView in a flyout, seamlessly integrating it into an application while minimizing space usage.",
                DemoView = typeof(Views.Overview),
                DemoType = DemoTypes.AISamples | DemoTypes.None,
                ShowInfoPanel = false,
            };

            var chat = new ControlInfo()
            {
                Control = DemoControl.SfAIAssistView,
                ControlCategory = ControlCategory.Miscellaneous,
                ControlBadge = ControlBadge.Updated,
                Description = "The Syncfusion® WinUI AIAssistView control offers an adaptable interface for integrating AI-driven assistance directly within your application, enhancing user experience and productivity.",
                Glyph = "\uE728",
                ImageSource = "aiassistview.png",
            };     
            chat.Demos.Add(chatAIAssistView);
            chat.Demos.Add(composeView);
            chat.Demos.Add(chatAIIntegration);
            

            var controlInfo = new List<ControlInfo>()
            {
                chat,
            };
            DemoHelper.ControlInfos.AddRange(controlInfo);
        }
    }
}
