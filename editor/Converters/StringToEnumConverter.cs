#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
    public class StringToEnumConverter : IValueConverter
    {
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

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
