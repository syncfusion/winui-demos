
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.SliderDemos.WinUI.Views.RangeSlider
{
    using Microsoft.UI.Xaml.Controls;
    using System;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TickCustomization : Page, IDisposable
    {
        public TickCustomization()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Dispose all the allocated resources.
        /// </summary>
        public void Dispose()
        {
            if (this.tickSizeRangeSlider != null)
            {
                this.tickSizeRangeSlider.Dispose();
                this.tickSizeRangeSlider = null;
            }

            if (this.tickStyleRangeSlider != null)
            {
                this.tickStyleRangeSlider.Dispose();
                this.tickStyleRangeSlider = null;
            }

            if (this.activeTickRangeSlider != null)
            {
                this.activeTickRangeSlider.Dispose();
                this.activeTickRangeSlider = null;
            }

            if (this.tickOffsetRangeSlider != null)
            {
                this.tickOffsetRangeSlider.Dispose();
                this.tickOffsetRangeSlider = null;
            }
        }
    }
}