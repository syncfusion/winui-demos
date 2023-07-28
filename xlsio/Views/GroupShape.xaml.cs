#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.XlsIO;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Reflection;
using System.IO;
using Windows.Storage;
using Windows.Storage.Pickers;
using System.Collections.Generic;
using Windows.Storage.Streams;

namespace Syncfusion.XlsIODemos.WinUI.Views
{
    /// <summary>
    /// Interaction logic for GroupShape.xaml
    /// </summary>
    public partial class GroupShape : Page
    {
        #region Constructor
        /// <summary>
        /// GroupShape Constructor
        /// </summary>
        public GroupShape()
        {
            this.InitializeComponent();           
        }
        #endregion

        # region Events
        /// <summary>
        /// Opens input template
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event</param>
        /// <param name="e">contains the event data</param>
        private void btnInput_Click(object sender, RoutedEventArgs e)
        {
            string path = "Syncfusion.XlsIODemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.XlsIO.";
#endif
            string inputPath = path + "Assets.XlsIO.GroupShapes.xlsx";

            Assembly assembly = typeof(EditMacro).GetTypeInfo().Assembly;
            Stream input = assembly.GetManifestResourceStream(inputPath);
            InputTemplate obj = new InputTemplate();
            obj.GetInputTeamplate(input, "GroupShapes.xlsx", ".xlsx");
            input.Dispose();
        }

        /// <summary>
        /// Create spreadsheet with group shapes
        /// </summary>
        /// <param name="sender">contains a reference to the control/object that raised the event</param>
        /// <param name="e">contains the event data</param>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            string path = "Syncfusion.XlsIODemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.XlsIO.";
#endif
            // New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            // The instantiation process consists of two steps.

            // Step 1 : Instantiate the spreadsheet creation engine.
            using (ExcelEngine excelEngine = new ExcelEngine())
            {

                // Step 2 : Instantiate the excel application object.
                IApplication application = excelEngine.Excel;

                // An existing workbook is opened.
                string inputPath = path + "Assets.XlsIO.GroupShapes.xlsx";
                Assembly assembly = typeof(CreateSpreadsheet).GetTypeInfo().Assembly;
                Stream input = assembly.GetManifestResourceStream(inputPath);
                IWorkbook workbook = application.Workbooks.Open(input);

                // The first worksheet object in the worksheets collection is accessed.
                IWorksheet worksheet;

                string filename = string.Empty;
                MemoryStream stream = new MemoryStream();

                if (rdbtnGroup.IsChecked.Value)
                {
                    // The first worksheet object in the worksheets collection is accessed.
                    worksheet = workbook.Worksheets[0];
                    IShapes shapes = worksheet.Shapes;

                    IShape[] groupItems;
                    for (int i = 0; i < shapes.Count; i++)
                    {
                        if (shapes[i].Name == "Development" || shapes[i].Name == "Production" || shapes[i].Name == "Sales")
                        {
                            groupItems = new IShape[] { shapes[i], shapes[i + 1], shapes[i + 2], shapes[i + 3], shapes[i + 4], shapes[i + 5] };
                            shapes.Group(groupItems);
                            i = -1;
                        }
                    }

                    groupItems = new IShape[] { shapes[0], shapes[1], shapes[2], shapes[3], shapes[4], shapes[5], shapes[6] };
                    shapes.Group(groupItems);

                    filename = "Group.xlsx";

                    workbook.SaveAs(stream);
                    Save(stream, filename);
                }
                else if (rdbtnUngroupAll.IsChecked.Value)
                {
                    // The second worksheet object in the worksheets collection is accessed.
                    worksheet = workbook.Worksheets[1];
                    IShapes shapes = worksheet.Shapes;
                    shapes.Ungroup(shapes[0] as IGroupShape, true);
                    worksheet.Activate();
                    filename = "UngroupAll.xlsx";

                    workbook.SaveAs(stream);
                    Save(stream, filename);
                }
                else if (rdbtnUngroup.IsChecked.Value)
                {
                    // The second worksheet object in the worksheets collection is accessed.
                    worksheet = workbook.Worksheets[1];
                    IShapes shapes = worksheet.Shapes;
                    shapes.Ungroup(shapes[0] as IGroupShape);
                    worksheet.Activate();
                    filename = "Ungroup.xlsx";

                    workbook.SaveAs(stream);
                    Save(stream, filename);
                }

                input.Dispose();
                stream.Dispose();
            }
        }
        #endregion        

        #region HelperMethods
        async void Save(MemoryStream stream, string filename)
        {
            StorageFile stFile;
            if (!(Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons")))
            {
                FileSavePicker savePicker = new FileSavePicker();
                savePicker.DefaultFileExtension = ".xlsx";
                savePicker.SuggestedFileName = filename;
                savePicker.FileTypeChoices.Add("Excel Documents", new List<string>() { ".xlsx" });
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