#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Shapes;
using System;

namespace syncfusion.demoscommon.winui
{
    /// <summary>
    /// A Class to convert string to geometry path
    /// </summary>
    public class StringToGeometryConverter : MarkupExtension, IValueConverter
    {
        /// <summary>
        /// Convert a string value to geometry type.
        /// </summary>
        /// <param name="value">The source data being passed to the target.</param>
        /// <param name="targetType">The type of the target property, as a type reference.</param>
        /// <param name="parameter">An optional parameter to be used to invert the converter logic.</param>
        /// <param name="language">The language of the conversion.</param>
        /// <returns>The value to be passed to the target dependency property.</returns>
        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            if (value != null)
            {
                string pathMarkup = value.ToString();
                string xaml =
             "<Path " +
             "xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'>" +
             "<Path.Data>" + pathMarkup + "</Path.Data></Path>";
                var path = XamlReader.Load(xaml) as Path;
                Geometry geometry = path.Data;
                path.Data = null;
                return geometry;
            }

            return null;
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <remarks>If the <paramref name="value"/> parameter is a reference type, <see cref="TrueValue"/> must match its reference to return true.</remarks>
        /// <param name="value">The target data being passed to the source.</param>
        /// <param name="targetType">The type of the target property, as a type reference (System.Type for Microsoft .NET, a TypeName helper struct for Visual C++ component extensions (C++/CX)).</param>
        /// <param name="parameter">An optional parameter to be used to invert the converter logic.</param>
        /// <param name="language">The language of the conversion.</param>
        /// <returns>The value to be passed to the source object.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            throw new NotImplementedException();
        }
    }
}
