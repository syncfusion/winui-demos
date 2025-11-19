#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Media;
using System.Collections.ObjectModel;

namespace Syncfusion.ChartDemos.WinUI
{
    public class LogarithmicAxisViewModel
    {
        public ObservableCollection<ChartAxisModel> LogarithmicData { get; set; }
        public ObservableCollection<Brush> CustomBrushes { get; set; }

        public LogarithmicAxisViewModel()
        {
            LogarithmicData = new ObservableCollection<ChartAxisModel>()
            {
                new ChartAxisModel { Year = 2012, Users = 60 },
                new ChartAxisModel { Year = 2013, Users = 200 },
                new ChartAxisModel { Year = 2014, Users = 500 },
                new ChartAxisModel { Year = 2015, Users = 800 },
                new ChartAxisModel { Year = 2016, Users = 1600 },
                new ChartAxisModel { Year = 2017, Users = 2800 },
                new ChartAxisModel { Year = 2018, Users = 4000 },
                new ChartAxisModel { Year = 2019, Users = 4600 },
                new ChartAxisModel { Year = 2020, Users = 5000 },
                new ChartAxisModel { Year = 2021, Users = 5200 },
            };

            CustomBrushes = new ObservableCollection<Brush>();
            foreach (var item in LogarithmicData)
            {
                if (item.Users <= 500)
                {
                    CustomBrushes.Add(new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 66, 181))); // #0042B5
                }
                else if (item.Users > 500 && item.Users <= 2000)
                {
                    CustomBrushes.Add(new SolidColorBrush(Windows.UI.Color.FromArgb(255, 42, 114, 220))); // #2A72DC
                }
                else if (item.Users > 2000 && item.Users <= 4000)
                {
                    CustomBrushes.Add(new SolidColorBrush(Windows.UI.Color.FromArgb(255, 24, 123, 248))); // #187BF8
                }
                else
                {
                    CustomBrushes.Add(new SolidColorBrush(Windows.UI.Color.FromArgb(255, 79, 157, 255))); // #4F9DFF
                }
            }
        }
    };
}
