#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using System.Data.Common;

namespace Syncfusion.XlsIODemos.WinUI.Views
{
    /// <summary>
    /// Interaction logic for Slicer.xaml
    /// </summary>
    public partial class Slicer : Page
    {
        # region Constructor
        /// <summary>
        /// Slicer constructor
        /// </summary>
        public Slicer()
        {
            this.InitializeComponent();

            string[] findOptions = { "Requester", "Assignee", "Status" };

            for (int i = 0; i < findOptions.Length; i++)
            {
                Column1.Items.Add(findOptions[i]);
                Column2.Items.Add(findOptions[i]);
            }
            Column1.SelectedIndex = 0;
            Column2.SelectedIndex = 2;
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
            string inputPath = path + "Assets.XlsIO.TableSlicer.xlsx";

            Assembly assembly = typeof(Slicer).GetTypeInfo().Assembly;
            Stream input = assembly.GetManifestResourceStream(inputPath);
            InputTemplate obj = new InputTemplate();
            obj.GetInputTeamplate(input, "TableSlicer.xlsx", ".xlsx");
            input.Dispose();
        }

        /// <summary>
        /// Create Slicer
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event</param>
        /// <param name="e">contains the event data</param>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            string path = "Syncfusion.XlsIODemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.XlsIO.";
#endif
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                string inputPath = path + "Assets.XlsIO.TableSlicer.xlsx";
                Assembly assembly = typeof(Slicer).GetTypeInfo().Assembly;
                Stream input = assembly.GetManifestResourceStream(inputPath);
                IWorkbook workbook = excelEngine.Excel.Workbooks.Open(input, ExcelOpenType.Automatic);
                IWorksheet sheet = workbook.Worksheets[0];
                IListObject table = sheet.ListObjects[0];

                //Get the column id from the given column name
                int colId1 = GetColumnId(Column1.SelectedValue.ToString(), table);
                int colId2 = GetColumnId(Column2.SelectedValue.ToString(), table);

                //Add slicer for the table
                sheet.Slicers.Add(table, colId1, 11, 2);
                sheet.Slicers.Add(table, colId2, 11, 4);

                #region Workbook Save
                string filename = "Slicer.xlsx";
                MemoryStream stream = new MemoryStream();
                workbook.SaveAs(stream);
                stream.Position = 0;
                Save(stream, filename);
                #endregion

                #region Dispose
                input.Dispose();
                stream.Dispose();
                #endregion
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
                savePicker.DefaultFileExtension = ".xlsx";
                savePicker.SuggestedFileName = filename;
                savePicker.FileTypeChoices.Add("Excel Documents", new List<string>() { ".xlsx" });
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
        private int GetColumnId(String columnName, IListObject table)
        {
            int colId = 0;
            for (int i = 0; i < table.Columns.Count; i++)
            {
                if (table.Columns[i].Name == columnName)
                {
                    colId = i + 1;
                    break;
                }
            }
            return colId;
        }
        #endregion
    }
}