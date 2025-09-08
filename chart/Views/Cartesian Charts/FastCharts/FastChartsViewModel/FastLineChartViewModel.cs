#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;

namespace Syncfusion.ChartDemos.WinUI
{
    public class FastLineChartViewModel : IDisposable
    {
        public int DataCount = 5000;
        private Random randomNumber;
        public ObservableCollection<FastLineChartModel> DataCollection { get; set; }

        public FastLineChartViewModel()
        {
            randomNumber = new Random();
            DataCollection = GenerateData();
        }

        public ObservableCollection<FastLineChartModel> GenerateData()
        {
            ObservableCollection<FastLineChartModel> datas = new ObservableCollection<FastLineChartModel>();
            DateTime date = new DateTime(2000, 1, 1);
            double value = 100;

            for (int i = 0; i < this.DataCount; i++)
            {
                datas.Add(new FastLineChartModel(date, value));
                date = date.Add(TimeSpan.FromDays(1));

                if (randomNumber.NextDouble() > .5)
                {
                    value += randomNumber.NextDouble();
                    value = Math.Min(value, 134);
                }
                else
                {
                    value -= randomNumber.NextDouble(); 
                    value = Math.Min(value, 134); 
                }
            }
            return datas;
        }

        public void Dispose()
        {
            if (DataCollection != null)
                DataCollection.Clear();
        }
    }
}
