#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syncfusion.ChartDemos.WinUI
{
    public class SystemPower
    {
        public DateTime Year
        {
            get;
            set;
        }

        public double IND
        {
            get;
            set;
        }

        public double GER
        {
            get;
            set;
        }

        public double UK
        {
            get;
            set;
        }

        public double FRA
        {
            get;
            set;
        }

        public double AUS
        {
            get;
            set;
        }

    }

    public class ScatterModel
    {
        public float Eruptions
        {
            get;
            set;
        }
        public int WaitingTime
        {
            get;
            set;
        }
    }

    public class LoadDetail
    {
        public DateTime Date { get; set; }
        public double Load { get; set; }
    }

    public class PerformanceData
    {
        public PerformanceData(DateTime date, double value)
        {
            Date = date;
            Value = value;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public double Value
        {
            get;
            set;
        }
    }

    public class Measurement
    {
        public DateTime Time { get; set; }
        public double Velocity1 { get; set; }
        public double Velocity2 { get; set; }
    }


    public class CompanyDetail
    {
        public string CompanyName
        {
            get;
            set;
        }
        public double CompanyTurnover
        {
            get;
            set;
        }
    }

    public class Metrics
    {
        public double Utilization
        {
            get;
            set;
        }
        public double ResponseTime
        {
            get;
            set;
        }
    }

    public class Populations
    {
        public string Continent { get; set; }

        public string Countries { get; set; }

        public double Count { get; set; }

        public string States { get; set; }

        public double PopulationinStates { get; set; }

        public double PopulationinCountries { get; set; }

        public double PopulationinContinents { get; set; }
    }
      
    public class CompanyDetail1
    {
        public Uri Imagepath
        {
            get;
            set;
        }

        public string CompanyName
        {
            get;
            set;
        }

        public double YTD
        {
            get;
            set;
        }

        public int Rank
        {
            get;
            set;
        }
    }

    public class PaletteModel
    {
        public string SocialSite
        {
            get;
            set;
        }
        public double UsersCount
        {
            get;
            set;
        }
        public double Year2012
        {
            get;
            set;
        }
        public double Year2014
        {
            get;
            set;
        }
        public double Year2015
        {
            get;
            set;
        }
        public string Country
        {
            get;
            set;
        }

    }
}
