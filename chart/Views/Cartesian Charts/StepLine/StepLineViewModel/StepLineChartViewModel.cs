#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;

namespace Syncfusion.ChartDemos.WinUI
{
    public class StepLineChartViewModel : IDisposable
    {
        public ObservableCollection<StepLineChartModel> CanadaData { get; set; }
        public ObservableCollection<StepLineChartModel> FranceData { get; set; }
        public ObservableCollection<StepLineChartModel> AustriaUnemploymentData { get; set; }
        public ObservableCollection<StepLineChartModel> CanadaUnemploymentData { get; set; }
        public ObservableCollection<StepLineChartModel> DashedLinetData { get; set; }
        public StepLineChartViewModel()
        {
            //Default Step Line
            this.CanadaData = new ObservableCollection<StepLineChartModel>();
            CanadaData.Add(new StepLineChartModel() { Name = "2000", Value = 26.8});
            CanadaData.Add(new StepLineChartModel() { Name = "2001", Value = 29});
            CanadaData.Add(new StepLineChartModel() { Name = "2002", Value = 27.5});
            CanadaData.Add(new StepLineChartModel() { Name = "2003", Value = 28.4});
            CanadaData.Add(new StepLineChartModel() { Name = "2004", Value = 26.5});
            CanadaData.Add(new StepLineChartModel() { Name = "2005", Value = 25.1});
            CanadaData.Add(new StepLineChartModel() { Name = "2006", Value = 24.4});
            CanadaData.Add(new StepLineChartModel() { Name = "2007", Value = 24.8});
            CanadaData.Add(new StepLineChartModel() { Name = "2008", Value = 23.3});
            CanadaData.Add(new StepLineChartModel() { Name = "2009", Value = 22});
            CanadaData.Add(new StepLineChartModel() { Name = "2010", Value = 23.1});


            this.FranceData = new ObservableCollection<StepLineChartModel>();
            FranceData.Add(new StepLineChartModel() { Name = "2000", Value = 9.3 });
            FranceData.Add(new StepLineChartModel() { Name = "2001", Value = 8.3 });
            FranceData.Add(new StepLineChartModel() { Name = "2002", Value = 9.2 });
            FranceData.Add(new StepLineChartModel() { Name = "2003", Value = 9.9 });
            FranceData.Add(new StepLineChartModel() { Name = "2004", Value = 9.6 });
            FranceData.Add(new StepLineChartModel() { Name = "2005", Value = 10.8 });
            FranceData.Add(new StepLineChartModel() { Name = "2006", Value = 9.7 });
            FranceData.Add(new StepLineChartModel() { Name = "2007", Value = 10 });
            FranceData.Add(new StepLineChartModel() { Name = "2008", Value = 9.4 });
            FranceData.Add(new StepLineChartModel() { Name = "2009", Value = 9.3 });
            FranceData.Add(new StepLineChartModel() { Name = "2010", Value = 9.9 });

            //Vertical Step Line
            this.CanadaUnemploymentData = new ObservableCollection<StepLineChartModel>();
            CanadaUnemploymentData.Add(new StepLineChartModel() { Name = "2000", Value = 6.8 });
            CanadaUnemploymentData.Add(new StepLineChartModel() { Name = "2001", Value = 7.2 });
            CanadaUnemploymentData.Add(new StepLineChartModel() { Name = "2002", Value = 7.7 });
            CanadaUnemploymentData.Add(new StepLineChartModel() { Name = "2003", Value = 7.6 });
            CanadaUnemploymentData.Add(new StepLineChartModel() { Name = "2004", Value = 7.2 });
            CanadaUnemploymentData.Add(new StepLineChartModel() { Name = "2005", Value = 6.8 });
            CanadaUnemploymentData.Add(new StepLineChartModel() { Name = "2006", Value = 6.3 });
            CanadaUnemploymentData.Add(new StepLineChartModel() { Name = "2007", Value = 6 });
            CanadaUnemploymentData.Add(new StepLineChartModel() { Name = "2008", Value = 6.1 });
            CanadaUnemploymentData.Add(new StepLineChartModel() { Name = "2009", Value = 8.3 });
            CanadaUnemploymentData.Add(new StepLineChartModel() { Name = "2010", Value = 8.1 });

            this.AustriaUnemploymentData = new ObservableCollection<StepLineChartModel>();
            AustriaUnemploymentData.Add(new StepLineChartModel() { Name = "2000", Value = 4.7 });
            AustriaUnemploymentData.Add(new StepLineChartModel() { Name = "2001", Value = 4 });
            AustriaUnemploymentData.Add(new StepLineChartModel() { Name = "2002", Value = 4.8 });
            AustriaUnemploymentData.Add(new StepLineChartModel() { Name = "2003", Value = 4.8 });
            AustriaUnemploymentData.Add(new StepLineChartModel() { Name = "2004", Value = 5.8 });
            AustriaUnemploymentData.Add(new StepLineChartModel() { Name = "2005", Value = 5.6 });
            AustriaUnemploymentData.Add(new StepLineChartModel() { Name = "2006", Value = 5.2 });
            AustriaUnemploymentData.Add(new StepLineChartModel() { Name = "2007", Value = 4.9});
            AustriaUnemploymentData.Add(new StepLineChartModel() { Name = "2008", Value = 4.1 });
            AustriaUnemploymentData.Add(new StepLineChartModel() { Name = "2009", Value = 5.3 });
            AustriaUnemploymentData.Add(new StepLineChartModel() { Name = "2010", Value = 4.8 });

            //Dashed Step Line
            this.DashedLinetData = new ObservableCollection<StepLineChartModel>();
            DashedLinetData.Add(new StepLineChartModel() { Name = "2006", India = 1.21521, Germany = 0.81441, Kazakhstan = 0.1853 });
            DashedLinetData.Add(new StepLineChartModel() { Name = "2007", India = 1.33674, Germany = 0.7838, Kazakhstan = 0.19839 });
            DashedLinetData.Add(new StepLineChartModel() { Name = "2008", India = 1.42438, Germany = 0.78969, Kazakhstan = 0.24203 });
            DashedLinetData.Add(new StepLineChartModel() { Name = "2009", India = 1.56488, Germany = 0.73481, Kazakhstan = 0.21361 });
            DashedLinetData.Add(new StepLineChartModel() { Name = "2010", India = 1.65998, Germany = 0.77307, Kazakhstan = 0.2297 });
            DashedLinetData.Add(new StepLineChartModel() { Name = "2011", India = 1.75674, Germany = 0.74648, Kazakhstan = 0.24545 });

        }

        public void Dispose()
        {
            if(CanadaData != null)
                CanadaData.Clear();

            if (FranceData != null)
                FranceData.Clear();

            if (AustriaUnemploymentData != null)
                AustriaUnemploymentData.Clear();

            if (CanadaUnemploymentData != null)
                CanadaUnemploymentData.Clear();

            if (DashedLinetData != null)
                DashedLinetData.Clear();
        }
    }
}
