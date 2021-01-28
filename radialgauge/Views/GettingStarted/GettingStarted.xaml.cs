#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace syncfusion.radialgaugedemos.winui.Views
{
    using Microsoft.UI.Xaml.Controls;
    using Syncfusion.UI.Xaml.Gauges;
    using System;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>

    public sealed partial class GettingStarted : Page, IDisposable
    {
        public GettingStarted()
        {
            this.InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch((AnnotationDirection)(sender as ComboBox).SelectedItem)
            {
                case AnnotationDirection.Angle:
                    this.directionValueSlider.Maximum = 360;
                    break;
                case AnnotationDirection.AxisValue:
                    this.directionValueSlider.Maximum = 150;
                    break;
            }
        }

        public void Dispose()
        {
            directionUnitComboBox.SelectionChanged -= ComboBox_SelectionChanged;
        }
    }
}