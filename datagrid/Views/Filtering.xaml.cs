#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
using Microsoft.UI.Xaml;
using Syncfusion.UI.Xaml.DataGrid;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DataGrid
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Filtering : Page, IDisposable
    {
        EmployeeViewModel viewModel;
        public Filtering()
        {
            this.InitializeComponent();
            viewModel = this.Grid.DataContext as EmployeeViewModel;
            this.Loaded += FilteringLoaded;
        }

        /// <summary>
        /// Occurs when the Filter is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilteringLoaded(object sender, RoutedEventArgs e)
        {
            if(viewModel != null)
              viewModel.filterChanged = OnFilterChanged;
        }

        /// <summary>
        /// Occurs when the Filter value is changed
        /// </summary>
        private void OnFilterChanged()
        {
            if (this.sfDataGrid.View != null)
            {
                this.sfDataGrid.View.Filter = viewModel.FilerRecords;
                this.sfDataGrid.View.RefreshFilter();
            }
        }

        /// <summary>
        /// Occurs when the Filter option is changed
        /// </summary>
        private void FilterOptionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (viewModel != null)
            {
                var comboBox = sender as ComboBox;
                viewModel.FilterOption = (comboBox.SelectedItem as ComboBoxItem).Content.ToString();
                if (viewModel.filterChanged != null)
                    viewModel.filterChanged();
            }
        }

        /// <summary>
        /// Occurs when the Filter condition is changed
        /// </summary>
        private void FilterConditionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (viewModel != null)
            {
                var comboBox = sender as ComboBox;
                if (comboBox.Name == "stringCondition")
                {
                    string input = (comboBox.SelectedItem as ComboBoxItem).Content.ToString();
                    if (input == "Ends With")
                        viewModel.FilterCondition = "EndsWith";
                    else if (input == "Starts With")
                        viewModel.FilterCondition = "StartsWith";
                    else
                        viewModel.FilterCondition = "Contains";
                }
                else
                    viewModel.FilterCondition = (comboBox.SelectedItem as ComboBoxItem).Content.ToString();
                if (viewModel.filterChanged != null)
                    viewModel.filterChanged();
            }
        }

        /// <summary>
        /// Occurs when the Filter text is changed
        /// </summary>
        private void FilterBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            viewModel.FilterText = textBox.Text;
            if (viewModel.filterChanged != null)
                viewModel.filterChanged();
        }

        public void Dispose()
        {
            this.Loaded -= FilteringLoaded;
            this.Resources.Clear();
            if (this.sfDataGrid != null)
            {
                this.sfDataGrid.Dispose();
            }
            if (this.numericCondition != null)
                this.numericCondition= null;
            if (this.stringCondition != null)
                this.stringCondition = null;
            if (this.filterTextBox != null)
                this.filterTextBox = null;
            if (this.columnOption != null)
                this.columnOption = null;
        }
    }
}
