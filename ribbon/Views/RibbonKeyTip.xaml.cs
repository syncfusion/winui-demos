#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.Ribbon;
using System;

namespace Syncfusion.RibbonDemos.WinUI.Views.Ribbon
{
    public sealed partial class RibbonKeyTip : Page, IDisposable
    {
        public RibbonKeyTip()
        {
            this.InitializeComponent();
        }

        private async void RibbonGroup_LauncherButtonClick(RibbonGroup sender, object args)
        {
            ContentDialog contentDialog1 = new ContentDialog();
            contentDialog1.XamlRoot = ribbon.XamlRoot;
            contentDialog1.Title = "Launcher activated.";
            contentDialog1.PrimaryButtonText = "Close";
            await contentDialog1.ShowAsync();
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
            if (this.ribbonGallery != null)
            {
                this.ribbonGallery = null;
            }

            if (this.ribbon != null)
            {
                for (int i = 0; i < ribbon.Tabs.Count; i++)
                {
                    for (int j = 0; j < ribbon.Tabs[i].Items.Count; j++)
                    {
                        if (ribbon.Tabs[i].Items[j] is RibbonGroup ribbonGroup)
                        {
                            if (ribbonGroup.ShowLauncherButton)
                            {
                                ribbonGroup.LauncherButtonClick -= RibbonGroup_LauncherButtonClick;
                            }
                        }
                    }
                }
                this.ribbon = null;
                this.DataContext = null;
            }
        }
    }
}
