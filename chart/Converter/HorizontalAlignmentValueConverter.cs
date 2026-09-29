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
    public class HorizontalAlignmentValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                string alignment = (string)value;
                if (alignment == "Left")
                {
                    return HorizontalAlignment.Left;
                }
                else if (alignment == "Center")
                {
                    return HorizontalAlignment.Center;
                }
                else if (alignment == "Right")
                {
                    return HorizontalAlignment.Right;
                }
            }

            return HorizontalAlignment.Center;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    } 
}
