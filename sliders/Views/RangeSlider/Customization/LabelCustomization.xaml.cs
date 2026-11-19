
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.SliderDemos.WinUI.Views.RangeSlider
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
            if (this.labelTemplateRangeSlider != null)
            {
                this.labelTemplateRangeSlider.Dispose();
                this.labelTemplateRangeSlider = null;
            }

            if (this.activeLabelTemplateRangeSlider != null)
            {
                this.activeLabelTemplateRangeSlider.Dispose();
                this.activeLabelTemplateRangeSlider = null;
            }
        }
    }
}