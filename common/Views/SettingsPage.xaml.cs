#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Linq;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using Windows.Media.Playback;

namespace Syncfusion.DemosCommon.WinUI
{
    /// <summary>
    /// A section page to display demo list under showcase and what's new.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        MainViewModel mainViewModel;

        /// <summary>
        /// Gets the link to the UWPSamples repository from UIStringsProvider.
        /// </summary>
        public string UWPSamplesLink => UIStringsProvider.UWPSamplesLink;
        /// <summary>
        /// Gets the link to the API documentation from UIStringsProvider.
        /// </summary>
        public string UwpApiDocsLink => UIStringsProvider.UwpApiDocsLink;
        /// <summary>
        /// Gets the link to the User Guide from UIStringsProvider.
        /// </summary>
        public string UWPUserGuideLink => UIStringsProvider.UWPUserGuideLink;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsPage"/> class.
        /// Calls <see cref="InitializeComponent"/> to load the XAML UI definitions and sets up the event handler for the Loaded event.
        /// </summary>
        public SettingsPage()
        {
            this.InitializeComponent();
            Loaded += SettingsPage_Loaded;
        }

        /// <summary>
        /// Called when the page is navigated to.
        /// Receives the ViewModel instance from the navigation parameters.
        /// </summary>
        /// <param name="e">Navigation event arguments containing the ViewModel.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            mainViewModel = e?.Parameter as MainViewModel;
            base.OnNavigatedTo(e);
        }

        /// <summary>
        /// Handler for the Loaded event of the SettingsPage.
        /// Sets the initial theme selection in the ComboBox based on the current theme settings.
        /// </summary>
        /// <param name="sender">The sender object (SettingsPage).</param>
        /// <param name="e">Routed event arguments.</param>
        private void SettingsPage_Loaded(object sender, RoutedEventArgs e)
        {
            string currentTheme = ThemeHelper.RootTheme.ToString();
            ThemePanel.SelectedItem = ThemePanel.Items.Cast<ComboBoxItem>().FirstOrDefault(c => c.Tag.ToString() == currentTheme);
        }

        /// <summary>
        /// Handles the SelectionChanged event for the theme selection ComboBox.
        /// Updates the application's root theme based on the user's selection.
        /// </summary>
        /// <param name="sender">The ComboBox control that triggered the event.</param>
        /// <param name="e">Selection changed event arguments.</param>
        private void ThemeModeContainer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;    
            string selectedTheme = ((ComboBoxItem)comboBox.SelectedItem).Tag.ToString();

            if (!string.IsNullOrEmpty(selectedTheme))
            {
                Enum.TryParse(typeof(ElementTheme), selectedTheme, out object theme);
                ThemeHelper.RootTheme = mainViewModel.CurrentTheme = (ElementTheme)theme;
            }
        }
    }
}
