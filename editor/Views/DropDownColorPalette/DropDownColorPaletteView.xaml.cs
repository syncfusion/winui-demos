#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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

namespace syncfusion.editordemos.winui.Views.DropDownColorPalette
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DropDownColorPaletteView : Page
    {
        public DropDownColorPaletteView()
        {
            this.InitializeComponent();

            foregroundPicker.Command = new DelegateCommand(SetForegroundColor);
            backgroundPicker.Command = new DelegateCommand(SetBackgroundColor);

            richEditBox.Document.SetText(Microsoft.UI.Text.TextSetOptions.None,
                "The Color Palette allows users to select a color " +
                "from a list of available colors. The Dropdown Color Palette allows " +
                "users to select a color from a available colors in a drop-down list.");
            richEditBox.Document.Selection.StartPosition = 0;
            richEditBox.Document.Selection.EndPosition = 18;
        }

        private void SetForegroundColor(object parameter)
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

        private void SetBackgroundColor(object parameter)
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
