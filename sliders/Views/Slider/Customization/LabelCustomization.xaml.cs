
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.SliderDemos.WinUI.Views.Slider
{
    using Microsoft.UI.Xaml.Controls;
    using System;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LabelCustomization : Page, IDisposable
    {
        public LabelCustomization()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Dispose all the allocated resources.
        /// </summary>
        public void Dispose()
        {
            if (this.labelCustomizationSlider != null)
            {
                this.labelCustomizationSlider.Dispose();
                this.labelCustomizationSlider = null;
            }

            if (this.labelTemplateSlider != null)
            {
                this.labelTemplateSlider.Dispose();
                this.labelTemplateSlider = null;
            }

            if (this.activeLabelTemplateSlider != null)
            {
                this.activeLabelTemplateSlider.Dispose();
                this.activeLabelTemplateSlider = null;
            }
        }
    }
}