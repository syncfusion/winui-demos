#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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

namespace Syncfusion.ChartDemos.WinUI
{
    public class FastColumnChartViewModel
    {
        DateTime date = new DateTime(1999, 1, 1);
        public ObservableCollection<FastColumnChartModel> Data { get; set; }
        public ObservableCollection<FastColumnChartModel> WeatherData { get; set; }

        public FastColumnChartViewModel()
        {
            //Fast Column Series
            Data = new ObservableCollection<FastColumnChartModel>();
            Random random = new Random();
            for (int i = 0; i < 60; i++)
            {
                Data.Add(new FastColumnChartModel() { Date = date.AddDays(i), Price = random.Next(1, 100) });
            }

            //Fast Step Line Series
            WeatherData = new ObservableCollection<FastColumnChartModel>();
            Random random1 = new Random();
            for (int i = 0; i < 60; i++)
            {
                WeatherData.Add(new FastColumnChartModel() { Date = date.AddDays(i), Value = random1.Next(1, 134) });
            }
        }
    }
}
