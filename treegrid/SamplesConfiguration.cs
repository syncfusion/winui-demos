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
                Category = "Selection",
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

            var demos = new List<DemoInfo>()
            {
                selfrelational,
                columnsizer,
                selection,
                sorting,
                nestedcollection,
                advancedfiltering,

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
