#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.ChartDemos.WinUI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BubbleChart : Page, IDisposable
    {
        public BubbleChart()
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
            if (position >= 1000 && position <= 999999)
            {
                string text = (position / 1000).ToString("C0");
                e.Label = $"{text}K";
            }
            else
            {
                e.Label = $"{position:C0}K";
            }
        }
    }

}
