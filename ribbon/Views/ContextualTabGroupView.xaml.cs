#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.RibbonDemos.WinUI.Views.Ribbon
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ContextualTabGroupView : Page
    {
        public ContextualTabGroupView()
        {
            this.InitializeComponent();
        }

        private async void RibbonGroup_LauncherButtonClick(Syncfusion.UI.Xaml.Ribbon.RibbonGroup sender, object args)
        {
            ContentDialog contentDialog1 = new ContentDialog();
            contentDialog1.XamlRoot = ribbon.XamlRoot;
            contentDialog1.Title = "Launcher clicked";
            contentDialog1.PrimaryButtonText = "Close";
            await contentDialog1.ShowAsync();
        }

        private void ContentGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.ImageButton.IsChecked = false;
            this.ImageOptions.Visibility = Visibility.Collapsed;
            this.TableOptions.Visibility = Visibility.Visible;
            this.ContentGridView.BorderBrush = (SolidColorBrush)this.Resources["TextBoxBorderThemeBrush"];
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            this.TableOptions.Visibility = Visibility.Collapsed;
            this.ImageButton.IsChecked = true;
            this.ImageOptions.Visibility = Visibility.Visible;
            this.ContentGridView.BorderBrush = (SolidColorBrush)this.Resources["TextBoxDisabledBorderThemeBrush"];
        }

        private void Grid_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            this.ImageButton.IsChecked = false;
            this.ImageOptions.Visibility = Visibility.Collapsed;
            this.TableOptions.Visibility = Visibility.Collapsed;
            this.ContentGridView.BorderBrush = (SolidColorBrush)this.Resources["TextBoxDisabledBorderThemeBrush"];
        }
    }
}