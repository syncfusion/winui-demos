
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.SliderDemos.WinUI.Views.Slider
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
            if (this.trackSizeSlider != null)
            {
                this.trackSizeSlider.Dispose();
                this.trackSizeSlider = null;
            }

            if (this.trackColorSlider != null)
            {
                this.trackColorSlider.Dispose();
                this.trackColorSlider = null;
            }

            if (this.trackStyleSlider != null)
            {
                this.trackStyleSlider.Dispose();
                this.trackStyleSlider = null;
            }
        }
    }
}