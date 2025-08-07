#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Syncfusion.UI.Xaml.Core;
using Syncfusion.UI.Xaml.Editors;

namespace Syncfusion.EditorDemos.WinUI
{
    public class ColorPickerViewModel : NotificationObject
    {
        private ColorInputOptions alphaInputOptions = ColorInputOptions.All;
        private ColorInputOptions colorChannelInputOptions = ColorInputOptions.All;
        private ColorEditorsVisibilityMode colorEditorsVisibilityMode = ColorEditorsVisibilityMode.Inline;
        private Brush selectedBrush;
        private BrushTypeOptions brushTypeOptions = BrushTypeOptions.All;
        private ColorSpectrumComponents colorSpectrumComponents = ColorSpectrumComponents.HueSaturation;
        private ColorSpectrumShape colorSpectrumShape = ColorSpectrumShape.Box;
        private AxisInputOption axisInputOption = AxisInputOption.Simple;
        private Brush selectedColor;
        private string colorChannelOptions = "All";
        private bool enableAxisInputOption = false;

        public ColorInputOptions AlphaInputOptions
        {
            get
            {
                return alphaInputOptions;
            }
            set
            {
                if (alphaInputOptions != value)
                {
                    alphaInputOptions = value;
                    this.RaisePropertyChanged(nameof(this.AlphaInputOptions));
                }
            }
        }

        public ColorInputOptions ColorChannelInputOptions
        {
            get 
            { 
                return colorChannelInputOptions; 
            }
            set
            {
                if (colorChannelInputOptions != value)
                {
                    colorChannelInputOptions = value;
                    this.RaisePropertyChanged(nameof(this.ColorChannelInputOptions));
                }
            }
        }

        public ColorEditorsVisibilityMode ColorEditorsVisibilityMode
        {
            get
            {
                return colorEditorsVisibilityMode;
            }
            set
            {
                if (colorEditorsVisibilityMode != value)
                {
                    colorEditorsVisibilityMode = value;
                    this.RaisePropertyChanged(nameof(this.ColorEditorsVisibilityMode));
                }
            }
        }

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

        public BrushTypeOptions BrushTypeOptions
        {
            get
            {
                return brushTypeOptions;
            }
            set
            {
                if (brushTypeOptions != value)
                {
                    brushTypeOptions = value;
                    this.RaisePropertyChanged(nameof(this.BrushTypeOptions));
                }
            }
        }

        public ColorSpectrumComponents ColorSpectrumComponents
        {
            get
            {
                return colorSpectrumComponents;
            }
            set
            {
                if (colorSpectrumComponents != value)
                {
                    colorSpectrumComponents = value;
                    this.RaisePropertyChanged(nameof(this.ColorSpectrumComponents));
                }
            }
        }

        public ColorSpectrumShape ColorSpectrumShape
        {
            get
            {
                return colorSpectrumShape;
            }
            set
            {
                if (colorSpectrumShape != value)
                {
                    colorSpectrumShape = value;
                    this.RaisePropertyChanged(nameof(this.ColorSpectrumShape));
                }
            }
        }

        public AxisInputOption AxisInputOption
        {
            get
            {
                return axisInputOption;
            }
            set
            {
                if (axisInputOption != value)
                {
                    axisInputOption = value;
                    this.RaisePropertyChanged(nameof(this.AxisInputOption));
                }
            }
        }

        public Brush SelectedColor
        {
            get
            {
                return selectedColor;
            }
            set
            {
                if (selectedColor != value)
                {
                    selectedColor = value;
                    this.RaisePropertyChanged(nameof(this.SelectedColor));
                    this.EnableAxisInputOption = selectedColor is LinearGradientBrush || selectedColor is RadialGradientBrush;
                }
            }
        }

        public string ColorChannelOptions
        {
            get
            {
                return colorChannelOptions;
            }
            set
            {
                if (colorChannelOptions != value)
                {
                    colorChannelOptions = value;
                    this.RaisePropertyChanged(nameof(this.ColorChannelOptions));
                }
            }
        }

        public bool EnableAxisInputOption
        {
            get
            {
                return enableAxisInputOption;
            }
            set
            {
                if (enableAxisInputOption != value)
                {
                    enableAxisInputOption = value;
                    this.RaisePropertyChanged(nameof(this.EnableAxisInputOption));
                }
            }
        }
    }
}
