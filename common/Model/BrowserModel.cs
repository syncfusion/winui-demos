#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;

namespace Syncfusion.DemosCommon.WinUI
{
    /// <summary>
    /// A model class represent a browser model
    /// </summary>
    public class BrowserModel
    {
        /// <summary>
        /// Gets or sets a value of name which represent the demo name or its group.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value of content which holds the demo info, control info or group name.
        /// </summary>
        public object Content { get; set; }

        /// <summary>
        /// Gets or sets a value of icon to represent the control or demo.
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Gets or sets a list of browser model to hold the inner items.
        /// </summary>
        public List<BrowserModel> Items { get; internal set; }
    }
}
