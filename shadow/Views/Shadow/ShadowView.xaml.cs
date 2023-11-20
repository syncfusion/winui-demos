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
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using System;
using Windows.UI;

namespace Syncfusion.ShadowDemos.WinUI.Views.Shadow
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShadowView : Page
    {
        public ShadowView()
        {
            this.InitializeComponent();
        }

        private void ColorPicker1_SelectedBrushChanged(object sender, UI.Xaml.Editors.SelectedBrushChangedEventArgs e)
        {
            btnShadow.Color = (colorPicker1.SelectedBrush as SolidColorBrush).Color;
        }

        private void ColorPicker2_SelectedBrushChanged(object sender, UI.Xaml.Editors.SelectedBrushChangedEventArgs e)
        {
            imageShadow.Color = (colorPicker2.SelectedBrush as SolidColorBrush).Color;
        }

        private void ColorPicker3_SelectedBrushChanged(object sender, UI.Xaml.Editors.SelectedBrushChangedEventArgs e)
        {
            shape1.Color = (colorPicker3.SelectedBrush as SolidColorBrush).Color;     
            shape2.Color = (colorPicker3.SelectedBrush as SolidColorBrush).Color; 
            shape3.Color = (colorPicker3.SelectedBrush as SolidColorBrush).Color;
            shape4.Color = (colorPicker3.SelectedBrush as SolidColorBrush).Color;
            shape5.Color = (colorPicker3.SelectedBrush as SolidColorBrush).Color;
        }

        private void toggle1_Toggled(object sender, RoutedEventArgs e)
        {
            if(toggle1.IsOn == true)
            {
                btnShadow.EnableShadow = false;
                buttonShadow.PointerEntered += ButtonShadow_PointerEntered;
                buttonShadow.PointerExited += ButtonShadow_PointerExited;
            }
            else
            {
                btnShadow.EnableShadow = true;
                buttonShadow.PointerEntered -= ButtonShadow_PointerEntered;
                buttonShadow.PointerExited -= ButtonShadow_PointerExited;
                board1.Stop();
                board2.Stop();
            }
        }

        private void ButtonShadow_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "PointerOver", true);
            board1.Begin();
        }

        private void ButtonShadow_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "PointerExit", true);
            board2.Begin();
        }
    }
}
