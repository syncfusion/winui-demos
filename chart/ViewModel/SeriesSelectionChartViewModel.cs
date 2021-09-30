#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
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

namespace syncfusion.chartdemos.winui
{
    public class SeriesSelectionChartViewModel : NotificationObject
    {

        public ObservableCollection<Sales> SalesCollection
        {
            get;
        }

        public SeriesSelectionChartViewModel()
        {
            SalesCollection = new ObservableCollection<Sales>();
            SalesCollection.Add(new Sales() { Category = "Samsung", Year2013 = 32.5, Year2014 = 28.0 });
            SalesCollection.Add(new Sales() { Category = "Apple", Year2013 = 16.6, Year2014 = 16.4 });
            SalesCollection.Add(new Sales() { Category = "Sony", Year2013 = 4.1, Year2014 = 3.9 });
            SalesCollection.Add(new Sales() { Category = "LG", Year2013 = 4.3, Year2014 = 6.0 });
            SalesCollection.Add(new Sales() { Category = "ZTE", Year2013 = 3.2, Year2014 = 3.1 });

        }
    }
}
