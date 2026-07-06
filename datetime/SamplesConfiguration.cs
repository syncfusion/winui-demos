using Syncfusion.DemosCommon.WinUI;
using System;
using System.Collections.Generic;

namespace Syncfusion.DateTimeDemos.WinUI
{
    /// <summary>
    /// Represents the configuration settings for samples, potentially used to load or manage demo samples.
    /// </summary>
    public class SamplesConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SamplesConfiguration"/> class.
        /// This constructor is intended for basic initialization. If specific setup is required, it should be performed by calling other methods or setting properties after instantiation.
        /// </summary>
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

            var datePicker = new ControlInfo()
            {
                Control = DemoControl.SfDatePicker,
                ControlCategory = ControlCategory.Calendars,
                Description = "The DatePicker provides a standardized way to pick a date using spinner in dropdown using touch, mouse, or keyboard input.",
                Glyph = "\uE700",
                ImageSource = "DatePicker.png"
            };
            datePicker.Demos.Add(datePickerDemo);
            datePicker.Demos.Add(datePickerCustomizationDemo);

            var timePicker = new ControlInfo()
            {
                Control = DemoControl.SfTimePicker,
                ControlCategory = ControlCategory.Calendars,
                Description = "The TimePicker provides a standardized way to pick a time using spinner in dropdown using touch, mouse, or keyboard input.",
                Glyph = "\uE701",
                ImageSource = "TimePicker.png"
            };
            timePicker.Demos.Add(timePickerDemo);
            timePicker.Demos.Add(timePickerCustomizationDemo);

            var controlInfos = new List<ControlInfo>()
            {
                datePicker,
                timePicker,
            };

            DemoHelper.ControlInfos.AddRange(controlInfos);
        }
    }
}
