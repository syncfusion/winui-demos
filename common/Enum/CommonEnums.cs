#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel.DataAnnotations;

namespace syncfusion.demoscommon.winui
{
    /// <summary>
    /// Specifies a control category that should be mentioned in each controls
    /// </summary>
    public enum ControlCategory
    {
        [Display(Name = "GRID")]
        Grids,

        [Display(Name = "DATA VISUALIZATION")]
        DataVisualization,

        [Display(Name = "LAYOUT")]
        Layout,

        [Display(Name = "EDITORS")]
        Editors,

        [Display(Name = "NAVIGATION")]
        Navigation,

        [Display(Name = "NOTIFICATION")]
        Notification,

        [Display(Name = "FILE FORMAT")]
        FileFormat,

        [Display(Name = "REPORTING")]
        Reporting,

        [Display(Name = "BUSINESS INTELLIGENCE")]
        BusinessIntelligence,

        [Display(Name = "DATA SCIENCE")]
        DataScience,

        [Display(Name = "MISCELLANEOUS")]
        Miscellaneous
    }

    /// <summary>
    /// Specifies a control
    /// </summary>
    public enum DemoControl
    {
        [Display(Name = "Data Grid")]
        SfDataGrid,

        [Display(Name = "Tree Grid")]
        SfTreeGrid,
        
        [Display(Name = "Tree View")]
        SfTreeView,
        
        [Display(Name = "Charts")]
        SfChart,

        [Display(Name = "Radial Gauge")]
        SfRadialGauge,

        [Display(Name = "Badge")]
        SfBadge,

        [Display(Name = "TimePicker")]
        SfTimePicker,

        [Display(Name = "Color Picker")]
        SfColorPicker,

        [Display(Name = "Dropdown Color Picker")]
        SfDropDownColorPicker,

        [Display(Name = "Color Palette")]
        SfColorPalette,

        [Display(Name = "Dropdown Color Palette")]
        SfDropDownColorPalette,

        [Display(Name = "Barcode")]
        Barcode
    }

    /// </summary>
    /// Specifies a demo type which should mention in each demo
    /// </summary>
    [Flags]
    public enum DemoTypes
    {
        None = 0,
        Showcase = 1,
        New = 2,
        Updated = 4,
    }
}
