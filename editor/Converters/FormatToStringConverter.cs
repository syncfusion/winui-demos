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


namespace Syncfusion.EditorDemos.WinUI
{
    /// <summary>
    /// Converts a <see cref="ComboBoxItem"/> to its string Tag value.
    /// This converter is useful for binding the selected item's tag to a string property.
    /// </summary>
    public class FormatToStringConverter : IValueConverter
    {
        /// <summary>
        /// Converts a <see cref="ComboBoxItem"/> to its string Tag value.
        /// If the input value is a <see cref="ComboBoxItem"/> and has a non-null Tag, its string representation is returned.
        /// Otherwise, "N" is returned as a default.
        /// </summary>
        /// <param name="value">The ComboBoxItem to convert.</param>
        /// <param name="targetType">The target type of the binding (not used).</param>
        /// <param name="parameter">Optional parameter for converter logic (not used).</param>
        /// <param name="language">The culture/language information (not used).</param>
        /// <returns>The string Tag of the ComboBoxItem, or "N" if conversion is not possible.</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null && value is ComboBoxItem)
            {
                ComboBoxItem item = value as ComboBoxItem;
                return item.Tag.ToString();
            }
            return "N";
        }

        /// <summary>
        /// Converts a string value back to a <see cref="ComboBoxItem"/>.
        /// This method is not fully implemented for typical UI binding scenarios where the ComboBoxItem itself is bound.
        /// It currently returns the string value or "N" if conversion is not possible or if the value is null unexpectedly.
        /// </summary>
        /// <param name="value">The string value to convert back (not directly used for ComboBoxItem creation).</param>
        /// <param name="targetType">The target type of the binding (not used).</param>
        /// <param name="parameter">Optional parameter for converter logic (not used).</param>
        /// <param name="language">The culture/language information (not used).</param>
        /// <returns>The input string value if not null, otherwise "N". Note: This does not create a ComboBoxItem.</returns>
        /// <exception cref="NotImplementedException">This method may conceptually throw, but current implementation returns a default value.</exception>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value != null && value is ComboBoxItem)
            {
                ComboBoxItem item = value as ComboBoxItem;
                return item.Tag.ToString();
            }
            return "N";
        }
    }
}
