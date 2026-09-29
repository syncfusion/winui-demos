
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.RadialGaugeDemos.WinUI.Views
{
    using System;
    using Microsoft.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DirectionCompass : Page, IDisposable
    {
        public DirectionCompass()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// To dispose the objects.
        /// </summary>
        public void Dispose()
        {
            this.gauge.Dispose();
        }
    }
}