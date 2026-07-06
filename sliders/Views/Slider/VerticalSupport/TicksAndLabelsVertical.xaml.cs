
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.SliderDemos.WinUI.Views.Slider
{
    using Microsoft.UI.Xaml.Controls;
    using System;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TicksAndLabelsVertical : Page, IDisposable
    {
        public TicksAndLabelsVertical()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Dispose all the allocated resources.
        /// </summary>
        public void Dispose()
        {
            if (this.scaleSlider != null)
            {
                this.scaleSlider.Dispose();
                this.scaleSlider = null;
            }
        }
    }
}