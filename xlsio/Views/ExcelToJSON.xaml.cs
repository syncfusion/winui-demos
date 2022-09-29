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
using Windows.UI.Popups;

namespace Syncfusion.XlsIODemos.WinUI.Views
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
            string path = "Syncfusion.XlsIODemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.XlsIO.";
#endif
            string inputPath = path + "Assets.XlsIO.ExcelToJSON.xlsx";

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
            string path = "Syncfusion.XlsIODemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.XlsIO.";
#endif
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                string inputPath = path + "Assets.XlsIO.ExcelToJSON.xlsx";
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