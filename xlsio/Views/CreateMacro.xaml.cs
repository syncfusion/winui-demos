#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.Office;
using Syncfusion.XlsIO;
using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.Storage.Streams;

namespace Syncfusion.XlsIODemos.WinUI.Views
{
    /// <summary>
    /// Interaction logic for CreateMacro.xaml
    /// </summary>
    public partial class CreateMacro : Page
    {
        # region Constructor
        /// <summary>
        /// CreateMacro constructor
        /// </summary>
        public CreateMacro()
        {
            this.InitializeComponent();
        }
        #endregion

        #region Events
        /// <summary>
        /// Creates and saves the macro file
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

                #region Initialize Workbook
                //An existing template workbook is opened.[Equivalent to the workbook in MS Excel]
                IWorkbook workbook;
                string path = "Syncfusion.XlsIODemos.WinUI.";
#if Main_SB
                path = "Syncfusion.SampleBrowser.WinUI.XlsIO.";
#endif
                string inputPath = path + "Assets.XlsIO.CreateMacroTemplate.xlsx";
                Assembly assembly = typeof(CreateMacro).GetTypeInfo().Assembly;
                Stream input = assembly.GetManifestResourceStream(inputPath);
                workbook = application.Workbooks.Open(input, ExcelOpenType.Automatic);

                //The first worksheet object in the worksheets collection is accessed.
                IWorksheet worksheet = workbook.Worksheets[0];
                #endregion

                #region Create Macro
                IVbaProject vbaProject = workbook.VbaProject;
                IVbaModule vbaModule = vbaProject.Modules.Add("Module1", VbaModuleType.StdModule);
                vbaModule.Code = GetVbaCode();
                #endregion

                #region Workbook Save
                string filename = "";
                MemoryStream stream = new MemoryStream();
                if (rdbtnXls.IsChecked.Value)
                {
                    filename = "CreateMacro.xls";
                    workbook.Version = ExcelVersion.Excel97to2003;
                    workbook.SaveAs(stream);
                    Save(stream, filename, true, false, false);
                }
                else if (rdbtnXltm.IsChecked.Value)
                {
                    filename = "CreateMacro.xltm";
                    workbook.SaveAs(stream, ExcelSaveType.SaveAsMacroTemplate);
                    Save(stream, filename, false, true, false);
                }
                else if (rdbtnXlsm.IsChecked.Value)
                {
                    filename = "CreateMacro.xlsm";
                    workbook.SaveAs(stream, ExcelSaveType.SaveAsMacro);
                    Save(stream, filename, false, false, true);
                }
                #endregion

                #region Close and Dispose                
                stream.Dispose();
                #endregion
            }
        }
        # endregion

        #region HelperMethods
        /// <summary>
        /// Get the Vba code as string
        /// </summary>
        private string GetVbaCode()
        {
            string vbaCode = "Sub Auto_Open()\n" +
                             "'\n" +
                             "' Auto_Open Macro\n" +
                             "'\n" +
                             "\n" +
                             "'\n" +
                                "Range(\"B3:C28\").Select\n" +
                                "Range(\"E3\").Activate\n" +
                                "Sheet1.Activate\n" +
                                "ActiveSheet.Shapes.AddChart2(276, xlAreaStacked).Select\n" +
                                "ActiveChart.SetSourceData Source:= Range(\"'Exchange Report'!$B$3:$C$28\")\n" +
                                "ActiveChart.Parent.Left = Range(\"F3\").Left + 3\n" +
                                "ActiveChart.Parent.Top = Range(\"F3\").Top\n" +
                                "ActiveChart.Parent.Width = Range(\"M3\").Left - ActiveChart.Parent.Left\n" +
                                "ActiveChart.Parent.Height = Range(\"F16\").Top - ActiveChart.Parent.Top\n" +
                                "ActiveChart.ChartTitle.Select\n" +
                                "ActiveChart.ChartTitle.Text = \"Open-Close Statistics\"\n" +
                                "Selection.Format.TextFrame2.TextRange.Characters.Text = \"Open-Close Statistics\"\n" +
                                "With Selection.Format.TextFrame2.TextRange.Characters(1, 21).Font\n" +
                                "    .BaselineOffset = 0\n" +
                                "    .Bold = msoFalse\n" +
                                "    .NameComplexScript = \" +mn-cs\"\n" +
                                "    .NameFarEast = \" +mn-ea\"\n" +
                                "    .Fill.Visible = msoTrue\n" +
                                "    .Fill.ForeColor.RGB = RGB(89, 89, 89)\n" +
                                "    .Fill.Transparency = 0\n" +
                                "    .Fill.Solid\n" +
                                "    .Size = 14\n" +
                                "    .Italic = msoFalse\n" +
                                "    .Kerning = 12\n" +
                                "    .Name = \" +mn-lt\"\n" +
                                "    .UnderlineStyle = msoNoUnderline\n" +
                                "    .Spacing = 0\n" +
                                "    .Strike = msoNoStrike\n" +
                                "End With\n" +
                                "ActiveChart.FullSeriesCollection(1).XValues = \"='Exchange Report'!$A$4:$A$28\"\n" +
                                "ActiveChart.ChartArea.Select\n" +
                                "ActiveChart.ChartTitle.Select\n" +
                                "Selection.Format.TextFrame2.TextRange.Font.Bold = msoTrue\n" +
                                "ActiveChart.ChartArea.Select\n" +
                                "ActiveChart.ChartTitle.Select\n" +
                                "Selection.Top = 8\n" +
                                "ActiveChart.ChartColor = 13\n" +
                             "End Sub";
            return vbaCode;
        }
        async void Save(MemoryStream stream, string filename, bool isXLS, bool isXLTM, bool isXLSM)
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
                else if (isXLTM)
                {
                    savePicker.DefaultFileExtension = ".xltm";
                    savePicker.SuggestedFileName = filename;
                    savePicker.FileTypeChoices.Add("Excel Documents", new List<string>() { ".xltm" });
                }
                else if (isXLSM)
                {
                    savePicker.DefaultFileExtension = ".xlsm";
                    savePicker.SuggestedFileName = filename;
                    savePicker.FileTypeChoices.Add("Excel Documents", new List<string>() { ".xlsm" });
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