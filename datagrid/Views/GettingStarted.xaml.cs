#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
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
#if !WinUI_Desktop
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
#endif

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DataGrid
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GettingStarted : Page, IDisposable
    {
        public GettingStarted()
        {
            this.InitializeComponent();
        }
        public void Dispose()
        {
            this.Resources.Clear();
            if (this.sfDataGrid != null)
            {
                this.sfDataGrid.Dispose();
            }

            if (this.allowFilter != null)
                this.allowFilter = null;

            if (this.allowGroup != null)
                this.allowGroup = null;

            if (this.allowSort != null)
                this.allowSort = null;

            if (this.showGroupDropArea != null)
                this.showGroupDropArea = null;

            if (this.columnWidthMode != null)
                this.columnWidthMode = null;

            if (this.gridLinesVisibility != null)
                this.gridLinesVisibility = null;

            if (this.headerLinesVisibility != null)
                this.headerLinesVisibility = null;
        }
    }
}
