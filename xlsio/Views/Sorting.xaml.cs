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
    /// Interaction logic for Sorting.xaml
    /// </summary>
    public partial class Sorting : Page
    {
        SortOn sortOn;      
        OrderBy orderBy;
        string fileName = "Sorting.xlsx";
        public Sorting()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        #region Click Events       
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            sortOn = SortOn.Values;
            orderBy = OrderBy.Ascending;
            SortValues(fileName);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            sortOn = SortOn.CellColor;
            orderBy = OrderBy.OnTop;
            SortColor(fileName);
        }
        #endregion

        #region Input Template
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            string path = "Syncfusion.XlsIODemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.XlsIO.";
#endif
            //Launching the Input Template using the default Application.[MS Excel Or Free ExcelViewer]
            string inputPath = path + "Assets.XlsIO.SortingData.xlsx";
            Assembly assembly = typeof(Sorting).GetTypeInfo().Assembly;
            Stream input = assembly.GetManifestResourceStream(inputPath);
            InputTemplate obj = new InputTemplate();
            obj.GetInputTeamplate(input, "SortingData.xlsx", ".xlsx");
            input.Dispose();
        }
        #endregion

        #region Helper Methods
        private void SortColor(string outFileName)
        {
            string path = "Syncfusion.XlsIODemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.XlsIO.";
#endif
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Xlsx;

                string inputPath = path + "Assets.XlsIO.SortingData.xlsx";
                Assembly assembly = typeof(Sorting).GetTypeInfo().Assembly;
                Stream input = assembly.GetManifestResourceStream(inputPath);
                IWorkbook book = application.Workbooks.Open(input);

                IWorksheet sheet = book.Worksheets[1];
                IRange range = sheet["A2:C50"];

                IDataSort sorter = book.CreateDataSorter();
                sorter.SortRange = range;

                ISortField field = sorter.SortFields.Add(2, sortOn, orderBy);
                field.Color = Syncfusion.Drawing.Color.Red;

                field = sorter.SortFields.Add(2, sortOn, orderBy);
                field.Color = Syncfusion.Drawing.Color.Blue;

                sorter.Sort();
                book.Worksheets.Remove(0);

                MemoryStream stream = new MemoryStream();
                book.SaveAs(stream);
                Save(stream, outFileName);

                stream.Dispose();
            }

        }
        private void SortValues(string outFileName)
        {
            string path = "Syncfusion.XlsIODemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.XlsIO.";
#endif
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Xlsx;

                string inputPath = path + "Assets.XlsIO.SortingData.xlsx";
                Assembly assembly = typeof(Sorting).GetTypeInfo().Assembly;
                Stream input = assembly.GetManifestResourceStream(inputPath);
                IWorkbook book = application.Workbooks.Open(input);

                IWorksheet sheet = book.Worksheets[0];
                IRange range = sheet["A2:D51"];

                //Create the data sorter.
                IDataSort sorter = book.CreateDataSorter();
                //Specify the range to sort.
                sorter.SortRange = range;

                //Specify the sort field attributes (column index and sort order)
                ISortField field = sorter.SortFields.Add(0, sortOn, orderBy);

                //sort the data based on the sort field attributes.
                sorter.Sort();
                book.Worksheets.Remove(1);


                MemoryStream stream = new MemoryStream();
                book.SaveAs(stream);
                Save(stream, outFileName);

                stream.Dispose();
            }
        }
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
