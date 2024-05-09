#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ScreenTip : Page, IDisposable
    {
        public ScreenTip()
        {
            this.InitializeComponent();
        }
        private async void RibbonGroup_LauncherButtonClick(RibbonGroup sender, object args)
        {
            ContentDialog contentDialog1 = new ContentDialog();
            contentDialog1.XamlRoot = ribbon.XamlRoot;
            contentDialog1.Title = "Launcher clicked";
            contentDialog1.PrimaryButtonText = "Close";
            await contentDialog1.ShowAsync();
        }

        /// <summary>
        /// Clear the instances.
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
                this.DataContext = null;
            }
        }
    }
}
