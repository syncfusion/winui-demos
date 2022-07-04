#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Syncfusion.ChartDemos.WinUI.Resources
{
    public static class ColorModelResource
    {
        public static ResourceDictionary Resource
        {
            get
            {
#if Main_SB
                return new ResourceDictionary { Source = new Uri("ms-appx:///Chart/Resources/ColorModel.xaml", UriKind.RelativeOrAbsolute) };
#else
                return new ResourceDictionary { Source = new Uri("ms-appx:///Resources/ColorModel.xaml", UriKind.RelativeOrAbsolute) };
#endif
            }
        }
    }
}
