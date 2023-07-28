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
    /// Interaction logic for Sparklines.xaml
    /// </summary>
    public partial class Sparklines : Page
    {
        /// <summary>
        /// File Name
        /// </summary>
        private string filename;

        # region Constructor
        /// <summary>
        /// Sparklines constructor
        /// </summary>
        public Sparklines()
        {
            this.InitializeComponent();          
        }
        # endregion                

        #region Events
        /// <summary>
        /// Creates spreadsheet
        /// </summary>
        /// <param name="sender">Contains a reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            //Instantiate the spreadsheet creation engine.
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;

                application.DefaultVersion = ExcelVersion.Xlsx;

                //Open workbook with Data
                IWorkbook workbook;
                string path = "Syncfusion.XlsIODemos.WinUI.";
#if Main_SB
                path = "Syncfusion.SampleBrowser.WinUI.XlsIO.";
#endif
                string inputPath = path + "Assets.XlsIO.Sparkline.xlsx";

                Assembly assembly = typeof(Sparklines).GetTypeInfo().Assembly;
                Stream input = assembly.GetManifestResourceStream(inputPath);
                workbook = application.Workbooks.Open(input);

                //The first worksheet object in the worksheets collection is accessed.
                IWorksheet sheet = workbook.Worksheets[0];

                #region WholeSale Report

                //A new Sparkline group is added to the sheet sparklinegroups
                ISparklineGroup sparklineGroup = sheet.SparklineGroups.Add();

                //Set the Sparkline group type as line
                sparklineGroup.SparklineType = SparklineType.Line;

                //Set to display the empty cell as line
                sparklineGroup.DisplayEmptyCellsAs = SparklineEmptyCells.Line;

                //Sparkline group style properties
                sparklineGroup.ShowFirstPoint = true;
                sparklineGroup.FirstPointColor = Syncfusion.Drawing.Color.Green;
                sparklineGroup.ShowLastPoint = true;
                sparklineGroup.LastPointColor = Syncfusion.Drawing.Color.DarkOrange;
                sparklineGroup.ShowHighPoint = true;
                sparklineGroup.HighPointColor = Syncfusion.Drawing.Color.DarkBlue;
                sparklineGroup.ShowLowPoint = true;
                sparklineGroup.LowPointColor = Syncfusion.Drawing.Color.DarkViolet;
                sparklineGroup.ShowMarkers = true;
                sparklineGroup.MarkersColor = Syncfusion.Drawing.Color.Black;
                sparklineGroup.ShowNegativePoint = true;
                sparklineGroup.NegativePointColor = Syncfusion.Drawing.Color.Red;

                //set the line weight
                sparklineGroup.LineWeight = 0.3;

                //The sparklines are added to the sparklinegroup.
                ISparklines sparklines = sparklineGroup.Add();

                //Set the Sparkline Datarange .
                IRange dataRange = sheet.Range["D6:G17"];
                //Set the Sparkline Reference range.
                IRange referenceRange = sheet.Range["H6:H17"];

                //Create a sparkline with the datarange and reference range.
                sparklines.Add(dataRange, referenceRange);
                #endregion

                #region Retail Trade

                //A new Sparkline group is added to the sheet sparklinegroups
                sparklineGroup = sheet.SparklineGroups.Add();

                //Set the Sparkline group type as column
                sparklineGroup.SparklineType = SparklineType.Column;

                //Set to display the empty cell as zero
                sparklineGroup.DisplayEmptyCellsAs = SparklineEmptyCells.Zero;

                //Sparkline group style properties
                sparklineGroup.ShowHighPoint = true;
                sparklineGroup.HighPointColor = Syncfusion.Drawing.Color.Green;
                sparklineGroup.ShowLowPoint = true;
                sparklineGroup.LowPointColor = Syncfusion.Drawing.Color.Red;
                sparklineGroup.ShowNegativePoint = true;
                sparklineGroup.NegativePointColor = Syncfusion.Drawing.Color.Black;

                //The sparklines are added to the sparklinegroup.
                sparklines = sparklineGroup.Add();

                //Set the Sparkline Datarange .
                dataRange = sheet.Range["D21:G32"];
                //Set the Sparkline Reference range.
                referenceRange = sheet.Range["H21:H32"];

                //Create a sparkline with the datarange and reference range.
                sparklines.Add(dataRange, referenceRange);

                #endregion

                #region Manufacturing Trade

                //A new Sparkline group is added to the sheet sparklinegroups
                sparklineGroup = sheet.SparklineGroups.Add();

                //Set the Sparkline group type as win/loss
                sparklineGroup.SparklineType = SparklineType.ColumnStacked100;

                sparklineGroup.DisplayEmptyCellsAs = SparklineEmptyCells.Zero;

                sparklineGroup.DisplayAxis = true;
                sparklineGroup.AxisColor = Syncfusion.Drawing.Color.Black;
                sparklineGroup.ShowFirstPoint = true;
                sparklineGroup.FirstPointColor = Syncfusion.Drawing.Color.Green;
                sparklineGroup.ShowLastPoint = true;
                sparklineGroup.LastPointColor = Syncfusion.Drawing.Color.Orange;
                sparklineGroup.ShowNegativePoint = true;
                sparklineGroup.NegativePointColor = Syncfusion.Drawing.Color.Red;

                sparklines = sparklineGroup.Add();

                dataRange = sheet.Range["D36:G46"];
                referenceRange = sheet.Range["H36:H46"];

                sparklines.Add(dataRange, referenceRange);

                #endregion

                //Saving the workbook to disk.
                workbook.Version = ExcelVersion.Xlsx;
                filename = "Sparklines.xlsx";

                MemoryStream stream = new MemoryStream();
                workbook.SaveAs(stream);
                Save(stream, filename);

                input.Dispose();
                stream.Dispose();

                //No exception will be thrown if there are unsaved workbooks.
                excelEngine.ThrowNotSavedOnDestroy = false;                
            }
        }
        # endregion

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