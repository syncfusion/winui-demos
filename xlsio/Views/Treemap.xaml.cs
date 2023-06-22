#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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

namespace Syncfusion.XlsIODemos.WinUI.Views
{
    /// <summary>
    /// Interaction logic for Treemap.xaml
    /// </summary>
    public partial class Treemap : Page
    {
     
        # region Constructor
        /// <summary>
        /// Treemap constructor
        /// </summary>
        public Treemap()
        {
            InitializeComponent();           
        }
        # endregion                     

        #region Creating Charts

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            string path = "Syncfusion.XlsIODemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.XlsIO.";
#endif
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                #region Workbook Initialize         
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Xlsx;

                string inputPath = path + "Assets.XlsIO.TreemapTemplate.xlsx";

                Assembly assembly = typeof(Treemap).GetTypeInfo().Assembly;
                Stream input = assembly.GetManifestResourceStream(inputPath);
                IWorkbook workbook = application.Workbooks.Open(input);
                #endregion

                IWorksheet sheet = workbook.Worksheets[0];
                IChart chart = null;
                chart = workbook.Worksheets[0].Charts.Add();

                #region Treemap Chart Settings
                chart.ChartType = ExcelChartType.TreeMap;
                chart.DataRange = sheet["A1:F13"];
                chart.ChartTitle = "Daily Food Sales";
                foreach (IChartSerie serie in chart.Series)
                {
                    serie.SerieFormat.TreeMapLabelOption = ExcelTreeMapLabelOption.Banner;
                }
                #endregion

                chart.Legend.Position = ExcelLegendPosition.Top;

                workbook.Worksheets[0].Activate();
                IChartShape chartShape = chart as IChartShape;
                chartShape.TopRow = 1;
                chartShape.BottomRow = 22;
                chartShape.LeftColumn = 8;
                chartShape.RightColumn = 15;
                

                #region Workbook Save and Close
                string outFileName = "Treemap_Chart.xlsx";
                MemoryStream output = new MemoryStream();
                workbook.SaveAs(output);
                output.Position = 0;
                Save(output, outFileName);
                output.Dispose();
                #endregion


            }
        }      
        #endregion
               
        #region View the Input file
        private void btnInput_Click(object sender, RoutedEventArgs e)
        {
            string path = "Syncfusion.XlsIODemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.XlsIO.";
#endif
            //Launching the Input Template using the default Application.[MS Excel Or Free ExcelViewer]
            string inputPath = path + "Assets.XlsIO.TreemapTemplate.xlsx";
            Assembly assembly = typeof(Treemap).GetTypeInfo().Assembly;
            Stream input = assembly.GetManifestResourceStream(inputPath);
            InputTemplate obj = new InputTemplate();
            obj.GetInputTeamplate(input, "TreemapTemplate.xlsx", ".xlsx");
            input.Dispose();
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

    }
}
