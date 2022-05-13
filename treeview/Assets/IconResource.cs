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

namespace syncfusion.treeviewdemos.winui
{   
    public static class IconResource
    {
        public static ResourceDictionary Resource
        {
            get
            {
                string assemblyName = Assembly.GetEntryAssembly().GetName().Name;

                if (assemblyName.Equals("syncfusion.samplebrowser.winui"))
                {
                    return new ResourceDictionary { Source = new Uri("ms-appx:///syncfusion.treeviewdemos.winui/Assets/PathIcon.xaml", UriKind.RelativeOrAbsolute) };
                }
                else
                {
                    return new ResourceDictionary { Source = new Uri("ms-appx:///Assets/PathIcon.xaml", UriKind.RelativeOrAbsolute) };
                }
            }
        }
    }
}
