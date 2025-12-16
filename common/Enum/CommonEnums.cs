#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel.DataAnnotations;

namespace Syncfusion.DemosCommon.WinUI
{
    /// <summary>
    /// Specifies a control category that should be mentioned in each controls
    /// </summary>
    public enum ControlCategory
    {
        /// <summary>
        /// Represents controls related to Artificial Intelligence and smart solutions.
        /// </summary>
        [Display(Name = "SMART COMPONENTS")]
        SmartComponents,

        /// <summary>
        /// Represents controls related to data grids and tabular data display.
        /// </summary>
        [Display(Name = "GRID")]
        Grids,
        /// <summary>
        /// Represents controls for visualizing data, such as charts and graphs.
        /// </summary>
        [Display(Name = "DATA VISUALIZATION")]
        DataVisualization,
        /// <summary>
        /// Represents controls used for layout and arrangement of UI elements.
        /// </summary>
        [Display(Name = "LAYOUT")]
        Layout,

        /// <summary>
        /// Represents controls used for data input and editing, such as text boxes and pickers.
        /// </summary>
        [Display(Name = "EDITORS")]
        Editors,

        /// <summary>
        /// Represents controls related to navigation and user interface flow.
        /// </summary>
        [Display(Name = "NAVIGATION")]
        Navigation,

        /// <summary>
        /// Represents controls related to calendars and date/time selection.
        /// </summary>
        [Display(Name = "CALENDARS")]
        Calendars,

        /// <summary>
        /// Represents controls used for notifications and alerts.
        /// </summary>
        [Display(Name = "NOTIFICATION")]
        Notification,

        /// <summary>
        /// Represents controls related to file formats or file operations.
        /// </summary>
        [Display(Name = " ")]
        FileFormat,

        /// <summary>
        /// Represents controls related to reporting tools and functionalities.
        /// </summary>
        [Display(Name = "REPORTING")]
        Reporting,

        /// <summary>
        /// Represents controls for business intelligence and data analysis.
        /// </summary>
        [Display(Name = "BUSINESS INTELLIGENCE")]
        BusinessIntelligence,

        /// <summary>
        /// Represents controls for data science and machine learning capabilities.
        /// </summary>
        [Display(Name = "DATA SCIENCE")]
        DataScience,

        /// <summary>
        /// Represents other controls that do not fit into specific categories.
        /// </summary>
        [Display(Name = "MISCELLANEOUS")]
        Miscellaneous
    }

    /// <summary>
    /// Specifies a list of supported Syncfusion WPF controls.
    /// Each enum member has a <see cref="DisplayAttribute"/> to provide a user-friendly name.
    /// </summary>
    public enum DemoControl
    {
        /// <summary>
        /// Represents the AI Solutions feature.
        /// </summary>
        [Display(Name = "Smart AI Solutions")]
        SmartAISolutions,

        /// <summary>
        /// Represents the SfDataGrid control.
        /// </summary>
        [Display(Name = "DataGrid")]
        SfDataGrid,

        /// <summary>
        /// Represents the SfTreeGrid control.
        /// </summary>
        [Display(Name = "TreeGrid")]
        SfTreeGrid,

        /// <summary>
        /// Represents the SfTreeView control.
        /// </summary>
        [Display(Name = "TreeView")]
        SfTreeView,

        /// <summary>
        /// Represents the SfCartesianChart control for 2D charts.
        /// </summary>
        [Display(Name = "Cartesian Charts")]
        SfCartesianChart,

        /// <summary>
        /// Represents the SfCircularChart control for pie and other circular charts.
        /// </summary>
        [Display(Name = "Circular Charts")]
        SfCircularChart,

        /// <summary>
        /// Represents the SfFunnelChart control.
        /// </summary>
        [Display(Name = "Funnel Chart")]
        SfFunnelChart,

        /// <summary>
        /// Represents the SfPyramidChart control.
        /// </summary>
        [Display(Name = "Pyramid Chart")]
        SfPyramidChart,

        /// <summary>
        /// Represents the SfPolarChart control.
        /// </summary>
        [Display(Name = "Polar Charts")]
        SfPolarChart,

        /// <summary>
        /// Represents the SfRadialGauge control.
        /// </summary>
        [Display(Name = "Radial Gauge")]
        SfRadialGauge,

        /// <summary>
        /// Represents the SfLinearGauge control.
        /// </summary>
        [Display(Name = "Linear Gauge")]
        SfLinearGauge,

        /// <summary>
        /// Represents the SfBadge control.
        /// </summary>
        [Display(Name = "Badge")]
        SfBadge,

        /// <summary>
        /// Represents the SfCalendar control.
        /// </summary>
        [Display(Name = "Calendar")]
        SfCalendar,

        /// <summary>
        /// Represents the SfCalendarDatePicker control.
        /// </summary>
        [Display(Name = "Calendar Date Picker")]
        SfCalendarDatePicker,

        /// <summary>
        /// Represents the SfDatePicker control.
        /// </summary>
        [Display(Name = "Date Picker")]
        SfDatePicker,

        /// <summary>
        /// Represents the SfTimePicker control.
        /// </summary>
        [Display(Name = "Time Picker")]
        SfTimePicker,

        /// <summary>
        /// Represents the SfColorPicker control for selecting colors.
        /// </summary>
        [Display(Name = "Color Picker")]
        SfColorPicker,

        /// <summary>
        /// Represents the SfDropDownColorPicker control.
        /// </summary>
        [Display(Name = "Dropdown Color Picker")]
        SfDropDownColorPicker,

        /// <summary>
        /// Represents the SfColorPalette control.
        /// </summary>
        [Display(Name = "Color Palette")]
        SfColorPalette,

        /// <summary>
        /// Represents the SfDropDownColorPalette control.
        /// </summary>
        [Display(Name = "Dropdown Color Palette")]
        SfDropDownColorPalette,

        /// <summary>
        /// Represents the SfNumberBox control for numeric input.
        /// </summary>
        [Display(Name = "NumberBox")]
        SfNumberBox,

        /// <summary>
        /// Represents the SegmentedControl control.
        /// </summary>
        [Display(Name = "Segmented Control")]
        SegmentedControl,

        /// <summary>
        /// Represents the Barcode generation control.
        /// </summary>
        [Display(Name = "Barcode")]
        Barcode,

        /// <summary>
        /// Represents the SfSlider control.
        /// </summary>
        [Display(Name = "Slider")]
        SfSlider,

        /// <summary>
        /// Represents the SfRangeSlider control.
        /// </summary>
        [Display(Name = "Range Slider")]
        SfRangeSlider,

        /// <summary>
        /// Represents the SfRibbon control.
        /// </summary>
        [Display(Name = "Ribbon")]
        SfRibbon,

        /// <summary>
        /// Represents the SfScheduler control for scheduling events.
        /// </summary>
        [Display(Name = "Scheduler")]
        SfScheduler,

        /// <summary>
        /// Represents the SfKanban control for visualizing tasks in a workflow.
        /// </summary>
        [Display(Name = "Kanban")]
        SfKanban,

        /// <summary>
        /// Represents the SfCalendarDateRangePicker control.
        /// </summary>
        [Display(Name = "Calendar DateRange Picker")]
        SfCalendarDateRangePicker,

        /// <summary>
        /// Represents the SfComboBox control.
        /// </summary>
        [Display(Name = "ComboBox")]
        SfComboBox,

        /// <summary>
        /// Represents the SfAutoComplete control for type-ahead suggestions.
        /// </summary>
        [Display(Name = "AutoComplete")]
        SfAutoComplete,

        /// <summary>
        /// Represents the XlsIO library for Excel file manipulation.
        /// </summary>
        [Display(Name = "XlsIO")]
        XlsIO,

        /// <summary>
        /// Represents the EssentialPresentation library for PowerPoint file manipulation.
        /// </summary>
        [Display(Name = "Presentation")]
        EssentialPresentation,

        /// <summary>
        /// Represents the PDF library for PDF document manipulation.
        /// </summary>
        [Display(Name = "PDF")]
        PDF,

        /// <summary>
        /// Represents the EssentialDocIO library for Word document manipulation.
        /// </summary>
        [Display(Name = "DocIO")]
        EssentialDocIO,

        /// <summary>
        /// Represents the SfShadow control for applying shadows.
        /// </summary>
        [Display(Name = "Shadow")]
        SfShadow,

        /// <summary>
        /// Represents the SfBusyIndicator control for showing loading states.
        /// </summary>
        [Display(Name = "BusyIndicator")]
        SfBusyIndicator,

        /// <summary>
        /// Represents the SfRating control for user ratings.
        /// </summary>
        [Display(Name = "Rating")]
        SfRating,

        /// <summary>
        /// Represents the SfMaskedTextBox control for formatted input.
        /// </summary>
        [Display(Name = "MaskedTextBox")]
        SfMaskedTextBox,

        /// <summary>
        /// Represents the SfAvatarView control for displaying user avatars.
        /// </summary>
        [Display(Name = "AvatarView")]
        SfAvatarView,

        /// <summary>
        /// Represents the SfShimmer control for creating shimmer loading effects.
        /// </summary>
        [Display(Name = "Shimmer")]
        SfShimmer,

        /// <summary>
        /// Represents the SfAIAssistView control for AI-assisted input.
        /// </summary>
        [Display(Name = "AIAssistView")]
        SfAIAssistView
    }

    /// <summary>
    /// Specifies the type of a demo. This enum can be combined using flags.
    /// </summary>
    [Flags]
    public enum DemoTypes
    {
        /// <summary>
        /// No specific demo type.
        /// </summary>
        None = 0,
        /// <summary>
        /// Indicates a demo that showcases features.
        /// </summary>
        Showcase = 1,
        /// <summary>
        /// Indicates a newly added demo.
        /// </summary>
        New = 2,
        /// <summary>
        /// Indicates a demo that has been recently updated.
        /// </summary>
        Updated = 4,
        /// <summary>
        /// Indicates a demo related to AI samples or solutions.
        /// </summary>
        AISamples = 8,
    }

    /// <summary>
    /// Specifies a tag that can be used to denote new or updated controls.
    /// </summary>
    public enum ControlBadge
    {
        /// <summary>
        /// No badge is applied.
        /// </summary>
        None = 0,
        /// <summary>
        /// Indicates a new control.
        /// </summary>
        New = 1,
        /// <summary>
        /// Indicates an updated control.
        /// </summary>
        Updated = 2
    }
}
