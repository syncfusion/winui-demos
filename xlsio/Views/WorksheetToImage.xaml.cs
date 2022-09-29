#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.XlsIO;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Reflection;
using System.IO;
using Windows.Storage;
using Windows.Storage.Pickers;
using System.Collections.Generic;
using Windows.Storage.Streams;
using Syncfusion.XlsIORenderer;
using Windows.UI.Popups;

namespace Syncfusion.XlsIODemos.WinUI.Views
{
    /// <summary>
    /// Interaction logic for WorksheetToImage.xaml
    /// </summary>
    public partial class WorksheetToImage : Page
    {
        # region Constructor
        /// <summary>
        /// WorksheetToImage constructor
        /// </summary>
        public WorksheetToImage()
        {
            this.InitializeComponent();           
        }
        # endregion

        #region Events
        /// <summary>
        /// Opens input template
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event</param>
        /// <param name="e">contains the event data</param>
        private void btnInput_Click(object sender, RoutedEventArgs e)
        {
            string path = "Syncfusion.XlsIODemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.XlsIO.";
#endif
            string inputPath = path + "Assets.XlsIO.ExpenseReport.xlsx";

            Assembly assembly = typeof(EditMacro).GetTypeInfo().Assembly;
            Stream input = assembly.GetManifestResourceStream(inputPath);
            InputTemplate obj = new InputTemplate();
            obj.GetInputTeamplate(input, "ExpenseReport.xlsx", ".xlsx");
        }

        /// <summary>
        /// Converts spreadsheet to Image
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event</param>
        /// <param name="e">contains the event data</param>
        private void btnConvertToImage_Click(object sender, RoutedEventArgs e)
        {
            string path = "Syncfusion.XlsIODemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.XlsIO.";
#endif
            // New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            // The instantiation process consists of two steps.

            // Step 1 : Instantiate the spreadsheet creation engine.
            using (ExcelEngine excelEngine = new ExcelEngine())
            {

                // Step 2 : Instantiate the excel application object.
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2007;
                application.XlsIORenderer = new XlsIORenderer.XlsIORenderer();

                // An existing workbook is opened.
                string inputPath = path + "Assets.XlsIO.ExpenseReport.xlsx";
                Assembly assembly = typeof(CreateSpreadsheet).GetTypeInfo().Assembly;
                Stream input = assembly.GetManifestResourceStream(inputPath);
                IWorkbook workbook = application.Workbooks.Open(input);

                // The first worksheet object in the worksheets collection is accessed.
                IWorksheet sheet = workbook.Worksheets[0];

                ExportImageOptions imageOptions = new ExportImageOptions();

                MemoryStream stream = new MemoryStream();
                // Save the image.
                if (this.rdbtnBitmap.IsChecked.Value)
                {
                    imageOptions.ImageFormat = ExportImageFormat.Png;

                    // Convert the worksheet to image
                    sheet.ConvertToImage(sheet.UsedRange, imageOptions, stream);
                    string filename = "WorksheetToImage.png";
                    Save(stream, filename, true, false);
                }
                else
                {
                    imageOptions.ImageFormat = ExportImageFormat.Jpeg;

                    // Convert the worksheet to image
                    sheet.ConvertToImage(sheet.UsedRange, imageOptions, stream);
                    string filename = "WorksheetToImage.jpeg";
                    Save(stream, filename, false, true);
                }
                                
                input.Dispose();
                stream.Dispose();
            }
        }
        #endregion

        #region HelperMethods
        async void Save(MemoryStream stream, string filename, bool isPNG, bool isJPEG)
        {

            StorageFile stFile;
            if (!(Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons")))
            {
                FileSavePicker savePicker = new FileSavePicker();
                if (isPNG)
                {
                    savePicker.DefaultFileExtension = ".png";
                    savePicker.SuggestedFileName = filename;
                    savePicker.FileTypeChoices.Add("Image Documents", new List<string>() { ".png" });
                }
                else if (isJPEG)
                {
                    savePicker.DefaultFileExtension = ".jpeg";
                    savePicker.SuggestedFileName = filename;
                    savePicker.FileTypeChoices.Add("Image Documents", new List<string>() { ".jpeg" });
                }

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
