#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.winui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.datagriddemos.winui
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
                Description = "This sample showcases the basic features such as selection, sorting, filtering, grouping, and autofit columns of the data grid.",
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
                Description = "The data grid provides support to select rows and cells in different modes. It supports selection of one or more rows and cells programmatically or by mouse and keyboard interaction.",
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
                DemoType = DemoTypes.Updated,
                Description = "The data grid provides support to edit cells with built-in editors such as TextBox, ComboBox and DatePicker. Trigger the edit mode with a single or double tap.",
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
                Description = "The data grid allows you to sort data against one or more columns. Additional sorting functionalities include tristate sorting and displaying sort numbers to indicate the sort order.",
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

            DemoInfo advancefilter = new DemoInfo()
            {
                Name = "Filtering",
                Category = "Filtering",
                DemoType = DemoTypes.None,
                Description = "The data grid supports filtering columns like the Excel inspired UI.",
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
                Description = "The data grid allows you to group data by one or more columns. You can group the required column by dragging it to an intuitive group drop area at the top of the data grid.",
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

            DemoInfo summaries = new DemoInfo()
            {
                Name = "Summaries",
                Category = "Data Presentation",
                DemoType = DemoTypes.None,
                Description = "The data grid supports display of concise information about the data objects using summaries. ",
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
                Description = "The data grid allows you to add additional unbound header rows, known as stacked header rows, that span across columns.",
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
                Description = "This sample showcases serialization and deserialization settings of the data grid.",
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
                Description = "The data grid provides support to freeze rows at top or bottom and columns at left or right side, similar to Excel.",
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
                Description = "The context flyout is an entirely customizable flyout for the extensible functions of a data grid. It is enabled for various elements of the grid such as data cell, header cell, and so on.",
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
                Name = "Clipboard Operation",
                Category = "Interactive Features",
                DemoType = DemoTypes.None,
                Description = "The data grid provides an interactive support to perform cut, copy, and paste operations by using the CopyOption and PasteOption properties.",
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
                Description = "The data grid provides support to add additional rows at the top and bottom of the SfDataGrid, which are not bound with data objects from the underlying data source.",
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
                Name = "Master Details View",
                Category = "Master Detail",
                DemoType = DemoTypes.None,
                Description = "The data grid displays hierarchical data in the form of nested tables using master-details view configuration.",
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
            var demos = new List<DemoInfo>()
            {
                gettingstarted,
                sorting,
                grouping,
                summaries,
                advancefilter,
                masterdetailsview,
                editing,
                stackedheaders,
                unboundrows,
                datavalitations,
                customvalidations,
                selection,
                freezepanes,
                contextflyout,
                clipboardoperation,
                serialization,
            };

            var controlInfo = new ControlInfo()
            {
                Control = DemoControl.SfDataGrid,
                ControlCategory = ControlCategory.Grids,
                Description = "The Data Grid is a high performance grid control that displays tabular and hierarchical data. It supports sorting, grouping, filtering, etc.",
                Glyph= "\uE707"
            };

            controlInfo.Demos.AddRange(demos);
            DemoHelper.ControlInfos.Add(controlInfo);
        }
    }
}
