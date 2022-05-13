#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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
    public sealed partial class MultipleRanges : Page, IDisposable
    {
        public MultipleRanges()
        {
            this.InitializeComponent();
        }

        private void shapePointer_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (e.Value > 65)
            {
                this.shapePointer.Fill = this.thirdRange.Background;
                this.shapePointer.Stroke = this.thirdRange.Background;
            }
            else if(e.Value > 30)
            {
                this.shapePointer.Fill = this.secondRange.Background;
                this.shapePointer.Stroke = this.secondRange.Background;
            }
            else
            {
                this.shapePointer.Fill = this.firstRange.Background;
                this.shapePointer.Stroke = this.firstRange.Background;
            }
        }

        /// <summary>
        /// To dispose the events.
        /// </summary>
        public void Dispose()
        {
            this.shapePointer.ValueChanged -= this.shapePointer_ValueChanged;
#if WinUI_Desktop
            this.gauge.Dispose();
#endif
        }
    }
}