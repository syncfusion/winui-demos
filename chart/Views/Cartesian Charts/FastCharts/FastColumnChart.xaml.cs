#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.ChartDemos.WinUI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FastColumnChart : Page, IDisposable
    {
        int month = int.MaxValue;
        public FastColumnChart()
        {
            Resources.MergedDictionaries.Add(WinUI.Resources.ColorModelResource.Resource);
            this.InitializeComponent();
            Chart.XAxes[0].LabelCreated += Primary_LabelCreated;
        }

        public void Dispose()
        {
            Chart.Dispose();
        }

        private void Primary_LabelCreated(object sender, ChartAxisLabelEventArgs e)
        {
            DateTime baseDate = new(1899, 12, 30);
            var date = baseDate.AddDays(e.Position);
            if (date.Month != month)
            {
                LabelStyle labelStyle = new();
                labelStyle.LabelFormat = "MMM-dd";
                labelStyle.FontFamily = new FontFamily("TimesNewRoman");
                e.LabelStyle = labelStyle;

                month = date.Month;
            }
            else
            {
                LabelStyle labelStyle = new();
                labelStyle.LabelFormat = "dd";
                e.LabelStyle = labelStyle;
            }
        }
    }
}
