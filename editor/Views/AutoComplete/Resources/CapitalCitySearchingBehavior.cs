#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Editors;
using System.Linq;

namespace Syncfusion.EditorDemos.WinUI
{
    public class CapitalCitySearchingBehavior : IAutoCompleteSearchBehavior
    {
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