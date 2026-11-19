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
