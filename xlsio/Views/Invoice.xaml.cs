#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.XlsIO;
using System.Globalization;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System.IO;
using Windows.Storage;
using Windows.Storage.Pickers;
using System.Collections.Generic;
using Windows.Storage.Streams;
using System.Reflection;
using Windows.UI.Popups;

namespace Syncfusion.XlsIODemos.WinUI.Views
{
    /// <summary>
    /// Interaction logic for Invoice.xaml
    /// </summary>
    public partial class Invoice : Page
    {
        #region Constructor
        /// <summary>
        /// Invoice constructor
        /// </summary>
        public Invoice()
        {
            this.InitializeComponent();           
        }
        #endregion

        #region Events
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

                application.DefaultVersion = ExcelVersion.Xlsx;

                IWorkbook workbook = application.Workbooks.Create(1);
                IWorksheet sheet = workbook.Worksheets[0];

                sheet.Name = "Invoice";
                sheet.IsGridLinesVisible = false;
                sheet.EnableSheetCalculations();

                sheet.Range["A1"].ColumnWidth = 4.82;
                sheet.Range["B1:C1"].ColumnWidth = 13.82;
                sheet.Range["D1"].ColumnWidth = 12.20;
                sheet.Range["E1"].ColumnWidth = 8.50;
                sheet.Range["F1"].ColumnWidth = 9.73;
                sheet.Range["G1"].ColumnWidth = 8.82;
                sheet.Range["H1"].ColumnWidth = 4.46;

                sheet.Range["A1:H1"].CellStyle.Color = Syncfusion.Drawing.Color.FromArgb(51, 63, 79);
                sheet.Range["A1:H1"].Merge();
                sheet.Range["B4:D6"].Merge();

                sheet.Range["B4"].Text = "INVOICE";
                sheet.Range["B4"].CellStyle.Font.Bold = true;
                sheet.Range["B4"].CellStyle.Font.Size = 32;

                IStyle style1 = workbook.Styles.Add("style1");
                style1.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Medium;
                style1.Borders[ExcelBordersIndex.EdgeBottom].Color = ExcelKnownColors.Grey_40_percent;

                sheet.Range["B7:G7"].Merge();
                sheet.Range["B7:G7"].CellStyle = style1;

                sheet.Range["B13:G13"].Merge();
                sheet.Range["B13:G13"].CellStyle = style1;

                sheet.Range["B8"].Text = "BILL TO:";
                sheet.Range["B8"].CellStyle.Font.Size = 9;
                sheet.Range["B8"].CellStyle.Font.Bold = true;

                sheet.Range["B9"].Text = "Abraham Swearegin";
                sheet.Range["B9"].CellStyle.Font.Size = 12;
                sheet.Range["B9"].CellStyle.Font.Bold = true;

                sheet.Range["B10"].Text = "United States, California, San Mateo,";
                sheet.Range["B10"].CellStyle.Font.Size = 9;

                sheet.Range["B11"].Text = "9920 BridgePointe Parkway,";
                sheet.Range["B11"].CellStyle.Font.Size = 9;

                sheet.Range["B12"].Number = 9365550136;
                sheet.Range["B12"].CellStyle.Font.Size = 9;
                sheet.Range["B12"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;

                IRange range1 = sheet.Range["F8:G8"];
                IRange range2 = sheet.Range["F9:G9"];
                IRange range3 = sheet.Range["F10:G10"];
                IRange range4 = sheet.Range["E11:G11"];
                IRange range5 = sheet.Range["F12:G12"];

                range1.Merge();
                range2.Merge();
                range3.Merge();
                range4.Merge();
                range5.Merge();

                sheet.Range["F8"].Text = "INVOICE#";
                range1.CellStyle.Font.Size = 8;
                range1.CellStyle.Font.Bold = true;
                range1.CellStyle.HorizontalAlignment = ExcelHAlign.HAlignRight;

                sheet.Range["F9"].Number = 2058557939;
                range2.CellStyle.Font.Size = 9;
                range2.CellStyle.HorizontalAlignment = ExcelHAlign.HAlignRight;

                sheet.Range["F10"].Text = "DATE";
                range3.CellStyle.Font.Size = 8;
                range3.CellStyle.Font.Bold = true;
                range3.CellStyle.HorizontalAlignment = ExcelHAlign.HAlignRight;

                sheet.Range["E11"].DateTime = new DateTime(2020, 08, 31);
                sheet.Range["E11"].NumberFormat = "[$-x-sysdate]dddd, mmmm dd, yyyy";
                range4.CellStyle.Font.Size = 9;
                range4.CellStyle.HorizontalAlignment = ExcelHAlign.HAlignRight;

                range5.CellStyle.Font.Size = 8;
                range5.CellStyle.Font.Bold = true;
                range5.CellStyle.HorizontalAlignment = ExcelHAlign.HAlignRight;

                IRange range6 = sheet.Range["B15:G15"];
                range6.CellStyle.Font.Size = 10;
                range6.CellStyle.Font.Bold = true;

                sheet.Range[15, 2].Text = "Code";
                sheet.Range[16, 2].Text = "CA-1098";
                sheet.Range[17, 2].Text = "LJ-0192";
                sheet.Range[18, 2].Text = "So-B909-M";
                sheet.Range[19, 2].Text = "FK-5136";
                sheet.Range[20, 2].Text = "HL-U509";

                sheet.Range[15, 3].Text = "Description";
                sheet.Range[16, 3].Text = "AWC Logo Cap";
                sheet.Range[17, 3].Text = "Long-Sleeve Logo Jersey, M";
                sheet.Range[18, 3].Text = "Mountain Bike Socks, M";
                sheet.Range[19, 3].Text = "ML Fork";
                sheet.Range[20, 3].Text = "Sports-100 Helmet, Black";

                sheet.Range[15, 3, 15, 4].Merge();
                sheet.Range[16, 3, 16, 4].Merge();
                sheet.Range[17, 3, 17, 4].Merge();
                sheet.Range[18, 3, 18, 4].Merge();
                sheet.Range[19, 3, 19, 4].Merge();
                sheet.Range[20, 3, 20, 4].Merge();

                sheet.Range[15, 5].Text = "Quantity";
                sheet.Range[16, 5].Number = 2;
                sheet.Range[17, 5].Number = 3;
                sheet.Range[18, 5].Number = 2;
                sheet.Range[19, 5].Number = 6;
                sheet.Range[20, 5].Number = 1;

                sheet.Range[15, 6].Text = "Price";
                sheet.Range[16, 6].Number = 8.99;
                sheet.Range[17, 6].Number = 49.99;
                sheet.Range[18, 6].Number = 9.50;
                sheet.Range[19, 6].Number = 175.49;
                sheet.Range[20, 6].Number = 34.99;

                sheet.Range[15, 7].Text = "Total";
                sheet.Range[16, 7].Formula = "=E16*F16+(E16*F16)";
                sheet.Range[17, 7].Formula = "=E17*F17+(E17*F17)";
                sheet.Range[18, 7].Formula = "=E18*F18+(E18*F18)";
                sheet.Range[19, 7].Formula = "=E19*F19+(E19*F19)";
                sheet.Range[20, 7].Formula = "=E20*F20+(E20*F20)";
                sheet.Range[15, 6, 20, 7].NumberFormat = "$#,##0.00";

                sheet.Range["E15:G15"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignRight;
                sheet.Range["B15:G15"].CellStyle.Font.Size = 10;
                sheet.Range["B15:G15"].CellStyle.Font.Bold = true;
                sheet.Range["B16:G20"].CellStyle.Font.Size = 9;

                sheet.Range["E22:G22"].Merge();
                sheet.Range["E22:G22"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignRight;
                sheet.Range["E23:G24"].Merge();

                IRange range7 = sheet.Range["E22"];
                IRange range8 = sheet.Range["E23"];
                range7.Text = "TOTAL";
                range7.CellStyle.Font.Size = 8;               
                range7.CellStyle.Font.Color = ExcelKnownColors.Blue_grey;
                range8.Formula = "=SUM(G16:G20)";
                range8.NumberFormat = "$#,##0.00";
                range8.CellStyle.Font.Size = 24;
                range8.CellStyle.HorizontalAlignment = ExcelHAlign.HAlignRight;
                range8.CellStyle.Font.Bold = true;

                sheet.Range[26, 1].Text = "800 Interchange Blvd, Suite 2501, Austin, TX 78721 | support@adventure-works.com";
                sheet.Range[26, 1].CellStyle.Font.Size = 8;

                IRange range9 = sheet.Range["A26:H27"];
                range9.CellStyle.Color = Syncfusion.Drawing.Color.FromArgb(172, 185, 202);
                range9.Merge();
                range9.CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
                range9.CellStyle.VerticalAlignment = ExcelVAlign.VAlignCenter;
                string path = "Syncfusion.XlsIODemos.WinUI.";
#if Main_SB
                path = "Syncfusion.SampleBrowser.WinUI.XlsIO.";
#endif
                string inputPath = path + "Assets.XlsIO.invoice.jpeg";
                Assembly assembly = typeof(FormatCells).GetTypeInfo().Assembly;
                Stream input = assembly.GetManifestResourceStream(inputPath);

                sheet.Pictures.AddPicture(3, 4, 7, 8, input); 

                string OutputFilename = "Invoice.xlsx";
                MemoryStream stream = new MemoryStream();
                workbook.SaveAs(stream);
                Save(stream, OutputFilename);
                stream.Dispose();
                                
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
