#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.Ribbon;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.RibbonDemos.WinUI.Views.Ribbon
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SimplifiedRibbonView : Page, IDisposable
    {
        public SimplifiedRibbonView()
        {
            this.InitializeComponent();
        }

        private async void RibbonGroup_LauncherButtonClick(RibbonGroup sender, object args)
        {
            ContentDialog contentDialog1 = new ContentDialog();
            contentDialog1.XamlRoot = simplifiedRibbon.XamlRoot;
            contentDialog1.Title = "Launcher clicked";
            contentDialog1.PrimaryButtonText = "Close";
            await contentDialog1.ShowAsync();
        }

        /// <summary>
        /// Cleares the instance.
        /// </summary>
        public void Dispose()
        {
            if (this.simplifiedRibbon != null)
            {
                for (int i = 0; i < simplifiedRibbon.Tabs.Count; i++)
                {
                    for (int j = 0; j < simplifiedRibbon.Tabs[i].Items.Count; j++)
                    {
                        if(simplifiedRibbon.Tabs[i].Items[j] is RibbonGroup ribbonGroup)
                        {
                            if(ribbonGroup.ShowLauncherButton)
                            {
                                ribbonGroup.LauncherButtonClick -= RibbonGroup_LauncherButtonClick;
                            }
                        }
                    }
                }
                this.simplifiedRibbon = null;
            }
            this.DataContext = null;
        }
    }
}
