#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
using Windows.UI.ViewManagement;
using Windows.UI.Popups;

namespace Syncfusion.XlsIODemos.WinUI.Views
{
    /// <summary>
    /// Interaction logic for WhatifAnalysis.xaml
    /// </summary>
    public partial class WhatIfAnalysis : Page
    {
        # region Constructor
        /// <summary>
        /// WhatIfAnalysis constructor
        /// </summary>
        public WhatIfAnalysis()
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
            string path = "Syncfusion.XlsIODemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.XlsIO.";
#endif
            //Initialize ExcelEngine
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                //Initialize IApplication and set the default application version
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Xlsx;

                //Load the Excel template into IWorkbook and get the worksheet into IWorksheet
                Assembly assembly = typeof(WhatIfAnalysis).GetTypeInfo().Assembly;
                string inputPath = path + "Assets.XlsIO.WhatIfAnalysisTemplate.xlsx";
                Stream excelStream = assembly.GetManifestResourceStream(inputPath);
                IWorkbook workbook = application.Workbooks.Open(excelStream);
                IWorksheet worksheet = workbook.Worksheets[0];

                //Initailize list objects with different values for scenarios
                List<object> currentChange_Values = new List<object> { 0.23, 0.8, 1.1, 0.5, 0.35, 0.2, 0.4, 0.37, 1.1, 1, 0.94, 0.75 };
                List<object> increasedChange_Values = new List<object> { 0.45, 0.56, 0.9, 0.5, 0.58, 0.43, 0.39, 0.89, 1.45, 1.2, 0.99, 0.8 };
                List<object> decreasedChange_Values = new List<object> { 0.3, 0.2, 0.5, 0.3, 0.5, 0.23, 0.2, 0.3, 0.8, 0.6, 0.87, 0.4 };

                List<object> currentQuantity_Values = new List<object> { 1500, 3000, 5000, 4000, 500, 4000, 1200, 1500, 750, 750, 1200, 7900 };
                List<object> increasedQuantity_Values = new List<object> { 1000, 5000, 4500, 3900, 10000, 8900, 8000, 3500, 15000, 5500, 4500, 4200 };
                List<object> decreasedQuantity_Values = new List<object> { 1000, 2000, 3000, 3000, 300, 4000, 1200, 1000, 550, 650, 800, 6900 };

                //Add scenarios in the worksheet
                IScenarios scenarios = worksheet.Scenarios;
                scenarios.Add("Current % of Change", worksheet.Range["F5:F16"], currentChange_Values);
                scenarios.Add("Increased % of Change", worksheet.Range["F5:F16"], increasedChange_Values);
                scenarios.Add("Decreased % of Change", worksheet.Range["F5:F16"], decreasedChange_Values);

                scenarios.Add("Current Quantity", worksheet.Range["D5:D16"], currentQuantity_Values);
                scenarios.Add("Increased Quantity", worksheet.Range["D5:D16"], increasedQuantity_Values);
                scenarios.Add("Decreased Quantity", worksheet.Range["D5:D16"], decreasedQuantity_Values);

                //Create Summary
                if (chkboxCreateSummary.IsChecked.Value)
                {
                    worksheet.Scenarios.CreateSummary(worksheet.Range["L7"]);
                }

                MemoryStream stream = new MemoryStream();
                workbook.SaveAs(stream);
                Save(stream, "WhatIfAnalysis.xlsx");
                excelStream.Dispose();
                stream.Dispose();
            }
        }

        /// <summary>
        /// Opens input template
        /// </summary>
        /// <param name="sender">Contains a reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void btnInput_Click(object sender, RoutedEventArgs e)
        {
            string path = "Syncfusion.XlsIODemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.XlsIO.";
#endif
            //Launching the Input Template using the default Application.[MS Excel Or Free ExcelViewer]
            string inputPath = path + "Assets.XlsIO.WhatIfAnalysisTemplate.xlsx";
            Assembly assembly = typeof(WhatIfAnalysis).GetTypeInfo().Assembly;
            Stream input = assembly.GetManifestResourceStream(inputPath); ;
            string filename = "WhatIfAnalysisTemplate.xlsx";
            InputTemplate obj = new InputTemplate();
            obj.GetInputTeamplate(input, filename, ".xlsx");
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
            var hwnd = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            if (!(Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons")))
            {
                FileSavePicker savePicker = new FileSavePicker();
                {
                    savePicker.DefaultFileExtension = ".xlsx";
                    savePicker.SuggestedFileName = filename;
                    savePicker.FileTypeChoices.Add("Excel Documents", new List<string>() { ".xlsx" });
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
