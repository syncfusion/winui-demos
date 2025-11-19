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
using System.Reflection;
using System.Globalization;
using Syncfusion.XlsIORenderer;
using Syncfusion.Pdf;
using Syncfusion.XlsIO.Implementation.PivotTables;
using Windows.UI.Popups;

namespace Syncfusion.XlsIODemos.WinUI.Views
{
    /// <summary>
    /// Interaction logic for Pivot Table Layout.xaml
    /// </summary>
    public partial class PivotTableLayout : Page
    {
        # region Constructor
        public PivotTableLayout()
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

                string inputPath = path + "Assets.XlsIO.PivotTableLayout.xlsx";
                Assembly assembly = typeof(PivotTableLayout).GetTypeInfo().Assembly;
                Stream input = assembly.GetManifestResourceStream(inputPath);
                IWorkbook workbook = excelEngine.Excel.Workbooks.Open(input, ExcelOpenType.Automatic);
                IWorksheet dataSheet = workbook.Worksheets[0];
                IWorksheet pivotSheet = workbook.Worksheets[1];

                #region Creating Pivot Table 
                string layoutOption = string.Empty;
                if (this.rdbtnCompact.IsChecked.Value)
                    layoutOption = "Compact";
                else if (this.rdbtnOutline.IsChecked.Value)
                    layoutOption = "Outline";
                else if (this.rdbtnTabular.IsChecked.Value)
                    layoutOption = "Tabular";
				
                CreatePivotTable(workbook, layoutOption);
				
                IPivotTable pivotTable = workbook.Worksheets[1].PivotTables[0];
				
                pivotTable.Layout();

                //To view the pivot table inline formatting in MS Excel, we have to set the IsRefreshOnLoad property as true.
                (workbook.PivotCaches[pivotTable.CacheIndex] as PivotCacheImpl).IsRefreshOnLoad = true;
                #endregion

                // Save and close the document
                string filename = "PivotTableLayout.xlsx";
                MemoryStream stream = new MemoryStream();
                workbook.SaveAs(stream);
                Save(stream, filename);
                stream.Dispose();
                input.Dispose();
            }
        }
        
        private void btnConvert_Click(object sender, RoutedEventArgs e)
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

                string inputPath = path + "Assets.XlsIO.PivotTableLayout.xlsx";
                Assembly assembly = typeof(PivotTableLayout).GetTypeInfo().Assembly;
                Stream input = assembly.GetManifestResourceStream(inputPath);
                IWorkbook workbook = excelEngine.Excel.Workbooks.Open(input, ExcelOpenType.Automatic);
                IWorksheet dataSheet = workbook.Worksheets[0];
                
                #region Creating Pivot Table 
                string layoutOption = string.Empty;
                if (this.rdbtnCompact.IsChecked.Value)
                    layoutOption = "Compact";
                else if (this.rdbtnOutline.IsChecked.Value)
                    layoutOption = "Outline";
                else if (this.rdbtnTabular.IsChecked.Value)
                    layoutOption = "Tabular";

                CreatePivotTable(workbook, layoutOption);

                //Intialize the XlsIORenderer Class
                XlsIORenderer.XlsIORenderer renderer = new XlsIORenderer.XlsIORenderer();

                //Intialize the PdfDocument Class
                PdfDocument pdfDoc = new PdfDocument();

                //Intialize the ExcelToPdfConverterSettings class
                XlsIORendererSettings settings = new XlsIORendererSettings();
                settings.LayoutOptions = Syncfusion.XlsIORenderer.LayoutOptions.FitSheetOnOnePage;

                pdfDoc = renderer.ConvertToPDF(workbook, settings);

                #endregion
                // Save and close the document
                MemoryStream stream = new MemoryStream();
                pdfDoc.Save(stream);
                PdfDocument.ClearFontCache();
                Save(stream, "PivotTableLayout.pdf");
                stream.Dispose();
                input.Dispose();
            }
        }
        /// <summary>
        /// Create pivot table with layout
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="layoutOption"></param>
        private void CreatePivotTable(IWorkbook workbook, string layoutOption)
        {
            // The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];
            //Access the sheet to draw pivot table.
            IWorksheet pivotSheet = workbook.Worksheets[1];
            pivotSheet.Activate();
            //Select the data to add in cache
            IPivotCache cache = workbook.PivotCaches.Add(sheet["A1:G20"]);
            //Insert the pivot table. 
            IPivotTable pivotTable = pivotSheet.PivotTables.Add("PivotTable1", pivotSheet["A1"], cache);
            pivotTable.Fields[0].Axis = PivotAxisTypes.Row;
            pivotTable.Fields[1].Axis = PivotAxisTypes.Row;
            pivotTable.Fields[2].Axis = PivotAxisTypes.Row;
            IPivotField field1 = pivotSheet.PivotTables[0].Fields[5];
            pivotTable.DataFields.Add(field1, "Sum of Land Area", PivotSubtotalTypes.Sum);
            IPivotField field2 = pivotSheet.PivotTables[0].Fields[6];
            pivotTable.DataFields.Add(field2, "Sum of Water Area", PivotSubtotalTypes.Sum);

            if (layoutOption == "Outline")
            {
                pivotTable.Options.RowLayout = PivotTableRowLayout.Outline;

                pivotTable.Location = pivotSheet.Range[1, 1, 51, 5];

                //Apply Inline formatting to pivot table
                IPivotCellFormat cellFormat1 = pivotTable.GetCellFormat("B3:E4");
                cellFormat1.BackColorRGB = Syncfusion.Drawing.Color.FromArgb(255, 169, 208, 142);
                IPivotCellFormat cellFormat2 = pivotTable.GetCellFormat("B31:E32");
                cellFormat2.BackColorRGB = Syncfusion.Drawing.Color.FromArgb(255, 244, 176, 132);
            }
            else if (layoutOption == "Tabular")
            {
                pivotTable.Location = pivotSheet.Range[1, 1, 51, 5];

                pivotTable.Options.RowLayout = PivotTableRowLayout.Tabular;

                //Apply Inline formatting to pivot table
                IPivotCellFormat cellFormat1 = pivotTable.GetCellFormat("B2:E2");
                cellFormat1.BackColorRGB = Syncfusion.Drawing.Color.FromArgb(255, 169, 208, 142);
                IPivotCellFormat cellFormat2 = pivotTable.GetCellFormat("B30:E30");
                cellFormat2.BackColorRGB = Syncfusion.Drawing.Color.FromArgb(255, 244, 176, 132);
            }
            else
            {
                pivotTable.Location = pivotSheet.Range[1, 1, 51, 3];

                //Apply Inline formatting to pivot table
                IPivotCellFormat cellFormat1 = pivotTable.GetCellFormat("A3:C4");
                cellFormat1.BackColorRGB = Syncfusion.Drawing.Color.FromArgb(255, 169, 208, 142);
                IPivotCellFormat cellFormat2 = pivotTable.GetCellFormat("A31:C32");
                cellFormat2.BackColorRGB = Syncfusion.Drawing.Color.FromArgb(255, 244, 176, 132);
            }

            //Apply the show values row option in pivot table.
            pivotTable.Options.ShowValuesRow = true;

            //Apply built in style.
            pivotTable.BuiltInStyle = PivotBuiltInStyles.PivotStyleMedium9;
            pivotSheet.Range[1, 1, 1, 14].ColumnWidth = 11;
            pivotSheet.SetColumnWidth(1, 15.29);
            pivotSheet.SetColumnWidth(2, 15.29);

            if (pivotTable.Options.RowLayout == PivotTableRowLayout.Compact)
            {
                pivotSheet.SetColumnWidth(4, 1.0);
                pivotSheet.SetColumnWidth(5, 2.0);
                pivotSheet.SetColumnWidth(6, 0.5);
                pivotSheet.Range[2, 5, 2, 5].CellStyle.Color = Syncfusion.Drawing.Color.FromArgb(255, 169, 208, 142);
                pivotSheet.Range[4, 5, 4, 5].CellStyle.Color = Syncfusion.Drawing.Color.FromArgb(255, 244, 176, 132);
                pivotSheet.Range[2, 7, 2, 7].Text = "County with largest land area";
                pivotSheet.Range[4, 7, 4, 7].Text = "County with smallest land area";
            }
            else
            {
                pivotSheet.SetColumnWidth(6, 1.0);
                pivotSheet.SetColumnWidth(7, 2.0);
                pivotSheet.SetColumnWidth(8, 0.5);
                pivotSheet.Range[2, 7, 2, 7].CellStyle.Color = Syncfusion.Drawing.Color.FromArgb(255, 169, 208, 142);
                pivotSheet.Range[4, 7, 4, 7].CellStyle.Color = Syncfusion.Drawing.Color.FromArgb(255, 244, 176, 132);
                pivotSheet.Range[2, 9, 2, 9].Text = "County with largest land area";
                pivotSheet.Range[4, 9, 4, 9].Text = "County with smallest land area";
            }

            //Activate the pivot sheet.
            pivotSheet.Activate();
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
            string extension = Path.GetExtension(filename);
            StorageFile stFile;
            var hwnd = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            if (!(Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons")))
            {
                FileSavePicker savePicker = new FileSavePicker();
                if (extension == ".xlsx")
                {
                    savePicker.DefaultFileExtension = ".xlsx";
                    savePicker.SuggestedFileName = filename;
                    savePicker.FileTypeChoices.Add("Excel Documents", new List<string>() { ".xlsx" });
                }
                else if (extension == ".pdf")
                {
                    savePicker.DefaultFileExtension = ".pdf";
                    savePicker.SuggestedFileName = filename;
                    savePicker.FileTypeChoices.Add("Adobe PDF Document", new List<string>() { ".pdf" });
                }
                
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
                //Creates message dialog box. 
                MessageDialog msgDialog = new("Do you want to view the Document?", "File has been created successfully");
                UICommand yesCmd = new("Yes");
                msgDialog.Commands.Add(yesCmd);
                UICommand noCmd = new("No");
                msgDialog.Commands.Add(noCmd);

                WinRT.Interop.InitializeWithWindow.Initialize(msgDialog, hwnd);

                //Showing a dialog box. 
                IUICommand cmd = await msgDialog.ShowAsync();
                if (cmd.Label == yesCmd.Label)
                {
                    //Launch the saved file. 
                    await Windows.System.Launcher.LaunchFileAsync(stFile);
                }
            }
        }
        #endregion
    }
}