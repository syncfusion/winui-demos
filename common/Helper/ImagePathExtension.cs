#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Linq;
#if WinUI_Desktop
using System.Reflection;
#endif

namespace syncfusion.demoscommon.winui
{
    /// <summary>
    /// A markup extension that returns a ImageSource
    /// </summary>
    [MarkupExtensionReturnType(ReturnType = typeof(BitmapImage))]
    public class ImagePathExtension : MarkupExtension
    {
        /// <summary>
        /// Gets or sets the ImagePath
        /// </summary>
        public string ImagePath { get; set; }

        /// <inheritdoc/>
        protected override object ProvideValue()
        {
            if (string.IsNullOrEmpty(ImagePath))
            {
                throw new ArgumentException("Provide valid resource name on ImagePath");
            }

            BitmapImage bitmapImage = new BitmapImage();
#if WinUI_Desktop
            var entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly != null && entryAssembly.FullName.Contains("samplebrowser"))
            {
                bitmapImage.UriSource = new Uri($"ms-appx:///{ImagePath}", UriKind.Absolute);
            }
            else
#endif
            {

                var imgPath = string.Join("/", ImagePath.Split('/').Skip(1).ToArray());
                bitmapImage.UriSource = new Uri($"ms-appx:///{imgPath}", UriKind.Absolute);
            }

            return bitmapImage;
        }
    }
}
