
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.SliderDemos.WinUI.Views.RangeSlider
{
    using Microsoft.UI.Xaml.Controls;
    using System;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TrackCustomization : Page, IDisposable
    {
        public TrackCustomization()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Dispose all the allocated resources.
        /// </summary>
        public void Dispose()
        {
            if (this.trackSizeRangeSlider != null)
            {
                this.trackSizeRangeSlider.Dispose();
                this.trackSizeRangeSlider = null;
            }

            if (this.trackColorRangeSlider != null)
            {
                this.trackColorRangeSlider.Dispose();
                this.trackColorRangeSlider = null;
            }

            if (this.trackStyleRangeSlider != null)
            {
                this.trackStyleRangeSlider.Dispose();
                this.trackStyleRangeSlider = null;
            }
        }
    }
}