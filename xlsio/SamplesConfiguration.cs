#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
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

namespace Syncfusion.XlsIODemos.WinUI
{
    public class SamplesConfiguration
    {
        public SamplesConfiguration()
        {
			DemoInfo createspreadsheetdemo = new DemoInfo()
            {
                Name = "Create Spreadsheet",
                Category = "Getting Started",
                Description = "This example demonstrates how to create a simple Excel worksheet with text, numbers, formulas, and styles.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.CreateSpreadsheet),
                ShowInfoPanel = true
            };
            createspreadsheetdemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "Excel library - Create a Worksheet", Uri = new Uri("https://help.syncfusion.com/file-formats/xlsio/working-with-excel-worksheet"), } });

            DemoInfo attendancetrackerdemo = new DemoInfo()
            {
                Name = "Attendance Tracker",
                Category = "Product Showcase",
                Description = "This example demonstrates how to create a monthly attendance tracking report in an Excel worksheet using XlsIO features like formulas, cell styles, conditional formatting, and data validation.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.AttendanceTracker),
                ShowInfoPanel = true
            };
            attendancetrackerdemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "Excel library - Create a Attendance Tracking Report", Uri = new Uri("https://help.syncfusion.com/file-formats/xlsio/overview"), } });

            DemoInfo formatcellsdemo = new DemoInfo()
            {
                Name = "Format Cells",
                Category = "Formatting",
                Description = "This example demonstrates how to provide cell styles like font name, font color, font size, number format, and background color for cells in an Excel worksheet.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.FormatCells),
                ShowInfoPanel = true
            };
            formatcellsdemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "Excel library - Worksheet Cells Manipulation", Uri = new Uri("https://help.syncfusion.com/file-formats/xlsio/worksheet-cells-manipulation"), } });

			DemoInfo conditionalformattingdemo = new DemoInfo()
            {
                Name = "Conditional Formatting",
                Category = "Formatting",
                Description = "This example demonstrates how to use different conditional formatting options on a range of cells to format the cells based on their values in an Excel worksheet.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.ConditionalFormatting),
                ShowInfoPanel = true
            };
            conditionalformattingdemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "Excel library - Working with Conditional Formatting", Uri = new Uri("https://help.syncfusion.com/file-formats/xlsio/working-with-conditional-formatting"), } });

			DemoInfo formulademo = new DemoInfo()
            {
                Name = "Formula",
                Category = "Formulas",
                Description = "This example demonstrates how to read a formula, write a formula, and access the formula's calculated value in an Excel worksheet.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.Formula),
                ShowInfoPanel = true
            };
            formulademo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "Excel library - Working with Formulas", Uri = new Uri("https://help.syncfusion.com/file-formats/xlsio/working-with-formulas"), } });

            DemoInfo sunburstdemo = new DemoInfo()
            {
                Name = "Sunburst Chart",
                Category = "Charts",
                Description = "This example demonstrates how to create a sunburst chart which is ideal for displaying data in a hierarchy in an Excel worksheet.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.Sunburst),
                ShowInfoPanel = true
            };
            sunburstdemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "Excel library - Working with Sunburst Chart", Uri = new Uri("https://help.syncfusion.com/file-formats/xlsio/working-with-charts#sunburst"), } });

            DemoInfo boxandwhiskerdemo = new DemoInfo()
            {
                Name = "Box And Whisker",
                Category = "Charts",
                Description = "This example demonstrates how to create a box and whisker chart in an Excel worksheet.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.BoxAndWhisker),
                ShowInfoPanel = true
            };
            boxandwhiskerdemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "Excel library - Working with Box And Whisker chart", Uri = new Uri("https://help.syncfusion.com/file-formats/xlsio/working-with-charts#box-and-whisker"), } });

            DemoInfo treemapdemo = new DemoInfo()
            {
                Name = "Treemap",
                Category = "Charts",
                Description = "This example demonstrates how to create a tree map chart in an Excel worksheet.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.Treemap),
                ShowInfoPanel = true
            };
            treemapdemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "Excel library - Working with Treemap chart", Uri = new Uri("https://help.syncfusion.com/file-formats/xlsio/working-with-charts#treemap"), } });

            DemoInfo columnchartdemo = new DemoInfo()
            {
                Name = "Column Chart",
                Category = "Charts",
                Description = "This example demonstrates how to create a simple column chart in an Excel workhsheet.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.ColumnChart),
                ShowInfoPanel = true
            };
            columnchartdemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "Excel library - Working with charts", Uri = new Uri("https://help.syncfusion.com/file-formats/xlsio/working-with-charts"), } });

			DemoInfo sparklinesdemo = new DemoInfo()
            {
                Name = "Sparklines",
                Category = "Charts",
                Description = "This example demonstrates how to create sparkline charts which graphically represent data in an Excel worksheet.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.Sparklines),
                ShowInfoPanel = true
            };
            sparklinesdemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "Excel library - Working with Sparkline chart", Uri = new Uri("https://help.syncfusion.com/file-formats/xlsio/working-with-charts#sparkline"), } });

            DemoInfo datavalidationdemo = new DemoInfo()
            {
                Name = "Data Validation",
                Category = "Data Management",
                Description = "This example demonstrates how to set data validation rules for cells in an Excel worksheet.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.DataValidation),
                ShowInfoPanel = true
            };
            datavalidationdemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "Excel library - Working with Data Validation", Uri = new Uri("https://help.syncfusion.com/file-formats/xlsio/working-with-data-validation"), } });

			DemoInfo sortingdemo = new DemoInfo()
            {
                Name = "Sorting",
                Category = "Data Management",
                Description = "This example demonstrates how to perform sorting based on cell values and colors in an Excel worksheet.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.Sorting),
                ShowInfoPanel = true
            };
            sortingdemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "Excel library - Worksheet Cells Manipulation", Uri = new Uri("https://help.syncfusion.com/file-formats/xlsio/worksheet-cells-manipulation#data-sorting"), } });

            DemoInfo templatemarkerdemo = new DemoInfo()
            {
                Name = "Template Marker",
                Category = "Import Data",
                Description = "This example demonstrates how to import data into a predefined Excel template.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.TemplateMarker),
                ShowInfoPanel = true
            };
            templatemarkerdemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "Excel library - Working with Template Markers", Uri = new Uri("https://help.syncfusion.com/file-formats/xlsio/working-with-template-markers"), } });

            DemoInfo importhtmltabledemo = new DemoInfo()
            {
                Name = "Import HTML Table",
                Category = "Import Data",
                Description = "This example demonstrates how to import data from a table in an HTML file into an Excel workbook.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.ImportHTMLTable),
                ShowInfoPanel = true
            };
            importhtmltabledemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "Excel library - Importing HTML Table to Excel Worksheet", Uri = new Uri("https://help.syncfusion.com/file-formats/xlsio/working-with-data#importing-html-table-to-excel-worksheet"), } });

            DemoInfo exceltopdfdemo = new DemoInfo()
            {
                Name = "Excel To PDF",
                Category = "Conversions",
                Description = "This example demonstrates how to convert an Excel workbook to PDF along with its charts, shapes, cell styles, etc.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.ExcelToPDF),
                ShowInfoPanel = true
            };
            exceltopdfdemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "Excel library - Excel to PDF Conversion", Uri = new Uri("https://help.syncfusion.com/file-formats/xlsio/excel-to-pdf-conversion"), } });

            DemoInfo worksheettoimagedemo = new DemoInfo()
            {
                Name = "Worksheet To Image",
                Category = "Conversions",
                Description = "This example demonstrates how to convert an Excel workbook to an image in PNG or JPEG format.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.WorksheetToImage),
                ShowInfoPanel = true
            };
            worksheettoimagedemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "Excel library - Worksheet to Image conversion in Excel Library", Uri = new Uri("https://help.syncfusion.com/file-formats/xlsio/worksheet-to-image-conversion"), } });

            DemoInfo exceltojsondemo = new DemoInfo()
            {
                Name = "Excel To JSON",
                Category = "Conversions",
                Description = "This example demonstrates how to convert a workbook or a specific range of cells in an Excel worksheet to JSON format.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.ExcelToJSON),
                ShowInfoPanel = true
            };
            exceltojsondemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "Excel library - Excel to JSON Conversion", Uri = new Uri("https://help.syncfusion.com/file-formats/xlsio/excel-to-json-conversion"), } });

            DemoInfo encryptanddecryptdemo = new DemoInfo()
            {
                Name = "Encrypt and Decrypt",
                Category = "Security",
                Description = "This example demonstrates how to encrypt and decrypt an Excel workbook  with a password.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.EncryptAndDecrypt),
                ShowInfoPanel = true
            };
            encryptanddecryptdemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "Excel library - Security in Excel (XlsIO) Library", Uri = new Uri("https://help.syncfusion.com/file-formats/xlsio/security"), } });

            DemoInfo tablesdemo = new DemoInfo()
            {
                Name = "Tables",
                Category = "Business Intelligence",
                Description = "This example demonstrates how to create tables in an Excel worksheet along with table styles.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.Tables),
                ShowInfoPanel = true
            };
            tablesdemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "Excel library - Working with Excel Tables", Uri = new Uri("https://help.syncfusion.com/file-formats/xlsio/working-with-excel-tables"), } });

            DemoInfo autoshapesdemo = new DemoInfo()
            {
                Name = "Auto Shapes",
                Category = "Shapes",
                Description = "This example demonstrates how to add shapes with styles in an Excel worksheet.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.AutoShape),
                ShowInfoPanel = true
            };
            autoshapesdemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "Excel library - Working with AutoShapes", Uri = new Uri("https://help.syncfusion.com/file-formats/xlsio/working-with-drawing-objects#autoshapes"), } });

            DemoInfo groupshapesdemo = new DemoInfo()
            {
                Name = "Group Shapes",
                Category = "Shapes",
                Description = "This example demonstrates how to create group shapes and how to ungroup group shapes in an Excel worksheet.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.GroupShape),
                ShowInfoPanel = true
            };
            groupshapesdemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "Excel library - Working with Group Shapes", Uri = new Uri("https://help.syncfusion.com/file-formats/xlsio/working-with-drawing-objects#group-shapes"), } });

            DemoInfo createmacrodemo = new DemoInfo()
            {
                Name = "Create Macro",
                Category = "Macros",
                Description = "This example demonstrates how to use macro code in an Excel worksheet to create a chart.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.CreateMacro),
                ShowInfoPanel = true
            };
            createmacrodemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "Excel library - Creating a Macro", Uri = new Uri("https://help.syncfusion.com/file-formats/xlsio/working-with-macros#creating-a-macro"), } });

            DemoInfo editmacrodemo = new DemoInfo()
            {
                Name = "Edit Macro",
                Category = "Macros",
                Description = "This example demonstrates how to edit macro code in an Excel worksheet to modify an existing chart element.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.EditMacro),
                ShowInfoPanel = true
            };
            editmacrodemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "Excel library -  Editing a Macro", Uri = new Uri("https://help.syncfusion.com/file-formats/xlsio/working-with-macros#editing-a-macro"), } });

            DemoInfo yearlysalesdemo = new DemoInfo()
            {
                Name = "Yearly Sales",
                Category = "Product Showcase",
                Description = "This example demonstrates how to create an Excel report for yearly sales with data, charts, formulas, and cell formatting.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.YearlySales),
                ShowInfoPanel = true
            };
            yearlysalesdemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "Excel library - Create an Excel report for yearly sales", Uri = new Uri("https://help.syncfusion.com/file-formats/xlsio/overview"), } });

            DemoInfo invoicedemo = new DemoInfo()
            {
                Name = "Invoice",
                Category = "Product Showcase",
                Description = "This example demonstrates how to create an Excel invoice with data, images, formulas, and cell formatting.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.Invoice),
                ShowInfoPanel = true
            };
            invoicedemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "Excel library - Create an Excel Invoice", Uri = new Uri("https://help.syncfusion.com/file-formats/xlsio/overview"), } });

            DemoInfo expensesreportdemo = new DemoInfo()
            {
                Name = "Expense Report",
                Category = "Product Showcase",
                Description = "This example demonstrates how to create an Excel report for expenses with data, charts, formulas, and cell formatting.",
                DemoType = DemoTypes.None,
                DemoView = typeof(Views.ExpensesReport),
                ShowInfoPanel = true
            };
            expensesreportdemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "Excel library - Create an Excel report for expenses with data", Uri = new Uri("https://help.syncfusion.com/file-formats/xlsio/overview"), } });

            var demos = new List<DemoInfo>()
            {
                createspreadsheetdemo,
                attendancetrackerdemo,
                formatcellsdemo,
                conditionalformattingdemo,
                formulademo,
                columnchartdemo,
                sparklinesdemo,
                sunburstdemo,
                boxandwhiskerdemo,
                treemapdemo,
                datavalidationdemo,
                sortingdemo,
                templatemarkerdemo,
                importhtmltabledemo,
                exceltopdfdemo,
                worksheettoimagedemo,
                exceltojsondemo,
                encryptanddecryptdemo,
                tablesdemo,
                autoshapesdemo,
                groupshapesdemo,
                createmacrodemo,
                editmacrodemo,
                yearlysalesdemo,
                invoicedemo,
                expensesreportdemo
            };

            var xlsiocontrolInfo = new ControlInfo()
            {
                Control = DemoControl.XlsIO,
                Description = "Syncfusion XlsIO is a .NET class library to create, read, edit and modify Microsoft Excel documents along with conversion of Excel documents to PDF and image.",
                ControlBadge = ControlBadge.None ,
                ControlCategory = ControlCategory.FileFormat,
                Glyph = "\uE721",
                ImageSource = "XlsIO.png"
            };

            xlsiocontrolInfo.Demos.AddRange(demos);
            DemoHelper.ControlInfos.Add(xlsiocontrolInfo);
        }

    }
}
