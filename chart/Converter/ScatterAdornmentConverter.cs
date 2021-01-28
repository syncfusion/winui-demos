#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Data;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.chartdemos.winui
{
    public class ScatterAdornmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string langauge)
        {
            if (value != null)
            {
                var ydata = ((value as ChartDataMarkerLabel).YData);
                var variate = ((value as ChartDataMarkerLabel).Item as ScatterDataValues).Variation;
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
