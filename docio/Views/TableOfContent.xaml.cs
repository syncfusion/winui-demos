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
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;
using Syncfusion.DocIODemos.WinUI.Helpers;

namespace DocIO
{
    /// <summary>
    /// Integration logic for xaml.
    /// </summary>
    public sealed partial class TableOfContent : Page
    {
        #region Constructor
        /// <summary>
        /// Initializes component.
        /// </summary>
        public TableOfContent()
        {
            this.InitializeComponent();
        }
        #endregion

        #region Events
        /// <summary>
        /// Inserts and updates the Table of Contents (TOC) in a Word document.
        /// </summary>
        private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            //Creates a new Word document.
            using WordDocument document = new();
            //Adds one section and paragraph.
            document.EnsureMinimal();
            document.LastSection.PageSetup.Margins.All = 72;
            WParagraph para = document.LastParagraph;
            IWTextRange textRange = para.AppendText("Essential DocIO - Table of Contents");
            textRange.CharacterFormat.Bold = true;
            textRange.CharacterFormat.FontSize = 14;
            para.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            para.ParagraphFormat.BeforeSpacing = 12f;
            para.ParagraphFormat.AfterSpacing = 3f;

            para = document.LastSection.AddParagraph() as WParagraph;
            para.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            para.ParagraphFormat.BeforeSpacing = 12f;
            para.ParagraphFormat.AfterSpacing = 3f;

            if (!checkBox.IsChecked.Value)
            {
                textRange = para.AppendText("Select TOC and press F9 to update the Table of Contents");
                textRange.CharacterFormat.HighlightColor = Syncfusion.Drawing.Color.Yellow;
                textRange.CharacterFormat.Bold = true;
                textRange.CharacterFormat.FontSize = 14;
            }

            para = document.LastSection.AddParagraph() as WParagraph;
            //Inserts TOC.
            Syncfusion.DocIO.DLS.TableOfContent toc = para.AppendTOC(1, 3);
            para.ParagraphFormat.BeforeSpacing = 12f;
            para.ParagraphFormat.AfterSpacing = 3f;

            //Applies built-in paragraph formatting.
            WSection section = document.LastSection;

            #region Default Styles
            WParagraph newPara = section.AddParagraph() as WParagraph;
            newPara = section.AddParagraph() as WParagraph;
            newPara.AppendBreak(BreakType.PageBreak);
            WTextRange text = newPara.AppendText("Document with Default styles") as WTextRange;
            newPara.ApplyStyle(BuiltinStyle.Heading1);
            newPara = section.AddParagraph() as WParagraph;
            newPara.AppendText("This is the heading1 of built in style. This sample demonstrates the TOC insertion in a word document. Note that DocIO can only insert TOC field in a word document. It can not refresh or create TOC field. MS Word refreshes the TOC field after insertion. Please update the field or press F9 key to refresh the TOC.");

            section.AddParagraph();
            newPara = section.AddParagraph() as WParagraph;
            text = newPara.AppendText("Section1") as WTextRange;
            newPara.ApplyStyle(BuiltinStyle.Heading2);
            newPara = section.AddParagraph() as WParagraph;
            newPara.AppendText("This is the heading2 of built in style. A document can contain any number of sections. Sections are used to apply same formatting for a group of paragraphs. You can insert sections by inserting section breaks.");

            section.AddParagraph();
            newPara = section.AddParagraph() as WParagraph;
            text = newPara.AppendText("Paragraph1") as WTextRange;
            newPara.ApplyStyle(BuiltinStyle.Heading3);
            newPara = section.AddParagraph() as WParagraph;
            newPara.AppendText("This is the heading3 of built in style. Each section contains any number of paragraphs. A paragraph is a set of statements that gives a meaning for the text.");

            section.AddParagraph();
            newPara = section.AddParagraph() as WParagraph;
            text = newPara.AppendText("Paragraph2") as WTextRange;
            newPara.ApplyStyle(BuiltinStyle.Heading3);
            newPara = section.AddParagraph() as WParagraph;
            newPara.AppendText("This is the heading3 of built in style. This demonstrates the paragraphs at the same level and style as that of the previous one. A paragraph can have any number formatting. This can be attained by formatting each text range in the paragraph.");

            section.AddParagraph();
            section = document.AddSection() as WSection;
            section.PageSetup.Margins.All = 72;
            section.BreakCode = SectionBreakCode.NewPage;
            newPara = section.AddParagraph() as WParagraph;
            text = newPara.AppendText("Section2") as WTextRange;
            newPara.ApplyStyle(BuiltinStyle.Heading2);
            newPara = section.AddParagraph() as WParagraph;
            newPara.AppendText("This is the heading2 of built in style. A document can contain any number of sections. Sections are used to apply same formatting for a group of paragraphs. You can insert sections by inserting section breaks.");

            section.AddParagraph();
            newPara = section.AddParagraph() as WParagraph;
            text = newPara.AppendText("Paragraph1") as WTextRange;
            newPara.ApplyStyle(BuiltinStyle.Heading3);
            newPara = section.AddParagraph() as WParagraph;
            newPara.AppendText("This is the heading3 of built in style. Each section contains any number of paragraphs. A paragraph is a set of statements that gives a meaning for the text.");

            section.AddParagraph();
            newPara = section.AddParagraph() as WParagraph;
            text = newPara.AppendText("Paragraph2") as WTextRange;
            newPara.ApplyStyle(BuiltinStyle.Heading3);
            newPara = section.AddParagraph() as WParagraph;
            newPara.AppendText("This is the heading3 of built in style. This demonstrates the paragraphs at the same level and style as that of the previous one. A paragraph can have any number formatting. This can be attained by formatting each text range in the paragraph.");
            #endregion

            //Enables a flag to show page numbers in table of contents.
            toc.IncludePageNumbers = true;
            //Enables a flag to show page numbers as right aligned.
            toc.RightAlignPageNumbers = true;
            //Enables a flag to use hyperlinks for the levels.
            toc.UseHyperlinks = true;
            //Sets the starting heading level of the table of contents.
            toc.LowerHeadingLevel = 1;
            //Sets the ending heading level of the table of contents.
            toc.UpperHeadingLevel = 3;
            //Enables a flag to use outline levels.
            toc.UseOutlineLevels = true;

            //Updates the table of contents.
            if (checkBox.IsChecked.Value)
                document.UpdateTableOfContents();

            #region Document SaveOption
            using MemoryStream ms = new();
            string filename = string.Empty;
            //Saves as .docx format.
            if (worddocx.IsChecked == true)
            {
                filename = "Table of Contents.docx";
                //Saves the Word document to the memory stream.
                document.Save(ms, FormatType.Docx);
            }
            //Saves as .doc format.
            else if (worddoc.IsChecked == true)
            {
                filename = "Table of Contents.doc";
                //Saves the Word document to the memory stream.
                document.Save(ms, FormatType.Doc);
            }
            //Saves as .pdf format.
            else if (pdf.IsChecked == true)
            {
                filename = "Table of Contents.pdf";
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