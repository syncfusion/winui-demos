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
    public class LabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            ChartDataMarkerLabel pieAdornment = value as ChartDataMarkerLabel;

            if (pieAdornment == null) return value;

            var model = pieAdornment.Item as Populations;

            if (model != null)
            {
#pragma warning disable CA1305 // Specify IFormatProvider
                return String.Format(model.Countries + " : " + pieAdornment.YData);
#pragma warning restore CA1305 // Specify IFormatProvider
            }
            else
            {
                var list = pieAdornment.Item as List<object>;
                string labelData = "";

                for (int i = 0; i < list.Count; i++)
                {
                    var item = list[i] as Populations;
#pragma warning disable CA1305 // Specify IFormatProvider
                    labelData = labelData + String.Format(item.Countries + " : " + item.Count);
#pragma warning restore CA1305 // Specify IFormatProvider

                    if (i + 1 != list.Count)
                    {
                        labelData = labelData + Environment.NewLine;
                    }
                }

                return labelData;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }

    public class ColorConverter : IValueConverter
    {
        private static SolidColorBrush ApplyLight(Color color)
        {
            return new SolidColorBrush(Color.FromArgb(color.A, (byte)(color.R * 0.9), (byte)(color.G * 0.9), (byte)(color.B * 0.9)));
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null && (value is ChartDataMarkerLabel))
            {
                ChartDataMarkerLabel pieAdornment = value as ChartDataMarkerLabel;
                int index = pieAdornment.Series.Adornments.IndexOf(pieAdornment);
                SolidColorBrush brush = pieAdornment.Series.ColorModel.GetBrush(index) as SolidColorBrush;
                return ApplyLight(brush.Color);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }

    public class PopulationLabelConverter1 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                ChartDataMarkerLabel pieAdornment = value as ChartDataMarkerLabel;
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
                ChartDataMarkerLabel pieAdornment = value as ChartDataMarkerLabel;
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
                ChartDataMarkerLabel pieAdornment = value as ChartDataMarkerLabel;
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
