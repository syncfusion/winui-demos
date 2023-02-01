#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Syncfusion.DemosCommon.WinUI;
using Syncfusion.UI.Xaml.Editors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Syncfusion.DemosCommon.WinUI
{
    public class DemoFilter : IAutoCompleteFilterBehavior
    {
        public async Task<object> GetMatchingItemsAsync(SfAutoComplete source, AutoCompleteFilterInfo filterInfo)
        {
            var suggestions = MainViewModel.SearchDemos(filterInfo.Text);
            if (suggestions.Count == 0)
            {
                DemoInfo demoInfo = new DemoInfo();
                demoInfo.SearchItem = "No results found";
                suggestions.Add(demoInfo);
                return suggestions;
            }
            else
            {
                return await Task.FromResult(suggestions);
            }
            
        }
    }
}
