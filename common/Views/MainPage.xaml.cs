#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
using System.Collections;
using Syncfusion.UI.Xaml.Core;
using Microsoft.UI;

namespace Syncfusion.DemosCommon.WinUI
{
    public sealed partial class MainPage : Page
    {
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
            NavigationService.ViewModel = DataContext as MainViewModel;
            AISettings.MainViewModel = DataContext as MainViewModel;
            this.ValidateCrendentials();
            Enum.TryParse(typeof(ElementTheme), Application.Current.RequestedTheme.ToString(), out object theme);
            NavigationService.ViewModel.CurrentTheme = (ElementTheme)theme;
        }

        /// <summary>
        /// Helps to validate AI Credentials.
        /// </summary>
        private void ValidateCrendentials()
        {
            AISettings.MainViewModel.ModelName = AISettings.ModelName;
            AISettings.MainViewModel.Key = AISettings.Key;
            AISettings.MainViewModel.EndPoint = AISettings.EndPoint;
            Task.Run(AISettings.ValidateCredentials);
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
                        NavigationService.ViewModel.SelectDemo(suggestions.FirstOrDefault());
                        SfAutoCompleteSearchBox.Text = null;
                        return;
                    }
                }
            }
            SfAutoComplete sfAuto = sender as SfAutoComplete;
            NavigationService.ViewModel.SelectDemo(sfAuto.SelectedItem as DemoInfo);
            SfAutoCompleteSearchBox.Text = null;
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationViewControl.IsPaneOpen = true;
            SfAutoCompleteSearchBox.Focus(FocusState.Keyboard);
        }

        private void NavigationViewControl_Expanding(NavigationView sender, NavigationViewItemExpandingEventArgs args)
        {
            if (args.ExpandingItem != null && args.ExpandingItem is ControlInfo && (args.ExpandingItem as ControlInfo).IsExpanded)
            {
                ControlInfo controlInfo = args.ExpandingItem as ControlInfo;
                if (controlInfo.Visibility == Visibility.Collapsed)
                {
                    controlInfo.Visibility = Visibility.Visible;
                }

                bool canUpdateSelection = NavigationViewControl.SelectedItem != null && (args.ExpandingItem as ControlInfo).Demos.Contains((this.DataContext as MainViewModel).DemoInfo) ? false : true;
                NavigationViewControl.SelectedItem = canUpdateSelection ? (args.ExpandingItem as ControlInfo).Demos[0] : (this.DataContext as MainViewModel).DemoInfo;
                if (scrollViewer != null && NavigationViewControl.SelectedItem == (args.ExpandingItem as ControlInfo).Demos[0] && NavigationService.ViewModel.ScrollViewerVerticalOffset > 0)
                {
                    scrollViewer.UpdateLayout();
                    scrollViewer.ScrollToVerticalOffset(0);
                }
            }
        }

        private ScrollViewer scrollViewer { get; set; }

        private void NavigationViewControl_Collapsed(NavigationView sender, NavigationViewItemCollapsedEventArgs args)
        {
            if (scrollViewer != null && NavigationService.ViewModel.ScrollViewerVerticalOffset > 0)
            {
                scrollViewer.UpdateLayout();
                scrollViewer.ScrollToVerticalOffset(NavigationService.ViewModel.ScrollViewerVerticalOffset);
            }
            else if (args != null && args.CollapsedItemContainer != null && args.CollapsedItemContainer is NavigationViewItem navigationViewItem)
            {
                navigationViewItem.StartBringIntoView();
            }
        }

        private void NavigationViewControl_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args == null || (args.SelectedItem != null && args.SelectedItem is AllControlsButtonInfo))
            {
                return;
            }
            if (args != null && args.SelectedItemContainer != null && args.SelectedItemContainer is NavigationViewItem navigationViewItem)
            {
                if (navigationViewItem.MenuItemsSource == null || NavigationService.ViewModel.ScrollViewerVerticalOffset == 0)
                {
                    navigationViewItem.StartBringIntoView();
                }
                else if (navigationViewItem.MenuItemsSource != null && NavigationService.ViewModel.ScrollViewerVerticalOffset > 0)
                {
                    scrollViewer.UpdateLayout();
                    scrollViewer.ScrollToVerticalOffset(NavigationService.ViewModel.ScrollViewerVerticalOffset);
                }
            }
        }

        private void NavigationViewControl_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            scrollViewer = VisualTree.FindDescendantByName(NavigationView, "MenuItemsScrollViewer") as ScrollViewer;
            if (args.InvokedItemContainer is NavigationViewItem navigationViewItem && navigationViewItem.MenuItemsSource != null && !navigationViewItem.IsExpanded)
            {
                NavigationService.ViewModel.ScrollViewerVerticalOffset = scrollViewer.VerticalOffset;
            }
        }
    }
}
