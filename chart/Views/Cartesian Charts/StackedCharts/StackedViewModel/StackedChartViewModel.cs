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
    public class StackedChartViewModel
    {
        public ObservableCollection<StackedChartModel> StackedColumndData { get; set; }
        public ObservableCollection<StackedChartModel> StackedLinedData { get; set; }
        public ObservableCollection<StackedChartModel> StackedAreaData{ get; set; }
        public ObservableCollection<StackedChartModel> CostData { get; set; }
        public ObservableCollection<StackedChartModel> CostData1 { get; set; }
        public ObservableCollection<StackedChartModel> CostData2 { get; set; }


        public StackedChartViewModel()
        {
            //Stacked Column
            this.StackedColumndData = new ObservableCollection<StackedChartModel>()
            {
                new StackedChartModel() { Year = "2014", UK = 111.1, Germany = 76.9, France = 66.1, Italy = 34.1 },
                new StackedChartModel() { Year = "2015", UK = 127.3, Germany = 99.5, France = 79.3, Italy = 38.2 },
                new StackedChartModel() { Year = "2016", UK = 143.4, Germany = 121.7, France = 91.3, Italy = 44.0 },
                new StackedChartModel() { Year = "2017", UK = 159.9, Germany = 142.5, France = 102.4, Italy = 51.6 },
            };

            //Stacked Line
            this.StackedLinedData = new ObservableCollection<StackedChartModel>()
            {
                new StackedChartModel() { Year = "2010", UnitedKingdom = 2.4, US = 2.7, Cameroon = 2.9, China = 10.6 },
                new StackedChartModel() { Year = "2011", UnitedKingdom = 1.1, US = 1.5, Cameroon = 3.4, China = 9.6 },
                new StackedChartModel() { Year = "2012", UnitedKingdom = 1.4, US = 2.3, Cameroon = 4.6, China = 7.9 },
                new StackedChartModel() { Year = "2013", UnitedKingdom = 1.8, US = 1.8, Cameroon = 5, China = 7.8 },
                new StackedChartModel() { Year = "2014", UnitedKingdom = 3.2, US = 2.3, Cameroon = 5.7, China = 7.4 },
                new StackedChartModel() { Year = "2015", UnitedKingdom = 2.4, US = 2.7, Cameroon = 5.7, China = 7 },
               
            };

            //Stacked Area
            this.StackedAreaData = new ObservableCollection<StackedChartModel>()
            {
                new StackedChartModel() { Year = "2000", Organic = 0.61, FairTrade = 0.03, VegAlternatives = 0.48, Others = 0.23 },
                new StackedChartModel() { Year = "2001", Organic = 0.81, FairTrade = 0.05, VegAlternatives = 0.53, Others = 0.17 },
                new StackedChartModel() { Year = "2002", Organic = 0.91, FairTrade = 0.06, VegAlternatives = 0.57, Others = 0.17 },
                new StackedChartModel() { Year = "2003", Organic = 1, FairTrade = 0.09, VegAlternatives = 0.61, Others = 0.20 },
                new StackedChartModel() { Year = "2004", Organic = 1.19, FairTrade = 0.14, VegAlternatives = 0.63, Others = 0.23 },
                new StackedChartModel() { Year = "2005", Organic = 1.47, FairTrade = 0.20, VegAlternatives = 0.64, Others = 0.36 },
                new StackedChartModel() { Year = "2006", Organic = 1.74, FairTrade = 0.29, VegAlternatives = 0.66, Others = 0.43 },
                new StackedChartModel() { Year = "2007", Organic = 1.98, FairTrade = 0.46, VegAlternatives = 0.76, Others = 0.52 },
                new StackedChartModel() { Year = "2008", Organic = 1.99, FairTrade = 0.64, VegAlternatives = 0.77, Others = 0.72 },
                new StackedChartModel() { Year = "2009", Organic = 1.70, FairTrade = 0.75, VegAlternatives = 0.55, Others = 1.29 },
                new StackedChartModel() { Year = "2010", Organic = 1.48, FairTrade = 1.06, VegAlternatives = 0.54, Others = 1.38 },
                new StackedChartModel() { Year = "2011", Organic = 1.38, FairTrade = 1.25, VegAlternatives = 0.57, Others = 1.82 },
                new StackedChartModel() { Year = "2012", Organic = 1.66, FairTrade = 1.55, VegAlternatives = 0.61, Others = 2.16 },
                new StackedChartModel() { Year = "2013", Organic = 1.66, FairTrade = 1.55, VegAlternatives = 0.67, Others = 2.51 },
                new StackedChartModel() { Year = "2014", Organic = 1.67, FairTrade = 1.65, VegAlternatives = 0.67, Others = 2.61 },
            };

            //Grouping
          
            this.CostData = new ObservableCollection<StackedChartModel>()
            {
                new StackedChartModel() { Name = "Q1", Value = 75, Size = 50.76 },
                new StackedChartModel() { Name = "Q2", Value = 55, Size = 58.14  },
                new StackedChartModel() { Name = "Q3", Value = 65, Size = 61.89  },
                new StackedChartModel() { Name = "Q4", Value = 70, Size = 64.578 },
            };
          
            this.CostData1 = new ObservableCollection<StackedChartModel>()
            {
                new StackedChartModel() { Name = "Q1", Value = 55, Size = 35.9},
                new StackedChartModel() { Name = "Q2", Value = 40, Size = 45.2},
                new StackedChartModel() { Name = "Q3", Value = 55, Size = 52.34 },
                new StackedChartModel() { Name = "Q4", Value = 55, Size = 48.765},
            };

            this.CostData2 = new ObservableCollection<StackedChartModel>()
            {
                new StackedChartModel() { Name = "Q1", Value = 35, Size = 18.25},
                new StackedChartModel() { Name = "Q2", Value = 20, Size = 18.55},
                new StackedChartModel() { Name = "Q3", Value = 15, Size = 16.24 },
                new StackedChartModel() { Name = "Q4", Value = 20, Size = 18.5 },
            };
        }
    }
}
