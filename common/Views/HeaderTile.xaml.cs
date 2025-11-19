#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Syncfusion.DemosCommon.WinUI
{
    /// <summary>
    /// A section page to display demo list under showcase and what's new.
    /// </summary>
    public sealed partial class HeaderTile : Page
    {        
        /// <summary>
        /// Initializes a new instance of the <see cref="HeaderTile"/> class.
        /// Calls <see cref="InitializeComponent"/> to load the XAML UI definitions.
        /// </summary>
        public HeaderTile()
        {
            this.InitializeComponent();            
        }

        /// <summary>
        /// Gets or sets a string representing the link associated with this tile (e.g., a URL).
        /// </summary>
        public string Link
        {
            get { return (string)GetValue(LinkProperty); }
            set { SetValue(LinkProperty, value); }
        }

        /// <summary>
        /// Identifies the Link dependency property.
        /// </summary>
        public static readonly DependencyProperty LinkProperty =
            DependencyProperty.Register(nameof(Link), typeof(string), typeof(HeaderTile), new PropertyMetadata(null));

		/// <summary>
        /// Gets or sets the title text for the header tile.
        /// </summary>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        /// <summary>
        /// Identifies the Title dependency property.
        /// </summary>
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(nameof(Title), typeof(string), typeof(HeaderTile), new PropertyMetadata(null));

		/// <summary>
        /// Gets or sets a string representing a glyph or icon to be displayed on the tile.
        /// </summary>
        public string Glyph
        {
            get { return (string)GetValue(GlyphProperty); }
            set { SetValue(GlyphProperty, value); }
        }

        /// <summary>
        /// Identifies the Glyph dependency property.
        /// </summary>
        public static readonly DependencyProperty GlyphProperty =
            DependencyProperty.Register(nameof(Glyph), typeof(string), typeof(HeaderTile), new PropertyMetadata(null));

		/// <summary>
        /// Gets or sets a descriptive text to be displayed on the header tile.
        /// </summary>
        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        /// <summary>
        /// Identifies the Description dependency property.
        /// </summary>
        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register(nameof(Description), typeof(string), typeof(HeaderTile), new PropertyMetadata(string.Empty));
    }
}
