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
    /// Converts a string value to a corresponding stroke brush color in hexadecimal format.
    /// </summary>
    public class StrokeBrushConverter : IValueConverter
    {
        /// <summary>
        /// Converts a string to its corresponding hexadecimal color code.
        /// </summary>
        /// <param name="value">The string to convert.</param>
        /// <param name="targetType">The target type of the binding (not used).</param>
        /// <param name="parameter">An optional parameter (not used).</param>
        /// <param name="language">The language of the conversion (not used).</param>
        /// <returns>
        /// A string containing a hexadecimal color code if the value text matches a known value;
        /// otherwise, <c>null</c>.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string textValue = value != null ? value.ToString() : string.Empty;
            if (string.IsNullOrEmpty(textValue))
            {
                return null;
            }

            // Return color codes for kanban sorting demo based on the parameter value
            if (parameter != null && parameter.ToString() == "HeaderIcon")
            {
                return textValue switch
                {
                    "To do" => "#8E6FCF",
                    "In progress" => "#C76B1A",
                    "Code Review" => "#D65C54",
                    "Done" => "#33A1A4",
                    _ => null
                };
            }

            if (parameter?.ToString() == "PathBackground")
            {
                return textValue switch
                {
                    "Menu" => "#D1C4E9",
                    "Order" => "#D9C8B6",
                    "Ready to Serve" => "#E8B5B3",
                    "Ready to Delivery" => "#B1E9CD",
                    _ => null
                };
            }

            if (parameter != null && parameter.ToString() == "IndicatorColorKey")
            {
                return textValue switch
                {
                    "High" => "#914C00",
                    "Medium" => "#FFB300",
                    "Low" => "#107C10",
                    "Critical" => "#FF4B5B",
                    _ => null
                };
            }

            return textValue switch
            {
                "Menu" => "#FF6750A4",
                "Order" => "#914C00",
                "Ready to Serve" => "#B3261E",
                "Ready to Delivery" => "#205107",
                _ => null
            };
        }

        /// <summary>
        /// Not implemented. Converts back from a color code to a string.
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