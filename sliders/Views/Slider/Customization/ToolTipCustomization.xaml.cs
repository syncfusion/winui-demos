
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.SliderDemos.WinUI.Views.Slider
{
    using Microsoft.UI.Xaml.Controls;
    using System;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ToolTipCustomization : Page, IDisposable
    {
        public ToolTipCustomization()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Dispose all the allocated resources.
        /// </summary>
        public void Dispose()
        {
            if (this.basicCustomizationSlider != null)
            {
                this.basicCustomizationSlider.Dispose();
                this.basicCustomizationSlider = null;
            }

            if (this.styleCustomizationSlider != null)
            {
                this.styleCustomizationSlider.Dispose();
                this.styleCustomizationSlider = null;
            }

            if (this.templateCustomizationSlider != null)
            {
                this.templateCustomizationSlider.Dispose();
                this.templateCustomizationSlider = null;
            }
        }
    }
}