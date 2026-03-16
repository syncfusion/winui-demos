#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Navigation;
using Syncfusion.UI.Xaml.Charts;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.ChartDemos.WinUI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CandleChart : Page, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CandleChart"/> page.
        /// </summary>
        public CandleChart()
        {
            InitializeComponent();
        }

        private void RangeButton_Checked(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            if (viewModel is null) return;

            ToggleButton toggle = sender as ToggleButton;

            if (toggle == ThreeMonthsButton)
            {
                viewModel.SetRange("3m");
            }
            else
            {
                viewModel.SetRange("6m");
            }         

            if (toggle != ThreeMonthsButton) ThreeMonthsButton.IsChecked = false; 
            if (SixMonthsButton is not null && toggle != SixMonthsButton) SixMonthsButton.IsChecked = false; 
        }

        int month = int.MaxValue;

        private void DateTimeAxis_LabelCreated(object sender, ChartAxisLabelEventArgs e)
        {
            DateTime baseDate = new(1899, 12, 30);

            var date = baseDate.AddDays(e.Position);

            if (date.Month != month)
            {
                LabelStyle labelStyle = new();
                labelStyle.LabelFormat = "MMM-dd";
                e.LabelStyle = labelStyle;

                month = date.Month;
            }
            else
            {
                LabelStyle labelStyle = new();
                labelStyle.LabelFormat = "dd";
                e.LabelStyle = labelStyle;
            }
        }

        /// <inheritdoc/>
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Dispose();
            base.OnNavigatedFrom(e);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Chart.Dispose();
            MainGrid.Children.Clear();
        }

        private void SolidCandle_CheckBox_Checked(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            viewModel.EnableSolidCandles = true;
        }

        private void SolidCandle_CheckBox_Unchecked(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            viewModel.EnableSolidCandles = false;
        }
    }
}
