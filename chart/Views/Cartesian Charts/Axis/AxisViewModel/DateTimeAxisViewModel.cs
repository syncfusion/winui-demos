using System;
using System.Collections.ObjectModel;

namespace Syncfusion.ChartDemos.WinUI
{
    public class DateTimeAxisViewModel : IDisposable
    {
        public ObservableCollection<ChartAxisModel> DateTimeData { get; set; }
        public DateTimeAxisViewModel()
        {
            DateTimeData = new ObservableCollection<ChartAxisModel>();

            Random rand = new();
            double value = 100;
            DateTime date = new(2017, 1, 1);

            for (int i = 0; i < 100; i++)
            {
                if (rand.NextDouble() > 0.5)
                    value += rand.NextDouble();
                else
                    value -= rand.NextDouble();

                DateTimeData.Add(new ChartAxisModel { Growth = value, Date = date });
                date = date.AddDays(1);

            }
        }

        public void Dispose()
        {
            if(DateTimeData != null)
                DateTimeData.Clear();
        }
    }
}
