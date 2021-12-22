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
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.Storage.Pickers;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

namespace syncfusion.pdfdemos.winui
{
    public sealed partial class MergePDF : Page, IDisposable
    {
        public MergePDF()
        {
            this.InitializeComponent();
        }
        private void MergePDF_Click(object sender, RoutedEventArgs e)
        {
            //Get template PDF file stream from assembly.
            if (firstDocumentStream == null)
                firstDocumentStream = typeof(MergePDF).GetTypeInfo().Assembly.GetManifestResourceStream("syncfusion.pdfdemos.winui.Assets.pdf_succinctly.pdf");
            //Get template PDF file stream from assembly.
            if (secondDocumentStream == null)
                secondDocumentStream = typeof(MergePDF).GetTypeInfo().Assembly.GetManifestResourceStream("syncfusion.pdfdemos.winui.Assets.form_template.pdf");

            //Load the PDF document from stream.
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(firstDocumentStream);

            //Load and merge the pdf documents.
            PdfDocument.Merge(loadedDocument, new PdfLoadedDocument(secondDocumentStream));

            //Creating the stream object.
            using (MemoryStream stream = new MemoryStream())
            {
                //Save and close the document.
                loadedDocument.Save(stream);
                loadedDocument.Close();

                stream.Position = 0;
                //Save the output stream as a file using file picker.
                PdfUtil.Save("MergePDF.pdf", stream);
            }
            Dispose();
        }

        //Stream object to hold the files picked from file picker. 
        Stream firstDocumentStream = null;
        Stream secondDocumentStream = null;
        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            //Create file open picker and set the .pdf file type. 
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            openPicker.ViewMode = PickerViewMode.List;
            openPicker.FileTypeFilter.Add(".pdf");

            //Get process windows handle to open the dialog in application process. 
            IntPtr windowHandle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            WinRT.Interop.InitializeWithWindow.Initialize(openPicker, windowHandle);

            //Pick the single file.
            StorageFile stFile = await openPicker.PickSingleFileAsync();

            if (stFile != null)
            {
                //Get the file name and update the source PDF field box. 
                FirstPdf.Text = stFile.Name;

                //Read the PDF file as file stream.
                IRandomAccessStream fileStream = await stFile.OpenAsync(FileAccessMode.ReadWrite);
                firstDocumentStream = fileStream.AsStreamForWrite();
            }
        }

        private async void button2_Click(object sender, RoutedEventArgs e)
        {
            //Create file open picker and set the .pdf file type. 
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            openPicker.ViewMode = PickerViewMode.List;
            openPicker.FileTypeFilter.Add(".pdf");
            
            //Get process windows handle to open the dialog in application process. 
            IntPtr windowHandle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            WinRT.Interop.InitializeWithWindow.Initialize(openPicker, windowHandle);

            //Pick the single file.
            StorageFile stFile = await openPicker.PickSingleFileAsync();

            if (stFile != null)
            {
                //Get the file name and update the file name in textbox. 
                SecondPdf.Text = stFile.Name;

                //Read the PDF file as file stream.
                IRandomAccessStream fileStream = await stFile.OpenAsync(FileAccessMode.ReadWrite);
                secondDocumentStream = fileStream.AsStreamForWrite();
            }
        }

        public void Dispose()
        {
            if (firstDocumentStream != null)
            {
                firstDocumentStream.Dispose();
                firstDocumentStream = null;
            }

            if (secondDocumentStream != null)
            {
                secondDocumentStream.Dispose();
                secondDocumentStream = null;
            }
        }
    }
}
