#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using Syncfusion.UI.Xaml.Editors;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Windows.System;

namespace Syncfusion.DemosCommon.WinUI
{
    public sealed partial class MainPage : Page
    {
        MainViewModel viewModel; 

        public NavigationView NavigationView
        {
            get { return NavigationViewControl; }
        }

        public MainPage()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("");
            this.InitializeComponent();
            NavigationService.Frame = MainFrame;
            this.DataContext = new MainViewModel();
            this.viewModel = DataContext as MainViewModel;
            Enum.TryParse(typeof(ElementTheme), Application.Current.RequestedTheme.ToString(), out object theme);
            viewModel.CurrentTheme = (ElementTheme)theme;
        }

#pragma warning disable CA1801 // TypedEventHandler object parameter.
        private void NavigationViewControl_PaneClosing(NavigationView sender, NavigationViewPaneClosingEventArgs args)
        {
            UpdateAppTitleMargin(sender);
            SfAutoCompleteSearchBox.Visibility = Visibility.Collapsed;
            searchButton.Visibility = Visibility.Visible;
        }

        private void NavigationViewControl_PaneOpened(NavigationView sender, object args)
        {
            UpdateAppTitleMargin(sender);
            SfAutoCompleteSearchBox.Visibility = Visibility.Visible;
            searchButton.Visibility = Visibility.Collapsed;
        }

        private void NavigationViewControl_DisplayModeChanged(NavigationView sender, NavigationViewDisplayModeChangedEventArgs args)
        {
            UpdateAppTitleMargin(sender);
        }

#pragma warning restore CA1801 // TypedEventHandler object parameter.

        private void UpdateAppTitleMargin(NavigationView sender)
        {
            const int smallLeftIndent = 0, largeLeftIndent = 34;

            AppTitle.TranslationTransition = new Vector3Transition();

            if (sender.IsPaneOpen == false && (sender.DisplayMode == NavigationViewDisplayMode.Expanded ||
                sender.DisplayMode == NavigationViewDisplayMode.Compact))
            {
                AppTitle.Translation = new System.Numerics.Vector3(largeLeftIndent, 0, 0);
            }
            else
            {
                AppTitle.Translation = new System.Numerics.Vector3(smallLeftIndent, 0, 0);
            }
        }

        private void SfAutoCompleteSelectionChanged(object sender, AutoCompleteSelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0 && e.AddedItems[0] is DemoInfo)
            {
                var searchValue = e.AddedItems[0] as DemoInfo;
                if (searchValue.SearchItem.Equals("No results found"))
                {
                    SfAutoCompleteSearchBox.Text = null;
                    return;
                }
            }
            else if (e.AddedItems.Count > 0)
            {
                if (!string.IsNullOrEmpty((string)e.AddedItems[0]))
                {
                    var suggestions = MainViewModel.SearchDemos((string)e.AddedItems[0]);
                    if (suggestions.Count > 0)
                    {
                        this.viewModel.SelectDemo(suggestions.FirstOrDefault());
                        SfAutoCompleteSearchBox.Text = null;
                        return;
                    }
                }
            }
            SfAutoComplete sfAuto = sender as SfAutoComplete;
            this.viewModel.SelectDemo(sfAuto.SelectedItem as DemoInfo);
            SfAutoCompleteSearchBox.Text = null;
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationViewControl.IsPaneOpen = true;
            SfAutoCompleteSearchBox.Focus(FocusState.Keyboard);
        }

        private void OnThemeButtonClick(object sender, RoutedEventArgs e)
        {
            var newTheme = viewModel.CurrentTheme == ElementTheme.Dark ? ElementTheme.Light : ElementTheme.Dark;
            viewModel.CurrentTheme = newTheme;
        } 
    }
}
