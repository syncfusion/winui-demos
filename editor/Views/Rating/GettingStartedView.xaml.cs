#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using Syncfusion.UI.Xaml.Editors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.XPath;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.EditorDemos.WinUI.Views.Rating
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GettingStartedView : Page
    {
        public GettingStartedView()
        {
            this.InitializeComponent();
        }

        private void PrecisionCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (precisionCombo.SelectedIndex)
            {
                case 0:
                    DefaultStyle.Precision = RatingPrecision.Full;
                    break;
                case 1:
                    DefaultStyle.Precision = RatingPrecision.Half;
                    break;
                case 2:
                    DefaultStyle.Precision = RatingPrecision.Exact;
                    break;
            }
        }

        private void RatingValue_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            switch (precisionCombo.SelectedIndex)
            {
                case 0:
                    valueSlider.StepFrequency = 1.0;
                    DefaultStyle.Value = valueSlider.Value;
                    RatingText.Text = " " + Math.Round(DefaultStyle.Value, 1);
                    break;
                case 1:
                    valueSlider.StepFrequency = 0.5;
                    DefaultStyle.Value = valueSlider.Value;
                    RatingText.Text = " " + Math.Round(DefaultStyle.Value, 1);
                    break;
                case 2:
                    valueSlider.StepFrequency = 0.1;
                    DefaultStyle.Value = valueSlider.Value;
                    RatingText.Text = " " + Math.Round(DefaultStyle.Value, 1);
                    break;
            }
        }

        private void ratingCount_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            switch (precisionCombo.SelectedIndex)
            {
                case 0:
                    RatingText.Text = " " + Math.Round(DefaultStyle.Value, 1);
                    break;
                case 1:
                    RatingText.Text = " " + Math.Round(DefaultStyle.Value, 1);
                    break;
                case 2:
                    RatingText.Text = " " + Math.Round(DefaultStyle.Value, 1);
                    break;
            }
        }

        private void tooltipFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (tooltipFormat.SelectedIndex)
            {
                case 0:
                    DefaultStyle.ToolTipFormat = "0.000";
                    break;
                case 1:
                    DefaultStyle.ToolTipFormat = "0.00";
                    break;
                case 2:
                    DefaultStyle.ToolTipFormat = "0.##";
                    break;
            }
        }

        private void orientationCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (orientationCombo.SelectedIndex == 1)
                DefaultStyle.Orientation = Orientation.Vertical;
            else
                DefaultStyle.Orientation = Orientation.Horizontal;
        }
    }
}
