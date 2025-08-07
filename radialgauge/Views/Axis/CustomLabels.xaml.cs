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
    using Microsoft.UI.Xaml.Controls;
    using Syncfusion.UI.Xaml.Gauges;
    using System;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomLabels : Page, IDisposable
    {
        public CustomLabels()
        {
            this.InitializeComponent();
        }

        private void RadialAxis_LabelPrepared(object sender, LabelPreparedEventArgs e)
        {
            if (e.LabelText == "80" || e.LabelText == "0")
            {
                e.LabelText = "N";
            }
            else if (e.LabelText == "10")
            {
                e.LabelText = "NE";
            }
            else if (e.LabelText == "20")
            {
                e.LabelText = "E";
            }
            else if (e.LabelText == "30")
            {
                e.LabelText = "SE";
            }
            else if (e.LabelText == "40")
            {
                e.LabelText = "S";
            }
            else if (e.LabelText == "50")
            {
                e.LabelText = "SW";
            }
            else if (e.LabelText == "60")
            {
                e.LabelText = "W";
            }
            else if (e.LabelText == "70")
            {
                e.LabelText = "NW";
            }
        }

        /// <summary>
        /// To dispose objects.
        /// </summary>
        public void Dispose()
        {
            this.radialAxis.LabelPrepared -= RadialAxis_LabelPrepared;
            this.gauge.Dispose();
        }
    }
}