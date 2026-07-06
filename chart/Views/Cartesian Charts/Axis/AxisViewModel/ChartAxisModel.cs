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
