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
using Syncfusion.Pdf;
using Syncfusion.XlsIORenderer;
using Windows.UI.Popups;

namespace Syncfusion.XlsIODemos.WinUI.Views
{
    /// <summary>
    /// Interaction logic for Comments.xaml
    /// </summary>
    public partial class Comments : Page
    {
        # region Constructor
        /// <summary>
        /// WhatIfAnalysis constructor
        /// </summary>
        public Comments()
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
                Assembly assembly = typeof(Comments).GetTypeInfo().Assembly;
                string inputPath = path + "Assets.XlsIO.CommentsTemplate.xlsx";
                Stream excelStream = assembly.GetManifestResourceStream(inputPath);
                IWorkbook workbook = application.Workbooks.Open(excelStream);
                IWorksheet worksheet = workbook.Worksheets[0];

                //Add Comments
                AddComments(worksheet);

                MemoryStream stream = new MemoryStream();
                workbook.SaveAs(stream);
                Save(stream, "ExcelComments.xlsx");
                excelStream.Dispose();
                stream.Dispose();
            }
        }
        /// <summary>
        /// Converts To PDF
        /// </summary>
        /// <param name="sender">Contains a reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void btnConvert_Click(object sender, RoutedEventArgs e)
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
                Assembly assembly = typeof(Comments).GetTypeInfo().Assembly;
                string inputPath = path + "Assets.XlsIO.CommentsTemplate.xlsx";
                Stream excelStream = assembly.GetManifestResourceStream(inputPath);
                IWorkbook workbook = application.Workbooks.Open(excelStream);
                IWorksheet worksheet = workbook.Worksheets[0];

                //Add Comments
                AddComments(worksheet);

                //Set print location of comments
                worksheet.PageSetup.PrintComments = ExcelPrintLocation.PrintSheetEnd;

                //Initialize XlsIORenderer and convert the Excel document to PDF
                XlsIORenderer.XlsIORenderer renderer = new XlsIORenderer.XlsIORenderer();
                PdfDocument document = renderer.ConvertToPDF(workbook);

                MemoryStream ms = new MemoryStream();
                document.Save(ms);
                ms.Position = 0;
                Save(ms, "ExcelComments.pdf");
                excelStream.Dispose();
                ms.Dispose();
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
            string inputPath = path + "Assets.XlsIO.CommentsTemplate.xlsx";
            Assembly assembly = typeof(Comments).GetTypeInfo().Assembly;
            Stream input = assembly.GetManifestResourceStream(inputPath); ;
            string filename = "CommentsTemplate.xlsx";
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
            string extension = Path.GetExtension(filename);
            StorageFile stFile;
            var hwnd = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            if (!(Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons")))
            {
                FileSavePicker savePicker = new FileSavePicker();
                if(extension == ".xlsx")
                {
                    savePicker.DefaultFileExtension = ".xlsx";
                    savePicker.SuggestedFileName = filename;
                    savePicker.FileTypeChoices.Add("Excel Documents", new List<string>() { ".xlsx" });
                }
                else if (extension == ".pdf")
                {
                    savePicker.DefaultFileExtension = ".pdf";
                    savePicker.SuggestedFileName = filename;
                    savePicker.FileTypeChoices.Add("Adobe PDF Document", new List<string>() { ".pdf" });
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
        private void AddComments(IWorksheet worksheet)
        {
            //Add Comments (Notes)
            IComment comment = worksheet.Range["H1"].AddComment();
            comment.Text = "This Total column comment will be printed at the end of sheet.";
            comment.IsVisible = true;

            //Add Threaded Comments
            IThreadedComment threadedComment = worksheet.Range["H16"].AddThreadedComment("What is the reason for the higher total amount of \"desk\"  in the west region?", "User1", DateTime.Now);
            threadedComment.AddReply("The unit cost of desk is higher compared to other items in the west region. As a result, the total amount is elevated.", "User2", DateTime.Now);
            threadedComment.AddReply("Additionally, Wilson sold 31 desks in the west region, which is also a contributing factor to the increased total amount.", "User3", DateTime.Now);
        }
        #endregion
    }
}
