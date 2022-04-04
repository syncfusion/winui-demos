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
using System.Collections.Generic;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;

namespace syncfusion.xlsiodemos.winui.Views
{
    /// <summary>
    /// Interaction logic for ExcelToJSON.xaml
    /// </summary>
    public partial class ExcelToJSON : Page
    {
        # region Constructor
        /// <summary>
        /// ExcelToJSON constructor
        /// </summary>
        public ExcelToJSON()
        {
            this.InitializeComponent();    

            string[] findOptions = { "Workbook", "Worksheet", "Range" };

            for (int i = 0; i < findOptions.Length; i++)
            {
                cmbConvert.Items.Add(findOptions[i]);
            }
            cmbConvert.SelectedIndex = 0;
            chkboxAsSchema.IsChecked = true;
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
            string inputPath = "syncfusion.xlsiodemos.winui.Assets.XlsIO.ExcelToJSON.xlsx";

            Assembly assembly = typeof(EditMacro).GetTypeInfo().Assembly;
            Stream input = assembly.GetManifestResourceStream(inputPath);
            InputTemplate obj = new InputTemplate();
            obj.GetInputTeamplate(input, "ExcelToJSON.xlsx", ".xlsx");
        }

        /// <summary>
        /// Convert To JSON
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event</param>
        /// <param name="e">contains the event data</param>
        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                string inputPath = "syncfusion.xlsiodemos.winui.Assets.XlsIO.ExcelToJSON.xlsx";
                Assembly assembly = typeof(ExcelToJSON).GetTypeInfo().Assembly;
                Stream input = assembly.GetManifestResourceStream(inputPath);
                IWorkbook workbook = excelEngine.Excel.Workbooks.Open(input, ExcelOpenType.Automatic);
                IWorksheet sheet = workbook.Worksheets[0];
                IRange range = sheet.Range["A2:B10"];

                bool isSchema = chkboxAsSchema.IsChecked.Value;

                string fileName = "ExcelToJSON.json";
                MemoryStream stream = new MemoryStream();

                if (cmbConvert.SelectedIndex == 0)
                {
                    workbook.SaveAsJson(stream, isSchema);
                    Save(stream, fileName);
                }
                else if (cmbConvert.SelectedIndex == 1)
                {
                    workbook.SaveAsJson(stream, sheet, isSchema);
                    Save(stream, fileName);
                }
                else if (cmbConvert.SelectedIndex == 2)
                {
                    workbook.SaveAsJson(stream, range, isSchema);
                    Save(stream, fileName);
                }
                                
                input.Dispose();
                stream.Dispose();
            }
        }
        #endregion

        #region HelperMethods
        async void Save(MemoryStream stream, string filename)
        {
            stream.Position = 0;

            StorageFile stFile;
            if (!(Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons")))
            {
                FileSavePicker savePicker = new FileSavePicker();
                savePicker.DefaultFileExtension = ".json";
                savePicker.SuggestedFileName = filename;
                savePicker.FileTypeChoices.Add("JSON Files", new List<string>() { ".json" });
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
                //Launch the saved file
                await Windows.System.Launcher.LaunchFileAsync(stFile);
            }
        }
        #endregion
    }
}