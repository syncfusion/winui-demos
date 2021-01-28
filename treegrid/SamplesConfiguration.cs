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


namespace syncfusion.treegriddemos.winui
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
            };

            DemoInfo nestedcollection = new DemoInfo()
            {
                Name = "Nested Collection",
                Category = "Getting Started",
                DemoType = DemoTypes.None,
                Description = "This sample showcases how to bind the nested collection by specifying the ChildPropertyName property in a tree grid.",
                DemoView = typeof(TreeGrid.NestedCollection),
            };

            DemoInfo selection = new DemoInfo()
            {
                Name = "Selection",
                Category = "Editing and Selection",
                DemoType = DemoTypes.None,
                Description = "The Tree Grid control allows you to sort data against one or more columns.Additional sorting functionalities include tristate sorting and displaying sort numbers to indicate the sort order.",
                DemoView = typeof(TreeGrid.Selection),
            };

            DemoInfo sorting = new DemoInfo()
            {
                Name = "Sorting",
                Category = "Sorting",
                DemoType = DemoTypes.None,
                Description = "The tree grid allows you to sort data against one or more columns. Additional  sorting functionalities include tristate sorting and displaying sort numbers to indicate the sort order.",
                DemoView = typeof(TreeGrid.Sorting),
            };

            DemoInfo advancedfiltering = new DemoInfo()
            {
                Name = "Filtering",
                Category = "Filtering",
                DemoType = DemoTypes.None,
                Description = "The tree grid provides support to filter columns like the Excel inspired UI.",
                DemoView = typeof(TreeGrid.AdvancedFiltering),
            };

            DemoInfo columnsizer = new DemoInfo()
            {
                Name = "AutoFit Column",
                Category = "AutoFit Column",
                DemoType = DemoTypes.None,
                Description = "The tree grid provides built-in support to set the width of the column based on the content in the cells by defining the ColumnWidthMode property.",
                DemoView = typeof(TreeGrid.ColumnSizer),
            };

            DemoInfo freezecolumns = new DemoInfo()
            {
                Name = "Freeze Columns",
                Category = "Appearance",
                DemoType = DemoTypes.New,
                Description = "The tree grid provides support to freeze columns, similar to Excel, with the help of FrozenRowCount, FooterRowsCount, FrozenColumnCount, and FooterColumnCount properties.",
                DemoView = typeof(TreeGrid.FreezeColumns),
            };

            DemoInfo ondemandloading = new DemoInfo()
            {
                Name = "On-Demand Loading",
                Category = "Getting Started",
                DemoType = DemoTypes.New,
                Description = "This sample showcases loading data on demand in a tree grid.",
                DemoView = typeof(TreeGrid.OnDemandLoading),
            };

            DemoInfo editing = new DemoInfo()
            {
                Name = "Editing",
                Category = "Editing and Selection",
                DemoType = DemoTypes.New,
                Description = "The tree grid provides support to edit cells with built-in editors such as TextBox and ComboBox. Trigger the edit mode with a single or double tap.",
                DemoView = typeof(TreeGrid.Editing),
            };

            DemoInfo datavalidation = new DemoInfo()
            {
                Name = "Data Validation",
                Category = "Data Validation",
                DemoType = DemoTypes.New,
                Description = "This sample showcases data validation for cells and displays hints in case the validation does not pass.",
                DemoView = typeof(TreeGrid.DataValidation),
            };

            DemoInfo checkboxselection = new DemoInfo()
            {
                Name = "CheckBox Selection",
                Category = "Node CheckBox",
                DemoType = DemoTypes.New,
                Description = "This sample showcases how nodes can be selected using CheckBoxes available in each row of a tree grid.",
                DemoView = typeof(TreeGrid.CheckBoxSelection),
            };

            DemoInfo clipboardoperation = new DemoInfo()
            {
                Name = "Clipboard Operation",
                Category = "Interactive Features",
                DemoType = DemoTypes.New,
                Description = "The tree grid provides an interactive support to perform cut, copy, and paste operations by using the CopyOption and PasteOption properties.",
                DemoView = typeof(TreeGrid.ClipboardOperation),
            };

            var demos = new List<DemoInfo>()
            {
                selfrelational,
                nestedcollection,
                ondemandloading,
                sorting,
                advancedfiltering,
                selection,
                editing,
                datavalidation,
                checkboxselection,
                columnsizer,
                freezecolumns,
                clipboardoperation,
            };

            var controlInfo = new ControlInfo()
            {
                Control = DemoControl.SfTreeGrid,
                ControlCategory = ControlCategory.Grids,
                Description = "The Tree Grid control displays the hierarchical or self-relational data in a tree structure with multicolumn interface like multicolumn treeview.",
                Glyph= "\uE702"
            };

            controlInfo.Demos.AddRange(demos);
            DemoHelper.ControlInfos.Add(controlInfo);
        }
    }
}
