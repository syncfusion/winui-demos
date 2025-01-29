// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
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
    public sealed partial class NumericalAxis : Page, IDisposable
    {
        public NumericalAxis()
        {
            Resources.MergedDictionaries.Add(WinUI.Resources.ColorModelResource.Resource);
            this.InitializeComponent();
        }

        public void Dispose()
        {
            Chart.Dispose();
        }

        private void NumericalAxis_LabelCreated(object sender, UI.Xaml.Charts.ChartAxisLabelEventArgs e)
        {
            double position = e.Position+1;
            if (position > 0 && position <= 360)
            {
                string text = position.ToString();
                e.Label = $"{text}";
            }
            else
            {
                e.Label = $"{position}";
            }
        }
    }
}
