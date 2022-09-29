#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.IO;
using Syncfusion.XlsIO;
using Syncfusion.Pdf;
using Syncfusion.XlsIO.Implementation;
using System.Reflection;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using Windows.Storage;
using Windows.Storage.Pickers;
using System.Collections.Generic;
using Windows.Storage.Streams;
using Syncfusion.XlsIORenderer;
using Windows.UI.Popups;

namespace Syncfusion.XlsIODemos.WinUI.Views
{
    /// <summary>
    /// Interaction logic for ExcelToPDF1.xaml
    /// </summary>
    public partial class ExcelToPDF : Page
    {
        #region Constructor
        /// <summary>
        /// ExcelToPDF constructor
        /// </summary>
        public ExcelToPDF()
        {
            this.InitializeComponent();
        }
        #endregion

        #region Events
        /// <summary>
        /// Loads the input template
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event</param>
        /// <param name="e">contains the event data</param>
        private void btnInput_Click(object sender, RoutedEventArgs e)
        {
            string path = "Syncfusion.XlsIODemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.XlsIO.";
#endif
            string inputPath = path + "Assets.XlsIO.ExcelTopdfwithChart.xlsx";

            Assembly assembly = typeof(EditMacro).GetTypeInfo().Assembly;
            Stream input = assembly.GetManifestResourceStream(inputPath);
            InputTemplate obj = new InputTemplate();
            obj.GetInputTeamplate(input, "ExcelTopdfwithChart.xlsx", ".xlsx");
        }

        /// <summary>
        /// Convert Excel To PDF
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event</param>
        /// <param name="e">contains the event data</param>
        private void btnConvertToPDF_Click(object sender, RoutedEventArgs e)
        {
            string path = "Syncfusion.XlsIODemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.XlsIO.";
#endif
            using (ExcelEngine engine = new ExcelEngine())
            {
                IApplication application = engine.Excel;
                string inputPath = path + "Assets.XlsIO.ExcelTopdfwithChart.xlsx";
                Assembly assembly = typeof(ExcelToPDF).GetTypeInfo().Assembly;
                Stream input = assembly.GetManifestResourceStream(inputPath);
                IWorkbook book = application.Workbooks.Open(input);

                //Initialize XlsIORenderer
                XlsIORenderer.XlsIORenderer renderer = new XlsIORenderer.XlsIORenderer();

                //Intialize the PDFDocument
                PdfDocument pdfDoc = new PdfDocument();

                //Intialize the XlsIORendererSettings
                XlsIORendererSettings settings = new XlsIORendererSettings();

                if (this.rdbtnNoScaling.IsChecked.Value)
                    settings.LayoutOptions = LayoutOptions.NoScaling;
                else if (this.rdbtnFitAllRows.IsChecked.Value)
                    settings.LayoutOptions = LayoutOptions.FitAllRowsOnOnePage;
                else if (this.rdbtnFitAllCols.IsChecked.Value)
                    settings.LayoutOptions = LayoutOptions.FitAllColumnsOnOnePage;
                else
                    settings.LayoutOptions = LayoutOptions.FitSheetOnOnePage;

                //Assign the PdfDocument to the templateDocument property of XlsIORendererSettings
                settings.TemplateDocument = pdfDoc;
                settings.DisplayGridLines = GridLinesDisplayStyle.Invisible;

                //Convert Excel Document into PDF document
                pdfDoc = renderer.ConvertToPDF(book, settings);

                //Save the PDF file
                MemoryStream stream = new MemoryStream();
                pdfDoc.Save(stream);
                PdfDocument.ClearFontCache();
                Save(stream, "ExcelToPDF.pdf");

                #region Close and Dispose                
                pdfDoc.Dispose();
                input.Dispose();
                stream.Dispose();
                #endregion
            }
        }       
        #endregion

        #region HelperMethods
        async void Save(MemoryStream stream, string filename)
        {
            StorageFile stFile;
            if (!(Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons")))
            {
                FileSavePicker savePicker = new FileSavePicker();
                savePicker.DefaultFileExtension = ".pdf";
                savePicker.SuggestedFileName = "ExcelToPDF";
                savePicker.FileTypeChoices.Add("Adobe PDF Document", new List<string>() { ".pdf" });
                var hwnd = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
                WinRT.Interop.InitializeWithWindow.Initialize(savePicker, hwnd);
                stFile = await savePicker.PickSaveFileAsync();
            }
            else
            {
                StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
                stFile = await local.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            }
            try
            {
                if (stFile != null)
                {
                    using (IRandomAccessStream zipStream = await stFile.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        //Write compressed data from memory to file
                        using (Stream outstream = zipStream.AsStreamForWrite())
                        {
                            outstream.SetLength(0);
                            byte[] buffer = stream.ToArray();
                            outstream.Write(buffer, 0, buffer.Length);
                            outstream.Flush();
                        }
                    }
                    //Launch the saved Excel file
                    await Windows.System.Launcher.LaunchFileAsync(stFile);
                }

            }
            catch (Exception ex)
            {
                //Gets process windows handle to open the dialog in application process.
                IntPtr windowHandle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
 
                if (ex.Message.Contains("Access is denied."))
                {
                    //Creates message dialog box.
                    MessageDialog msgDialogBox = new("The file cannot be saved in this location due to access being denied." +
                        " Kindly provide permission to save the file in this location or save the file in another location.", "File Access Denied");
                    UICommand okCmd = new("Ok");
                    msgDialogBox.Commands.Add(okCmd);
                    WinRT.Interop.InitializeWithWindow.Initialize(msgDialogBox, windowHandle);
                    //Showing a dialog box. 
                    IUICommand msgCmd = await msgDialogBox.ShowAsync();
                }
            }
        }
        #endregion
    }
}
