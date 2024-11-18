#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Globalization.NumberFormatting;

namespace DataGrid
{
    public class DataBindingViewModel : NotificationObject ,IDisposable
    {
        public Dictionary<string, string[]> ShipCity = new Dictionary<string, string[]>();

        public DataBindingViewModel()
        {
            SetShipCity();
            // Binding List
            this.OrdersListDetails = this.PopulateOrders(100);
        }

        private ObservableCollection<Employee> employeeDetails = null;

        /// <summary>
        /// Gets or sets the EmployeeDetails.
        /// </summary>
        /// <value>The EmployeeDetails.</value>
        public ObservableCollection<Employee> EmployeeDetails
        {
            get
            {
                if (employeeDetails == null)
                    return new EmployeeViewModel().GetEmployeeDetails(100);
                else
                    return employeeDetails;
            }
        }

        private BindingList<OrderInfo> _ordersListDetails;

        /// <summary>
        /// Gets or sets the orders details.
        /// </summary>
        /// <value>The orders details.</value>
        public BindingList<OrderInfo> OrdersListDetails
        {
            get { return _ordersListDetails; }
            set { _ordersListDetails = value; }
        }

        ObservableCollection<dynamic> _dynamicOrders;

        /// <summary>
        /// Gets or sets the dynamic orders.
        /// </summary>
        /// <value>The dynamic orders.</value>
        public ObservableCollection<dynamic> DynamicOrders
        {
            get
            {
                if (_dynamicOrders == null)
                {
                    _dynamicOrders = this.PopulateData(100);
                }
                return _dynamicOrders;
            }
            set
            {
                _dynamicOrders = value;
                RaisePropertyChanged("DynamicOrders");
            }
        }


        #region Public Members

        /// <summary>
        /// Used to set the system default currency to numeric column NumberFormatter.
        /// </summary>
        public CurrencyFormatter SystemCurrency
        {
            get
            {
                IncrementNumberRounder rounder = new Windows.Globalization.NumberFormatting.IncrementNumberRounder();
                rounder.Increment = 0.01;
                return new CurrencyFormatter(Windows.System.UserProfile.GlobalizationPreferences.Currencies[0]) { NumberRounder = rounder };
            }
        }

        Random r = new Random();

        /// <summary>
        /// Gets the ship countries.
        /// </summary>
        /// <value>The ship countries.</value>
        public List<string> ShipCountries
        {
            get
            {
                return this.ShipCountry.ToList();
            }
        }

        #endregion

        #region Private Members

        internal BindingList<OrderInfo> PopulateOrders(int count)
        {
            BindingList<OrderInfo> orderCollection = new BindingList<OrderInfo>();

            for (int i = 0; i < count; i++)
            {
                var shipcountry = ShipCountry[r.Next(0, 5)];
                var shipcitycoll = ShipCity[shipcountry];

                OrderInfo orderInfo = new OrderInfo();
                orderInfo.OrderID = 10000 + i;
                orderInfo.CustomerID = CustomerID[r.Next(0, 14)];
                orderInfo.Quantity = Math.Round(r.Next(0, 1000) + r.NextDouble(), 0);
                orderInfo.ShipCountry = shipcountry;
                orderInfo.ShipCity = shipcitycoll[r.Next(shipcitycoll.Length - 1)];
                orderInfo.Freight = Math.Round(r.Next(0, 1000) + r.NextDouble(), 2);

                orderCollection.Add(orderInfo);
            }
            return orderCollection;
        }
        /// <summary>
        /// Gets the order.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns></returns>
        private dynamic GetOrder(int i)
        {
            dynamic dOrder = new ExpandoObject();

            dOrder.ProductID = 100 + i;
            dOrder.ProductName= ProductName[r.Next(0, 47)];
            dOrder.UnitPrice= r.Next(10, 500);
            dOrder.UnitsInStock= (double)r.Next(1, 40);
            dOrder.SupplierID = CustomerID[r.Next(0, 15)];
            return dOrder;
        }

        string[] ProductName = new string[]
        {
            "Alice Mutton",
            "NuNuCa Nub-Nougat-Creme",
            "Boston Crab Meat",
            "Raclette Courdavault",
            "Wimmers gute Semmelknodel",
            "Konbu",
            "Wimmers gute Semmelknödel",
            "Gorgonzola Telino",
            "Chartreuse verte",
            "Fløtemysost",
            "Carnarvon Tigers",
            "Thüringer Rostbratwurst",
            "Vegie-spread",
            "Tarte au sucre",
            "Valkoinen suklaa",
            "Queso Manchego La Pastora",
            "Perth Pasties",
            "Vegie-spread",
            "Tofu",
            "Sir Rodney's Scones",
            "Manjimup Dried Apples",
            "Tunnbröd",
            "Manjimup Dried Apples",
            "Ipoh Coffee",
            "Fløtemysost",
            "Carnarvon Tigers",
            "Teatime Chocolate Biscuits",
            "Inlagd Sill",
            "Teatime Chocolate Biscuits",
            "Steeleye Stout",
            "Boston Crab Meat",
            "Jack's New England Clam Chowder",
            "Ipoh Coffee",
            "Carnarvon Tigers",
            "Queso Cabrales",
            "Guaraná Fantástica",
            "Röd Kaviar",
            "Longlife Tofu",
            "Sirop d'érable",
            "Tarte au sucre",
            "Scottish Longbreads",
            "Spegesild",
            "Wimmers gute Semmelknödel",
            "Rhönbräu Klosterbier",
            "Queso Cabrales",
            "Valkoinen suklaa",
            "Rhönbräu Klosterbier",
            "Northwoods Cranberry Sauce",
            "Pavlova"
        };

        string[] ShipCountry = new string[]
        {
            "Argentina",
            "Austria",
            "Belgium",
            "Brazil",
            "Canada",
            "Denmark",
            "Finland",
            "France",
            "Germany",
            "Ireland",
            "Italy",
            "Mexico",
            "Norway",
            "Poland",
            "Portugal",
            "Spain",
            "Sweden",
            "Switzerland",
            "UK",
            "USA",
            "Venezuela"
        };

        /// <summary>
        /// Sets the ship city.
        /// </summary>
        private void SetShipCity()
        {
            string[] argentina = new string[] { "Buenos Aires" };

            string[] austria = new string[] { "Graz", "Salzburg" };

            string[] belgium = new string[] { "Bruxelles", "Charleroi" };

            string[] brazil = new string[] { "Campinas", "Resende", "Rio de Janeiro", "São Paulo" };

            string[] canada = new string[] { "Montréal", "Tsawassen", "Vancouver" };

            string[] denmark = new string[] { "Århus", "København" };

            string[] finland = new string[] { "Helsinki", "Oulu" };

            string[] france = new string[] { "Lille", "Lyon", "Marseille", "Nantes", "Paris", "Reims", "Strasbourg", "Toulouse", "Versailles" };

            string[] germany = new string[] { "Aachen", "Berlin", "Brandenburg", "Cunewalde", "Frankfurt a.M.", "Köln", "Leipzig", "Mannheim", "München", "Münster", "Stuttgart" };

            string[] ireland = new string[] { "Cork" };

            string[] italy = new string[] { "Bergamo", "Reggio Emilia", "Torino" };

            string[] mexico = new string[] { "México D.F." };

            string[] norway = new string[] { "Stavern" };

            string[] poland = new string[] { "Warszawa" };

            string[] portugal = new string[] { "Lisboa" };

            string[] spain = new string[] { "Barcelona", "Madrid", "Sevilla" };

            string[] sweden = new string[] { "Bräcke", "Luleå" };

            string[] switzerland = new string[] { "Bern", "Genève" };

            string[] uk = new string[] { "Colchester", "Hedge End", "London" };

            string[] usa = new string[] { "Albuquerque", "Anchorage", "Boise", "Butte", "Elgin", "Eugene", "Kirkland", "Lander", "Portland", "San Francisco", "Seattle", "Walla Walla" };

            string[] venezuela = new string[] { "Barquisimeto", "Caracas", "I. de Margarita", "San Cristóbal" };

            ShipCity.Add("Argentina", argentina);
            ShipCity.Add("Austria", austria);
            ShipCity.Add("Belgium", belgium);
            ShipCity.Add("Brazil", brazil);
            ShipCity.Add("Canada", canada);
            ShipCity.Add("Denmark", denmark);
            ShipCity.Add("Finland", finland);
            ShipCity.Add("France", france);
            ShipCity.Add("Germany", germany);
            ShipCity.Add("Ireland", ireland);
            ShipCity.Add("Italy", italy);
            ShipCity.Add("Mexico", mexico);
            ShipCity.Add("Norway", norway);
            ShipCity.Add("Poland", poland);
            ShipCity.Add("Portugal", portugal);
            ShipCity.Add("Spain", spain);
            ShipCity.Add("Sweden", sweden);
            ShipCity.Add("Switzerland", switzerland);
            ShipCity.Add("UK", uk);
            ShipCity.Add("USA", usa);
            ShipCity.Add("Venezuela", venezuela);
        }

        string[] CustomerID = new string[]
        {
            "ALFKI",
            "FRANS",
            "MEREP",
            "FOLKO",
            "SIMOB",
            "WARTH",
            "VAFFE",
            "FURIB",
            "SEVES",
            "LINOD",
            "RISCU",
            "PICCO",
            "BLONP",
            "WELLI",
            "FOLIG"
        };

        internal ObservableCollection<dynamic> PopulateData(int count)
        {
            var collection = new ObservableCollection<dynamic>();
            for (int i = 10000; i < count + 10000; i++)
            {
                collection.Add(GetOrder(i));
            }
            return collection;
        }
        #endregion

        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isdisposable)
        {
            if (OrdersListDetails != null)
            {
                foreach (var ordersDetail in OrdersListDetails)
                    (ordersDetail as OrderInfo).Dispose();
                OrdersListDetails.Clear();
            }
            if (DynamicOrders != null)
            {
                foreach (var dynamicOrder in DynamicOrders)
                    (dynamicOrder as dynamic).Dispose();
                DynamicOrders.Clear();
            }
            if (EmployeeDetails != null)
            {
                foreach (var employeeDetails in EmployeeDetails)
                         (employeeDetails as Employee).Dispose();
                EmployeeDetails.Clear();
            }
            if (ShipCountries != null)
                ShipCountries.Clear();
        }
        #endregion
    }
}