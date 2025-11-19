#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syncfusion.EditorDemos.WinUI
{
    /// <summary>
    /// Represents country-specific information, including its flag image, name, and culture code.
    /// This class is used as a data model, particularly in demos related to cultural formatting.
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Gets or sets the flag image for the country.
        /// </summary>
        public BitmapImage FlagImage { get; set; }
        /// <summary>
        /// Gets or sets the name of the country.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the culture code associated with the country (e.g., "en-US").
        /// </summary>
        public string Culture { get; set; }
    }

    /// <summary>
    /// Represents a unit of measurement or a specific value, identified by its display name and underlying value.
    /// This class is used as a data model, typically in demos demonstrating formatting options.
    /// </summary>
    public class Unit
    {
        /// <summary>
        /// Gets or sets the display name of the unit (e.g., "Kilograms", "Meters").
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the underlying value or code representing the unit (e.g., "kg", "m").
        /// </summary>
        public string Value { get; set; }
    }
}
