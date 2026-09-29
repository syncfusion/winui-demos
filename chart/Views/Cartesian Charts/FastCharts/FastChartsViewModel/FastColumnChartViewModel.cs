using System;
using System.Collections.ObjectModel;

namespace Syncfusion.ChartDemos.WinUI
{
    public class FastColumnChartViewModel : IDisposable
    {
        DateTime date = new DateTime(1999, 1, 1);
        public ObservableCollection<FastColumnChartModel> Data { get; set; }
        public ObservableCollection<FastColumnChartModel> WeatherData { get; set; }

        public FastColumnChartViewModel()
        {
            //Fast Column Series
            Data = new ObservableCollection<FastColumnChartModel>();
            Random random = new Random();
            for (int i = 0; i < 60; i++)
            {
                Data.Add(new FastColumnChartModel() { Date = date.AddDays(i), Price = random.Next(1, 100) });
            }

            //Fast Step Line Series
            WeatherData = new ObservableCollection<FastColumnChartModel>();
            Random random1 = new Random();
            for (int i = 0; i < 60; i++)
            {
                WeatherData.Add(new FastColumnChartModel() { Date = date.AddDays(i), Value = random1.Next(1, 134) });
            }
        }

        public void Dispose()
        {
            if(Data != null)
                Data.Clear();

            if(WeatherData != null)
                WeatherData.Clear();
        }
    }
}
