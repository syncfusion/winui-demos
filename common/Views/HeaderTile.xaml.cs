#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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
        public HeaderTile()
        {
            this.InitializeComponent();            
        }

        public string Link
        {
            get { return (string)GetValue(LinkProperty); }
            set { SetValue(LinkProperty, value); }
        }
       
        public static readonly DependencyProperty LinkProperty =
            DependencyProperty.Register(nameof(Link), typeof(string), typeof(HeaderTile), new PropertyMetadata(null));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(nameof(Title), typeof(string), typeof(HeaderTile), new PropertyMetadata(null));

        public string Glyph
        {
            get { return (string)GetValue(GlyphProperty); }
            set { SetValue(GlyphProperty, value); }
        }

        public static readonly DependencyProperty GlyphProperty =
            DependencyProperty.Register(nameof(Glyph), typeof(string), typeof(HeaderTile), new PropertyMetadata(null));

    }
}
