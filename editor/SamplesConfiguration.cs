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

namespace syncfusion.editordemos.winui
{
    public class SamplesConfiguration
    {
        public SamplesConfiguration()
        {
            DemoInfo calendarDemo = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "Calendar",
                DemoType = DemoTypes.New,
                Description = "The Calendar allows users to select the date.",
                DemoView = typeof(Views.Calendar.CalendarView)
            };
            calendarDemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "SfCalendar - API", Uri = new Uri("https://help.syncfusion.com") } });

            DemoInfo calendarCustomizationDemo = new DemoInfo()
            {
                Name = "Styles and Templates",
                Category = "Calendar",
                DemoType = DemoTypes.New,
                Description = "Customization of styles and templates of the Calendar.",
                DemoView = typeof(Views.Calendar.Customization)
            };
            calendarCustomizationDemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "SfCalendar - API", Uri = new Uri("https://help.syncfusion.com") } });

            DemoInfo calendarDatePickerDemo = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "Calendar Date Picker",
                DemoType = DemoTypes.New,
                Description = "The Calendar Date Picker allows users to select the date through a drop-down menu.",
                DemoView = typeof(Views.CalendarDatePicker.CalendarDatePickerView)
            };
            calendarDatePickerDemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "SfCalendarDatePicker - API", Uri = new Uri("https://help.syncfusion.com") } });

            DemoInfo calendarDatePickerCustomizationDemo = new DemoInfo()
            {
                Name = "Styles and Templates",
                Category = "Calendar Date Picker",
                DemoType = DemoTypes.New,
                Description = "Customization of styles and templates of the Calendar Date Picker.",
                DemoView = typeof(Views.CalendarDatePicker.Customization)
            };
            calendarDatePickerCustomizationDemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "SfCalendarDatePicker - API", Uri = new Uri("https://help.syncfusion.com") } });

            DemoInfo datePickerDemo = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "Date Picker",
                DemoType = DemoTypes.New,
                Description = "The Date Picker allows users to choose the date through a drop-down menu.",
                DemoView = typeof(Views.DatePicker.DatePickerView)
            };
            datePickerDemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "SfDatePicker - API", Uri = new Uri("https://help.syncfusion.com") } });

            DemoInfo datePickerCustomizationDemo = new DemoInfo()
            {
                Name = "Styles and Templates",
                Category = "Date Picker",
                DemoType = DemoTypes.New,
                Description = "Customization of styles and templates of the Date Picker.",
                DemoView = typeof(Views.DatePicker.Customization)
            };
            datePickerCustomizationDemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "SfDatePicker - API", Uri = new Uri("https://help.syncfusion.com") } });

            DemoInfo timePickerDemo = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "Time Picker",
                DemoType = DemoTypes.New,
                Description = "The Time Picker allows users to choose the time through a drop-down menu.",
                DemoView = typeof(Views.TimePicker.TimePickerView)
            };
            timePickerDemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "SfTimePicker - API", Uri = new Uri("https://help.syncfusion.com") } });

            DemoInfo timePickerCustomizationDemo = new DemoInfo()
            {
                Name = "Styles and Templates",
                Category = "Time Picker",
                DemoType = DemoTypes.New,
                Description = "Customization of styles and templates of the Time Picker.",
                DemoView = typeof(Views.TimePicker.Customization)
            };
            timePickerCustomizationDemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "SfTimePicker - API", Uri = new Uri("https://help.syncfusion.com") } });

            DemoInfo colorPickerDemo = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "Color Picker",
                Description = "The Color Picker allows users to edit solid and gradient colors, and provides RGB, HSV, HSL, CMYK, and hex color modes for color selection.",
                DemoView = typeof(Views.ColorPicker.ColorPickerView)
            };
            colorPickerDemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "SfColorPicker - API", Uri = new Uri("https://help.syncfusion.com") } });

            DemoInfo dropDownColorPickerDemo = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "Dropdown Color Picker",
                Description = "The Dropdown Color Picker allows users to edit a solid and gradient brush through a drop-down menu.",
                DemoView = typeof(Views.DropDownColorPicker.DropDownColorPickerView)
            };
            dropDownColorPickerDemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "SfDropDownColorPicker - API", Uri = new Uri("https://help.syncfusion.com") } });

            DemoInfo colorPaletteDemo = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "Color Palette",
                Description = "The Color Palette allows users to select a color from a list of available colors.",
                DemoView = typeof(Views.ColorPalette.ColorPaletteView)
            };
            colorPaletteDemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "SfColorPalette - API", Uri = new Uri("https://help.syncfusion.com") } });

            DemoInfo dropDownColorPaletteDemo = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "Dropdown Color Palette",
                Description = "The Dropdown Color Palette allows users to select a color from a available colors in a drop-down list.",
                DemoView = typeof(Views.DropDownColorPalette.DropDownColorPaletteView)
            };
            dropDownColorPaletteDemo.Documentation.AddRange(new List<Documentation>()
                { new Documentation() { Content = "SfDropDownColorPalette - API", Uri = new Uri("https://help.syncfusion.com") } });

            var calendar = new ControlInfo()
            {
                Control = DemoControl.SfCalendar,
                ControlBadge = ControlBadge.New,
                ControlCategory = ControlCategory.Calendars,
                Description = "The Calendar control allows user to select a date or dates quickly using built-in month, year, decade, and century views.",
                Glyph = "\uE710"
            };
            calendar.Demos.Add(calendarDemo);
            calendar.Demos.Add(calendarCustomizationDemo);

            var calendarDatePicker = new ControlInfo()
            {
                Control = DemoControl.SfCalendarDatePicker,
                ControlBadge = ControlBadge.New,
                ControlCategory = ControlCategory.Calendars,
                Description = "The Calendar DatePicker is a drop-down control that is optimized for picking a single date from a Calendar control.",
                Glyph = "\uE711"
            };
            calendarDatePicker.Demos.Add(calendarDatePickerDemo);
            calendarDatePicker.Demos.Add(calendarDatePickerCustomizationDemo);

            var datePicker = new ControlInfo()
            {
                Control = DemoControl.SfDatePicker,
                ControlBadge = ControlBadge.New,
                ControlCategory = ControlCategory.Calendars,
                Description = "The DatePicker provides a standardized way to pick a date using spinner in dropdown using touch, mouse, or keyboard input.",
                Glyph = "\uE700"
            };
            datePicker.Demos.Add(datePickerDemo);
            datePicker.Demos.Add(datePickerCustomizationDemo);

            var timePicker = new ControlInfo()
            {
                Control = DemoControl.SfTimePicker,
                ControlBadge = ControlBadge.New,
                ControlCategory = ControlCategory.Calendars,
                Description = "The TimePicker provides a standardized way to pick a time using spinner in dropdown using touch, mouse, or keyboard input.",
                Glyph = "\uE701"
            };
            timePicker.Demos.Add(timePickerDemo);
            timePicker.Demos.Add(timePickerCustomizationDemo);

            var colorPicker = new ControlInfo()
            {
                Control = DemoControl.SfColorPicker,
                ControlCategory = ControlCategory.Editors,
                Description = "The Color Picker allows users to edit solid and gradient colors, and provides RGB, HSV, HSL, CMYK, and hex color modes for color selection.",
                Glyph = "\uE705"
            };
            colorPicker.Demos.Add(colorPickerDemo);

            var dropDownColorPicker = new ControlInfo()
            {
                Control = DemoControl.SfDropDownColorPicker,
                ControlCategory = ControlCategory.Editors,
                Description = "The Dropdown Color Picker allows users to edit a solid and gradient brush through a drop-down menu.",
                Glyph = "\uE70a"
            };
            dropDownColorPicker.Demos.Add(dropDownColorPickerDemo);

            var colorPalette = new ControlInfo()
            {
                Control = DemoControl.SfColorPalette,
                ControlCategory = ControlCategory.Editors,
                Description = "The Color Palette allows users to select a color from a list of available colors.",
                Glyph = "\uE70c"
            };
            colorPalette.Demos.Add(colorPaletteDemo);

            var dropDownColorPalette = new ControlInfo()
            {
                Control = DemoControl.SfDropDownColorPalette,
                ControlCategory = ControlCategory.Editors,
                Description = "The Dropdown Color Palette allows users to select a color from a available colors in a drop-down list.",
                Glyph = "\uE70b"
            };
            dropDownColorPalette.Demos.Add(dropDownColorPaletteDemo);

            var controlInfos = new List<ControlInfo>()
            {
                calendar,
                calendarDatePicker,
                datePicker,
                timePicker,
                colorPicker,
                dropDownColorPicker,
                colorPalette,
                dropDownColorPalette
            };

            DemoHelper.ControlInfos.AddRange(controlInfos);
        }
    }
}
