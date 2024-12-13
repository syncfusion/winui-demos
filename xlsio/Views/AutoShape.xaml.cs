#region Copyright Syncfusion Inc. 2001 - 2024
// Copyright Syncfusion Inc. 2001 - 2024. All rights reserved.
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
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Popups;

namespace Syncfusion.XlsIODemos.WinUI.Views
{
    /// <summary>
    /// Interaction logic for AutoShape.xaml
    /// </summary>
    public partial class AutoShape : Page
    {
        #region Constructor
        /// <summary>
        /// AutoShape constructor
        /// </summary>
        public AutoShape()
        {
            this.InitializeComponent();            
        }
        # endregion

        # region Events
        /// <summary>
        /// Creates spreadsheet with AutoShapes
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

                application.DefaultVersion = ExcelVersion.Xlsx;

                //A new workbook is created.[Equivalent to creating a new workbook in MS Excel]
                //The new workbook will have 1 worksheet.
                IWorkbook workbook = application.Workbooks.Create(1);
                //The first worksheet object in the worksheets collection is accessed.
                IWorksheet worksheet = workbook.Worksheets[0];

                #region AddAutoShapes
                IShape shape;
                string text;

                IFont font = workbook.CreateFont();
                font.Color = ExcelKnownColors.White;
                font.Italic = true;
                font.Size = 12;


                IFont font2 = workbook.CreateFont();
                font2.Color = ExcelKnownColors.Black;
                font2.Size = 15;
                font2.Italic = true;
                font2.Bold = true;

                text = "Requirement";
                shape = worksheet.Shapes.AddAutoShapes(AutoShapeType.RoundedRectangle, 2, 7, 60, 192);
                shape.TextFrame.TextRange.Text = text;
                shape.TextFrame.TextRange.RichText.SetFont(0, text.Length - 1, font);
                shape.TextFrame.TextRange.RichText.SetFont(0, 0, font2);
                shape.Fill.ForeColorIndex = ExcelKnownColors.Light_blue;
                shape.Line.Visible = false;
                shape.TextFrame.VerticalAlignment = ExcelVerticalAlignment.MiddleCentered;

                shape = worksheet.Shapes.AddAutoShapes(AutoShapeType.DownArrow, 5, 8, 40, 64);
                shape.Fill.ForeColorIndex = ExcelKnownColors.White;
                shape.Line.ForeColorIndex = ExcelKnownColors.Blue;
                shape.Line.Weight = 1;

                text = "Design";
                shape = worksheet.Shapes.AddAutoShapes(AutoShapeType.RoundedRectangle, 7, 7, 60, 192);
                shape.TextFrame.TextRange.Text = text;
                shape.TextFrame.TextRange.RichText.SetFont(0, text.Length - 1, font);
                shape.TextFrame.TextRange.RichText.SetFont(0, 0, font2);
                shape.Line.Visible = false;
                shape.Fill.ForeColorIndex = ExcelKnownColors.Light_orange;
                shape.TextFrame.VerticalAlignment = ExcelVerticalAlignment.MiddleCentered;


                shape = worksheet.Shapes.AddAutoShapes(AutoShapeType.DownArrow, 10, 8, 40, 64);
                shape.Fill.ForeColorIndex = ExcelKnownColors.White;
                shape.Line.ForeColorIndex = ExcelKnownColors.Blue;
                shape.Line.Weight = 1;

                text = "Execution";
                shape = worksheet.Shapes.AddAutoShapes(AutoShapeType.RoundedRectangle, 12, 7, 60, 192);
                shape.TextFrame.TextRange.Text = text;
                shape.TextFrame.TextRange.RichText.SetFont(0, text.Length - 1, font);
                shape.TextFrame.TextRange.RichText.SetFont(0, 0, font2);
                shape.Line.Visible = false;
                shape.Fill.ForeColorIndex = ExcelKnownColors.Blue;
                shape.TextFrame.VerticalAlignment = ExcelVerticalAlignment.MiddleCentered;

                shape = worksheet.Shapes.AddAutoShapes(AutoShapeType.DownArrow, 15, 8, 40, 64);
                shape.Fill.ForeColorIndex = ExcelKnownColors.White;
                shape.Line.ForeColorIndex = ExcelKnownColors.Blue;
                shape.Line.Weight = 1;

                text = "Testing";
                shape = worksheet.Shapes.AddAutoShapes(AutoShapeType.RoundedRectangle, 17, 7, 60, 192);
                shape.TextFrame.TextRange.Text = text;
                shape.TextFrame.TextRange.RichText.SetFont(0, text.Length - 1, font);
                shape.TextFrame.TextRange.RichText.SetFont(0, 0, font2);
                shape.Line.Visible = false;
                shape.Fill.ForeColorIndex = ExcelKnownColors.Green;
                shape.TextFrame.VerticalAlignment = ExcelVerticalAlignment.MiddleCentered;

                shape = worksheet.Shapes.AddAutoShapes(AutoShapeType.DownArrow, 20, 8, 40, 64);
                shape.Fill.ForeColorIndex = ExcelKnownColors.White;
                shape.Line.ForeColorIndex = ExcelKnownColors.Blue;
                shape.Line.Weight = 1;

                text = "Release";
                shape = worksheet.Shapes.AddAutoShapes(AutoShapeType.RoundedRectangle, 22, 7, 60, 192);
                shape.TextFrame.TextRange.Text = text;
                shape.TextFrame.TextRange.RichText.SetFont(0, text.Length - 1, font);
                shape.TextFrame.TextRange.RichText.SetFont(0, 0, font2);
                shape.Line.Visible = false;
                shape.Fill.ForeColorIndex = ExcelKnownColors.Lavender;
                shape.TextFrame.VerticalAlignment = ExcelVerticalAlignment.MiddleCentered;
                #endregion

                //Saving the workbook to disk.
                string filename = "AutoShapes.xlsx";
                MemoryStream stream = new MemoryStream();
                workbook.SaveAs(stream);
                Save(stream, filename);

                //No exception will be thrown if there are unsaved workbooks.
                excelEngine.ThrowNotSavedOnDestroy = false;
                
                stream.Dispose();
            }
        }
        # endregion

        #region HelperMethods
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
        # endregion
    }
}