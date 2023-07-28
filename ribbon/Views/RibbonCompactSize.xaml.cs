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
    public sealed partial class RibbonCompactSize : Page, IDisposable
    {
        public RibbonCompactSize()
        {
            this.InitializeComponent();
        }
        private async void RibbonGroup_LauncherButtonClick(RibbonGroup sender, object args)
        {
            ContentDialog contentDialog1 = new ContentDialog();
            contentDialog1.XamlRoot = ribbonCompactSize.XamlRoot;
            contentDialog1.Title = "Launcher clicked";
            contentDialog1.PrimaryButtonText = "Close";
            await contentDialog1.ShowAsync();
        }

        /// <summary>
        /// Cleares the instance.
        /// </summary>
        public void Dispose()
        {
            if (this.ribbonCompactSize != null)
            {
                for (int i = 0; i < ribbonCompactSize.Tabs.Count; i++)
                {
                    for (int j = 0; j < ribbonCompactSize.Tabs[i].Items.Count; j++)
                    {
                        if (ribbonCompactSize.Tabs[i].Items[j] is RibbonGroup ribbonGroup)
                        {
                            if (ribbonGroup.ShowLauncherButton)
                            {
                                ribbonGroup.LauncherButtonClick -= RibbonGroup_LauncherButtonClick;
                            }
                        }
                    }
                }
                this.ribbonCompactSize = null;
            }
            this.DataContext = null;
        }
    }
}
