#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
using Syncfusion.UI.Xaml.DataGrid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace DataGrid
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AutoRowHeight : Page, IDisposable
    {
        GridRowSizingOptions gridRowResizingOptions = new GridRowSizingOptions();
        double autoHeight = double.NaN;
        List<string> excludeColumns = new List<string>() { "Location", "Trustworthiness", "Status", "Salary" };
        public AutoRowHeight()
        {
            this.InitializeComponent();
            this.sfDataGrid.QueryRowHeight += SfDataGrid_QueryRowHeight;
            gridRowResizingOptions.ExcludeColumns = excludeColumns;
        }
        private void SfDataGrid_QueryRowHeight(object sender, QueryRowHeightEventArgs e)
        {
            if (this.sfDataGrid.ColumnSizer.GetAutoRowHeight(e.RowIndex, gridRowResizingOptions, out autoHeight))
            {
                e.Height = (autoHeight > this.sfDataGrid.RowHeight) ? autoHeight : this.sfDataGrid.RowHeight;
                e.Handled = true;
            }
        }

        public void Dispose()
        {
            this.Resources.Clear();
            this.sfDataGrid.QueryRowHeight -= SfDataGrid_QueryRowHeight;
            if (this.sfDataGrid != null)
            {
                this.sfDataGrid.Dispose();
            }
        }
    }
}
