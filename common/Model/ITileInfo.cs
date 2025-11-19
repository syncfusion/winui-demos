#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Syncfusion.DemosCommon.WinUI
{
    /// <summary>
    /// An interface to represent a tile information.
    /// </summary>
    public interface ITileInfo
    {
        /// <summary>
        /// Gets the name of the tile.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets or sets the category of the tile.
        /// </summary>
        string Category { get; set; }

        /// <summary>
        /// Gets or sets a descriptive text for the tile.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets the badge text for the tile (e.g., "New", "Updated").
        /// </summary>
        string Badge { get; }
    }
}
