#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
    public sealed partial class MultiplePointers : Page, IDisposable
    {
        public MultiplePointers()
        {
            this.InitializeComponent();
        }

        private void shapePointer1_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            if (e.NewValue <= 5)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// To dispose the events.
        /// </summary>
        public void Dispose()
        {
            this.shapePointer1.ValueChanging -= this.shapePointer1_ValueChanging;
            this.gauge.Dispose();
        }
    }
}