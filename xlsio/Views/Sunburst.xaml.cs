#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;

namespace syncfusion.xlsiodemos.winui.Views
{
    /// <summary>
    /// Interaction logic for Sunburst.xaml
    /// </summary>
    public sealed partial class Sunburst : Page
    {
        # region Constructor
        /// <summary>
        /// Sunburst constructor
        /// </summary>
        public Sunburst()
        {
            InitializeComponent();
        }
        # endregion

        #region Creating Charts
        /// <summary>
        /// Create Sunburst chart
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
                #region Workbook Initialize
                //Step 2 : Instantiate the excel application object.
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Xlsx;

                string inputPath = "syncfusion.xlsiodemos.winui.Assets.XlsIO.SunburstTemplate.xlsx";

                Assembly assembly = typeof(Sunburst).GetTypeInfo().Assembly;
                Stream input = assembly.GetManifestResourceStream(inputPath);
                IWorkbook workbook = application.Workbooks.Open(input);

                #endregion

                IWorksheet sheet = workbook.Worksheets[0];
                IChart chart = null;
                chart = workbook.Worksheets[0].Charts.Add();

                #region Sunburst Chart Settings
                chart.ChartType = ExcelChartType.SunBurst;
                chart.DataRange = sheet["A1:D29"];
                chart.ChartTitle = "Breakdown of Bookstore Revenue";
                #endregion

                chart.Legend.Position = ExcelLegendPosition.Right;

                workbook.Worksheets[0].Activate();
                IChartShape chartShape = chart as IChartShape;
                chartShape.TopRow = 1;
                chartShape.BottomRow = 23;
                chartShape.LeftColumn = 6;                    
                chartShape.RightColumn = 15;

                #region Workbook Save and Close
                string outFileName = "Sunburst_Chart.xlsx";
                MemoryStream output = new MemoryStream();
                workbook.SaveAs(output);
                output.Position = 0;
                Save(output, outFileName);
                output.Dispose();
                #endregion
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

        #region View the Input file
        private void btnInput_Click(object sender, RoutedEventArgs e)
        {
            //Launching the Input Template using the default Application.[MS Excel Or Free ExcelViewer]
            string inputPath = "syncfusion.xlsiodemos.winui.Assets.XlsIO.SunburstTemplate.xlsx";
            Assembly assembly = typeof(Sunburst).GetTypeInfo().Assembly;
            Stream input = assembly.GetManifestResourceStream(inputPath);
            InputTemplate obj = new InputTemplate();
            obj.GetInputTeamplate(input, "SunburstTemplate.xlsx", ".xlsx");
            input.Dispose();
        }
        #endregion
    }
}