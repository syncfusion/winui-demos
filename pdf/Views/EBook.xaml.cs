#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.IO;
using System.Reflection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

namespace syncfusion.pdfdemos.winui
{
    public sealed partial class EBook : Page
    {
        public EBook()
        {
            this.InitializeComponent();
        }

        private void GeneratePDF_Click(object sender, RoutedEventArgs e)
        {
            //Create a new PDF document.
            PdfDocument document = new PdfDocument();
            //Add a page to the document.
            PdfPage page = document.Pages.Add();
            //Create bounds to draw a image. 
            RectangleF imageRect = new RectangleF(50, 50, 425, 642);
            //Get the image file stream from assembly. 
            Stream imageStream = typeof(EBook).GetTypeInfo().Assembly.GetManifestResourceStream("syncfusion.pdfdemos.winui.Assets.Pdf_Succinctly_img_1.jpg");
            //Create new image from stream. 
            PdfBitmap image = new PdfBitmap(imageStream);
            //Draw image to PDF page. 
            page.Graphics.DrawImage(image, imageRect);
            
            //Add a page to the document.
            PdfPage titlePage = document.Pages.Add();
            //Create font, string format and text bounds. 
            PdfStandardFont times30Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 30);
            RectangleF textRect = new RectangleF(0, 60, titlePage.GetClientSize().Width, titlePage.GetClientSize().Height);
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Center);
            //Draw a text to PDF page. 
            titlePage.Graphics.DrawString("PDF Succinctly", times30Font, PdfBrushes.Black, textRect, format);

            //Create bounds to draw a image. 
            imageRect = new RectangleF(40, 110, 435, 5);
            //Get the template PDF file stream from assembly. 
            imageStream = typeof(EBook).GetTypeInfo().Assembly.GetManifestResourceStream("syncfusion.pdfdemos.winui.Assets.Pdf_Succinctly_img_5.jpg");
            //Create new image from stream.
            image = new PdfBitmap(imageStream);
            //Draw image to PDF page. 
            titlePage.Graphics.DrawImage(image, imageRect);

            //Create font, text bounds to draw a string to PDF page. 
            PdfFont helvetica16 = new PdfStandardFont(PdfFontFamily.Helvetica, 16, PdfFontStyle.Bold);
            textRect = new RectangleF(0, 130, titlePage.GetClientSize().Width, titlePage.GetClientSize().Height);
            titlePage.Graphics.DrawString("By\nRyan Hodson", helvetica16, PdfBrushes.Black, textRect, format);

            //Create font, text bounds to draw a string to PDF page. 
            PdfFont helvetica20 = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
            textRect = new RectangleF(0, 220, titlePage.GetClientSize().Width, titlePage.GetClientSize().Height);
            titlePage.Graphics.DrawString("Foreword by Daniel Jebaraj", helvetica20, PdfBrushes.Black, textRect, format);

            //Add new section to PDF document. 
            PdfSection section = document.Sections.Add();
            //Add a new page to section. 
            PdfPage contentPage = section.Pages.Add();

            //Add a new text content to PDF page. 
            AddParagraph(contentPage, "Table of Contents", new RectangleF(20, 60, 495, contentPage.GetClientSize().Height), true, true);

            //Create a header template and draw a text.
            PdfPageTemplateElement headerElement = new PdfPageTemplateElement(new Rectangle(0, 0, 515, 50), contentPage);
            //Set transparency to header graphics. 
            headerElement.Graphics.SetTransparency(0.6F);
            //Create alignment and string format for header content. 
            PdfTextAlignment textAlingment = PdfTextAlignment.Right;
            PdfVerticalAlignment verticalAlignment = PdfVerticalAlignment.Middle;
            format = new PdfStringFormat(textAlingment, verticalAlignment);
            //Draw text to header template. 
            headerElement.Graphics.DrawString("PDF Succinctly", new PdfStandardFont(PdfFontFamily.Helvetica, 10), PdfBrushes.Black, new RectangleF(0, 0, 515, 50), format);
            //Draw line to header template. 
            headerElement.Graphics.DrawLine(PdfPens.Gray, new PointF(0, 49), new PointF(515, 49));
            //Set the top page template. 
            section.Template.Top = headerElement;

            //Create a footer template and draw a text.
            PdfPageTemplateElement footerElement = new PdfPageTemplateElement(new RectangleF(0, 0, 515, 50), contentPage);
            //Set transparency to header graphics. 
            footerElement.Graphics.SetTransparency(0.6F);
            //Create new font to draw the content in footer template. 
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 7);
            //Create page number field.
            PdfPageNumberField pageNumber = new PdfPageNumberField(font, PdfBrushes.Black);
            //Create page count field.
            PdfPageCountField count = new PdfPageCountField(font, PdfBrushes.Black);
            //Add the fields in composite fields.
            PdfCompositeField compositeField = new PdfCompositeField(font, PdfBrushes.Black, "Page {0} of {1}", pageNumber, count);
            compositeField.Bounds = footerElement.Bounds;
            //Draw the composite field in footer.
            compositeField.Draw(footerElement.Graphics, new PointF(450, 35));
            //Set the bottom page template.
            section.Template.Bottom = footerElement;
            //Add a new PDF page to PDF document. 
            page = document.Pages.Add();
            SizeF pageSize = page.GetClientSize();

            //Add a new text content to PDF page and get layout result. 
            PdfLayoutResult result = AddParagraph(page, "Introduction", new RectangleF(20, 25, 495, pageSize.Height), true, true);

            //Add to table of content and get layout result.
            PdfLayoutResult tableContent = AddTableOfContents(contentPage, "Introduction", new RectangleF(20, 110, 470, result.Page.GetClientSize().Height), true, 4, 20, result.Bounds.Top, result.Page);
            //Create color for bookmark. 
            PdfColor bookmarkColor = new PdfColor(0, 0, 0);

            //Add bookmark to PDF page. 
            AddBookmark(page, "Introduction", result.Bounds.Location, document,null, bookmarkColor);

            //Add a new text content to PDF page and get layout result. 
            result = AddParagraph(result.Page, "Adobe Systems Incorporated\'s Portable Document Format (PDF) is the de facto standard for the accurate, reliable, and platform-independent representation of a paged document. It\'s the only universally accepted file format that allows pixel-perfect layouts. In addition, PDF supports user interaction and collaborative workflows that are not possible with printed documents.\n\nPDF documents have been in widespread use for years, and dozens of free and commercial PDF readers, editors, and libraries are readily available. However, despite this popularity, it\'s still difficult to find a succinct guide to the native PDF format. Understanding the internal workings of a PDF makes it possible to dynamically generate PDF documents. For example, a web server can extract information from a database, use it to customize an invoice, and serve it to the customer on the fly.",
                new RectangleF(20, result.Bounds.Bottom + 20, 495, pageSize.Height), false, false);

            //Add a new text content to PDF page and get layout result. 
            result = AddParagraph(result.Page, "The PDF Standard", new RectangleF(20, result.Bounds.Bottom + 25, 495, pageSize.Height), true, false);
            
            //Add to table of content and get layout result.
            tableContent = AddTableOfContents(tableContent.Page, "The PDF Standard", new RectangleF(20, tableContent.Bounds.Bottom, 470, result.Page.GetClientSize().Height),
                false, 4, 20, result.Bounds.Top, result.Page);

            //Add bookmark to PDF page. 
            AddBookmark(result.Page, "The PDF Standard", result.Bounds.Location, document, null, bookmarkColor);

            //Add a new text content to PDF page and get layout result. 
            result = AddParagraph(result.Page, "The PDF format is an open standard maintained by the International Organization for Standardization. The official specification is defined in ISO 32000-1:2008, but Adobe also provides a free, comprehensive guide called PDF Reference, Sixth Edition, version 1.7.",
                new RectangleF(20, result.Bounds.Bottom + 20, 495, pageSize.Height), false);

            //Add a new text content to PDF page and get layout result. 
            result = AddParagraph(result.Page, "Chapter 1 Conceptual Overview", new RectangleF(20, result.Bounds.Bottom + 25, 495, pageSize.Height), true, true);

            //Add to table of content and get layout result.
            tableContent = AddTableOfContents(tableContent.Page, "Chapter 1 Conceptual Overview", new RectangleF(20, tableContent.Bounds.Bottom, 470, result.Page.GetClientSize().Height),
                true, 4, 20, result.Bounds.Top, result.Page);

            //Add bookmark to PDF page. 
            PdfBookmark standardBookmark = AddBookmark(result.Page, "Chapter 1 Conceptual Overview", result.Bounds.Location, document, null, bookmarkColor);

            //Add a new text content to PDF page and get layout result. 
            result = AddParagraph(result.Page, "We\'ll begin with a conceptual overview of a simple PDF document. This chapter is designed to be a brief orientation before diving in and creating a real document from scratch.\nA PDF file can be divided into four parts: a header, body, cross-reference table, and trailer. The header marks the file as a PDF, the body defines the visible document, the cross-reference table lists the location of everything in the file, and the trailer provides instructions for how to start reading the file.",
                new RectangleF(20, result.Bounds.Bottom + 20, 495, pageSize.Height), false);

            //Add a new PDF page to PDF document. 
            PdfPage page2 = document.Pages.Add();

            //Get the image file stream from assembly. 
            Stream imageStream1 = typeof(EBook).GetTypeInfo().Assembly.GetManifestResourceStream("syncfusion.pdfdemos.winui.Assets.Pdf_Succinctly_img_2.jpg");
            //Create PDF bitmap image from stream. 
            PdfBitmap bitmap = new PdfBitmap(imageStream1);
            //Draw the image to PDF page. 
            page2.Graphics.DrawImage(bitmap, new RectangleF(10, 0, 495, 600));

            //Add a new text content to PDF page and get layout result. 
            result = AddParagraph(page2, "Every PDF file must have these four components.", new RectangleF(20, 620, 495, page2.GetClientSize().Height), false);

            //Add a new text content to PDF page and get layout result. 
            result = AddParagraph(document.Pages.Add(), "Header", new RectangleF(20, 15, 495, pageSize.Height), true);

            //Add to table of content and get layout result.
            tableContent = AddTableOfContents(tableContent.Page, "Header", new RectangleF(20, tableContent.Bounds.Bottom, 470, result.Page.GetClientSize().Height),
                false, 6, 20, result.Bounds.Top, result.Page);

            //Add bookmark to PDF page. 
            AddBookmark(result.Page, "Header", result.Bounds.Location, null, standardBookmark, bookmarkColor);

            //Add a new text content to PDF page and get layout result. 
            result = AddParagraph(result.Page, "The header is simply a PDF version number and an arbitrary sequence of binary data. The binary data prevents na�ve applications from processing the PDF as a text file. This would result in a corrupted file, since a PDF typically consists of both plain text and binary data (e.g., a binary font file can be directly embedded in a PDF).",
                new RectangleF(20, result.Bounds.Bottom + 20, 495, pageSize.Height), false);

            //Add a new text content to PDF page and get layout result. 
            result = AddParagraph(result.Page, "Body", new RectangleF(20, result.Bounds.Bottom + 25, 495, pageSize.Height), true);

            //Add to table of content and get layout result.
            tableContent = AddTableOfContents(tableContent.Page, "Body", new RectangleF(20, tableContent.Bounds.Bottom, 470, result.Page.GetClientSize().Height),
                false, 6, 20, result.Bounds.Top, result.Page);

            //Add bookmark to PDF page. 
            AddBookmark(result.Page, "Body", result.Bounds.Location, null, standardBookmark, bookmarkColor);

            //Add a new text content to PDF page and get layout result. 
            result = AddParagraph(result.Page, "The body of a PDF contains the entire visible document. The minimum elements required in a valid PDF body are:\n\n1. A page tree \n2. Pages \n3. Resources \n4. Content \n5. The catalog \n\nThe page tree serves as the root of the document. In the simplest case, it is just a list of the pages in the document. Each page is defined as an independent entity with metadata (e.g., page dimensions) and a reference to its resources and content, which are defined separately. Together, the page tree and page objects create the \"paper\" that composes the document.\n\nResources are objects that are required to render a page. For example, a single font is typically used across several pages, so storing the font information in an external resource is much more efficient. A content object defines the text and graphics that actually show up on the page. Together, content objects and resources define the appearance of an individual page.\nFinally, the document\'s catalog tells applications where to start reading the document. Often, this is just a pointer to the root page tree.",
                new RectangleF(20, result.Bounds.Bottom + 20, 495, pageSize.Height), false);

            //Add a new PDF page to PDF document. 
            PdfPage page3 = document.Pages.Add();
            //Get the image file stream from assembly.
            Stream imageStream2 = typeof(EBook).GetTypeInfo().Assembly.GetManifestResourceStream("syncfusion.pdfdemos.winui.Assets.Pdf_Succinctly_img_3.jpg");
            //Create PDF bitmap image from stream.
            PdfBitmap bitmap2 = new PdfBitmap(imageStream2);
            //Draw the image to PDF page. 
            page3.Graphics.DrawImage(bitmap2, new RectangleF(20, 0, 300, 400));

            //Add a new text content to PDF page and get layout result. 
            result = AddParagraph(page3, "Cross-Reference Table", new RectangleF(20, 425, 495, pageSize.Height), true);
            
            //Add to table of content and get layout result.
            tableContent = AddTableOfContents(tableContent.Page, "Cross-Reference Table", new RectangleF(20, tableContent.Bounds.Bottom, 470, result.Page.GetClientSize().Height),
                false, 7, 20, result.Bounds.Top, result.Page);

            //Add bookmark to PDF page. 
            AddBookmark(result.Page, "Cross-Reference Table", result.Bounds.Location, null, standardBookmark, bookmarkColor);

            //Add a new text content to PDF page and get layout result. 
            result = AddParagraph(result.Page, "After the header and the body comes the cross-reference table. It records the byte location of each object in the body of the file. This enables random-access of the document, so when rendering a page, only the objects required for that page are read from the file. This makes PDFs much faster than their PostScript predecessors, which had to read in the entire file before processing it.",
               new RectangleF(20, result.Bounds.Bottom + 20, 495, pageSize.Height), false);

            //Add a new text content to PDF page and get layout result. 
            result = AddParagraph(result.Page, "Trailer", new RectangleF(20, result.Bounds.Bottom + 25, 495, pageSize.Height), true);

            //Add to table of content and get layout result.
            tableContent = AddTableOfContents(tableContent.Page, "Trailer", new RectangleF(20, tableContent.Bounds.Bottom, 470, result.Page.GetClientSize().Height),
                false, 7, 20, result.Bounds.Top, result.Page);

            //Add bookmark to PDF page. 
            AddBookmark(result.Page, "Trailer", result.Bounds.Location, null, standardBookmark, bookmarkColor);

            //Add a new text content to PDF page and get layout result. 
            result = AddParagraph(result.Page, "Finally, we come to the last component of a PDF document. The trailer tells applications how to start reading the file. At minimum, it contains three things:\n\n\n1. A reference to the catalog which links to the root of the document.\n2. The location of the cross-reference table.\n3. The size of the cross-reference table.\n\nSince a trailer is all you need to begin processing a document, PDFs are typically read back-to-front: first, the end of the file is found, and then you read backwards until you arrive at the beginning of the trailer. After that, you should have all the information you need to load any page in the PDF.",
                new RectangleF(20, result.Bounds.Bottom + 20, 495, pageSize.Height), false);

            //Add a new text content to PDF page and get layout result. 
            result = AddParagraph(result.Page, "Summary", new RectangleF(20, result.Bounds.Bottom + 25, 495, pageSize.Height), true);

            //Add to table of content and get layout result.
            tableContent = AddTableOfContents(tableContent.Page, "Summary", new RectangleF(20, tableContent.Bounds.Bottom, 470, result.Page.GetClientSize().Height),
                false, 8, 20, result.Bounds.Top, result.Page);

            //Add bookmark to PDF page. 
            AddBookmark(result.Page, "Summary", result.Bounds.Location, null, standardBookmark, bookmarkColor);

            //Add a new text content to PDF page and get layout result. 
            result = AddParagraph(result.Page, "To conclude our overview, a PDF document has a header, a body, a cross-reference table, and a trailer. The trailer serves as the entryway to the entire document, giving you access to any object via the cross-reference table, and pointing you toward the root of the document. The relationship between these elements is shown in the following figure.",
                new RectangleF(20, result.Bounds.Bottom + 20, 495, pageSize.Height), false);

            //Get the image file stream from assembly.
            Stream imageStream3 = typeof(EBook).GetTypeInfo().Assembly.GetManifestResourceStream("syncfusion.pdfdemos.winui.Assets.Pdf_Succinctly_img_4.jpg");
            //Create PDF bitmap image from stream.
            PdfBitmap bitmap3 = new PdfBitmap(imageStream3);
            //Draw the image to PDF page. 
            result.Page.Graphics.DrawImage(bitmap3, new RectangleF(20, result.Bounds.Bottom + 20, 495, 400));

            //Creating the stream object.
            using (MemoryStream stream = new MemoryStream())
            {
                //Save the document into stream.
                document.Save(stream);
                document.Close();

                stream.Position = 0;

                //Save the output stream as a file using file picker.
                PdfUtil.Save("E-Book.pdf", stream);
            }
        }

        #region Helper Methods
        /// <summary>
        /// Add a text to PDF page and return the layout result. 
        /// </summary>
        public PdfLayoutResult AddParagraph(PdfPage page, string text, RectangleF bounds, bool isTitle, bool mainTitle = false)
        {
            //Set string format, font size, style. 
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Justify);
            PdfFontStyle style = PdfFontStyle.Regular;
            float size = 13;

            if (mainTitle)
                format = new PdfStringFormat(PdfTextAlignment.Center);

            if (isTitle)
            {
                size = 18;
                if (mainTitle)
                    size = 24;
            }
           
            if (isTitle && !mainTitle)
                style = PdfFontStyle.Bold;

            //Create text element and draw it to PDF page. 
            PdfTextElement element = new PdfTextElement(text, new PdfStandardFont(PdfFontFamily.Helvetica, size, style), PdfBrushes.Black);
            element.StringFormat = format;
            return element.Draw(page, bounds);
        }
        /// <summary>
        /// Add content in table of content and return the layout result. 
        /// </summary>
        PdfLayoutResult AddTableOfContents(PdfPage page, string text, RectangleF bounds, bool isTitle, int pageNo, float x, float y, PdfPage destPage)
        {
            //Set font style. 
            PdfFontStyle style = isTitle ? PdfFontStyle.Bold : PdfFontStyle.Regular;
            //Create a font and draw the text to PDF page. 
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 13, style);
            page.Graphics.DrawString(pageNo.ToString(), font, PdfBrushes.Black, new RectangleF(480, bounds.Top + 5, bounds.Width, bounds.Height));
            //Create a pdf destination for document link annotation. 
            PdfDestination pdfDestination = new PdfDestination(destPage, new PointF(x, y));
            RectangleF annotationBounds = RectangleF.Empty;

            if (isTitle)
                annotationBounds = new RectangleF(bounds.Left, bounds.Top - 45, bounds.Width, font.Height);
            else
                annotationBounds = new RectangleF(bounds.Left + 20, bounds.Top - 45, bounds.Width - 20, font.Height);
            //Create document link annotation with bounds. 
            PdfDocumentLinkAnnotation annotation = new PdfDocumentLinkAnnotation(annotationBounds, pdfDestination);
            annotation.Border.Width = 0;
            //Add annotation to PDF page. 
            page.Annotations.Add(annotation);

            //Measure the text size to draw in PDF page. 
            string str = text + ' ';
            float width = isTitle ? font.MeasureString(text).Width + 20 : font.MeasureString(text).Width + 40;

            for (float i = width; i < 470;)
            {
                str = str + '.';
                i = i + 3.6140000000000003F;
            }

            //Create text element and draw it to PDF page. 
            PdfTextElement element = new PdfTextElement(str, font, PdfBrushes.Black);

            if (isTitle)
                bounds = new RectangleF(bounds.Left, bounds.Top + 5, bounds.Width, bounds.Height);
            else
                bounds = new RectangleF(bounds.Left + 20, bounds.Top + 5, bounds.Width, bounds.Height);

            return element.Draw(page, bounds);

        }
        /// <summary>
        /// Add a bookmark to bookmark collection. 
        /// </summary>
        PdfBookmark AddBookmark(PdfPage page, string text, PointF point, PdfDocument doc, PdfBookmark bookmark, PdfColor color)
        {
            PdfBookmark book;
            if (doc != null)
            {
                //Create and add a bookmark. 
                book = doc.Bookmarks.Add(text);
                //Set destination for bookmark. 
                book.Destination = new PdfDestination(page, point);
            }
            else
            {
                //Create and add a bookmark. 
                book = bookmark.Add(text);
                //Set destination for bookmark. 
                book.Destination = new PdfDestination(page, point);
            }

            book.Color = color;
            return book;
        }
        #endregion
    }
}
