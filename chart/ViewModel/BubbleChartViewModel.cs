#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
    public class BubbleChartViewModel
    {
        public BubbleChartViewModel()
        {
            BubbleData = new ObservableCollection<BubbleChartModel>
            {
                new BubbleChartModel(92.2, 7.8, 1.847, "China"),
                new BubbleChartModel(74, 6.5, 1.741, "India"),
                new BubbleChartModel(90.4, 6.0, 0.738, "Indonesia"),
                new BubbleChartModel(99.4, 2.2, 0.812, "US"),
                new BubbleChartModel(88.6, 1.3, 0.697, "Brazil"),
                new BubbleChartModel(99, 4.7, 0.1318, "Germany"),
                new BubbleChartModel(72, 2.0, 0.1355, "Egypt"),
                new BubbleChartModel(99.6, 3.4, 0.79, "Russia"),
                new BubbleChartModel(99, 0.6, 0.628, "Japan"),
                new BubbleChartModel(86.1, 4.0, 0.615, "Mexico"),
                new BubbleChartModel(92.6, 4.6, 0.149, "Philippines"),
                new BubbleChartModel(61.3, 1.45, 0.799, "Nigeria"),
                new BubbleChartModel(82.2, 4.97, 1.5, "Hong Kong"),
                new BubbleChartModel(79.2, 3.9,0.662, "Netherland"),
                new BubbleChartModel(72.5, 4.5,1.7, "Jordan"),
                new BubbleChartModel(81, 3.5, 0.75, "Australia"),
                new BubbleChartModel(66.8, 3.9, 0.78, "Mongolia"),
                new BubbleChartModel(79.2, 2.9, 0.731, "Taiwan"),
            };
        }
        public ObservableCollection<BubbleChartModel> BubbleData { get; }

    }
}
