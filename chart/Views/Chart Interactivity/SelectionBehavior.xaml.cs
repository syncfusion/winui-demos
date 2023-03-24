#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Syncfusion.UI.Xaml.Charts;
using Windows.System.Profile;
using SelectionChangedEventArgs = Microsoft.UI.Xaml.Controls.SelectionChangedEventArgs;
using System.Globalization;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.ChartDemos.WinUI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SelectionBehavior : Page, IDisposable
    {
        public SelectionBehavior()
        {
            Resources.MergedDictionaries.Add(WinUI.Resources.ColorModelResource.Resource);
            this.InitializeComponent();
            dataPointSelection.SelectedIndex = 6;
        }

        public void Dispose()
        {
            seriesSelectionChart.Dispose();
            dataPointSelectionChart.Dispose();
        }

        private void selectionStyleCombo_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            UpdateSelection();
        }

        private void UpdateSelection()
        {
            if(comboBox2 != null)
            {
                int index = comboBox2.SelectedIndex;
                switch (index)
                {
                    case 0:
                        dataPointSelection.Type = ChartSelectionType.None;
                        break;
                    case 1:
                        dataPointSelection.Type = ChartSelectionType.Single;
                        break;
                    case 2:
                        dataPointSelection.Type = ChartSelectionType.Multiple;
                        break;
                    case 3:
                        dataPointSelection.Type = ChartSelectionType.SingleDeselect;
                        break;
                }
            }
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            if (comboBox2 != null)
            {
                if (comboBox.SelectedIndex == 0)
                {
                    dataPointSelectionChart.Visibility = Visibility.Visible;
                    seriesSelectionChart.Visibility = Visibility.Collapsed;
                    comboBox2.Visibility = Visibility.Visible;
                }
                else
                {
                    dataPointSelectionChart.Visibility = Visibility.Collapsed;
                    seriesSelectionChart.Visibility = Visibility.Visible;
                    comboBox2.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void selection_SelectionChanged(object sender, UI.Xaml.Charts.ChartSelectionChangedEventArgs e)
        {
            if (e.NewIndexes[0] == 0)
            {
                seriesSelectionChart.Series[0].Opacity = 1;
                seriesSelectionChart.Series[1].Opacity = 0.5;
            }
            else if (e.NewIndexes[0] == 1)
            {
                seriesSelectionChart.Series[1].Opacity = 1;
                seriesSelectionChart.Series[0].Opacity = 0.5;
            }
            else
            {
                seriesSelectionChart.Series[0].Opacity = 1;
                seriesSelectionChart.Series[1].Opacity = 1;
            }
        }
    }
}
