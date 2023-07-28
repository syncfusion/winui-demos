#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
    public class FormatToStringConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null && value is ComboBoxItem)
            {
                ComboBoxItem item = value as ComboBoxItem;
                return item.Tag.ToString();
            }
            return "N";
        }

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
