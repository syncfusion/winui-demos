#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Syncfusion.DemosCommon.WinUI
{
    public sealed partial class TileGallery : Page
    {
        public TileGallery()
        {
            this.InitializeComponent();
        }

        public string DocsLink => UIStringsProvider.DocsLink;
        public string DocsDesc => UIStringsProvider.DocsDesc;
        public string GitHubLink => UIStringsProvider.GitHubLink;
        public string GitHubDesc => UIStringsProvider.GitHubDesc;
        public string FeatureLink => UIStringsProvider.FeatureLink;
        public string FeatureDesc => UIStringsProvider.FeatureDesc;

        private void OnScrollerViewChanging(object sender, ScrollViewerViewChangingEventArgs e)
        {
            if (e.FinalView.HorizontalOffset < 1)
            {
                ScrollBackButton.Visibility = Visibility.Collapsed;
            }
            else if (e.FinalView.HorizontalOffset > 1)
            {
                ScrollBackButton.Visibility = Visibility.Visible;
            }

            if (e.FinalView.HorizontalOffset > Scroller.ScrollableWidth - 1)
            {
                ScrollForwardButton.Visibility = Visibility.Collapsed;
            }
            else if (e.FinalView.HorizontalOffset < Scroller.ScrollableWidth - 1)
            {
                ScrollForwardButton.Visibility = Visibility.Visible;
            }
        }

        private void OnScrollBackButtonClick(object sender, RoutedEventArgs e)
        {
            Scroller.ChangeView(Scroller.HorizontalOffset - Scroller.ViewportWidth, null, null);
        }

        private void OnScrollForwardButtonClick(object sender, RoutedEventArgs e)
        {
            Scroller.ChangeView(Scroller.HorizontalOffset + Scroller.ViewportWidth, null, null);
        }

        private void OnScrollerSizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateScrollButtonsVisibility();
        }

        private void UpdateScrollButtonsVisibility()
        {
            if (Scroller.ScrollableWidth > 0)
            {
                ScrollForwardButton.Visibility = Visibility.Visible;
            }
            else
            {
                ScrollForwardButton.Visibility = Visibility.Collapsed;
            }
        }
    }

}
