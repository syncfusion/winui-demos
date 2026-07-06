
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238
namespace Syncfusion.RadialGaugeDemos.WinUI.Views
{
    using System;
    using Microsoft.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TempMonitor : Page, IDisposable
    {
        public TempMonitor()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// To dispose objects.
        /// </summary>
        public void Dispose()
        {
            this.gauge.Dispose();
        }
    }
}