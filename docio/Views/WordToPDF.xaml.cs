#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;
using Syncfusion.DocIODemos.WinUI.Helpers;

namespace DocIO
{
    /// <summary>
    /// Integration logic for xaml.
    /// </summary>
    public sealed partial class WordToPDF : Page
    {
        #region Fields
        readonly Assembly assembly = typeof(WordToPDF).GetTypeInfo().Assembly;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes component.
        /// </summary>
        public WordToPDF()
        {
            this.InitializeComponent();
        }
        #endregion

        #region Events
        /// <summary>
        /// Converts Word document to PDF.
        /// </summary>
        private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            string path;
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.DocIO.";
#else
            path = "Syncfusion.DocIODemos.WinUI.";
#endif
            //Gets the input Word document.
            string resourcePath = path+"Assets.DocIO.WordtoPDF.docx";
            using Stream fileStream = assembly.GetManifestResourceStream(resourcePath);
            //Loads an existing Word document.
            using WordDocument document = new(fileStream, FormatType.Automatic);
            //Creates a new DocIORenderer instance.
            using DocIORenderer render = new();
            //Enables a flag to preserve document structured tags in the converted tagged PDF.
            if (checkBox1.IsChecked == true)
                render.Settings.AutoTag = true;
            //Enables a flag to preserve the Word document form field as editable PDF form field in PDF document.
            if (checkBox2.IsChecked == true)
                render.Settings.PreserveFormFields = true;
            //Sets ExportBookmarks for preserving Word document headings as PDF bookmarks.
            if (checkBox3.IsChecked == true)
                render.Settings.ExportBookmarks = Syncfusion.DocIO.ExportBookmarkType.Headings;

            #region Preserve track changes in PDF
            if (checkBox4.IsChecked == true)
            {
                //Enables to show the revision marks in the generated PDF for tracked changes or revisions in the Word document.
                document.RevisionOptions.ShowMarkup = RevisionType.Deletions | RevisionType.Formatting | RevisionType.Insertions;
                //Sets revision bars color as Black.
                document.RevisionOptions.RevisionBarsColor = RevisionColor.Black;
                //Sets revised properties (Formatting) color as Blue.
                document.RevisionOptions.RevisedPropertiesColor = RevisionColor.Blue;
                //Sets deleted text (Deletions) color as Yellow.
                document.RevisionOptions.DeletedTextColor = RevisionColor.Yellow;
                //Sets inserted text (Insertions) color as Pink.
                document.RevisionOptions.InsertedTextColor = RevisionColor.Pink;
            }
            #endregion

            #region Preserve comments in PDF
            if (checkBox5.IsChecked == true)
            {
                //Sets ShowInBalloons to render a document comments in converted PDF document.
                document.RevisionOptions.CommentDisplayMode = CommentDisplayMode.ShowInBalloons;
                //Sets the color to be used for Comment Balloon.
                document.RevisionOptions.CommentColor = RevisionColor.Blue;
            }
            #endregion

            //Converts Word document into PDF.
            using PdfDocument pdfDocument = render.ConvertToPDF(document);
            using MemoryStream ms = new();
            //Saves the converted PDF document to the memory stream.
            pdfDocument.Save(ms);
            PdfDocument.ClearFontCache();
            ms.Position = 0;
            //Saves the memory stream as file.
            SaveHelper.SaveAndLaunch("WordtoPDF.pdf", ms);
        }

        /// <summary>
        /// Opens the input template Word document.
        /// </summary>
        private void ButtonView_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            string path;
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.DocIO.";
#else
            path = "Syncfusion.DocIODemos.WinUI.";
#endif
            //Gets the input Word document.
            string resourcePath = path + "Assets.DocIO.WordtoPDF.docx";
            using Stream fileStream = assembly.GetManifestResourceStream(resourcePath);
            using MemoryStream ms = new();
            fileStream.CopyTo(ms);
            ms.Position = 0;
            //Saves the memory stream as file.
            SaveHelper.SaveAndLaunch("WordtoPDF.docx", ms);
        }
        #endregion
    }
}
