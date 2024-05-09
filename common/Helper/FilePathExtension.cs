#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.Media;
using System;

namespace Syncfusion.DemosCommon.WinUI
{
    public class ConditionalXAML : MarkupExtension
    {
        public string Individual { get; set; }
        public string Common { get; set; }

        protected override object ProvideValue(IXamlServiceProvider serviceProvider)
        {
#if Main_SB
            return Common;
#else
            return Individual;
#endif
        }
    }

    internal class ThemeResourcesDictionary : ResourceDictionary
    {
        public ThemeResourcesDictionary()
        {
#if Main_SB
            this.Source = new Uri(@"ms-appx:///Common/Themes/themeresources.xaml", UriKind.RelativeOrAbsolute);
#else
            this.Source = new Uri(@"ms-appx:///Syncfusion.DemosCommon.WinUI/Themes/themeresources.xaml", UriKind.RelativeOrAbsolute);
#endif
        }
    }

    internal class ControlIcons : MarkupExtension
    {
        protected override object ProvideValue(IXamlServiceProvider serviceProvider)
        {
#if Main_SB
            return new FontFamily(@"ms-appx:///Common/Assets/ControlIcons.ttf#ControlIcons");
#else
            return new FontFamily(@"ms-appx:///Syncfusion.DemosCommon.WinUI/Assets/ControlIcons.ttf#ControlIcons");
#endif
        }
    }

    internal class SBIcons : MarkupExtension
    {
        protected override object ProvideValue(IXamlServiceProvider serviceProvider)
        {
#if Main_SB
            return new FontFamily(@"ms-appx:///Common/Assets/SBIcons.ttf#SBIcons");
#else
            return new FontFamily(@"ms-appx:///Syncfusion.DemosCommon.WinUI/Assets/SBIcons.ttf#SBIcons");
#endif
        }
    }
}
