#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.SliderDemos.WinUI.Views.Slider
{
    using System;
    using Microsoft.UI.Xaml.Controls;
    using Syncfusion.UI.Xaml.Sliders;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VolumeSettingsDemo : Page, IDisposable
    {

        public VolumeSettingsDemo()
        {
            this.InitializeComponent();
        }

        private void musicSlider_ValueChanged(object sender, SliderValueChangedEventArgs e)
        {
            string glyph;
            if (e.NewValue >= 66)
            {
                glyph = "\uED33";
            }
            else if (e.NewValue >= 33)
            {
                glyph = "\uED32";
            }
            else if (e.NewValue >= 1)
            {
                glyph = "\uED31";
            }
            else
            {
                glyph = "\uED30";
            }

            if (this.musiqFontIcon.Glyph != glyph)
            {
                this.musiqFontIcon.Glyph = glyph;
            }
        }

        private void volumeSlider_ValueChanged(object sender, SliderValueChangedEventArgs e)
        {
            string glyph;
            if (e.NewValue >= 66)
            {
                glyph = "\uE995";
            }
            else if (e.NewValue >= 33)
            {
                glyph = "\uE994";
            }
            else if (e.NewValue >= 1)
            {
                glyph = "\uE993";
            }
            else
            {
                glyph = "\uE992";
            }

            if (this.volumeFontIcon.Glyph != glyph)
            {
                this.volumeFontIcon.Glyph = glyph;
            }
        }

        private void alarmSlider_ValueChanged(object sender, SliderValueChangedEventArgs e)
        {
            string glyph;
            if (e.NewValue == 0)
            {
                glyph = "\uE7ED";
            }
            else
            {
                glyph = "\uEA8F";
            }

            if (this.alarmFontIcon.Glyph != glyph)
            {
                this.alarmFontIcon.Glyph = glyph;
            }
        }

        /// <summary>
        /// To dispose the events.
        /// </summary>
        public void Dispose()
        {
            this.volumeSlider.ValueChanged -= this.volumeSlider_ValueChanged;
            this.musicSlider.ValueChanged -= this.musicSlider_ValueChanged;
            this.alarmSlider.ValueChanged -= this.alarmSlider_ValueChanged;
        }
    }
}