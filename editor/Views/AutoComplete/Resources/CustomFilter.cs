#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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
    public class CustomFilter : IAutoCompleteFilterBehavior
    {
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
