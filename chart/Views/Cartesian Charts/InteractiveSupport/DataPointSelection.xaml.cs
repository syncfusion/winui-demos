#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.Charts;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.ChartDemos.WinUI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DataPointSelection : Page, IDisposable
    {
        public DataPointSelection()
        {
            Resources.MergedDictionaries.Add(WinUI.Resources.ColorModelResource.Resource);
            this.InitializeComponent();
            dataPointSelection.SelectedIndex = 3;
        }

        public void Dispose()
        {
            dataPointSelectionChart.Dispose();
            grid.Children.Clear();
        }
        private void checkbox_Checked(object sender, RoutedEventArgs e)
        {
            if (dataPointSelection != null)
            {
                dataPointSelection.Type = ChartSelectionType.Multiple;
            }
        }

        private void checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (dataPointSelection != null)
            {
                dataPointSelection.Type = ChartSelectionType.SingleDeselect;
            }
        }

    }
}
