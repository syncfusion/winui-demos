using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Syncfusion.TreeViewDemos.WinUI
{   
    public static class IconResource
    {
        public static ResourceDictionary Resource
        {
            get
            {
#if Main_SB
                 return new ResourceDictionary { Source = new Uri("ms-appx:///TreeView/Assets/PathIcon.xaml", UriKind.RelativeOrAbsolute) };
#else
                 return new ResourceDictionary { Source = new Uri("ms-appx:///Assets/PathIcon.xaml", UriKind.RelativeOrAbsolute) };
#endif
            }
        }
    }
}
