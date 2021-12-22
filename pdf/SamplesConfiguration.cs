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

namespace syncfusion.pdfdemos.winui
{
   public class SamplesConfiguration
    {
        public SamplesConfiguration()
        {
            DemoInfo invoice = new DemoInfo()
            {
                Name = "Invoice",
                Category = "Product Showcase",
                DemoType = DemoTypes.None,
                Description = "This demo shows how to create simple invoice report using PDF grid with built-in styles.",
                DemoView = typeof(Invoice),
                ShowInfoPanel = true
            };

            List<Documentation> pdfDocumentations = new List<Documentation>();
            pdfDocumentations.Add(new Documentation() { Content = "PDF - Overview of PDF library", Uri = new Uri("https://help.syncfusion.com/file-formats/pdf/overview") });
            pdfDocumentations.Add(new Documentation() { Content = "PDF - Working with ZUGFeRD invoice", Uri = new Uri("https://help.syncfusion.com/file-formats/pdf/working-with-zugferd-invoice") });
            invoice.Documentation.AddRange(pdfDocumentations);

            DemoInfo certficate = new DemoInfo()
            {
                Name = "Course Completion Certificate",
                Category = "Product Showcase",
                DemoType = DemoTypes.None,
                Description = "This demo shows how to dynamically generates the course completion certificate for online learning portal with participant name, course name and date of completion.",
                DemoView = typeof(Certificate),
                ShowInfoPanel = true
            };

            pdfDocumentations = new List<Documentation>();
            pdfDocumentations.Add(new Documentation() { Content = "PDF - Working with Text", Uri = new Uri("https://help.syncfusion.com/file-formats/pdf/working-with-text") });
            pdfDocumentations.Add(new Documentation() { Content = "PDF - Working with Images", Uri = new Uri("https://help.syncfusion.com/file-formats/pdf/working-with-images") });
            certficate.Documentation.AddRange(pdfDocumentations);

            DemoInfo imageInsertion = new DemoInfo()
            {
                Name = "Image Insertion",
                Category = "Graphics",
                DemoType = DemoTypes.None,
                Description = "This demo shows how to insert images in a PDF document.",
                DemoView = typeof(ImageInsertion),
                ShowInfoPanel = true
            };

            pdfDocumentations = new List<Documentation>();
            pdfDocumentations.Add(new Documentation() { Content = "PDF - Working with Images", Uri = new Uri("https://help.syncfusion.com/file-formats/pdf/working-with-images") });
            pdfDocumentations.Add(new Documentation() { Content = "PDF - Inserting an image in an existing PDF document", Uri = new Uri("https://help.syncfusion.com/file-formats/pdf/working-with-images#inserting-an-image-in-an-existing-document") });
            imageInsertion.Documentation.AddRange(pdfDocumentations);

            DemoInfo annotations = new DemoInfo()
            {
                Name = "Annotations",
                Category = "User Interaction",
                DemoType = DemoTypes.None,
                Description = "This demo shows how to create different types of annotations such as ink, free text, pop up, text markup annotation and more. It is possible to flatten the annotations in a PDF document.",
                DemoView = typeof(Annotations),
                ShowInfoPanel = true
            };
            pdfDocumentations = new List<Documentation>();
            pdfDocumentations.Add(new Documentation() { Content = "PDF - Annotations overview", Uri = new Uri("https://www.syncfusion.com/pdf-framework/net/pdf-library/pdf-annotation") });
            pdfDocumentations.Add(new Documentation() { Content = "PDF - Working with Annotations", Uri = new Uri("https://help.syncfusion.com/file-formats/pdf/working-with-annotations") });
            annotations.Documentation.AddRange(pdfDocumentations);

            DemoInfo formFilling = new DemoInfo()
            {
                Name = "Form Filling",
                Category = "User Interaction",
                DemoType = DemoTypes.None,
                Description = "This demo shows how to fill the existing form in a PDF document. It also supports flattening the form fields.",
                DemoView = typeof(FormFilling),
                ShowInfoPanel = true
            };
            pdfDocumentations = new List<Documentation>();
            pdfDocumentations.Add(new Documentation() { Content = "PDF - Forms overview", Uri = new Uri("https://www.syncfusion.com/pdf-framework/net/pdf-library/pdf-form-fields") });
            pdfDocumentations.Add(new Documentation() { Content = "PDF - Working with Forms", Uri = new Uri("https://help.syncfusion.com/file-formats/pdf/working-with-forms") });
            formFilling.Documentation.AddRange(pdfDocumentations);

            DemoInfo importexport = new DemoInfo()
            {
                Name = "Import and Export Form Data",
                Category = "User Interaction",
                DemoType = DemoTypes.None,
                Description = "This demo shows how to import or export form data from the PDF document. It supports FDF, XFDF, XML, and JSON format for import and export. It is possible to save the exported form data to file or database.",
                DemoView = typeof(ImportAndExport),
                ShowInfoPanel = true
            };
            pdfDocumentations = new List<Documentation>();
            pdfDocumentations.Add(new Documentation() { Content = "PDF - Forms overview", Uri = new Uri("https://www.syncfusion.com/pdf-framework/net/pdf-library/pdf-form-fields") });
            pdfDocumentations.Add(new Documentation() { Content = "PDF - Working with Forms", Uri = new Uri("https://help.syncfusion.com/file-formats/pdf/working-with-forms") });
            importexport.Documentation.AddRange(pdfDocumentations);


            DemoInfo mergePDF = new DemoInfo()
            {
                Name = "Merge PDF Documents",
                Category = "Modify Documents",
                DemoType = DemoTypes.None,
                Description = "This demo shows how to merge two different PDF documents into single PDF document.",
                DemoView = typeof(MergePDF),
                ShowInfoPanel = true
            };
            pdfDocumentations = new List<Documentation>();
            pdfDocumentations.Add(new Documentation() { Content = "PDF - Merge PDF documents overview", Uri = new Uri("https://www.syncfusion.com/pdf-framework/net/pdf-library/split-merge-pdf") });
            pdfDocumentations.Add(new Documentation() { Content = "PDF - Working with Merge PDF documents", Uri = new Uri("https://help.syncfusion.com/file-formats/pdf/merge-documents") });
            mergePDF.Documentation.AddRange(pdfDocumentations);

          
            DemoInfo digitalSignature = new DemoInfo()
            {
                Name = "Digital Signature",
                Category = "Security",
                DemoType = DemoTypes.None,
                Description = "This demo shows how to digitally sign the PDF document with .pfx certificates. It also supports various digest algorithms and cryptographic standards.",
                DemoView = typeof(DigitalSignature),
                ShowInfoPanel = true
            };
            pdfDocumentations = new List<Documentation>();
            pdfDocumentations.Add(new Documentation() { Content = "PDF - Digital Signatures overview", Uri = new Uri("https://www.syncfusion.com/pdf-framework/net/pdf-library/digital-signature-timestamp-pdf") });
            pdfDocumentations.Add(new Documentation() { Content = "PDF - Working with Digital Signature", Uri = new Uri("https://help.syncfusion.com/file-formats/pdf/working-with-digitalsignature") });
            digitalSignature.Documentation.AddRange(pdfDocumentations);

            DemoInfo encryption = new DemoInfo()
            {
                Name = "Encryption",
                Category = "Security",
                DemoType = DemoTypes.None,
                Description = "This demo shows how to encrypt the existing PDF document with encryption standards like 40-bit RC4, 128-bit RC4, 128-bit AES, 256-bit AES, and advanced encryption standard 256-bit AES Revision 6 (PDF 2.0) to protect documents against unauthorized access.",
                DemoView = typeof(Encryption),
                ShowInfoPanel = true
            };
            pdfDocumentations = new List<Documentation>();
            pdfDocumentations.Add(new Documentation() { Content = "PDF - Protect PDF in .NET", Uri = new Uri("https://www.syncfusion.com/pdf-framework/net/pdf-library/protect-pdf") });
            pdfDocumentations.Add(new Documentation() { Content = "PDF - Working with Security", Uri = new Uri("https://help.syncfusion.com/file-formats/pdf/working-with-security") });
            encryption.Documentation.AddRange(pdfDocumentations);

            DemoInfo conformance = new DemoInfo()
            {
                Name = "PDF Conformance",
                Category = "Conformance",
                DemoType = DemoTypes.None,
                Description = "This demo shows how to create PDF document with different types of PDF/A conformance.",
                DemoView = typeof(PdfConformance),
                ShowInfoPanel = true
            };
            pdfDocumentations = new List<Documentation>();
            pdfDocumentations.Add(new Documentation() { Content = "PDF - Working with PDF conformance", Uri = new Uri("https://help.syncfusion.com/file-formats/pdf/working-with-pdf-conformance") });
            pdfDocumentations.Add(new Documentation() { Content = "PDF - PDF conformance API documentation", Uri = new Uri("https://help.syncfusion.com/cr/file-formats/Syncfusion.Pdf.PdfConformanceLevel.html") });
            conformance.Documentation.AddRange(pdfDocumentations);

            DemoInfo watermarkdemo = new DemoInfo()
            {
                Name = "Watermark Text",
                Category = "Modify Documents",
                DemoType = DemoTypes.None,
                Description = "This demo shows how to add a text watermark in an existing PDF document. It supports watermark with text and images in a PDF document.",
                DemoView = typeof(PdfWatermark),
                ShowInfoPanel = true
            };
            pdfDocumentations = new List<Documentation>();
            pdfDocumentations.Add(new Documentation() { Content = "PDF - Working with text watermark", Uri = new Uri("https://help.syncfusion.com/file-formats/pdf/working-with-watermarks#adding-text-watermark-in-pdf-document") });
            pdfDocumentations.Add(new Documentation() { Content = "PDF - Working with image watermark", Uri = new Uri("https://help.syncfusion.com/file-formats/pdf/working-with-watermarks#adding-image-watermark-in-pdf-document") });
            watermarkdemo.Documentation.AddRange(pdfDocumentations);

            DemoInfo extractText = new DemoInfo()
            {
                Name = "Text Extraction",
                Category = "Extract and Find Text",
                DemoType = DemoTypes.None,
                Description = "This demo shows how to extract text from an existing PDF document. It also supports extracting the text with font name, size, and style.",
                DemoView = typeof(ExtractText),
                ShowInfoPanel = true
            };
            pdfDocumentations = new List<Documentation>();
            pdfDocumentations.Add(new Documentation() { Content = "PDF - Working with Text Extraction", Uri = new Uri("https://help.syncfusion.com/file-formats/pdf/working-with-text-extraction") });
            pdfDocumentations.Add(new Documentation() { Content = "PDF - Working with Image Extraction", Uri = new Uri("https://help.syncfusion.com/file-formats/pdf/working-with-image-extraction") });
            extractText.Documentation.AddRange(pdfDocumentations);
            
            DemoInfo findText = new DemoInfo()
            {
                Name = "Find Text",
                Category = "Extract and Find Text",
                DemoType = DemoTypes.None,
                Description = "This demo shows how to find a text along with bounds and page index from an existing PDF document.",
                DemoView = typeof(FindText),
                ShowInfoPanel = true
            };
            pdfDocumentations = new List<Documentation>();
            pdfDocumentations.Add(new Documentation() { Content = "PDF - Working with Text", Uri = new Uri("https://help.syncfusion.com/file-formats/pdf/working-with-text") });
            pdfDocumentations.Add(new Documentation() { Content = "PDF - Find Text API documentation", Uri = new Uri("https://help.syncfusion.com/cr/file-formats/Syncfusion.Pdf.Parsing.PdfLoadedDocument.html#Syncfusion_Pdf_Parsing_PdfLoadedDocument_FindText_System_Collections_Generic_List_System_String__Syncfusion_Pdf_Parsing_TextSearchResultCollection__") });
            findText.Documentation.AddRange(pdfDocumentations);

            var demos = new List<DemoInfo>()
            {
                invoice,
                certficate,
                imageInsertion,
                annotations,
                formFilling,
                mergePDF,
                importexport,
                digitalSignature,
                encryption,
                conformance,
                watermarkdemo,
                extractText,
                findText,
            };

            var controlInfo = new ControlInfo()
            {
                Control = DemoControl.PDF,
                ControlCategory = ControlCategory.FileFormat,
                ControlBadge = ControlBadge.New,
                Description = "A .NET PDF library to create, read, and edit PDF files programmatically with formatted text, tables, links, list, header, and footer, and more.",
                Glyph= "\uE720"
            };

            controlInfo.Demos.AddRange(demos);
            DemoHelper.ControlInfos.Add(controlInfo);
        }
    }
}
