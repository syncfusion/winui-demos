#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Linq;
using System.Reflection;

namespace Syncfusion.DemosCommon.WinUI
{
    /// <summary>
    /// A markup extension that returns a ImageSource
    /// </summary>
    [MarkupExtensionReturnType(ReturnType = typeof(BitmapImage))]
    public class ImagePathExtension : MarkupExtension
    {
        /// <summary>
        /// Gets or sets the ImagePath for common sample browser.
        /// </summary>
        public string Common { get; set; }

        /// <summary>
        /// Gets or sets the ImagePath for individual sample browser.
        /// </summary>
        public string Individual { get; set; }

        /// <inheritdoc/>
        protected override object ProvideValue()
        {
            string imagePath;
#if Main_SB
            imagePath = Common;
#else
            imagePath = string.Join("/", Individual.Split('/').Skip(1).ToArray());
#endif

            if (string.IsNullOrEmpty(imagePath))
            {
                throw new ArgumentException("Provide valid resource name on ImagePath");
            }

            return new BitmapImage() { UriSource = new Uri($"ms-appx:///{imagePath}", UriKind.Absolute) };
        }
    }
}
