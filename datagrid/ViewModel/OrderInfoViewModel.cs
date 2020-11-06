#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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

namespace DataGrid
{
    public class OrderInfoViewModel : NotificationObject
    {
        static int countrycount;
        static int discountcount = 2;
        Random randomValue = new Random();

        Dictionary<string, string[]> shipCities = new Dictionary<string, string[]>();

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderInfoViewModel"/> class.
        /// </summary>
        public OrderInfoViewModel()
        {
            SetShipCity();
            this.PopulateData();
        }

        #endregion

        #region Properties 

        private ObservableCollection<OrderInfo> _ordersDetails = new ObservableCollection<OrderInfo>();

        /// <summary>
        /// Gets or sets the orders details.
        /// </summary>
        /// <value>The orders details.</value>
        public ObservableCollection<OrderInfo> OrdersDetails
        {
            get { return _ordersDetails; }
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
                orderInfo.Discount = (double)randomValue.Next(40);
                orderInfo.Freight = Math.Round(Freight[randomValue.Next(0, 11)], 2);
                orderInfo.OrderDate = new DateTime(randomValue.Next(2004, 2005), randomValue.Next(1, 06), randomValue.Next(1, 15));
                orderInfo.ShippedDate = new DateTime(randomValue.Next(2004, 2005), randomValue.Next(06, 12), randomValue.Next(16, 28));
                orderInfo.ShipPostalCode = PostalCode[randomValue.Next(0, 9)];
                orderInfo.ShipAddress = shipcountry;
                orderInfo.Expense = randomValue.Next(2000, 4000);
                orderInfo.ShipName = ShipName[randomValue.Next(0, 97)];
                orderInfo.CompanyName = CompanyName[randomValue.Next(0, 2)];
                orderInfo.UnitsInStock = (short)randomValue.Next(1, 40);
                orderInfo.ShipCity = shipcitycoll[randomValue.Next(shipcitycoll.Length - 1)];
                orderInfo.DeliveryDelay = orderInfo.ShippedDate - orderInfo.OrderDate;
                orderInfo.ShipCityID = randomValue.Next(100, 200);
                orderInfo.ContactNumber = 9991121234 + i;

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
    }

}
