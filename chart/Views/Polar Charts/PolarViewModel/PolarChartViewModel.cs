#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Markup;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syncfusion.ChartDemos.WinUI
{
    public class PolarChartViewModel
    {
        public ObservableCollection<PolarChartModel> PloarAreaData { get; set; }
        public ObservableCollection<PolarChartModel> PloarLineData { get; set; }
        public PolarChartViewModel()
        {
            //Polar Line
            this.PloarLineData = new ObservableCollection<PolarChartModel>();
            this.PloarLineData.Add(new PolarChartModel() { Direction = "North", Weed = 63, Flower = 42, Tree = 80 });
            this.PloarLineData.Add(new PolarChartModel() { Direction = "NorthEast", Weed = 70, Flower = 40, Tree = 85 });
            this.PloarLineData.Add(new PolarChartModel() { Direction = "East", Weed = 45, Flower = 25, Tree = 78 });
            this.PloarLineData.Add(new PolarChartModel() { Direction = "SouthEast", Weed = 70, Flower = 40, Tree = 90 });
            this.PloarLineData.Add(new PolarChartModel() { Direction = "South", Weed = 47, Flower = 20, Tree = 78 });
            this.PloarLineData.Add(new PolarChartModel() { Direction = "SouthWest", Weed = 65, Flower = 45, Tree = 83 });
            this.PloarLineData.Add(new PolarChartModel() { Direction = "West", Weed = 58, Flower = 40, Tree = 79 });
            this.PloarLineData.Add(new PolarChartModel() { Direction = "NorthWest", Weed = 73, Flower = 28, Tree = 88 });

            //Polar Area
            this.PloarAreaData = new ObservableCollection<PolarChartModel>()
            {
                new PolarChartModel() { Year = "2000", ProductA = 4, ProductB = 3.3, ProductC = 2.8 },
                new PolarChartModel() { Year = "2001", ProductA = 3.6, ProductB = 3.1, ProductC = 2.5 },
                new PolarChartModel() { Year = "2002", ProductA = 3.8, ProductB = 3.9, ProductC = 2.1 },
                new PolarChartModel() { Year = "2003", ProductA = 3.4, ProductB = 3.1, ProductC = 3.2 },
                new PolarChartModel() { Year = "2004", ProductA = 3.7, ProductB = 3.6, ProductC = 2.8 },
                new PolarChartModel() { Year = "2005", ProductA = 3.9, ProductB = 3, ProductC = 2.2 },
            };
        }
    }
}
