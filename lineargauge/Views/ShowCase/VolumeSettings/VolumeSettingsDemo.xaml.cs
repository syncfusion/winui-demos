#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.LinearGaugeDemos.WinUI.Views
{
    using System;
    using Microsoft.UI.Xaml.Controls;
    using Syncfusion.UI.Xaml.Gauges;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VolumeSettingsDemo : Page, IDisposable
    {
        public VolumeSettingsDemo()
        {
            this.InitializeComponent();
        }

        private void volumeShapePointer_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            string glyph;
            if (e.NewValue <= 0)
            {
                glyph = "\uE74F";
                e.Cancel = true;
            }
            else
            {
                glyph = "\uE767";
            }

            if (this.volumeFontIcon.Glyph != glyph)
            {
                this.volumeFontIcon.Glyph = glyph;
            }
        }

        private void alarmShapePointer_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            string glyph;
            if (e.NewValue <= 0)
            {
                glyph = "\uE7ED";
                e.Cancel = true;
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

        private void musicShapePointer_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            string glyph;
            if (e.NewValue <= 0)
            {
                glyph = "\uED30";
                e.Cancel = true;
            }
            else
            {
                glyph = "\uED33";
            }

            if (this.musicFontIcon.Glyph != glyph)
            {
                this.musicFontIcon.Glyph = glyph;
            }
        }

        public void Dispose()
        {
            this.musicShapePointer.ValueChanging -= this.volumeShapePointer_ValueChanging;
            this.volumeShapePointer.ValueChanging -= this.volumeShapePointer_ValueChanging;
            this.alarmShapePointer.ValueChanging -= this.alarmShapePointer_ValueChanging;

            this.musicGauge.Dispose();
            this.volumeGauge.Dispose();
            this.alarmGauge.Dispose();
        }
    }
}