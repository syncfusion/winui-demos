#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
        public SettingsPage()
        {
            this.InitializeComponent();
            Loaded += SettingsPage_Loaded;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            mainViewModel = e?.Parameter as MainViewModel;
            base.OnNavigatedTo(e);
        }

        private void SettingsPage_Loaded(object sender, RoutedEventArgs e)
        {
            string currentTheme = ThemeHelper.RootTheme.ToString();
            (ThemePanel.Children.Cast<RadioButton>().FirstOrDefault(c => c.Tag.ToString() == currentTheme)).IsChecked = true;
        }

        private void OnThemeRadioButtonChecked(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            string selectedTheme = ((RadioButton)sender).Tag.ToString();

            if (!string.IsNullOrEmpty(selectedTheme))
            {
                Enum.TryParse(typeof(ElementTheme), selectedTheme, out object theme);
                ThemeHelper.RootTheme = mainViewModel.CurrentTheme = (ElementTheme)theme;
            }
        }  
    }
}
