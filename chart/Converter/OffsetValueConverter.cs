using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Data;

namespace syncfusion.chartdemos.winui
{
    public class OffsetValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
#pragma warning disable CA1305 // Specify IFormatProvider
                return (double)System.Convert.ToDouble(value);
#pragma warning restore CA1305 // Specify IFormatProvider
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    } 
}
