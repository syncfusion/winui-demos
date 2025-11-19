#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
    /// <summary>
    /// ViewModel for demonstrating the DropDownColorPicker control.
    /// Manages properties related to different types of brushes (Solid, Gradient) and their associated colors (foreground, background).
    /// This class inherits from <see cref="NotificationObject"/> to support property change notifications.
    /// </summary>
    public class DropDownColorPickerViewModel : NotificationObject
    {
        private Brush solidBrush = new SolidColorBrush(Colors.Blue);
        private Brush foregroundBrush = new SolidColorBrush(Colors.Blue);
        private Brush backgroundBrush = new SolidColorBrush(Colors.Yellow);
        private Brush gradientBrush;

        /// <summary>
        /// Initializes a new instance of the <see cref="DropDownColorPickerViewModel"/> class.
        /// Sets up a default linear gradient brush.
        /// </summary>
        public DropDownColorPickerViewModel()
        {
            GradientStopCollection gradientStops = new GradientStopCollection();
            gradientStops.Add(new GradientStop() { Color = Colors.Blue, Offset = 1 });
            gradientStops.Add(new GradientStop() { Color = Colors.White, Offset = 0 });
            gradientBrush = new LinearGradientBrush() { GradientStops = gradientStops };
        }

        /// <summary>
        /// Gets or sets the solid color brush.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the foreground color brush.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the background color brush.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the gradient brush.
        /// </summary>
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
