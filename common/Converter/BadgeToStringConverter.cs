#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Class helps to change the visibility of Badge
    /// </summary>
    public class BadgeToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string text = value as string;
            string expectedText = parameter as string;

            if (text == expectedText)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}