#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Store;
using Windows.Globalization.NumberFormatting;

namespace DataGrid
{
    public class OrderInfoViewModel : NotificationObject, IDisposable
    {
        static int countrycount;
        static int discountcount = 2;
        Random randomValue = new Random();
        int count = 100;

        Dictionary<string, string[]> shipCities = new Dictionary<string, string[]>();

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderInfoViewModel"/> class.
        /// </summary>
        public OrderInfoViewModel()
        {
            this.OrderedDates = GetDateBetween(2008, 2012, count);
            this.OrdersAdd(100);
            SetShipCity();
            this.PopulateData();
            productCollection = GetProducts();
        }

        private void OrdersAdd(int count)
        {
            ord.Add(new OrderInfo(10000, 239800, 12, 5, 0.10, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Newyork"));
            ord.Add(new OrderInfo(10000, 587929, 14, 10, 0.02, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Washington"));
            ord.Add(new OrderInfo(10000, 299913, 18, 5, 0.10, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "London"));

            ord.Add(new OrderInfo(10001, 445654, 23, 76, 0.06, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Brisbane"));
            ord.Add(new OrderInfo(10001, 690871, 45, 23, 0.05, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Durban"));
            ord.Add(new OrderInfo(10001, 434762, 45, 16, 0.03, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Auckland"));
            ord.Add(new OrderInfo(10001, 989875, 23, 15, 0.02, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Wellington"));
            ord.Add(new OrderInfo(10002, 723480, 7, 6, 0.04, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Newyork"));
            ord.Add(new OrderInfo(10002, 245683, 30, 5, 0.02, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Melbourne"));
            ord.Add(new OrderInfo(10003, 213463, 73, 9, 0.03, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Brisbane"));
            ord.Add(new OrderInfo(10003, 890898, 11, 8, 0.07, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Perth"));
            ord.Add(new OrderInfo(10003, 167590, 150, 1, 0.08, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Durban"));
            ord.Add(new OrderInfo(10009, 469879, 35, 4, 0.03, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Brisbane"));
            ord.Add(new OrderInfo(10009, 254389, 31, 7, 0.5, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Perth"));
            ord.Add(new OrderInfo(10010, 790859, 23, 3, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Auckland"));
            ord.Add(new OrderInfo(10010, 565560, 65, 4, 0.04, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Wellington"));
            ord.Add(new OrderInfo(10010, 345767, 15, 5, 0.06, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Manchester"));
            ord.Add(new OrderInfo(10010, 290898, 31, 1, 0.07, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Durban"));
            ord.Add(new OrderInfo(10011, 667876, 46, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "London"));
            ord.Add(new OrderInfo(10011, 345676, 45, 4, 0.03, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Melbourne"));
            ord.Add(new OrderInfo(10011, 289780, 41, 7, 0.02, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Washington"));
            ord.Add(new OrderInfo(10013, 195678, 80, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Melbourne"));
            ord.Add(new OrderInfo(10013, 204345, 111, 1, 0.07, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Auckland"));
            ord.Add(new OrderInfo(10021, 548908, 35, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Brisbane"));
            ord.Add(new OrderInfo(10021, 634567, 46, 7, 0.03, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Perth"));
            ord.Add(new OrderInfo(10021, 275467, 99, 5, 0.05, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Auckland"));
            ord.Add(new OrderInfo(10022, 598907, 80, 3, 0.03, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Wellington"));
            ord.Add(new OrderInfo(10022, 605678, 111, 1, 0.07, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Manchester"));
            ord.Add(new OrderInfo(10022, 472345, 35, 9, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Durban"));
            ord.Add(new OrderInfo(10032, 445678, 35, 6, 0.09, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "London"));
            ord.Add(new OrderInfo(10032, 690909, 46, 8, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Melbourne"));
            ord.Add(new OrderInfo(10034, 174356, 99, 1, 0.10, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Washington"));
            ord.Add(new OrderInfo(10034, 196789, 80, 5, 0.04, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Melbourne"));
            ord.Add(new OrderInfo(10034, 206578, 111, 3, 0.07, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "London"));
            ord.Add(new OrderInfo(10042, 454578, 35, 1, 0.025, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Melbourne"));
            ord.Add(new OrderInfo(10042, 489076, 35, 9, 0.3, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Washington"));
            ord.Add(new OrderInfo(10045, 667890, 46, 7, 0.04, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Melbourne"));
            ord.Add(new OrderInfo(10045, 174356, 99, 3, 0.03, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "London"));
            ord.Add(new OrderInfo(10045, 199890, 80, 6, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Melbourne"));
            ord.Add(new OrderInfo(10045, 204356, 111, 1, 0.07, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Perth"));
            ord.Add(new OrderInfo(10056, 489087, 35, 2, 0.08, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Brisbane"));
            ord.Add(new OrderInfo(10056, 443567, 35, 7, 0.04, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Perth"));
            ord.Add(new OrderInfo(10056, 612367, 46, 4, 0.06, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Auckland"));
            ord.Add(new OrderInfo(10067, 178796, 99, 4, 0.03, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Wellington"));
            ord.Add(new OrderInfo(10067, 195468, 80, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Manchester"));
            ord.Add(new OrderInfo(10067, 207657, 111, 1, 0.07, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Durban"));
        }

        #endregion

        #region Properties 

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

        private ObservableCollection<OrderInfo> _ordersDetails = new ObservableCollection<OrderInfo>();

        /// <summary>
        /// Gets or sets the orders details.
        /// </summary>
        /// <value>The orders details.</value>
        public ObservableCollection<OrderInfo> OrdersDetails
        {
            get { return _ordersDetails; }
        }
       
        private ObservableCollection<string> productCollection;
        /// <summary>
        /// Get or set the ProductName
        /// </summary>
        public ObservableCollection<string> ProductCollection
        {
            get
            {
                return productCollection;
            }

        }
        #endregion

       

        #region Method

        /// <summary>
        /// Populates the data.
        /// </summary>
        private void PopulateData()
        {
            for (int i = 0; i < 100; i++)
            {
                var shipcountry = ShipCountry[randomValue.Next(0, 5)];
                var shipcitycoll = shipCities[shipcountry];

                OrderInfo orderInfo = new OrderInfo();
                orderInfo.OrderID = 10000 + i;
                orderInfo.ProductID = 1000 + i;
                orderInfo.CustomerID = CustomerID[randomValue.Next(0, 14)];
                orderInfo.ProductName = ProductName[randomValue.Next(0, 47)];
                orderInfo.UnitPrice = randomValue.Next(10, 500);
                orderInfo.Quantity = randomValue.Next(10, 50);
                orderInfo.Discount = (double)randomValue.NextDouble();
                orderInfo.Freight = Math.Round(Freight[randomValue.Next(0, 11)], 2);
                orderInfo.OrderDate = new DateTimeOffset(new DateTime(randomValue.Next(2004, 2005), randomValue.Next(1, 06), randomValue.Next(1, 15)));
                orderInfo.ShippedDate = new DateTimeOffset(new DateTime(randomValue.Next(2004, 2005), randomValue.Next(06, 12), randomValue.Next(16, 28)));
                orderInfo.ShipPostalCode = PostalCode[randomValue.Next(0, 9)];
                orderInfo.ShipAddress = shipcountry;
                orderInfo.Expense = randomValue.Next(2000, 4000);
                orderInfo.ShipName = ShipName[randomValue.Next(0, 97)];
                orderInfo.CompanyName = CompanyName[randomValue.Next(0, 2)];
                orderInfo.UnitsInStock = (double)randomValue.Next(1, 40);
                orderInfo.ShipCity = shipcitycoll[randomValue.Next(shipcitycoll.Length - 1)];
                orderInfo.DeliveryDelay = orderInfo.ShippedDate - orderInfo.OrderDate;
                orderInfo.ShipCityID = randomValue.Next(100, 200);
                orderInfo.ContactNumber = 9991121234 + i;
                orderInfo.OrderDetails = getorder(orderInfo.OrderID);
                orderInfo.NoOfOrders = discountcount + 6 / 100;
                if (discountcount > 16)
                    discountcount = 7;
                orderInfo.SupplierID = countrycount % 3 == 0 ? 1 : countrycount % 3;
                if (countrycount % 3 == 0 || countrycount % 9 == 0)
                    orderInfo.ImageLink = "US.jpg";
                else if (countrycount % 5 == 0 || countrycount % 17 == 0)
                    orderInfo.ImageLink = "Japan.jpg";
                else
                    orderInfo.ImageLink = "UK.jpg";

                countrycount++;
                discountcount += 3;
                orderInfo.IsShipped = randomValue.Next() % 2 == 0 ? true : false;
                _ordersDetails.Add(orderInfo);
            }
        }

        private List<DateTime> OrderedDates;
        Random r = new Random();
        List<OrderInfo> ord = new List<OrderInfo>();

        private static ObservableCollection<string> GetProducts()
        {
            ObservableCollection<string> products = new ObservableCollection<string>();
            products.Add("Alice Mutton");
            products.Add("Boston Crab Meat");
            products.Add("Raclette Courdavault");
            products.Add("Vegie-spread");
            products.Add("Tarte au sucre");
            products.Add("Valkoinen suklaa");
            products.Add("Perth Pasties");
            products.Add("Tofu");
            products.Add("Manjimup Dried Apples");
            products.Add("Ipoh Coffee");
            products.Add("Carnarvon Tigers");
            products.Add("Inlagd Sill");
            products.Add("Steeleye Stout");
            products.Add("Carnarvon Tigers");
            products.Add("Queso Cabrales");
            products.Add("Longlife Tofu");
            products.Add("Konbu");
            return products;
        }

        /// <summary>
        /// Gets the date between.
        /// </summary>
        /// <param name="startYear">The start year.</param>
        /// <param name="EndYear">The end year.</param>
        /// <param name="Count">The count.</param>
        /// <returns></returns>
        private List<DateTime> GetDateBetween(int startYear, int EndYear, int Count)
        {
            List<DateTime> date = new List<DateTime>();
            Random d = new Random(1);
            Random m = new Random(2);
            Random y = new Random(startYear);
            for (int i = 0; i < Count; i++)
            {
                int year = y.Next(startYear, EndYear);
                int month = m.Next(3, 13);
                int day = d.Next(1, 31);

                date.Add(new DateTime(year, month, day));
            }
            return date;
        }

        public ObservableCollection<OrderInfo> getorder(double i)
        {
            ObservableCollection<OrderInfo> order = new ObservableCollection<OrderInfo>();
            foreach (var or in ord)
                if (or.OrderID == i)
                    order.Add(or);
            return order;
        }

        #endregion

        #region Collections

        /// <summary>
        /// Sets the ship city.
        /// </summary>
        private void SetShipCity()
        {
            string[] argentina = new string[] { "Buenos Aires" };

            string[] austria = new string[] { "Graz", "Salzburg" };

            string[] belgium = new string[] { "Bruxelles", "Charleroi" };

            string[] brazil = new string[] { "Campinas", "Resende", "Palmas", "São Paulo" };

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

            shipCities.Add("Argentina", argentina);
            shipCities.Add("Austria", austria);
            shipCities.Add("Belgium", belgium);
            shipCities.Add("Brazil", brazil);
            shipCities.Add("Canada", canada);
            shipCities.Add("Denmark", denmark);
            shipCities.Add("Finland", finland);
            shipCities.Add("France", france);
            shipCities.Add("Germany", germany);
            shipCities.Add("Ireland", ireland);
            shipCities.Add("Italy", italy);
            shipCities.Add("Mexico", mexico);
            shipCities.Add("Norway", norway);
            shipCities.Add("Poland", poland);
            shipCities.Add("Portugal", portugal);
            shipCities.Add("Spain", spain);
            shipCities.Add("Sweden", sweden);
            shipCities.Add("Switzerland", switzerland);
            shipCities.Add("UK", uk);
            shipCities.Add("USA", usa);
            shipCities.Add("Venezuela", venezuela);

        }

        string[] CustomerID = new string[]
      {
            "FRANS",
            "MEREP",
            "FOLKO",
            "SIMOB",
            "WARTH",
            "VAFFE",
             "BLONP",
            "FURIB",
            "SEVES",
            "LINOD",
            "RISCU",
            "PICCO",
            "FOLIG",
            "WELLI",
            "ALFKI",

      };

        double[] Freight = new double[]
        {
            4.45, 10.98, 17.67, 50.87, 20.12, 36.19, 49.21, 79.45, 18.59, 3.01, 4.13, 74,22
        };


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

        string[] ShipName = new string[]
        {
            "Franchi S.p.A.",
            "Mère Paillarde",
            "Folk och fä HB",
            "Simons bistro",
            "Vaffeljernet",
            "Wartian Herkku",
            "Franchi S.p.A",
            "Morgenstern Gesundkost",
            "Furia Bacalhau e Frutos do Mar",
            "Seven Seas Imports",
            "Simons bistro",
            "Wellington Importadora",
            "LINO-Delicateses",
            "Richter Supermarkt",
            "GROSELLA-Restaurante",
            "Piccolo und mehr",
            "Folies gourmandes",
            "Blondel père et fils",
            "Rattlesnake Canyon Grocery",
            "Magazzini Alimentari Riuniti",
            "Vins et alcools Chevalier",
            "Ernst Handel",
            "La maison d'Asie",
            "Toms Spezialitäten",
            "Rattlesnake Canyon Grocery",
            "Morgenstern Gesundkost",
            "Ernst Handel",
            "Antonio Moreno Taquería ",
            "Santé Gourmet",
            "LILA-Supermercado",
            "Suprêmes délices",
            "Bólido Comidas preparadas",
            "Ottilies Käseladen	",
            "Eastern Connection",
            "HILARIÓN-Abastos",
            "Centro comercial Moctezuma ",
            "Vaffeljernet",
            "Old World Delicatessen",
            "Mère Paillarde",
            "White Clover Markets",
            "HILARIÓN-Abastos",
            "Folk och fä HB",
            "LINO-Delicateses",
            "Antonio Moreno Taquería",
            "Berglunds snabbköp",
            "Santé Gourmet",
            "Morgenstern Gesundkost",
            "HILARIÓN-Abastos",
            "Toms Spezialitäten",
            "Bólido Comidas preparadas",
            "Folk och fä HB",
            "Save-a-lot Markets",
            "Wartian Herkku",
            "Ricardo Adocicados",
            "Blondel père et fils",
            "LILA-Supermercado",
            "The Cracker Box",
            "Hungry Owl All-Night Grocers",
            "LILA-Supermercado ",
            "Seven Seas Imports",
            "Eastern Connection",
            "Alfred's Futterkiste",
            "Hungry Owl All-Night Grocers",
            "Vaffeljernet",
            "Save-a-lot Markets",
            "Wartian Herkku",
            "France restauration",
            "Piccolo und mehr",
            "La maison d'Asie",
            "Hungry Owl All-Night Grocers",
            "Folk och fä HB",
            "Hungry Owl All-Night Grocers",
            "Chop-suey Chinese",
            "Spécialités du monde",
            "La maison d'Asie",
            "Richter Supermarkt	",
            "Suprêmes délices",
            "Bottom-Dollar Markets	",
            "Chop-suey Chinese",
            "Godos Cocina Típica ",
            "Suprêmes délices",
            "La maison d'Asie",
            "Santé Gourmet",
            "Franchi S.p.A",
            "Mère Paillarde",
            "LINO-Delicateses",
            "Galería del gastronómo",
            "B's Beverages ",
            "Ricardo Adocicados ",
            "Ernst Handel	",
            "QUICK-Stop ",
            "Rattlesnake Canyon Grocery",
            "Lazy K Kountry Store",
            "Richter Supermarkt",
            "Eastern Connection",
            "Save-a-lot Markets ",
            "Magazzini Alimentari Riuniti"
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

        string[] CompanyName = new string[]
        {
            "Federal Shipping",
            "Speedy Express",
            "United Package"
        };

        internal string[] EmployeeName = new string[]
            {
                "Sean Jacobson",
                "Phyllis Allen",
                "Marvin Allen",
                "Michael Allen",
                "Cecil Allison",
                "Oscar Alpuerto",
                "Sandra Altamirano",
                "Selena Alvarad",
                "Emilio Alvaro",
                "Maxwell Amland",
                "Mae Anderson",
                "Ramona Antrim",
                "Sabria Appelbaum",
                "Hannah Arakawa",
                "Kyley Arbelaez",
                "Tom Johnston",
                "Thomas Armstrong",
                "John Arthur",
                "Chris Ashton",
                "Teresa Atkinson",
                "John Ault",
                "Robert Avalos",
                "Stephen Ayers",
                "Phillip Bacalzo",
                "Gustavo Achong",
                "Catherine Abel",
                "Kim Abercrombie",
                "Humberto Acevedo",
                "Pilar Ackerman",
                "Frances Adams",
                "Margar Smith",
                "Carla Adams",
                "Jay Adams",
                "Ronald Adina",
                "Samuel Agcaoili",
                "James Aguilar",
                "Robert Ahlering",
                "Francois Ferrier",
                "Kim Akers",
                "Lili Alameda",
                "Amy Alberts",
                "Anna Albright",
                "Milton Albury",
                "Paul Alcorn",
                "Gregory Alderson",
                "J. Phillip Alexander",
                "Michelle Alexander",
                "Daniel Blanco",
                "Cory Booth",
                "James Bailey"
            };

        string[] PostalCode = new string[]
        {
            "10100",
            "H1J 1c3",
            "S-844 67",
            "1734",
            "8200",
            "90110",
            "04179",
            "1675",
            "OX15 4NB",
            "08737-363",
            "4980",
            "1204",
            "1081",
            "5020"
        };
        #endregion

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isdisposable)
        { 
            if (OrdersDetails != null)
            {
                foreach (var ordersDetail in OrdersDetails)
                    (ordersDetail as OrderInfo).Dispose();
                OrdersDetails.Clear();
            }

            if (ProductCollection != null)
                ProductCollection.Clear();
        }
    }

}
