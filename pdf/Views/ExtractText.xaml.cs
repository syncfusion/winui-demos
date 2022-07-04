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
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;

namespace Syncfusion.PdfDemos.WinUI
{
    public sealed partial class ExtractText : Page
    {
        public ExtractText()
        {
            this.InitializeComponent();

        }
        
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            string path = "Syncfusion.PdfDemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.Pdf.";
#endif
            //Get the input PDF file stream from assembly.
            Stream documentStream = typeof(ExtractText).GetTypeInfo().Assembly.GetManifestResourceStream(path + "Assets.pdf_succinctly.pdf");

            //Load the PDF document from stream.
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(documentStream);

            //Extract the text from all the pages and get the text result. 
            string text = string.Empty;
            foreach (PdfLoadedPage page in loadedDocument.Pages) {
                text += page.ExtractText(true);
            }

            //Close the document.
            loadedDocument.Close();

            //Show the extracted text in a dialog.
            PdfUtil.ShowDialog(text, "Extracted Text");

        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string path = "Syncfusion.PdfDemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.Pdf.";
#endif
            // Get the template PDF file stream from assembly.
            Stream documentStream = typeof(ExtractText).GetTypeInfo().Assembly.GetManifestResourceStream(path + "Assets.pdf_succinctly.pdf");

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
                PdfUtil.Save("ExtractText_Template.pdf", stream);
            }
        }
    }
}
