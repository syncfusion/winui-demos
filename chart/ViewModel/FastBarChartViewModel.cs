#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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

namespace syncfusion.chartdemos.winui
{
    public class FastBarChartViewModel
    {
        DateTime date = new DateTime(1999, 1, 1);

        public FastBarChartViewModel()
        {
            Data = new ObservableCollection<FastBarChartModel>();
            Random random = new Random();

            for (int i = 0; i < 50; i++)
            {
                Data.Add(new FastBarChartModel() { Date = date.AddDays(i), Price = random.Next(1, 20) });
            }
        }

        public ObservableCollection<FastBarChartModel> Data { get; set; }
    }
}