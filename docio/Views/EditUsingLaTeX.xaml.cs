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
using Syncfusion.DocIODemos.WinUI.Helpers;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;
using System.Collections.Generic;

namespace DocIO
{
    /// <summary>
    /// Integration logic for xaml.
    /// </summary>
    public sealed partial class EditUsingLaTeX : Page
    {
        #region Fields
        readonly Assembly assembly = typeof(EditUsingLaTeX).GetTypeInfo().Assembly;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes component.
        /// </summary>
        public EditUsingLaTeX()
        {
            this.InitializeComponent();
        }
        #endregion

        #region Events
        /// <summary>
        /// Creates a Word document.
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
            string resourcePath = path + "Assets.DocIO.EditEquationLaTeXInput.docx";
            using Stream fileStream = assembly.GetManifestResourceStream(resourcePath);
            //Creates a new Word document instance.
            using WordDocument document = new();
            //Opens an existing word document.
            document.Open(fileStream, FormatType.Docx);

            //Find all the equations in the Word document.
            List<Entity> entities = document.FindAllItemsByProperty(EntityType.Math, null, null);

            //Iterate through each equation in the Word document.
            foreach (Entity entity in entities)
            {
                WMath math = entity as WMath;
                //Get the laTeX code of equation.
                string laTeX = math.MathParagraph.LaTeX;

                //Modify the laTeX code of derivative equation.
                if (laTeX.StartsWith("\\frac"))
                    laTeX = laTeX.Replace("n", "k");
                //Modify the laTeX code of expansion of the sum equation.
                else if (laTeX.StartsWith("{\\left"))
                    laTeX = laTeX.Replace("n", "k");
                //Modify the laTeX code of quadratic equation.
                else if (laTeX.StartsWith("x=\\frac"))
                    laTeX = laTeX.Replace("x", "y");

                //Update the modified laTeX code to the equation.
                math.MathParagraph.LaTeX = laTeX;
            }

            #region Document SaveOption
            using MemoryStream ms = new();
            string filename = string.Empty;
            //Saves as .docx format.
            if (worddocx.IsChecked == true)
            {
                filename = "EditEquationLaTeX.docx";
                //Saves the Word document to the memory stream.
                document.Save(ms, FormatType.Docx);
            }
            //Saves as .pdf format.
            else if (pdf.IsChecked == true)
            {
                filename = "EditEquationLaTeX.pdf";
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
            string resourcePath = path + "Assets.DocIO.EditEquationLaTeXInput.docx";
            using Stream fileStream = assembly.GetManifestResourceStream(resourcePath);
            using MemoryStream ms = new();
            fileStream.CopyTo(ms);
            ms.Position = 0;
            //Saves the memory stream as file.
            SaveHelper.SaveAndLaunch("EditEquationLaTeXInput.docx", ms);
        }
        #endregion
    }
}
