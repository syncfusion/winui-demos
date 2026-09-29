using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.Ribbon;
using System;

namespace Syncfusion.RibbonDemos.WinUI.Views.Ribbon
{
    /// <summary>
    /// Represents a page that demonstrates the behavior and appearance of the Syncfusion Ribbon control in compact mode.
    /// This class implements <see cref="IDisposable"/> to ensure proper cleanup of resources when the page is no longer needed.
    /// </summary>
    public sealed partial class RibbonCompactSize : Page, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RibbonCompactSize"/> class.
        /// </summary>
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
                foreach (RibbonTab tab in this.ribbonCompactSize.Tabs)
                {
                    foreach (RibbonGroup ribbonGroup in tab.Items)
                    {
                        if (ribbonGroup.ShowLauncherButton)
                        {
                            ribbonGroup.LauncherButtonClick -= RibbonGroup_LauncherButtonClick;
                        }
                    }
                }

                this.ribbonCompactSize.Dispose();
                this.ribbonCompactSize = null;
            }
            this.DataContext = null;
        }
    }
}
