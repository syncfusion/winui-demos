#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using syncfusion.chartdemos.winui.Views;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
namespace syncfusion.chartdemos.winui
{
    public class PopulationLabelConverter1 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                ChartDataLabel pieAdornment = value as ChartDataLabel;
                if ((pieAdornment.Item as Populations).Continent != null)
                {
#pragma warning disable CA1305 // Specify IFormatProvider
                    return String.Format((pieAdornment.Item as Populations).Continent.ToString());
#pragma warning restore CA1305 // Specify IFormatProvider
                }
                else
                    return null;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }

    public class PopulationLabelConverter2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                ChartDataLabel pieAdornment = value as ChartDataLabel;
                if ((pieAdornment.Item as Populations).Countries != null)
                {
#pragma warning disable CA1305 // Specify IFormatProvider
                    return String.Format((pieAdornment.Item as Populations).Countries);
#pragma warning restore CA1305 // Specify IFormatProvider
                }
                else
                    return null;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }

    public class PopulationLabelConverter3 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                ChartDataLabel pieAdornment = value as ChartDataLabel;
#pragma warning disable CA1305 // Specify IFormatProvider
                return String.Format((pieAdornment.Item as Populations).States);
#pragma warning restore CA1305 // Specify IFormatProvider
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
