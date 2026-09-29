using System;

namespace Syncfusion.ChartDemos.WinUI
{
    public class ZoomingModel
    {
        public DateTime Date { get; set; }
        public double Value { get; set; }

        public ZoomingModel(DateTime dateTime, double value)
        {
            Date = dateTime;
            Value = value;
        }
    }
}
