#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;
using System;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Syncfusion.EditorDemos.WinUI.Views.ColorPalette
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ColorPaletteView : Page, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ColorPaletteView"/> class.
        /// This constructor calls <see cref="InitializeComponent"/> to load the XAML UI definitions
        /// and subscribes to the PointerPressed event for the `colorPaletteViewPanel`.
        /// </summary>
        public ColorPaletteView()
        {
            this.InitializeComponent();
            colorPaletteViewPanel.PointerPressed += OnColorPaletteViewPanelPointerPressed;
        }

        private void OnColorPaletteViewPanelPointerPressed(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            // To restrict the focus on first control when clicking on empty area.
            e.Handled = true;
        }

        /// <summary>
        /// To dispose objects.
        /// </summary>
        public void Dispose()
        {
            if (colorPalette1 != null)
            {
                this.colorPalette1.Dispose();
            }

            if (colorPalette2 != null)
            {
                this.colorPalette2.Dispose();
            }

            if (colorPalette3 != null)
            {
                this.colorPalette3.Dispose();
            }

            if (this.colorPaletteViewPanel != null)
            {
                this.colorPaletteViewPanel.PointerPressed -= OnColorPaletteViewPanelPointerPressed;
            }

            this.Resources.Clear();
            this.DataContext = null;
        }
    }
}
