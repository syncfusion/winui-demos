#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
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

namespace Syncfusion.PdfDemos.WinUI
{
    public sealed partial class ImageInsertion : Page
    {
        public ImageInsertion()
        {
            this.InitializeComponent();
        }

        private void GeneratePDF_Click(object sender, RoutedEventArgs e)
        {
            string path = "Syncfusion.PdfDemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.Pdf.";
#endif
            //Create a new PDF document.
            PdfDocument document = new PdfDocument();
            //Add page to the PDF document. 
            PdfPage page = document.Pages.Add();
            //Create font with size and style. 
            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Bold);
            //Create PDF graphics for the page.
            PdfGraphics graphics = page.Graphics;
            //Draw text to PDF page with font and location. 
            graphics.DrawString("JPEG Image", font, PdfBrushes.Blue, new PointF(0, 40));
            //Get the image file stream from assembly. 
            Stream jpgImageStream = typeof(ImageInsertion).GetTypeInfo().Assembly.GetManifestResourceStream(path + "Assets.Xamarin_JPEG.jpg");
            //Create new image from stream. 
            PdfImage jpgImage = new PdfBitmap(jpgImageStream);
            //Draw the JPEG image
            graphics.DrawImage(jpgImage, new RectangleF(0, 70, 515, 215));
            //Draw text to PDF page with font and location. 
            graphics.DrawString("PNG Image", font, PdfBrushes.Blue, new PointF(0, 355));
            //Get the image file stream from assembly. 
            Stream pngImageStream = typeof(ImageInsertion).GetTypeInfo().Assembly.GetManifestResourceStream(path + "Assets.Xamarin_PNG.png");
            //Create new image from stream. 
            PdfImage pngImage = new PdfBitmap(pngImageStream);
            //Draw the PNG image
            graphics.DrawImage(pngImage, new RectangleF(0, 375, 199, 300));

            //Creating the stream object.
            using (MemoryStream stream = new MemoryStream())
            {
                //Save the document into stream.
                document.Save(stream);
                document.Close();

                stream.Position = 0;

                //Save the output stream as a file using file picker.
                PdfUtil.Save("ImageInsertion.pdf", stream);
            }
        }
    }
}
