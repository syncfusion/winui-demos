#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.IO;
using Microsoft.UI.Xaml.Controls;
using System.Reflection;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using syncfusion.dociodemos.winui.Helpers;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;

namespace DocIO
{
    /// <summary>
    /// Integration logic for xaml.
    /// </summary>
    public sealed partial class ImageInsertion : Page
    {
        #region Constructor
        /// <summary>
        /// Initializes component.
        /// </summary>
        public ImageInsertion()
        {
            this.InitializeComponent();
        }
        #endregion

        #region Events
        /// <summary>
        /// Inserts images into the Word document.
        /// </summary>
        private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            //Creates a new Word document.
            using WordDocument document = new();
            //Adds a new section to the document.
            IWSection section = document.AddSection();
            section.PageSetup.Margins.All = 72;
            //Adds a paragraph to the section.
            IWParagraph paragraph = section.AddParagraph();
            //Writes the text.
            paragraph.AppendText("This sample demonstrates how to insert images in a Word document.");
            //Adds a new paragraph.
            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            paragraph.ParagraphFormat.BeforeSpacing = 12f;
            Assembly assembly = typeof(ImageInsertion).GetTypeInfo().Assembly;
            string basePath = "syncfusion.dociodemos.winui.Assets.DocIO.";
            Stream imageStream = assembly.GetManifestResourceStream(basePath + "AdventureCycle.png");

            //Inserts .png image.
            WPicture picture = (WPicture)paragraph.AppendPicture(imageStream);
            //Scales the Image.
            picture.HeightScale = 25f;
            picture.WidthScale = 25f;
            //Adds Image caption.
            picture.AddCaption("Figure", CaptionNumberingFormat.Roman, CaptionPosition.AfterImage);
            ApplyFormattingForCaption(document.LastParagraph);

            //Inserts .jpg image.
            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            imageStream = assembly.GetManifestResourceStream(basePath + "Mountain200.jpg");
            picture = (WPicture)paragraph.AppendPicture(imageStream);
            //Adds Image caption.
            picture.AddCaption("Figure", CaptionNumberingFormat.Roman, CaptionPosition.AfterImage);
            ApplyFormattingForCaption(document.LastParagraph);

            //Inserts .bmp image.
            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            imageStream = assembly.GetManifestResourceStream(basePath + "Mountain300.bmp");
            picture = (WPicture)paragraph.AppendPicture(imageStream);
            //Adds Image caption.
            picture.AddCaption("Figure", CaptionNumberingFormat.Roman, CaptionPosition.AfterImage);
            ApplyFormattingForCaption(document.LastParagraph);

            //Inserts .jpg image.
            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            imageStream = assembly.GetManifestResourceStream(basePath + "Road550W.jpg");
            picture = (WPicture)paragraph.AppendPicture(imageStream);
            //Adds Image caption.
            picture.AddCaption("Figure", CaptionNumberingFormat.Roman, CaptionPosition.AfterImage);
            ApplyFormattingForCaption(document.LastParagraph);

            //Updates the fields in Word document.
            document.UpdateDocumentFields();

            #region Document SaveOption
            using MemoryStream ms = new();
            string filename = string.Empty;
            //Saves as .docx format.
            if (worddocx.IsChecked == true)
            {
                filename = "Image Insertion.docx";
                //Saves the Word document to the memory stream.
                document.Save(ms, FormatType.Docx);
            }
            //Saves as .doc format.
            else if (worddoc.IsChecked == true)
            {
                filename = "Image Insertion.doc";
                //Saves the Word document to the memory stream.
                document.Save(ms, FormatType.Doc);
            }
            //Saves as .pdf format.
            else if (pdf.IsChecked == true)
            {
                filename = "Image Insertion.pdf";
                //Creates a new DocIORenderer instance.
                using DocIORenderer renderer = new();
                //Converts Word document into PDF.
                using PdfDocument pdfDoc = renderer.ConvertToPDF(document);
                //Saves the PDF document to the memory stream.
                pdfDoc.Save(ms);
            }
            ms.Position = 0;
            //Saves the memory stream as file.
            SaveHelper.SaveAndLaunch(filename, ms);
            #endregion Document SaveOption
        }
        #endregion

        #region Helper methods
        /// <summary>
        /// Applies formatting for image caption paragraph.
        /// </summary>
        private static void ApplyFormattingForCaption(WParagraph paragraph)
        {
            //Sets Alignment to the caption.
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            //Sets after and before spacings.
            paragraph.ParagraphFormat.AfterSpacing = 24f;
            paragraph.ParagraphFormat.BeforeSpacing = 8f;
        }
        #endregion
    }
}