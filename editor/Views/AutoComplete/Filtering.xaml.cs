#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace syncfusion.editordemos.winui.Views.AutoComplete
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Filtering : Page, IDisposable
    {
        public Filtering()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// To dispose objects.
        /// </summary>
        public void Dispose()
        {
            if (this.FilterAutoComplete != null)
            {
                this.FilterAutoComplete.Dispose();
            }

            if (this.CustomFilterAutoComplete != null)
            {
                this.CustomFilterAutoComplete.Dispose();
            }

            if (this.asyncAutoComplete != null)
            {
                this.asyncAutoComplete.Dispose();
            }

            if (this.SearchAutoComplete != null)
            {
                this.SearchAutoComplete.Dispose();
            }

            this.Resources.Clear();
            this.DataContext = null;
        }
    }
      
}
