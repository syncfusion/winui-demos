#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace syncfusion.lineargaugedemos.winui.Views
{
    using System;
    using Microsoft.UI.Xaml.Controls;
    using Syncfusion.UI.Xaml.Gauges;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HeightCalculatorDemo : Page, IDisposable
    {
        public HeightCalculatorDemo()
        {
            this.InitializeComponent();
        }

        private void shapePointer_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            if (e.NewValue < 50)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// To dispose the events.
        /// </summary>
        public void Dispose()
        {
            this.shapePointer.ValueChanging -= this.shapePointer_ValueChanging;

#if WinUI_Desktop
            this.gauge.Dispose();
#endif
        }
    }
}