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

namespace Syncfusion.EditorDemos.WinUI
{
    /// <summary>
    /// ViewModel for demonstrating the DropDownColorPalette control.
    /// Manages properties related to selected colors, including foreground and background brushes.
    /// This class inherits from <see cref="NotificationObject"/> to support property change notifications.
    /// </summary>
    public class DropDownColorPaletteViewModel : NotificationObject
    {
        private Brush selectedBrush = new SolidColorBrush(Colors.Blue);
        private Brush foregroundBrush = new SolidColorBrush(Colors.Blue);
        private Brush backgroundBrush = new SolidColorBrush(Colors.Yellow);

        /// <summary>
        /// Gets or sets the currently selected color as a Brush.
        /// </summary>
        public Brush SelectedBrush
        {
            get
            {
                return selectedBrush;
            }
            set
            {
                if (selectedBrush != value)
                {
                    selectedBrush = value;
                    this.RaisePropertyChanged(nameof(this.SelectedBrush));
                }
            }
        }

        /// <summary>
        /// Gets or sets the foreground color Brush.
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
        /// Gets or sets the background color Brush.
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
    }
}
