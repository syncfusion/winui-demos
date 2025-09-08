#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Syncfusion.ChartDemos.WinUI
{
    public class ScatterChartModel
    {
        public double Value { get; set; }
        public double Size { get; set; }

        public ScatterChartModel(double value, double size)
        {
            Value = value;
            Size = size;
        }

    }
}
