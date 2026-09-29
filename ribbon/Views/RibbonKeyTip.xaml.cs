using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.Ribbon;
using System;

namespace Syncfusion.RibbonDemos.WinUI.Views.Ribbon
{
    /// <summary>
    /// Represents a page that demonstrates the functionality and usage of KeyTips within the Syncfusion Ribbon control.
    /// KeyTips provide keyboard shortcuts for accessing ribbon elements.
    /// This class implements <see cref="IDisposable"/> to ensure proper cleanup of resources when the page is no longer needed.
    /// </summary>
    public sealed partial class RibbonKeyTip : Page, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RibbonKeyTip"/> class.
        /// </summary>
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
