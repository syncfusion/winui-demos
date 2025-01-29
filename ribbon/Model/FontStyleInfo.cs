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
    public class FontStyleInfo
    {
        public string FontText { get; set; }
        public string FontDescription { get; set; }

        private FontWeight fontWeight = FontWeights.Normal;

        public FontWeight FontWeight
        {
            get { return fontWeight; }
            set { fontWeight = value; }
        }

        public FontStyle FontStyle { get; set; }

        private double fontSize = 14;

        public double FontSize
        {
            get { return fontSize; }
            set { fontSize = value; }
        }

        private Thickness margin = new Thickness() { Left = 2, Top = 0, Right = 2, Bottom = 0};

        public Thickness Margin
        {
            get { return margin; }
            set { margin = value; }
        }
    } 
}
