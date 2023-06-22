#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
