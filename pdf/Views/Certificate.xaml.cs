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
using System;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
using Syncfusion.Pdf.Graphics;

namespace Syncfusion.PdfDemos.WinUI
{
    public sealed partial class Certificate : Page
    {
        public Certificate()
        {
            this.InitializeComponent();
            date.Date = new DateTimeOffset(DateTime.Now);
            date.DateFormat = "{month.full} {day.integer}, {year.full}";
        }

        private void GeneratePdf_Click(object sender, RoutedEventArgs e)
        {
            //Create a new PDF document.
            PdfDocument document = new PdfDocument();
            //Set PDF landscape page orientiation. 
            document.PageSettings.Orientation = PdfPageOrientation.Landscape;
            //Set page margins. 
            document.PageSettings.Margins.All = 0;
            //Add page to the PDF document. 
            PdfPage page = document.Pages.Add();
            //Get the page size to draw the contents to PDF page. 
            SizeF pageSize = page.GetClientSize();

            string path = "Syncfusion.PdfDemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.Pdf.";
#endif

            //Get the image file stream from assembly.
            Stream imageStream = typeof(Certificate).GetTypeInfo().Assembly.GetManifestResourceStream(path + "Assets.certificate.jpg");
            //Load the PDF document from stream.
            PdfBitmap bitmapImage = new PdfBitmap(imageStream);
            //Draw the PDF bitmap image to PDF page with provided size. 
            page.Graphics.DrawImage(bitmapImage, new RectangleF(0, 0, pageSize.Width, pageSize.Height));

            //Create font with different size. 
            PdfFont nameFont = new PdfStandardFont(PdfFontFamily.Helvetica, 22);
            PdfFont controlFont = new PdfStandardFont(PdfFontFamily.Helvetica, 19);
            PdfFont dateFont = new PdfStandardFont(PdfFontFamily.Helvetica, 16);
            PdfBrush textBrush = new PdfSolidBrush(new PdfColor(20, 58, 86));

            //Find the X position based on text and font size. 
            float x = calculateXPosition(name.Text, nameFont, pageSize.Width);
            //Draw the string to specified location. 
            page.Graphics.DrawString(name.Text, nameFont, textBrush, new RectangleF(x, 253, 0, 0));

            //Find the X position based on text and font size. 
            x = calculateXPosition(courseName.Text, controlFont, pageSize.Width);
            //Draw the string to specified location. 
            page.Graphics.DrawString(courseName.Text, controlFont, textBrush, new RectangleF(x, 340, 0, 0));

            //Get date value from date picker field. 
            var dateTimeOffset = date.Date;
            DateTime time = dateTimeOffset.Value.DateTime;
            //Get the formatted Date to add in PDF page. 
            string formatedDate = "on " + time.ToString("MMMM d, yyyy");

            //Find the X position based on text and font size. 
            x = calculateXPosition(formatedDate, dateFont, pageSize.Width);
            //Draw the string to specified location. 
            page.Graphics.DrawString(formatedDate, dateFont, textBrush, new RectangleF(x, 385, 0, 0));

            //Creating the stream object.
            using (MemoryStream stream = new MemoryStream())
            {
                //Save and close the document.
                document.Save(stream);
                document.Close();

                stream.Position = 0;
                //Save the output stream as a file using file picker.
                PdfUtil.Save("Certificate.pdf", stream);
            }
        }

        float calculateXPosition(string text, PdfFont font, float pageWidth)
        {
            //Measure the text size based on the font size. 
            SizeF textSize = font.MeasureString(text, new SizeF(pageWidth, 0));
            return (pageWidth - textSize.Width) / 2;
        }
    }
}
