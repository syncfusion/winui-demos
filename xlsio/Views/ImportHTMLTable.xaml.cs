#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.XlsIO;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System.IO;
using Windows.Storage;
using Windows.Storage.Pickers;
using System.Collections.Generic;
using Windows.Storage.Streams;
using System.Reflection;

namespace syncfusion.xlsiodemos.winui.Views
{
    /// <summary>
    /// Interaction logic for ImportHTMLTable.xaml
    /// </summary>
    public partial class ImportHTMLTable : Page
    {
        # region Constructor
        /// <summary>
        /// ImportHTMLTable constructor
        /// </summary>
        public ImportHTMLTable()
        {
            this.InitializeComponent();
        }
        # endregion      

        # region Events
        /// <summary>
        /// Imports spreadsheet
        /// </summary>
        /// <param name="sender">Contains a reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            // New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            // The instantiation process consists of two steps.

            // Step 1 : Instantiate the spreadsheet creation engine.
            using (ExcelEngine excelEngine = new ExcelEngine())
            {

                // Step 2 : Instantiate the excel application object.
                IApplication application = excelEngine.Excel;

                // A workbook is created.
                IWorkbook workbook = application.Workbooks.Create(1);

                workbook.Version = ExcelVersion.Xlsx;

                // The first worksheet object in the worksheets collection is accessed.
                IWorksheet sheet = workbook.Worksheets[0];

                string inputPath = "syncfusion.xlsiodemos.winui.Assets.XlsIO.HTMLToExcel.html";
                Assembly assembly = typeof(ImportHTMLTable).GetTypeInfo().Assembly;
                Stream input = assembly.GetManifestResourceStream(inputPath);
                sheet.ImportHtmlTable(input, 1, 1);

                sheet.UsedRange.AutofitColumns();

                sheet.UsedRange.AutofitRows();

                string filename = "Import-HTML-Table.xlsx";

                MemoryStream stream = new MemoryStream();
                workbook.SaveAs(stream);
                Save(stream, filename);                
                input.Dispose();
                stream.Dispose();   
            }
        }

        /// <summary>
        /// Opens input template
        /// </summary>
        /// <param name="sender">Contains a reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void btnInput_Click(object sender, RoutedEventArgs e)
        {
            //Launching the Input Template using the default Application.[MS Excel Or Free ExcelViewer]
            string inputPath = "syncfusion.xlsiodemos.winui.Assets.XlsIO.HTMLToExcel.html";
            Assembly assembly = typeof(ImportHTMLTable).GetTypeInfo().Assembly;
            Stream input = assembly.GetManifestResourceStream(inputPath);
            InputTemplate obj = new InputTemplate();
            obj.GetInputTeamplate(input, "HTMLToExcel.html", ".html");
            input.Dispose();
        }
        #endregion

        #region HelperMethods
        /// <summary>
        ///Used to save the output file
        /// </summary>
        /// <param name="stream">Memory stream to store the output file</param>
        /// <param name="filename">Output file name</param>
        async void Save(MemoryStream stream, string filename)
        {
            StorageFile stFile;
            if (!(Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons")))
            {
                FileSavePicker savePicker = new FileSavePicker();
                {
                    savePicker.DefaultFileExtension = ".xlsx";
                    savePicker.SuggestedFileName = filename;
                    savePicker.FileTypeChoices.Add("Excel Documents", new List<string>() { ".xlsx" });
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
        #endregion
    }
}
