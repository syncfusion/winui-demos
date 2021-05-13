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
            DemoInfo datePickerDemo = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "Date Picker",
                DemoType = DemoTypes.Updated,
                Description = "The Date Picker allows users to choose the date through a drop-down menu.",
                DemoView = typeof(Views.DatePicker.DatePickerView),
                ShowInfoPanel = true
            };
            List<Documentation> datePickerDemoDocumentations = new List<Documentation>();
            datePickerDemoDocumentations.Add(new Documentation() { Content = "DatePicker - API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Editors.SfDatePicker.html") });
            datePickerDemoDocumentations.Add(new Documentation() { Content = "DatePicker - Getting Started", Uri = new Uri("https://help.syncfusion.com/winui/date-picker/getting-started") });
            datePickerDemoDocumentations.Add(new Documentation() { Content = "DatePicker - Date Formatting", Uri = new Uri("https://help.syncfusion.com/winui/date-picker/getting-started#change-date-display-format") });
            datePickerDemoDocumentations.Add(new Documentation() { Content = "DatePicker - Block Days", Uri = new Uri("https://help.syncfusion.com/winui/date-picker/getting-started#block-dates-using-blackoutdates") });
            datePickerDemoDocumentations.Add(new Documentation() { Content = "DatePicker - Date Spinner Customization", Uri = new Uri("https://help.syncfusion.com/winui/date-picker/dropdown-date-spinner") });
            datePickerDemo.Documentation.AddRange(datePickerDemoDocumentations);

            DemoInfo datePickerCustomizationDemo = new DemoInfo()
            {
                Name = "Styles and Templates",
                Category = "Date Picker",
                DemoType = DemoTypes.Updated,
                Description = "Customization of styles and templates of the Date Picker.",
                DemoView = typeof(Views.DatePicker.Customization),
                ShowInfoPanel = true
            };
            List<Documentation> datePickerCustomizationDemoDocumentations = new List<Documentation>();
            datePickerCustomizationDemoDocumentations.Add(new Documentation() { Content = "DatePicker - API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Editors.SfDatePicker.html") });
            datePickerCustomizationDemoDocumentations.Add(new Documentation() { Content = "DatePicker - Getting Started", Uri = new Uri("https://help.syncfusion.com/winui/date-picker/getting-started") });
            datePickerCustomizationDemoDocumentations.Add(new Documentation() { Content = "DatePicker - Dropdown Header Custom UI", Uri = new Uri("https://help.syncfusion.com/winui/date-picker/dropdown-date-spinner#custom-ui-of-dropdown-header") });
            datePickerCustomizationDemoDocumentations.Add(new Documentation() { Content = "DatePicker - Custom Format String", Uri = new Uri("https://help.syncfusion.com/winui/date-picker/dropdown-date-spinner#customize-the-date-field-in-dropdown-spinner-using-event") });
            datePickerCustomizationDemoDocumentations.Add(new Documentation() { Content = "DatePicker - Block All Weekends", Uri = new Uri("https://help.syncfusion.com/winui/date-picker/getting-started#disableblock-all-weekends") });
            datePickerCustomizationDemoDocumentations.Add(new Documentation() { Content = "DatePicker - Date Cell Custom UI", Uri = new Uri("https://help.syncfusion.com/winui/date-picker/dropdown-date-spinner#custom-ui-for-specific-cell-in-dropdown-spinner") });
            datePickerCustomizationDemo.Documentation.AddRange(datePickerCustomizationDemoDocumentations);

            DemoInfo timePickerDemo = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "Time Picker",
                DemoType = DemoTypes.Updated,
                Description = "The Time Picker allows users to choose the time through a drop-down menu.",
                DemoView = typeof(Views.TimePicker.TimePickerView),
                ShowInfoPanel = true
            };
            List<Documentation> timePickerDemoDocumentations = new List<Documentation>();
            timePickerDemoDocumentations.Add(new Documentation() { Content = "TimePicker - API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Editors.SfTimePicker.html") });
            timePickerDemoDocumentations.Add(new Documentation() { Content = "TimePicker - Getting Started", Uri = new Uri("https://help.syncfusion.com/winui/time-picker/getting-started") });
            timePickerDemoDocumentations.Add(new Documentation() { Content = "TimePicker - Time Formatting", Uri = new Uri("https://help.syncfusion.com/winui/time-picker/getting-started#change-time-display-format") });
            timePickerDemoDocumentations.Add(new Documentation() { Content = "TimePicker - Block Times", Uri = new Uri("https://help.syncfusion.com/winui/time-picker/getting-started#block-times-using-blackouttimes") });
            timePickerDemoDocumentations.Add(new Documentation() { Content = "TimePicker - Time Spinner Customization", Uri = new Uri("https://help.syncfusion.com/winui/time-picker/dropdown-time-spinner") });
            timePickerDemo.Documentation.AddRange(timePickerDemoDocumentations);

            DemoInfo timePickerCustomizationDemo = new DemoInfo()
            {
                Name = "Styles and Templates",
                Category = "Time Picker",
                Description = "Customization of styles and templates of the Time Picker.",
                DemoView = typeof(Views.TimePicker.Customization),
                ShowInfoPanel = true
            };
            List<Documentation> timePickerCustomizationDemoDocumentations = new List<Documentation>();
            timePickerCustomizationDemoDocumentations.Add(new Documentation() { Content = "TimePicker - API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Editors.SfTimePicker.html") });
            timePickerCustomizationDemoDocumentations.Add(new Documentation() { Content = "TimePicker - Getting Started", Uri = new Uri("https://help.syncfusion.com/winui/time-picker/getting-started") });
            timePickerCustomizationDemoDocumentations.Add(new Documentation() { Content = "TimePicker - Custom UI of Dropdown Header", Uri = new Uri("https://help.syncfusion.com/winui/time-picker/dropdown-time-spinner#custom-ui-of-dropdown-header") });
            timePickerCustomizationDemoDocumentations.Add(new Documentation() { Content = "TimePicker - Custom Time Field", Uri = new Uri("https://help.syncfusion.com/winui/time-picker/dropdown-time-spinner#customize-the-time-fields-in-dropdown-spinner-using-event") });
            timePickerCustomizationDemoDocumentations.Add(new Documentation() { Content = "TimePicker - Custom UI of Time Cell", Uri = new Uri("https://help.syncfusion.com/winui/time-picker/dropdown-time-spinner#custom-ui-for-specific-cell-in-dropdown-spinner") });
            timePickerCustomizationDemo.Documentation.AddRange(timePickerCustomizationDemoDocumentations);

            DemoInfo colorPickerDemo = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "Color Picker",
                Description = "The Color Picker allows users to edit solid and gradient colors, and provides RGB, HSV, HSL, CMYK, and hex color modes for color selection.",
                DemoView = typeof(Views.ColorPicker.ColorPickerView),
                ShowInfoPanel = true
            };
            List<Documentation> colorPickerDemoDocumentations = new List<Documentation>();
            colorPickerDemoDocumentations.Add(new Documentation() { Content = "ColorPicker - API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Editors.SfColorPicker.html") });
            colorPickerDemoDocumentations.Add(new Documentation() { Content = "ColorPicker - Getting Started", Uri = new Uri("https://help.syncfusion.com/winui/color-picker/getting-started") });
            colorPickerDemoDocumentations.Add(new Documentation() { Content = "ColorPicker - Brush Types", Uri = new Uri("https://help.syncfusion.com/winui/color-picker/colorpicker-customization#enable-specific-brush-mode") });
            colorPickerDemoDocumentations.Add(new Documentation() { Content = "ColorPicker - Color Spectrums", Uri = new Uri("https://help.syncfusion.com/winui/color-picker/colorpicker-customization#change-color-spectrums-color-components") });
            colorPickerDemoDocumentations.Add(new Documentation() { Content = "ColorPicker - Solid Colors", Uri = new Uri("https://help.syncfusion.com/winui/color-picker/solid-colors") });
            colorPickerDemoDocumentations.Add(new Documentation() { Content = "ColorPicker - Gradient Colors", Uri = new Uri("https://help.syncfusion.com/winui/color-picker/gradient-colors") });
            colorPickerDemo.Documentation.AddRange(colorPickerDemoDocumentations);

            DemoInfo dropDownColorPickerDemo = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "Dropdown Color Picker",
                Description = "The Dropdown Color Picker allows users to edit a solid and gradient brush through a drop-down menu.",
                DemoView = typeof(Views.DropDownColorPicker.DropDownColorPickerView),
                ShowInfoPanel = true
            };
            List<Documentation> dropDownColorPickerDemoDocumentations = new List<Documentation>();
            dropDownColorPickerDemoDocumentations.Add(new Documentation() { Content = "DropDownColorPicker - API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winUI/Syncfusion.UI.Xaml.Editors.SfDropDownColorPicker.html") });
            dropDownColorPickerDemoDocumentations.Add(new Documentation() { Content = "DropDownColorPicker - Getting Started", Uri = new Uri("https://help.syncfusion.com/winui/dropdown-color-picker/getting-started") });
            dropDownColorPickerDemoDocumentations.Add(new Documentation() { Content = "DropDownColorPicker - ColorPicker as Command Button", Uri = new Uri("https://help.syncfusion.com/winui/dropdown-color-picker/getting-started#color-picker-as-a-command-button") });
            dropDownColorPickerDemoDocumentations.Add(new Documentation() { Content = "DropDownColorPicker - Customization", Uri = new Uri("https://help.syncfusion.com/winui/dropdown-color-picker/getting-started#customize-the-colorpicker") });
            dropDownColorPickerDemo.Documentation.AddRange(dropDownColorPickerDemoDocumentations);

            DemoInfo colorPaletteDemo = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "Color Palette",
                Description = "The Color Palette allows users to select a color from a list of available colors.",
                DemoView = typeof(Views.ColorPalette.ColorPaletteView),
                ShowInfoPanel = true
            };
            List<Documentation> colorPaletteDemoDocumentations = new List<Documentation>();
            colorPaletteDemoDocumentations.Add(new Documentation() { Content = "ColorPalette - API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winUI/Syncfusion.UI.Xaml.Editors.SfColorPalette.html") });
            colorPaletteDemoDocumentations.Add(new Documentation() { Content = "ColorPalette - Getting Started", Uri = new Uri("https://help.syncfusion.com/winui/color-palette/getting-started") });
            colorPaletteDemoDocumentations.Add(new Documentation() { Content = "ColorPalette - Theme Colors", Uri = new Uri("https://help.syncfusion.com/winui/color-palette/theme-colors") });
            colorPaletteDemoDocumentations.Add(new Documentation() { Content = "ColorPalette - Standard Colors", Uri = new Uri("https://help.syncfusion.com/winui/color-palette/standard-colors") });
            colorPaletteDemoDocumentations.Add(new Documentation() { Content = "ColorPalette - More Colors", Uri = new Uri("https://help.syncfusion.com/winui/color-palette/more-color-dialog") });
            colorPaletteDemoDocumentations.Add(new Documentation() { Content = "ColorPalette - Customization", Uri = new Uri("https://help.syncfusion.com/winui/color-palette/control-customization") });

            colorPaletteDemo.Documentation.AddRange(colorPaletteDemoDocumentations);

            DemoInfo dropDownColorPaletteDemo = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "Dropdown Color Palette",
                Description = "The Dropdown Color Palette allows users to select a color from a available colors in a drop-down list.",
                DemoView = typeof(Views.DropDownColorPalette.DropDownColorPaletteView),
                ShowInfoPanel = true
            };
            List<Documentation> dropDownColorPaletteDemoDocumentations = new List<Documentation>();
            dropDownColorPaletteDemoDocumentations.Add(new Documentation() { Content = "DropDownColorPalette - API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winUI/Syncfusion.UI.Xaml.Editors.SfDropDownColorPalette.html") });
            dropDownColorPaletteDemoDocumentations.Add(new Documentation() { Content = "DropDownColorPalette - Getting Started", Uri = new Uri("https://help.syncfusion.com/winui/dropdown-color-palette/getting-started") });
            dropDownColorPaletteDemoDocumentations.Add(new Documentation() { Content = "DropDownColorPalette - ColorPalette as Command Button", Uri = new Uri("https://help.syncfusion.com/winui/dropdown-color-palette/getting-started#color-palette-as-a-command-button") });
            dropDownColorPaletteDemoDocumentations.Add(new Documentation() { Content = "DropDownColorPalette - Customization", Uri = new Uri("https://help.syncfusion.com/winui/dropdown-color-palette/getting-started#customize-the-colorpalette") });
            dropDownColorPaletteDemo.Documentation.AddRange(dropDownColorPaletteDemoDocumentations);

            var datePicker = new ControlInfo()
            {
                Control = DemoControl.SfDatePicker,
                ControlCategory = ControlCategory.Calendars,
                Description = "The DatePicker provides a standardized way to pick a date using spinner in dropdown using touch, mouse, or keyboard input.",
                Glyph = "\uE700"
            };
            datePicker.Demos.Add(datePickerDemo);
            datePicker.Demos.Add(datePickerCustomizationDemo);

            var timePicker = new ControlInfo()
            {
                Control = DemoControl.SfTimePicker,
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
