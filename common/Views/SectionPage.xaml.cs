#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
                else if (model.Content.ToString() == Constants.WhatsNew)
                {
                    this.itemGridView.ItemsSource = DemoHelper.WhatsNewDemos.ToList();
                }
                this.itemGridView.Header = model.Content.ToString();
                itemGridView.SelectionChanged += ItemGridView_SelectionChanged;
            }
        }

        private void ItemGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.itemGridView.SelectedItem is DemoInfo demoInfo)
                mainViewModel.OnTileSelected(demoInfo);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            itemGridView.SelectionChanged -= ItemGridView_SelectionChanged;
            mainViewModel = null;
            base.OnNavigatedFrom(e);
        }
    }
}
