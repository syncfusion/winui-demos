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

namespace Syncfusion.XlsIODemos.WinUI.Views
{
    /// <summary>
    /// Interaction logic for Tables.xaml
    /// </summary>
    public partial class Tables : Page
    {
        # region Constructor
        public Tables()
        {
            this.InitializeComponent();
        }
        # endregion        

        # region Events
        /// <summary>
        /// Create spreadsheet with Table
        /// </summary>
        /// <param name="sender">Contains a reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                //Step 2 : Instantiate the excel application object.
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Xlsx;

                IWorkbook workbook = application.Workbooks.Create(1);
                IWorksheet worksheet = workbook.Worksheets[0];

                #region Table data
                // Create data
                worksheet[1, 1].Text = "Products";
                worksheet[1, 2].Text = "Qtr1";
                worksheet[1, 3].Text = "Qtr2";
                worksheet[1, 4].Text = "Qtr3";
                worksheet[1, 5].Text = "Qtr4";

                worksheet[2, 1].Text = "Alfreds Futterkiste";
                worksheet[2, 2].Number = 744.6;
                worksheet[2, 3].Number = 162.56;
                worksheet[2, 4].Number = 5079.6;
                worksheet[2, 5].Number = 1249.2;

                worksheet[3, 1].Text = "Antonio Moreno Taqueria";
                worksheet[3, 2].Number = 5079.6;
                worksheet[3, 3].Number = 1249.2;
                worksheet[3, 4].Number = 943.89;
                worksheet[3, 5].Number = 349.6;

                worksheet[4, 1].Text = "Around the Horn";
                worksheet[4, 2].Number = 1267.5;
                worksheet[4, 3].Number = 1062.5;
                worksheet[4, 4].Number = 744.6;
                worksheet[4, 5].Number = 162.56;

                worksheet[5, 1].Text = "Bon app";
                worksheet[5, 2].Number = 1418;
                worksheet[5, 3].Number = 756;
                worksheet[5, 4].Number = 1267.5;
                worksheet[5, 5].Number = 1062.5;

                worksheet[6, 1].Text = "Eastern Connection";
                worksheet[6, 2].Number = 4728;
                worksheet[6, 3].Number = 4547.92;
                worksheet[6, 4].Number = 1418;
                worksheet[6, 5].Number = 756;

                worksheet[7, 1].Text = "Ernst Handel";
                worksheet[7, 2].Number = 943.89;
                worksheet[7, 3].Number = 349.6;
                worksheet[7, 4].Number = 4728;
                worksheet[7, 5].Number = 4547.92;
                #endregion

                // Create style for table number format
                IStyle style1 = workbook.Styles.Add("CurrencyFormat");
                style1.NumberFormat = "_($* #,##0.00_);_($* (#,##0.00);_($* \" - \"??_);_(@_)";

                // Apply number format
                worksheet["B2:E8"].CellStyleName = "CurrencyFormat";

                // Create table
                IListObject table1 = worksheet.ListObjects.Create("Table1", worksheet["A1:E7"]);

                if (chkboxApplyCustomStyle.IsChecked.Value)
                {
                    // Apply custom table style
                    table1.TableStyleName = CreateCustomStyle(workbook).Name;
                }
                else
                {
                    // Apply builtin style
                    table1.BuiltInTableStyle = TableBuiltInStyles.TableStyleMedium9;
                }

                // Total row
                table1.ShowTotals = true;
                table1.ShowFirstColumn = true;
                table1.ShowTableStyleColumnStripes = true;
                table1.ShowTableStyleRowStripes = true;
                table1.Columns[0].TotalsRowLabel = "Total";
                table1.Columns[1].TotalsCalculation = ExcelTotalsCalculation.Sum;
                table1.Columns[2].TotalsCalculation = ExcelTotalsCalculation.Sum;
                table1.Columns[3].TotalsCalculation = ExcelTotalsCalculation.Sum;
                table1.Columns[4].TotalsCalculation = ExcelTotalsCalculation.Sum;

                worksheet.UsedRange.AutofitColumns();
                worksheet.SetColumnWidth(2, 12.43);
                worksheet.SetColumnWidth(4, 12.43);

                // Save and close the document
                string filename = "Table.xlsx";
                MemoryStream stream = new MemoryStream();
                workbook.SaveAs(stream);
                Save(stream, filename);                
                stream.Dispose();
            }
        }
        #endregion

        #region Helper Method
        /// <summary>
        /// Create a custom table style
        /// </summary>
        /// <param name="workbook">Workbook used to create the custom table style</param>
        private ITableStyle CreateCustomStyle(IWorkbook workbook)
        {
            string tableStyleName = "Table Style 1";

            ITableStyles tableStyles = workbook.TableStyles;
            ITableStyle tableStyle = tableStyles.Add(tableStyleName);
            ITableStyleElements tableStyleElements = tableStyle.TableStyleElements;
            ITableStyleElement tableStyleElement = tableStyleElements.Add(ExcelTableStyleElementType.SecondColumnStripe);
            tableStyleElement.BackColorRGB = Syncfusion.Drawing.Color.FromArgb(217, 225, 242);

            ITableStyleElement tableStyleElement1 = tableStyleElements.Add(ExcelTableStyleElementType.FirstColumn);
            tableStyleElement1.FontColorRGB = Syncfusion.Drawing.Color.FromArgb(128, 128, 128);

            ITableStyleElement tableStyleElement2 = tableStyleElements.Add(ExcelTableStyleElementType.HeaderRow);
            tableStyleElement2.Bold = true;
            tableStyleElement2.FontColor = ExcelKnownColors.White;
            tableStyleElement2.BackColorRGB = Syncfusion.Drawing.Color.FromArgb(0, 112, 192);

            ITableStyleElement tableStyleElement3 = tableStyleElements.Add(ExcelTableStyleElementType.TotalRow);
            tableStyleElement3.BackColorRGB = Syncfusion.Drawing.Color.FromArgb(0, 112, 192);
            tableStyleElement3.Bold = true;
            tableStyleElement3.FontColor = ExcelKnownColors.White;

            return tableStyle;
        }
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