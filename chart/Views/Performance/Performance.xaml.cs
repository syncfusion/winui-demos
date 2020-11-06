#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace syncfusion.chartdemos.winui.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Performance : Page
    {
        private Random randomNumber;

        public Performance()
        {
            this.InitializeComponent();
            randomNumber = new Random();
            this.Loaded += Performance_Loaded;
        }

        void Performance_Loaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= Performance_Loaded;
            this.lineChart.Series[0].ItemsSource = GenerateData();
        }

        public IList<PerformanceData> GenerateData()
        {
            List<PerformanceData> datas = new List<PerformanceData>();
            DateTime date = DateTime.Now;
            double value = 1000;
            for (int i = 0; i < 100000; i++)
            {
                datas.Add(new PerformanceData(date, value));
                date = date.Add(TimeSpan.FromSeconds(15));

                if (randomNumber.NextDouble() > .5)
                {
                    value += randomNumber.NextDouble();
                }
                else
                {
                    value -= randomNumber.NextDouble();
                }
            }

            return datas;
        }
    }
}
