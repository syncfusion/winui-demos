#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI;
using Microsoft.UI.Text;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Text;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.EditorDemos.WinUI.Views.AutoComplete
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Highlighting : Page
    {
        public Highlighting()
        {
            this.InitializeComponent();
            foregroundColorPicker.SelectedBrush = new SolidColorBrush(Colors.Red);
        }

        private void OnFontStyleSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fontStyle.SelectedIndex == 0)
            {
                autoComplete.HighlightedTextFontStyle = FontStyle.Normal;
            }
            else if (fontStyle.SelectedIndex == 1)
            {
                autoComplete.HighlightedTextFontStyle = FontStyle.Italic;
            }
            else if (fontStyle.SelectedIndex == 2)
            {
                autoComplete.HighlightedTextFontStyle = FontStyle.Oblique;
            }
        }
        private void OnFontWeightSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fontWeight.SelectedIndex == 0)
            {
                autoComplete.HighlightedTextFontWeight = FontWeights.Bold;
            }
            else if (fontWeight.SelectedIndex == 1)
            {
                autoComplete.HighlightedTextFontWeight = FontWeights.ExtraBold;
            }
            else if (fontWeight.SelectedIndex == 2)
            {
                autoComplete.HighlightedTextFontWeight = FontWeights.ExtraLight;
            }
            else if (fontWeight.SelectedIndex == 3)
            {
                autoComplete.HighlightedTextFontWeight = FontWeights.Light;
            }
            else if (fontWeight.SelectedIndex == 4)
            {
                autoComplete.HighlightedTextFontWeight = FontWeights.Medium;
            }
            else if (fontWeight.SelectedIndex == 5)
            {
                autoComplete.HighlightedTextFontWeight = FontWeights.Normal;
            }
            else if (fontWeight.SelectedIndex == 6)
            {
                autoComplete.HighlightedTextFontWeight = FontWeights.SemiBold;
            }
            else if (fontWeight.SelectedIndex == 7)
            {
                autoComplete.HighlightedTextFontWeight = FontWeights.SemiLight;
            }
            else if (fontWeight.SelectedIndex == 8)
            {
                autoComplete.HighlightedTextFontWeight = FontWeights.Thin;
            }
            else if (fontWeight.SelectedIndex == 9)
            {
                autoComplete.HighlightedTextFontWeight = FontWeights.Black;
            }
            else if (fontWeight.SelectedIndex == 10)
            {
                autoComplete.HighlightedTextFontWeight = FontWeights.ExtraBlack;
            }
        }
        private void OnFontSizeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string value = (e.AddedItems[0] as ComboBoxItem).Content as string;
            autoComplete.HighlightedTextFontSize = Convert.ToDouble(value);
        }
        private void OnTextHighlightModeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (textHighlightMode.SelectedIndex == 0)
            {
                this.foregroundColorPicker.IsEnabled = false;
                this.fontSize.IsEnabled = false;
                this.foregroundHeader.Opacity = 0.4;
                this.fontStyle.IsEnabled = false;
                this.fontWeight.IsEnabled = false;
            }
            else
            {
                this.foregroundColorPicker.IsEnabled = true;
                this.fontSize.IsEnabled = true;
                this.foregroundHeader.Opacity = 1;
                this.fontStyle.IsEnabled = true;
                this.fontWeight.IsEnabled = true;
            }
        }
    }
}
