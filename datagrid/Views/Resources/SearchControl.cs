#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.DataGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.UI.Xaml.Input;
using Windows.System;
using Windows.UI.Core;
using System.Reflection;

namespace DataGrid
{
    /// <summary>
    /// Represents the class that helps to Search the Text in the DataGrid.
    /// </summary>
    [TemplatePart(Name = "PART_FindNextButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_FindPreviousButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_CloseButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_ApplyFilteringCheckBox", Type = typeof(CheckBox))]
    [TemplatePart(Name = "PART_ComboBox", Type = typeof(ComboBox))]
    [TemplatePart(Name = "PART_ClearButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_SearchTextBox", Type = typeof(TextBox))]
    [TemplatePart(Name = "PART_CaseSensitiveSearchCheckBox", Type = typeof(CheckBox))]
    [TemplatePart(Name = "PART_SarchControlRootBorder", Type = typeof(Border))]
    public class SearchControl : Control,IDisposable
    {
        #region Fields
        internal Button findNextButton;
        internal Button findPreviousButton;
        internal Button closeButton;
        internal TextBox searchTextBox;
        internal CheckBox applyFilterCheckBox;
        internal CheckBox caseSensitiveSearchCheckBox;
        internal ComboBox comboBox;
        internal Border searchControlBorder;
        internal Button clearButton;
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the DataGrid for the corresponding search operation.
        /// </summary>
        public SfDataGrid DataGrid
        {
            get { return (SfDataGrid)GetValue(DataGridProperty); }
            set { SetValue(DataGridProperty, value); }
        }
        public static readonly DependencyProperty DataGridProperty =
            DependencyProperty.Register("DataGrid", typeof(SfDataGrid), typeof(SearchControl), new PropertyMetadata(null));

        #endregion

        #region Ctor

        public SearchControl()
        {
            this.DefaultStyleKey = typeof(SearchControl);
        }

        public SearchControl(SfDataGrid datagrid)
        {
            DataGrid = datagrid;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the DetailsViewDefinition index of the given DataGrid.
        /// </summary>
        /// <param name="dataGrid">The SfDataGrid</param>
        /// <param name="actualRowIdx"></param>
        /// <returns>Returns the DetailsView Index</returns>
        private int GetDetailsViewDefinitionIndex(SfDataGrid dataGrid, int actualRowIdx)
        {
            var counter0 = 0;
            for (int i = actualRowIdx; i > 0; i--)
            {
                if (!dataGrid.IsInDetailsViewIndex(i))
                {
                    break;
                }
                counter0++;
            }
            return counter0;
        }

        /// <summary>
        /// Used to decide whether open or close the Search Control.
        /// </summary>
        /// <param name="visible">Used to set whether we need to set visible for SearchCotrol or not.</param>
        internal void UpdateSearchControlVisiblity(bool visible)
        {
            if (visible)
            {
                if (this.DataGrid.SelectedDetailsViewGrid != null)
                {
                    var detailsViewIndex = this.DataGrid.GetGridDetailsViewRowIndex(this.DataGrid.SelectedDetailsViewGrid as DetailsViewDataGrid);
                    comboBox.SelectedIndex = this.GetDetailsViewDefinitionIndex(this.DataGrid, detailsViewIndex - 1) + 1;
                }
                else
                    comboBox.SelectedIndex = 0;
                this.Visibility = Visibility.Visible;
                this.searchTextBox.Focus(FocusState.Programmatic);
            }
            else
            {
                this.Visibility = Visibility.Collapsed;
                this.searchTextBox.Text = "";
                this.DataGrid.SearchHelper.ClearSearch();
                this.DataGrid.Focus(FocusState.Programmatic);
            }
        }

        /// <summary>
        /// Builds the visual tree for the SearchControl when a template is applied.
        /// </summary>
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            findNextButton = this.GetTemplateChild("PART_FindNextButton") as Button;
            findPreviousButton = this.GetTemplateChild("PART_FindPreviousButton") as Button;
            closeButton = this.GetTemplateChild("PART_CloseButton") as Button;
            clearButton = this.GetTemplateChild("PART_ClearButton") as Button;
            applyFilterCheckBox = this.GetTemplateChild("PART_ApplyFilteringCheckBox") as CheckBox;
            comboBox = this.GetTemplateChild("PART_ComboBox") as ComboBox;
            searchTextBox = this.GetTemplateChild("PART_SearchTextBox") as TextBox;
            searchControlBorder = this.GetTemplateChild("PART_SarchControlRootBorder") as Border;
            caseSensitiveSearchCheckBox = this.GetTemplateChild("PART_CaseSensitiveSearchCheckBox") as CheckBox;
            this.searchTextBox.Focus(FocusState.Programmatic);
            this.WireEvents();
        }

        #endregion

        #region Events

        /// <summary>
        /// Used to wire the events for searchcontrol.
        /// </summary>
        private void WireEvents()
        {
            findNextButton.Click += OnFindNextButtonClick;
            findPreviousButton.Click += OnFindPreviousButtonClick;
            closeButton.Click += OnCloseButtonClick;
            clearButton.Click += OnClearButtonClick;
            searchTextBox.TextChanged += OnTextChanged;
            applyFilterCheckBox.Click += OnApplyFilterCheckBoxClick;
            caseSensitiveSearchCheckBox.Click += OnCaseSensitiveSearchCheckBoxClick;
            comboBox.SelectionChanged += OnComboBoxSelectionChanged;
            searchControlBorder.PreviewKeyDown += OnPreviewKeyDown;
        }

        /// <summary>Event handler that handle click event for Close button.</summary>
        /// <param name="sender">The sender is a source of the event object.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> contains the event data.</param>
        private void OnClearButtonClick(object sender, RoutedEventArgs e)
        {
            this.searchTextBox.Text = "";
            var item = this.comboBox.SelectedItem;
            if (item != null)
                this.GetDataGrid(item.ToString()).SearchHelper.ClearSearch();
        }

        /// <summary>Invoked when the <see cref="UIElement.PreviewKeyDown"/> attached event raised in SearchControl. </summary>
        /// <param name="e">The <see cref="KeyEventArgs"/> that contains the event data. </param>
        private void OnPreviewKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if ((e.Key == VirtualKey.F) && (Microsoft.UI.Input.InputKeyboardSource.GetKeyStateForCurrentThread(VirtualKey.Control).HasFlag(CoreVirtualKeyStates.Down)))
                UpdateSearchControlVisiblity(true);
            else if (e.Key == VirtualKey.Escape)
                UpdateSearchControlVisiblity(false);
        }

        /// <summary>Event handler to handle CaseSensitive search check box click.</summary>
        /// <param name="sender">The sender is a source of the event object.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> contains the event data.</param>
        private void OnCaseSensitiveSearchCheckBoxClick(object sender, RoutedEventArgs e)
        {
            var item = this.comboBox.SelectedItem;
            if (item == null)
                return;
            var grid = this.GetDataGrid(item.ToString());
            grid.SearchHelper.AllowCaseSensitiveSearch = (bool)this.caseSensitiveSearchCheckBox.IsChecked;
        }


        /// <summary>Event handler that handle the text value is changed event for SearchTextBox.</summary>
        /// <param name="sender">The sender is a source of the event object.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> contains the event data.</param>
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var item = this.comboBox.SelectedItem;
            if (item == null)
                return;
            var grid = this.GetDataGrid(item.ToString());
            grid.SearchHelper.Search(searchTextBox.Text);
        }


        /// <summary>Event handler that handle click event for FindNext button.</summary>
        /// <param name="sender">The sender is a source of the event object.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> contains the event data.</param>
        private void OnFindNextButtonClick(object sender, RoutedEventArgs e)
        {
            var item = this.comboBox.SelectedItem;
            if (item == null)
                return;
            var grid = this.GetDataGrid(item.ToString());
            grid.SearchHelper.FindNext(searchTextBox.Text);
        }


        /// <summary>Event handler that handle click event for FindPrevious button.</summary>
        /// <param name="sender">The sender is a source of the event object.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> contains the event data.</param>
        private void OnFindPreviousButtonClick(object sender, RoutedEventArgs e)
        {
            var item = this.comboBox.SelectedItem;
            if (item == null)
                return;
            var grid = this.GetDataGrid(item.ToString());
            grid.SearchHelper.FindPrevious(searchTextBox.Text);
        }

        /// <summary>Event handler that handle click event for Close button.</summary>
        /// <param name="sender">The sender is a source of the event object.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> contains the event data.</param>
        private void OnCloseButtonClick(object sender, RoutedEventArgs e)
        {
            this.searchTextBox.Text = "";
            var item = this.comboBox.SelectedItem;
            if (item != null)
                this.GetDataGrid(item.ToString()).SearchHelper.ClearSearch();
            this.Visibility = Visibility.Collapsed;
            this.DataGrid.Focus(FocusState.Programmatic);
        }


        /// <summary>Event handler to handle ApplyFilter check box click.</summary>
        /// <param name="sender">The sender is a source of the event object.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> contains the event data.</param>
        private void OnApplyFilterCheckBoxClick(object sender, RoutedEventArgs e)
        {
            var item = this.comboBox.SelectedItem;
            if (item == null)
                return;
            var grid = this.GetDataGrid(item.ToString());
            grid.SearchHelper.AllowFiltering = (bool)this.applyFilterCheckBox.IsChecked;
        }


        /// <summary>Event handler to handle selection changes in DataGrid combo box. </summary>
        /// <param name="sender">The sender is a source of the event object.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> contains the event data.</param>
        private void OnComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var oldItem = e.RemovedItems[0];
            var newItem = e.AddedItems[0];
            if (oldItem == null || newItem == null)
                return;
            var oldGrid = this.GetDataGrid(oldItem.ToString());
            var newGrid = this.GetDataGrid(newItem.ToString());
            oldGrid.SearchHelper.ClearSearch();
            newGrid.SearchHelper.AllowFiltering = (bool)this.applyFilterCheckBox.IsChecked;
            newGrid.SearchHelper.AllowCaseSensitiveSearch = (bool)this.caseSensitiveSearchCheckBox.IsChecked;
            newGrid.SearchHelper.Search(searchTextBox.Text);
        }

        /// <summary>Method to return the DataGrid which Selected in the ComboBox.</summary>
        /// <param name="item">The item denotes the levels of DataGrid.</param>
        /// <returns>Returns which datagrid is selected in the combobox.</returns>
        private SfDataGrid GetDataGrid(string item)
        {
            switch (item)
            {
                case "Search First-Level Grid":
                    return (this.DataGrid.DetailsViewDefinition[0] as GridViewDefinition).DataGrid;
                default:
                    return this.DataGrid;
            }
        }
        #endregion

        /// <summary>
        /// Used to unwire the wired events.
        /// </summary>
        private void UnWireEvents()
        {
            findNextButton.Click -= OnFindNextButtonClick;
            findPreviousButton.Click -= OnFindPreviousButtonClick;
            closeButton.Click -= OnCloseButtonClick;
            searchTextBox.TextChanged -= OnTextChanged;
            applyFilterCheckBox.Click -= OnApplyFilterCheckBoxClick;
            comboBox.SelectionChanged -= OnComboBoxSelectionChanged;
            searchControlBorder.PreviewKeyDown -= OnPreviewKeyDown;
            clearButton.Click -= OnClearButtonClick;
        }

        /// <summary>
        /// Used to dispose the all unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.UnWireEvents();
            this.DataGrid = null;
            this.findNextButton = null;
            this.findPreviousButton = null;
            this.closeButton = null;
            this.comboBox = null;
            this.searchTextBox = null;
            this.applyFilterCheckBox = null;
            this.caseSensitiveSearchCheckBox = null;
            this.clearButton = null;
        }
    }
    public static class SearchControlResource
    {
        public static ResourceDictionary Resource
        {
            get
            {
                string assemblyName = Assembly.GetEntryAssembly().GetName().Name;

                if (assemblyName.Equals("syncfusion.samplebrowser.winui"))
                {
                    return new ResourceDictionary { Source = new Uri("ms-appx:///syncfusion.datagriddemos.winui/Views/Resources/Search.xaml", UriKind.RelativeOrAbsolute) };
                }
                else
                {
                    return new ResourceDictionary { Source = new Uri("ms-appx:///Views/Resources/Search.xaml", UriKind.RelativeOrAbsolute) };
                }
            }
        }
    }
}
