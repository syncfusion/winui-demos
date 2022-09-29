#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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


namespace Syncfusion.TreeGridDemos.WinUI
{
    public class SamplesConfiguration
    {
        public SamplesConfiguration()
        {
            DemoInfo selfrelational = new DemoInfo()
            {
                Name = "Self Relational Collection",
                Category = "Getting Started",
                DemoType = DemoTypes.None,
                Description = "This sample showcases how to bind self-relational data by specifying the ChildPropertyName and ParentPropertyName properties in a tree grid.",
                DemoView = typeof(TreeGrid.SelfRelational),
                ShowInfoPanel = true
            };

            List<Documentation> selfrelationalDocumentations = new List<Documentation>();
            selfrelationalDocumentations.Add(new Documentation() { Content = "TreeGrid - API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.TreeGrid.html") });
            selfrelationalDocumentations.Add(new Documentation() { Content = "TreeGrid - Getting Started Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/getting-started") });
            selfrelationalDocumentations.Add(new Documentation() { Content = "TreeGrid - Sorting Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/sorting") });
            selfrelationalDocumentations.Add(new Documentation() { Content = "TreeGrid - Filtering Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/filtering") });
            selfrelationalDocumentations.Add(new Documentation() { Content = "TreeGrid - Editing Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/editing") });
            selfrelationalDocumentations.Add(new Documentation() { Content = "TreeGrid - Clipboard Operations Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/clipboard-operations") });
            selfrelationalDocumentations.Add(new Documentation() { Content = "TreeGrid - Selection Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/selection") });

            selfrelational.Documentation.AddRange(selfrelationalDocumentations);

            DemoInfo nestedcollection = new DemoInfo()
            {
                Name = "Nested Collection",
                Category = "Getting Started",
                DemoType = DemoTypes.None,
                Description = "This sample showcases how to bind the nested collection by specifying the ChildPropertyName property in a tree grid.",
                DemoView = typeof(TreeGrid.NestedCollection),
                ShowInfoPanel = true
            };

            List<Documentation> nestedcollectionDocumentations = new List<Documentation>();
            nestedcollectionDocumentations.Add(new Documentation() { Content = "TreeGrid - API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.TreeGrid.html") });
            nestedcollectionDocumentations.Add(new Documentation() { Content = "TreeGrid - Getting Started Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/getting-started") });
            nestedcollectionDocumentations.Add(new Documentation() { Content = "TreeGrid - Sorting Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/sorting") });
            nestedcollectionDocumentations.Add(new Documentation() { Content = "TreeGrid - Filtering Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/filtering") });
            nestedcollectionDocumentations.Add(new Documentation() { Content = "TreeGrid - Editing Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/editing") });
            nestedcollectionDocumentations.Add(new Documentation() { Content = "TreeGrid - Clipboard Operations Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/clipboard-operations") });
            nestedcollectionDocumentations.Add(new Documentation() { Content = "TreeGrid - Selection Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/selection") });

            nestedcollection.Documentation.AddRange(nestedcollectionDocumentations);

            DemoInfo selection = new DemoInfo()
            {
                Name = "Selection",
                Category = "Editing and Selection",
                DemoType = DemoTypes.None,
                Description = "The TreeGrid control provides interactive support for selecting rows in different modes smoothly. Select one or more rows programmatically or by mouse and keyboard interaction.",
                DemoView = typeof(TreeGrid.Selection),
                ShowInfoPanel = true
            };

            List<Documentation> selectionDocumentations = new List<Documentation>();
            selectionDocumentations.Add(new Documentation() { Content = "TreeGrid - SelectionMode API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Grids.SfGridBase.html#Syncfusion_UI_Xaml_Grids_SfGridBase_SelectionMode") });
            selectionDocumentations.Add(new Documentation() { Content = "TreeGrid - NavigationMode API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Grids.SfGridBase.html#Syncfusion_UI_Xaml_Grids_SfGridBase_NavigationMode") });
            selectionDocumentations.Add(new Documentation() { Content = "TreeGrid - Selection Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/selection") });
            selectionDocumentations.Add(new Documentation() { Content = "TreeGrid - Selection Events Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/selection#events") });
            selectionDocumentations.Add(new Documentation() { Content = "TreeGrid - Selection Customization Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/selection#customize-selection-behaviors") });
            selectionDocumentations.Add(new Documentation() { Content = "TreeGrid - UI Appearance Customization while selection Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/selection#appearance") });

            selection.Documentation.AddRange(selectionDocumentations);

            DemoInfo sorting = new DemoInfo()
            {
                Name = "Sorting",
                Category = "Sorting",
                DemoType = DemoTypes.None,
                Description = "The TreeGrid control allows you to sort data against one or more columns. Additional sorting functionalities include tristate sorting and displaying sort numbers to indicate the sort order.",
                DemoView = typeof(TreeGrid.Sorting),
                ShowInfoPanel = true
            };

            List<Documentation> sortingDocumentations = new List<Documentation>();
            sortingDocumentations.Add(new Documentation() { Content = "TreeGrid - Sorting API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Grids.SfGridBase.html#Syncfusion_UI_Xaml_Grids_SfGridBase_AllowSortingProperty") });
            sortingDocumentations.Add(new Documentation() { Content = "TreeGrid - Sorting Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/sorting") });
            sortingDocumentations.Add(new Documentation() { Content = "TreeGrid - Sorting Events Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/sorting#handling-events") });
            sortingDocumentations.Add(new Documentation() { Content = "TreeGrid - Custom Sorting Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/sorting#custom-sorting") });

            sorting.Documentation.AddRange(sortingDocumentations);

			DemoInfo filtering = new DemoInfo()
            {
                Name = "Filtering",
                Category = "Filtering",
                DemoType = DemoTypes.None,
                Description = "This sample showcases the data filtering capabilities of the TreeGrid control",
                DemoView = typeof(TreeGrid.Filtering),
                ShowInfoPanel = true
            };
			
			List<Documentation> filteringDocumentations = new List<Documentation>();
            filteringDocumentations.Add(new Documentation() { Content = "TreeGrid - FilterLevel API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.TreeGrid.SfTreeGrid.html#Syncfusion_UI_Xaml_TreeGrid_SfTreeGrid_FilterLevel") });
            filteringDocumentations.Add(new Documentation() { Content = "TreeGrid - Filtering Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/filtering") });
            filteringDocumentations.Add(new Documentation() { Content = "TreeGrid - Programmatic Filtering Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/filtering#programmatic-filtering") });

            filtering.Documentation.AddRange(filteringDocumentations);
       
            DemoInfo advancedfiltering = new DemoInfo()
            {
                Name = "Advanced Filtering",
                Category = "Filtering",
                DemoType = DemoTypes.None,
                Description = "The TreeGrid control provides support to filter columns with an Excel-inspired UI.",
                DemoView = typeof(TreeGrid.AdvancedFiltering),
                ShowInfoPanel = true
            };

            List<Documentation> advancedfilteringDocumentations = new List<Documentation>();
            advancedfilteringDocumentations.Add(new Documentation() { Content = "TreeGrid - Filtering API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.TreeGrid.SfTreeGrid.html#Syncfusion_UI_Xaml_TreeGrid_SfTreeGrid_AllowFiltering") });
            advancedfilteringDocumentations.Add(new Documentation() { Content = "TreeGrid - FilterLevel API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.TreeGrid.SfTreeGrid.html#Syncfusion_UI_Xaml_TreeGrid_SfTreeGrid_FilterLevel") });
            advancedfilteringDocumentations.Add(new Documentation() { Content = "TreeGrid - Filtering Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/filtering") });
            advancedfilteringDocumentations.Add(new Documentation() { Content = "TreeGrid - Advanced Filtering Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/filtering#advanced-filtering") });
            advancedfilteringDocumentations.Add(new Documentation() { Content = "TreeGrid - Filtering Events Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/filtering#customization-using-events") });

            advancedfiltering.Documentation.AddRange(advancedfilteringDocumentations);

            DemoInfo columnsizer = new DemoInfo()
            {
                Name = "AutoFit Columns",
                Category = "Columns",
                DemoType = DemoTypes.None,
                Description = "The TreeGrid control provides built-in support to set the width of a column based on the content in its cells by defining the ColumnWidthMode property.",
                DemoView = typeof(TreeGrid.ColumnSizer),
                ShowInfoPanel = true
            };

            List<Documentation> columnsizerDocumentations = new List<Documentation>();
            columnsizerDocumentations.Add(new Documentation() { Content = "TreeGrid - ColumnWidthMode API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Grids.ColumnWidthMode.html") });
            columnsizerDocumentations.Add(new Documentation() { Content = "TreeGrid - Column Sizing Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/column-sizing") });
            columnsizerDocumentations.Add(new Documentation() { Content = "TreeGrid - Column Sizing Customization Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/column-sizing#customizing-built-in-column-sizing-logic") });

            columnsizer.Documentation.AddRange(columnsizerDocumentations);


            DemoInfo freezecolumns = new DemoInfo()
            {
                Name = "Freeze Columns",
                Category = "Appearance",
                DemoType = DemoTypes.None,
                Description = "The TreeGrid control provides support to freeze columns, similar to Excel, with the help of the FrozenColumnsCount and FrozenFooterColumnsCount properties.",
                DemoView = typeof(TreeGrid.FreezeColumns),
                ShowInfoPanel = true
            };

            List<Documentation> freezecolumnsDocumentations = new List<Documentation>();
            freezecolumnsDocumentations.Add(new Documentation() { Content = "TreeGrid - Frozen Columns API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Grids.SfGridBase.html#Syncfusion_UI_Xaml_Grids_SfGridBase_FrozenColumnCount") });
            freezecolumnsDocumentations.Add(new Documentation() { Content = "TreeGrid - Frozen Footer Columns API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Grids.SfGridBase.html#Syncfusion_UI_Xaml_Grids_SfGridBase_FrozenFooterColumnCount") });

            freezecolumns.Documentation.AddRange(freezecolumnsDocumentations);

            DemoInfo ondemandloading = new DemoInfo()
            {
                Name = "On-Demand Loading",
                Category = "Getting Started",
                DemoType = DemoTypes.None,
                Description = "This sample showcases loading data on demand in a tree grid.",
                DemoView = typeof(TreeGrid.OnDemandLoading),
                ShowInfoPanel = true
            };

            List<Documentation> ondemandloadingDocumentations = new List<Documentation>();
            ondemandloadingDocumentations.Add(new Documentation() { Content = "TreeGrid - API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.TreeGrid.html") });
            ondemandloadingDocumentations.Add(new Documentation() { Content = "TreeGrid - Getting Started Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/getting-started") });
            ondemandloadingDocumentations.Add(new Documentation() { Content = "TreeGrid - Sorting Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/sorting") });
            ondemandloadingDocumentations.Add(new Documentation() { Content = "TreeGrid - Filtering Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/filtering") });
            ondemandloadingDocumentations.Add(new Documentation() { Content = "TreeGrid - Editing Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/editing") });
            ondemandloadingDocumentations.Add(new Documentation() { Content = "TreeGrid - Clipboard Operations Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/clipboard-operations") });
            ondemandloadingDocumentations.Add(new Documentation() { Content = "TreeGrid - Selection Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/selection") });

            ondemandloading.Documentation.AddRange(ondemandloadingDocumentations);


            DemoInfo editing = new DemoInfo()
            {
                Name = "Editing",
                Category = "Editing and Selection",
                DemoType = DemoTypes.None,
                Description = "The TreeGrid control provides support to edit cells with built-in editors such as a text box and combo box. Trigger the edit mode with a single or double tap.",
                DemoView = typeof(TreeGrid.Editing),
                ShowInfoPanel = true
            };
            List<Documentation> editingDocumentations = new List<Documentation>();
            editingDocumentations.Add(new Documentation() { Content = "TreeGrid - Editing API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Grids.SfGridBase.html#Syncfusion_UI_Xaml_Grids_SfGridBase_AllowEditing") });
            editingDocumentations.Add(new Documentation() { Content = "TreeGrid - Editing Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/editing") });
            editingDocumentations.Add(new Documentation() { Content = "TreeGrid - Editing Events Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/editing#events") });

            editing.Documentation.AddRange(editingDocumentations);

            DemoInfo datavalidation = new DemoInfo()
            {
                Name = "Data Validation",
                Category = "Data Validation",
                DemoType = DemoTypes.None,
                Description = "This sample showcases data validation for cells and displays hints in case the validation does not pass.",
                DemoView = typeof(TreeGrid.DataValidation),
                ShowInfoPanel = true
            };

            List<Documentation> datavalidationDocumentations = new List<Documentation>();
            datavalidationDocumentations.Add(new Documentation() { Content = "TreeGrid - DataValidationMode API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Grids.SfGridBase.html#Syncfusion_UI_Xaml_Grids_SfGridBase_DataValidationMode") });
            datavalidationDocumentations.Add(new Documentation() { Content = "TreeGrid - Data Validation Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/data-validation") });
            datavalidationDocumentations.Add(new Documentation() { Content = "TreeGrid - Data Validation Events Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/data-validation#custom-validation-through-events") });
            datavalidationDocumentations.Add(new Documentation() { Content = "TreeGrid - Data Validation Customization Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/data-validation#error-icon-and-tip-customization") });

            datavalidation.Documentation.AddRange(datavalidationDocumentations);

            DemoInfo checkboxselection = new DemoInfo()
            {
                Name = "CheckBox Selection",
                Category = "Node CheckBox",
                DemoType = DemoTypes.None,
                Description = "This sample showcases how nodes can be selected using the checkboxes available in each row of a tree grid.",
                DemoView = typeof(TreeGrid.CheckBoxSelection),
                ShowInfoPanel = true
            };

            List<Documentation> checkboxselectionDocumentations = new List<Documentation>();
            checkboxselectionDocumentations.Add(new Documentation() { Content = "TreeGrid - SelectionMode API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Grids.SfGridBase.html#Syncfusion_UI_Xaml_Grids_SfGridBase_SelectionMode") });
            checkboxselectionDocumentations.Add(new Documentation() { Content = "TreeGrid - NavigationMode API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Grids.SfGridBase.html#Syncfusion_UI_Xaml_Grids_SfGridBase_NavigationMode") });
            checkboxselectionDocumentations.Add(new Documentation() { Content = "TreeGrid - Selection Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/selection") });
            checkboxselectionDocumentations.Add(new Documentation() { Content = "TreeGrid - Selection Events Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/selection#events") });
            checkboxselectionDocumentations.Add(new Documentation() { Content = "TreeGrid - Selection Customization Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/selection#customize-selection-behaviors") });
            checkboxselectionDocumentations.Add(new Documentation() { Content = "TreeGrid - UI Appearance Customization while selection Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/selection#appearance") });

            checkboxselection.Documentation.AddRange(checkboxselectionDocumentations);

            DemoInfo clipboardoperation = new DemoInfo()
            {
                Name = "Clipboard Operations",
                Category = "Interactive Features",
                DemoType = DemoTypes.None,
                Description = "The TreeGrid control provides interactive support to perform cut, copy, and paste operations by using the CopyOption and PasteOption properties.",
                DemoView = typeof(TreeGrid.ClipboardOperation),
                ShowInfoPanel = true
            };
            List<Documentation> clipboardoperationDocumentations = new List<Documentation>();
            clipboardoperationDocumentations.Add(new Documentation() { Content = "TreeGrid - CopyOption API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Grids.SfGridBase.html#Syncfusion_UI_Xaml_Grids_SfGridBase_CopyOption") });
            clipboardoperationDocumentations.Add(new Documentation() { Content = "TreeGrid - PasteOption API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Grids.SfGridBase.html#Syncfusion_UI_Xaml_Grids_SfGridBase_PasteOption") });
            clipboardoperationDocumentations.Add(new Documentation() { Content = "TreeGrid - Clipboard Operation Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/clipboard-operations") });
            clipboardoperationDocumentations.Add(new Documentation() { Content = "TreeGrid - Clipboard Operation Events Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/clipboard-operations#events") });
            clipboardoperationDocumentations.Add(new Documentation() { Content = "TreeGrid - Clipboard Operation Customization Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/clipboard-operations#customize-copy-paste-behavior") });

            clipboardoperation.Documentation.AddRange(clipboardoperationDocumentations);

            DemoInfo rowdragdrop = new DemoInfo()
            {
                Name = "Row Drag and Drop",
                Category = "Interactive Features",
                DemoType = DemoTypes.None,
                Description = "The TreeGrid control provides support to perform row drag-and-drop operations using the AllowRowDragDrop and AllowDrop properties.",
                DemoView = typeof(TreeGrid.RowDragDrop),
                ShowInfoPanel = true
            };
			
			List<Documentation> rowdragdropDocumentations = new List<Documentation>();
            rowdragdropDocumentations.Add(new Documentation() { Content = "TreeGrid - Row Drag and Drop API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.TreeGrid.SfTreeGrid.html#Syncfusion_UI_Xaml_TreeGrid_SfTreeGrid_RowDragOver") });
            rowdragdropDocumentations.Add(new Documentation() { Content = "TreeGrid - Row Drag and Drop Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/row-drag-and-drop") });
            rowdragdropDocumentations.Add(new Documentation() { Content = "TreeGrid - Row Drag and Drop Events Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/row-drag-and-drop#drag-and-drop-events") });
            rowdragdropDocumentations.Add(new Documentation() { Content = "TreeGrid - Row Drag and Drop Customization Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/row-drag-and-drop#customizing-row-drag-and-drop-operation") });

            rowdragdrop.Documentation.AddRange(rowdragdropDocumentations);
			
			DemoInfo stackedHeaders = new DemoInfo()
            {
                Name = "Stacked Headers",
                Category = "Columns",
                DemoType = DemoTypes.None,
                Description = "The TreeGrid control allows you to add additional unbound header rows, known as stacked header rows, that span across columns.",
                DemoView = typeof(TreeGrid.StackedHeaders),
                ShowInfoPanel = true
            };

            List<Documentation> stackedheadersDocumentations = new List<Documentation>();
            stackedheadersDocumentations.Add(new Documentation() { Content = "TreeGrid - Stacked Headers API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Grids.SfGridBase.html#Syncfusion_UI_Xaml_Grids_SfGridBase_StackedHeaderRows") });
            stackedheadersDocumentations.Add(new Documentation() { Content = "TreeGrid - Stacked Headers Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/columns#stacked-headers") });

            stackedHeaders.Documentation.AddRange(stackedheadersDocumentations);
           
            DemoInfo styling = new DemoInfo()
            {
                Name = "Styling",
                Category = "Appearance",
                DemoType = DemoTypes.New,
                Description = "This sample showcases the styling capabilities of the TreeGrid.",
                DemoView = typeof(TreeGrid.Styling),
                ShowInfoPanel = true
            };

            List<Documentation> stylingDocumentation = new List<Documentation>();
            stylingDocumentation.Add(new Documentation() { Content = "TreeGrid - UI Customization Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/ui-customization") });

            styling.Documentation.AddRange(stylingDocumentation);

            DemoInfo conditionalstyling = new DemoInfo()
            {
                Name = "Conditional Styling",
                Category = "Appearance",
                DemoType = DemoTypes.New,
                Description = "This sample showcases the cell style customization in the TreeGrid via StyleSelector.",
                DemoView = typeof(TreeGrid.ConditionalStyling),
                ShowInfoPanel = true
            };

            List<Documentation> conditionalstylingDocumentations = new List<Documentation>();
            conditionalstylingDocumentations.Add(new Documentation() { Content = "TreeGrid - Conditional styling Documentation", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/conditional-styling") });
            conditionalstylingDocumentations.Add(new Documentation() { Content = "TreeGrid - Style cells using style selector", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/conditional-styling#style-cells-using-style-selector") });
            conditionalstylingDocumentations.Add(new Documentation() { Content = "TreeGrid - Add image to cell", Uri = new Uri("https://help.syncfusion.com/winui/treegrid/conditional-styling#add-image-to-cell") });

            conditionalstyling.Documentation.AddRange(conditionalstylingDocumentations);

            var demos = new List<DemoInfo>()
            {
                selfrelational,
                nestedcollection,
                ondemandloading,
                sorting,
				filtering,
                advancedfiltering,
                selection,
                editing,
                datavalidation,
                checkboxselection,
                columnsizer,
                freezecolumns,
                clipboardoperation, 
 				stackedHeaders,
                styling,
                conditionalstyling 
            };

            var controlInfo = new ControlInfo()
            {
                Control = DemoControl.SfTreeGrid,
                ControlCategory = ControlCategory.Grids,
                Description = "The TreeGrid control displays the hierarchical or self-relational data in a tree structure with multicolumn interface like multicolumn treeview.",
                Glyph = "\uE702",
                ImageSource = "TreeGrid.png"
            };

            controlInfo.Demos.AddRange(demos);
            DemoHelper.ControlInfos.Add(controlInfo);
        }
    }
}
