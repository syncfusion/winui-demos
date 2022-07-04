#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.ViewManagement;

namespace Syncfusion.DemosCommon.WinUI
{
    /// <summary>
    /// Class providing functionality around switching and restoring theme settings
    /// </summary>
    public static class ThemeHelper
    {
        private const string SelectedAppThemeKey = "SelectedAppTheme";
#if WinUI_Desktop
        public static Window CurrentApplicationWindow;
#else
        private static Window CurrentApplicationWindow;
#endif

        /// <summary>
        /// Gets or sets (with LocalSettings persistence) the RequestedTheme of the root element.
        /// </summary>
        public static ElementTheme RootTheme
        {
            get
            {
#if WinUI_Desktop
                if (CurrentApplicationWindow != null && CurrentApplicationWindow.Content is FrameworkElement rootElement)
#else
                if (Window.Current.Content is FrameworkElement rootElement)
#endif
                {
                    return rootElement.RequestedTheme;
                }

                return ElementTheme.Default;
            }
            set
            {
#if WinUI_Desktop
                if (CurrentApplicationWindow != null && CurrentApplicationWindow.Content is FrameworkElement rootElement)
#else
                if (Window.Current != null && Window.Current.Content is FrameworkElement rootElement)
#endif
                {
                    rootElement.RequestedTheme = value;
                }

                ApplicationData.Current.LocalSettings.Values[SelectedAppThemeKey] = value.ToString();
                UpdateSystemCaptionButtonColors();
            }
        }

        public static bool IsDarkTheme()
        {
            if (RootTheme == ElementTheme.Default)
            {
                return Application.Current.RequestedTheme == ApplicationTheme.Dark;
            }
            return RootTheme == ElementTheme.Dark;
        }

        public static void Initialize()
        {
#if !WinUI_Desktop
            CurrentApplicationWindow = Window.Current;
#endif
            string savedTheme = ApplicationData.Current.LocalSettings.Values[SelectedAppThemeKey]?.ToString();

            if (savedTheme != null)
            {
                Enum.TryParse(typeof(ElementTheme), savedTheme, out object theme);
                RootTheme = (ElementTheme)theme;
            }
        } 
        

        public static void UpdateSystemCaptionButtonColors()
        {
#if !WinUI_Desktop
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;

            if (ThemeHelper.IsDarkTheme())
            {
                titleBar.ButtonForegroundColor = Colors.White;
                titleBar.ButtonBackgroundColor = Colors.Black;
            }
            else
            {
                titleBar.ButtonForegroundColor = Colors.Black;
                titleBar.ButtonBackgroundColor = Colors.White;
            }
#endif
        }
    }
}
