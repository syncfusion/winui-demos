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
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.Storage.Pickers;
using Syncfusion.UI.Xaml.DataGrid.Export;
using Syncfusion.XlsIO;
using Syncfusion.Drawing;
using Syncfusion.UI.Xaml.DataGrid;
using Syncfusion.UI.Xaml.Data;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DataGrid
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ExcelExporting : Page, IDisposable
    {
        double totalPrice = 0d;
        public ExcelExporting()
        {
            this.InitializeComponent();;
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
            try
            {
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

        private void exportingDataGrid_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            var options = new DataGridExcelExportOptions();
            options.ExcelVersion = ExcelVersion.Excel2013;
            options.CanExportUnboundRows = ExportUnboundRows.IsChecked == true;
            options.CanExportStackedHeaders = ExportStackedHeaders.IsChecked == true;
            if (ColumnStyle.IsChecked == true)
                options.CellsExportHandler = CellsExportHandler;

            if (OrderIDColumn.IsChecked == false)
                options.ExcludedColumns.Add("OrderID");

            if (OrderDateColumn.IsChecked == false)
                options.ExcludedColumns.Add("OrderDate");

            if (ShippingCityColumn.IsChecked == false)
                options.ExcludedColumns.Add("ShipCity");

            if (ShippingCountryColumn.IsChecked == false)
                options.ExcludedColumns.Add("ShipAddress");

            if (QuantityColumn.IsChecked == false)
                options.ExcludedColumns.Add("Quantity");

            if (UnitPriceColumn.IsChecked == false)
                options.ExcludedColumns.Add("UnitPrice");

            var excelEngine = sfDataGrid.ExportToExcel(sfDataGrid.View, options);
            var workBook = excelEngine.Excel.Workbooks[0];
            MemoryStream outputStream = new MemoryStream();
            workBook.SaveAs(outputStream);
            Save(outputStream, "OrderDetails");
        }

        private void exportSelectedItems_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            var options = new DataGridExcelExportOptions();
            options.ExcelVersion = ExcelVersion.Excel2013;
            if (CellStyle.IsChecked == true)
                options.GridExportHandler = GridExportHandler;

            var excelEngine = sfDataGrid.ExportToExcel(sfDataGrid.SelectedItems, options);
            var workBook = excelEngine.Excel.Workbooks[0];
            MemoryStream outputStream = new MemoryStream();
            workBook.SaveAs(outputStream);
            Save(outputStream, "SelectedOrders");
        }
        private void GridExportHandler(object sender, DataGridExcelExportStartOptions e)
        {
            if (e.CellType == ExportCellType.RecordCell)
            {
                e.Style.ColorIndex = ExcelKnownColors.Sea_green;
                e.Style.Font.Color = ExcelKnownColors.White;
            }
        }

        private void CellsExportHandler(object sender, DataGridCellExcelExportOptions e)
        {
            if (e.ColumnName == "UnitPrice")
            {
                e.Range.CellStyle.ColorIndex = ExcelKnownColors.Blue_grey;
                e.Range.CellStyle.Font.Color = ExcelKnownColors.Light_yellow;
            }
        }

        private void sfDataGrid_SelectionChanged(object sender, Syncfusion.UI.Xaml.Grids.GridSelectionChangedEventArgs e)
        {
            if (this.sfDataGrid.SelectedItems.Count > 0)
            {
                this.exportSelectedItems.IsEnabled = true;
                NoteTextBlock.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
            }
            else
            {
                this.exportSelectedItems.IsEnabled = false;
                NoteTextBlock.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
            }
        }

        private void sfDataGrid_QueryUnboundRow(object sender, Syncfusion.UI.Xaml.DataGrid.GridUnboundRowEventsArgs e)
        {
            if (totalPrice == 0)
                return;

            if (e.UnboundAction == UnboundActions.QueryData)
            {
                if (e.RowColumnIndex.ColumnIndex == 5)
                {
                    e.Value = "Total Price : " + totalPrice.ToString("C2");                    
                    e.Handled = true;
                }
            }
        }

        private void sfDataGrid_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            foreach (GridColumn column in this.sfDataGrid.Columns)
            {
                if (column.MappingName == "UnitPrice")
                    totalPrice = GetValue(column.MappingName);
            }

            // Refresh the UnboundRows.
            this.sfDataGrid.InValidateUnboundRow(this.sfDataGrid.UnboundRows[0]);
            var visualContainer = this.sfDataGrid.GetType().GetProperty("VisualContainer", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(this.sfDataGrid) as VisualContainer;
            if (visualContainer != null)
                visualContainer.InvalidateMeasureInfo();
        }
        double GetValue(string column)
        {
            double total = 0.0;
            var view = this.sfDataGrid.View;
            foreach (var data in view.Records)
            {
                if (column.Equals("UnitPrice"))
                    total += ((data as RecordEntry).Data as OrderInfo).UnitPrice;
            }
            return total;
        }
        public void Dispose()
        {
            this.Resources.Clear();
            this.exportDataGrid.Click -= exportingDataGrid_Click;
            this.exportSelectedItems.Click -= exportSelectedItems_Click;
            if (this.sfDataGrid != null)
            {
                this.sfDataGrid.SelectionChanged -= sfDataGrid_SelectionChanged;
                this.sfDataGrid.QueryUnboundRow -= sfDataGrid_QueryUnboundRow;
                this.sfDataGrid.Loaded -= sfDataGrid_Loaded;
                this.sfDataGrid.Dispose();
            }
            if (this.ExportStackedHeaders != null)
                this.ExportStackedHeaders = null;

            if (this.ExportUnboundRows != null)
                this.ExportUnboundRows = null;

            if (this.OrderIDColumn != null)
                this.OrderIDColumn = null;

            if (this.OrderDateColumn != null)
                this.OrderDateColumn = null;

            if (this.ShippingCityColumn != null)
                this.ShippingCityColumn = null;

            if (this.ShippingCountryColumn != null)
                this.ShippingCountryColumn = null;

            if (this.QuantityColumn != null)
                this.QuantityColumn = null;

            if (this.UnitPriceColumn != null)
                this.UnitPriceColumn = null;

            if (this.CellStyle != null)
                this.CellStyle = null;

            if (this.ColumnStyle != null)
                this.ColumnStyle = null;

            if (this.exportDataGrid != null)
                this.exportDataGrid = null;

            if (this.exportSelectedItems != null)
                this.exportSelectedItems = null;

        }
    }
}
