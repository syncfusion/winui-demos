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
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
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
            var datacontext = new EmployeeViewModel();
            this.DataContext = datacontext;
            this.PasteOptionListBox.SelectionChanged += PasteOptionListBox_SelectionChanged; ;
            this.CopyOptionListBox.SelectionChanged += CopyOptionListBox_SelectionChanged;
            this.CopyOptionListBox.Loaded += CopyOptionListBox_Loaded;
            this.PasteOptionListBox.Loaded += PasteOptionListBox_Loaded;
            this.sfDataGrid.ItemsSource = datacontext.Employees;
        }       

        /// <summary>
        /// Set the default value for paste option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasteOptionListBox_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            PasteOptionListBox.SelectedIndex = 1;
        }

        /// <summary>
        /// Set the default value for copy option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyOptionListBox_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            CopyOptionListBox.SelectedIndex = 1;
        }

        /// <summary>
        /// Set the value for CopyOption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyOptionListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var data = (sender as ListBox);
            var selecteditem = data.SelectedItems;
            if (data.SelectedItems != null)
            {
                for (int i = 0; i < selecteditem.Count; i++)
                {
                    if (i == 0)
                        this.sfDataGrid.CopyOption = (GridCopyOptions)selecteditem[i];
                    else
                        this.sfDataGrid.CopyOption = this.sfDataGrid.CopyOption | (GridCopyOptions)selecteditem[i];
                }
            }
        }

        /// <summary>
        /// Set the value for Paste Option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasteOptionListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var data = (sender as ListBox);
            var selecteditem = data.SelectedItems;
            if (data.SelectedItems != null)
            {

                for (int i = 0; i < selecteditem.Count; i++)
                {
                    if (i == 0)
                        this.sfDataGrid.PasteOption = (GridPasteOptions)selecteditem[i];
                    else
                        this.sfDataGrid.PasteOption = this.sfDataGrid.PasteOption | (GridPasteOptions)selecteditem[i];
                }
            }
        }

        /// <summary>
        /// Dispose of unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Resources.Clear();
            this.PasteOptionListBox.SelectionChanged -= PasteOptionListBox_SelectionChanged; ;
            this.CopyOptionListBox.SelectionChanged -= CopyOptionListBox_SelectionChanged;
            this.CopyOptionListBox.Loaded -= CopyOptionListBox_Loaded;
            this.PasteOptionListBox.Loaded -= PasteOptionListBox_Loaded;
            if (this.sfDataGrid != null)
            {
                this.sfDataGrid.Dispose();
                this.sfDataGrid = null;
                this.DataContext = null;
            }
        }
    }
}
