using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.chartdemos.winui
{
    public class DoughnutLabelConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
#pragma warning disable CA1305 // Specify IFormatProvider
            return String.Format("{0} %", value);
#pragma warning restore CA1305 // Specify IFormatProvider

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
