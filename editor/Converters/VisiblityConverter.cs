#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.UI.Xaml.Editors;
using Syncfusion.EditorDemos.WinUI;

namespace Syncfusion.DemosCommon.WinUI
{
    /// <summary>
    /// Converts a source value to a <see cref="Visibility"/> state based on a parameter comparison.
    /// It's designed to control the visibility of UI elements.
    /// </summary>
    public class VisiblityConverter : IValueConverter
    {
        /// <summary>
        /// Converts a source value to a <see cref="Visibility.Visible"/> state if the source value (expected to be a Segment's Name)
        /// matches the provided parameter (case-insensitive). Otherwise, returns <see cref="Visibility.Collapsed"/>.
        /// </summary>
        /// <param name="value">The source value to convert. Expected to be a <see cref="Segment"/> object from which the Name is extracted.</param>
        /// <param name="targetType">The target type for the conversion (expected to be <see cref="Visibility"/>).</param>
        /// <param name="parameter">The string parameter to compare against the source value's name.</param>
        /// <param name="language">The culture/language information (not used).</param>
        /// <returns><see cref="Visibility.Visible"/> if the source value matches the parameter; otherwise, <see cref="Visibility.Collapsed"/>.</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if ((value as Segment).Name.ToLower() == parameter.ToString().ToLower())
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Converts a <see cref="Visibility"/> state back to a source value.
        /// This method appears to have redundant logic and might not behave as expected for a typical ConvertBack scenario.
        /// It performs the same comparison as Convert and returns Visibility, which is likely not the intended reverse action.
        /// </summary>
        /// <param name="value">The visibility value to convert back (expected to be <see cref="Visibility"/>).</param>
        /// <param name="targetType">The target type for the conversion (expected to be related to the source value, like Segment Name).</param>
        /// <param name="parameter">The string parameter to compare against.</param>
        /// <param name="language">The culture/language information (not used).</param>
        /// <returns><see cref="Visibility.Visible"/> if the visibility matches the parameter comparison; otherwise, <see cref="Visibility.Collapsed"/>.</returns>
        /// <remarks>
        /// The ConvertBack method's implementation might need review. It currently returns Visibility, which might not be the desired output
        /// for a typical two-way binding scenario aiming to set the source value based on the parameter.
        /// </remarks>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if ((value as Segment).Name.ToLower() == parameter.ToString().ToLower())
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }
    }
}
