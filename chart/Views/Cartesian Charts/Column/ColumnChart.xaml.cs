using System;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.ChartDemos.WinUI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ColumnChart : Page, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnChart"/> page.
        /// </summary>
        public ColumnChart()
        {
            Resources.MergedDictionaries.Add(WinUI.Resources.ColorModelResource.Resource);
            this.InitializeComponent();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Chart.Dispose();
            grid.Children.Clear();
        }
    }
}
