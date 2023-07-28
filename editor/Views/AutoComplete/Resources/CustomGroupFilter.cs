#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Data;
using Syncfusion.UI.Xaml.Editors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Syncfusion.EditorDemos.WinUI
{
    public class CustomGroupFilter : IAutoCompleteFilterBehavior
    {
        public async Task<object> GetMatchingItemsAsync(SfAutoComplete source, AutoCompleteFilterInfo filterInfo)
        {
            List<ContinentInfo> list = new List<ContinentInfo>();
            IEnumerable itemsSource = source.ItemsSource as IEnumerable;

            list.AddRange(from item in itemsSource.Cast<ContinentInfo>()
                          let filteritem = this.GetStringFromMemberPath(item, nameof(item.Country))
                          where filteritem.Contains(filterInfo.Text, StringComparison.CurrentCultureIgnoreCase)
                          select item);

            var collectionViewSource = new CollectionViewSource();
            collectionViewSource.Source = list.GroupBy(item => item.Continent);
            collectionViewSource.IsSourceGrouped = true;

            return await Task.FromResult(collectionViewSource.View);
        }

        private string GetStringFromMemberPath(object item, string path)
        {
            string value = item.ToString();
            if (!string.IsNullOrEmpty(path))
            {
                value = item.GetType()?.GetRuntimeProperty(path)?.GetValue(item).ToString();
            }

            return value;
        }
    }
}
