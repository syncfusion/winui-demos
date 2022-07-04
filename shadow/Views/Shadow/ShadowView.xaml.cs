using Microsoft.UI;
using Microsoft.UI.Xaml.Controls;
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
    }
}
