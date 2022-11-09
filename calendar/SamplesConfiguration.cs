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

namespace Syncfusion.CalendarDemos.WinUI
{
    public class SamplesConfiguration
    {
        public SamplesConfiguration()
        {
            DemoInfo calendarDemo = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "Calendar",
                DemoType = DemoTypes.None,
                Description = "The Calendar allows users to select the date.",
                DemoView = typeof(Views.Calendar.CalendarView),
                ShowInfoPanel=true
            };
            List<Documentation> calendarDemoDocumentations = new List<Documentation>();
            calendarDemoDocumentations.Add(new Documentation() { Content = "Calendar - API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Calendar.SfCalendar.html") });
            calendarDemoDocumentations.Add(new Documentation() { Content = "Calendar - Getting Started", Uri = new Uri("https://help.syncfusion.com/winui/calendar/getting-started") });
            calendarDemoDocumentations.Add(new Documentation() { Content = "Calendar - Date Selection", Uri = new Uri("https://help.syncfusion.com/winui/calendar/selection") });
            calendarDemoDocumentations.Add(new Documentation() { Content = "Calendar - View Navigation", Uri = new Uri("https://help.syncfusion.com/winui/calendar/navigation") });
            calendarDemoDocumentations.Add(new Documentation() { Content = "Calendar - Calendar Types", Uri = new Uri("https://help.syncfusion.com/winui/calendar/localization-and-formatting#types-of-calendar") });
            calendarDemo.Documentation.AddRange(calendarDemoDocumentations);

            DemoInfo calendarCustomizationDemo = new DemoInfo()
            {
                Name = "Customization",
                Category = "Calendar",
                DemoType = DemoTypes.None,
                Description = "Customization of the dates.",
                DemoView = typeof(Views.Calendar.Customization),
                ShowInfoPanel = true
            };
            List<Documentation> calendarCustomizationDemoDocumentations = new List<Documentation>();
            calendarCustomizationDemoDocumentations.Add(new Documentation() { Content = "Calendar - API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Calendar.SfCalendar.html") });
            calendarCustomizationDemoDocumentations.Add(new Documentation() { Content = "Calendar - Getting Started", Uri = new Uri("https://help.syncfusion.com/winui/calendar/getting-started") });
            calendarCustomizationDemoDocumentations.Add(new Documentation() { Content = "Calendar - Date Formatting", Uri = new Uri("https://help.syncfusion.com/winui/calendar/localization-and-formatting#change-date-display-format") });
            calendarCustomizationDemoDocumentations.Add(new Documentation() { Content = "Calendar - Block All Weekends", Uri = new Uri("https://help.syncfusion.com/winui/calendar/restrict-date-selection#disable-dates-dynamically-all-weekend-days") });
            calendarCustomizationDemoDocumentations.Add(new Documentation() { Content = "Calendar - Block Specific Dates", Uri = new Uri("https://help.syncfusion.com/winui/calendar/restrict-date-selection#disable-dates-using-blackoutdates") });
            calendarCustomizationDemo.Documentation.AddRange(calendarCustomizationDemoDocumentations);

            DemoInfo calendarStylesAndTemplatesDemo = new DemoInfo()
            {
                Name = "Styles and Templates",
                Category = "Calendar",
                DemoType = DemoTypes.None,
                Description = "Customization of styles and templates of the Calendar.",
                DemoView = typeof(Views.Calendar.StylesAndTemplates),
                ShowInfoPanel = true
            };
            List<Documentation> calendarStylesAndTemplatesDemoDocumentations = new List<Documentation>();
            calendarStylesAndTemplatesDemoDocumentations.Add(new Documentation() { Content = "Calendar - API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Calendar.SfCalendar.html") });
            calendarStylesAndTemplatesDemoDocumentations.Add(new Documentation() { Content = "Calendar - Getting Started", Uri = new Uri("https://help.syncfusion.com/winui/calendar/getting-started") });
            calendarStylesAndTemplatesDemoDocumentations.Add(new Documentation() { Content = "Calendar - Specific Cell's Custom UI", Uri = new Uri("https://help.syncfusion.com/winui/calendar/ui-customization#custom-ui-for-specific-cell-in-calendar") });
            calendarStylesAndTemplatesDemo.Documentation.AddRange(calendarStylesAndTemplatesDemoDocumentations);

            var calendar = new ControlInfo()
            {
                Control = DemoControl.SfCalendar,
                ControlBadge = ControlBadge.None,
                ControlCategory = ControlCategory.Calendars,
                Description = "The Calendar control allows user to select a date or dates quickly using built-in month, year, decade, and century views.",
                Glyph = "\uE710",
                ImageSource= "Calendar.png",
                IsPreview = true
            };
            calendar.Demos.Add(calendarDemo);
            calendar.Demos.Add(calendarCustomizationDemo);
            calendar.Demos.Add(calendarStylesAndTemplatesDemo);

            DemoInfo calendarDatePickerDemo = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "Calendar Date Picker",
                DemoType = DemoTypes.None,
                Description = "The Calendar Date Picker allows users to select the date through a drop-down menu.",
                DemoView = typeof(Views.CalendarDatePicker.CalendarDatePickerView),
                ShowInfoPanel = true
            };
            List<Documentation> calendarDatePickerDemoDocumentations = new List<Documentation>();
            calendarDatePickerDemoDocumentations.Add(new Documentation() { Content = "CalendarDatePicker - API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Calendar.SfCalendarDatePicker.html") });
            calendarDatePickerDemoDocumentations.Add(new Documentation() { Content = "CalendarDatePicker - Getting Started", Uri = new Uri("https://help.syncfusion.com/winui/calendar-datepicker/getting-started") });
            calendarDatePickerDemoDocumentations.Add(new Documentation() { Content = "CalendarDatePicker - View Navigation", Uri = new Uri("https://help.syncfusion.com/winui/calendar-date-picker/navigation") });
            calendarDatePickerDemoDocumentations.Add(new Documentation() { Content = "CalendarDatePicker - Calendar Types", Uri = new Uri("https://help.syncfusion.com/winui/calendar-date-picker/localization-and-formatting#types-of-calendar") });
            calendarDatePickerDemoDocumentations.Add(new Documentation() { Content = "CalendarDatePicker - Date Formatting", Uri = new Uri("https://help.syncfusion.com/winui/calendar-date-picker/localization-and-formatting#change-calendar-display-format") });
            calendarDatePickerDemoDocumentations.Add(new Documentation() { Content = "CalendarDatePicker - Block Specific Dates", Uri = new Uri("https://help.syncfusion.com/winui/calendar-date-picker/date-selection-and-restriction#block-dates-using-blackoutdates") });
            calendarDatePickerDemo.Documentation.AddRange(calendarDatePickerDemoDocumentations);

            DemoInfo calendarDatePickerCustomizationDemo = new DemoInfo()
            {
                Name = "Styles and Templates",
                Category = "Calendar Date Picker",
                DemoType = DemoTypes.None,
                Description = "Customization of styles and templates of the Calendar Date Picker.",
                DemoView = typeof(Views.CalendarDatePicker.Customization),
                ShowInfoPanel = true
            };
            List<Documentation> calendarDatePickerCustomizationDemoDocumentations = new List<Documentation>();
            calendarDatePickerCustomizationDemoDocumentations.Add(new Documentation() { Content = "CalendarDatePicker - API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Calendar.SfCalendarDatePicker.html") });
            calendarDatePickerCustomizationDemoDocumentations.Add(new Documentation() { Content = "CalendarDatePicker - Getting Started", Uri = new Uri("https://help.syncfusion.com/winui/calendar-datepicker/getting-started") });
            calendarDatePickerCustomizationDemoDocumentations.Add(new Documentation() { Content = "CalendarDatePicker - Specific Cell's Custom UI", Uri = new Uri("https://help.syncfusion.com/winui/calendar-date-picker/calendar-ui-customization#customize-individual-items-in-calendar") });
            calendarDatePickerCustomizationDemo.Documentation.AddRange(calendarDatePickerCustomizationDemoDocumentations);

            var calendarDatePicker = new ControlInfo()
            {
                Control = DemoControl.SfCalendarDatePicker,
                ControlBadge = ControlBadge.None,
                ControlCategory = ControlCategory.Calendars,
                Description = "The Calendar DatePicker is a drop-down control that is optimized for picking a single date from a Calendar control.",
                Glyph = "\uE711",
                ImageSource= "CalendarDatePicker.png",
                IsPreview = true
            };
            calendarDatePicker.Demos.Add(calendarDatePickerDemo);
            calendarDatePicker.Demos.Add(calendarDatePickerCustomizationDemo);

            DemoInfo calendarDateRangePickerDemo = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "Calendar DateRange Picker",
                DemoType = DemoTypes.None,
                Description = "The Calendar DateRangePicker allows users to select a range of dates.",
                DemoView = typeof(Views.CalendarDateRangePicker.CalendarDateRangePickerView),
                ShowInfoPanel = true
            };
            List<Documentation> calendarDateRangePickerDemoDocumentations = new List<Documentation>();
            calendarDateRangePickerDemoDocumentations.Add(new Documentation() { Content = "CalendarDateRangePicker - API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Calendar.SfCalendarDateRangePicker.html") });
            calendarDateRangePickerDemoDocumentations.Add(new Documentation() { Content = "CalendarDateRangePicker - Getting Started", Uri = new Uri("https://help.syncfusion.com/winui/calendar-daterange-picker/getting-started") });
            calendarDateRangePickerDemoDocumentations.Add(new Documentation() { Content = "CalendarDateRangePicker - View Navigation", Uri = new Uri("https://help.syncfusion.com/winui/calendar-daterange-picker/navigation") });
            calendarDateRangePickerDemoDocumentations.Add(new Documentation() { Content = "CalendarDateRangePicker - Calendar Types", Uri = new Uri("https://help.syncfusion.com/winui/calendar-daterange-picker/localization-and-formatting#types-of-calendar") });
            calendarDateRangePickerDemoDocumentations.Add(new Documentation() { Content = "CalendarDateRangePicker - Date Formatting", Uri = new Uri("https://help.syncfusion.com/winui/calendar-daterange-picker/localization-and-formatting#change-calendar-display-format") });
            calendarDateRangePickerDemoDocumentations.Add(new Documentation() { Content = "CalendarDateRangePicker - Preset Items", Uri = new Uri("https://help.syncfusion.com/winui/calendar-daterange-picker/show-preset-items") });
            calendarDateRangePickerDemoDocumentations.Add(new Documentation() { Content = "CalendarDateRangePicker - Block All Weekends", Uri = new Uri("https://help.syncfusion.com/winui/calendar-daterange-picker/restrict-daterange-selection#disable-dates-dynamically-all-weekend-days") });
            calendarDateRangePickerDemoDocumentations.Add(new Documentation() { Content = "CalendarDateRangePicker - Block Specific Dates", Uri = new Uri("https://help.syncfusion.com/winui/calendar-daterange-picker/restrict-daterange-selection#disable-dates-using-blackoutdates") });
            calendarDateRangePickerDemo.Documentation.AddRange(calendarDatePickerDemoDocumentations);

            DemoInfo calendarDateRangePickerCustomizationDemo = new DemoInfo()
            {
                Name = "Styles and Templates",
                Category = "Calendar DateRange Picker",
                DemoType = DemoTypes.None,
                Description = "Customization of styles and templates of the Calendar DateRange Picker.",
                DemoView = typeof(Views.CalendarDateRangePicker.Customization),
                ShowInfoPanel = true
            };
            List<Documentation> calendarDateRangePickerCustomizationDemoDocumentations = new List<Documentation>();
            calendarDateRangePickerCustomizationDemoDocumentations.Add(new Documentation() { Content = "CalendarDateRangePicker - API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Calendar.SfCalendarDateRangePicker.html") });
            calendarDateRangePickerCustomizationDemoDocumentations.Add(new Documentation() { Content = "CalendarDateRangePicker - Getting Started", Uri = new Uri("https://help.syncfusion.com/winui/calendar-daterange-picker/getting-started") });
            calendarDateRangePickerCustomizationDemoDocumentations.Add(new Documentation() { Content = "CalendarDateRangePicker - Specific Cell's Custom UI", Uri = new Uri("https://help.syncfusion.com/winui/calendar-daterange-picker/calendar-ui-customization#customize-individual-items-in-calendar") });
            calendarDateRangePickerCustomizationDemo.Documentation.AddRange(calendarDatePickerCustomizationDemoDocumentations);


            var calendarDateRangePicker = new ControlInfo()
            {
                Control = DemoControl.SfCalendarDateRangePicker,
                ControlBadge = ControlBadge.None,
                ControlCategory = ControlCategory.Calendars,
                Description = "The Calendar DateRangePicker is a drop-down control optimized for selecting a range of dates from a calendar control.",
                Glyph = "\uE713",
                ImageSource= "CalendarDateRangePicker.png",
                IsPreview = true
            };
            calendarDateRangePicker.Demos.Add(calendarDateRangePickerDemo);
            calendarDateRangePicker.Demos.Add(calendarDateRangePickerCustomizationDemo);

            var controlInfos = new List<ControlInfo>()
            {
                calendar,
                calendarDatePicker,
                calendarDateRangePicker
            };

            DemoHelper.ControlInfos.AddRange(controlInfos);
        }
    }
}
