// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml.Controls;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.ChartDemos.WinUI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MultipleColorBubbleSeries : Page, IDisposable
    {
        public MultipleColorBubbleSeries()
        {
            Resources.MergedDictionaries.Add(WinUI.Resources.ColorModelResource.Resource);
            this.InitializeComponent();
        }
        public void Dispose()
        {
            Chart.Dispose();
            grid.Children.Clear();
        }

        private void NumericalAxis_LabelCreated(object sender, UI.Xaml.Charts.ChartAxisLabelEventArgs e)
        {
            double position = e.Position;
            if (position > 0 && position <= 10000)
            {
                string text = (position / 1000).ToString();
                e.Label = $"{text}B";
            }
            else
            {
                e.Label = $"{position}B";
            }
        }
    }
}
