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
using System.Reflection;
using Windows.Storage;
using Windows.Storage.Pickers;
using System.Collections.Generic;
using Windows.Storage.Streams;

namespace Syncfusion.XlsIODemos.WinUI.Views
{
    /// <summary>
    /// Interaction logic for ColumnChart.xaml
    /// </summary>
    public partial class ColumnChart : Page
    {
        private string filename;

        #region Constructor
        /// <summary>
        /// ColumnChart constructor
        /// </summary>
        public ColumnChart()
        {
            this.InitializeComponent();    
        }
        #endregion

        #region Events
        /// <summary>
        /// Creates spreadsheet with chart
        /// </summary>
        /// <param name="sender">Contains a reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>    
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            string path = "Syncfusion.XlsIODemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.XlsIO.";
#endif
            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                #region Workbook Initialize
                //Step 2 : Instantiate the excel application object.
                IWorkbook workbook = null;

                IApplication application = excelEngine.Excel;
                Stream input = new MemoryStream();
                if (this.rdbtnXLS.IsChecked.Value)
                {
                    application.DefaultVersion = ExcelVersion.Excel97to2003;

                    string inputPath = path + "Assets.XlsIO.EmbeddedChart.xls";

                    Assembly assembly = typeof(ColumnChart).GetTypeInfo().Assembly;
                    input = assembly.GetManifestResourceStream(inputPath);
                    workbook = application.Workbooks.Open(input);

                    filename = "ColumnChart.xls";
                }

                else if (this.rdbtnXLSX.IsChecked.Value)
                {
                    string inputPath = path + "Assets.XlsIO.EmbeddedChart.xlsx";

                    Assembly assembly = typeof(ColumnChart).GetTypeInfo().Assembly;
                    input = assembly.GetManifestResourceStream(inputPath);
                    workbook = application.Workbooks.Open(input);

                    workbook.Version = ExcelVersion.Xlsx;
                    filename = "ColumnChart.xlsx";
                }

                //The first worksheet object in the worksheets collection is accessed.
                IWorksheet worksheet = workbook.Worksheets[0];
                #endregion

                // Adding a New chart to the Existing Worksheet   
                IChartShape chart = workbook.Worksheets[0].Charts.Add();

                chart.DataRange = worksheet.Range["A3:C15"];
                chart.ChartTitle = "Crescent City, CA";
                chart.IsSeriesInRows = false;

                chart.PrimaryValueAxis.Title = "Precipitation,in.";
                chart.PrimaryValueAxis.TitleArea.TextRotationAngle = 90;
                chart.PrimaryValueAxis.MaximumValue = 14.0;
                chart.PrimaryValueAxis.NumberFormat = "0.0";

                chart.PrimaryCategoryAxis.Title = "Month";

                #region Format Series
                IChartSerie serieOne = chart.Series[0];

                chart.ChartType = ExcelChartType.Column_Clustered_3D;

                //set the Backwall fill option
                chart.BackWall.Fill.FillType = ExcelFillType.Gradient;

                //set the Texture Type
                chart.BackWall.Fill.GradientColorType = ExcelGradientColor.TwoColor;
                chart.BackWall.Fill.GradientStyle = ExcelGradientStyle.Diagonl_Down;
                chart.BackWall.Fill.ForeColor = Syncfusion.Drawing.Color.WhiteSmoke;
                chart.BackWall.Fill.BackColor = Syncfusion.Drawing.Color.LightBlue;

                //set the Border Linecolor 
                chart.BackWall.Border.LineColor = Syncfusion.Drawing.Color.Wheat;

                //set the Picture Type     
                chart.BackWall.PictureUnit = ExcelChartPictureType.stretch;

                //set the Backwall thickness
                chart.BackWall.Thickness = 10;

                //set the sidewall fill option
                chart.SideWall.Fill.FillType = ExcelFillType.SolidColor;

                //set the sidewall foreground and backcolor
                chart.SideWall.Fill.BackColor = Syncfusion.Drawing.Color.White;
                chart.SideWall.Fill.ForeColor = Syncfusion.Drawing.Color.White;

                //set the side wall Border color
                chart.SideWall.Border.LineColor = Syncfusion.Drawing.Color.Beige;

                //set floor fill option
                chart.Floor.Fill.FillType = ExcelFillType.Pattern;

                //set the floor pattern Type
                chart.Floor.Fill.Pattern = ExcelGradientPattern.Pat_Divot;

                //Set the floor fore and Back ground color
                chart.Floor.Fill.ForeColor = Syncfusion.Drawing.Color.Blue;
                chart.Floor.Fill.BackColor = Syncfusion.Drawing.Color.White;

                //set the floor thickness
                chart.Floor.Thickness = 3;

                IChartSerie serieTwo = chart.Series[1];
                //Show value as data labels
                serieOne.DataPoints.DefaultDataPoint.DataLabels.IsValue = true;
                serieTwo.DataPoints.DefaultDataPoint.DataLabels.IsValue = true;

                //ColumnChart Chart Position
                chart.TopRow = 2;
                chart.BottomRow = 30;
                chart.LeftColumn = 5;
                chart.RightColumn = 18;
                serieTwo.Name = "Temperature,deg.F";
                #endregion

                #region Legend setting
                chart.Legend.Position = ExcelLegendPosition.Right;
                chart.Legend.IsVerticalLegend = false;
                #endregion

                if (this.rdbtnXLSX.IsChecked.Value)
                {
                    chart.Series[0].IsFiltered = true;
                    chart.Categories[0].IsFiltered = true;
                    chart.Categories[1].IsFiltered = true;
                }

                if (this.rdbtnXLS.IsChecked.Value)
                {
                    //Saving the workbook to disk.
                    MemoryStream stream = new MemoryStream();
                    workbook.SaveAs(stream);
                    Save(stream, filename, true, false);                   
                    stream.Dispose();
                }
                else if (this.rdbtnXLSX.IsChecked.Value)
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
                if (isXlsx)
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
