using System;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.ChartDemos.WinUI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SemiPieChart : Page, IDisposable
    {
        public SemiPieChart()
        {
            Resources.MergedDictionaries.Add(WinUI.Resources.ColorModelResource.Resource);
            this.InitializeComponent();
        }

        public void Dispose()
        {
            Chart.Dispose();
            grid.Children.Clear();
        }
  
        private void StartSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Pieseries.StartAngle = e.NewValue;
        }

        private void EndSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Pieseries.EndAngle = e.NewValue;
        }

    }
}
