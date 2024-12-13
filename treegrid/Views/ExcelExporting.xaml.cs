#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Syncfusion.UI.Xaml.TreeGrid;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Syncfusion.UI.Xaml.Data;
using Syncfusion.UI.Xaml.TreeGrid.Export;
using Syncfusion.XlsIO.Implementation;
using Syncfusion.XlsIO;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.Storage;
using Syncfusion.Drawing;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TreeGrid
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ExcelExporting : Page, IDisposable
    {
        public ExcelExporting()
        {
            this.InitializeComponent();      
        }

        async void Save(MemoryStream stream, string filename)
        {
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
                        byte[] buffer = stream.ToArray();
                        outstream.Write(buffer, 0, buffer.Length);
                        outstream.Flush();
                    }
                }
                //Launch the saved Excel file
                await Windows.System.Launcher.LaunchFileAsync(stFile);
            }
        }

        private void exportingTreeGrid_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            var options = new TreeGridExcelExportOptions();
            options.ExcelVersion = ExcelVersion.Excel2013;
            options.CanExportStackedHeaders = exportStackedHeaders.IsChecked == true;

            if (columnStyle.IsChecked == true)
                options.CellsExportHandler = CellsExportHandler;

            if (headerStyle.IsChecked == true)
                options.GridExportHandler = GridExportHandler;

            if (firstName.IsChecked == false)
                options.ExcludedColumns.Add("FirstName");

            if (lastName.IsChecked == false)
                options.ExcludedColumns.Add("LastName");

            if (employeeID.IsChecked == false)
                options.ExcludedColumns.Add("ID");

            if (dateofBirth.IsChecked == false)
                options.ExcludedColumns.Add("DOJ");

            if (salary.IsChecked == false)
                options.ExcludedColumns.Add("Salary");

            if (department.IsChecked == false)
                options.ExcludedColumns.Add("Department");

            var excelEngine = sfTreeGrid.ExportToExcel(options);
            var workBook = excelEngine.Excel.Workbooks[0];
            MemoryStream outputStream = new MemoryStream();
            workBook.SaveAs(outputStream);
            Save(outputStream, "EmployeeDetails");
        }

        private void GridExportHandler(object sender, TreeGridExcelExportStartOptions e)
        {
            if (e.CellType == ExportCellType.HeaderCell || e.CellType == ExportCellType.StackedHeaderCell)
            {
                e.Style.Color = Color.Red;
                e.Style.Font.Color = ExcelKnownColors.White;
                e.Handled = true;
            }
        }

        private void CellsExportHandler(object sender, TreeGridCellExcelExportOptions e)
        {
            if (e.ColumnName == "ID")
            {
                e.Range.CellStyle.ColorIndex = ExcelKnownColors.Blue_grey;
                e.Range.CellStyle.Font.Color = ExcelKnownColors.Light_yellow;
            }

        }

        public void Dispose()
        {
            this.Resources.Clear();
            this.exportTreeGrid.Click -= exportingTreeGrid_Click;
            if (this.sfTreeGrid != null)
                this.sfTreeGrid.Dispose();
            
            if (this.exportStackedHeaders != null)
                this.exportStackedHeaders = null;

            if (this.columnStyle != null)
                this.columnStyle = null;

            if (this.firstName != null)
                this.firstName = null;

            if (this.lastName != null)
                this.lastName = null;

            if (this.employeeID != null)
                this.employeeID = null;

            if (this.dateofBirth != null)
                this.dateofBirth = null;

            if (this.salary != null)
                this.salary = null;

            if (this.department != null)
                this.department = null;


            if (this.exportTreeGrid != null)
                this.exportTreeGrid = null;

        }
    }
}
