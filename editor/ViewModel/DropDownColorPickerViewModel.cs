#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI;
using Microsoft.UI.Xaml.Media;
using Syncfusion.UI.Xaml.Core;
using Windows.UI.WebUI;

namespace Syncfusion.EditorDemos.WinUI
{
    public class DropDownColorPickerViewModel : NotificationObject
    {
        private Brush solidBrush = new SolidColorBrush(Colors.Blue);
        private Brush foregroundBrush = new SolidColorBrush(Colors.Blue);
        private Brush backgroundBrush = new SolidColorBrush(Colors.Yellow);
        private Brush gradientBrush;

        public DropDownColorPickerViewModel()
        {
            GradientStopCollection gradientStops = new GradientStopCollection();
            gradientStops.Add(new GradientStop() { Color = Colors.Blue, Offset = 1 });
            gradientStops.Add(new GradientStop() { Color = Colors.White, Offset = 0 });
            gradientBrush = new LinearGradientBrush() { GradientStops = gradientStops };
        }

        public Brush SolidBrush
        {
            get
            {
                return solidBrush;
            }
            set
            {
                if (solidBrush != value)
                {
                    solidBrush = value;
                    this.RaisePropertyChanged(nameof(this.SolidBrush));
                }
            }
        }

        public Brush ForegroundBrush
        {
            get
            {
                return foregroundBrush;
            }
            set
            {
                if (foregroundBrush != value)
                {
                    foregroundBrush = value;
                    this.RaisePropertyChanged(nameof(this.ForegroundBrush));
                }
            }
        }

        public Brush BackgroundBrush
        {
            get
            {
                return backgroundBrush;
            }
            set
            {
                if (backgroundBrush != value)
                {
                    backgroundBrush = value;
                    this.RaisePropertyChanged(nameof(this.BackgroundBrush));
                }
            }
        }

        public Brush GradientBrush
        {
            get
            {
                return gradientBrush;
            }
            set
            {
                if (gradientBrush != value)
                {
                    gradientBrush = value;
                    this.RaisePropertyChanged(nameof(this.GradientBrush));
                }
            }
        }
    }
}
