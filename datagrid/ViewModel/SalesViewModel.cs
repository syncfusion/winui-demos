#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Globalization.NumberFormatting;

namespace DataGrid
{
    /// <summary>
    /// This class represents the SalesInfoViewModel
    /// </summary>
    public class SalesViewModel : IDisposable
    {
        public SalesViewModel()
        {
            yearlySales = this.GetYearlySalesDetails();
        }

        /// <summary>
        /// Used to set the system default currency to numeric column NumberFormatter.
        /// </summary>
        public CurrencyFormatter SystemCurrency
        {
            get
            {
                IncrementNumberRounder rounder = new Windows.Globalization.NumberFormatting.IncrementNumberRounder();
                rounder.Increment = 0.01;
                return new CurrencyFormatter(Windows.System.UserProfile.GlobalizationPreferences.Currencies[0]) { NumberRounder = rounder};
            }
        }

        private ObservableCollection<Sales> yearlySales;

        /// <summary>
        /// Gets or sets the DailySalesDetails.
        /// </summary>
        /// <value>The DailySalesDetails.</value>
        public ObservableCollection<Sales> YearlySales
        {
            get
            {
                return yearlySales;
            }

        }

        private readonly List<string> _salesParsonNames = new List<string>()
            {
                "Gary Drury",
                "Maciej Dusza",
                "Shelley Dyck",
                "Linda Ecoffey",
                "Carla Eldridge",
                "Carol Elliott",
                "Shannon Elliott",
                "Jauna Elson",
                "Michael Emanuel",
                "Terry Eminhizer",
                "John Emory",
                "Gail Erickson",
                "Mark Erickson",
                "Martha Espinoza",
                "Julie Estes",
                "Janeth Esteves",
                "Twanna Evans"
            };

        public ObservableCollection<Sales> GetYearlySalesDetails()
        {
            var collection = new ObservableCollection<Sales>();
            var dt = DateTime.Now.AddYears(-1);
            var r = new Random();
            for (var i = 0; i < 5; i++)
            {
                foreach (var person in _salesParsonNames)
                {
                    if (r.Next(0, 3) == 0) continue;
                    var s = new Sales
                    {
                        Name = person,
                        QS1 = r.Next(100000, 1000000) * 0.01,
                        QS2 = r.Next(100000, 1000000) * 0.01,
                        QS3 = r.Next(100000, 1000000) * 0.01,
                        QS4 = r.Next(100000, 1000000) * 0.01,
                        QS5 = r.Next(100000, 1000000) * 0.01,
                        QS6 = r.Next(100000, 1000000) * 0.01
                    };
                    s.Total = s.QS1 + s.QS2 + s.QS3 + s.QS4 + s.QS5 + s.QS6;
                    s.Year = dt.Year;
                    collection.Add(s);
                }
                dt = dt.AddYears(-1);
            }
            return collection;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isdisposable)
        {
            if (YearlySales != null)
            {
                foreach (var sale in YearlySales)
                    (sale as Sales).Dispose();
                YearlySales.Clear();
            }
        }
    }
}
