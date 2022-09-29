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
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

namespace Syncfusion.PdfDemos.WinUI
{
    public sealed partial class PdfWatermark : Page
    {
        public PdfWatermark()
        {
            this.InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string path = "Syncfusion.PdfDemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.Pdf.";
#endif
            //Get the template PDF file stream from assembly. 
            Stream documentStream = typeof(PdfWatermark).GetTypeInfo().Assembly.GetManifestResourceStream(path + "Assets.pdf_succinctly.pdf");
            //Load the PDF document from stream.
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(documentStream);
            //Create a new font instance.
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 36f);
            //Adding a watermark text to all the PDF pages. 
            foreach (PdfPageBase loadedPage in loadedDocument.Pages)
            {
                //Get the PDF page graphics.
                PdfGraphics graphics = loadedPage.Graphics;
                //Save the current graphics state. 
                PdfGraphicsState state = graphics.Save();
                //Set transparency to add a watermark text. 
                graphics.SetTransparency(0.25f);
                //Rotate the graphics to add a watermark text with 40 degree. 
                graphics.RotateTransform(-40);
                //Draw a watermark text to PDF page graphics. 
                graphics.DrawString(stampText.Text, font, PdfPens.Red, PdfBrushes.Red, new PointF(-150, 450));
                //Restore the graphics state. 
                graphics.Restore(state);
            }

            //Creating the stream object.
            using (MemoryStream stream = new MemoryStream())
            {
                //Save the document into stream.
                loadedDocument.Save(stream);
                loadedDocument.Close();

                stream.Position = 0;
                //Save the output stream as a file using file picker.
                PdfUtil.Save("PdfWatermark.pdf", stream);
            }
        }
    }
}
