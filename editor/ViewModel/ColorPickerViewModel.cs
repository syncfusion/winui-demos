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
    /// <summary>
    /// ViewModel for managing the state and properties of the ColorPicker control in demos.
    /// This ViewModel controls various aspects of the ColorPicker's appearance and behavior,
    /// such as input options, visibility modes, spectrum settings, and selected colors.
    /// </summary>
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

        /// <summary>
        /// Gets or sets the input options for the alpha channel in the color picker.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the input options for the color channels (e.g., RGB, HSV).
        /// </summary>
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

        /// <summary>
        /// Gets or sets the visibility mode for color editors (e.g., Inline, PopUp).
        /// </summary>
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
        /// Gets or sets the type of brush to be used (e.g., SolidColor, Gradient).
        /// </summary>
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

        /// <summary>
        /// Gets or sets the components displayed in the color spectrum (e.g., HueSaturation, Value).
        /// </summary>
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

        /// <summary>
        /// Gets or sets the shape of the color spectrum (e.g., Box, Ring).
        /// </summary>
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

        /// <summary>
        /// Gets or sets the input option for axes, which might be relevant for gradient or spectrum controls.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the currently selected color, represented as a Brush.
        /// When this value changes, it also updates the `EnableAxisInputOption` property.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the string representation of the selected color channel options (e.g., "All", "RGB").
        /// </summary>
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

        /// <summary>
        /// Gets or sets a value indicating whether axis input options should be enabled.
        /// This is typically controlled by the type of the selected color (e.g., gradients).
        /// </summary>
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
