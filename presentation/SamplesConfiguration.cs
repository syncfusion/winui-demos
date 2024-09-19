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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syncfusion.PresentationDemos.WinUI
{
    public class SamplesConfiguration
    {
        public SamplesConfiguration()
        {
            DemoInfo helloWorld = new()
            {
                Name = "Hello World",
                Category = "Getting Started",
                DemoType = DemoTypes.None,
                Description = "This example demonstrates how to create a slide with text in a PowerPoint presentation file.",
                DemoView = typeof(EssentialPresentation.HelloWorld),
                ShowInfoPanel = true
            };
            List<Documentation> selectionDocumentations = new()
            {
                new Documentation() { Content = "PowerPoint library -  Getting started", Uri = new Uri("https://help.syncfusion.com/file-formats/presentation/getting-started") }
            };
            helloWorld.Documentation.AddRange(selectionDocumentations);

            DemoInfo pptxToImage = new()
            {
                Name = "PPTX To Image",
                Category = "Conversions",
                Description = "This example demonstrates how to convert a PowerPoint slide to an image.",
                DemoView = typeof(EssentialPresentation.PPTXToImage),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "PowerPoint library -  PPTX to Image conversion", Uri = new Uri("https://help.syncfusion.com/file-formats/presentation/presentation-to-image") }
            };
            pptxToImage.Documentation.AddRange(selectionDocumentations);

            DemoInfo pptxToPDF = new()
            {
                Name = "PPTX To PDF",
                Category = "Conversions",
                Description = "This example demonstrates how to convert a PowerPoint presentation file to a PDF file.",
                DemoView = typeof(EssentialPresentation.PPTXToPDF),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "PowerPoint library -  PPTX to PDF conversion", Uri = new Uri("https://help.syncfusion.com/file-formats/presentation/presentation-to-pdf") }
            };
            pptxToPDF.Documentation.AddRange(selectionDocumentations);
			
			DemoInfo findAndReplace = new()
            {
                Name = "Find and Replace",
                Category = "Editing",
                DemoType = DemoTypes.None,
                Description = "This example demonstrates how to replace a specific text or text pattern in the PowerPoint presentation file.",
                DemoView = typeof(EssentialPresentation.FindAndReplace),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "PowerPoint library -  Find and Replace", Uri = new Uri("https://help.syncfusion.com/file-formats/presentation/working-with-find-and-replace") }
            };
            findAndReplace.Documentation.AddRange(selectionDocumentations);
			
			DemoInfo findAndHighlight = new()
            {
                Name = "Find and Highlight",
                Category = "Editing",
                Description = "This example demonstrates how to find a specific text and highlight it in an existing PowerPoint presentation file.",
                DemoView = typeof(EssentialPresentation.FindAndHighlight),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "PowerPoint library -  Find and Highlight", Uri = new Uri("https://help.syncfusion.com/file-formats/presentation/working-with-find-and-replace") }
            };
            findAndHighlight.Documentation.AddRange(selectionDocumentations);

            DemoInfo encryptAndDecrypt = new()
            {
                Name = "Encrypt and Decrypt",
                Category = "Security",
                DemoType = DemoTypes.None,
                Description = "This example demonstrates how to encrypt and decrypt a PowerPoint presentation file.",
                DemoView = typeof(EssentialPresentation.EncryptAndDecrypt),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "PowerPoint library -  Working with Security", Uri = new Uri("https://help.syncfusion.com/file-formats/presentation/security") }
            };
            encryptAndDecrypt.Documentation.AddRange(selectionDocumentations);
            
            DemoInfo image = new()
            {
                Name = "Image",
                Category = "Slide Elements",
                DemoType = DemoTypes.None,
                Description = "This example demonstrates how to add and format images in PowerPoint Presentation using .NET PowerPoint Library (Presentation).",
                DemoView = typeof(EssentialPresentation.Image),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "PowerPoint library -  Working with Images", Uri = new Uri("https://help.syncfusion.com/file-formats/presentation/working-with-images") }
            };
            image.Documentation.AddRange(selectionDocumentations);
			
            DemoInfo chart = new()
            {
                Name = "Chart",
                Category = "Slide Elements",
                DemoType = DemoTypes.None,
                Description = "This example demonstrates how to create a chart in a PowerPoint presentation file.",
                DemoView = typeof(EssentialPresentation.Chart),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "PowerPoint library -  Working with Charts", Uri = new Uri("https://help.syncfusion.com/file-formats/presentation/working-with-charts") }
            };
            chart.Documentation.AddRange(selectionDocumentations);

            DemoInfo slide = new()
            {
                Name = "Slide",
                Category = "Slide Elements",
                DemoType = DemoTypes.None,
                Description = "This example demonstrates how to create slides with text, table, and images in a PowerPoint presentation file.",
                DemoView = typeof(EssentialPresentation.Slide),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "PowerPoint library -  Working with Slides", Uri = new Uri("https://help.syncfusion.com/file-formats/presentation/working-with-slide") }
            };
            slide.Documentation.AddRange(selectionDocumentations);

            DemoInfo table = new()
            {
                Name = "Table",
                Category = "Slide Elements",
                DemoType = DemoTypes.None,
                Description = "This example demonstrates how to create a table in a PowerPoint presentation file.",
                DemoView = typeof(EssentialPresentation.Table),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "PowerPoint library -  Working with Tables", Uri = new Uri("https://help.syncfusion.com/file-formats/presentation/working-with-tables") }
            };
            table.Documentation.AddRange(selectionDocumentations);

            DemoInfo headerAndFooter = new()
            {
                Name = "Header and Footer",
                Category = "Slide Elements",
                DemoType = DemoTypes.None,
                Description = "This example demonstrates how to insert headers and footers in a PowerPoint presentation.",
                DemoView = typeof(EssentialPresentation.HeaderAndFooter),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "PowerPoint library -  Working with Headers and Footers", Uri = new Uri("https://help.syncfusion.com/file-formats/presentation/working-with-headers-and-footers") }
            };
            headerAndFooter.Documentation.AddRange(selectionDocumentations);

            var demos = new List<DemoInfo>()
            {
                helloWorld,
                pptxToImage,
                pptxToPDF,
				findAndReplace,
				findAndHighlight,
                image,
                chart,
                slide,
                table,
                headerAndFooter,
                encryptAndDecrypt
            };

            var controlInfo = new ControlInfo()
            {
                Control = DemoControl.EssentialPresentation,
                ControlCategory = ControlCategory.FileFormat,
                Description = "A .NET PowerPoint library to create, read, and edit PowerPoint files programmatically.",
                Glyph = "\ue71f",
                ImageSource = "Presentation.png",
                ControlBadge = ControlBadge.None
            };

            controlInfo.Demos.AddRange(demos);
            DemoHelper.ControlInfos.Add(controlInfo);
        }
    }
}
