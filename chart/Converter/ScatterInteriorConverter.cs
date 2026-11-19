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
    public class ScatterInteriorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                var ydata = (value as ScatterSegment).YData;
                Brush interior;
              
                  interior = ydata >= 25 ? new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0xB5, 0x53)) :
                   new SolidColorBrush(Color.FromArgb(0xFF, 0xE4, 0x44, 0x44)); ;

                return interior;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
