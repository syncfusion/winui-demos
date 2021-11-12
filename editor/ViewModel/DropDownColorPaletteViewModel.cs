#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI;
using Microsoft.UI.Xaml.Media;
using Syncfusion.UI.Xaml.Core;

namespace syncfusion.editordemos.winui
{
    public class DropDownColorPaletteViewModel : NotificationObject
    {
        private Brush selectedBrush = new SolidColorBrush(Colors.Blue);
        private Brush foregroundBrush = new SolidColorBrush(Colors.Blue);
        private Brush backgroundBrush = new SolidColorBrush(Colors.Yellow);

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
    }
}
