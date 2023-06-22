#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.IO;
using System.Reflection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Security;
using Syncfusion.Pdf.Parsing;

namespace Syncfusion.PdfDemos.WinUI
{
    public sealed partial class Encryption : Page
    {
        public Encryption()
        {
            this.InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string path = "Syncfusion.PdfDemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.Pdf.";
#endif
            //Get the template PDF file stream from assembly.
            Stream documentStream = typeof(Encryption).GetTypeInfo().Assembly.GetManifestResourceStream(path + "Assets.credit_card_statement.pdf");
            //Load the PDF document from stream.
            PdfLoadedDocument document = new PdfLoadedDocument(documentStream);

            //Get the document security.
            PdfSecurity security = document.Security;

            //Specify key size and encryption algorithm.
            if (encryptionTechnique.SelectionBoxItem.ToString() == "40-Bit RC4")
            {
                //use 40 bits key in RC4 mode.
                security.KeySize = PdfEncryptionKeySize.Key40Bit;
                security.Algorithm = PdfEncryptionAlgorithm.RC4;
            }
            else if (encryptionTechnique.SelectionBoxItem.ToString() == "128-Bit RC4")
            {
                //use 128 bits key in RC4 mode.
                security.KeySize = PdfEncryptionKeySize.Key128Bit;
                security.Algorithm = PdfEncryptionAlgorithm.RC4;
            }
            else if (encryptionTechnique.SelectionBoxItem.ToString() == "128-Bit AES")
            {
                //use 128 bits key in RC4 mode.
                security.KeySize = PdfEncryptionKeySize.Key128Bit;
                security.Algorithm = PdfEncryptionAlgorithm.AES;
            }
            else if (encryptionTechnique.SelectionBoxItem.ToString() == "256-Bit AES")
            {
                //use 256 bits key in AES mode.
                security.KeySize = PdfEncryptionKeySize.Key256Bit;
                security.Algorithm = PdfEncryptionAlgorithm.AES;
            }
            else if (encryptionTechnique.SelectionBoxItem.ToString() == "256-Bit AES Revision 6")
            {
                //use 256 bits key in AES mode with Revision 6.
                security.KeySize = PdfEncryptionKeySize.Key256BitRevision6;
                security.Algorithm = PdfEncryptionAlgorithm.AES;
            }

            //Set the PdfEncryption option to encrypt the document.  
            if (!cmbencryptOption.IsEnabled || cmbencryptOption.SelectedIndex == 0)
                security.EncryptionOptions = PdfEncryptionOptions.EncryptAllContents;
            else if (cmbencryptOption.SelectedIndex == 1)
                security.EncryptionOptions = PdfEncryptionOptions.EncryptAllContentsExceptMetadata;
            else if (cmbencryptOption.SelectedIndex == 2)
            {
                //Read a file from assembly to add an attachment. 
                Stream imageStream = typeof(Encryption).GetTypeInfo().Assembly.GetManifestResourceStream(path + "Assets.credit_card_statement.xml");

                //Create PdfAttachment from stream. 
                PdfAttachment attachment = new PdfAttachment("PDF.xml", imageStream);
                attachment.ModificationDate = DateTime.Now;
                attachment.Description = "Product details";
                attachment.MimeType = "application/xml";

                if (document.Attachments == null)
                    document.CreateAttachment();

                //Adds the attachment to the document.
                document.Attachments.Add(attachment);
                security.EncryptionOptions = PdfEncryptionOptions.EncryptOnlyAttachments;
            }

            //Set the user and owner password.
            security.OwnerPassword = txtOwnerPassword.Text;
            security.UserPassword = txtUserPassword.Text;

            //Set the permission flags for the file. 
            security.Permissions = PdfPermissionsFlags.Print | PdfPermissionsFlags.FullQualityPrint;

            //Creating the stream object.
            using (MemoryStream stream = new MemoryStream())
            {
                //Save and close the document.
                document.Save(stream);
                document.Close(true);

                stream.Position = 0;
                //Save the output stream as a file using file picker.
                PdfUtil.Save("Encryption.pdf", stream);
            }
        }
        private void EncryptionTechnique_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combobox = sender as ComboBox;
            if (combobox.SelectedIndex == 0 || combobox.SelectedIndex == 1)
            {
                cmbencryptOption.IsEnabled = false;
            }
            else
                cmbencryptOption.IsEnabled = true;
        }
    }
}
