#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.XlsIO;
using System.ComponentModel;
using Syncfusion.Office;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Reflection;
using System.IO;
using Windows.Storage;
using Windows.Storage.Pickers;
using System.Collections.Generic;
using Windows.Storage.Streams;

namespace syncfusion.xlsiodemos.winui.Views
{
    /// <summary>
    /// Interaction logic for EditMacro.xaml
    /// </summary>
    public partial class EditMacro : Page
    {
        # region Constructor
        /// <summary>
        /// EditMacro constructor
        /// </summary>
        public EditMacro()
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
            string inputPath = "syncfusion.xlsiodemos.winui.Assets.XlsIO.EditMacroTemplate.xltm";

            Assembly assembly = typeof(EditMacro).GetTypeInfo().Assembly;
            Stream input = assembly.GetManifestResourceStream(inputPath);
            InputTemplate obj = new InputTemplate();
            obj.GetInputTeamplate(input, "EditMacroTemplate.xltm", ".xltm");
            input.Dispose();
        }
        /// <summary>
        /// Edits and saves the macro file
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event</param>
        /// <param name="e">contains the event data</param>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {            
            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                //Step 2 : Instantiate the excel application object.
                IApplication application = excelEngine.Excel;

                #region Initialize Workbook
                //An existing macro-enabled workbook is opened.[Equivalent to the workbook in MS Excel]
                IWorkbook workbook;
                string inputPath = "syncfusion.xlsiodemos.winui.Assets.XlsIO.EditMacroTemplate.xltm";
                Assembly assembly = typeof(EditMacro).GetTypeInfo().Assembly;
                Stream input = assembly.GetManifestResourceStream(inputPath);
                workbook = application.Workbooks.Open(input, ExcelOpenType.Automatic);

                //The first worksheet object in the worksheets collection is accessed.
                IWorksheet worksheet = workbook.Worksheets[0];
                #endregion

                #region Edit Macro
                IVbaProject vbaProject = workbook.VbaProject;
                IVbaModule vbaModule = vbaProject.Modules["Module1"];
                vbaModule.Code = vbaModule.Code.Replace("xlAreaStacked", "xlLine");
                #endregion

                #region Workbook Save
                string filename = "";
                MemoryStream stream = new MemoryStream();
                if (rdbtnXls.IsChecked.Value)
                {
                    filename = "EditMacro.xls";
                    workbook.Version = ExcelVersion.Excel97to2003;
                    workbook.SaveAs(stream);
                    Save(stream, filename, true, false, false);
                }
                else if (rdbtnXltm.IsChecked.Value)
                {
                    filename = "EditMacro.xltm";
                    workbook.SaveAs(stream, ExcelSaveType.SaveAsMacroTemplate);
                    Save(stream, filename, false, true, false);
                }
                else if (rdbtnXlsm.IsChecked.Value)
                {
                    filename = "EditMacro.xlsm";
                    workbook.SaveAs(stream, ExcelSaveType.SaveAsMacro);
                    Save(stream, filename, false, false, true);
                }
                #endregion

                #region Close and Dispose
                input.Dispose();
                stream.Dispose();
                #endregion
            }
        }
        # endregion

        #region HelperMethods
        async void Save(MemoryStream stream, string filename, bool isXLS, bool isXLTM, bool isXLSM)
        {

            StorageFile stFile;
            if (!(Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons")))
            {
                FileSavePicker savePicker = new FileSavePicker();
                if (isXLS)
                {
                    savePicker.DefaultFileExtension = ".xls";
                    savePicker.SuggestedFileName = filename;
                    savePicker.FileTypeChoices.Add("Excel Documents", new List<string>() { ".xls" });
                }
                else if (isXLTM)
                {
                    savePicker.DefaultFileExtension = ".xltm";
                    savePicker.SuggestedFileName = filename;
                    savePicker.FileTypeChoices.Add("Excel Documents", new List<string>() { ".xltm" });
                }
                else if (isXLSM)
                {
                    savePicker.DefaultFileExtension = ".xlsm";
                    savePicker.SuggestedFileName = filename;
                    savePicker.FileTypeChoices.Add("Excel Documents", new List<string>() { ".xlsm" });
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