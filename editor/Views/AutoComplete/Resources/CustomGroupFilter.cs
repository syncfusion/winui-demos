#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
    /// <summary>
    /// Implements a custom asynchronous filtering behavior for the <see cref="SfAutoComplete"/> control
    /// that groups the results by continent. It filters items based on the country name and then groups them.
    /// </summary>
    public class CustomGroupFilter : IAutoCompleteFilterBehavior
    {
        /// <summary>
        /// Asynchronously filters and groups the items based on the provided text and continent grouping.
        /// </summary>
        /// <param name="source">The <see cref="SfAutoComplete"/> control initiating the filter.</param>
        /// <param name="filterInfo">Information about the filter text.</param>
        /// <returns>A task representing the asynchronous operation. The result is a grouped view of filtered items.</returns>
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

        /// <summary>
        /// Retrieves a string value from an object's specified property.
        /// </summary>
        /// <param name="item">The object from which to get the property value.</param>
        /// <param name="path">The name of the property to retrieve.</param>
        /// <returns>The string representation of the property value, or the object's default string representation if the path is null/empty or property is not found.</returns>
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
