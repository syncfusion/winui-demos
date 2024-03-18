#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
using Syncfusion.Drawing;
using Syncfusion.DocIODemos.WinUI.Helpers;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;

namespace DocIO
{
    /// <summary>
    /// Integration logic for xaml.
    /// </summary>
    public sealed partial class LaTeX : Page
    {
        #region Fields
        readonly Assembly assembly = typeof(LaTeX).GetTypeInfo().Assembly;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes component.
        /// </summary>
        public LaTeX()
        {
            this.InitializeComponent();
        }
        #endregion

        #region Events
        /// <summary>
        /// Creates a simple Word document with text, image and table.
        /// </summary>
        private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            // Creates a new Word document.
            using WordDocument document = new();

            //Adds a new section to the document.
            WSection section = document.AddSection() as WSection;
            //Set page margins
            section.PageSetup.Margins.All = 72;
            // Sets page size of the section.
            section.PageSetup.PageSize = new SizeF(612, 792);
            //Add new paragraph to the section
            IWParagraph paragraph = section.AddParagraph();

            //Append text to paragraph
            IWTextRange textRange = paragraph.AppendText("Mathematical equation");
            textRange.CharacterFormat.FontSize = 28;
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            paragraph.ParagraphFormat.AfterSpacing = 12;

            //Add new paragraph to the section.
            paragraph = section.AddParagraph();
            //Append mathematical equation using LaTeX.
            if (!string.IsNullOrEmpty(this.laTeXText.Text))
                paragraph.AppendMath(this.laTeXText.Text);

            #region Document SaveOption
            using MemoryStream ms = new();
            string filename = string.Empty;
            //Saves as .docx format.
            if (worddocx.IsChecked == true)
            {
                filename = "LaTeXToMath.docx";
                //Saves the Word document to the memory stream.
                document.Save(ms, FormatType.Docx);
            }
            //Saves as .pdf format.
            else if (pdf.IsChecked == true)
            {
                filename = "LaTeXToMath.pdf";
                //Creates a new DocIORenderer instance.
                using DocIORenderer renderer = new();
                //Converts Word document into PDF.
                using PdfDocument pdfDoc = renderer.ConvertToPDF(document);
                //Saves the PDF document to the memory stream.
                pdfDoc.Save(ms);
            }
            PdfDocument.ClearFontCache();
            ms.Position = 0;
            //Saves the memory stream as file.
            SaveHelper.SaveAndLaunch(filename, ms);
            #endregion Document SaveOption

        }
        #endregion
    }
}
