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
                DemoType = DemoTypes.None,
                Description = "The Date Picker allows users to choose the date through a drop-down menu.",
                DemoView = typeof(Views.DatePicker.DatePickerView),
                ShowInfoPanel = true
            };
            List<Documentation> datePickerDemoDocumentations = new List<Documentation>();
            datePickerDemoDocumentations.Add(new Documentation() { Content = "DatePicker - API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Editors.SfDatePicker.html") });
            datePickerDemoDocumentations.Add(new Documentation() { Content = "DatePicker - Getting Started", Uri = new Uri("https://help.syncfusion.com/winui/date-picker/getting-started") });
            datePickerDemoDocumentations.Add(new Documentation() { Content = "DatePicker - Date Formatting", Uri = new Uri("https://help.syncfusion.com/winui/date-picker/localization-and-formatting#change-date-format-for-spinner") });
            datePickerDemoDocumentations.Add(new Documentation() { Content = "DatePicker - Limit the Available Dates", Uri = new Uri("https://help.syncfusion.com/winui/date-picker/date-restriction#limit-the-available-dates") });
            datePickerDemoDocumentations.Add(new Documentation() { Content = "DatePicker - Date Cells Customization", Uri = new Uri("https://help.syncfusion.com/winui/date-picker/dropdown-spinner-customization#change-the-size-of-dropdown-cells") });
            datePickerDemoDocumentations.Add(new Documentation() { Content = "DatePicker - Dropdown Customization", Uri = new Uri("https://help.syncfusion.com/winui/date-picker/dropdown-customization") });
            datePickerDemoDocumentations.Add(new Documentation() { Content = "DatePicker - Dropdown Header Customization", Uri = new Uri("https://help.syncfusion.com/winui/date-picker/dropdown-header-customization") });
            datePickerDemo.Documentation.AddRange(datePickerDemoDocumentations);

            DemoInfo datePickerCustomizationDemo = new DemoInfo()
            {
                Name = "Styles and Templates",
                Category = "Date Picker",
                DemoType = DemoTypes.None,
                Description = "Customization of styles and templates of the Date Picker.",
                DemoView = typeof(Views.DatePicker.Customization),
                ShowInfoPanel = true
            };
            List<Documentation> datePickerCustomizationDemoDocumentations = new List<Documentation>();
            datePickerCustomizationDemoDocumentations.Add(new Documentation() { Content = "DatePicker - API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Editors.SfDatePicker.html") });
            datePickerCustomizationDemoDocumentations.Add(new Documentation() { Content = "DatePicker - Getting Started", Uri = new Uri("https://help.syncfusion.com/winui/date-picker/getting-started") });
            datePickerCustomizationDemoDocumentations.Add(new Documentation() { Content = "DatePicker - Dropdown Header Custom UI", Uri = new Uri("https://help.syncfusion.com/winui/date-picker/dropdown-header-customization#customize-the-dropdown-header") });
            datePickerCustomizationDemoDocumentations.Add(new Documentation() { Content = "DatePicker - Custom Format String", Uri = new Uri("https://help.syncfusion.com/winui/date-picker/dropdown-spinner-customization#customize-the-columns-in-dropdown-spinner") });
            datePickerCustomizationDemoDocumentations.Add(new Documentation() { Content = "DatePicker - Block All Weekends", Uri = new Uri("https://help.syncfusion.com/winui/date-picker/date-restriction#disable-dates-dynamically-disable-weekends") });
            datePickerCustomizationDemoDocumentations.Add(new Documentation() { Content = "DatePicker - Date Cell Custom UI", Uri = new Uri("https://help.syncfusion.com/winui/date-picker/dropdown-spinner-customization#customize-the-cells-appearance-in-dropdown-spinner") });
            datePickerCustomizationDemo.Documentation.AddRange(datePickerCustomizationDemoDocumentations);

            DemoInfo timePickerDemo = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "Time Picker",
                DemoType = DemoTypes.None,
                Description = "The Time Picker allows users to choose the time through a drop-down menu.",
                DemoView = typeof(Views.TimePicker.TimePickerView),
                ShowInfoPanel = true
            };
            List<Documentation> timePickerDemoDocumentations = new List<Documentation>();
            timePickerDemoDocumentations.Add(new Documentation() { Content = "TimePicker - API Reference", Uri = new Uri("https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Editors.SfTimePicker.html") });
            timePickerDemoDocumentations.Add(new Documentation() { Content = "TimePicker - Getting Started", Uri = new Uri("https://help.syncfusion.com/winui/time-picker/getting-started") });
            timePickerDemoDocumentations.Add(new Documentation() { Content = "TimePicker - Time Formatting", Uri = new Uri("https://help.syncfusion.com/winui/time-picker/localization-and-formatting#change-time-display-format") });
            timePickerDemoDocumentations.Add(new Documentation() { Content = "TimePicker - Limit the Available Times", Uri = new Uri("https://help.syncfusion.com/winui/time-picker/time-restriction#limit-the-available-times") });
            timePickerDemoDocumentations.Add(new Documentation() { Content = "TimePicker - Time Cells Customization", Uri = new Uri("https://help.syncfusion.com/winui/time-picker/dropdown-spinner-customization#change-the-size-of-dropdown-cells") });
            timePickerDemoDocumentations.Add(new Documentation() { Content = "TimePicker - Dropdown Customization", Uri = new Uri("https://help.syncfusion.com/winui/time-picker/dropdown-customization") });
            timePickerDemoDocumentations.Add(new Documentation() { Content = "TimePicker - Dropdown Header Customization", Uri = new Uri("https://help.syncfusion.com/winui/time-picker/dropdown-header-customization") });
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
            timePickerCustomizationDemoDocumentations.Add(new Documentation() { Content = "TimePicker - Custom UI of Dropdown Header", Uri = new Uri("https://help.syncfusion.com/winui/time-picker/dropdown-header-customization#customize-the-dropdown-header") });
            timePickerCustomizationDemoDocumentations.Add(new Documentation() { Content = "TimePicker - Custom Time Field", Uri = new Uri("https://help.syncfusion.com/winui/time-picker/dropdown-spinner-customization#customize-the-columns-in-dropdown-spinner") });
            timePickerCustomizationDemoDocumentations.Add(new Documentation() { Content = "TimePicker - Custom UI of Time Cell", Uri = new Uri("https://help.syncfusion.com/winui/time-picker/dropdown-spinner-customization#customize-the-cells-appearance-in-dropdown-spinner") });
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
            colorPickerDemoDocumentations.Add(new Documentation() { Content = "ColorPicker - Brush Types", Uri = new Uri("https://help.syncfusion.com/winui/color-picker/getting-started#switch-between-solid-linear-and-radial-gradient-brush-mode") });
            colorPickerDemoDocumentations.Add(new Documentation() { Content = "ColorPicker - Color Spectrums", Uri = new Uri("https://help.syncfusion.com/winui/color-picker/ui-customization#change-color-spectrums-color-components") });
            colorPickerDemoDocumentations.Add(new Documentation() { Content = "ColorPicker - Solid Colors", Uri = new Uri("https://help.syncfusion.com/winui/color-picker/solid-color-selection") });
            colorPickerDemoDocumentations.Add(new Documentation() { Content = "ColorPicker - Gradient Colors", Uri = new Uri("https://help.syncfusion.com/winui/color-picker/gradient-color-selection") });
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
            dropDownColorPickerDemoDocumentations.Add(new Documentation() { Content = "DropDownColorPicker - ColorPicker as Command Button", Uri = new Uri("https://help.syncfusion.com/winui/dropdown-color-picker/dropdown-customization#color-picker-as-a-command-button") });
            dropDownColorPickerDemoDocumentations.Add(new Documentation() { Content = "DropDownColorPicker - Customization", Uri = new Uri("https://help.syncfusion.com/winui/dropdown-color-picker/customization-of-color-picker") });
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
            colorPaletteDemoDocumentations.Add(new Documentation() { Content = "ColorPalette - Customization", Uri = new Uri("https://help.syncfusion.com/winui/color-palette/ui-customization") });

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
            dropDownColorPaletteDemoDocumentations.Add(new Documentation() { Content = "DropDownColorPalette - ColorPalette as Command Button", Uri = new Uri("https://help.syncfusion.com/winui/dropdown-color-palette/dropdown-customization#color-palette-as-a-command-button") });
            dropDownColorPaletteDemoDocumentations.Add(new Documentation() { Content = "DropDownColorPalette - More Colors", Uri = new Uri("https://help.syncfusion.com/winui/dropdown-color-palette/more-colors-dialog") });
            dropDownColorPaletteDemoDocumentations.Add(new Documentation() { Content = "DropDownColorPalette - Customization", Uri = new Uri("https://help.syncfusion.com/winui/dropdown-color-palette/customization-of-color-palette") });
            dropDownColorPaletteDemo.Documentation.AddRange(dropDownColorPaletteDemoDocumentations);

            DemoInfo numberBoxGettingStartedDemo = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "NumberBox",
                Description = "This sample showcases the basic features such as number formatting, watermark, up-down button, and input restriction.",
                DemoView = typeof(Views.NumberBox.GettingStartedView),
                DemoType= DemoTypes.None,
                ShowInfoPanel = false,
                
            };

            DemoInfo numberBoxCultureDemo = new DemoInfo()
            {
                Name = "Culture",
                Category = "NumberBox",
                Description = "The NumberBox displays currency, decimal, and percent numbers in different cultures.",
                DemoView = typeof(Views.NumberBox.CultureView),
                DemoType = DemoTypes.None,
                ShowInfoPanel = false,

            };

            DemoInfo comboboxGettingStartedDemo = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "ComboBox",
                Description = "A ComboBox allows users to type a value or choose an option from a list of predefined options.",
                DemoView = typeof(Views.ComboBox.GettingStarted),
                DemoType = DemoTypes.Updated,
                ShowInfoPanel = false,
            };

            DemoInfo comboboxEditingDemo = new DemoInfo()
            {
                Name = "Editing",
                Category = "ComboBox",
                Description = "When editing a text, the combox filters and displays suggestions based on the entered text.",
                DemoView = typeof(Views.ComboBox.Editing),
                DemoType = DemoTypes.None,
                ShowInfoPanel = false,
            };

            DemoInfo comboboxSelectionDemo = new DemoInfo()
            {
                Name = "Multiple Selection",
                Category = "ComboBox",
                Description = "A ComboBox allows users to select multiple items from the listed options.",
                DemoView = typeof(Views.ComboBox.MultiSelection),
                DemoType = DemoTypes.Updated,
                ShowInfoPanel = false,
            };

            DemoInfo comboboxSearchingDemo = new DemoInfo()
            {
                Name = "Searching",
                Category = "ComboBox",
                Description = "A ComboBox allows users to search for an option from the list of predefined options.",
                DemoView = typeof(Views.ComboBox.Searching),
                DemoType = DemoTypes.None,
                ShowInfoPanel = false,
            };

            DemoInfo comboboxFilteringDemo = new DemoInfo()
            {
                Name = "Filtering",
                Category = "ComboBox",
                Description = "The ComboBox has built-in support to filter the data source when characters are typed in the search box.",
                DemoView = typeof(Views.ComboBox.Filtering),
                DemoType = DemoTypes.Updated,
                ShowInfoPanel = false,
            };

            DemoInfo comboboxGroupingDemo = new DemoInfo()
            {
                Name = "Grouping",
                Category = "ComboBox",
                Description = "The ComboBox allows you to group relevant items under a corresponding category.",
                DemoView = typeof(Views.ComboBox.Grouping),
                DemoType = DemoTypes.None,
                ShowInfoPanel = false,
            };

            DemoInfo segmentedGettingStarted = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "Segmented Control",
                Description = "Populates the segments from a collection of strings and views along with the objects of built-in classes.",
                DemoView = typeof(Views.SegmentedControl.GettingStarted),
                ShowInfoPanel = false
            };

            DemoInfo segmentedCustomization = new DemoInfo()
            {
                Name = "Customization",
                Category = "Segmented Control",
                Description = "Supports customizing text and other UI elements.",
                DemoView = typeof(Views.SegmentedControl.Customization),
                DemoType = DemoTypes.Updated,
                ShowInfoPanel = false
            };

            DemoInfo autoCompleteGettingStartedDemo = new DemoInfo()
            {
                Name = "Getting Started",
                Category = "AutoComplete",
                Description = "The AutoComplete control allows users to type a value in the control and the relevant data will be loaded automatically.",
                DemoView = typeof(Views.AutoComplete.GettingStarted),
                DemoType = DemoTypes.New,
                ShowInfoPanel = false,
            };

            DemoInfo autoCompleteMultiSelectionDemo = new DemoInfo()
            {
                Name = "Multiple Selection",
                Category = "AutoComplete",
                Description = "The AutoComplete control allows users to select multiple items from the listed options.",
                DemoView = typeof(Views.AutoComplete.MultiSelection),
                DemoType = DemoTypes.New,
                ShowInfoPanel = false,
            };
            DemoInfo autoCompleteFilteringDemo = new DemoInfo()
            {
                Name = "Searching and Filtering",
                Category = "AutoComplete",
                Description = "The AutoComplete control has built-in support to filter the data source when characters are typed in the search box.",
                DemoView = typeof(Views.AutoComplete.Filtering),
                DemoType = DemoTypes.New,
                ShowInfoPanel = false,
            };
            DemoInfo autoCompleteGroupingDemo = new DemoInfo()
            {
                Name = "Grouping",
                Category = "AutoComplete",
                Description = "The AutoComplete control allows you to group corresponding items under a category.",
                DemoView = typeof(Views.AutoComplete.Grouping),
                DemoType = DemoTypes.New,
                ShowInfoPanel = false,
            };
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

            var numberBox = new ControlInfo()
            {
                Control = DemoControl.SfNumberBox,
                ControlCategory = ControlCategory.Editors,
                ControlBadge = ControlBadge.None,
                Description = "The NumberBox is a numeric input editor control that supports number formatting, watermark, up-down button, input restriction, and different cultures support.",
                Glyph = "\uE714"
            };
            numberBox.Demos.Add(numberBoxGettingStartedDemo);
            numberBox.Demos.Add(numberBoxCultureDemo);

            var comboBox = new ControlInfo()
            {
                Control = DemoControl.SfComboBox,
                ControlCategory = ControlCategory.Editors,
                ControlBadge = ControlBadge.Updated,
                Description = "The WinUI ComboBox control (drop-down) is a text box component that allows users to type a value or choose an option from a list of predefined options.",
                Glyph = "\uE71c"
            };
            comboBox.Demos.Add(comboboxGettingStartedDemo);
            comboBox.Demos.Add(comboboxEditingDemo);
            comboBox.Demos.Add(comboboxSelectionDemo);
            comboBox.Demos.Add(comboboxSearchingDemo);
            comboBox.Demos.Add(comboboxFilteringDemo);
            comboBox.Demos.Add(comboboxGroupingDemo);

            var segmentedControl = new ControlInfo()
            {
                Control = DemoControl.SegmentedControl,
                ControlCategory = ControlCategory.Editors,
                ControlBadge = ControlBadge.Updated,
                Description = "The Segmented Control provides a simple way to choose from a linear set of two or more segments, each of which functions as a mutually exclusive button.",
                Glyph= "\uE71d"
            };
            segmentedControl.Demos.Add(segmentedGettingStarted);
            segmentedControl.Demos.Add(segmentedCustomization);

            var autoComplete = new ControlInfo()
            {
                Control = DemoControl.SfAutoComplete,
                ControlCategory = ControlCategory.Editors,
                ControlBadge = ControlBadge.New,
                Description = "The AutoComplete control is a text box component that allows users to type some characters in the control and the appropriate data will be automatically loaded.",
                Glyph = "\uE71b"
            };
            autoComplete.Demos.Add(autoCompleteGettingStartedDemo);
            autoComplete.Demos.Add(autoCompleteMultiSelectionDemo);
            autoComplete.Demos.Add(autoCompleteFilteringDemo);
            autoComplete.Demos.Add(autoCompleteGroupingDemo);
          

            var controlInfos = new List<ControlInfo>()
            {
                autoComplete,
                comboBox,
                segmentedControl,
                datePicker,
                timePicker,
                colorPicker,
                dropDownColorPicker,
                colorPalette,
                dropDownColorPalette,
                numberBox,              
            };

            DemoHelper.ControlInfos.AddRange(controlInfos);
        }
    }
}
