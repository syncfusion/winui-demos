#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Syncfusion.UI.Xaml.Core;
using Syncfusion.UI.Xaml.Editors;
using System.Windows.Input;

namespace Syncfusion.EditorDemos.WinUI
{
    /// <summary>
    /// ViewModel for the Color Palette control, managing its states, properties, and commands.
    /// It handles visibility of various buttons and headers, selected colors, and manages color palette data.
    /// This class inherits from <see cref="NotificationObject"/>, implying it supports property change notifications.
    /// </summary>
    public class ColorPaletteViewModel : NotificationObject
    {
        private bool showDefaultColorButton = true;
        private bool showMoreColorsButton = true;
        private bool showNoColorButton;
        private Brush selectedBrush;
        private ColorPaletteNames activePalette;
        private bool showPaletteColorsHeader = true;
        private ColorPaletteModel paletteColors = new ColorPaletteModel();
        private Brush selecteColor;
        private StandardPaletteModel standardColors = new StandardPaletteModel();
        private Brush selectedColorValue;
        private ICommand paletteCommand;
        private ICommand standardCommand;
        private bool allowPaletteColorShadesSpacing = true;
        private bool allowStandardColorShadesSpacing = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorPaletteViewModel"/> class.
        /// Sets up delegate commands for managing color shade spacing based on palette and standard color visibility.
        /// </summary>
        public ColorPaletteViewModel()
        {
            this.PaletteCommand = new DelegateCommand(this.EnablePaletteColorShadesSpacing);
            this.StandardCommand = new DelegateCommand(this.EnableStandardColorShadesSpacing);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the default color button is visible.
        /// </summary>
        public bool ShowDefaultColorButton
        {
            get 
            {
                return showDefaultColorButton; 
            }
            set 
            {
                if (this.showDefaultColorButton != value)
                {
                    this.showDefaultColorButton = value;
                    this.RaisePropertyChanged(nameof(this.ShowDefaultColorButton));
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the "More Colors" button is visible.
        /// </summary>
        public bool ShowMoreColorsButton
        {
            get
            {
                return showMoreColorsButton;
            }
            set
            {
                if (this.showMoreColorsButton != value)
                {
                    this.showMoreColorsButton = value;
                    this.RaisePropertyChanged(nameof(this.ShowMoreColorsButton));
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the "No Color" button is visible.
        /// </summary>
        public bool ShowNoColorButton
        {
            get
            {
                return showNoColorButton;
            }
            set
            {
                if (this.showNoColorButton != value)
                {
                    this.showNoColorButton = value;
                    this.RaisePropertyChanged(nameof(this.ShowNoColorButton));
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
                if (this.selectedBrush != value)
                {
                    this.selectedBrush = value;
                    this.RaisePropertyChanged(nameof(this.SelectedBrush));
                }
            }
        }

        /// <summary>
        /// Gets or sets the currently active color palette type.
        /// </summary>
        public ColorPaletteNames ActivePalette
        {
            get
            {
                return activePalette;
            }
            set
            {
                if (this.activePalette != value)
                {
                    this.activePalette = value;
                    this.RaisePropertyChanged(nameof(this.ActivePalette));
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the header for palette colors should be displayed.
        /// </summary>
        public bool ShowPaletteColorsHeader
        {
            get
            {
                return showPaletteColorsHeader;
            }
            set
            {
                if (this.showPaletteColorsHeader != value)
                {
                    this.showPaletteColorsHeader = value;
                    this.RaisePropertyChanged(nameof(this.ShowPaletteColorsHeader));
                }
            }
        }

        /// <summary>
        /// Gets or sets the model containing data for palette colors.
        /// </summary>
        public ColorPaletteModel PaletteColors
        {
            get
            {
                return paletteColors;
            }
            set
            {
                if (this.paletteColors != value)
                {
                    this.paletteColors = value;
                    this.RaisePropertyChanged(nameof(this.PaletteColors));
                }
            }
        }

        /// <summary>
        /// Gets or sets the selected color value. Note: This property name 'SelecteColor' contains a typo.
        /// </summary>
        public Brush SelecteColor
        {
            get
            {
                return selecteColor;
            }
            set
            {
                if (this.selecteColor != value)
                {
                    this.selecteColor = value;
                    this.RaisePropertyChanged(nameof(this.SelecteColor));
                }
            }
        }

        /// <summary>
        /// Gets or sets the model containing data for standard colors.
        /// </summary>
        public StandardPaletteModel StandardColors
        {
            get
            {
                return standardColors;
            }
            set
            {
                if (this.standardColors != value)
                {
                    this.standardColors = value;
                    this.RaisePropertyChanged(nameof(this.StandardColors));
                }
            }
        }

        /// <summary>
        /// Gets or sets the selected color value, likely intended to be the primary selected color.
        /// </summary>
        public Brush SelectedColorValue
        {
            get
            {
                return selectedColorValue;
            }
            set
            {
                if (this.selectedColorValue != value)
                {
                    this.selectedColorValue = value;
                    this.RaisePropertyChanged(nameof(this.SelectedColorValue));
                }
            }
        }

        /// <summary>
        /// Gets or sets the command to execute when interacting with palette color actions.
        /// </summary>
        public ICommand PaletteCommand
        {
            get
            {
                return paletteCommand;
            }
            set
            {
                if (this.paletteCommand != value)
                {
                    this.paletteCommand = value;
                    this.RaisePropertyChanged(nameof(this.PaletteCommand));
                }
            }
        }

        /// <summary>
        /// Gets or sets the command to execute when interacting with standard color actions.
        /// </summary>
        public ICommand StandardCommand
        {
            get
            {
                return standardCommand;
            }
            set
            {
                if (this.standardCommand != value)
                {
                    this.standardCommand = value;
                    this.RaisePropertyChanged(nameof(this.StandardCommand));
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether spacing is allowed between shades for palette colors.
        /// </summary>
        public bool AllowPaletteColorShadesSpacing
        {
            get
            {
                return allowPaletteColorShadesSpacing;
            }
            set
            {
                if (this.allowPaletteColorShadesSpacing != value)
                {
                    this.allowPaletteColorShadesSpacing = value;
                    this.RaisePropertyChanged(nameof(this.AllowPaletteColorShadesSpacing));
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether spacing is allowed between shades for standard colors.
        /// </summary>
        public bool AllowStandardColorShadesSpacing
        {
            get
            {
                return allowStandardColorShadesSpacing;
            }
            set
            {
                if (this.allowStandardColorShadesSpacing != value)
                {
                    this.allowStandardColorShadesSpacing = value;
                    this.RaisePropertyChanged(nameof(this.AllowStandardColorShadesSpacing));
                }
            }
        }

        /// <summary>
        /// Enables or disables spacing for palette color shades based on the visibility of color-related properties in the PaletteColors model.
        /// This method is executed via the <see cref="PaletteCommand"/>.
        /// </summary>
        /// <param name="parameter">Optional parameter (not used).</param>
        private void EnablePaletteColorShadesSpacing(object parameter)
        {
            this.AllowPaletteColorShadesSpacing = 
                this.PaletteColors.ShowColors && this.PaletteColors.ShowColorShades;
        }

        /// <summary>
        /// Enables or disables spacing for standard color shades based on the visibility of color-related properties in the StandardColors model.
        /// This method is executed via the <see cref="StandardCommand"/>.
        /// </summary>
        /// <param name="parameter">Optional parameter (not used).</param>
        private void EnableStandardColorShadesSpacing(object parameter)
        {
            this.AllowStandardColorShadesSpacing = 
                this.StandardColors.ShowColors && this.StandardColors.ShowColorShades;
        }
    }
}
