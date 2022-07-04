#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.Editors;
using System;
using System.Linq;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.EditorDemos.WinUI.Views.ComboBox
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MultiSelection : Page, IDisposable
    {
        public MultiSelection()
        {
            this.InitializeComponent();
            this.customMultipleSelectionBox.SelectedItems.Add(comboBoxViewModel.VegetablesList[1]);
            this.customMultipleSelectionBox.SelectedItems.Add(comboBoxViewModel.VegetablesList[2]);
        }

        private void SelectionComboBox_SelectionChanged(object sender, ComboBoxSelectionChangedEventArgs e)
        {
            var selectionMode = SelectionComboBox.SelectionMode;
            if (selectionMode == ComboBoxSelectionMode.Single)
            {
                if (SelectionComboBox.SelectedItem is string selectedItem)
                {
                    SelectionSelectedItem.Text = selectedItem;
                }
            }
            else if(selectionMode == ComboBoxSelectionMode.Multiple)
            {
                string selectedItems = string.Empty;
                foreach (var item in SelectionComboBox.SelectedItems)
                {
                    if (item is string)
                    {
                        selectedItems += item + "\n";
                    }
                }

                SelectionSelectedItem.Text = selectedItems;
            }

            bool showSelectionOption = (selectionMode == ComboBoxSelectionMode.Single && SelectionComboBox.SelectedItem != null) ||
                                       (selectionMode == ComboBoxSelectionMode.Multiple && SelectionComboBox.SelectedItems.Any());
            SelectionSelectedItem.Visibility = showSelectionOption ? Visibility.Visible : Visibility.Collapsed;
            SelectedItemHeader.Visibility = showSelectionOption ? Visibility.Visible : Visibility.Collapsed;
        }

        private void SelectionMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(SelectionMode.SelectedItem is string selectionMode)
            {
                SelectionSelectedItem.Text = string.Empty;
                if (selectionMode == "Single")
                {
                    SelectedItemHeader.Text = "SelectedItem:";
                }
                else if (selectionMode == "Multiple")
                {
                    SelectedItemHeader.Text = "SelectedItems:";
                }

                this.UpdateOptionsState();
            }
        }
        private void MultiSelectionMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.UpdateOptionsState();
        }

        private void UpdateOptionsState()
        {
            if (SelectionMode.SelectedItem != null)
            {
                MultiSelectionMode.IsEnabled = (SelectionMode.SelectedItem.ToString() == "Multiple");

                if (MultiSelectionMode.SelectedItem != null
                && MultiSelectionMode.SelectedItem.ToString() == "Delimiter"
                && SelectionMode.SelectedItem.ToString() == "Multiple")
                {
                    DelimiterTextBox.IsEnabled = true;
                }
                else
                {
                    DelimiterTextBox.IsEnabled = false;
                }

            }
        }

        /// <summary>
        /// To dispose objects.
        /// </summary>
        public void Dispose()
        {
            if (this.SelectionComboBox != null)
            {
                this.SelectionComboBox.Dispose();
            }

            if (this.customMultipleSelectionBox != null)
            {
                this.customMultipleSelectionBox.Dispose();
            }

            this.Resources.Clear();
            this.DataContext = null;
        }
    }
}
