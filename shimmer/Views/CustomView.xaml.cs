#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Syncfusion.UI.Xaml.Core;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI;

namespace Syncfusion.ShimmerDemos.WinUI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomView : Page
    {
        public CustomView()
        {
            this.InitializeComponent();
        }

        private void FillPalette_SelectedBrushChanged(object sender, UI.Xaml.Editors.SelectedBrushChangedEventArgs e)
        {
            shimmer.Fill = shimmerFillColor.SelectedBrush as SolidColorBrush;
        }

        private void WavePalette_SelectedBrushChanged(object sender, UI.Xaml.Editors.SelectedBrushChangedEventArgs e)
        {
            if (shimmerWaveColor.SelectedBrush is SolidColorBrush solidColorBrush)
            {
                shimmer.WaveColor = solidColorBrush.Color;
            }
        }
    }
}
