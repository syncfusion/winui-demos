#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Linq;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using Windows.Media.Playback;

namespace syncfusion.demoscommon.winui
{
    /// <summary>
    /// A section page to display demo list under showcase and what's new.
    /// </summary>
    public sealed partial class SectionPage : Page
    {
        public SectionPage()
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

            if (mainViewModel.SelectedRootMenuItem is BrowserModel model)
            {
                if (model.Content.ToString() == Constants.Showcase)
                {
                    this.itemGridView.ItemsSource = DemoHelper.ShowCaseDemos.ToList();
                }
               
                itemGridView.ItemClick += ItemGridView_ItemClick;
            }
        }

        private void ItemGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is DemoInfo demoInfo)
                mainViewModel.OnTileSelected(demoInfo);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            itemGridView.ItemClick -= ItemGridView_ItemClick;
            mainViewModel = null;
            base.OnNavigatedFrom(e);
        }
    }
}
