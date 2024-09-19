#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace Syncfusion.ChartDemos.WinUI
{
    public class SelectionChartViewModel
    {
        public ObservableCollection<SelectionChartModel> SeriesSelectionData { get; set; }

        public ObservableCollection<PerformanceData> SelectionData { get; set; }

        public SelectionChartViewModel()
        {
            SeriesSelectionData = new ObservableCollection<SelectionChartModel>()
            {
                new SelectionChartModel() {Country="CHN",Children=17.5,Adults=68.3,Elders=14.2},
                new SelectionChartModel() {Country="IND",Children=25.8,Adults=67.4,Elders=6.8},
                new SelectionChartModel() {Country="PAK",Children=34.6,Adults=61,Elders=4.4},
                new SelectionChartModel() {Country="IDN",Children=25.6,Adults=67.9,Elders=6.5},
                new SelectionChartModel() {Country="BGD",Children=26.3,Adults=68.4,Elders=5.3},
            };

            DateTime date = new(2017, 3, 01);
            Random r = new();
            SelectionData = new ObservableCollection<PerformanceData>();
            for (int i = 0; i < 10; i++)
            {
                SelectionData.Add(new PerformanceData(date, r.Next(10, 65)));
                date = date.AddHours(1);
            }
        }
    }

    public class PerformanceData
    {
        public DateTime Date { get; set; }
        public double Value { get; set; }

        public PerformanceData(DateTime date, double value)
        {
            Date = date;
            Value = value;
        }
    }
}
