#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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

namespace Syncfusion.DemosCommon.WinUI
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

        private RelativePanel relativePanel = null;

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

        private void RelativePanel_PointerEntered(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            if (sender is RelativePanel)
            {
                relativePanel = sender as RelativePanel;
                relativePanel.Background = (Microsoft.UI.Xaml.Media.SolidColorBrush)this.Resources["SyncfusionControInfoHoverBackground"];
                relativePanel.BorderBrush = (Microsoft.UI.Xaml.Media.SolidColorBrush)this.Resources["SyncfusionControInfoHoverBorderBrush"];
            }
        }

        private void RelativePanel_PointerExited(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            if (sender is RelativePanel)
            {
                relativePanel = sender as RelativePanel;
                relativePanel.Background = (Microsoft.UI.Xaml.Media.SolidColorBrush)this.Resources["SyncfusionControlInfoBackground"];
                relativePanel.BorderBrush = (Microsoft.UI.Xaml.Media.SolidColorBrush)this.Resources["SyncfusionControlInfoBorderBrush"];
            }
        }

        private void RelativePanel_PointerPressed(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            if (sender is RelativePanel)
            {
                relativePanel = sender as RelativePanel;
                relativePanel.Background = (Microsoft.UI.Xaml.Media.SolidColorBrush)this.Resources["SyncfusionControInfoPressedBackground"];
                relativePanel.BorderBrush = (Microsoft.UI.Xaml.Media.SolidColorBrush)this.Resources["SyncfusionControlInfoBorderBrush"];
            }
        }
    }
}
