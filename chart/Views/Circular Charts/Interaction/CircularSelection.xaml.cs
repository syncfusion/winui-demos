using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Syncfusion.UI.Xaml.Charts;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.ChartDemos.WinUI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CircularSelection : Page, IDisposable
    {
        public CircularSelection()
        {
            Resources.MergedDictionaries.Add(WinUI.Resources.ColorModelResource.Resource);
            this.InitializeComponent();
        }

        public void Dispose()
        {
            Chart.Dispose();
            grid.Children.Clear();
        }

        private void dataPointSelection_SelectionChanging(object sender, ChartSelectionChangingEventArgs e)
        {
            var palette= Resources["ChartCustomPalette"] as BrushCollection;
            if (model == null) return;

            foreach (var index in e.NewIndexes)
            {
                if (e.OldIndexes.Contains(index))
                {
                    selection.PaletteBrushes = palette;
                }
                else
                {
                    if(Chart.ActualTheme==ElementTheme.Dark)
                    {
                        selection.PaletteBrushes = model.DarkSelectionBrushes;
                    }
                    else
                    {
                        selection.PaletteBrushes = model.SelectionBrushes;
                    }
                }
                if (palette[index] is SolidColorBrush brush)
                    dataPointSelection.SelectionBrush = brush;
            }
        }
    }
}
