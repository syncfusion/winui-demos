#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Text;
using Windows.UI.Text;

namespace Syncfusion.RibbonDemos.WinUI
{
    /// <summary>
    /// Represents font style information, including font text, description, weight, style, size, and margin.
    /// This class is likely used to configure and display font properties in a UI element.
    /// </summary>
    public class FontStyleInfo
    {
        /// <summary>
        /// Gets or sets the text content associated with the font style (e.g., the text itself or a label).
        /// </summary>
        public string FontText { get; set; }
        /// <summary>
        /// Gets or sets a description for the font style, providing more context.
        /// </summary>
        public string FontDescription { get; set; }

        private FontWeight fontWeight = FontWeights.Normal;

        /// <summary>
        /// Gets or sets the font weight (e.g., Normal, Bold).
        /// </summary>
        public FontWeight FontWeight
        {
            get { return fontWeight; }
            set { fontWeight = value; }
        }

        /// <summary>
        /// Gets or sets the Font Style
        /// </summary>
        public FontStyle FontStyle { get; set; }

        private double fontSize = 14;

        /// <summary>
        /// Gets or sets the font size in device-independent units.
        /// </summary>
        public double FontSize
        {
            get { return fontSize; }
            set { fontSize = value; }
        }

        private Thickness margin = new Thickness() { Left = 2, Top = 0, Right = 2, Bottom = 0};

        /// <summary>
        /// Gets or sets the margin around the element associated with this font style.
        /// </summary>
        public Thickness Margin
        {
            get { return margin; }
            set { margin = value; }
        }
    } 
}
