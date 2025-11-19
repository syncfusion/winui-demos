#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Linq;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace Syncfusion.DemosCommon.WinUI
{
    /// <summary>
    /// A section page to display demo list under showcase and what's new.
    /// </summary>
    public sealed partial class SectionPage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SectionPage"/> class.
        /// Calls <see cref="InitializeComponent"/> to load the XAML for the page.
        /// </summary>
        public SectionPage()
        {
            this.InitializeComponent();
        }

        MainViewModel mainViewModel;

        /// <summary>
        /// Called when the page is navigated to.
        /// Sets up the ViewModel and populates the `itemGridView` with demo items based on the selected root menu item (e.g., Showcase, What's New).
        /// </summary>
        /// <param name="e">Navigation event arguments containing the ViewModel.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            mainViewModel = e?.Parameter as MainViewModel;
            if (mainViewModel == null)
                return;

            if (mainViewModel.SelectedRootMenuItem is BrowserModel model)
            {
                if (model.Content.ToString() == Constants.Showcase)
                {
                    this.itemGridView.ItemsSource = DemoHelper.ShowCaseDemos.ToList();
                }
               
                itemGridView.ItemClick += ItemGridView_ItemClick;
            }
        }

        /// <summary>
        /// Handles the ItemClick event for the `itemGridView`.
        /// When a demo item is clicked, it invokes the `OnTileSelected` method in the ViewModel.
        /// </summary>
        /// <param name="sender">The GridView that raised the event.</param>
        /// <param name="e">Item click event arguments containing the clicked item.</param>
        private void ItemGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is DemoInfo demoInfo)
                mainViewModel.OnTileSelected(demoInfo);
        }

        /// <summary>
        /// Called when the page is navigated away from.
        /// This method performs cleanup by removing event handlers and nullifying references to prevent memory leaks.
        /// </summary>
        /// <param name="e">Navigation event arguments.</param>
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            itemGridView.ItemClick -= ItemGridView_ItemClick;
            mainViewModel = null;
            base.OnNavigatedFrom(e);
        }
    }
}
