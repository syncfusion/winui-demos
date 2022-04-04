#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.IO;
using Microsoft.UI.Xaml.Controls;
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
    public sealed partial class Bookmarks : Page
    {
        #region Constructor
        /// <summary>
        /// Initializes component.
        /// </summary>
        public Bookmarks()
        {
            this.InitializeComponent();
        }
        #endregion

        #region Events
        /// <summary>
        /// Appends bookmarks into the Word document.
        /// </summary>
        private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            //Creates a new Word document.
            using WordDocument document = new();
            //Adds a section to the document.
            IWSection section = document.AddSection();
            //Adds a new paragraph to the section.
            IWParagraph paragraph = section.AddParagraph();
            //Appends text.
            paragraph.AppendText("This document demonstrates Essential DocIO's Bookmark functionality.").CharacterFormat.FontSize = 14f;
            //Adds paragraph to the section.
            section.AddParagraph();
            paragraph = section.AddParagraph();
            paragraph.AppendText("1. Inserting Bookmark Text").CharacterFormat.FontSize = 12f;

            //Adds paragraph to the section.
            section.AddParagraph();
            paragraph = section.AddParagraph();

            #region Bookmark Creation
            //Appends BookmarkStart.
            paragraph.AppendBookmarkStart("Bookmark");
            //Appends text.
            paragraph.AppendText("Bookmark Text");
            //Appends BookmarkEnd.
            paragraph.AppendBookmarkEnd("Bookmark");

            //Adds paragraph to the section.
            section.AddParagraph();
            paragraph = section.AddParagraph();
            //Indicates hidden bookmark text start.
            paragraph.AppendBookmarkStart("_HiddenText");
            //Appends bookmark text.
            paragraph.AppendText("2. Hidden Bookmark Text").CharacterFormat.Font = new Syncfusion.Drawing.Font("Comic Sans MS", 10);
            //Indicates hidden bookmark text end.
            paragraph.AppendBookmarkEnd("_HiddenText");

            section.AddParagraph();
            paragraph = section.AddParagraph();
            paragraph.AppendText("3. Nested Bookmarks").CharacterFormat.FontSize = 12f;

            //Appends nested bookmarks.
            section.AddParagraph();
            paragraph = section.AddParagraph();
            paragraph.AppendBookmarkStart("Main");
            paragraph.AppendText(" Main data ");
            paragraph.AppendBookmarkStart("Nested");
            paragraph.AppendText(" Nested data ");
            paragraph.AppendBookmarkStart("NestedNested");
            paragraph.AppendText(" Nested Nested ");
            paragraph.AppendBookmarkEnd("NestedNested");
            paragraph.AppendText(" data Nested ");
            paragraph.AppendBookmarkEnd("Nested");
            paragraph.AppendText(" Data Main ");
            paragraph.AppendBookmarkEnd("Main");
            #endregion Bookmark Creation

            #region Document SaveOption
            using MemoryStream ms = new();
            string filename = string.Empty;
            //Saves as .docx format.
            if (worddocx.IsChecked == true)
            {
                filename = "Bookmarks.docx";
                //Saves the Word document to the memory stream.
                document.Save(ms, FormatType.Docx);
            }
            //Saves as .doc format.
            else if (worddoc.IsChecked == true)
            {
                filename = "Bookmarks.doc";
                //Saves the Word document to the memory stream.
                document.Save(ms, FormatType.Doc);
            }
            //Saves as .pdf format.
            else if (pdf.IsChecked == true)
            {
                filename = "Bookmarks.pdf";
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
    }
}
