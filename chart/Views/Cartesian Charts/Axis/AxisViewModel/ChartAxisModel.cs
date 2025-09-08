#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

namespace Syncfusion.ChartDemos.WinUI
{
    public class ChartAxisModel
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public double AustraliaValue { get; set; }
        public double IndiaValue { get; set; }

        //DateTime Axis
        public double Growth { get; set; }
        public DateTime Date { get; set; }

        //Logarithmic Axis
        public int Year { get; set; }
        public double Users { get; set; }
    }
}
