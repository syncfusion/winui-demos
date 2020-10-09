#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using syncfusion.chartdemos.winui.Views;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace syncfusion.chartdemos.winui
{
    public class BarTopConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string culture)
        {
#pragma warning disable CA2000 // Dispose objects before losing scope
            CustomBarSeries barSeries = new CustomBarSeries();
#pragma warning restore CA2000 // Dispose objects before losing scope
            if (value != null)
            {
                var itemData = (value as BarSegment).XData;
                if (itemData == 0.0)
                    return barSeries.temp1;
                else if (itemData == 1.0)
                    return barSeries.temp2;
                else if (itemData == 2.0)
                    return barSeries.temp3;
                else if (itemData == 3.0)
                    return barSeries.temp4;
                else if (itemData == 4.0)
                    return barSeries.temp5;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            return value;
        }
    }

}
