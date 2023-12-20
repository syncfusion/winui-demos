#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
    public class ColumnChartViewModel
    {
        public ObservableCollection<ColumnChartModel> DefaultColumnData { get; }
        public ObservableCollection<Brush> OlympicColorModel { get; set; }
        public ObservableCollection<ColumnChartModel> OlympicMedals { get; set; }
        public ObservableCollection<Brush> AlterColor { get; set; }
        public ObservableCollection<ColumnChartModel> RoundedColumnData { get; set; }
        public ColumnChartViewModel()
        {
            //Default column
            this.DefaultColumnData = new ObservableCollection<ColumnChartModel>();
            DefaultColumnData.Add(new ColumnChartModel() { Name = "China", Value = 0.541 });
            DefaultColumnData.Add(new ColumnChartModel() { Name = "Egypt", Value = 0.818 });
            DefaultColumnData.Add(new ColumnChartModel() { Name = "Bolivia", Value = 1.51 });
            DefaultColumnData.Add(new ColumnChartModel() { Name = "Mexico", Value = 1.302 });
            DefaultColumnData.Add(new ColumnChartModel() { Name = "Brazil", Value = 2.017 });

            //Column Width Color
            OlympicColorModel = new ObservableCollection<Brush>()
            {
                new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xD7, 0x00)),
                new SolidColorBrush(Color.FromArgb(0xFF, 0xC0, 0xC0, 0xC0)),
                new SolidColorBrush(Color.FromArgb(0xFF, 0xCD, 0x7F, 0x32)),
            };

            //Column Widht and Spacing

            this.OlympicMedals = new ObservableCollection<ColumnChartModel>();
            OlympicMedals.Add(new ColumnChartModel() { Name = "Norway", Gold = 16,Silver=8,Bronze=13 });
            OlympicMedals.Add(new ColumnChartModel() { Name = "Russia", Gold = 6,Silver=12,Bronze=14 });
            OlympicMedals.Add(new ColumnChartModel() { Name = "Germany", Gold = 12,Silver=10,Bronze=5 });
            OlympicMedals.Add(new ColumnChartModel() { Name = "Canada", Gold = 4,Silver=8,Bronze=14 });

            // Rounded Column Color
            AlterColor = new ObservableCollection<Brush>()
            {
                new SolidColorBrush(Color.FromArgb(0xFF, 0x10, 0x60, 0xDC)),
                new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0xB5, 0x53)),
            };

            //Rounded Column Data
            this.RoundedColumnData = new ObservableCollection<ColumnChartModel>();
            RoundedColumnData.Add(new ColumnChartModel() { Name = "New York", Value = 8683 });
            RoundedColumnData.Add(new ColumnChartModel() { Name = "Tokyo", Value = 6993 });
            RoundedColumnData.Add(new ColumnChartModel() { Name = "Chicago", Value = 5498 });
            RoundedColumnData.Add(new ColumnChartModel() { Name = "Atlanta", Value = 5083 });
            RoundedColumnData.Add(new ColumnChartModel() { Name = "Boston", Value = 4497 });
        }
    }
}
