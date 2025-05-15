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
using System.Reflection;
using Windows.Storage;
using Windows.Storage.Pickers;
using System.Collections.Generic;
using Windows.Storage.Streams;
using Windows.UI.Popups;

namespace Syncfusion.XlsIODemos.WinUI.Views
{
    /// <summary>
    /// Interaction logic for ConditionalFormatting.xaml
    /// </summary>
    public partial class ConditionalFormatting : Page
    {
        # region Constructor
        /// <summary>
        /// ConditionalFormatting constructor
        /// </summary>
        public ConditionalFormatting()
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
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                string OutputFilename = "ConditionalFormatting.xlsx";
                string path = "Syncfusion.XlsIODemos.WinUI.";
#if Main_SB
                path = "Syncfusion.SampleBrowser.WinUI.XlsIO.";
#endif
                string inputPath = path + "Assets.XlsIO.CFTemplate.xlsx";

                Assembly assembly = typeof(ConditionalFormatting).GetTypeInfo().Assembly;
                Stream input = assembly.GetManifestResourceStream(inputPath);
                IWorkbook myWorkbook = application.Workbooks.Open(input);
                myWorkbook.Version = ExcelVersion.Xlsx;

                IWorksheet sheet = myWorkbook.Worksheets[0];

                #region Databar
                //Add condition for the range
                IConditionalFormats formats = sheet.Range["C7:C46"].ConditionalFormats;
                IConditionalFormat format = formats.AddCondition();

                //Set Data bar and icon set for the same cell
                //Set the format type
                format.FormatType = ExcelCFType.DataBar;
                IDataBar dataBar = format.DataBar;

                //Set the constraint
                dataBar.MinPoint.Type = ConditionValueType.LowestValue;
                dataBar.MinPoint.Value = "0";
                dataBar.MaxPoint.Type = ConditionValueType.HighestValue;
                dataBar.MaxPoint.Value = "0";

                //Set color for Bar
                dataBar.BarColor = Syncfusion.Drawing.Color.FromArgb(156, 208, 243);

                //Hide the value in data bar
                dataBar.ShowValue = false;
                #endregion

                #region Iconset
                //Add another condition in the same range
                format = formats.AddCondition();

                //Set Icon format type
                format.FormatType = ExcelCFType.IconSet;
                IIconSet iconSet = format.IconSet;
                iconSet.IconSet = ExcelIconSetType.FourRating;
                iconSet.IconCriteria[0].Type = ConditionValueType.LowestValue;
                iconSet.IconCriteria[0].Value = "0";
                iconSet.IconCriteria[1].Type = ConditionValueType.HighestValue;
                iconSet.IconCriteria[1].Value = "0";
                iconSet.ShowIconOnly = true;

                //Sets Icon sets for another range
                formats = sheet.Range["E7:E46"].ConditionalFormats;
                format = formats.AddCondition();
                format.FormatType = ExcelCFType.IconSet;
                iconSet = format.IconSet;
                iconSet.IconSet = ExcelIconSetType.ThreeSymbols;
                iconSet.IconCriteria[0].Type = ConditionValueType.LowestValue;
                iconSet.IconCriteria[0].Value = "0";
                iconSet.IconCriteria[1].Type = ConditionValueType.HighestValue;
                iconSet.IconCriteria[1].Value = "0";
                iconSet.ShowIconOnly = true;
                #endregion

                #region Databar Negative value settings
                //Add condition for the range
                IConditionalFormats conditionalFormats1 = sheet.Range["E7:E46"].ConditionalFormats;
                IConditionalFormat conditionalFormat1 = conditionalFormats1.AddCondition();

                //Set Data bar and icon set for the same cell
                //Set the conditionalFormat type
                conditionalFormat1.FormatType = ExcelCFType.DataBar;
                IDataBar dataBar1 = conditionalFormat1.DataBar;

                //Set the constraint
                dataBar1.BarColor = Syncfusion.Drawing.Color.YellowGreen;
                dataBar1.NegativeFillColor = Syncfusion.Drawing.Color.Pink;
                dataBar1.NegativeBorderColor = Syncfusion.Drawing.Color.WhiteSmoke;
                dataBar1.BarAxisColor = Syncfusion.Drawing.Color.Yellow;
                dataBar1.BorderColor = Syncfusion.Drawing.Color.WhiteSmoke;
                dataBar1.DataBarDirection = DataBarDirection.context;
                dataBar1.DataBarAxisPosition = DataBarAxisPosition.middle;
                dataBar1.HasGradientFill = true;

                //Hide the value in data bar
                dataBar1.ShowValue = false;

                #endregion

                #region Duplicate
                formats = sheet.Range["D7:D46"].ConditionalFormats;
                format = formats.AddCondition();
                format.FormatType = ExcelCFType.Duplicate;

                format.BackColorRGB = Syncfusion.Drawing.Color.FromArgb(255, 199, 206);
                #endregion

                #region TopBottom and AboveBelowAverage
                sheet = myWorkbook.Worksheets[1];
                formats = sheet.Range["N6:N35"].ConditionalFormats;
                format = formats.AddCondition();
                format.FormatType = ExcelCFType.TopBottom;
                format.TopBottom.Type = ExcelCFTopBottomType.Bottom;

                format.BackColorRGB = Syncfusion.Drawing.Color.FromArgb(51, 153, 102);

                formats = sheet.Range["M6:M35"].ConditionalFormats;
                format = formats.AddCondition();
                format.FormatType = ExcelCFType.AboveBelowAverage;
                format.AboveBelowAverage.AverageType = ExcelCFAverageType.Below;

                format.FontColorRGB = Syncfusion.Drawing.Color.FromArgb(255, 255, 255);
                format.BackColorRGB = Syncfusion.Drawing.Color.FromArgb(166, 59, 38);
                #endregion

                //Saving the workbook to disk.
                MemoryStream stream = new MemoryStream();
                myWorkbook.SaveAs(stream);
                Save(stream, OutputFilename);
                stream.Dispose();

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
        async void Save(MemoryStream stream, string filename)
        {
            StorageFile stFile;
            var hwnd = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            if (!(Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons")))
            {
                FileSavePicker savePicker = new FileSavePicker();
                savePicker.DefaultFileExtension = ".xlsx";
                savePicker.SuggestedFileName = filename;
                savePicker.FileTypeChoices.Add("Excel Documents", new List<string>() { ".xlsx" });
                
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