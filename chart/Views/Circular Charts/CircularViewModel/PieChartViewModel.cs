#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Media;
using Syncfusion.UI.Xaml.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syncfusion.ChartDemos.WinUI
{
    public class PieChartViewModel : NotificationObject
    {
        private double startAngle;
        private double endAngle;

        public IList<PieChartModel> PieSeriesData
        {
            get;
            set;
        }

        public IList<PieChartModel> SemiCircularData
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
                RaisePropertyChanged(nameof(this.StartAngle));                
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
                RaisePropertyChanged(nameof(this.EndAngle));
            }
        }

        public PieChartViewModel()
        {
            //Default Pie
            this.PieSeriesData = new List<PieChartModel>();

            PieSeriesData.Add(new PieChartModel() { Name = "David", Value = 16.6 });
            PieSeriesData.Add(new PieChartModel() { Name = "Steve", Value = 14.6 });
            PieSeriesData.Add(new PieChartModel() { Name = "Jack", Value = 18.6 });
            PieSeriesData.Add(new PieChartModel() { Name = "John", Value = 20.5 });
            PieSeriesData.Add(new PieChartModel() { Name = "Regev", Value = 39.5 });

            //Semi Pie

            this.SemiCircularData = new List<PieChartModel>();

            SemiCircularData.Add(new PieChartModel() { Name = "Mystery", Value = 30 });
            SemiCircularData.Add(new PieChartModel() { Name = "Horror", Value = 7 });
            SemiCircularData.Add(new PieChartModel() { Name = "Romance", Value = 30 });
            SemiCircularData.Add(new PieChartModel() { Name = "Biographies", Value = 15 });
            SemiCircularData.Add(new PieChartModel() { Name = "Science Fiction", Value = 10 });
            SemiCircularData.Add(new PieChartModel() { Name = "Self-help", Value = 8 });

            StartAngle = 180;
            EndAngle = 360;
        }
    }
}
