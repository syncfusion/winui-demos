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

namespace Syncfusion.ChartDemos.WinUI
{
   public class DateTimeAxisViewModel
    {
        public ObservableCollection<ChartAxisModel> DateTimeData { get; set; }
        public DateTimeAxisViewModel()
        {
            DateTimeData = new ObservableCollection<ChartAxisModel>();

            Random rand = new();
            double value = 100;
            DateTime date = new(2017, 1, 1);

            for (int i = 0; i < 100; i++)
            {
                if (rand.NextDouble() > 0.5)
                    value += rand.NextDouble();
                else
                    value -= rand.NextDouble();

                DateTimeData.Add(new ChartAxisModel { Growth = value, Date = date });
                date = date.AddDays(1);

            }
        }
    }
}
