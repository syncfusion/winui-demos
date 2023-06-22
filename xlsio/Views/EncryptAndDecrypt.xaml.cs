#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
using System.Reflection;
using Windows.Storage;
using Windows.Storage.Pickers;
using System.Collections.Generic;
using Windows.Storage.Streams;

namespace Syncfusion.XlsIODemos.WinUI.Views
{
    /// <summary>
    /// Interaction logic for EncryptAndDecrypt.xaml
    /// </summary>
    public partial class EncryptAndDecrypt : Page
    {
        # region Constructor
        /// <summary>
        /// EncryptAndDecrypt constructor
        /// </summary>
        public EncryptAndDecrypt()
        {
            this.InitializeComponent();
        }
        # endregion      

        #region Events
        /// <summary>
        /// Encrypt the selected spreadsheet
        /// </summary>
        /// <param name="sender">Contains a reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            string path = "Syncfusion.XlsIODemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.XlsIO.";
#endif
            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                //Step 2 : Instantiate the excel application object.
                IApplication application = excelEngine.Excel;

                application.DefaultVersion = ExcelVersion.Xlsx;

                //Opening the Existing Workbook.              
                string inputPath = path + "Assets.XlsIO.Encrypt.xlsx";

                Assembly assembly = typeof(EncryptAndDecrypt).GetTypeInfo().Assembly;
                Stream input = assembly.GetManifestResourceStream(inputPath);
                IWorkbook workbook = application.Workbooks.Open(input);

                //Encrypt the workbook with password.
                workbook.PasswordToOpen = "syncfusion";

                //Save the workbook to disk.
                string fileName = "EncryptedWorkbook";
                if (rdbtnXLS.IsChecked.Value)
                {
                    workbook.Version = ExcelVersion.Excel97to2003;
                    fileName = fileName + ".xls";
                    MemoryStream stream = new MemoryStream();
                    workbook.SaveAs(stream);
                    Save(stream, fileName, true, false);                    
                    stream.Dispose();
                }
                else
                {

                    fileName = fileName + ".xlsx";
                    MemoryStream stream = new MemoryStream();
                    workbook.SaveAs(stream);
                    Save(stream, fileName, false, true);                    
                    stream.Dispose();
                }
                input.Dispose();
            }
        }

        /// <summary>
        /// Decrypt the selected spreadsheet
        /// </summary>
        /// <param name="sender">Contains a reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            string path = "Syncfusion.XlsIODemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.XlsIO.";
#endif
            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                //Step 2 : Instantiate the excel application object.
                IApplication application = excelEngine.Excel;

                application.DefaultVersion = ExcelVersion.Xlsx;

                // Opening the encrypted Workbook.            
                string inputPath = path + "Assets.XlsIO.EncryptedSpreadsheet.xlsx";

                Assembly assembly = typeof(EncryptAndDecrypt).GetTypeInfo().Assembly;
                var input = assembly.GetManifestResourceStream(inputPath);
                IWorkbook workbook = application.Workbooks.Open(input, ExcelParseOptions.Default, true, "syncfusion");

                //Modify the decrypted document.
                workbook.Worksheets[0].Range["B2"].Text = "Demo for workbook decryption with Essential XlsIO";
                workbook.Worksheets[0].Range["B5"].Text = "This document is decrypted using password 'syncfusion'";

                workbook.PasswordToOpen = "";

                //Save the workbook to disk.
                string fileName = "DecryptedWorkbook";
                if (rdbtnXLS.IsChecked.Value)
                {
                    workbook.Version = ExcelVersion.Excel97to2003;
                    fileName = fileName + ".xls";
                    //Saving the workbook to disk.
                    MemoryStream stream = new MemoryStream();
                    workbook.SaveAs(stream);
                    Save(stream, fileName, true, false);
                    stream.Dispose();
                }
                else
                {
                    fileName = fileName + ".xlsx";
                    //Saving the workbook to disk.
                    MemoryStream stream = new MemoryStream();
                    workbook.SaveAs(stream);
                    Save(stream, fileName, false, true);
                    stream.Dispose();
                }
            }                
        }
        #endregion

        #region HelperMethods
        /// <summary>
        ///Used to save the output file
        /// </summary>
        /// <param name="stream">Memory stream to store the output file</param>
        /// <param name="filename">Output file name</param>
        /// <param name="isXls">Boolean value indicates whether the file type is Xls or not</param>
        /// <param name="isXlsx">Boolean value indicates whether the file type is Xlsx or not</param>
        async void Save(MemoryStream stream, string filename, bool isXls, bool isXlsx)
        {
            StorageFile stFile;
            if (!(Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons")))
            {
                FileSavePicker savePicker = new FileSavePicker();
                if (isXlsx)
                {
                    savePicker.DefaultFileExtension = ".xlsx";
                    savePicker.SuggestedFileName = filename;
                    savePicker.FileTypeChoices.Add("Excel Documents", new List<string>() { ".xlsx" });
                }
                else if (isXls)
                {
                    savePicker.DefaultFileExtension = ".xls";
                    savePicker.SuggestedFileName = filename;
                    savePicker.FileTypeChoices.Add("Excel Documents", new List<string>() { ".xls" });
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