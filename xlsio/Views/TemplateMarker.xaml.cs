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
using Windows.Storage;
using Windows.Storage.Pickers;
using System.Collections.Generic;
using Windows.Storage.Streams;
using System.Reflection;
using System.Xml.Linq;
using System.Linq;
using EssentialXlsIO;

namespace Syncfusion.XlsIODemos.WinUI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class TemplateMarker : Page
    {
        #region Initializing Methods
        public TemplateMarker()
        {
            this.InitializeComponent();            
        }
        #endregion

        #region Events
        /// <summary>
        /// Open the Input Template
        /// </summary>
        /// <param name="sender">Contains a reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>   
        private void btnInput_Click(object sender, RoutedEventArgs e)
        {
            string path = "Syncfusion.XlsIODemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.XlsIO.";
#endif
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;

                application.DefaultVersion = ExcelVersion.Xlsx;

                //Launching the Input Template using the default Application.[MS Excel Or Free ExcelViewer]            
                string inputPath = path + "Assets.XlsIO.TemplateMarker.xlsx";
                Assembly assembly = typeof(TemplateMarker).GetTypeInfo().Assembly;
                Stream input = assembly.GetManifestResourceStream(inputPath);
                InputTemplate obj = new InputTemplate();
                obj.GetInputTeamplate(input, "TemplateMarker.xlsx", ".xlsx");
                input.Dispose();                                              
            }
            
        }

        /// <summary>
        /// Create spreadsheet
        /// </summary>
        /// <param name="sender">Contains a reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>   
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            string path = "Syncfusion.XlsIODemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.XlsIO.";
#endif
            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.
            //Step 1 : Instantiate the spreadsheet creation engine.
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                //Step 2 : Instantiate the excel application object.
                IApplication application = excelEngine.Excel;

                application.DefaultVersion = ExcelVersion.Xlsx;

                string inputPath = path + "Assets.XlsIO.TemplateMarker.xlsx";
                Assembly assembly = typeof(TemplateMarker).GetTypeInfo().Assembly;
                Stream input = assembly.GetManifestResourceStream(inputPath);

                IWorkbook workbook = application.Workbooks.Open(input);
                IWorksheet worksheet1 = workbook.Worksheets[0];

                input = assembly.GetManifestResourceStream(path + "Assets.XlsIO.CLRObjects.xml");
                IList<Customers> list = GetList(input);
              

                #region Applying Marker
                //Create Template Marker Processor
                ITemplateMarkersProcessor marker = workbook.CreateTemplateMarkersProcessor();

                marker.AddVariable("Customers", list);

                //Process the markers in the template.
                marker.ApplyMarkers();
                #endregion

                string filename = "TemplateMarker";
                MemoryStream stream = new MemoryStream();
                if (rdbtnXLS.IsChecked == true)
                {
                    workbook.Version = ExcelVersion.Excel97to2003;
                    workbook.SaveAs(stream);
                    Save(stream, filename, true, false);                   
                }
                else
                {
                    workbook.SaveAs(stream);
                    Save(stream, filename, false, true);                    
                }

                input.Dispose();
                stream.Dispose();
            }
        }                          

        #endregion

        #region Helper Methods
        public IList<Customers> GetList(Stream fileStream)
        {
            string path = "Syncfusion.XlsIODemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.XlsIO.";
#endif
            IList<Customers> lstCustomers = new List<Customers>();
            fileStream.Position = 0;
            StreamReader reader = new StreamReader(fileStream);
            IEnumerable<Customers> customers = GetData<Customers>(reader.ReadToEnd());
            //Get the Path of the Image
            Assembly assembly = typeof(TemplateMarker).GetTypeInfo().Assembly;
            Stream imageStream;
            BinaryReader binaryReader;
            foreach (Customers cust in customers)
            {
                imageStream = assembly.GetManifestResourceStream(path + "Assets.XlsIO.Template_Marker_Images." + cust.ImageText);
                binaryReader = new BinaryReader(imageStream);
                byte[] hyperlinkImage = binaryReader.ReadBytes((int)imageStream.Length);
                cust.Hyperlink = new Hyperlink("https://help.syncfusion.com/file-formats/xlsio/working-with-template-markers", "", "Hyperlink", "Syncfusion", ExcelHyperLinkType.Url, hyperlinkImage);
                lstCustomers.Add(cust);
                imageStream.Dispose();
            }            
            return lstCustomers;
        }

        public static IEnumerable<T> GetData<T>(string xml)
        where T : Customers, new()
        {
            return XElement.Parse(xml)
               .Elements("Customers")
               .Select(c => new T
               {
                   SalesPerson = (string)c.Element("SalesPerson"),
                   SalesJanJune = (int)c.Element("SalesJanJune"),
                   SalesJulyDec = (int)c.Element("SalesJulyDec"),
                   Change = (int)c.Element("Change"),
                   ImageText= (string)c.Element("ImageText")
               });
        }

        /// <summary>
        ///Used to save the output file
        /// </summary>
        /// <param name="stream">Memory stream to store the output file</param>
        /// <param name="filename">Output file name</param>
        /// <param name="isXls">Boolean value indicates whether the file type is Xls or not</param>
        /// <param name="isXlsx">Boolean value indicates whether the file type is Xlsx or not</param>
        async void Save(MemoryStream stream, string filename, bool isXls, bool isXlsx)
        {
            StorageFile stFile;
            if (!(Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons")))
            {
                FileSavePicker savePicker = new FileSavePicker();
                if (isXlsx)
                {
                    savePicker.DefaultFileExtension = ".xlsx";
                    savePicker.SuggestedFileName = filename;
                    savePicker.FileTypeChoices.Add("Excel Documents", new List<string>() { ".xlsx" });
                }
                else if (isXls)
                {
                    savePicker.DefaultFileExtension = ".xls";
                    savePicker.SuggestedFileName = filename;
                    savePicker.FileTypeChoices.Add("Excel Documents", new List<string>() { ".xls" });
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