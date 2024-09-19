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
using Windows.Storage;
using Windows.Storage.Pickers;
using System.Collections.Generic;
using Windows.Storage.Streams;
using Microsoft.UI.Xaml.Shapes;
using System.Reflection;
using System.Globalization;

namespace Syncfusion.XlsIODemos.WinUI.Views
{
    /// <summary>
    /// Interaction logic for Pivot Table.xaml
    /// </summary>
    public partial class PivotTable : Page
    {
        # region Constructor
        public PivotTable()
        {
            this.InitializeComponent();
        }
        # endregion        

        # region Events
        /// <summary>
        /// Create spreadsheet with Pivot Table
        /// </summary>
        /// <param name="sender">Contains a reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            string path = "Syncfusion.XlsIODemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.XlsIO.";
#endif
            //The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                //Step 2 : Instantiate the excel application object.
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Xlsx;

                string inputPath = path + "Assets.XlsIO.PivotTable.xlsx";
                Assembly assembly = typeof(PivotTable).GetTypeInfo().Assembly;
                Stream input = assembly.GetManifestResourceStream(inputPath);
                IWorkbook workbook = excelEngine.Excel.Workbooks.Open(input, ExcelOpenType.Automatic);
                IWorksheet dataSheet = workbook.Worksheets[0];
                IWorksheet pivotSheet = workbook.Worksheets[1];

                #region Creating Pivot Table 
                IPivotCache cache = workbook.PivotCaches.Add(dataSheet["A1:H50"]);

                //Insert the pivot table. 
                IPivotTable pivotTable = pivotSheet.PivotTables.Add("PivotTable1", pivotSheet["A1"], cache);
                if (chkboxApplyGrouping.IsChecked.Value)
                    pivotTable.Fields[0].Axis = PivotAxisTypes.Row;
                pivotTable.Fields[2].Axis = PivotAxisTypes.Row;
                pivotTable.Fields[4].Axis = PivotAxisTypes.Row;
                pivotTable.Fields[3].Axis = PivotAxisTypes.Column;

                IPivotField field1 = pivotSheet.PivotTables[0].Fields[5];
                pivotTable.DataFields.Add(field1, "Sum of Units", PivotSubtotalTypes.Sum);

                //Apply grouping to the pivot table
                if (chkboxApplyGrouping.IsChecked.Value)
                {
                    IPivotFieldGroup group = pivotTable.Fields[0].FieldGroup;
                    group.GroupBy = PivotFieldGroupType.Years | PivotFieldGroupType.Quarters | PivotFieldGroupType.Months;
                }
                //Apply built in style.
                pivotTable.ShowDrillIndicators = true;
                pivotTable.RowGrand = true;
                pivotTable.DisplayFieldCaptions = true;
                pivotTable.BuiltInStyle = PivotBuiltInStyles.PivotStyleMedium2;
                //Activate the pivot sheet.
                pivotSheet.Activate();

                #endregion

                // Save and close the document
                string filename = "PivotTable.xlsx";
                MemoryStream stream = new MemoryStream();
                workbook.SaveAs(stream);
                Save(stream, filename);                
                stream.Dispose();
            }
        }
        #endregion

        #region Helper Method
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