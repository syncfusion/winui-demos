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
    public sealed partial class DottedStepLine : Page, IDisposable
    {
        public DottedStepLine()
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
            if (position > 0 && position <= 2)
            {
                string text = position.ToString("0.0");
                e.Label = $"{text}M";
            }
            else
            {
                e.Label = $"{position:0}M";
            }
        }
    }
}
