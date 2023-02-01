#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TreeGrid
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Filtering : Page
    {
        EmployeeViewModel viewModel;
        public Filtering()
        {
            this.InitializeComponent();
            viewModel = this.grid.DataContext as EmployeeViewModel;
            this.sfTreeGrid.Loaded += SfTreeGrid_Loaded;
        }

        private void SfTreeGrid_Loaded(object sender, RoutedEventArgs e)
        {
            if (viewModel != null)
                viewModel.filterChanged = OnFilterChanged;
        }
        /// <summary>
        /// Occurs when the Filter value is changed
        /// </summary>
        private void OnFilterChanged()
        {
            if (this.sfTreeGrid.View != null)
            {
                this.sfTreeGrid.View.Filter = viewModel.FilerRecords;
                this.sfTreeGrid.View.RefreshFilter();
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
            this.Loaded -=  SfTreeGrid_Loaded;
            this.Resources.Clear();
            if (this.sfTreeGrid != null)
            {
                this.sfTreeGrid.Dispose();
            }
            if (this.columnComboBox != null)
                this.columnComboBox = null;

            if (this.numericCombo != null)
                this.numericCombo = null;

            if (this.stringCombo != null)
                this.stringCombo = null;

            if (this.FilterBox != null)
                this.FilterBox = null;

            if (this.filterLevelComboBox != null)
                this.filterLevelComboBox = null;
        }
    }
}
