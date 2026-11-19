using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace Syncfusion.ChartDemos.WinUI
{
    public class SplineValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                var ydata = (value as SplineSegment).YData;
                Brush interior;

                interior = ydata > 0 ?
                    new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xC1, 0x07)) :
                    new SolidColorBrush(Color.FromArgb(0xFF, 0xD1, 0xD3, 0xD4));

                return interior;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class SelectionValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((DateTime)value).ToString("ddd-hh:mm");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
