#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Editors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Syncfusion.EditorDemos.WinUI
{
    /// <summary>
    /// To filter the cities based on country name.
    /// </summary>
    public class CityFilteringBehavior : IComboBoxFilterBehavior
    {
        /// <summary>
        /// Filters the items in the <see cref="SfComboBox"/> based on the provided text in `filterInfo`. It returns a list of indexes corresponding to the items that match the filter criteria.
        /// </summary>
        /// <param name="source">The <see cref="SfComboBox"/> control initiating the filter.</param>
        /// <param name="filterInfo">Information about the filter text and other search-related details.</param>
        /// <returns>A list of integers representing the indexes of the matching items in the original source.</returns>
        public List<int> GetMatchingIndexes(SfComboBox source, ComboBoxFilterInfo filterInfo)
        {
            List<int> filteredlist = new List<int>();
            List<CityInfo> CityItems = source.Items.OfType<CityInfo>().ToList(); 

            filteredlist.AddRange(from CityInfo item in CityItems
                            where item.CountryName.StartsWith(filterInfo.Text, StringComparison.CurrentCultureIgnoreCase) ||
                                       item.CityName.StartsWith(filterInfo.Text, StringComparison.CurrentCultureIgnoreCase)
                                 select CityItems.IndexOf(item));
            return filteredlist;
        }
    }
}