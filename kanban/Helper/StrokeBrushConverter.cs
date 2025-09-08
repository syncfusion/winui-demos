#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Syncfusion.KanbanDemos.WinUI
{
    using Microsoft.UI.Xaml.Data;
    using System;

    /// <summary>
    /// Converts a string header value to a corresponding stroke brush color in hexadecimal format.
    /// </summary>
    public class StrokeBrushConverter : IValueConverter
    {
        /// <summary>
        /// Converts a header string to its corresponding hexadecimal color code.
        /// </summary>
        /// <param name="value">The header string to convert.</param>
        /// <param name="targetType">The target type of the binding (not used).</param>
        /// <param name="parameter">An optional parameter (not used).</param>
        /// <param name="language">The language of the conversion (not used).</param>
        /// <returns>
        /// A string containing a hexadecimal color code if the header matches a known value;
        /// otherwise, <c>null</c>.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string header = value as string;

            if (string.IsNullOrEmpty(header))
            {
                return null;
            }

            return header switch
            {
                "Menu" => "#D43F38",
                "Order" => "#107C10",
                "Ready to Serve" => "#EF6C00",
                "Ready to Delivery" => "#689F38",
                _ => null
            };
        }

        /// <summary>
        /// Not implemented. Converts back from a color code to a header string.
        /// </summary>
        /// <param name="value">The value produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">An optional parameter.</param>
        /// <param name="language">The language of the conversion.</param>
        /// <returns> Always returns <c>null</c>.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}