#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Syncfusion.UI.Xaml.Core;
using Syncfusion.UI.Xaml.Editors;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace syncfusion.editordemos.winui.Views.SegmentedControl
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Customization : Page,IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Customization"/> class.
        /// </summary>
        public Customization()
        {
            this.InitializeComponent();
            this.shirtSize.SetItemEnabled(0, false);
            this.shirtSize.SetItemEnabled(5, false);
        }


        /// <summary>
        /// Method to dispose objects
        /// </summary>
        public void Dispose()
        {
            if (models != null)
            {
                models.Dispose();
            }
            if (colors != null)
            {
                colors.Dispose();
            }
            if (shirtSize != null)
            {
                shirtSize.Dispose();
            }
        }
    }
}
