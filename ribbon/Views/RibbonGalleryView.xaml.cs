#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Text;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.Ribbon;
using System;
using Windows.UI.Text;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace syncfusion.ribbondemos.winui.Views.Ribbon
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RibbonGalleryView : Page, IDisposable
    {

        public RibbonGalleryView()
        {
            this.InitializeComponent();
        }

        private void OnItemPointerEnter(object sender, RibbonRoutedEventArgs e)
        {
            RibbonGalleryItem selecteditem = (e.Source) as RibbonGalleryItem;
            if (selecteditem != null)
            {
                viewModel.FontSize = selecteditem.FontSize;
                viewModel.FontWeight = selecteditem.FontWeight;
            }
        }

        private void OnItemPointerExit(object sender, RibbonRoutedEventArgs e)
        {
            RibbonGalleryItem selecteditem = (RibbonGalleryItem)(sender as RibbonGallery).SelectedItem;
            if (selecteditem != null)
            {
               viewModel.FontSize = selecteditem.FontSize;
               viewModel.FontWeight = selecteditem.FontWeight;
            }
        }

        /// <summary>
        /// Clear the instances.
        /// </summary>
        public void Dispose()
        {
            if (this.DataContext is ViewModel viewModel)
            {
                viewModel.FontStyles.Clear();
                viewModel.FontStyles = null;
            }
            this.DataContext = null;
            this.RibbonGalleryItemTemplate = null;
            if (this.ribbonGallery != null)
            {
                this.ribbonGallery = null;
            }
        }

    }
}
