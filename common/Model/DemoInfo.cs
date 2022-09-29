#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;

namespace Syncfusion.DemosCommon.WinUI
{
    /// <summary>
    /// A model class represent a demo information.
    /// </summary>
    public class DemoInfo : ITileInfo
    {
        /// <summary>
        /// Gets or sets a value of name which represent the demo.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value of demo category.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets a value of <see cref="Syncfusion.DemosCommon.WinUI.DemoTypes"/>.
        /// </summary>
        public DemoTypes DemoType { get; set; }

        /// <summary>
        /// Gets or sets a value of ControlName for demo.
        /// </summary>
        public string ControlName { get; set; }

        /// <summary>
        /// Gets or sets a value of description which explains about the demo and its feature.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or set a value indicating whether the control used in this demo is in preview or not.
        /// </summary>
        public bool IsPreview { get; set; }

        /// <summary>
        /// Gets a value of glyph which represent the demo.
        /// </summary>
        public string Glyph { get; }

        /// <summary>
        /// Gets or sets a demo when searching that matched the search keyword.
        /// </summary>
        public string SearchItem { get; internal set; } 

        /// <summary>
        /// Gets a value of badge which fall under any of the <see cref="DemoType"/>.
        /// </summary>
        public string Badge
        {
            get
            {
                if ((this.DemoType & DemoTypes.Showcase) == DemoTypes.Showcase)
                {
                    if (this.DemoType.HasFlag(DemoTypes.New))
                    {
                        return Constants.New;
                    }
                    else if (this.DemoType.HasFlag(DemoTypes.Updated))
                    {
                        return Constants.Updated;
                    }
                }
                else
                {
                    if (this.DemoType.HasFlag(DemoTypes.New))
                    {
                        return Constants.New;
                    }
                    else if (this.DemoType.HasFlag(DemoTypes.Updated))
                    {
                        return Constants.Updated;
                    }
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// Gets or sets a value of demo page which holds the sample.
        /// </summary>
        public Type DemoView { get; set; }

        /// <summary>
        /// Gets a list of <see cref="Syncfusion.DemosCommon.WinUI.Documentation"/> which direct to help link.
        /// </summary>
        public List<Documentation> Documentation { get; } = new List<Documentation>();

        /// <summary>
        /// Gets a list of search string which represent the demo and its feature.
        /// </summary>
        public List<string> SearchKeys { get; }

        /// <summary>
        /// Gets or sets value that indicating whether the of <see cref="Syncfusion.DemosCommon.WinUI.Documentation"/ > panel is enabled on the demo page.
        /// </summary>
        public bool ShowInfoPanel { get; set; }
    }

    public class Documentation
    {
        /// <summary>
        /// Gets or sets a content of the help link.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets a value of uri which direct to the link.
        /// </summary>
        public Uri Uri { get; set; }
    }
}
