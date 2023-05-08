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
    public class FunnelChartViewModel
    {
        public FunnelChartViewModel()
        {
            this.List = new ObservableCollection<FunnelChartModel>();
            DateTime yr = new DateTime(2010, 5, 1);

            List.Add(new FunnelChartModel() { Category = "Iron", Percentage = 36 });
            List.Add(new FunnelChartModel() { Category = "Zinc", Percentage = 32 });
            List.Add(new FunnelChartModel() { Category = "Copper", Percentage = 34 });
            List.Add(new FunnelChartModel() { Category = "Aluminium", Percentage = 41 });
            List.Add(new FunnelChartModel() { Category = "Gold", Percentage = 42 });
            List.Add(new FunnelChartModel() { Category = "Silver", Percentage = 42 });
            List.Add(new FunnelChartModel() { Category = "Diamond", Percentage = 43 });
        }

        public ObservableCollection<FunnelChartModel> List
        {
            get;
            set;
        }
    }
}
