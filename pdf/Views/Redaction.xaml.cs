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
using Syncfusion.Pdf.Redaction;

namespace Syncfusion.PdfDemos.WinUI
{
    public sealed partial class Redaction : Page
    {
        public Redaction()
        {
            this.InitializeComponent();
        }
       
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            string path = "Syncfusion.PdfDemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.Pdf.";
#endif
            
            // Get the template PDF file stream from assembly.
            Stream documentStream = typeof(Redaction).GetTypeInfo().Assembly.GetManifestResourceStream(path + "Assets.RedactionTemplate.pdf");

            //Load the PDF document from stream.
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(documentStream);

            PdfLoadedPage lpage = loadedDocument.Pages[0] as PdfLoadedPage;

            //Create PDF redaction for the page to redact text 
            PdfRedaction textRedaction = new PdfRedaction(new Syncfusion.Drawing.RectangleF(477f, 154f, 62.709f, 16.802f), Syncfusion.Drawing.Color.Black);

            PdfRedaction textRedaction2 = new PdfRedaction(new Syncfusion.Drawing.RectangleF(70, 240, 65.709f, 16.802f), Syncfusion.Drawing.Color.Black);

            lpage.AddRedaction(textRedaction);
            lpage.AddRedaction(textRedaction2);
            loadedDocument.Redact();

            //Creating the stream object.
            using (MemoryStream stream = new MemoryStream())
            {
                //Save and close the document.
                loadedDocument.Save(stream);
                loadedDocument.Close();

                stream.Position = 0;
                //Save the output stream as a file using file picker.
                PdfUtil.Save("Redaction.pdf", stream);
            }
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            string path = "Syncfusion.PdfDemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.Pdf.";
#endif
            // Get the template PDF file stream from assembly.
            Stream documentStream = typeof(Redaction).GetTypeInfo().Assembly.GetManifestResourceStream(path + "Assets.RedactionTemplate.pdf");

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
                PdfUtil.Save("RedactionTemplate.pdf", stream);
            }
        }
    }
}
