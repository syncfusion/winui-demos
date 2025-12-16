// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using System;
using Windows.UI;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.ChartDemos.WinUI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ColumnRoundedEdges : Page, IDisposable
    {
        public ColumnRoundedEdges()
        {
            Resources.MergedDictionaries.Add(WinUI.Resources.ColorModelResource.Resource);
            this.InitializeComponent();
        }

        public void Dispose()
        {
            Chart.Dispose();
            grid.Children.Clear();
        }
    }

    public class LabelTemplateConverter : IValueConverter
    {
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            double position = value as double? ?? 0;
            return position % 2 == 0 ? new SolidColorBrush(Color.FromArgb(0xFF, 0x10, 0x60, 0xDC)) : new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0xB5, 0x53));
        }
    }
}
