#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
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

namespace Syncfusion.PdfDemos.WinUI
{
    public sealed partial class TiffToPdf : Page
    {
        public TiffToPdf()
        {
            this.InitializeComponent();
        }

        private void GeneratePDF_Click(object sender, RoutedEventArgs e)
        {
            //Get the image file stream from assembly.
            Assembly assembly = typeof(TiffToPdf).GetTypeInfo().Assembly;
            string path = "Syncfusion.PdfDemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.Pdf.";
#endif
            Stream imageFileStream = assembly.GetManifestResourceStream(path + "Assets.image.tiff");
            //Create a new PDF document
            PdfDocument document = new PdfDocument();
            //Set margin to the page
            document.PageSettings.Margins.All = 0;
            //Load Multiframe Tiff image
            PdfTiffImage tiffImage = new PdfTiffImage(imageFileStream);
            //Get the frame count
            int frameCount = tiffImage.FrameCount;
            //Access each frame and draw into the page
            
            for (int i = 0; i < frameCount; i++)
            {
                //Add new page for each frames
                PdfPage page = document.Pages.Add();
                //Get page graphics
                PdfGraphics graphics = page.Graphics;
                //Set active frame.
                tiffImage.ActiveFrame = i;
                //Draw Tiff image into page
                graphics.DrawImage(tiffImage, 0, 0, page.GetClientSize().Width, page.GetClientSize().Height);
            }

            //Creating the stream object.
            using (MemoryStream stream = new MemoryStream())
            {
                //Save the document into stream.
                document.Save(stream);
                document.Close();

                stream.Position = 0;

                //Save the output stream as a file using file picker.
                PdfUtil.Save("TiffToPdf.pdf", stream);
            }
        }
    }
}
