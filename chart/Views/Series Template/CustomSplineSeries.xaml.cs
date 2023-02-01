#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

using Microsoft.UI.Text;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Syncfusion.UI.Xaml.Charts;
using System;
using Windows.System.Profile;
using Windows.UI;

namespace Syncfusion.ChartDemos.WinUI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomSplineSeries : Page, IDisposable
    {
        public CustomSplineSeries()
        {
            this.InitializeComponent();
        }

        public void Dispose()
        {
            Chart.Dispose();
        }
    }

}
