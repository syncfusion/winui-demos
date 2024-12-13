#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Syncfusion.KanbanDemos.WinUI
{
    using System;
    using System.Collections.Generic;
    using Syncfusion.DemosCommon.WinUI;

    public class SamplesConfiguration
    {
        public SamplesConfiguration()
        {
            DemoInfo gettingStarted = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "Kanban",
                DemoType = DemoTypes.New,
                Description = "This sample demonstrates the capabilities of the Kanban board to display and organize tasks based on their statuses, categories, or priorities. Kanban allows users to manage tasks visually through columns that represent stages in a workflow, enabling easy tracking and updating of task progress.",
                DemoView = typeof(GettingStarted),
                ShowInfoPanel = true
            };

            List<Documentation> gettingstartedDocumentations = new List<Documentation>();
            gettingstartedDocumentations.Add(new Documentation() { Content = "Kanban - API Reference Documentation", Uri = new Uri("https://help.syncfusion.com/cr/winui") });
            gettingstartedDocumentations.Add(new Documentation() { Content = "Kanban - Getting Started Documentation", Uri = new Uri("https://help.syncfusion.com/winui/overview") });

            gettingStarted.Documentation.AddRange(gettingstartedDocumentations);

            DemoInfo swimlane = new DemoInfo()
            {
                Name = "Swimlane",
                Category = "Kanban",
                DemoType = DemoTypes.New,
                Description = "This example demonstrates the swimlane functionality of the Kanban control, allowing for drag-and-drop task management across swimlanes. You can expand or collapse swimlane rows, flexibly categorizing your workflow by projects, teams, users, or other criteria, so you can keep tasks organized and workflows visible.",
                DemoView = typeof(Swimlane),
                ShowInfoPanel = true
            };

            List<Documentation> swimlaneDocumentations = new List<Documentation>();
            swimlaneDocumentations.Add(new Documentation() { Content = "Kanban - API Reference Documentation", Uri = new Uri("https://help.syncfusion.com/cr/winui") });
            swimlaneDocumentations.Add(new Documentation() { Content = "Kanban - Documentation", Uri = new Uri("https://help.syncfusion.com/winui/overview") });

            swimlane.Documentation.AddRange(swimlaneDocumentations);

            DemoInfo dialogEditing = new DemoInfo()
            {
                Name = "Dialog Editing",
                Category = "Kanban",
                DemoType = DemoTypes.New,
                Description = "This sample showcases the create, read and update operations of the Kanban control. You can add a new card using the button in the properties panel and read or update a card by opening the card details in a dialog.",
                DemoView = typeof(DialogEditing),
                ShowInfoPanel = true
            };

            List<Documentation> dialogEditingDocumentations = new List<Documentation>();
            dialogEditingDocumentations.Add(new Documentation() { Content = "Kanban - API Reference Documentation", Uri = new Uri("https://help.syncfusion.com/cr/winui") });
            dialogEditingDocumentations.Add(new Documentation() { Content = "Kanban - Documentation", Uri = new Uri("https://help.syncfusion.com/winui/overview") });

            dialogEditing.Documentation.AddRange(dialogEditingDocumentations);

            var demos = new List<DemoInfo>()
            {
                gettingStarted,
                swimlane,
                dialogEditing,
            };

            var controlInfo = new ControlInfo()
            {
                Control = DemoControl.SfKanban,
                ControlBadge = ControlBadge.New,
                ControlCategory = ControlCategory.DataVisualization,
                IsPreview = true,
                Description = "The Kanban is a visual component that provides an efficient interface for tracking and visualizing different stages in a workflow or process.",
                Glyph = "\uE700",
                ImageSource = "Kanban.png"
            };

            controlInfo.Demos.AddRange(demos);
            DemoHelper.ControlInfos.Add(controlInfo);
        }
    }
}