#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Windows.System;

namespace syncfusion.demoscommon.winui
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
        }

        private void NavigationViewControl_PaneOpened(NavigationView sender, object args)
        {
            UpdateAppTitleMargin(sender);
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

        private void SearchTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var suggestions = MainViewModel.SearchDemos(sender.Text);
                if (suggestions.Count > 0)
                {
                    sender.ItemsSource = suggestions;
                    sender.ItemTemplate = this.Resources["SearchResultsItemTemplate"] as DataTemplate;
                }
                else
                {
                    sender.ItemsSource = new string[] { "No results found" };
                    sender.ItemTemplate = null;
                }
            }
        }

#pragma warning disable CA1801 // Review unused parameters
        private void SearchQuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null && args.ChosenSuggestion is DemoInfo)
            {
                this.viewModel.SelectDemo(args.ChosenSuggestion as DemoInfo);
            }
            else if (!string.IsNullOrEmpty(args.QueryText))
            {
                // Gets a collection of non-exact matches of the target item 
                var suggestions = MainViewModel.SearchDemos(args.QueryText);
                if (suggestions.Count > 0)
                {
                    // By default, select the first demo from the suggestions
                    this.viewModel.SelectDemo(suggestions.FirstOrDefault());
                }
            }
        }

        private void OnThemeButtonClick(object sender, RoutedEventArgs e)
        {
            var newTheme = viewModel.CurrentTheme == ElementTheme.Dark ? ElementTheme.Light : ElementTheme.Dark;
            viewModel.CurrentTheme = newTheme;
        } 
    }
}
