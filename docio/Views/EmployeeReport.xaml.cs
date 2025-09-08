#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.UI.Xaml.Controls;
using System.Reflection;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using Syncfusion.DocIODemos.WinUI.Helpers;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;
using System.Xml.Serialization;

namespace DocIO
{
    /// <summary>
    /// Integration logic for xaml.
    /// </summary>
    public sealed partial class EmployeeReport : Page
    {
        #region Fields
        readonly Assembly assembly = typeof(EmployeeReport).GetTypeInfo().Assembly;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes component.
        /// </summary>
        public EmployeeReport()
        {
            this.InitializeComponent();
        }
        #endregion

        #region Events
        #region  EmployeeReport
        /// <summary>
        /// Generates an employee report using Mail merge.
        /// </summary>
        private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            string path;
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.DocIO.";
#else
            path = "Syncfusion.DocIODemos.WinUI.";
#endif

            //Gets the input Word document.
            string dataPathEmployee = @path +"Assets.DocIO.EmployeesReportDemo.docx";
            using Stream fileStream = assembly.GetManifestResourceStream(dataPathEmployee);
            //Creates a new Word document instance.
            using WordDocument document = new();
            //Opens an existing Word document.
            document.Open(fileStream, FormatType.Doc);
            document.MailMerge.MergeImageField += new MergeImageFieldEventHandler(MergeField_EmployeeImage);
            //Creates MailMergeDataTable.
            MailMergeDataTable mailMergeDataTable = GetMailMergeDataTableEmployee();
            //Executes Mail Merge with groups. 
            document.MailMerge.ExecuteGroup(mailMergeDataTable);

            #region Document SaveOption
            using MemoryStream ms = new();
            string filename = string.Empty;
            //Saves as .docx format.
            if (worddocx.IsChecked == true)
            {
                filename = "Employee Report.docx";
                //Saves the Word document to the memory stream.
                document.Save(ms, FormatType.Docx);
            }
            //Saves as .doc format.
            else if (worddoc.IsChecked == true)
            {
                filename = "Employee Report.doc";
                //Saves the Word document to the memory stream.
                document.Save(ms, FormatType.Doc);
            }
            //Saves as .pdf format.
            else if (pdf.IsChecked == true)
            {
                filename = "Employee Report.pdf";
                //Creates a new DocIORenderer instance.
                using DocIORenderer renderer = new();
                //Converts Word document into PDF.
                using PdfDocument pdfDoc = renderer.ConvertToPDF(document);
                //Saves the PDF document to the memory stream.
                pdfDoc.Save(ms);
            }
            PdfDocument.ClearFontCache();
            ms.Position = 0;
            //Saves the memory stream as file.
            SaveHelper.SaveAndLaunch(filename, ms);
            #endregion Document SaveOption
        }
        /// <summary>
        /// Binds image from file system during mail merge.
        /// </summary>
        private void MergeField_EmployeeImage(object sender, MergeImageFieldEventArgs args)
        {
            //Gets the image from disk during Merge.
            if (args.FieldName == "Photo")
            {
                string ProductFileName = args.FieldValue.ToString();
                byte[] bytes = Convert.FromBase64String(ProductFileName);
                MemoryStream ms = new(bytes);
                args.ImageStream = ms;
            }
        }
        #endregion  EmployeeReport
        /// <summary>
        /// Opens the input template Word document.
        /// </summary>
        private void ButtonView_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            string path;
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.DocIO.";
#else
            path = "Syncfusion.DocIODemos.WinUI.";
#endif
            //Gets the input Word document.
            string dataPathEmployee = @path +"Assets.DocIO.EmployeesReportDemo.docx";
            using Stream fileStream = assembly.GetManifestResourceStream(dataPathEmployee);
            using MemoryStream ms = new();
            fileStream.CopyTo(ms);
            ms.Position = 0;
            //Saves the memory stream as file.
            SaveHelper.SaveAndLaunch("EmployeesReportDemo.docx", ms);
        }
        #endregion

        #region Helper methods
        /// <summary>
        /// Gets the MailMergeDataTable.
        /// </summary>        
        private MailMergeDataTable GetMailMergeDataTableEmployee()
        {
            string path;
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.DocIO.";
#else
            path = "Syncfusion.DocIODemos.WinUI.";
#endif

            List<Employee> employees = new();
            //Reads data from xml.
            Stream fileStream = assembly.GetManifestResourceStream(@path+"Assets.DocIO.EmployeesList.xml");

            XmlSerializer serializer = new(typeof(Employees));
            //Deserializes XML into DOM.
            Employees employeesList = (Employees)serializer.Deserialize(fileStream);

            foreach (Employee employee in employeesList.Employee)
                employees.Add(employee);

            //Creates MailMergeDataTable from xml.
            MailMergeDataTable dataTable = new("Employees", employees);
            fileStream.Dispose();
            return dataTable;
        }
        #endregion
    }

    #region Helper class
    /// <summary>
    /// Helper class to maintain collection of employee details.
    /// </summary>
    public class Employees
    {
        #region Fields
        private Employee[] employee;
        #endregion

        #region Properties
        [System.Xml.Serialization.XmlElementAttribute("Employee")]
        public Employee[] Employee
        {
            get
            {
                return employee;
            }
            set
            {
                employee = value;
            }
        }
        #endregion
    }
    /// <summary>
    ///  Helper class to maintain employee details.
    /// </summary>
    public class Employee
    {
        #region Fields
        private string employeeID;
        private string lastName;
        private string firstName;
        private string title;
        private string titleOfCourtesy;
        private string birthDate;
        private string hireDate;
        private string address;
        private string city;
        private string region;
        private string postalCode;
        private string country;
        private string homePhone;
        private string extension;
        private string photo;
        private string notes;
        private string reportsTo;
        #endregion

        #region Properties
        public string EmployeeID
        {
            get
            {
                return employeeID;
            }
            set
            {
                employeeID = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        public string TitleOfCourtesy
        {
            get
            {
                return titleOfCourtesy;
            }
            set
            {
                titleOfCourtesy = value;
            }
        }
        public string BirthDate
        {
            get
            {
                return birthDate;
            }
            set
            {
                birthDate = value;
            }
        }
        public string HireDate
        {
            get
            {
                return hireDate;
            }
            set
            {
                hireDate = value;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
            }
        }
        public string Region
        {
            get
            {
                return region;
            }
            set
            {
                region = value;
            }
        }
        public string PostalCode
        {
            get
            {
                return postalCode;
            }
            set
            {
                postalCode = value;
            }
        }
        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
            }
        }
        public string HomePhone
        {
            get
            {
                return homePhone;
            }
            set
            {
                homePhone = value;
            }
        }
        public string Extension
        {
            get
            {
                return extension;
            }
            set
            {
                extension = value;
            }
        }
        public string Photo
        {
            get
            {
                return photo;
            }
            set
            {
                photo = value;
            }
        }
        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
                notes = value;
            }
        }
        public string ReportsTo
        {
            get
            {
                return reportsTo;
            }
            set
            {
                reportsTo = value;
            }
        }
        #endregion
    }
    #endregion
}