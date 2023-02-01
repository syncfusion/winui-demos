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

namespace Syncfusion.ChartDemos.WinUI
{
    public class StepLineChartViewModel
    {
        public StepLineChartViewModel()
        {
            this.Intensity = new ObservableCollection<StepLineChartModel>();
            DateTime yr = new DateTime(2000, 5, 1);
            Intensity.Add(new StepLineChartModel() { Year = yr.AddYears(0), UK = 416, JP = 180 });
            Intensity.Add(new StepLineChartModel() { Year = yr.AddYears(1), UK = 490, JP = 240 });
            Intensity.Add(new StepLineChartModel() { Year = yr.AddYears(2), UK = 470, JP = 370 });
            Intensity.Add(new StepLineChartModel() { Year = yr.AddYears(3), UK = 500, JP = 200 });
            Intensity.Add(new StepLineChartModel() { Year = yr.AddYears(4), UK = 449, JP = 229 });
            Intensity.Add(new StepLineChartModel() { Year = yr.AddYears(5), UK = 470, JP = 210 });
            Intensity.Add(new StepLineChartModel() { Year = yr.AddYears(6), UK = 437, JP = 337 });
            Intensity.Add(new StepLineChartModel() { Year = yr.AddYears(7), UK = 458, JP = 258 });
            Intensity.Add(new StepLineChartModel() { Year = yr.AddYears(8), UK = 500, JP = 300 });
            Intensity.Add(new StepLineChartModel() { Year = yr.AddYears(9), UK = 473, JP = 173 });
            Intensity.Add(new StepLineChartModel() { Year = yr.AddYears(10), UK = 520, JP = 220 });
            Intensity.Add(new StepLineChartModel() { Year = yr.AddYears(11), UK = 480, JP = 309 });

        }

        public ObservableCollection<StepLineChartModel> Intensity
        {
            get;
        }
    }
}
