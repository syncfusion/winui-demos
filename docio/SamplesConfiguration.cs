#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using DocIO;
using Syncfusion.DemosCommon.WinUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syncfusion.DocIODemos.WinUI
{
    public class SamplesConfiguration
    {
        public SamplesConfiguration()
        {
            DemoInfo salesInvoice = new()
            {
                Name = "Sales Invoice",
                Category = "Product Showcase",
                DemoType = DemoTypes.None,
                Description = "This example demonstrates the generation of sales invoice from an input Word template using the mail merge functionality.",
                DemoView = typeof(SalesInvoice),
                ShowInfoPanel = true
            };
            List<Documentation> selectionDocumentations = new()
            {
                new Documentation() { Content = "Word library -  Working with Mail Merge", Uri = new Uri("https://help.syncfusion.com/file-formats/docio/working-with-mail-merge") }
            };
            salesInvoice.Documentation.AddRange(selectionDocumentations);

            DemoInfo helloWorld = new()
            {
                Name = "Hello World",
                Category = "Getting Started",
                DemoType = DemoTypes.None,
                Description = "This example demonstrates how to create a simple Word document with text, images, and tables.",
                DemoView = typeof(HelloWorld),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "Word library -  Working with Text", Uri = new Uri("https://help.syncfusion.com/file-formats/docio/working-with-paragraph#working-with-text") },
                new Documentation() { Content = "Word library -  Working with Images", Uri = new Uri("https://help.syncfusion.com/file-formats/docio/working-with-paragraph#working-with-images") },
                new Documentation() { Content = "Word library -  Working with Tables", Uri = new Uri("https://help.syncfusion.com/file-formats/docio/working-with-tables") }
            };
            helloWorld.Documentation.AddRange(selectionDocumentations);

            DemoInfo findAndHighlight = new()
            {
                Name = "Find and Highlight",
                Category = "Editing",
                DemoType = DemoTypes.None,
                Description = "This example demonstrates how to find and highlight a specific text in an existing Word document using the Find functionality.",
                DemoView = typeof(FindAndHighlight),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "Word library -  Working with Find and Replace", Uri = new Uri("https://help.syncfusion.com/file-formats/docio/working-with-find-and-replace") }
            };
            findAndHighlight.Documentation.AddRange(selectionDocumentations);

            DemoInfo findAndReplace = new()
            {
                Name = "Find and Replace",
                Category = "Editing",
                DemoType = DemoTypes.None,
                Description = "This example demonstrates how to find a specific text and replace it with another text in the Word document using the Find and Replace functionality.",
                DemoView = typeof(FindAndReplace),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "Word library -  Working with Find and Replace", Uri = new Uri("https://help.syncfusion.com/file-formats/docio/working-with-find-and-replace") }
            };
            findAndReplace.Documentation.AddRange(selectionDocumentations);

            DemoInfo bookmarks = new()
            {
                Name = "Bookmarks",
                Category = "Insert Content",
                DemoType = DemoTypes.None,
                Description = "This example demonstrates how to add bookmarks to a Word document.",
                DemoView = typeof(Bookmarks),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "Word library -  Working with Bookmarks", Uri = new Uri("https://help.syncfusion.com/file-formats/docio/working-with-bookmarks") }
            };
            bookmarks.Documentation.AddRange(selectionDocumentations);

            DemoInfo headerAndFooter = new()
            {
                Name = "Header and Footer",
                Category = "Insert Content",
                DemoType = DemoTypes.None,
                Description = "This example demonstrates how to insert headers and footers in a Word document.",
                DemoView = typeof(HeaderAndFooter),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "Word library -  Working with Headers and Footers", Uri = new Uri("https://help.syncfusion.com/file-formats/docio/working-with-sections#working-with-headers-and-footers") }
            };
            headerAndFooter.Documentation.AddRange(selectionDocumentations);

            DemoInfo imageInsertion = new()
            {
                Name = "Image Insertion",
                Category = "Insert Content",
                DemoType = DemoTypes.None,
                Description = "This example demonstrates how to insert images in a Word document.",
                DemoView = typeof(ImageInsertion),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "Word library -  Working with Images", Uri = new Uri("https://help.syncfusion.com/file-formats/docio/working-with-paragraph#working-with-images") }
            };
            imageInsertion.Documentation.AddRange(selectionDocumentations);

            DemoInfo wordToPdf = new()
            {
                Name = "Word to PDF",
                Category = "Conversions",
                DemoType = DemoTypes.Updated,
                Description = "This example demonstrates how to convert a Word document to a PDF file.",
                DemoView = typeof(WordToPDF),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "Word library -  Word document to PDF conversion", Uri = new Uri("https://help.syncfusion.com/file-formats/docio/word-to-pdf") }
            };
            wordToPdf.Documentation.AddRange(selectionDocumentations);

            DemoInfo rtfConversion = new()
            {
                Name = "RTF Conversion",
                Category = "Conversions",
                DemoType = DemoTypes.None,
                Description = "This example demonstrates how to convert a RTF file to a Word document and PDF.",
                DemoView = typeof(RTFConversion),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "Word library -  RTF conversion", Uri = new Uri("https://help.syncfusion.com/file-formats/docio/rtf") }
            };
            rtfConversion.Documentation.AddRange(selectionDocumentations);

            DemoInfo employeeReport = new()
            {
                Name = "Employee Report",
                Category = "Mail Merge",
                DemoType = DemoTypes.None,
                Description = "This example demonstrates how to generate employees’ addresses using the mail merge feature.",
                DemoView = typeof(EmployeeReport),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "Word library -  Working with Mail Merge", Uri = new Uri("https://help.syncfusion.com/file-formats/docio/working-with-mail-merge") }
            };
            employeeReport.Documentation.AddRange(selectionDocumentations);

            DemoInfo ordersReport = new()
            {
                Name = "Orders Report",
                Category = "Mail Merge",
                DemoType = DemoTypes.None,
                Description = "This example demonstrates how to generate order details of customers using the nested mail merge functionality with hierarchical data.",
                DemoView = typeof(OrdersReport),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "Word library -  Working with Nested Mail Merge", Uri = new Uri("https://help.syncfusion.com/file-formats/docio/mail-merge/mail-merge-for-nested-groups") }
            };
            ordersReport.Documentation.AddRange(selectionDocumentations);

            DemoInfo tableOfContent = new()
            {
                Name = "Table of Contents",
                Category = "References",
                DemoType = DemoTypes.None,
                Description = "This example demonstrates how to insert and update a table of contents (TOC) in a Word document.",
                DemoView = typeof(TableOfContent),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "Word library -  Working with Table of Contents", Uri = new Uri("https://help.syncfusion.com/file-formats/docio/working-with-table-of-contents") }
            };
            tableOfContent.Documentation.AddRange(selectionDocumentations);

            DemoInfo encryptAndDecrypt = new()
            {
                Name = "Encrypt and Decrypt",
                Category = "Security",
                DemoType = DemoTypes.None,
                Description = "This example demonstrates how to encrypt and decrypt a Word document.",
                DemoView = typeof(EncryptAndDecrypt),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "Word library -  Working with Security", Uri = new Uri("https://help.syncfusion.com/file-formats/docio/working-with-security") }
            };
            encryptAndDecrypt.Documentation.AddRange(selectionDocumentations);

            var demos = new List<DemoInfo>()
            {
                salesInvoice,
                helloWorld,
                employeeReport,
                ordersReport,
                findAndHighlight,
                findAndReplace,
                bookmarks,
                headerAndFooter,
                imageInsertion,
                wordToPdf,
                rtfConversion,
                tableOfContent,
                encryptAndDecrypt
            };

            var controlInfo = new ControlInfo()
            {
                Control = DemoControl.EssentialDocIO,
                ControlCategory = ControlCategory.FileFormat,
                ControlBadge = ControlBadge.Updated,
                Description = "A .NET Word library to create, read, and edit Word documents programmatically.",
                Glyph = "\ue71e",
                ImageSource = "DocIO.png"
            };

            controlInfo.Demos.AddRange(demos);
            DemoHelper.ControlInfos.Add(controlInfo);
        }
    }
}
