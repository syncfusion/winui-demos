#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using System;
using System.Globalization;

namespace Syncfusion.EditorDemos.WinUI
{
    public class TemperatureConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (parameter == null)
                return value;
            if (value == null)
            {
                return null;
            }
            double _value = Double.Parse(value.ToString());

            if (parameter.Equals("F"))
            {
                return ((_value - 1) * 1.8) + 33.8;
            }
            else if (parameter.Equals("K"))
            {
                return (_value - 1) + 274.15;
            }
            else if (parameter.Equals("RA"))
            {
                return ((_value - 1) * 1.8) + 493.47;
            }
            else
            {
                return Decimal.Parse(value.ToString());
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (parameter == null)
                return value;
            if (value == null)
            {
                return null;
            }
            double _value = Double.Parse(value.ToString());

            if (parameter.Equals("F"))
            {
                return (_value - 33.8) / 1.8 + 1;
            }
            else if (parameter.Equals("K"))
            {
                return (_value - 274.15) + 1;
            }
            else if (parameter.Equals("RA"))
            {
                return (_value - 493.47) / 1.8 + 1;
            }
            else
            {
                return Decimal.Parse(value.ToString());
            }
        }
    }
}
