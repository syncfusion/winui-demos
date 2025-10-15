#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
using Syncfusion.UI.Xaml.Ribbon;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.RibbonDemos.WinUI.Views.Ribbon
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ContextualTabGroupView : Page, IDisposable
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

        /// <summary>
        /// Cleares the instance.
        /// </summary>
        public void Dispose()
        {
            if (this.ribbon != null)
            {
                foreach (RibbonTab tab in this.ribbon.Tabs)
                {
                    foreach (RibbonGroup ribbonGroup in tab.Items)
                    {
                        if (ribbonGroup.ShowLauncherButton)
                        {
                            ribbonGroup.LauncherButtonClick -= RibbonGroup_LauncherButtonClick;
                        }
                    }
                }

                this.ribbon.Dispose();
                this.ribbon = null;
            }
            this.DataContext = null;
        }
    }
}