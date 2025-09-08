#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.ComponentModel;
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
using System.Linq;

namespace syncfusion.xlsiodemos.winui.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class ImportCollectionObject : Page
    {
        # region Constructor
        /// <summary>
        /// ImportCollectionObject constructor
        /// </summary>
        public ImportCollectionObject()
        {
            this.InitializeComponent();		
        }
        #endregion

        # region Events

        /// <summary>
        /// Export Data
        /// </summary>
        /// <param name="sender">Contains a reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private async void btnExportData_Click(object sender, RoutedEventArgs e)
        {            
            System.Diagnostics.Stopwatch watcher = new System.Diagnostics.Stopwatch();
            watcher.Start();

            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                //Step 2 : Instantiate the excel application object.
                IApplication application = excelEngine.Excel;

                //Set the Default Version as Xlsx
                application.DefaultVersion = ExcelVersion.Xlsx;

                //A new workbook is created.[Equivalent to creating a new workbook in MS Excel]
                //The new workbook will have 3 worksheets
                IWorkbook workbook = application.Workbooks.Create(1);
                //The first worksheet object in the worksheets collection is accessed.
                IWorksheet sheet = workbook.Worksheets[0];
               
                sheet.ImportData((List<Brand>)this.grdViewExport.ItemsSource, 4, 1, true);

                #region Define Styles
                IStyle pageHeader = workbook.Styles.Add("PageHeaderStyle");
                IStyle tableHeader = workbook.Styles.Add("TableHeaderStyle");

                pageHeader.Font.FontName = "Calibri";
                pageHeader.Font.Size = 16;
                pageHeader.Font.Bold = true;
                pageHeader.Color = Syncfusion.Drawing.Color.FromArgb(0, 146, 208, 80);
                pageHeader.HorizontalAlignment = ExcelHAlign.HAlignCenter;
                pageHeader.VerticalAlignment = ExcelVAlign.VAlignCenter;

                tableHeader.Font.Bold = true;
                tableHeader.Font.FontName = "Calibri";
                tableHeader.Color = Syncfusion.Drawing.Color.FromArgb(0, 146, 208, 80);

                #endregion

                #region Apply Styles
                // Apply style for header
                sheet["A1:C2"].Merge();
                sheet["A1"].Text = "Automobile Brands in the US";
                sheet["A1"].CellStyle = pageHeader;

                sheet["A4:C4"].CellStyle = tableHeader;

                sheet.Columns[0].ColumnWidth = 10;
                sheet.Columns[1].ColumnWidth = 20;
                sheet.Columns[2].ColumnWidth = 25;
                #endregion

                string filename;
                if (workbook.Version == ExcelVersion.Excel97to2003)
                {
                    filename = "CollectionObjects.xls";
                    MemoryStream stream = new MemoryStream();
                    workbook.SaveAs(stream);
                    Save(stream, filename, true, false);
                    stream.Dispose();
                }
                else
                {
                    filename = "CollectionObjects.xlsx";
                    MemoryStream stream = new MemoryStream();
                    workbook.SaveAs(stream);
                    Save(stream, filename, false, true);
                    stream.Dispose();
                }
                               
            }
        }

        /// <summary>
        ///  Opens input template
        /// </summary>
        /// <param name="sender">Contains a reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private async void btnInput_Click(object sender, RoutedEventArgs e)
        {
            string inputPath = "syncfusion.xlsiodemos.winui.Assets.XlsIO.ExportData.xlsx";

            Assembly assembly = typeof(ImportHTMLTable).GetTypeInfo().Assembly;
            Stream input = assembly.GetManifestResourceStream(inputPath);

            InputTemplate obj = new InputTemplate();
            obj.GetInputTeamplate(input, "ExportData.xlsx", ".xlsx");
            input.Dispose();
        }
        /// <summary>
        /// Import Data
        /// </summary>
        /// <param name="sender">Contains a reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private async void btnImportData_Click(object sender, RoutedEventArgs e)
        {           
            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.

            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;

                application.DefaultVersion = ExcelVersion.Xlsx;
                // For Export Data           
                string inputPath = "syncfusion.xlsiodemos.winui.Assets.XlsIO.ExportData.xlsx";
                Assembly assembly = typeof(ImportHTMLTable).GetTypeInfo().Assembly;
                Stream input = assembly.GetManifestResourceStream(inputPath);
                IWorkbook workbook = application.Workbooks.Open(input);
                //The first worksheet object in the worksheets collection is accessed.
                IWorksheet worksheet = workbook.Worksheets[0];

                Dictionary<string, string> mappingProperties = new Dictionary<string, string>();
                mappingProperties.Add("Brand", "BrandName");
                mappingProperties.Add("Vehicle Type", "VehicleType.VehicleName");
                mappingProperties.Add("Model", "VehicleType.Model.ModelName");

                List<Brand> CLRObjects = worksheet.ExportData<Brand>(4, 1, 141, 3, mappingProperties);

                this.grdViewExport.ItemsSource = CLRObjects;
                btnExportData.IsEnabled = true;
                input.Dispose();
            }
        }

        #endregion

        #region HelperMethods
        /// <summary>
        ///Used to save the output file
        /// </summary>
        /// <param name="stream">Memory stream to store the output file</param>
        /// <param name="filename">Output file name</param>
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
    #region HelperClasses
    public class Brand
    {
        private string m_brandName;
        [DisplayNameAttribute("Brand")]
        public string BrandName
        {
            get { return m_brandName; }
            set { m_brandName = value; }
        }

        private VehicleType m_vehicleType;
        public VehicleType VehicleType
        {
            get { return m_vehicleType; }
            set { m_vehicleType = value; }
        }

        public Brand(string brandName)
        {
            m_brandName = brandName;
        }
        public Brand()
        {

        }
    }

    public class VehicleType
    {
        private string m_vehicleName;
        [DisplayNameAttribute("Vehicle Type")]
        public string VehicleName
        {
            get { return m_vehicleName; }
            set { m_vehicleName = value; }
        }

        private Model m_model;
        public Model Model
        {
            get { return m_model; }
            set { m_model = value; }
        }

        public VehicleType(string vehicle)
        {
            m_vehicleName = vehicle;
        }
        public VehicleType()
        {

        }
    }

    public class Model
    {
        private string m_modelName;
        [DisplayNameAttribute("Model")]
        public string ModelName
        {
            get { return m_modelName; }
            set { m_modelName = value; }
        }

        public Model(string name)
        {
            m_modelName = name;
        }
        public Model()
        {

        }
    }

    /// <summary>
    /// This class represents the DataBoundViewModel
    /// </summary>
    public class ImportAndExport : INotifyPropertyChanged, IDisposable
    {

        public ImportAndExport()
        {
            CustomersInfo = new List<Brand>();
            foreach (int i in Enumerable.Range(1, 20))
            {
                CustomersInfo.Add(new Brand());
            }
        }
        private List<Brand> customersInfo = null;
        /// <summary>
        /// Gets or sets the OrderListDetails.
        /// </summary>
        /// <value>The OrderListDetails.</value>
        ///         #region ItemsSource
        public List<Brand> CustomersInfo
        {
            get { return customersInfo; }
            set { this.customersInfo = value;}
        }    

        public event PropertyChangedEventHandler PropertyChanged;


        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isdisposable)
        {
            if (CustomersInfo != null)
            {
                CustomersInfo.Clear();
            }
        }
    }
    #endregion
}