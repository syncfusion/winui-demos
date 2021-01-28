#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Linq;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Navigation;

namespace syncfusion.demoscommon.winui
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
                
                this.itemGridView.ItemsSource = collectionView.View;
            }
            else
            {
                var collectionView = new CollectionViewSource();
                collectionView.IsSourceGrouped = true;
                collectionView.Source = from tileInfo in DemoHelper.ControlInfos group tileInfo by tileInfo.Category; 
                this.itemGridView.ItemsSource = collectionView.View;
            }
            this.itemGridView.SelectionChanged += ItemGridView_SelectionChanged;
        }

        private void ItemGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.itemGridView.SelectedItem is DemoInfo demoInfo)
                this.mainViewModel.OnTileSelected(demoInfo);
            else if (this.itemGridView.SelectedItem is ControlInfo controlInfo)
                this.mainViewModel.OnTileSelected(controlInfo);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.itemGridView.SelectionChanged -= ItemGridView_SelectionChanged;
            this.mainViewModel = null;
            base.OnNavigatedFrom(e);
        }
    }
}
