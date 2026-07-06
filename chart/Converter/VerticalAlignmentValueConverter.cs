using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;

namespace syncfusion.chartdemos.winui
{
    public class VerticalAlignmentValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                string alignment = (string)value;
                if (alignment == "Top")
                {
                    return VerticalAlignment.Top;
                }
                else if (alignment == "Center")
                {
                    return VerticalAlignment.Center;
                }
                else if (alignment == "Bottom")
                {
                    return VerticalAlignment.Bottom;
                }
            }

            return VerticalAlignment.Top;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
