#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Data;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.Foundation;

namespace syncfusion.chartdemos.winui
{
    public class ColumnPointsConverter2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                var ydata = (value as ColumnSegment).XData;
                Point point = new Point();
                if (ydata == 0.0)
                {
                    point.X = 0;
                    point.Y = 0.25;
                }
                else if (ydata == 1.0)
                {
                    point.X = 0;
                    point.Y = 0.1;
                }
                else if (ydata == 3.0)
                {
                    point.X = 0;
                    point.Y = 0.25;
                }
                else if (ydata == 2.0)
                {
                    point.X = 0;
                    point.Y = 0;
                }
                else if (ydata == 4.0)
                {
                    point.X = 0;
                    point.Y = 0.2;
                }

                return point;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
