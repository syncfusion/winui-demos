#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Syncfusion.UI.Xaml.Charts;
using Windows.System.Profile;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace syncfusion.chartdemos.winui.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SelectionBehavior : Page, IDisposable
    {
        public SelectionBehavior()
        {
            this.InitializeComponent();
        }

        public void Dispose()
        {
            Chart.Dispose();
        }

        private void EnableSegment_Checked(object sender, RoutedEventArgs e)
        {
            selection.EnableSegmentSelection = true;
            selection.EnableSeriesSelection = false;
        }

        private void EnableSeries_Checked(object sender, RoutedEventArgs e)
        {
            selection.EnableSeriesSelection = true;
            selection.EnableSegmentSelection = false;
        }

        private void selectionModeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = (sender as ComboBox).SelectedIndex;
            selection.SelectionMode = index == 0 ? Syncfusion.UI.Xaml.Charts.SelectionMode.MouseClick : Syncfusion.UI.Xaml.Charts.SelectionMode.MouseMove;
        }

        private void selectionStyleCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = (sender as ComboBox).SelectedIndex;
            selection.SelectionStyle = index == 0 ?  SelectionStyle.Single : SelectionStyle.Multiple;
        }
    }
}
