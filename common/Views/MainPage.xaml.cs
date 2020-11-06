#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace syncfusion.demoscommon.winui
{
    public sealed partial class MainPage : Page
    {
        public NavigationView NavigationView
        {
            get { return NavigationViewControl; }
        }

        public MainPage()
        {
            this.InitializeComponent();
            NavigationService.Frame = MainFrame;
            this.DataContext = new MainViewModel();
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
    }
}
