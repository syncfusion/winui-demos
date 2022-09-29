#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using Syncfusion.UI.Xaml.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syncfusion.ChartDemos.WinUI
{
    public class SeriesSelectionChartViewModel : NotificationObject
    {

        public ObservableCollection<Sales> SalesCollection1
        {
            get;
        }

        public ObservableCollection<Sales> SalesCollection2
        {
            get;
        }

        public ObservableCollection<PerformanceData> SelectionData { get; set; }

        public SeriesSelectionChartViewModel()
        {
            SalesCollection1 = new ObservableCollection<Sales>();
            SalesCollection1.Add(new Sales() { Category = "Samsung", Year2013 = 32.5 });
            SalesCollection1.Add(new Sales() { Category = "Apple", Year2013 = 16.6 });
            SalesCollection1.Add(new Sales() { Category = "Sony", Year2013 = 4.1 });
            SalesCollection1.Add(new Sales() { Category = "LG", Year2013 = 4.3 });
            SalesCollection1.Add(new Sales() { Category = "ZTE", Year2013 = 3.2 });

            SalesCollection2 = new ObservableCollection<Sales>();
            SalesCollection2.Add(new Sales() { Category = "Samsung", Year2014 = 28.0 });
            SalesCollection2.Add(new Sales() { Category = "Apple", Year2014 = 16.4 });
            SalesCollection2.Add(new Sales() { Category = "Sony", Year2014 = 3.9 });
            SalesCollection2.Add(new Sales() { Category = "LG", Year2014 = 6.0 });
            SalesCollection2.Add(new Sales() { Category = "ZTE", Year2014 = 3.1 });

            DateTime date = new(2017, 3, 01);
            Random r = new();
            SelectionData = new ObservableCollection<PerformanceData>();
            for (int i = 0; i < 20; i++)
            {
                SelectionData.Add(new PerformanceData(date, r.Next(10, 65)));
                date = date.AddHours(1);
            }

        }
    }
}
