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
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using Syncfusion.Pdf.Graphics;

namespace Syncfusion.PdfDemos.WinUI
{
    public sealed partial class DigitalSignature : Page
    {
        public DigitalSignature()
        {
            this.InitializeComponent();

        }
        
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            string path = "Syncfusion.PdfDemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.Pdf.";
#endif
            //Get the template PDF file stream from assembly. 
            Stream documentStream = typeof(DigitalSignature).GetTypeInfo().Assembly.GetManifestResourceStream(path + "Assets.digital_signature_template.pdf");
            //Load the PDF document from stream.
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(documentStream);
            //Get the .pfx certificate file stream.
            Stream certificateStream = typeof(DigitalSignature).GetTypeInfo().Assembly.GetManifestResourceStream(path + "Assets.certificate.pfx");
            //Get the signature field to add digital signature. 
            PdfLoadedSignatureField signatureField = loadedDocument.Form.Fields[6] as PdfLoadedSignatureField;
            //Get the signature bounds. 
            RectangleF bounds = signatureField.Bounds;
            
            //Create PDF certificate using certificate stream and password.
            PdfCertificate pdfCertificate = new PdfCertificate(certificateStream, "password123");

            //Add certificate to first page of the document.
            PdfSignature signature = new PdfSignature(loadedDocument, loadedDocument.Pages[0], pdfCertificate, "", signatureField);
            signature.ContactInfo = "johndoe@owned.us";
            signature.LocationInfo = "Honolulu, Hawaii";
            signature.Reason = "I am author of this document.";

            //Set the cryptographic standard to signature settings. 
            if ((bool)cms.IsChecked)
                signature.Settings.CryptographicStandard = CryptographicStandard.CMS;
            else
                signature.Settings.CryptographicStandard = CryptographicStandard.CADES;

            //Set the digest algorithm to signature settings. 
            if ((bool)sha1.IsChecked)
                signature.Settings.DigestAlgorithm = DigestAlgorithm.SHA1;
            else if ((bool)sha256.IsChecked)
                signature.Settings.DigestAlgorithm = DigestAlgorithm.SHA256;
            else if ((bool)sha384.IsChecked)
                signature.Settings.DigestAlgorithm = DigestAlgorithm.SHA384;
            else if ((bool)sha512.IsChecked)
                signature.Settings.DigestAlgorithm = DigestAlgorithm.SHA512;

            //Get the signature field appearance graphics.
            PdfGraphics graphics = signature.Appearance.Normal.Graphics;
            if (graphics != null)
            {
                //Draw the rectangle in appearance graphics.
                graphics.DrawRectangle(PdfPens.Black, bounds);

                //Get the image file stream from assembly. 
                Stream imageStream = typeof(DigitalSignature).GetTypeInfo().Assembly.GetManifestResourceStream(path + "Assets.signature.png");
                //Create the PDF bitmap image from stream. 
                PdfBitmap bitmap = new PdfBitmap(imageStream, true);
                //Draw image to appearance graphics. 
                graphics.DrawImage(bitmap, new RectangleF(2, 1, 30, 30));

                //Get certificate subject name.
                string subject = pdfCertificate.SubjectName;

                //Create a new font instance and draw a text to appearance graphics. 
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 7);
                RectangleF textRect = new RectangleF(45, 0, bounds.Width - 45, bounds.Height);
                PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Justify);
                graphics.DrawString("Digitally signed by "+ subject + " \r\nReason: Testing signature \r\nLocation: USA", font, PdfBrushes.Black, textRect , format);
            }

            //Set the digital signature to signing the field. 
            signatureField.Signature = signature;

            //Creating the stream object.
            using (MemoryStream stream = new MemoryStream())
            {
                //Save and close the document.
                loadedDocument.Save(stream);
                loadedDocument.Close();

                stream.Position = 0;
                //Save the output stream as a file using file picker. 
                PdfUtil.Save("DigitalSignature.pdf", stream);
            }
        }
    }
}
