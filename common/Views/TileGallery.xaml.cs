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
    /// <summary>
    /// Represents a gallery page that displays items (like controls or demos) in a tiled or card-like format.
    /// It includes navigation buttons for horizontally scrolling through the items and provides access to UI strings for documentation and feature links.
    /// </summary>
    public sealed partial class TileGallery : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TileGallery"/> class.
        /// </summary>
        public TileGallery()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets the general documentation link for Syncfusion WinUI controls from `UIStringsProvider`.
        /// </summary>
        public string DocsLink => UIStringsProvider.DocsLink;
        /// <summary>
        /// Gets the description for the documentation link from `UIStringsProvider`.
        /// </summary>
        public string DocsDesc => UIStringsProvider.DocsDesc;
        /// <summary>
        /// Gets the link to the Syncfusion WinUI demos GitHub repository from `UIStringsProvider`.
        /// </summary>
        public string GitHubLink => UIStringsProvider.GitHubLink;
        /// <summary>
        /// Gets the description for the GitHub link from `UIStringsProvider`.
        /// </summary>
        public string GitHubDesc => UIStringsProvider.GitHubDesc;
        /// <summary>
        /// Gets the link to the Syncfusion WinUI controls product page from `UIStringsProvider`.
        /// </summary>
        public string FeatureLink => UIStringsProvider.FeatureLink;
        /// <summary>
        /// Gets the description for the feature link from `UIStringsProvider`.
        /// </summary>
        public string FeatureDesc => UIStringsProvider.FeatureDesc;

        /// <summary>
        /// Event handler for when the scroll view's view is changing (e.g., during user scrolling).
        /// Updates the visibility of the scroll back and forward buttons based on the scroll position.
        /// </summary>
        /// <param name="sender">The ScrollViewer that triggered the event.</param>
        /// <param name="e">Scroll view changing event arguments containing the final view state.</param>
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

        /// <summary>
        /// Event handler for the Scroll Back button click.
        /// Scrolls the content horizontally to the left by the width of the viewport.
        /// </summary>
        /// <param name="sender">The ScrollBackButton element.</param>
        /// <param name="e">Routed event arguments.</param>
        private void OnScrollBackButtonClick(object sender, RoutedEventArgs e)
        {
            Scroller.ChangeView(Scroller.HorizontalOffset - Scroller.ViewportWidth, null, null);
        }

        /// <summary>
        /// Event handler for the Scroll Forward button click.
        /// Scrolls the content horizontally to the right by the width of the viewport.
        /// </summary>
        /// <param name="sender">The ScrollForwardButton element.</param>
        /// <param name="e">Routed event arguments.</param>
        private void OnScrollForwardButtonClick(object sender, RoutedEventArgs e)
        {
            Scroller.ChangeView(Scroller.HorizontalOffset + Scroller.ViewportWidth, null, null);
        }

        /// <summary>
        /// Event handler for the SizeChanged event of the ScrollViewer.
        /// Updates the visibility of scroll buttons when the size of the scrollable area changes.
        /// </summary>
        /// <param name="sender">The ScrollViewer element.</param>
        /// <param name="e">Size changed event arguments.</param>
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
