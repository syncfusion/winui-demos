#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
                DemoType = DemoTypes.None,
                Description = "This sample demonstrates the capabilities of the Kanban board to display and organize tasks based on their statuses, categories, or priorities. Kanban allows users to manage tasks visually through columns that represent stages in a workflow, enabling easy tracking and updating of task progress.",
                DemoView = typeof(GettingStarted),
                ShowInfoPanel = true
            };

            List<Documentation> gettingstartedDocumentations = new List<Documentation>();
            gettingstartedDocumentations.Add(new Documentation() { Content = "Kanban - API Reference Documentation", Uri = new Uri("https://help.syncfusion.com/cr/winui") });
            gettingstartedDocumentations.Add(new Documentation() { Content = "Kanban - Getting Started Documentation", Uri = new Uri("https://help.syncfusion.com/winui/overview") });

            gettingStarted.Documentation.AddRange(gettingstartedDocumentations);

            DemoInfo customization = new DemoInfo()
            {
                Name = "Customization",
                Category = "Kanban",
                DemoType = DemoTypes.Updated,
                Description = "This Kanban board is designed to organize and track hotel service and delivery tasks through ordered, in-service, and completed stages. It demonstrates Kanban view customization, where a data template was used to customize the display of tasks, enabling clear visual distinctions across the different stages and enhancing task management efficiency.",
                DemoView = typeof(Customization),
                ShowInfoPanel = true
            };

            List<Documentation> customizationDocumentations = new List<Documentation>();
            customizationDocumentations.Add(new Documentation() { Content = "Kanban - API Reference Documentation", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Kanban.SfKanban.html") });
            customizationDocumentations.Add(new Documentation() { Content = "Kanban - Documentation", Uri = new Uri("https://help.syncfusion.com/winui/kanban/cards#card-appearance-customization") });

            customization.Documentation.AddRange(customizationDocumentations);

            DemoInfo swimlane = new DemoInfo()
            {
                Name = "Swimlane",
                Category = "Kanban",
                DemoType = DemoTypes.None,
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
                DemoType = DemoTypes.None,
                Description = "This sample showcases how to perform create, and update operations with the Kanban control. You can add a new card using the button in the properties panel, and update a card by tapping on it to open the details in a dialog.",
                DemoView = typeof(DialogEditing),
                ShowInfoPanel = true
            };

            List<Documentation> dialogEditingDocumentations = new List<Documentation>();
            dialogEditingDocumentations.Add(new Documentation() { Content = "Kanban - API Reference Documentation", Uri = new Uri("https://help.syncfusion.com/cr/winui") });
            dialogEditingDocumentations.Add(new Documentation() { Content = "Kanban - Documentation", Uri = new Uri("https://help.syncfusion.com/winui/overview") });

            dialogEditing.Documentation.AddRange(dialogEditingDocumentations);

            DemoInfo sorting = new DemoInfo()
            {
                Name = "Sorting",
                Category = "Kanban",
                DemoType = DemoTypes.New,
                Description = "This sample showcases the sorting behavior of the Kanban board using the sort by, custom field, and sort order properties. It supports sorting by item source order, index, or custom field mapping, allowing cards to be arranged and repositioned dynamically or based on predefined values. The sort order property controls whether cards are aligned in ascending or descending order.",
                DemoView = typeof(Sorting),
                ShowInfoPanel = true
            };

            List<Documentation> sortingDocumentations = new List<Documentation>();
            sortingDocumentations.Add(new Documentation() { Content = "Kanban - API Reference Documentation", Uri = new Uri("https://help.syncfusion.com/cr/winui") });
            sortingDocumentations.Add(new Documentation() { Content = "Kanban - Documentation", Uri = new Uri("https://help.syncfusion.com/winui/overview") });

            sorting.Documentation.AddRange(sortingDocumentations);

            var demos = new List<DemoInfo>()
            {
                gettingStarted,
                customization,
                swimlane,
                dialogEditing,
                sorting,
            };

            var controlInfo = new ControlInfo()
            {
                Control = DemoControl.SfKanban,
                ControlBadge = ControlBadge.Updated,
                ControlCategory = ControlCategory.DataVisualization,
                Description = "The Kanban is a visual component that provides an efficient interface for tracking and visualizing different stages in a workflow or process.",
                Glyph = "\uE700",
                ImageSource = "Kanban.png"
            };

            controlInfo.Demos.AddRange(demos);
            DemoHelper.ControlInfos.Add(controlInfo);
        }
    }
}