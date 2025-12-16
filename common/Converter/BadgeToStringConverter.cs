#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;

namespace Syncfusion.DemosCommon.WinUI
{
    /// <summary>
    /// Class helps to convert the Badge to string
    /// </summary>
    public class BadgeToStringConverter : IValueConverter
    {
        /// <summary>
        /// Converts a badge value to a descriptive string that can be displayed to the user.
        /// </summary>
        /// <param name="value">The badge value to convert.</param>
        /// <param name="targetType">The target type of the binding (not used).</param>
        /// <param name="parameter">Optional parameter for converter logic (not used).</param>
        /// <param name="language">The culture/language information (not used).</param>
        /// <returns>A descriptive string that matches the badge identifier, or the original value if no match is found.</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null && value.ToString() == "New")
            {
                return "Recently Added Samples";
            }
            else if (value != null && value.ToString() == "Updated")
            {
                return "Recently Updated Samples";
            }
            else if (value != null && value.ToString().Contains("AISamples"))
            {
                return "Smart AI Solutions";
            }

            return value;
        }

        /// <summary>
        /// Not implemented. Conversion back from descriptive string to badge identifier is not supported.
        /// </summary>
        /// <param name="value">The value to convert back (not used).</param>
        /// <param name="targetType">The target type of the binding (not used).</param>
        /// <param name="parameter">Optional parameter for converter logic (not used).</param>
        /// <param name="language">The culture/language information (not used).</param>
        /// <returns>This method always throws <see cref="NotImplementedException"/>.</returns>
        /// <exception cref="NotImplementedException">Thrown because conversion back is not supported.</exception>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Converts a badge value to <see cref="Visibility"/> based on a supplied parameter.
    /// </summary>
    public class BadgeToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts a badge value to <see cref="Visibility.Visible"/> when it matches the specified parameter; otherwise returns <see cref="Visibility.Collapsed"/>.
        /// </summary>
        /// <param name="value">The badge value to evaluate.</param>
        /// <param name="targetType">The target type of the binding (not used).</param>
        /// <param name="parameter">The expected badge value to compare against.</param>
        /// <param name="language">The culture/language information (not used).</param>
        /// <returns><see cref="Visibility.Visible"/> if the badge matches the parameter; otherwise <see cref="Visibility.Collapsed"/>.</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string text = value as string;
            string expectedText = parameter as string;

            if (text == expectedText)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }

        /// <summary>
        /// Not implemented. Converting from <see cref="Visibility"/> back to a badge value is not supported.
        /// </summary>
        /// <param name="value">The value to convert back (not used).</param>
        /// <param name="targetType">The target type of the binding (not used).</param>
        /// <param name="parameter">Optional parameter for converter logic (not used).</param>
        /// <param name="language">The culture/language information (not used).</param>
        /// <returns>This method always throws <see cref="NotImplementedException"/>.</returns>
        /// <exception cref="NotImplementedException">Thrown because conversion back is not supported.</exception>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}