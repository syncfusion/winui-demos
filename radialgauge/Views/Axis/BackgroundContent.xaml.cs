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

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BackgroundContent : Page
    {
        public BackgroundContent()
        {
            this.InitializeComponent();
        }

        private void RadialAxis_LabelPrepared(object sender, LabelPreparedEventArgs e)
        {
            if (e.LabelText == "90")
            {
                e.LabelText = "E";
            }
            else if (e.LabelText == "360")
            {
                e.LabelText = string.Empty;
            }
            else
            {
                if (e.LabelText == "0")
                {
                    e.LabelText = "N";
                }
                else if (e.LabelText == "180")
                {
                    e.LabelText = "S";
                }
                else if (e.LabelText == "270")
                {
                    e.LabelText = "W";
                }
            }
        }
    }
}