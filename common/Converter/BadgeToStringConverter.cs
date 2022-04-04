#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Microsoft.UI.Xaml.Data;

namespace syncfusion.demoscommon.winui
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

            return value;
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
