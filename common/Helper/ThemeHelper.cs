#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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

        /// <summary>
        /// Reference to the current application window, needed for theme application.
        /// </summary>
        public static Window CurrentApplicationWindow;

        /// <summary>
        /// Gets or sets (with LocalSettings persistence) the RequestedTheme of the root element.
        /// </summary>
        public static ElementTheme RootTheme
        {
            get
            {
                if (CurrentApplicationWindow != null && CurrentApplicationWindow.Content is FrameworkElement rootElement)
                {
                    return rootElement.RequestedTheme;
                }

                return ElementTheme.Default;
            }
            set
            {
                if (CurrentApplicationWindow != null && CurrentApplicationWindow.Content is FrameworkElement rootElement)
                {
                    rootElement.RequestedTheme = value;
                }

                ApplicationData.Current.LocalSettings.Values[SelectedAppThemeKey] = value.ToString();
                UpdateSystemCaptionButtonColors();
            }
        }

        /// <summary>
        /// Checks if the application is currently using a dark theme.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the application theme is dark (either Default resolved to Dark, or explicitly set to Dark);
        /// otherwise, <c>false</c>.
        /// </returns>
        public static bool IsDarkTheme()
        {
            if (RootTheme == ElementTheme.Default)
            {
                return Application.Current.RequestedTheme == ApplicationTheme.Dark;
            }
            return RootTheme == ElementTheme.Dark;
        }

        /// <summary>
        /// Initializes the theme settings by loading the previously saved theme preference
        /// from local settings. This method should be called early in the application's
        /// startup sequence.
        /// </summary>
        public static void Initialize()
        {
            string savedTheme = ApplicationData.Current.LocalSettings.Values[SelectedAppThemeKey]?.ToString();

            if (savedTheme != null)
            {
                Enum.TryParse(typeof(ElementTheme), savedTheme, out object theme);
                RootTheme = (ElementTheme)theme;
            }
        } 
        

        /// <summary>
        /// Updates the color of the system caption button (e.g., minimize, maximize, close buttons)
        /// to match the current application theme.
        /// This method is intended to bridge UI theme changes with system UI elements.
        /// </summary>
        /// <remarks>
        /// The actual implementation of changing system caption button colors might depend on
        /// the specific platform and requires platform-specific APIs (e.g., using Windows.UI.ViewManagement.UISettings).
        /// This method is currently a placeholder.
        /// </remarks>
        public static void UpdateSystemCaptionButtonColors()
        {
        }
    }
}
