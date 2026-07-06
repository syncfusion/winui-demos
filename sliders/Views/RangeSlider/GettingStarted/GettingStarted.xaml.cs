
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.SliderDemos.WinUI.Views.RangeSlider
{
    using Microsoft.UI.Xaml.Controls;
    using System;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GettingStarted : Page, IDisposable
    {
        public GettingStarted()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Dispose all the allocated resources.
        /// </summary>
        public void Dispose()
        {
            if (this.scaleRangeSlider != null)
            {
                this.scaleRangeSlider.Dispose();
                this.scaleRangeSlider = null;
            }

            if (this.frequencySlider != null)
            {
                this.frequencySlider.Dispose();
                this.frequencySlider = null;
            }

            if (this.rangeDragRangeSlider != null)
            {
                this.rangeDragRangeSlider.Dispose();
                this.rangeDragRangeSlider = null;
            }

            if (this.dividerRangeSlider != null)
            {
                this.dividerRangeSlider.Dispose();
                this.dividerRangeSlider = null;
            }

            if (this.simpleRangeSlider != null)
            {
                this.simpleRangeSlider.Dispose();
                this.simpleRangeSlider = null;
            } 
        }
    }
}