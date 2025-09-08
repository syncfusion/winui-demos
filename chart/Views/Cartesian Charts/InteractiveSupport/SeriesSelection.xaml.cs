// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.Charts;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.ChartDemos.WinUI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SeriesSelection : Page, IDisposable
    {

        public SeriesSelection()
        {
            Resources.MergedDictionaries.Add(WinUI.Resources.ColorModelResource.Resource);
            this.InitializeComponent();
        }
        private void Selection_SelectionChanged(object sender, ChartSelectionChangedEventArgs e)
        {
            if (e.NewIndexes.Count > 0 && e.NewIndexes[0] >= 0)
            {
                int selectedSeriesIndex = e.NewIndexes[0];

                for (int i = 0; i < seriesSelectionChart.Series.Count; i++)
                {
                    var series = seriesSelectionChart.Series[i];

                    if (i == selectedSeriesIndex)
                    {
                        series.Opacity = 1;
                    }
                    else
                    {
                        series.Opacity = 0.3;
                    }
                }
            }
            else
            {
                for (int i = 0; i < seriesSelectionChart.Series.Count; i++)
                {
                    var series = seriesSelectionChart.Series[i];
                    series.Opacity = 0.3; 
                }
            }
        }
        public void Dispose()
        {
            seriesSelectionChart.Dispose();
            grid.Children.Clear();
        }
    }
}
