#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Core;
using System;
using System.Collections.Generic;

namespace Syncfusion.ChartDemos.WinUI
{
    public class DoughnutChartViewModel : NotificationObject , IDisposable
    {
        private double startAngle;
        private double endAngle;

        public IList<DoughnutChartModel> DoughnutSeriesData
        {
            get;
            set;
        }

        public IList<DoughnutChartModel> SemiCircularData
        {
            get;
            set;
        }
       
        public double StartAngle
        {
            get
            {
                return startAngle;
            }

            set
            {
                startAngle = value;
                RaisePropertyChanged(nameof(StartAngle));
            }
        }

        public double EndAngle
        {
            get
            {
                return endAngle;
            }

            set
            {
                endAngle = value;
                RaisePropertyChanged(nameof(EndAngle));
            }
        }
       
        public DoughnutChartViewModel()
        {
            StartAngle = 180;
            EndAngle = 360;

            //Default Doughnut
            this.DoughnutSeriesData = new List<DoughnutChartModel>();

            DoughnutSeriesData.Add(new DoughnutChartModel() { Name = "Labor", Value = 10 });
            DoughnutSeriesData.Add(new DoughnutChartModel() { Name = "Legal", Value = 8 });
            DoughnutSeriesData.Add(new DoughnutChartModel() { Name = "Production", Value = 7 });
            DoughnutSeriesData.Add(new DoughnutChartModel() { Name = "License", Value = 5 });
            DoughnutSeriesData.Add(new DoughnutChartModel() { Name = "Facilities", Value = 10 });
            DoughnutSeriesData.Add(new DoughnutChartModel() { Name = "Taxes", Value = 6 });
            DoughnutSeriesData.Add(new DoughnutChartModel() { Name = "Insurance", Value = 18 });

            //Semi Doughnut

            this.SemiCircularData = new List<DoughnutChartModel>();

            SemiCircularData.Add(new DoughnutChartModel() { Name = "Product A", Value = 750 });
            SemiCircularData.Add(new DoughnutChartModel() { Name = "Product B", Value = 463 });
            SemiCircularData.Add(new DoughnutChartModel() { Name = "Product C", Value = 389 });
            SemiCircularData.Add(new DoughnutChartModel() { Name = "Product D", Value = 697 });
            SemiCircularData.Add(new DoughnutChartModel() { Name = "Product E", Value = 251 });
        }

        public void Dispose()
        {
            if (DoughnutSeriesData != null)
                DoughnutSeriesData.Clear();

            if (SemiCircularData != null)
                SemiCircularData.Clear();
        }
    }
}
