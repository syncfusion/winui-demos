
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.SliderDemos.WinUI.Views.Slider
{
    using Microsoft.UI.Xaml.Controls;
    using System;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Equalizer : Page, IDisposable
    {
        public Equalizer()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Dispose all the allocated resources.
        /// </summary>
        public void Dispose()
        {
            if (this.slider500 != null)
            {
                this.slider500.Dispose();
                this.slider500 = null;
            }

            if (this.slider32 != null)
            {
                this.slider32.Dispose();
                this.slider32 = null;
            }

            if (this.slider64 != null)
            {
                this.slider64.Dispose();
                this.slider64 = null;
            }

            if (this.slider125 != null)
            {
                this.slider125.Dispose();
                this.slider125 = null;
            }

            if (this.slider250 != null)
            {
                this.slider250.Dispose();
                this.slider250 = null;
            }

            if (this.slider500 != null)
            {
                this.slider500.Dispose();
                this.slider500 = null;
            }
        }
    }
}