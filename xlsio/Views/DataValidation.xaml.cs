#region Copyright Syncfusion Inc. 2001-2022
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.XlsIO;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Popups;

namespace Syncfusion.XlsIODemos.WinUI.Views
{
    /// <summary>
    /// Interaction logic for DataValidation.xaml
    /// </summary>
    public partial class DataValidation : Page
    {       
        # region Constructor
        /// <summary>
        /// DataValidation constructor
        /// </summary>
        public DataValidation()
        {
            this.InitializeComponent();
        }
        # endregion

        # region Events
        /// <summary>
        /// Creates spreadsheet with data validation
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

                //A new workbook is created.[Equivalent to creating a new workbook in MS Excel]
                IWorkbook workbook = application.Workbooks.Create(1);
                //The first worksheet object in the worksheets collection is accessed.
                IWorksheet sheet = workbook.Worksheets[0];

                //Data validation to list the values in the first cell
                IDataValidation validation = sheet.Range["C7"].DataValidation;
                sheet.Range["B7"].Text = "Select an item from the validation list";
                validation.ListOfValues = new string[] { "PDF", "XlsIO", "DocIO" };
                validation.PromptBoxText = "Data Validation list";
                validation.IsPromptBoxVisible = true;
                validation.ShowPromptBox = true;

                sheet.Range["C7"].CellStyle.Borders.LineStyle = ExcelLineStyle.Medium;
                sheet.Range["C7"].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
                sheet.Range["C7"].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;

                // Data Validation for Numbers
                IDataValidation validation1 = sheet.Range["C9"].DataValidation;
                sheet.Range["B9"].Text = "Enter a Number to validate";
                validation1.AllowType = ExcelDataType.Integer;
                validation1.CompareOperator = ExcelDataValidationComparisonOperator.Between;
                validation1.FirstFormula = "0";
                validation1.SecondFormula = "10";
                validation1.ShowErrorBox = true;
                validation1.ErrorBoxText = "Enter Value between 0 to 10";
                validation1.ErrorBoxTitle = "ERROR";
                validation1.PromptBoxText = "Data Validation using Condition for Numbers";
                validation1.ShowPromptBox = true;
                sheet.Range["C9"].CellStyle.Borders.LineStyle = ExcelLineStyle.Medium;
                sheet.Range["C9"].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
                sheet.Range["C9"].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;

                // Data Validation for Date
                IDataValidation validation2 = sheet.Range["C11"].DataValidation;
                sheet.Range["B11"].Text = "Enter the Date to validate";
                validation2.AllowType = ExcelDataType.Date;
                validation2.CompareOperator = ExcelDataValidationComparisonOperator.Between;
                validation2.FirstDateTime = new DateTime(2003, 5, 10);
                validation2.SecondDateTime = new DateTime(2004, 5, 10);
                validation2.ShowErrorBox = true;
                validation2.ErrorBoxText = "Enter Value between 10/5/2003 to 10/5/2004";
                validation2.ErrorBoxTitle = "ERROR";
                validation2.PromptBoxText = "Data Validation using Condition for Date";
                validation2.ShowPromptBox = true;
                sheet.Range["C11"].CellStyle.Borders.LineStyle = ExcelLineStyle.Medium;
                sheet.Range["C11"].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
                sheet.Range["C11"].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;

                // Data Validation for TextLength
                IDataValidation validation3 = sheet.Range["C13"].DataValidation;
                sheet.Range["B13"].Text = "Enter the Text to validate";
                validation3.AllowType = ExcelDataType.TextLength;
                validation3.CompareOperator = ExcelDataValidationComparisonOperator.Between;
                validation3.FirstFormula = "1";
                validation3.SecondFormula = "6";
                validation3.ShowErrorBox = true;
                validation3.ErrorBoxText = "Retype text length to 6 character";
                validation3.ErrorBoxTitle = "ERROR";
                validation3.PromptBoxText = "Data Validation using Condition for TextLength";
                validation3.ShowPromptBox = true;
                sheet.Range["C13"].CellStyle.Borders.LineStyle = ExcelLineStyle.Medium;
                sheet.Range["C13"].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
                sheet.Range["C13"].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;

                // Data Validation for Time
                IDataValidation validation4 = sheet.Range["C15"].DataValidation;
                sheet.Range["B15"].Text = "Enter the Time to validate";
                validation4.AllowType = ExcelDataType.Time;
                validation4.CompareOperator = ExcelDataValidationComparisonOperator.Between;
                validation4.FirstFormula = "10";
                validation4.SecondFormula = "12";
                validation4.ShowErrorBox = true;
                validation4.ErrorBoxText = "Enter the Correct time between 10 to 12 ";
                validation4.ErrorBoxTitle = "ERROR";
                validation4.PromptBoxText = "Data Validation using Condition for Time";
                validation4.ShowPromptBox = true;
                sheet.Range["C15"].CellStyle.Borders.LineStyle = ExcelLineStyle.Medium;
                sheet.Range["C15"].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
                sheet.Range["C15"].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;
                sheet.Range["B2:C2"].Merge();
                sheet.Range["B2"].Text = "Simple Data validation";
                sheet.Range["B5"].Text = "Validation criteria";
                sheet.Range["C5"].Text = "Validation";
                sheet.Range["B5"].CellStyle.Font.Bold = true;
                sheet.Range["C5"].CellStyle.Font.Bold = true;
                sheet.Range["B2"].CellStyle.Font.Bold = true;
                sheet.Range["B2"].CellStyle.Font.Size = 16;
                sheet.Range["B2"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
                sheet.UsedRange.AutofitColumns();
                sheet.UsedRange.AutofitRows();

                string filename = "";
                MemoryStream stream = new MemoryStream();

                //Saving the workbook to disk
                if (rdbtnXLS.IsChecked.Value)
                {
                    filename = "DataValidation.xls";
                    workbook.Version = ExcelVersion.Excel97to2003;
                    workbook.SaveAs(stream);
                    Save(stream, filename, true, false);
                }
                else if (rdbtnXLSX.IsChecked.Value)
                {
                    filename = "DataValidation.xlsx";
                    workbook.Version = ExcelVersion.Xlsx;
                    workbook.SaveAs(stream);
                    Save(stream, filename, false, true);
                }                
                stream.Dispose();
            }
        }
        #endregion

        #region HelperMethods
        async void Save(MemoryStream stream, string filename, bool isXLS, bool isXLSX)
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
                else if (isXLSX)
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
        # endregion
    }
}