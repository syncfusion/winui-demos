#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace syncfusion.chartdemos.winui.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ColorPalettes : Page, IDisposable
    {
        public ColorPalettes()
        {
            this.InitializeComponent();
            
        }

        public void Dispose()
        {
            barChart.Dispose();
            doughnutChart.Dispose();
            stackedChart.Dispose();
        }

        void OnPaletteCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch ((sender as ComboBox).SelectedIndex)
            {
                case 0:
                    barChart.Palette = ChartColorPalette.Metro;
                    doughnutChart.Series[0].Palette = ChartColorPalette.Metro;
                    stackedChart.Palette = ChartColorPalette.Metro;
                    break;
                case 1:
                    barChart.Palette = ChartColorPalette.AutumnBrights;
                    doughnutChart.Series[0].Palette = ChartColorPalette.AutumnBrights;
                    stackedChart.Palette = ChartColorPalette.AutumnBrights;
                    break;
                case 2:
                    barChart.Palette = ChartColorPalette.FloraHues;
                    doughnutChart.Series[0].Palette = ChartColorPalette.FloraHues;
                    stackedChart.Palette = ChartColorPalette.FloraHues;
                    break;
                case 3:
                    barChart.Palette = ChartColorPalette.Pineapple;
                    doughnutChart.Series[0].Palette = ChartColorPalette.Pineapple;
                    stackedChart.Palette = ChartColorPalette.Pineapple;
                    break;
                case 4:
                    barChart.Palette = ChartColorPalette.TomotoSpectrum;
                    doughnutChart.Series[0].Palette = ChartColorPalette.TomotoSpectrum;
                    stackedChart.Palette = ChartColorPalette.TomotoSpectrum;
                    break;
                case 5:
                    barChart.Palette = ChartColorPalette.RedChrome;
                    doughnutChart.Series[0].Palette = ChartColorPalette.RedChrome;
                    stackedChart.Palette = ChartColorPalette.RedChrome;
                    break;
                case 6:
                    barChart.Palette = ChartColorPalette.BlueChrome;
                    doughnutChart.Series[0].Palette = ChartColorPalette.BlueChrome;
                    stackedChart.Palette = ChartColorPalette.BlueChrome;
                    break;
                case 7:
                    barChart.Palette = ChartColorPalette.PurpleChrome;
                    doughnutChart.Series[0].Palette = ChartColorPalette.PurpleChrome;
                    stackedChart.Palette = ChartColorPalette.PurpleChrome;
                    break;
                case 8:
                    barChart.Palette = ChartColorPalette.GreenChrome;
                    doughnutChart.Series[0].Palette = ChartColorPalette.GreenChrome;
                    stackedChart.Palette = ChartColorPalette.GreenChrome;
                    break;
                case 9:
                    barChart.Palette = ChartColorPalette.Elite;
                    doughnutChart.Series[0].Palette = ChartColorPalette.Elite;
                    stackedChart.Palette = ChartColorPalette.Elite;
                    break;
                case 10:
                    barChart.Palette = ChartColorPalette.LightCandy;
                    doughnutChart.Series[0].Palette = ChartColorPalette.LightCandy;
                    stackedChart.Palette = ChartColorPalette.LightCandy;
                    break;
                case 11:
                    barChart.Palette = ChartColorPalette.SandyBeach;
                    doughnutChart.Series[0].Palette = ChartColorPalette.SandyBeach;
                    stackedChart.Palette = ChartColorPalette.SandyBeach;
                    break;
                case 12:
                    barChart.Palette = ChartColorPalette.Custom;
                    doughnutChart.Series[0].Palette = ChartColorPalette.Custom;
                    stackedChart.Palette = ChartColorPalette.Custom;
                    barChart.ColorModel = demolayout.Resources["CustomColor"] as ChartColorModel;
                    doughnutChart.ColorModel = demolayout.Resources["CustomColor"] as ChartColorModel;
                    stackedChart.ColorModel = demolayout.Resources["CustomColor"] as ChartColorModel;
                    break;
            }
        }
       
    }
}