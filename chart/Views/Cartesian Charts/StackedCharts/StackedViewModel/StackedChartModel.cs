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
    public class StackedChartModel
    {
        public string Year { get; set; }

        //Stacked Column 
        public double UK { get; set; }
        public double Germany { get; set; }
        public double France { get; set; }
        public double Italy { get; set; }

        //Stacked Line
        public double UnitedKingdom { get; set; }
        public double US { get; set; }
        public double Cameroon { get; set; }
        public double China { get; set; }

        //Stacked Area
        public double Organic { get; set; }
        public double FairTrade { get; set; }
        public double VegAlternatives { get; set; }
        public double Others { get; set; }

        //Grouping
        public string Name { get; set; }
        public double Value { get; set; }
        public double Size { get; set; }
    }
}
