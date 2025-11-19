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
    /// <summary>
    /// Converts temperature values between different scales (Celsius, Fahrenheit, Kelvin, Rankine).
    /// This converter is useful for UI elements that need to display or input temperature values in various units.
    /// The conversion is based on a chosen parameter: "F" for Fahrenheit, "K" for Kelvin, "RA" for Rankine, or a default (Celsius).
    /// </summary>
    public class TemperatureConverter : IValueConverter
    {
        /// <summary>
        /// Converts a temperature value from Celsius to a specified target scale (Fahrenheit, Kelvin, or Rankine).
        /// </summary>
        /// <param name="value">The temperature value in Celsius to convert.</param>
        /// <param name="targetType">The target type for the conversion (not used).</param>
        /// <param name="parameter">The target temperature scale: "F" for Fahrenheit, "K" for Kelvin, "RA" for Rankine. Defaults to Celsius if null or unrecognized.</param>
        /// <param name="language">The culture/language information (not used).</param>
        /// <returns>The converted temperature value in the target scale, or the original value if the parameter is null or unrecognized.</returns>
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

        /// <summary>
        /// Converts a temperature value from a specified scale (Fahrenheit, Kelvin, or Rankine) back to Celsius.
        /// </summary>
        /// <param name="value">The temperature value in the target scale to convert back to Celsius.</param>
        /// <param name="targetType">The target type for the conversion (not used).</param>
        /// <param name="parameter">The source temperature scale: "F" for Fahrenheit, "K" for Kelvin, "RA" for Rankine. Defaults to Celsius if null or unrecognized.</param>
        /// <param name="language">The culture/language information (not used).</param>
        /// <returns>The converted temperature value in Celsius, or the original value if the parameter is null or unrecognized.</returns>
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
