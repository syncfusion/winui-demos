#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
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
    public class AreaChartViewModel
    {
        public AreaChartViewModel()
        {
            this.Performance = new ObservableCollection<AreaChartModel>();

            Performance.Add(new AreaChartModel() { Date = 2005, Automation = 23, Application = 16, Web = 5 });
            Performance.Add(new AreaChartModel() { Date = 2006, Automation = 40, Application = 25, Web = 13 });
            Performance.Add(new AreaChartModel() { Date = 2007, Automation = 15, Application = 22, Web = 43 });
            Performance.Add(new AreaChartModel() { Date = 2008, Automation = 10, Application = 55, Web = 25 });
            Performance.Add(new AreaChartModel() { Date = 2009, Automation = 62, Application = 6,  Web = 39 });
            Performance.Add(new AreaChartModel() { Date = 2010, Automation = 10, Application = 40, Web = 19 });
            Performance.Add(new AreaChartModel() { Date = 2011, Automation = 29, Application = 22, Web = 59 });
            Performance.Add(new AreaChartModel() { Date = 2012, Automation = 74, Application = 54, Web = 40 });
            Performance.Add(new AreaChartModel() { Date = 2013, Automation = 20, Application = 62, Web = 45 });
        }

        public ObservableCollection<AreaChartModel> Performance
        {
            get;
        }
    }
}
