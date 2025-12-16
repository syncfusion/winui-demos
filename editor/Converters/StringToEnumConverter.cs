#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Data;
using Syncfusion.UI.Xaml.Editors;
using System;
using System.ComponentModel.DataAnnotations;

namespace Syncfusion.EditorDemos.WinUI
{
    /// <summary>
    /// Converts a string representation of color channel options into the corresponding enum value (<see cref="ColorChannelOptions"/>).
    /// This converter is useful for mapping string inputs from UI elements (like ComboBoxes) to enum flags.
    /// </summary>
    public class StringToEnumConverter : IValueConverter
    {
        /// <summary>
        /// Converts a string value to a <see cref="ColorChannelOptions"/> enum value.
        /// It handles specific string inputs like "RGB", "RGB and CMYK", "HSV and HSL", "All", and provides a default.
        /// </summary>
        /// <param name="value">The string value to convert (e.g., "RGB", "All").</param>
        /// <param name="targetType">The target type of the binding (expected to be <see cref="ColorChannelOptions"/>).</param>
        /// <param name="parameter">Optional parameter for converter logic (not used).</param>
        /// <param name="language">The culture/language information (not used).</param>
        /// <returns>The corresponding <see cref="ColorChannelOptions"/> enum value, or ColorChannelOptions.All as a default.</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            switch (value)
            {
                case "RGB":
                    return ColorChannelOptions.RGB;
                case "RGB & CMYK":
                    return ColorChannelOptions.RGB | ColorChannelOptions.CMYK;
                case "HSV & HSL":
                    return ColorChannelOptions.HSV | ColorChannelOptions.HSL;
                case "All":
                    return ColorChannelOptions.All;
                default:
                    return ColorChannelOptions.All;
            }
        }

        /// <summary>
        /// Converts a <see cref="ColorChannelOptions"/> enum value back to its string representation.
        /// This method is not implemented and will throw a <see cref="NotImplementedException"/>.
        /// </summary>
        /// <param name="value">The enum value to convert back (not used).</param>
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
