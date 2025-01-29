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
using System.Collections;
using Syncfusion.DocIODemos.WinUI.Helpers;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;
using System.Xml.Serialization;

namespace DocIO
{
    /// <summary>
    /// Integration logic for xaml.
    /// </summary>
    public sealed partial class SalesInvoice : Page
    {
        #region Fields
        readonly Assembly assembly = typeof(SalesInvoice).GetTypeInfo().Assembly;
        string resourcePath;
        Stream fileStream;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes component.
        /// </summary>
        public SalesInvoice()
        {
            this.InitializeComponent();
            ArrayList orderID = GetTestOrderID();
            //Adds Customer ID to the list box.
            foreach (string id in orderID)
                listCustomer.Items.Add(id);
            listCustomer.SelectedIndex = 0;
        }
        #endregion

        #region Events
        /// <summary>
        /// Generates the sales invoice from an input Word template using Mail Merge.
        /// </summary>
        private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            string path;
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.DocIO.";
#else
            path = "Syncfusion.DocIODemos.WinUI.";
#endif
            //Gets the selected customer id.
            int id = Convert.ToInt32(listCustomer.SelectedItem);
            //Gets the input Word document.
            string resourcePath = path + "Assets.DocIO.SalesInvoiceDemo.docx";
            using Stream fileStream = assembly.GetManifestResourceStream(resourcePath);
            //Creates a new Word document instance.
            using WordDocument document = new();
            //Opens an existing Word document.
            document.Open(fileStream, FormatType.Automatic);
            //Creates MailMergeDataTable.
            MailMergeDataTable mailMergeDataTableOrder = GetTestOrder(id);
            MailMergeDataTable mailMergeDataTableOrderTotals = GetTestOrderTotals(id);
            MailMergeDataTable mailMergeDataTableOrderDetails = GetTestOrderDetails(id);
            //Executes Mail Merge with groups.
            document.MailMerge.ExecuteGroup(mailMergeDataTableOrder);
            document.MailMerge.ExecuteGroup(mailMergeDataTableOrderTotals);
            document.MailMerge.ExecuteGroup(mailMergeDataTableOrderDetails);

            #region Document SaveOption
            using MemoryStream ms = new();
            string filename = string.Empty;
            //Saves as .docx format.
            if (worddocx.IsChecked == true)
            {
                filename = "Sales Invoice.docx";
                //Saves the Word document to the memory stream.
                document.Save(ms, FormatType.Docx);
            }
            //Saves as .doc format.
            else if (worddoc.IsChecked == true)
            {
                filename = "Sales Invoice.doc";
                //Saves the Word document to the memory stream.
                document.Save(ms, FormatType.Doc);
            }
            //Saves as .pdf format.
            else if (pdf.IsChecked == true)
            {
                filename = "Sales Invoice.pdf";
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
        #endregion

        #region Helper methods
        /// <summary>
        /// Gets test order.
        /// </summary>
        private MailMergeDataTable GetTestOrder(int TestOrderId)
        {
            string path;
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.DocIO.";
#else
            path = "Syncfusion.DocIODemos.WinUI.";
#endif
            List<TestOrder> orders = new();
            //Reads data from xml.
            resourcePath = path + "Assets.DocIO.TestOrder.xml";
            fileStream = assembly.GetManifestResourceStream(resourcePath);

            XmlSerializer serializer = new(typeof(TestOrders));
            //Deserializes XML into DOM.
            TestOrders testorders = (TestOrders)serializer.Deserialize(fileStream);

            foreach (TestOrder testorder in testorders.TestOrder)
            {
                if (testorder.OrderID.ToString() == TestOrderId.ToString())
                    orders.Add(testorder);
            }

            //Creates MailMergeDataTable.
            MailMergeDataTable dataTable = new("Orders", orders);
            fileStream.Dispose();
            return dataTable;
        }
        /// <summary>
        /// Gets test order details.
        /// </summary>
        private MailMergeDataTable GetTestOrderDetails(int TestOrderId)
        {
            string path;
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.DocIO.";
#else
            path = "Syncfusion.DocIODemos.WinUI.";
#endif
            List<TestOrderDetail> orders = new();
            //Reads data from xml.
            resourcePath = path + "Assets.DocIO.TestOrderDetails.xml";
            fileStream = assembly.GetManifestResourceStream(resourcePath);

            XmlSerializer serializer = new(typeof(TestOrderDetails));
            //Deserializes XML into DOM.
            TestOrderDetails testorderDetails = (TestOrderDetails)serializer.Deserialize(fileStream);

            foreach (TestOrderDetail testorder in testorderDetails.TestOrderDetail)
            {
                if (testorder.OrderID.ToString() == TestOrderId.ToString())
                    orders.Add(testorder);
            }

            //Creates MailMergeDataTable.
            MailMergeDataTable dataTable = new("Order", orders);
            fileStream.Dispose();
            return dataTable;
        }
        /// <summary>
        /// Gets test order totals.
        /// </summary>
        private MailMergeDataTable GetTestOrderTotals(int TestOrderId)
        {
            string path;
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.DocIO.";
#else
            path = "Syncfusion.DocIODemos.WinUI.";
#endif
            List<TestOrderTotal> orders = new();
            //Reads data from xml.
            resourcePath = path + "Assets.DocIO.OrderTotals.xml";
            fileStream = assembly.GetManifestResourceStream(resourcePath);

            XmlSerializer serializer = new(typeof(TestOrderTotals));
            //Deserializes XML into DOM.
            TestOrderTotals testOrderTotals = (TestOrderTotals)serializer.Deserialize(fileStream);

            foreach (TestOrderTotal testorder in testOrderTotals.TestOrderTotal)
            {
                if (testorder.OrderID.ToString() == TestOrderId.ToString())
                    orders.Add(testorder);
            }

            //Creates MailMergeDataTable.
            MailMergeDataTable dataTable = new("OrderTotals", orders);
            fileStream.Dispose();
            return dataTable;
        }
        /// <summary>
        /// Gets test order id.
        /// </summary>
        private ArrayList GetTestOrderID()
        {
            string path;
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.DocIO.";
#else
            path = "Syncfusion.DocIODemos.WinUI.";
#endif
            //Reads data from xml.
            resourcePath = path + "Assets.DocIO.TestOrder.xml";
            fileStream = assembly.GetManifestResourceStream(resourcePath);

            XmlSerializer serializer = new(typeof(TestOrders));
            //Deserializes XML into DOM.
            TestOrders testOrders = (TestOrders)serializer.Deserialize(fileStream);

            ArrayList orderId = new();
            foreach (TestOrder testOrder in testOrders.TestOrder)
                orderId.Add(testOrder.OrderID);
            return orderId;
        }
        #endregion
    }

    #region Helper class
    /// <summary>
    /// Helper class to maintain collection of test orders.
    /// </summary>
    public class TestOrders
    {
        #region Fields
        private TestOrder[] testOrder;
        #endregion

        #region Properties
        [System.Xml.Serialization.XmlElementAttribute("TestOrder")]
        public TestOrder[] TestOrder
        {
            get
            {
                return testOrder;
            }
            set
            {
                testOrder = value;
            }
        }
        #endregion
    }
    /// <summary>
    /// Helper class to maintain test orders.
    /// </summary>
    public class TestOrder
    {
        #region Fields
        private string shipName;
        private string shipAddress;
        private string shipCity;
        private string shipRegion;
        private string shipPostalCode;
        private string shipCountry;
        private string customerID;
        private string customersCompanyName;
        private string address;
        private string city;
        private string region;
        private string postalCode;
        private string country;
        private string salesperson;
        private string orderID;
        private string orderDate;
        private string requiredDate;
        private string shippedDate;
        private string shippersCompanyName;
        #endregion

        #region Properties
        public string ShipName
        {
            get
            {
                return shipName;
            }
            set
            {
                shipName = value;
            }
        }
        public string ShipAddress
        {
            get
            {
                return shipAddress;
            }
            set
            {
                shipAddress = value;
            }
        }
        public string ShipCity
        {
            get
            {
                return shipCity;
            }
            set
            {
                shipCity = value;
            }
        }
        public string ShipRegion
        {
            get
            {
                return shipRegion;
            }
            set
            {
                shipRegion = value;
            }
        }
        public string ShipPostalCode
        {
            get
            {
                return shipPostalCode;
            }
            set
            {
                shipPostalCode = value;
            }
        }
        public string ShipCountry
        {
            get
            {
                return shipCountry;
            }
            set
            {
                shipCountry = value;
            }
        }
        public string CustomerID
        {
            get
            {
                return customerID;
            }
            set
            {
                customerID = value;
            }
        }
        public string CustomersCompanyName
        {
            get
            {
                return customersCompanyName;
            }
            set
            {
                customersCompanyName = value;
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
        public string Salesperson
        {
            get
            {
                return salesperson;
            }
            set
            {
                salesperson = value;
            }
        }
        public string OrderID
        {
            get
            {
                return orderID;
            }
            set
            {
                orderID = value;
            }
        }
        public string OrderDate
        {
            get
            {
                return orderDate;
            }
            set
            {
                orderDate = value;
            }
        }
        public string RequiredDate
        {
            get
            {
                return requiredDate;
            }
            set
            {
                requiredDate = value;
            }
        }
        public string ShippedDate
        {
            get
            {
                return shippedDate;
            }
            set
            {
                shippedDate = value;
            }
        }
        public string ShippersCompanyName
        {
            get
            {
                return shippersCompanyName;
            }
            set
            {
                shippersCompanyName = value;
            }
        }
        #endregion
    }
    /// <summary>
    /// Helper class to maintain collection of test order totals.
    /// </summary>
    public class TestOrderTotals
    {
        #region Fields
        private TestOrderTotal[] testOrderTotal;
        #endregion

        #region Properties
        [System.Xml.Serialization.XmlElementAttribute("TestOrderTotal")]
        public TestOrderTotal[] TestOrderTotal
        {
            get
            {
                return testOrderTotal;
            }
            set
            {
                testOrderTotal = value;
            }
        }
        #endregion
    }
    /// <summary>
    /// Helper class to maintain test order totals.
    /// </summary>
    public class TestOrderTotal
    {
        #region Fields
        private string orderID;
        private string subtotal;
        private string freight;
        private string total;
        #endregion

        #region Properties
        public string OrderID
        {
            get
            {
                return orderID;
            }
            set
            {
                orderID = value;
            }
        }
        public string Subtotal
        {
            get
            {
                return subtotal;
            }
            set
            {
                subtotal = value;
            }
        }
        public string Freight
        {
            get
            {
                return freight;
            }
            set
            {
                freight = value;
            }
        }
        public string Total
        {
            get
            {
                return total;
            }
            set
            {
                total = value;
            }
        }
        #endregion
    }
    /// <summary>
    /// Helper class to maintain collection of test order details.
    /// </summary>
    public class TestOrderDetails
    {
        #region Fields
        private TestOrderDetail[] testOrderDetail;
        #endregion

        #region Properties
        [System.Xml.Serialization.XmlElementAttribute("TestOrderDetail")]
        public TestOrderDetail[] TestOrderDetail
        {
            get
            {
                return testOrderDetail;
            }
            set
            {
                testOrderDetail = value;
            }
        }
        #endregion
    }
    /// <summary>
    /// Helper class to maintain test order details.
    /// </summary>
    public class TestOrderDetail
    {
        #region Fields
        private string orderID;
        private string productID;
        private string productName;
        private string unitPrice;
        private string quantity;
        private string discount;
        private string extendedPrice;
        #endregion

        #region Properties
        public string OrderID
        {
            get
            {
                return orderID;
            }
            set
            {
                orderID = value;
            }
        }
        public string ProductID
        {
            get
            {
                return productID;
            }
            set
            {
                productID = value;
            }
        }
        public string ProductName
        {
            get
            {
                return productName;
            }
            set
            {
                productName = value;
            }
        }
        public string UnitPrice
        {
            get
            {
                return unitPrice;
            }
            set
            {
                unitPrice = value;
            }
        }
        public string Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }
        public string Discount
        {
            get
            {
                return discount;
            }
            set
            {
                discount = value;
            }
        }
        public string ExtendedPrice
        {
            get
            {
                return extendedPrice;
            }
            set
            {
                extendedPrice = value;
            }
        }
        #endregion
    }
    #endregion
}
