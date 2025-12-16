#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Syncfusion.UI.Xaml.Editors;

namespace Syncfusion.EditorDemos.WinUI
{
    /// <summary>
    /// Implements a custom synchronous filtering behavior for the <see cref="SfAutoComplete"/> control.
    /// This filter checks if the `CountryName` or `CityName` of `CityInfo` objects starts with the provided filter text (case-insensitive).
    /// </summary>
    public class CustomFilter : IAutoCompleteFilterBehavior
    {
        /// <summary>
        /// Filters the items source for the <see cref="SfAutoComplete"/> control based on the provided text.
        /// It returns items where the CountryName or CityName starts with the filter text, ignoring case.
        /// </summary>
        /// <param name="source">The <see cref="SfAutoComplete"/> control initiating the filter.</param>
        /// <param name="filterInfo">Information about the filter text.</param>
        /// <returns>An enumerable collection of filtered items. Returns an empty collection if the items source is invalid or no matches are found.</returns>
        public async Task<object> GetMatchingItemsAsync(SfAutoComplete source, AutoCompleteFilterInfo filterInfo)
        {
            IEnumerable itemssource = source.ItemsSource as IEnumerable;
            var filteredItems = (from CityInfo item in itemssource
                                 where item.CountryName.StartsWith(filterInfo.Text, StringComparison.CurrentCultureIgnoreCase) ||
                                       item.CityName.StartsWith(filterInfo.Text, StringComparison.CurrentCultureIgnoreCase)
                                 select item);
            return await Task.FromResult(filteredItems);
        }
    }
}
