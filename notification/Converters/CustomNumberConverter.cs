#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Data;
using System;
using System.Globalization;

namespace Syncfusion.NotificationDemos.WinUI
{
    public class CustomNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null && int.TryParse(value.ToString(), out int number))
            {
                if (number <= 99)
                {
                    return value;
                }
                else if (number <= 999)
                {
                    return "99+";
                }
                else if (number < 99999)
                {
                    return (number / 1000).ToString("0.#", CultureInfo.InvariantCulture) + "K";
                }
                else if (number < 999999)
                {
                    return (number / 1000).ToString("#,0K", CultureInfo.InvariantCulture);
                }
                else if (number < 9999999)
                {
                    return (number / 1000000).ToString("0.#", CultureInfo.InvariantCulture) + "M";
                }
                else
                {
                    return (number / 1000000).ToString("#,0M", CultureInfo.InvariantCulture);
                }
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
