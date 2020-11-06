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

namespace syncfusion.editordemos.winui
{
    public class SamplesConfiguration
    {
        public SamplesConfiguration()
        {
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
                colorPicker,
                dropDownColorPicker,
                colorPalette,
                dropDownColorPalette
            };

            DemoHelper.ControlInfos.AddRange(controlInfos);
        }
    }
}
