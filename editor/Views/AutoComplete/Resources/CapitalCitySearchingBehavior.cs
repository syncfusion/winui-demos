#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Editors;
using System.Linq;

namespace Syncfusion.EditorDemos.WinUI
{
    /// <summary>
    /// Implements a custom search behavior for the <see cref="SfAutoComplete"/> control,
    /// specifically to highlight capital cities within the filtered results.
    /// </summary>
    public class CapitalCitySearchingBehavior : IAutoCompleteSearchBehavior
    {
        /// <summary>
        /// Determines the index of the first capital city found in the filtered items list.
        /// This method is called by the <see cref="SfAutoComplete"/> control to find a suitable item to highlight.
        /// </summary>
        /// <param name="source">The <see cref="SfAutoComplete"/> control initiating the search.</param>
        /// <param name="searchInfo">Information about the search, including the filtered items.</param>
        /// <returns>The index of the first capital city found in `searchInfo.FilteredItems`. Returns 0 if no capital city is found or if `searchInfo.FilteredItems` is null/empty.</returns>
        public int GetHighlightIndex(SfAutoComplete source, AutoCompleteSearchInfo searchInfo)
        {
            var filteredCapitals = from CityInfo cityInfo in searchInfo.FilteredItems
                      where cityInfo.IsCapital
                      select searchInfo.FilteredItems.IndexOf(cityInfo);
            if (filteredCapitals.Count() > 0)
                return filteredCapitals.FirstOrDefault();

            return 0;
        }
    }
}