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
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Documents;

namespace Syncfusion.DemosCommon.WinUI
{
    /// <summary>
    /// A section group page to display demos or control list by grouping
    /// </summary>
    public sealed partial class SectionGroupPage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SectionGroupPage"/> class.
        /// Calls <see cref="InitializeComponent"/> to load the XAML UI definitions.
        /// </summary>
        public SectionGroupPage()
        {
            this.InitializeComponent();
        }


        MainViewModel mainViewModel;

        /// <summary>
        /// Called when the page is navigated to.
        /// It receives the ViewModel, determines the type of data to display (demos, new/updated, AI demos, or all controls),
        /// and configures the `itemGridView` accordingly, including setting the `ItemsSource` and `ItemTemplate`.
        /// </summary>
        /// <param name="e">Navigation event arguments containing the ViewModel.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            mainViewModel = e?.Parameter as MainViewModel;
            if (mainViewModel == null)
                return;

            if (mainViewModel.SelectedItem != null)
            {
                var contorlInfo = mainViewModel.SelectedItem as ControlInfo;

                var collectionView = new CollectionViewSource();
                collectionView.IsSourceGrouped = true;
                collectionView.Source = from tileInfo in contorlInfo.Demos group tileInfo by tileInfo.Category;
                this.itemGridView.ItemTemplate = this.Resources["DemoTileTemplate"] as DataTemplate;
                this.itemGridView.ItemsSource = collectionView.View;
            }
            else if (mainViewModel.SelectedRootMenuItem is BrowserModel model && model.Content.ToString() == Constants.WhatsNew)
            {
                var collectionView = new CollectionViewSource();
                collectionView.IsSourceGrouped = true;
                var whatsNewControls = DemoHelper.WhatsNewDemos.Where(controlInfo => controlInfo.DemoType == DemoTypes.New || controlInfo.DemoType == DemoTypes.Updated);
                collectionView.Source = from tileInfo in whatsNewControls group tileInfo by tileInfo.DemoType;
                this.itemGridView.ItemTemplate = this.Resources["WhatsNewTileTemplate"] as DataTemplate;
                this.itemGridView.ItemsSource = collectionView.View;
            }
            else if (mainViewModel.SelectedRootMenuItem is BrowserModel models && models.Content.ToString() == Constants.AIDemos)
            {
                var collectionView = new CollectionViewSource();
                collectionView.IsSourceGrouped = true;
                var AIControls = DemoHelper.AIDemos.Where(controlInfo => (controlInfo.DemoType & (DemoTypes.New | DemoTypes.AISamples)) == (DemoTypes.New | DemoTypes.AISamples) ||
                                                 (controlInfo.DemoType & (DemoTypes.Updated | DemoTypes.AISamples)) == (DemoTypes.Updated | DemoTypes.AISamples) ||
                                                 (controlInfo.DemoType & (DemoTypes.None | DemoTypes.AISamples)) == (DemoTypes.None | DemoTypes.AISamples));
                collectionView.Source = from tileInfo in AIControls group tileInfo by tileInfo.DemoType;
                this.itemGridView.ItemTemplate = this.Resources["DemoTileTemplate"] as DataTemplate;
                this.itemGridView.ItemsSource = collectionView.View;
            }
            else
            {
                var collectionView = new CollectionViewSource();
                collectionView.IsSourceGrouped = true;
                collectionView.Source = from tileInfo in DemoHelper.ControlInfos group tileInfo by tileInfo.Category;
                this.itemGridView.ItemTemplate = this.Resources["AllControlsTileTemplate"] as DataTemplate;
                this.itemGridView.ItemsSource = collectionView.View;
            }
            this.itemGridView.ItemClick += ItemGridView_ItemClick;
            this.itemGridView.Loaded += OnItemGridViewLoaded;
        }

        /// <summary>
        /// Handles the Loaded event for the `itemGridView`.
        /// Specifically targets the AI Demos section to make the "AI Setup"TextBlock visible.
        /// </summary>
        /// <param name="sender">The itemGridView.</param>
        /// <param name="e">Routed event arguments.</param>
        private void OnItemGridViewLoaded(object sender, RoutedEventArgs e)
        {
            if (mainViewModel.SelectedRootMenuItem is BrowserModel models && models.Content.ToString() == Constants.AIDemos)
            {
                var aiSetUpTextBlock = FindVisualChildByName<StackPanel>(itemGridView, "AISetUp");
                if (aiSetUpTextBlock != null)
                {
                    aiSetUpTextBlock.Visibility = Visibility.Visible;
                }
            }
        }

        /// <summary>
        /// Handles the ItemClick event for the `itemGridView`.
        /// Navigates to the selected demo or control via the ViewModel.
        /// </summary>
        /// <param name="sender">The itemGridView.</param>
        /// <param name="e">Item click event arguments.</param>
        private void ItemGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is DemoInfo demoInfo)
                this.mainViewModel.OnTileSelected(demoInfo);
            else if (e.ClickedItem is ControlInfo controlInfo)
                this.mainViewModel.OnTileSelected(controlInfo);
        }

        /// <summary>
        /// Called when navigating away from the page.
        /// Cleans up event handlers and releases the ViewModel reference.
        /// </summary>
        /// <param name="e">Navigation event arguments.</param>
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.itemGridView.ItemClick -= ItemGridView_ItemClick;
            this.itemGridView.Loaded -= OnItemGridViewLoaded;
            this.mainViewModel = null;
            base.OnNavigatedFrom(e);
        }

        private async void OnSetupAIButtonClick(Hyperlink sender, HyperlinkClickEventArgs args)
        {
            await AISettings.ShowAISettingsWindow();
        }

        /// <summary>
        /// Helper method to find a visual child element by its type and name within a visual tree.
        /// </summary>
        /// <typeparam name="T">The type of the dependency object to find.</typeparam>
        /// <param name="parent">The parent element to search within.</param>
        /// <param name="name">The name of the element to find.</param>
        /// <returns>The found element of type T, or null if not found.</returns>
        private T FindVisualChildByName<T>(DependencyObject parent, string name) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is FrameworkElement fe && fe.Name == name)
                {
                    return (T)child;
                }
                var result = FindVisualChildByName<T>(child, name);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }
    }
}
