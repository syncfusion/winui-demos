#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows;
using Syncfusion.XlsIO;
using System.ComponentModel;
using System.Globalization;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System.IO;
using System.Reflection;
using Windows.Storage;
using Windows.Storage.Pickers;
using System.Collections.Generic;
using Windows.Storage.Streams;

namespace syncfusion.xlsiodemos.winui.Views
{
    /// <summary>
    /// Interaction logic for FormatCells.xaml
    /// </summary>
    public partial class FormatCells : Page
    {
        private string filename;

        # region Constructor
        /// <summary>
        /// FormatCells Constructor
        /// </summary>
        public FormatCells()
        {
            this.InitializeComponent();
        }
        # endregion

        # region Events
        /// <summary>
        /// Creates spreadsheet
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
                if (this.rdbtnXLS.IsChecked.Value)
                {
                    application.DefaultVersion = ExcelVersion.Excel97to2003;
                    filename = "FormatCells.xls";
                }
                else if (this.rdbtnXLSX.IsChecked.Value)
                {
                    application.DefaultVersion = ExcelVersion.Xlsx;
                    filename = "FormatCells.xlsx";
                }
                //A new workbook is created.[Equivalent to creating a new workbook in MS Excel]
                IWorkbook workbook = application.Workbooks.Create(1);
                //The first worksheet object in the worksheets collection is accessed.
                IWorksheet sheet = workbook.Worksheets[0];
                sheet.IsGridLinesVisible = false;

                #region RTF
                //Insert Rich Text
                IRange range = sheet.Range["D3"];
                range.Text = "Employee Report";
                IRichTextString rtf = range.RichText;

                //Formatting the text
                IFont redFont = workbook.CreateFont();
                redFont.Size = 16;
                redFont.Bold = true;
                redFont.Italic = true;
                redFont.RGBColor = Syncfusion.Drawing.Color.FromArgb(0x82, 0x2e, 0x1b);
                rtf.SetFont(0, 14, redFont);

                #endregion

                #region Number Formatting

                sheet.Range["H24"].Number = 5000;
                sheet.Range["H24"].NumberFormat = "$#,##0.00";
                sheet.Range["H14"].NumberFormat = "dd/mm/yyyy";
                sheet.Range["H14"].DateTime = DateTime.Parse(" 8/3/1963", CultureInfo.InvariantCulture);
                sheet.Range["H16"].NumberFormat = "mm/dd/yyyy";
                sheet.Range["H16"].DateTime = DateTime.Parse(" 4/1/1992", CultureInfo.InvariantCulture);

                #endregion

                #region Alignment settings

                #region Text alignment
                sheet.Range["F10:F24"].HorizontalAlignment = ExcelHAlign.HAlignRight;
                sheet.Range["D3"].HorizontalAlignment = ExcelHAlign.HAlignCenter;
                sheet.Range["H10:H24"].HorizontalAlignment = ExcelHAlign.HAlignLeft;
                sheet.Range["F10:F24"].VerticalAlignment = ExcelVAlign.VAlignCenter;
                #endregion

                #region Text Control
                sheet.Range["F27"].WrapText = true;
                sheet.Range["F27"].Text = "Antony Jose graduated from St. Andrews University, Scotland, with a BSC degree in 1976.  Upon joining the company as a sales representative in 1992, he spent 6 months in an orientation program at the Seattle office and then returned to his permanent post in London.  He was promoted to sales manager in March 1993.";
                sheet.Range["F27"].CellStyle.VerticalAlignment = ExcelVAlign.VAlignCenter;
                #endregion

                #region Cell merging
                sheet.Range["F27:H28"].Merge();
                sheet.Range["D3:F3"].Merge();
                sheet.Range["B7:J8"].Merge();
                sheet.Range["F27"].RowHeight = 68;
                sheet.Range["H10:H24"].ColumnWidth = 25;
                sheet.Range["C10:D28"].Merge();
                sheet.Range["B10:C28"].ColumnWidth = 1;
                sheet.Range["E10:E28"].ColumnWidth = 5;
                sheet.Range["D10:D28"].ColumnWidth = 15;
                #endregion

                #region Text Direction
                sheet.Range["B7"].Text = "Antony Jose";
                sheet.Range["B7"].CellStyle.ReadingOrder = Syncfusion.XlsIO.ExcelReadingOrderType.LeftToRight;
                sheet.Range["B7"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
                sheet.Range["B7"].CellStyle.VerticalAlignment = ExcelVAlign.VAlignCenter;
                #endregion

                #region Text Indent
                sheet.Range["D7"].CellStyle.IndentLevel = 6;
                #endregion

                #endregion

                #region Font settings

                // Setting Font Type
                sheet.Range["F10:F24"].CellStyle.Font.FontName = "Arial";
                sheet.Range["D3"].CellStyle.Font.FontName = "Arial";
                sheet.Range["B7"].CellStyle.Font.FontName = "Arial";
                sheet.Range["B7"].CellStyle.Font.Size = 12f;
                sheet.Range["B7"].CellStyle.Font.Bold = true;

                // Setting Font Styles
                sheet.Range["F10:F24"].CellStyle.Font.Bold = true;
                sheet.Range["D3"].CellStyle.Font.Bold = true;

                // Setting Font Size
                sheet.Range["F10:F24"].CellStyle.Font.Size = 10;
                sheet.Range["D3"].CellStyle.Font.Size = 14;
                sheet.Range["F27:H28"].CellStyle.Font.Size = 9f;

                // Setting Font Color
                sheet.Range["B7"].CellStyle.Font.RGBColor = Syncfusion.Drawing.Color.White;
                sheet.Range["D28"].CellStyle.Font.RGBColor = Syncfusion.Drawing.Color.White;

                // Setting UnderLine 
                sheet.Range["D3"].CellStyle.Font.Underline = ExcelUnderline.Double;

                sheet.Range["F10"].Text = "Name";
                sheet.Range["F12"].Text = "Title";
                sheet.Range["F14"].Text = "Birth Date";
                sheet.Range["F16"].Text = "Hire date";
                sheet.Range["F18"].Text = "Home phone";
                sheet.Range["F20"].Text = "Extension";
                sheet.Range["F22"].Text = "Home address";
                sheet.Range["F24"].Text = "Salary";

                sheet.Range["H10"].Text = "Antony Jose";
                sheet.Range["H12"].Text = "Sales Manager";
                sheet.Range["H18"].Text = "(206) 555-3412";
                sheet.Range["H20"].Number = 3355;
                sheet.Range["H22"].Text = "722 Moss Bay Blvd";

                #endregion

                #region Insert Image           
                string inputPath = "syncfusion.xlsiodemos.winui.Assets.XlsIO.EMPID1.png";

                Assembly assembly = typeof(FormatCells).GetTypeInfo().Assembly;
                Stream input = assembly.GetManifestResourceStream(inputPath);

                sheet.Pictures.AddPicture(11, 4, input, 55, 65);

                #endregion

                #region Border setting

                sheet.Range["H10"].CellStyle.Borders.LineStyle = ExcelLineStyle.Medium;
                sheet.Range["H10"].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
                sheet.Range["H10"].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;

                sheet.Range["H12"].CellStyle.Borders.LineStyle = ExcelLineStyle.Medium;
                sheet.Range["H12"].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
                sheet.Range["H12"].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;

                sheet.Range["H14"].CellStyle.Borders.LineStyle = ExcelLineStyle.Medium;
                sheet.Range["H14"].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
                sheet.Range["H14"].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;

                sheet.Range["H16"].CellStyle.Borders.LineStyle = ExcelLineStyle.Medium;
                sheet.Range["H16"].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
                sheet.Range["H16"].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;

                sheet.Range["H18"].CellStyle.Borders.LineStyle = ExcelLineStyle.Medium;
                sheet.Range["H18"].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
                sheet.Range["H18"].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;

                sheet.Range["H20"].CellStyle.Borders.LineStyle = ExcelLineStyle.Medium;
                sheet.Range["H20"].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
                sheet.Range["H20"].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;

                sheet.Range["H22"].CellStyle.Borders.LineStyle = ExcelLineStyle.Medium;
                sheet.Range["H22"].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
                sheet.Range["H22"].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;

                sheet.Range["H24"].CellStyle.Borders.LineStyle = ExcelLineStyle.Medium;
                sheet.Range["H24"].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
                sheet.Range["H24"].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;

                sheet.Range["F27:H28"].CellStyle.Borders.LineStyle = ExcelLineStyle.Medium;
                sheet.Range["F27:H28"].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
                sheet.Range["F27:H28"].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;

                sheet.Range["C10:D28"].CellStyle.Borders.LineStyle = ExcelLineStyle.Thin;
                sheet.Range["C10:D28"].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
                sheet.Range["C10:D28"].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;

                #endregion

                #region Pattern settings
                sheet.Range["B9:I29"].CellStyle.Color = Syncfusion.Drawing.Color.FromArgb(198, 215, 239);
                sheet.Range["A7:J8"].CellStyle.Color = Syncfusion.Drawing.Color.FromArgb(57, 93, 148);

                sheet.Range["A7:A30"].CellStyle.Color = Syncfusion.Drawing.Color.FromArgb(57, 93, 148);
                sheet.Range["A7:A30"].ColumnWidth = 2.29;

                sheet.Range["J7:J30"].CellStyle.Color = Syncfusion.Drawing.Color.FromArgb(57, 93, 148);
                sheet.Range["J7:J30"].ColumnWidth = 2.29;

                sheet.Range["A30:J30"].CellStyle.Color = Syncfusion.Drawing.Color.FromArgb(57, 93, 148);

                sheet.Range["C10:D28"].CellStyle.Color = Syncfusion.Drawing.Color.FromArgb(231, 235, 247);
                sheet.Range["F27:H28"].CellStyle.Color = Syncfusion.Drawing.Color.FromArgb(231, 235, 247);
                #endregion

                if (this.rdbtnXLS.IsChecked.Value)
                {
                    //Saving the workbook to disk.
                    MemoryStream stream = new MemoryStream();
                    workbook.SaveAs(stream);
                    Save(stream, filename, true, false);
                    stream.Dispose();
                }
                else
                {
                    //Saving the workbook to disk.
                    MemoryStream stream = new MemoryStream();
                    workbook.SaveAs(stream);
                    Save(stream, filename, false, true);                    
                    stream.Dispose();
                }
                input.Dispose();

                //No exception will be thrown if there are unsaved workbooks.
                excelEngine.ThrowNotSavedOnDestroy = false;
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
                if(isXlsx)
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