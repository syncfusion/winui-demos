#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TreeGrid
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NestedCollection : Page, IDisposable
    {
        public NestedCollection()
        {
            this.InitializeComponent();
        }
        public void Dispose()
        {
            this.Resources.Clear();
            if (this.sfTreeGrid != null)
            {
                this.sfTreeGrid.Dispose();
            }

            if (this.btnCollapse != null)
                this.btnCollapse = null;

            if (this.btnExpand != null)
                this.btnExpand = null;

            if (this.gridLinesVisibility != null)
                this.gridLinesVisibility = null;

            if (this.headerLinesVisibility != null)
                this.headerLinesVisibility = null;
        }
    }
}
