
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.SliderDemos.WinUI.Views.RangeSlider
{
    using Microsoft.UI.Xaml.Controls;
    using System;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DividerCustomization : Page, IDisposable
    {
        public DividerCustomization()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Dispose all the allocated resources.
        /// </summary>
        public void Dispose()
        {
            if (this.dividerSizeRangeSlider != null)
            {
                this.dividerSizeRangeSlider.Dispose();
                this.dividerSizeRangeSlider = null;
            }

            if (this.dividerColorRangeSlider != null)
            {
                this.dividerColorRangeSlider.Dispose();
                this.dividerColorRangeSlider = null;
            }

            if (this.dividerTemplateRangeSlider != null)
            {
                this.dividerTemplateRangeSlider.Dispose();
                this.dividerTemplateRangeSlider = null;
            }

            if (this.activeDividerTemplateRangeSlider != null)
            {
                this.activeDividerTemplateRangeSlider.Dispose();
                this.activeDividerTemplateRangeSlider = null;
            }
        }
    }
}