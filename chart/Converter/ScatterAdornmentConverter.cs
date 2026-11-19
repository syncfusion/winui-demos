using Microsoft.UI.Xaml.Data;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syncfusion.ChartDemos.WinUI
{
    public class ScatterAdornmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string langauge)
        {
            if (value != null)
            {
                var ydata = ((value as ChartDataLabel).YData);
                var variate = ((value as ChartDataLabel).Item as ScatterDataValues).Variation;
                if (ydata >= 25)
#pragma warning disable CA1305 // Specify IFormatProvider
                    return String.Format("+" + variate);
                return String.Format("-" + variate);
#pragma warning restore CA1305 // Specify IFormatProvider
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
