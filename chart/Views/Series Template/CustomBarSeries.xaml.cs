#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

using Microsoft.UI.Text;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using syncfusion.demoscommon.winui;
using Syncfusion.UI.Xaml.Charts;
using System;
using Windows.System.Profile;
using Windows.UI;

namespace syncfusion.chartdemos.winui.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomBarSeries : Page, IDisposable
    {
        public CustomBarSeries()
        {
            this.InitializeComponent();

            temp1 = bardemo.Resources["carTemplate1"] as DataTemplate;
            temp2 = bardemo.Resources["carTemplate2"] as DataTemplate;
            temp3 = bardemo.Resources["carTemplate3"] as DataTemplate;
            temp4 = bardemo.Resources["carTemplate4"] as DataTemplate;
            temp5 = bardemo.Resources["carTemplate5"] as DataTemplate;
        }
        public DataTemplate temp1 { get; set; }
        public DataTemplate temp2 { get; set; }
        public DataTemplate temp3 { get; set; }
        public DataTemplate temp4 { get; set; }
        public DataTemplate temp5 { get; set; }

        public void Dispose()
        {
            Chart.Dispose();
        }
    }  
}
