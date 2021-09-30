#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
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
    using Microsoft.UI.Xaml.Data;
    using Microsoft.UI.Xaml.Media;
    using Syncfusion.UI.Xaml.Gauges;
    using Windows.UI;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StepsCounter : Page, IDisposable
    {
        public StepsCounter()
        {
            this.InitializeComponent();
        }

        private void stepCountShapePointer_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            if (e.NewValue < 360)
            {
                e.Cancel = true;
            }

            if (e.NewValue > 8000)
            {
                this.stepCountRange.Background = new SolidColorBrush(Color.FromArgb(0xff, 0x4c, 0xaf, 0x4f));
            }
            else if (e.NewValue > 4000)
            {
                this.stepCountRange.Background = new SolidColorBrush(Color.FromArgb(0xff, 0xff, 0xeb, 0x3b));
            }
            else
            {
                this.stepCountRange.Background = new SolidColorBrush(Color.FromArgb(0xff, 0xf4, 0x43, 0x36));
            }
        }

        /// <summary>
        /// To dispose the events.
        /// </summary>
        public void Dispose()
        {
            this.stepCountShapePointer.ValueChanging -= this.stepCountShapePointer_ValueChanging;
#if WinUI_Desktop
            this.gauge.Dispose();
#endif
        }
    }

    public class StepsToKMConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((double)value / 1310).ToString("N2");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }

    public class StepsToCaloriesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((double)value * 0.04).ToString("N2");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}