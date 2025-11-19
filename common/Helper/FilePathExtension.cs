#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
    /// <summary>
    /// A Markup Extension that allows conditionally including XAML resources based on build configurations.
    /// It allows specifying different resource paths for 'Common' and 'Individual' builds.
    /// </summary>
    [MarkupExtensionReturnType(ReturnType = typeof(object))]
    public class ConditionalXAML : MarkupExtension
    {
        /// <summary>
        /// Gets or sets the XAML resource path for individual builds.
        /// </summary>
        public string Individual { get; set; }
        /// <summary>
        /// Gets or sets the XAML resource path for common builds.
        /// </summary>
        public string Common { get; set; }

        /// <summary>
        /// Provides the appropriate XAML resource value based on the current build configuration.
        /// </summary>
        /// <param name="serviceProvider">Provides context information for the markup extension.</param>
        /// <returns>The appropriate XAML resource string.</returns>
        protected override object ProvideValue(IXamlServiceProvider serviceProvider)
        {
#if Main_SB
            return Common;
#else
            return Individual;
#endif
        }
    }

    /// <summary>
    /// A derived ResourceDictionary that specifically loads theme resources based on the build configuration.
    /// It points to different paths for 'Common' theme resources or 'Syncfusion.DemosCommon.WinUI' specific theme resources.
    /// </summary>
    internal class ThemeResourcesDictionary : ResourceDictionary
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ThemeResourcesDictionary"/> class.
        /// The Source URI is set conditionally based on the Main_SB preprocessor directive.
        /// </summary>
        public ThemeResourcesDictionary()
        {
#if Main_SB
            this.Source = new Uri(@"ms-appx:///Common/Themes/themeresources.xaml", UriKind.RelativeOrAbsolute);
#else
            this.Source = new Uri(@"ms-appx:///Syncfusion.DemosCommon.WinUI/Themes/themeresources.xaml", UriKind.RelativeOrAbsolute);
#endif
        }
    }

    /// <summary>
    /// A Markup Extension that provides a <see cref="FontFamily"/> for ControlIcons.
    /// The font family source URI is conditionally set based on the build configuration ('Main_SB' or else).
    /// </summary>
    [MarkupExtensionReturnType(ReturnType = typeof(FontFamily))]
    internal class ControlIcons : MarkupExtension
    {
        /// <summary>
        /// Provides the ControlIcons font family based on the current build configuration.
        /// </summary>
        /// <param name="serviceProvider">Provides context information for the markup extension.</param>
        /// <returns>A <see cref="FontFamily"/> object representing ControlIcons.</returns>
        protected override object ProvideValue(IXamlServiceProvider serviceProvider)
        {
#if Main_SB
            return new FontFamily(@"ms-appx:///Common/Assets/ControlIcons.ttf#ControlIcons");
#else
            return new FontFamily(@"ms-appx:///Syncfusion.DemosCommon.WinUI/Assets/ControlIcons.ttf#ControlIcons");
#endif
        }
    }

    /// <summary>
    /// A Markup Extension that provides a <see cref="FontFamily"/> for SBIcons.
    /// The font family source URI is conditionally set based on the build configuration ('Main_SB' or else).
    /// </summary>
    [MarkupExtensionReturnType(ReturnType = typeof(FontFamily))]
    internal class SBIcons : MarkupExtension
    {
        /// <summary>
        /// Provides the SBIcons font family based on the current build configuration.
        /// </summary>
        /// <param name="serviceProvider">Provides context information for the markup extension.</param>
        /// <returns>A <see cref="FontFamily"/> object representing SBIcons.</returns>
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
