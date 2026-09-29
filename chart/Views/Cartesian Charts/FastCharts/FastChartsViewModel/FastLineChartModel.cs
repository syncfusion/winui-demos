using System;

namespace Syncfusion.ChartDemos.WinUI
{
    public class FastLineChartModel
    {
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public FastLineChartModel(DateTime date, double value)
        {
            Date = date;
            Value = value;
        }
    }
}
