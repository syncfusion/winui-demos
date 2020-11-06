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

            DemoInfo rowselection = new DemoInfo()
            {
                Name = "Selection",
                Category = "Selection",
                DemoType = DemoTypes.None,
                Description = "The data grid provides an interactive support for selecting rows in different modes smoothly and easily . It also supports selecting one or more rows programmatically or using mouse and keyboard interactions. Rows can be selected using the SelectionMode property . This property provides selection options like single, multiple, xxtended, and none.yy",
                DemoView = typeof(DataGrid.RowSelection),

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
                Description = "The data grid allows you to add additional unbound header rows, known as stacked header rows, that span across columns. You can categorize two or more columns under each of the stacked header.",
                DemoView = typeof(DataGrid.StackedHeader),

            };

            DemoInfo autorowheight = new DemoInfo()
            {
                Name = "Auto Row Height",
                Category = "Row",
                DemoType = DemoTypes.None,
                Description = "The data grid provides support to auto-fit the height of the rows to improve readability of the content.",
                DemoView = typeof(DataGrid.AutoRowHeight),

            };



            var demos = new List<DemoInfo>()
            {
                gettingstarted,
                rowselection,
                editing,
                sorting,
                advancefilter,
                grouping,
                summaries,
                autorowheight,
                stackedheaders,
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
