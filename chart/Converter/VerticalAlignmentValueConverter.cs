#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
