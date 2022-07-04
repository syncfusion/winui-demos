#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

namespace Syncfusion.PdfDemos.WinUI
{
    public sealed partial class FindText : Page
    {
        public FindText()
        {
            this.InitializeComponent();
        }
       
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            string path = "Syncfusion.PdfDemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.Pdf.";
#endif
            string text = textbox.Text;

            // Get the template PDF file stream from assembly.
            Stream documentStream = typeof(FindText).GetTypeInfo().Assembly.GetManifestResourceStream(path + "Assets.pdf_succinctly.pdf");

            //Load the PDF document from stream.
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(documentStream);

            TextSearchResultCollection results;

            //Create list and add a string text to find from PDF document. 
            List<string> searchItem = new List<string>();
            searchItem.Add(text);

            //Find text from PDF document and get the result collection. 
            loadedDocument.FindText(searchItem, out results);

            //Iterate over the result collection. 
            foreach (var result in results)
            {
                //Get the PDF page using the result. 
                PdfLoadedPage page = loadedDocument.Pages[result.Key] as PdfLoadedPage;
                //Save the current graphics state. 
                page.Graphics.Save();
                //Set transparency to the page graphics.
                page.Graphics.SetTransparency(0.5F);

                foreach(var matchedItem in result.Value)
                {
                    //Draw rectangle to highlight the text in PDF page.
                    page.Graphics.DrawRectangle(PdfBrushes.Yellow, matchedItem.Bounds);

                }
                //Restore the graphics state. 
                page.Graphics.Restore();
            }

            //Creating the stream object.
            using (MemoryStream stream = new MemoryStream())
            {
                //Save and close the document.
                loadedDocument.Save(stream);
                loadedDocument.Close();

                stream.Position = 0;
                //Save the output stream as a file using file picker.
                PdfUtil.Save("FindText.pdf", stream);
            }
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            string path = "Syncfusion.PdfDemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.Pdf.";
#endif
            // Get the template PDF file stream from assembly.
            Stream documentStream = typeof(FindText).GetTypeInfo().Assembly.GetManifestResourceStream(path + "Assets.pdf_succinctly.pdf");

            //Load the PDF document from stream.
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(documentStream);

            //Creating the stream object.
            using (MemoryStream stream = new MemoryStream())
            {
                //Save and close the document.
                loadedDocument.Save(stream);
                loadedDocument.Close();

                stream.Position = 0;
                //Save the output stream as a file using file picker.
                PdfUtil.Save("FindText_Template.pdf", stream);
            }
        }
    }
}
