
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.SliderDemos.WinUI.Views.RangeSlider
{
    using Microsoft.UI.Xaml.Controls;
    using System;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ThumbCustomization : Page, IDisposable
    {
        public ThumbCustomization()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Dispose all the allocated resources.
        /// </summary>
        public void Dispose()
        {
            if (this.thumbTypeRangeSlider != null)
            {
                this.thumbTypeRangeSlider.Dispose();
                this.thumbTypeRangeSlider = null;
            }

            if (this.textViewRangeSlider != null)
            {
                this.textViewRangeSlider.Dispose();
                this.textViewRangeSlider = null;
            }

            if (this.thumbColorRangeSlider != null)
            {
                this.thumbColorRangeSlider.Dispose();
                this.thumbColorRangeSlider = null;
            }
        }
    }
}
