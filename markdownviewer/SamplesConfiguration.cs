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

namespace Syncfusion.MarkdownViewerDemos.WinUI
{
    public class SamplesConfiguration
    {
        public SamplesConfiguration()
        {
            DemoInfo markdownViewer = new DemoInfo()
            {
                Name = "Overview",
                Category = "MarkdownViewer",
                Description = "This sample demonstrates the basic features of the MarkdownViewer control, showcasing common markdown elements such as headings, paragraphs, links, lists, and code blocks.",
                DemoView = typeof(Views.Overview),
                DemoType = DemoTypes.New | DemoTypes.None,
                ShowInfoPanel = false,
            };

            DemoInfo customization = new DemoInfo()
            {
                Name = "Customization",
                Category = "MarkdownViewer",
                Description = "This sample demonstrates how to customize the appearance of the MarkdownViewer control. It showcases styling options such as font customization, color themes, and layout adjustments to match the application's visual design.",
                DemoView = typeof(Views.Customization),
                DemoType = DemoTypes.New | DemoTypes.None,
                ShowInfoPanel = false,
            };

            var SfMarkdownViewer = new ControlInfo()
            {
                Control = DemoControl.MarkdownViewer,
                ControlCategory = ControlCategory.Miscellaneous,
                ControlBadge = ControlBadge.New,
                Description = "The Syncfusion® WinUI MarkdownViewer control is used to render and preview Markdown files. It converts markdown syntax into a clean, readable format and supports elements such as headings, lists, code blocks, tables, and other common markdown structures.",
                Glyph = "\uE72a",
                ImageSource = "MarkdownViewer.png"
            };     
            SfMarkdownViewer.Demos.Add(markdownViewer);
            SfMarkdownViewer.Demos.Add(customization);
            

            var controlInfo = new List<ControlInfo>()
            {
                SfMarkdownViewer,
            };
            DemoHelper.ControlInfos.AddRange(controlInfo);
        }
    }
}
