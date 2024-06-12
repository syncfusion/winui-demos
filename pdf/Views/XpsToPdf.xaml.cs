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
using Syncfusion.Pdf;
using Syncfusion.XPS;

namespace Syncfusion.PdfDemos.WinUI
{
    public sealed partial class XpsToPdf : Page
    {
        public XpsToPdf()
        {
            this.InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string path = "Syncfusion.PdfDemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.Pdf.";
#endif
            //Load XPS file to stream
            Stream documentStream = typeof(PdfWatermark).GetTypeInfo().Assembly.GetManifestResourceStream(path + "Assets.XPSToPDF.xps");

            XPSToPdfConverter converter = new XPSToPdfConverter();

            //Convert XPS document into PDF document
            PdfDocument document = converter.Convert(documentStream);

            //Creating the stream object.
            using (MemoryStream stream = new MemoryStream())
            {
                //Save the document into stream.
                document.Save(stream);
                //Close the PDF document
                document.Close(true);
                stream.Position = 0;
                //Save the output stream as a file using file picker.
                PdfUtil.Save("XPSToPDF.pdf", stream);
            }
        }
    }
}