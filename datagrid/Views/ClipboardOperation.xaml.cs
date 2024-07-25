#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
using Syncfusion.UI.Xaml.DataGrid;
using Windows.ApplicationModel.DataTransfer;
using Syncfusion.UI.Xaml.Grids;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DataGrid
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ClipboardOperation : Page, IDisposable
    {
        public ClipboardOperation()
        {
            this.InitializeComponent();
            this.PasteOptionListView.SelectionChanged += PasteOptionListView_SelectionChanged; 
            this.CopyOptionListView.SelectionChanged += CopyOptionListView_SelectionChanged;
            this.CopyOptionListView.Loaded += CopyOptionListView_Loaded;
            this.PasteOptionListView.Loaded += PasteOptionListView_Loaded;
        }       

        /// <summary>
        /// Set the default value for paste option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasteOptionListView_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            PasteOptionListView.SelectedIndex = 1;
        }

        /// <summary>
        /// Set the default value for copy option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyOptionListView_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            CopyOptionListView.SelectedIndex = 1;
        }

        /// <summary>
        /// Set the value for CopyOption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyOptionListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var data = (sender as ListView);
            var selecteditem = data.SelectedItems;
            if (data.SelectedItems != null)
            {
                for (int i = 0; i < selecteditem.Count; i++)
                {
                    if (selecteditem[i] != null && Enum.TryParse(typeof(GridCopyOptions), selecteditem[i].ToString(), out object result))
                    {
                        if (i == 0)
                            this.sfDataGrid.CopyOption = (GridCopyOptions)result;
                        else
                            this.sfDataGrid.CopyOption = this.sfDataGrid.CopyOption | (GridCopyOptions)result;
                    }
                }
            }
        }

        /// <summary>
        /// Set the value for Paste Option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasteOptionListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var data = (sender as ListView);
            var selecteditem = data.SelectedItems;
            if (data.SelectedItems != null)
            {

                for (int i = 0; i < selecteditem.Count; i++)
                {
                    if (selecteditem[i] != null && Enum.TryParse(typeof(GridPasteOptions), selecteditem[i].ToString(), out object result))
                    {
                        if (i == 0)
                            this.sfDataGrid.PasteOption = (GridPasteOptions)result;
                        else
                            this.sfDataGrid.PasteOption = this.sfDataGrid.PasteOption | (GridPasteOptions)result;
                    }
                }
            }
        }

        /// <summary>
        /// Dispose of unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Resources.Clear();
            this.PasteOptionListView.SelectionChanged -= PasteOptionListView_SelectionChanged;
            this.CopyOptionListView.SelectionChanged -= CopyOptionListView_SelectionChanged;
            this.CopyOptionListView.Loaded -= CopyOptionListView_Loaded;
            this.PasteOptionListView.Loaded -= PasteOptionListView_Loaded;
            if (this.sfDataGrid != null)
            {
                this.sfDataGrid.Dispose();
            }

            if (this.SelectionUnit != null)
                this.SelectionUnit = null;

            if (this.cmbSelectionMode != null)
                this.cmbSelectionMode = null;

            if (this.CopyOptionListView != null)
                this.CopyOptionListView = null;

            if (this.PasteOptionListView != null)
                this.PasteOptionListView = null;
        }
    }
}
