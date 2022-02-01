#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Syncfusion.UI.Xaml.Core;
using Syncfusion.UI.Xaml.Editors;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace syncfusion.editordemos.winui.Views.DropDownColorPicker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DropDownColorPickerView : Page
    {
        public DropDownColorPickerView()
        {
            this.InitializeComponent();

            foregroundPicker.Command = new DelegateCommand(UpdateForegroundColor);
            backgroundPicker.Command = new DelegateCommand(UpdateBackgroundColor);

            richEditBox.Document.SetText(Microsoft.UI.Text.TextSetOptions.None,
                "The Dropdown Color Picker allows users to edit a solid and gradient brush " +
                "through a drop-down menu, and provides RGB, HSV, HSL, CMYK, and " +
                "hex color modes for color selection.");
            richEditBox.Document.Selection.StartPosition = 0;
            richEditBox.Document.Selection.EndPosition = 18;
            this.dropDownColorPickerViewPanel.PointerPressed += OnDropDownColorPickerViewPanelPointerPressed;
        }

        private void OnDropDownColorPickerViewPanelPointerPressed(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            // To restrict the focus on first control when clicking on empty area.
            e.Handled = true;
        }

        private void UpdateForegroundColor(object parameter)
        {
            if (parameter is SelectedBrushChangedEventArgs)
            {
                var brush = (parameter as SelectedBrushChangedEventArgs).NewBrush as SolidColorBrush;
                if (brush != null)
                {
                    richEditBox.Document.Selection.CharacterFormat.ForegroundColor = brush.Color;
                }
            }
        }

        private void UpdateBackgroundColor(object parameter)
        {
            if (parameter is SelectedBrushChangedEventArgs)
            {
                var brush = (parameter as SelectedBrushChangedEventArgs).NewBrush as SolidColorBrush;
                if (brush != null)
                {
                    richEditBox.Document.Selection.CharacterFormat.BackgroundColor = brush.Color;
                }
            }
        }
    }
}
