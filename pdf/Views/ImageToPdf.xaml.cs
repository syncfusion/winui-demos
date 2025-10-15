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
#nullable enable
namespace Syncfusion.PdfDemos.WinUI
{
    public sealed partial class ImageToPdf : Page
    {
        public ImageToPdf()
        {
            this.InitializeComponent();
        }

        private void GeneratePDF_Click(object sender, RoutedEventArgs e)
        {
            //Get the image file stream from assembly.
            Assembly assembly = typeof(ImageToPdf).GetTypeInfo().Assembly;
            string path = "Syncfusion.PdfDemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.Pdf.";
#endif
            List<Stream?> imageStreams = new List<Stream?>();
            for (int i = 1; i <= 6; i++)
            {
                Stream? jpgImageStream = assembly.GetManifestResourceStream(path + "Assets.pdf_succinctly_page" + i + ".jpg");
                imageStreams.Add(jpgImageStream);
            }
            //Create image to PDF converter.
            ImageToPdfConverter imageToPdfConverter = new ImageToPdfConverter();
            //Set image position.
            imageToPdfConverter.ImagePosition = PdfImagePosition.FitToPageAndMaintainAspectRatio;

            //Convert images to PDF file.
            PdfDocument document = imageToPdfConverter.Convert(imageStreams);

            //Creating the stream object.
            using (MemoryStream stream = new MemoryStream())
            {
                //Save the document into stream.
                document.Save(stream);
                document.Close();

                stream.Position = 0;

                //Save the output stream as a file using file picker.
                PdfUtil.Save("ImageToPdf.pdf", stream);
            }
        }
    }
}
