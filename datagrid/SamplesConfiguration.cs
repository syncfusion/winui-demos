#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.DemosCommon.WinUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syncfusion.DataGridDemos.WinUI
{
   public class SamplesConfiguration
    {
        public SamplesConfiguration()
        {

            DemoInfo gettingstarted = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "Getting Started",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the basic features of the DataGrid control, such as selection, sorting, filtering, grouping, and autofitting columns.",
                DemoView = typeof(DataGrid.GettingStarted),
                ShowInfoPanel = true
            };

            List<Documentation> gettingstartedDocumentations = new List<Documentation>();
            gettingstartedDocumentations.Add(new Documentation() { Content = "DataGrid - API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.html") });
            gettingstartedDocumentations.Add(new Documentation() { Content = "DataGrid - Getting Started Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/getting-started") });
            gettingstartedDocumentations.Add(new Documentation() { Content = "DataGrid - Selection Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/selection") });
            gettingstartedDocumentations.Add(new Documentation() { Content = "DataGrid - Sorting Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/sorting") });
            gettingstartedDocumentations.Add(new Documentation() { Content = "DataGrid - Filtering Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/filtering") });
            gettingstartedDocumentations.Add(new Documentation() { Content = "DataGrid - Grouping Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/grouping") });
            gettingstartedDocumentations.Add(new Documentation() { Content = "DataGrid - Editing Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/editing") });
            gettingstartedDocumentations.Add(new Documentation() { Content = "DataGrid - CRUD Operations Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/crud-operations") });
            gettingstartedDocumentations.Add(new Documentation() { Content = "DataGrid - Printing Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/printing") });


            gettingstarted.Documentation.AddRange(gettingstartedDocumentations);

            DemoInfo selection = new DemoInfo()
            {
                Name = "Selection",
                Category = "Selection",
                DemoType = DemoTypes.None,
                Description = "The DataGrid control provides support to select rows and cells in different modes. Select one or more rows or cells programmatically or by mouse and keyboard interaction.",
                DemoView = typeof(DataGrid.Selection),
                ShowInfoPanel = true
            };

            List<Documentation> selectionDocumentations = new List<Documentation>();
            selectionDocumentations.Add(new Documentation() { Content = "DataGrid - SelectionMode API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Grids.GridSelectionMode.html") });
            selectionDocumentations.Add(new Documentation() { Content = "DataGrid - SelectionUnit API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Grids.GridSelectionUnit.html") });
            selectionDocumentations.Add(new Documentation() { Content = "DataGrid - Selection Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/selection") });
            selectionDocumentations.Add(new Documentation() { Content = "DataGrid - Selection Events Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/selection#events-processed-on-selection") });
            selectionDocumentations.Add(new Documentation() { Content = "DataGrid - Selection Customization Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/selection#customizing-selection-behaviors") });
            selectionDocumentations.Add(new Documentation() { Content = "Details View DataGrid - Selection Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/selection#selection-in-master-details-view") });


            selection.Documentation.AddRange(selectionDocumentations);


            DemoInfo editing = new DemoInfo()
            {
                Name = "Editing",
                Category = "Editing",
                DemoType = DemoTypes.None,
                Description = "The DataGrid control provides support to edit cells with built-in editors such as text box, combo box and date picker. Trigger the edit mode with a single or double tap.",
                DemoView = typeof(DataGrid.EditingDemo),
                ShowInfoPanel = true
            };

            List<Documentation> editingDocumentations = new List<Documentation>();
            editingDocumentations.Add(new Documentation() { Content = "DataGrid - Editing API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Grids.SfGridBase.html#Syncfusion_UI_Xaml_Grids_SfGridBase_AllowEditing") });
            editingDocumentations.Add(new Documentation() { Content = "DataGrid - Editing Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/editing") });
            editingDocumentations.Add(new Documentation() { Content = "DataGrid - Editing Events Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/editing#events") });
            editingDocumentations.Add(new Documentation() { Content = "DataGrid - Programmatic Editing Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/editing#programmatically-edit-the-cell") });

            editing.Documentation.AddRange(editingDocumentations);

            DemoInfo sorting = new DemoInfo()
            {
                Name = "Sorting",
                Category = "Data Presentation",
                DemoType = DemoTypes.None,
                Description = "The DataGrid control allows you to sort data against one or more columns. Additional sorting functionalities include tristate sorting and displaying sort numbers to indicate the sort order.",
                DemoView = typeof(DataGrid.Sorting),
                ShowInfoPanel = true
            };

            List<Documentation> sortingDocumentations = new List<Documentation>();
            sortingDocumentations.Add(new Documentation() { Content = "DataGrid - Sorting API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Grids.SfGridBase.html#Syncfusion_UI_Xaml_Grids_SfGridBase_AllowSorting") });
            sortingDocumentations.Add(new Documentation() { Content = "DataGrid - Sorting Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/sorting") });
            sortingDocumentations.Add(new Documentation() { Content = "DataGrid - Custom Sorting Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/sorting#custom-sorting") });
            sortingDocumentations.Add(new Documentation() { Content = "DataGrid - Programmatic Sorting Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/sorting#programmatic-sorting") });
            sortingDocumentations.Add(new Documentation() { Content = "DataGrid - Sorting Events Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/sorting#handling-events") });

            sorting.Documentation.AddRange(sortingDocumentations);

            DemoInfo filtering= new DemoInfo()
            {
                Name = "Filtering",
                Category = "Filtering",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the data filtering capabilities of the DataGrid control.",
                DemoView = typeof(DataGrid.Filtering),
                ShowInfoPanel = true
            };

            List<Documentation> filteringDocumentations = new List<Documentation>();
            filteringDocumentations.Add(new Documentation() { Content = "DataGrid - View Filter API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Data.ICollectionViewAdv.html#Syncfusion_UI_Xaml_Data_ICollectionViewAdv_Filter") });
            filteringDocumentations.Add(new Documentation() { Content = "DataGrid - View Filter Refresh API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Data.ICollectionViewAdv.html#Syncfusion_UI_Xaml_Data_ICollectionViewAdv_RefreshFilter_System_Boolean_") });
            filteringDocumentations.Add(new Documentation() { Content = "DataGrid - View Filtering Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/filtering#view-filtering") });
            filteringDocumentations.Add(new Documentation() { Content = "DataGrid - Instant Filtering Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/filtering#instant-filtering") });
            filteringDocumentations.Add(new Documentation() { Content = "DataGrid - Filtering Events Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/filtering#events") });

            filtering.Documentation.AddRange(filteringDocumentations);

            DemoInfo filterRow = new DemoInfo()
            {
                Name = "Filter Row",
                Category = "Filtering",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the filter row functionalities of the DataGrid control.",
                DemoView = typeof(DataGrid.FilterRow),
                ShowInfoPanel = true
            };

            List<Documentation> filterRowDocumentations = new List<Documentation>();
            filterRowDocumentations.Add(new Documentation() { Content = "DataGrid - Filter Row API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.SfDataGrid.html#Syncfusion_UI_Xaml_DataGrid_SfDataGrid_FilterRowPosition") });
            filterRowDocumentations.Add(new Documentation() { Content = "DataGrid - Filter Row Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/filterrow") });
            filterRowDocumentations.Add(new Documentation() { Content = "DataGrid - Filter Row Instant Filtering Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/filterrow#instant-filtering") });
            filterRowDocumentations.Add(new Documentation() { Content = "DataGrid - Filter Row Styling Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/filterrow#styling") });
            filterRowDocumentations.Add(new Documentation() { Content = "DataGrid - Filter Row Customization Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/filterrow#customizing-filter-row-editors") });

            filterRow.Documentation.AddRange(filterRowDocumentations);

            DemoInfo advancefilter = new DemoInfo()
            {
                Name = "Advanced Filtering",
                Category = "Filtering",
                DemoType = DemoTypes.None,
                Description = "The DataGrid control supports filtering columns with an Excel-inspired UI.",
                DemoView = typeof(DataGrid.AdvanceFilter),
                ShowInfoPanel = true
            };

            List<Documentation> advancefilterDocumentations = new List<Documentation>();
            advancefilterDocumentations.Add(new Documentation() { Content = "DataGrid - Filtering API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.SfDataGrid.html#Syncfusion_UI_Xaml_DataGrid_SfDataGrid_AllowFiltering") });
            advancefilterDocumentations.Add(new Documentation() { Content = "DataGrid - Advanced Filtering Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/filtering#advanced-filter-ui") });
            advancefilterDocumentations.Add(new Documentation() { Content = "DataGrid - Filtering Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/filtering") });
            advancefilterDocumentations.Add(new Documentation() { Content = "DataGrid - Filtering Events Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/filtering#events") });
            advancefilterDocumentations.Add(new Documentation() { Content = "DataGrid - Filtering Customization Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/filtering#show-image-in-checkboxfiltercontrol-instead-of-image-path") });

            advancefilter.Documentation.AddRange(advancefilterDocumentations);

            DemoInfo grouping = new DemoInfo()
            {
                Name = "Grouping",
                Category = "Data Presentation",
                DemoType = DemoTypes.None,
                Description = "The DataGrid control allows you to group data by one or more columns. You can group the required column by dragging it to an intuitive group drop area at the top of the data grid.",
                DemoView = typeof(DataGrid.Grouping),
                ShowInfoPanel = true
            };

            List<Documentation> groupingDocumentations = new List<Documentation>();
            groupingDocumentations.Add(new Documentation() { Content = "DataGrid - Grouping API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.SfDataGrid.html#Syncfusion_UI_Xaml_DataGrid_SfDataGrid_AllowGrouping") });
            groupingDocumentations.Add(new Documentation() { Content = "DataGrid - GroupMode API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.GridColumn.html#Syncfusion_UI_Xaml_DataGrid_GridColumn_GroupMode") });
            groupingDocumentations.Add(new Documentation() { Content = "DataGrid - Grouping Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/grouping") });
            groupingDocumentations.Add(new Documentation() { Content = "DataGrid - Programmatic Grouping Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/grouping#programmatic-grouping") });
            groupingDocumentations.Add(new Documentation() { Content = "DataGrid - Grouping Events Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/grouping#grouping-events") });
            groupingDocumentations.Add(new Documentation() { Content = "DataGrid - Group Drop Area Customization Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/grouping#groupdroparea-customization") });

            grouping.Documentation.AddRange(groupingDocumentations);

            DemoInfo customGrouping = new DemoInfo()
            {
                Name = "Custom Grouping",
                Category = "Data Presentation",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the custom grouping capabilities in the DataGrid Control.",
                DemoView = typeof(DataGrid.CustomGrouping),
                ShowInfoPanel = true
            };

            List<Documentation> customGroupingDocumentations = new List<Documentation>();
            customGroupingDocumentations.Add(new Documentation() { Content = "DataGrid - Custom Grouping API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.SfDataGrid.html#Syncfusion_UI_Xaml_DataGrid_SfDataGrid_GroupColumnDescriptions") });
            customGroupingDocumentations.Add(new Documentation() { Content = "DataGrid - GroupColumnDescription API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.GroupColumnDescription.html") });
            customGroupingDocumentations.Add(new Documentation() { Content = "DataGrid - Custom Grouping Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/grouping#custom-grouping") });
            customGroupingDocumentations.Add(new Documentation() { Content = "DataGrid - Sortig the Grouped Column Records Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/grouping#sorting-the-grouped-column-records") });
            customGroupingDocumentations.Add(new Documentation() { Content = "DataGrid - Grouping Events Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/grouping#grouping-events") });

            customGrouping.Documentation.AddRange(customGroupingDocumentations);

            DemoInfo columnSizer = new DemoInfo()
            {
                Name = "Column Sizing",
                Category = "Columns",
                DemoType = DemoTypes.None,
                Description = "This sample show cases the different types of column-sizing capabilities in the DataGrid control.",
                DemoView = typeof(DataGrid.ColumnSizer),
                ShowInfoPanel = true
            };

            List<Documentation> columnSizerDocumentations = new List<Documentation>();
            columnSizerDocumentations.Add(new Documentation() { Content = "DataGrid - Column Sizer API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.SfDataGrid.html#Syncfusion_UI_Xaml_DataGrid_SfDataGrid_ColumnWidthMode") });
            columnSizerDocumentations.Add(new Documentation() { Content = "DataGrid - ColumnWidthMode API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Grids.ColumnWidthMode.html") });
            columnSizerDocumentations.Add(new Documentation() { Content = "DataGrid - Column Sizer Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/autosize-columns") });
            columnSizerDocumentations.Add(new Documentation() { Content = "DataGrid - Column Sizer Customization Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/grouping#sorting-the-grouped-column-records") });
            columnSizerDocumentations.Add(new Documentation() { Content = "DataGrid - Star Column Width Mode Customization Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/autosize-columns#star-column-sizer-ratio-support") });

            columnSizer.Documentation.AddRange(columnSizerDocumentations);

            DemoInfo unboundColumns = new DemoInfo()
            {
                Name = "Unbound Columns",
                Category = "Columns",
                DemoType = DemoTypes.None,
                Description = "The DataGrid control provides support to add additional columns that are not bound with data objects from underlying data source.",
                DemoView = typeof(DataGrid.UnboundColumns),
                ShowInfoPanel = true
            };

            List<Documentation> unboundColumnsDocumentations = new List<Documentation>();
            unboundColumnsDocumentations.Add(new Documentation() { Content = "DataGrid - Unbound Columns API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.GridUnboundColumn.html") });
            unboundColumnsDocumentations.Add(new Documentation() { Content = "DataGrid - Unbound Columns Properties API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.GridUnboundColumn.html#properties") });
            unboundColumnsDocumentations.Add(new Documentation() { Content = "DataGrid - Unbound Columns Events API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.SfDataGrid.html#Syncfusion_UI_Xaml_DataGrid_SfDataGrid_QueryUnboundColumnValue") });
            unboundColumnsDocumentations.Add(new Documentation() { Content = "DataGrid - Unbound Columns Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/unbound-column") });

            unboundColumns.Documentation.AddRange(unboundColumnsDocumentations);

            DemoInfo autoRowHeight = new DemoInfo()
            {
                Name = "Auto RowHeight",
                Category = "Row",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the auto row height feature of DataGrid which improves the readability of the content and occurs on-demand basis.",
                DemoView = typeof(DataGrid.AutoRowHeight),
                ShowInfoPanel = true
            };

            List<Documentation> autoRowHeightDocumentations = new List<Documentation>();
            autoRowHeightDocumentations.Add(new Documentation() { Content = "DataGrid - Auto RowHeight Events API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.SfDataGrid.html#Syncfusion_UI_Xaml_DataGrid_SfDataGrid_QueryRowHeight") });
            autoRowHeightDocumentations.Add(new Documentation() { Content = "DataGrid - Auto RowHeight Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/row-height-customization#fit-the-row-height-based-on-its-content") });

            autoRowHeight.Documentation.AddRange(autoRowHeightDocumentations);

            DemoInfo dataBinding = new DemoInfo()
            {
                Name = "Data Binding",
                Category = "Data Binding",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the data binding capabilities in the DataGrid control.",
                DemoView = typeof(DataGrid.DataBinding),
                ShowInfoPanel = true
            };

            List<Documentation> dataBindingDocumentations = new List<Documentation>();
            dataBindingDocumentations.Add(new Documentation() { Content = "DataGrid - Data Binding API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.SfDataGrid.html#Syncfusion_UI_Xaml_DataGrid_SfDataGrid_ItemsSource") });
            dataBindingDocumentations.Add(new Documentation() { Content = "DataGrid - Data Binding Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/data-binding") });
            dataBindingDocumentations.Add(new Documentation() { Content = "DataGrid - Data Binding With IEnumerable Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/data-binding#binding-with-ienumerable") });
            dataBindingDocumentations.Add(new Documentation() { Content = "DataGrid - Data Binding With Dynamic Data Object Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/data-binding#binding-with-dynamic-data-object") });
            dataBindingDocumentations.Add(new Documentation() { Content = "DataGrid - Data Binding Events Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/data-binding#events") });

            dataBinding.Documentation.AddRange(dataBindingDocumentations);

            DemoInfo summaries = new DemoInfo()
            {
                Name = "Summaries",
                Category = "Data Presentation",
                DemoType = DemoTypes.None,
                Description = "Display concise information about data objects using summaries. ",
                DemoView = typeof(DataGrid.Summaries),
                ShowInfoPanel = true
            };

            List<Documentation> summariesDocumentations = new List<Documentation>();
            summariesDocumentations.Add(new Documentation() { Content = "DataGrid - GridTableSummaryRow API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.SfDataGrid.html#Syncfusion_UI_Xaml_DataGrid_SfDataGrid_TableSummaryRows") });
            summariesDocumentations.Add(new Documentation() { Content = "DataGrid - GroupSummaryRow API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.SfDataGrid.html#Syncfusion_UI_Xaml_DataGrid_SfDataGrid_GroupSummaryRows") });
            summariesDocumentations.Add(new Documentation() { Content = "DataGrid - CaptionSummaryRow API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.SfDataGrid.html#Syncfusion_UI_Xaml_DataGrid_SfDataGrid_CaptionSummaryRow") });
            summariesDocumentations.Add(new Documentation() { Content = "DataGrid - Summaries Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/summaries") });
            summariesDocumentations.Add(new Documentation() { Content = "DataGrid - Summaries Formatting Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/summaries#formatting-summary") });
            summariesDocumentations.Add(new Documentation() { Content = "DataGrid - Custom Summaries Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/summaries#custom-summaries") });

            summaries.Documentation.AddRange(summariesDocumentations);

            DemoInfo stackedheaders = new DemoInfo()
            {
                Name = "Stacked Headers",
                Category = "Row",
                DemoType = DemoTypes.None,
                Description = "The DataGrid control allows you to add additional unbound header rows, known as stacked header rows, that span across columns.",
                DemoView = typeof(DataGrid.StackedHeader),
                ShowInfoPanel = true
            };

            List<Documentation> stackedheadersDocumentations = new List<Documentation>();
            stackedheadersDocumentations.Add(new Documentation() { Content = "DataGrid - Stacked Headers API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Grids.SfGridBase.html#Syncfusion_UI_Xaml_Grids_SfGridBase_StackedHeaderRows") });
            stackedheadersDocumentations.Add(new Documentation() { Content = "DataGrid - Stacked Headers Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/stacked-headers") });
            stackedheadersDocumentations.Add(new Documentation() { Content = "DataGrid - Stacked Headers Height Customization Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/stacked-headers#changing-stacked-header-row-height") });

            stackedheaders.Documentation.AddRange(stackedheadersDocumentations);

            DemoInfo serialization = new DemoInfo()
            {
                Name = "Serialization",
                Category = "Serialization",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the serialization and deserialization settings of the data grids.",
                DemoView = typeof(DataGrid.Serialization),
                ShowInfoPanel = true
            };

            List<Documentation> serializationDocumentations = new List<Documentation>();
            serializationDocumentations.Add(new Documentation() { Content = "DataGrid - Serialization API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.Serialization.html") });
            serializationDocumentations.Add(new Documentation() { Content = "DataGrid - Serialization Options API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.Serialization.SerializationOptions.html") });
            serializationDocumentations.Add(new Documentation() { Content = "DataGrid - Deserialization Options API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.Serialization.DeserializationOptions.html") });
            serializationDocumentations.Add(new Documentation() { Content = "DataGrid - Serialize and Deserialize Properties API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.Serialization.SerializableDataGrid.html") });
            serializationDocumentations.Add(new Documentation() { Content = "DataGrid - Serialize and Deserialize Filters API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.Serialization.SerializableFilter.html") });
            serializationDocumentations.Add(new Documentation() { Content = "DataGrid - Serialize and Deserialize StackedHeaders API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.Serialization.SerializableStackedHeaderRow.html") });
            serializationDocumentations.Add(new Documentation() { Content = "DataGrid - Serialize and Deserialize Summaries API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.Serialization.SerializableGridSummaryRows.html") });

            serialization.Documentation.AddRange(serializationDocumentations);

            DemoInfo freezepanes = new DemoInfo()
            {
                Name = "Freeze Panes",
                Category = "Appearance",
                DemoType = DemoTypes.None,
                Description = "The DataGrid control provides support to freeze rows at the top or bottom and columns on the left or right sides, similar to in Excel.",
                DemoView = typeof(DataGrid.FreezePanes),
                ShowInfoPanel = true
            };

            List<Documentation> freezepanesDocumentations = new List<Documentation>();
            freezepanesDocumentations.Add(new Documentation() { Content = "DataGrid - Frozen Rows API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.SfDataGrid.html#Syncfusion_UI_Xaml_DataGrid_SfDataGrid_FrozenRowsCount") });
            freezepanesDocumentations.Add(new Documentation() { Content = "DataGrid - Frozen Footer Rows API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.SfDataGrid.html#Syncfusion_UI_Xaml_DataGrid_SfDataGrid_FrozenFooterRowsCount") });
            freezepanesDocumentations.Add(new Documentation() { Content = "DataGrid - Frozen Columns API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Grids.SfGridBase.html#Syncfusion_UI_Xaml_Grids_SfGridBase_FrozenColumnCount") });
            freezepanesDocumentations.Add(new Documentation() { Content = "DataGrid - Frozen Footer Columns API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Grids.SfGridBase.html#Syncfusion_UI_Xaml_Grids_SfGridBase_FrozenFooterColumnCount") });
            freezepanesDocumentations.Add(new Documentation() { Content = "DataGrid - Freeze Panes Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/rows#freeze-panes") });

            freezepanes.Documentation.AddRange(freezepanesDocumentations);

            DemoInfo contextflyout = new DemoInfo()
            {
                Name = "Context Flyout",
                Category = "Interactive Features",
                DemoType = DemoTypes.None,
                Description = "The context flyout is an entirely customizable flyout for the extensible functions of a data grid. It is enabled for various elements of the grid, such as a data cell or header cell.",
                DemoView = typeof(DataGrid.ContextFlyout),
                ShowInfoPanel = true
            };

            List<Documentation> contextflyoutDocumentations = new List<Documentation>();
            contextflyoutDocumentations.Add(new Documentation() { Content = "DataGrid - GroupDropAreaContextFlyout API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.SfDataGrid.html#Syncfusion_UI_Xaml_DataGrid_SfDataGrid_GroupDropAreaContextFlyout") });
            contextflyoutDocumentations.Add(new Documentation() { Content = "DataGrid - GroupCaptionContextFlyout API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.SfDataGrid.html#Syncfusion_UI_Xaml_DataGrid_SfDataGrid_GroupCaptionContextFlyout") });
            contextflyoutDocumentations.Add(new Documentation() { Content = "DataGrid - GroupSummaryContextFlyout API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.SfDataGrid.html#Syncfusion_UI_Xaml_DataGrid_SfDataGrid_GroupSummaryContextFlyout") });
            contextflyoutDocumentations.Add(new Documentation() { Content = "DataGrid - TableSummaryContextFlyout API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.SfDataGrid.html#Syncfusion_UI_Xaml_DataGrid_SfDataGrid_TableSummaryContextFlyout") });
            contextflyoutDocumentations.Add(new Documentation() { Content = "DataGrid - ContextFlyout Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/context-flyout") });
            
            contextflyout.Documentation.AddRange(contextflyoutDocumentations);

            DemoInfo clipboardoperation = new DemoInfo()
            {
                Name = "Clipboard Operations",
                Category = "Interactive Features",
                DemoType = DemoTypes.None,
                Description = "The DataGrid control provides interactive support to perform cut, copy, and paste operations by using the CopyOption and PasteOption properties.",
                DemoView = typeof(DataGrid.ClipboardOperation),
                ShowInfoPanel = true
            };

            List<Documentation> clipboardoperationDocumentations = new List<Documentation>();
            clipboardoperationDocumentations.Add(new Documentation() { Content = "DataGrid - CopyOptions API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Grids.GridCopyOptions.html#fields") });
            clipboardoperationDocumentations.Add(new Documentation() { Content = "DataGrid - PasteOptions API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Grids.GridPasteOptions.html#fields") });
            clipboardoperationDocumentations.Add(new Documentation() { Content = "DataGrid - Clipboard Operation Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/clipboard-operations") });
            clipboardoperationDocumentations.Add(new Documentation() { Content = "DataGrid - Clipboard Operation Events Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/clipboard-operations#events") });
            clipboardoperationDocumentations.Add(new Documentation() { Content = "DataGrid - Clipboard Operation Customization Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/clipboard-operations#customizing-copy-paste-behavior-in-winui-datagrid") });

            clipboardoperation.Documentation.AddRange(clipboardoperationDocumentations);
			
            DemoInfo rowdragdrop = new DemoInfo()
            {
                Name = "Row Drag and Drop",
                Category = "Interactive Features",
                DemoType = DemoTypes.None,
                Description = "The DataGrid control provides support to perform row drag-and-drop operations using the AllowRowDragDrop and AllowDrop properties.",
                DemoView = typeof(DataGrid.RowDragDrop),
                ShowInfoPanel = true
            };
			
			 List<Documentation> rowdragdropDocumentations = new List<Documentation>();
            rowdragdropDocumentations.Add(new Documentation() { Content = "DataGrid - Row Drag and Drop API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.SfDataGrid.html#Syncfusion_UI_Xaml_DataGrid_SfDataGrid_RowDragOver") });
            rowdragdropDocumentations.Add(new Documentation() { Content = "DataGrid - Row Drag and Drop Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/row-drag-and-drop") });
            rowdragdropDocumentations.Add(new Documentation() { Content = "DataGrid - Row Drag and Drop Events Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/row-drag-and-drop#drag-and-drop-events") });
            rowdragdropDocumentations.Add(new Documentation() { Content = "DataGrid - Row Drag and Drop Customization Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/row-drag-and-drop#customizing-row-drag-and-drop-operation") });

            rowdragdrop.Documentation.AddRange(rowdragdropDocumentations);
			
			DemoInfo excelExporting = new DemoInfo()
            {
                Name = "Excel Exporting",
                Category = "Exporting",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the excel exporting capability of DataGrid.",
                DemoView = typeof(DataGrid.ExcelExporting),
                ShowInfoPanel = false,
            };
			
            DemoInfo datavalitations = new DemoInfo()
            {
                Name = "Data Validation",
                Category = "Data Validation",
                DemoType = DemoTypes.None,
                Description = "This sample showcases data validation for cells and displays hints in case the validation does not pass.",
                DemoView = typeof(DataGrid.DataValidation),
                ShowInfoPanel = true
            };

            List<Documentation> datavalitationsDocumentations = new List<Documentation>();
            datavalitationsDocumentations.Add(new Documentation() { Content = "DataGrid - DataValidationMode API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Grids.GridColumnBase.html#Syncfusion_UI_Xaml_Grids_GridColumnBase_DataValidationMode") });
            datavalitationsDocumentations.Add(new Documentation() { Content = "DataGrid - Data Validation Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/data-validation") });
            datavalitationsDocumentations.Add(new Documentation() { Content = "DataGrid - Built-In Data Validation Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/data-validation#built-in-validations") });
            datavalitationsDocumentations.Add(new Documentation() { Content = "DataGrid - Data Validation Events Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/data-validation#cell-validation") });
            datavalitationsDocumentations.Add(new Documentation() { Content = "DataGrid - Data Validation Customization Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/data-validation#data-validation-error-icon-customization") });
            datavalitationsDocumentations.Add(new Documentation() { Content = "Details View DataGrid - Data Validation Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/data-validation#data-validation-with-master-details-view") });

            datavalitations.Documentation.AddRange(datavalitationsDocumentations);

            DemoInfo customvalidations = new DemoInfo()
            {
                Name = "Custom Validation",
                Category = "Data Validation",
                DemoType = DemoTypes.None,
                Description = "This sample showcases custom data validation for cells in a data grid by using the CurrentCellValidating and RowValidating events.",
                DemoView = typeof(DataGrid.CustomValidation),
                ShowInfoPanel = true
            };

            List<Documentation> customvalidationsDocumentations = new List<Documentation>();
            customvalidationsDocumentations.Add(new Documentation() { Content = "DataGrid - DataValidationMode API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Grids.GridColumnBase.html#Syncfusion_UI_Xaml_Grids_GridColumnBase_DataValidationMode") });
            customvalidationsDocumentations.Add(new Documentation() { Content = "DataGrid - Data Validation Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/data-validation") });
            customvalidationsDocumentations.Add(new Documentation() { Content = "DataGrid - Data Validation Events Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/data-validation#cell-validation") });
            customvalidationsDocumentations.Add(new Documentation() { Content = "DataGrid - Data Validation Customization Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/data-validation#data-validation-error-icon-customization") });
            customvalidationsDocumentations.Add(new Documentation() { Content = "Details View DataGrid - Data Validation Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/data-validation#data-validation-with-master-details-view") });

            customvalidations.Documentation.AddRange(customvalidationsDocumentations);

            DemoInfo unboundrows = new DemoInfo()
            {
                Name = "Unbound Rows",
                Category = "Row",
                DemoType = DemoTypes.None,
                Description = "The DataGrid control provides support to add additional rows at its top and bottom that are not bound with data objects from the underlying data source.",
                DemoView = typeof(DataGrid.UnboundRows),
                ShowInfoPanel = true
            };

            List<Documentation> unboundrowsDocumentations = new List<Documentation>();
            unboundrowsDocumentations.Add(new Documentation() { Content = "DataGrid - Unbound Rows API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.GridUnboundRow.html") });
            unboundrowsDocumentations.Add(new Documentation() { Content = "DataGrid - Unbound Rows Properties API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.GridUnboundRow.html#properties") });
            unboundrowsDocumentations.Add(new Documentation() { Content = "DataGrid - Unbound Rows Events API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.SfDataGrid.html#Syncfusion_UI_Xaml_DataGrid_SfDataGrid_QueryUnboundRow") });
            unboundrowsDocumentations.Add(new Documentation() { Content = "DataGrid - Unbound Rows Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/unbound-rows") });

            unboundrows.Documentation.AddRange(unboundrowsDocumentations);

            DemoInfo masterdetailsview = new DemoInfo()
            {
                Name = "Master-Details View",
                Category = "Master Detail",
                DemoType = DemoTypes.None,
                Description = "The DataGrid control displays hierarchical data in the form of nested tables using a master-details view configuration.",
                DemoView = typeof(DataGrid.MasterDetailsView),
                ShowInfoPanel = true
            };

            List<Documentation> masterdetailsviewDocumentations = new List<Documentation>();
            masterdetailsviewDocumentations.Add(new Documentation() { Content = "Details View DataGrid - API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.DataGrid.DetailsViewDataGrid.html") });
            masterdetailsviewDocumentations.Add(new Documentation() { Content = "Details View DataGrid - Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/master-details-view") });
            masterdetailsviewDocumentations.Add(new Documentation() { Content = "Details View DataGrid - Defining Relations Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/master-details-view#defining-relations-in-datagrid") });
            masterdetailsviewDocumentations.Add(new Documentation() { Content = "Details View DataGrid - Selection Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/master-details-view#selection") });
            masterdetailsviewDocumentations.Add(new Documentation() { Content = "Details View DataGrid - Column Sizing Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/master-details-view#column-sizing") });
            masterdetailsviewDocumentations.Add(new Documentation() { Content = "Details View DataGrid - Events Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/master-details-view#handling-events") });

            masterdetailsview.Documentation.AddRange(masterdetailsviewDocumentations);
             
            DemoInfo styling = new DemoInfo()
            {
                Name = "Styling",
                Category = "Appearance",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the styling capabilities of the DataGrid.",
                DemoView = typeof(DataGrid.Styling),
                ShowInfoPanel = true
            };

            List<Documentation> stylingDocumentations = new List<Documentation>();
            stylingDocumentations.Add(new Documentation() { Content = "DataGrid - UI Customization Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/ui-customization") });
            stylingDocumentations.Add(new Documentation() { Content = "DataGrid - Styling CaptionSummary rows", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/ui-customization#styling-captionsummary-rows") });
            stylingDocumentations.Add(new Documentation() { Content = "DataGrid - Styling GroupSummary rows", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/ui-customization#styling-groupsummary-rows") });
            stylingDocumentations.Add(new Documentation() { Content = "DataGrid - Styling TableSummary rows", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/ui-customization#styling-tablesummary-rows") });
            stylingDocumentations.Add(new Documentation() { Content = "DataGrid - Styling unbound row", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/ui-customization#styling-unbound-row") });
            stylingDocumentations.Add(new Documentation() { Content = "DataGrid - Styling AddNewRow", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/ui-customization#styling-addnewrow") });
            stylingDocumentations.Add(new Documentation() { Content = "DataGrid - Styling DetailsViewDataGrid", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/ui-customization#styling-detailsviewdatagrid") });
            stylingDocumentations.Add(new Documentation() { Content = "DataGrid - Styling RowHeader", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/ui-customization#styling-rowheader") });

            styling.Documentation.AddRange(stylingDocumentations);

            DemoInfo conditionalstyling = new DemoInfo()
            {
                Name = "Conditional Styling",
                Category = "Appearance",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the cell style customization in the DataGrid via StyleSelector.",
                DemoView = typeof(DataGrid.Conditionalstyling),
                ShowInfoPanel = true
            };

            List<Documentation> conditionalstylingDocumentations = new List<Documentation>();
            conditionalstylingDocumentations.Add(new Documentation() { Content = "DataGrid - Conditional styling Documentation", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/conditional-styling") });
            conditionalstylingDocumentations.Add(new Documentation() { Content = "DataGrid - Cell style", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/conditional-styling#cell-style") });
            conditionalstylingDocumentations.Add(new Documentation() { Content = "DataGrid - Caption summary cell style", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/conditional-styling#caption-summary-cell-style") });
            conditionalstylingDocumentations.Add(new Documentation() { Content = "DataGrid - Group summary cell style", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/conditional-styling#group-summary-cell-style") });
            conditionalstylingDocumentations.Add(new Documentation() { Content = "DataGrid - Table summary cell", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/conditional-styling#table-summary-cell ") });
            conditionalstylingDocumentations.Add(new Documentation() { Content = "DataGrid - Table summary cell alignment based on column", Uri = new Uri("https://help.syncfusion.com/winui/datagrid/conditional-styling#table-summary-cell-alignment-based-on-column") });

            conditionalstyling.Documentation.AddRange(conditionalstylingDocumentations); 

            var demos = new List<DemoInfo>()
            {
                gettingstarted,
                dataBinding,
                sorting,
                grouping,
                summaries,
                filtering,
                advancefilter,
                filterRow,
                masterdetailsview,
                editing,
                stackedheaders,
                unboundrows,
                columnSizer,
                datavalitations,
                customvalidations,
                selection,
                freezepanes,
                contextflyout,
                clipboardoperation, 
                serialization,
                customGrouping,
				excelExporting,
                styling,
                conditionalstyling,
                unboundColumns
            };

            var controlInfo = new ControlInfo()
            {
                Control = DemoControl.SfDataGrid,
                ControlCategory = ControlCategory.Grids,
                Description = "The DataGrid is a high performance grid control that displays tabular and hierarchical data. It supports sorting, grouping, filtering, etc.",
                Glyph = "\uE707",
                ImageSource = "DataGrid.png"
            };

            controlInfo.Demos.AddRange(demos);
            DemoHelper.ControlInfos.Add(controlInfo);
        }
    }
}
