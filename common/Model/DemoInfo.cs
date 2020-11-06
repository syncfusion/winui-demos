#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;

namespace syncfusion.demoscommon.winui
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
        /// Gets or sets a value of <see cref="syncfusion.demoscommon.winui.DemoTypes"/>.
        /// </summary>
        public DemoTypes DemoType { get; set; }

        /// <summary>
        /// Gets or sets a value of description which explains about the demo and its feature.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets a value of glyph which represent the demo.
        /// </summary>
        public string Glyph { get; }

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
        /// Gets a list of <see cref="syncfusion.demoscommon.winui.Documentation"/> which direct to help link.
        /// </summary>
        public List<Documentation> Documentation { get; } = new List<Documentation>();

        /// <summary>
        /// Gets a list of search string which represent the demo and its feature.
        /// </summary>
        public List<string> SearchKeys { get; }
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
