#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Syncfusion.ChartDemos.WinUI
{
    /// <summary>
    /// Represents a data model for column chart visualization.
    /// Contains a category name, a primary value, and optional medal counts
    /// (Gold, Silver, Bronze) for comparative charting.
    /// </summary>
    public class ColumnChartModel
    {
        /// <summary>
        /// Gets or sets the category or label name associated with the chart column.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the primary numeric value represented by the chart column.
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Gets or sets the number of gold medals or gold-level achievements
        /// associated with this category.
        /// </summary>
        public double Gold { get; set; }

        /// <summary>
        /// Gets or sets the number of silver medals or silver-level achievements
        /// associated with this category.
        /// </summary>
        public double Silver { get; set; }

        /// <summary>
        /// Gets or sets the number of bronze medals or bronze-level achievements
        /// associated with this category.
        /// </summary>
        public double Bronze { get; set; }
    }
}
