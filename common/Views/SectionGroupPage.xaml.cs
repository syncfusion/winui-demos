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
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Navigation;

namespace Syncfusion.DemosCommon.WinUI
{
    /// <summary>
    /// A section group page to display demos or control list by grouping
    /// </summary>
    public sealed partial class SectionGroupPage : Page
    {
        public SectionGroupPage()
        {
            this.InitializeComponent();
        }


        MainViewModel mainViewModel;

        private Grid grid = null;

        private RelativePanel relativePanel = null;

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
            else
            {
                var collectionView = new CollectionViewSource();
                collectionView.IsSourceGrouped = true;
                collectionView.Source = from tileInfo in DemoHelper.ControlInfos group tileInfo by tileInfo.Category;
                this.itemGridView.ItemTemplate = this.Resources["AllControlsTileTemplate"] as DataTemplate;
                this.itemGridView.ItemsSource = collectionView.View;
            }
            this.itemGridView.ItemClick += ItemGridView_ItemClick;
        }

        private void ItemGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is DemoInfo demoInfo)
                this.mainViewModel.OnTileSelected(demoInfo);
            else if (e.ClickedItem is ControlInfo controlInfo)
                this.mainViewModel.OnTileSelected(controlInfo);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.itemGridView.ItemClick -= ItemGridView_ItemClick;
            this.mainViewModel = null;
            base.OnNavigatedFrom(e);
        }
    }
}
