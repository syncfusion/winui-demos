#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.winui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.presentationdemos.winui
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
                DemoType = DemoTypes.None,
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
                DemoType = DemoTypes.None,
                Description = "This example demonstrates how to convert a PowerPoint presentation file to a PDF file.",
                DemoView = typeof(EssentialPresentation.PPTXToPDF),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "PowerPoint library -  PPTX to PDF conversion", Uri = new Uri("https://help.syncfusion.com/file-formats/presentation/presentation-to-pdf") }
            };
            pptxToPDF.Documentation.AddRange(selectionDocumentations);

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
                ControlBadge = ControlBadge.New
            };

            controlInfo.Demos.AddRange(demos);
            DemoHelper.ControlInfos.Add(controlInfo);
        }
    }
}
