#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
            };

            DemoInfo selection = new DemoInfo()
            {
                Name = "Selection",
                Category = "Selection",
                DemoType = DemoTypes.None,
                Description = "The data grid provides support to select rows and cells in different modes. It supports selection of one or more rows and cells programmatically or by mouse and keyboard interaction.",
                DemoView = typeof(DataGrid.Selection),
            };


            DemoInfo editing = new DemoInfo()
            {
                Name = "Editing",
                Category = "Editing",
                DemoType = DemoTypes.None,
                Description = "The data grid provides support to edit cells with built-in editors such as TextBox and ComboBox., Trigger the edit mode with a single or double tap.",
                DemoView = typeof(DataGrid.EditingDemo),
            };

            DemoInfo sorting = new DemoInfo()
            {
                Name = "Sorting",
                Category = "Data Presentation",
                DemoType = DemoTypes.None,
                Description = "The data grid allows you to sort data against one or more columns. Additional  sorting functionalities include tristate sorting and displaying sort numbers to indicate the sort order.",
                DemoView = typeof(DataGrid.Sorting),
            };

            DemoInfo advancefilter = new DemoInfo()
            {
                Name = "Filtering",
                Category = "Filtering",
                DemoType = DemoTypes.None,
                Description = "The data grid supports filtering columns like the Excel inspired UI.",
                DemoView = typeof(DataGrid.AdvanceFilter),
            };

            DemoInfo grouping = new DemoInfo()
            {
                Name = "Grouping",
                Category = "Data Presentation",
                DemoType = DemoTypes.None,
                Description = "The data grid allows you to group data by one or more columns. You can group the required column by dragging it to an intuitive group drop area at the top of the data grid.",
                DemoView = typeof(DataGrid.Grouping),
            };

            DemoInfo summaries = new DemoInfo()
            {
                Name = "Summaries",
                Category = "Data Presentation",
                DemoType = DemoTypes.None,
                Description = "The data grid supports display of concise information about the data objects using summaries. ",
                DemoView = typeof(DataGrid.Summaries),
            };

            DemoInfo stackedheaders = new DemoInfo()
            {
                Name = "Stacked Headers",
                Category = "Row",
                DemoType = DemoTypes.None,
                Description = "The data grid allows you to add additional unbound header rows, known as stacked header rows, that span across columns.",
                DemoView = typeof(DataGrid.StackedHeader),
            };

            DemoInfo serialization = new DemoInfo()
            {
                Name = "Serialization",
                Category = "Serialization",
                DemoType = DemoTypes.New,
                Description = "This sample showcases serialization and deserialization settings of the data grid.",
                DemoView = typeof(DataGrid.Serialization),
            };

            DemoInfo freezepanes = new DemoInfo()
            {
                Name = "Freeze Panes",
                Category = "Appearance",
                DemoType = DemoTypes.New,
                Description = "The data grid provides support to freeze rows at top or bottom and columns at left or right side, similar to Excel.",
                DemoView = typeof(DataGrid.FreezePanes),
            };

            DemoInfo contextflyout = new DemoInfo()
            {
                Name = "Context Flyout",
                Category = "Interactive Features",
                DemoType = DemoTypes.New,
                Description = "The context flyout is an entirely customizable flyout for the extensible functions of a data grid. It is enabled for various elements of the grid such as data cell, header cell, and so on.",
                DemoView = typeof(DataGrid.ContextFlyout),
            };

            DemoInfo clipboardoperation = new DemoInfo()
            {
                Name = "Clipboard Operation",
                Category = "Interactive Features",
                DemoType = DemoTypes.New,
                Description = "The data grid provides an interactive support to perform cut, copy, and paste operations by using the CopyOption and PasteOption properties.",
                DemoView = typeof(DataGrid.ClipboardOperation),
            };

            DemoInfo datavalitations = new DemoInfo()
            {
                Name = "Data Validation",
                Category = "Data Validation",
                DemoType = DemoTypes.New,
                Description = "This sample showcases data validation for cells and displays hints in case the validation does not pass.",
                DemoView = typeof(DataGrid.DataValidation),
            };

            DemoInfo customvalidations = new DemoInfo()
            {
                Name = "Custom Validation",
                Category = "Data Validation",
                DemoType = DemoTypes.New,
                Description = "This sample showcases custom data validation for cells in a data grid by using the CurrentCellValidating and RowValidating events.",
                DemoView = typeof(DataGrid.CustomValidation),
            };

            DemoInfo unboundrows = new DemoInfo()
            {
                Name = "Unbound Rows",
                Category = "Row",
                DemoType = DemoTypes.New,
                Description = "The data grid provides support to add additional rows at the top and bottom of the SfDataGrid, which are not bound with data objects from the underlying data source.",
                DemoView = typeof(DataGrid.UnboundRows),
            };

            DemoInfo masterdetailsview = new DemoInfo()
            {
                Name = "Master Details View",
                Category = "Master Detail",
                DemoType = DemoTypes.New,
                Description = "The data grid displays hierarchical data in the form of nested tables using master-details view configuration.",
                DemoView = typeof(DataGrid.MasterDetailsView),
            };

            DemoInfo printing = new DemoInfo()
            {
                Name = "Printing",
                Category = "Print",
                DemoType = DemoTypes.New,
                Description = "The data grid provides support to print the data displayed. You can customize the various printing options such as orientation, page size, margin etc.",
                DemoView = typeof(DataGrid.Printing),
            };

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
                printing,
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
