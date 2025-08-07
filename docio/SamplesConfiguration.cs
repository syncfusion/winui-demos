#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
﻿using DocIO;
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

            DemoInfo createUsingLaTeX = new()
            {
                Name = "Create using LaTeX",
                Category = "Equation",
                DemoType = DemoTypes.None,
                Description = "This sample demonstrates how to create a Word document with mathematical equation using LaTeX using .NET Word Library (DocIO).",
                DemoView = typeof(CreateUsingLaTeX),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "Word library - Working with LaTeX", Uri = new Uri("https://help.syncfusion.com/file-formats/docio/working-with-latex") }
            };
            createUsingLaTeX.Documentation.AddRange(selectionDocumentations);

            DemoInfo editUsingLaTeX = new()
            {
                Name = "Edit using LaTeX",
                Category = "Equation",
                DemoType = DemoTypes.None,
                Description = "This sample demonstrates how to modify a mathematical equation using LaTeX in a Word document using .NET Word Library (DocIO).",
                DemoView = typeof(EditUsingLaTeX),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "Word library - Working with LaTeX", Uri = new Uri("https://help.syncfusion.com/file-formats/docio/working-with-latex") }
            };
            editUsingLaTeX.Documentation.AddRange(selectionDocumentations);

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
			
            DemoInfo wordToHTML = new()
            {
                Name = "Word to HTML",
                Category = "Conversions",
                Description = "This example demonstrates how to convert a Word document to HTML file using .NET Word Library (DocIO).",
                DemoView = typeof(WordToHTML),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "Word library -  Word document to HTML conversion", Uri = new Uri("https://help.syncfusion.com/document-processing/word/word-library/net/html") }
            };
            wordToHTML.Documentation.AddRange(selectionDocumentations);

            DemoInfo htmlToWord = new()
            {
                Name = "HTML to Word",
                Category = "Conversions",
                Description = "This example demonstrates how to convert HTML file to a Word document using .NET Word Library (DocIO).",
                DemoView = typeof(HTMLToWord),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "Word library -  HTML to Word document conversion", Uri = new Uri("https://help.syncfusion.com/document-processing/word/word-library/net/html") }
            };
            htmlToWord.Documentation.AddRange(selectionDocumentations);

            DemoInfo wordToMd = new()
            {
                Name = "Word to Markdown",
                Category = "Conversions",
                Description = "This example demonstrates how to convert the Word document to Markdown file.",
                DemoView = typeof(WordToMarkdown),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "Word library -  Word document to Markdown conversion", Uri = new Uri("https://help.syncfusion.com/file-formats/docio/convert-word-document-to-markdown-in-csharp") }
            };
            wordToMd.Documentation.AddRange(selectionDocumentations);

            DemoInfo mdToWord = new()
            {
                Name = "Markdown to Word",
                Category = "Conversions",
                DemoType = DemoTypes.None,
                Description = "This sample demonstrates how to convert  the Markdown file to Word document using .NET Word (DocIO) library.",
                DemoView = typeof(MarkdownToWord),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "Word library -  Markdown to Word conversion", Uri = new Uri("https://help.syncfusion.com/file-formats/docio/convert-markdown-to-word-document-in-csharp") }
            };
            mdToWord.Documentation.AddRange(selectionDocumentations);

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
            
            DemoInfo tableOfFigures = new()
            {
                Name = "Table of Figures",
                Category = "References",
                DemoType = DemoTypes.None,
                Description = "This example demonstrates how to insert and update the table of figures in a Word document using .NET Word Library (DocIO).",
                DemoView = typeof(TableOfFigures),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "Word library -  Working with Table of Contents", Uri = new Uri("https://help.syncfusion.com/file-formats/docio/working-with-table-of-contents") }
            };
            tableOfFigures.Documentation.AddRange(selectionDocumentations);

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
			DemoInfo documentProtection = new()
            {
                Name = "Document Protection",
                Category = "Security",
                DemoType = DemoTypes.Updated,
                Description = "This example demonstrates how to protect and make the specific section as editable a Word document.",
                DemoView = typeof(DocumentProtection),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "Word library -  Working with Security", Uri = new Uri("https://help.syncfusion.com/file-formats/docio/working-with-security") }
            };
            documentProtection.Documentation.AddRange(selectionDocumentations)	;					  
            DemoInfo compareDocuments = new()
            {
                Name = "Compare Documents",
                Category = "Review",
                Description = "This sample demonstrates how to compare two Word documents using .NET Word (DocIO) library. With this, you can easily identify the changes between two versions of a document.",
                DemoView = typeof(CompareDocuments),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "Word library - Compare Documents", Uri = new Uri("https://help.syncfusion.com/file-formats/docio/word-document/compare-word-documents") }
            };
            compareDocuments.Documentation.AddRange(selectionDocumentations);


            DemoInfo createSmartArt = new()
            {
                Name = "Create SmartArt",
                Category = "SmartArts",
                DemoType = DemoTypes.None,
                Description = "This sample demonstrates how to create a Word document with SmartArt graphics using the .NET Word Library (DocIO).",
                DemoView = typeof(CreateSmartArt),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "Word library -  Working with SmartArts", Uri = new Uri("https://help.syncfusion.com/document-processing/word/word-library/net/working-with-smartarts") }
            };
            createSmartArt.Documentation.AddRange(selectionDocumentations);

            DemoInfo editSmartArt = new()
            {
                Name = "Edit SmartArt",
                Category = "SmartArts",
                DemoType = DemoTypes.None,
                Description = "This sample demonstrates how to modify SmartArt graphics in a Word document using the .NET Word Library (DocIO).",
                DemoView = typeof(EditSmartArt),
                ShowInfoPanel = true
            };
            selectionDocumentations = new List<Documentation>
            {
                new Documentation() { Content = "Word library -  Working with SmartArts", Uri = new Uri("https://help.syncfusion.com/document-processing/word/word-library/net/working-with-smartarts") }
            };
            editSmartArt.Documentation.AddRange(selectionDocumentations);

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
                createUsingLaTeX,
                editUsingLaTeX,
                createSmartArt,
                editSmartArt,
                wordToPdf,
                wordToHTML,
                htmlToWord,
                wordToMd,
                mdToWord,
                rtfConversion,
                tableOfContent,
                tableOfFigures,
                encryptAndDecrypt,
				documentProtection,	   
                compareDocuments,
            };

            var controlInfo = new ControlInfo()
            {
                Control = DemoControl.EssentialDocIO,
                ControlBadge=ControlBadge.Updated,
                ControlCategory = ControlCategory.FileFormat,
                Description = "A .NET Word library to create, read, and edit Word documents programmatically.",
                Glyph = "\ue71e",
                ImageSource = "DocIO.png"
            };

            controlInfo.Demos.AddRange(demos);
            DemoHelper.ControlInfos.Add(controlInfo);
        }
    }
}
