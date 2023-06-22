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
using Syncfusion.Pdf.Parsing;

namespace Syncfusion.PdfDemos.WinUI
{
    public sealed partial class ImportAndExport : Page
    {
        public ImportAndExport()
        {
            this.InitializeComponent();

        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)import.IsChecked)
                ImportData();
            else
                ExportData();
        }

        private void ExportData()
        {
            string path = "Syncfusion.PdfDemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.Pdf.";
#endif
            //Get the template PDF file stream from assembly.
            Stream documentStream = typeof(ImportAndExport).GetTypeInfo().Assembly.GetManifestResourceStream(path + "Assets.export_template.pdf");
            //Load the PDF document from stream.
            PdfLoadedDocument document = new PdfLoadedDocument(documentStream);

            //Creating the stream object to store the exported data.
            using (MemoryStream stream = new MemoryStream())
            {
                string title = string.Empty;
                //Initialize export form setting to export form data. 
                ExportFormSettings exportFormSettings = new ExportFormSettings();
                if ((bool)fdf.IsChecked)
                {
                    title = "FDF Data";
                    //Set data format to export form data to FDF format. 
                    exportFormSettings.DataFormat = DataFormat.Fdf;
                }
                else if ((bool)xfdf.IsChecked)
                {
                    title = "XFDF Data";
                    //Set data format to export form data to XFDF format. 
                    exportFormSettings.DataFormat = DataFormat.XFdf;
                }
                else
                {
                    title = "XML Data";
                    //Set data format to export form data to XML format. 
                    exportFormSettings.DataFormat = DataFormat.Xml;
                }
                //Export the form data to stream with provided export form settings. 
                document.Form.ExportData(stream, exportFormSettings);
                //Close the document. 
                document.Close();

                stream.Position = 0;
                //Get the exported text value from stream. 
                StreamReader reader = new StreamReader(stream);
                string content = reader.ReadToEnd();
                //Open the exported text in dialog box. 
                PdfUtil.ShowDialog(content, title);
            }
        }
        private void ImportData()
        {
            string path = "Syncfusion.PdfDemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.Pdf.";
#endif
            //Get the template PDF file stream from assembly.
            Stream documentStream = typeof(ImportAndExport).GetTypeInfo().Assembly.GetManifestResourceStream(path + "Assets.form_template.pdf");

            //Load the PDF document from stream.
            PdfLoadedDocument document = new PdfLoadedDocument(documentStream);

            //Initialize import form setting to import form data. 
            ImportFormSettings settings = new ImportFormSettings();

            string fileName = string.Empty;
            if ((bool)fdf.IsChecked)
            {
                //Set data format to import form data from FDF format. 
                settings.DataFormat = DataFormat.Fdf;
                fileName = "import_data.fdf";

            }
            else if ((bool)xfdf.IsChecked)
            {
                //Set data format to import form data from XFDF format. 
                settings.DataFormat = DataFormat.XFdf;
                fileName = "import_data.xfdf";
            }
            else
            {
                //Set data format to import form data from XML format. 
                settings.DataFormat = DataFormat.Xml;
                fileName = "import_data.xml";
            }
            //Get the data file stream to import.
            Stream dataStream = typeof(ImportAndExport).GetTypeInfo().Assembly.GetManifestResourceStream(path + "Assets." + fileName);

            //Import form data from stream
            document.Form.ImportData(dataStream, settings);

            //Creating the stream object.
            using (MemoryStream stream = new MemoryStream())
            {
                //Save and close the document.
                document.Save(stream);
                document.Close();

                stream.Position = 0;
                //Save the output stream as a file using file picker.
                PdfUtil.Save("ImportedDocument.pdf", stream);
            }
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string path = "Syncfusion.PdfDemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.Pdf.";
#endif
            Stream documentStream;
            string fileName = string.Empty;

            if ((bool)import.IsChecked)
            {
                //Get the import template PDF file stream from assembly. 
                documentStream = typeof(ImportAndExport).GetTypeInfo().Assembly.GetManifestResourceStream(path + "Assets.form_template.pdf");
                fileName = "ImportForm_Template.pdf";
            }
            else 
            {
                //Get the export template PDF file stream from assembly. 
                documentStream = typeof(ImportAndExport).GetTypeInfo().Assembly.GetManifestResourceStream(path + "Assets.export_template.pdf");
                fileName = "ExportForm_Template.pdf";
            }
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
                PdfUtil.Save(fileName, stream);
            }
        }

        private void export_Checked(object sender, RoutedEventArgs e)
        {
            btn.Content = "Export Form Data";
        }

        private void import_Checked(object sender, RoutedEventArgs e)
        {
            btn.Content = "Import Form Data";
        }
    }
}
