#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Text;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Syncfusion.UI.Xaml.Core;
using Microsoft.UI.Xaml;
using System;
using Windows.System;
using Windows.UI.Text;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.EditorDemos.WinUI.Views.ComboBox
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
                comboBox.HighlightedTextFontStyle = FontStyle.Normal;
            }
            else if (fontStyle.SelectedIndex == 1)
            {
                comboBox.HighlightedTextFontStyle = FontStyle.Italic;
            }
            else if (fontStyle.SelectedIndex == 2)
            {
                comboBox.HighlightedTextFontStyle = FontStyle.Oblique;
            }
        }
        private void OnFontWeightSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fontWeight.SelectedIndex == 0)
            {
                comboBox.HighlightedTextFontWeight = FontWeights.Bold;
            }
            else if (fontWeight.SelectedIndex == 1)
            {
                comboBox.HighlightedTextFontWeight = FontWeights.ExtraBold;
            }
            else if (fontWeight.SelectedIndex == 2)
            {
                comboBox.HighlightedTextFontWeight = FontWeights.ExtraLight;
            }
            else if (fontWeight.SelectedIndex == 3)
            {
                comboBox.HighlightedTextFontWeight = FontWeights.Light;
            }
            else if (fontWeight.SelectedIndex == 4)
            {
                comboBox.HighlightedTextFontWeight = FontWeights.Medium;
            }
            else if (fontWeight.SelectedIndex == 5)
            {
                comboBox.HighlightedTextFontWeight = FontWeights.Normal;
            }
            else if (fontWeight.SelectedIndex == 6)
            {
                comboBox.HighlightedTextFontWeight = FontWeights.SemiBold;
            }
            else if (fontWeight.SelectedIndex == 7)
            {
                comboBox.HighlightedTextFontWeight = FontWeights.SemiLight;
            }
            else if (fontWeight.SelectedIndex == 8)
            {
                comboBox.HighlightedTextFontWeight = FontWeights.Thin;
            }
            else if (fontWeight.SelectedIndex == 9)
            {
                comboBox.HighlightedTextFontWeight = FontWeights.Black;
            }
            else if (fontWeight.SelectedIndex == 10)
            {
                comboBox.HighlightedTextFontWeight = FontWeights.ExtraBlack;
            }
        }
        private void OnFontSizeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string value = (e.AddedItems[0] as ComboBoxItem).Content as string;
            comboBox.HighlightedTextFontSize = Convert.ToDouble(value);
        }

        private void OnComboBoxPreviewKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (!this.comboBox.IsDropDownOpen)
            {
                bool allowOpenDropDown = e.Key != VirtualKey.Enter && e.Key != VirtualKey.Tab &&
                                         e.Key != VirtualKey.F4 && e.Key != VirtualKey.Escape &&
                                         e.Key != VirtualKey.Shift;

                TextBox editingTextBox = VisualTree.FindDescendant(this.comboBox, typeof(TextBox)) as TextBox;
                if (allowOpenDropDown && editingTextBox != null && editingTextBox.FocusState != FocusState.Unfocused)
                {
                    this.comboBox.IsDropDownOpen = true;
                }
            }
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
