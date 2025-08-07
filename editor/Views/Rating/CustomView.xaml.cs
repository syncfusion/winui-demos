#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Syncfusion.UI.Xaml.Editors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.EditorDemos.WinUI.Views.Rating
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomView : Page
    {
        public CustomView()
        {
            this.InitializeComponent();
        }

        private void EmojiRating_ValueChanged(object sender, RatingValueChangedEventArgs e)
        {
            if (RatingText == null) return;

            switch (emojiRating.Value)
            {
                case 1:
                    RatingText.Text = "Sad";
                    break;
                case 2:
                    RatingText.Text = "Unhappy";
                    break;
                case 3:
                    RatingText.Text = "Neutral";
                    break;
                case 4:
                    RatingText.Text = "Happy";
                    break;
                case 5:
                    RatingText.Text = "Excited";
                    break;
                default:
                    RatingText.Text = "No Rating";
                    break;
            }
        }
    }
}
