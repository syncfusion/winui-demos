#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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
    public sealed partial class FindAndHighlight : Page
    {
        #region Fields
        readonly Assembly assembly = typeof(FindAndHighlight).GetTypeInfo().Assembly;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes component.
        /// </summary>
        public FindAndHighlight()
        {
            this.InitializeComponent();
        }
        #endregion

        #region Events
        /// <summary>
        /// Finds a specific text and highlight it in an existing Word document.
        /// </summary>
        private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            //Gets the input Word document.
            string resourcePath = "syncfusion.dociodemos.winui.Assets.DocIO.Adventure.docx";
            using Stream fileStream = assembly.GetManifestResourceStream(resourcePath);
            //Creates a new Word document instance.
            using WordDocument document = new();
            //Opens an existing word document.
            document.Open(fileStream, FormatType.Automatic);

            //Finds all occurrence of the text in the Word document.
            TextSelection[] textSelections = document.FindAll(FindTextBox.Text, false, false);
            for (int i = 0; i < textSelections.Length; i++)
            {
                //Sets the highlight color for the searched text as Green.
                textSelections[i].GetAsOneRange().CharacterFormat.HighlightColor = Syncfusion.Drawing.Color.Green;
            }

            #region Document SaveOption
            using MemoryStream ms = new();
            string filename = string.Empty;
            //Saves as .docx format.
            if (worddocx.IsChecked == true)
            {
                filename = "Find and Highlight.docx";
                //Saves the Word document to the memory stream.
                document.Save(ms, FormatType.Docx);
            }
            //Saves as .doc format.
            else if (worddoc.IsChecked == true)
            {
                filename = "Find and Highlight.doc";
                //Saves the Word document to the memory stream.
                document.Save(ms, FormatType.Doc);
            }
            //Saves as .pdf format.
            else if (pdf.IsChecked == true)
            {
                filename = "Find and Highlight.pdf";
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
        /// <summary>
        /// Opens the input template Word document.
        /// </summary>
        private void ButtonView_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            //Gets the input Word document.
            string resourcePath = "syncfusion.dociodemos.winui.Assets.DocIO.Adventure.docx";
            using Stream fileStream = assembly.GetManifestResourceStream(resourcePath);
            using MemoryStream ms = new();
            fileStream.CopyTo(ms);
            ms.Position = 0;
            //Saves the memory stream as file.
            SaveHelper.SaveAndLaunch("Adventure.docx", ms);
        }
        #endregion
    }
}
