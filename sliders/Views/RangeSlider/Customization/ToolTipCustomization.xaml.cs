
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.SliderDemos.WinUI.Views.RangeSlider
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
            if (this.basicCustomizationRangeSlider != null)
            {
                this.basicCustomizationRangeSlider.Dispose();
                this.basicCustomizationRangeSlider = null;
            }

            if (this.styleCustomizationRangeSlider != null)
            {
                this.styleCustomizationRangeSlider.Dispose();
                this.styleCustomizationRangeSlider = null;
            }

            if (this.templateCustomizationRangeSlider != null)
            {
                this.templateCustomizationRangeSlider.Dispose();
                this.templateCustomizationRangeSlider = null;
            }
        }
    }
}