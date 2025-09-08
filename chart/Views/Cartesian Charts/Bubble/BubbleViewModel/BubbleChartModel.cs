#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Syncfusion.ChartDemos.WinUI
{
    public class BubbleChartModel
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Size { get; set; }

        public BubbleChartModel(string name, double value, double high, double low)
        {
            Name = name;
            Value = value;
            High = high;
            Low = low;
        }

        public BubbleChartModel(string name, double high, double low, double open, double close)
        {
            Name = name;
            High = high;
            Low = low;
            Value = open;
            Size = close;
        }
    }
}
