#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.RadialGaugeDemos.WinUI.Views
{
    using System;
    using Microsoft.UI.Xaml.Controls;
    using Syncfusion.UI.Xaml.Gauges;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MultipleNeedle : Page, IDisposable
    {
        public MultipleNeedle()
        {
            this.InitializeComponent();
        }
        private void mainAxis_LabelPrepared(object sender, LabelPreparedEventArgs e)
        {
            if(e.LabelText == "12")
            {
                e.LabelText += "h";
            }
        }

        /// <summary>
        /// To dispose objects.
        /// </summary>
        public void Dispose()
        {
            this.mainAxis.LabelPrepared -= this.mainAxis_LabelPrepared;

            this.gauge.Dispose();
        }
    }
}