#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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

namespace syncfusion.editordemos.winui
{
    /// <summary>
    /// To filter the cities based on country name.
    /// </summary>
    public class CityFilteringBehaviour : IComboBoxFilterBehavior
    {
        public List<int> GetMatchingIndexes(SfComboBox source, ComboBoxFilterInfo filterInfo)
        {
            List<int> filteredlist = new List<int>();
            List<CityInfo> CityItems = source.Items.OfType<CityInfo>().ToList();

            filteredlist.AddRange(from CityInfo item in CityItems
                                  let filterItem = this.GetStringFromMemberPath(item, "CountryName")
                                  where filterItem.StartsWith(filterInfo.Text, StringComparison.CurrentCultureIgnoreCase)
                                  select CityItems.IndexOf(item));

            filteredlist.AddRange(from CityInfo item in CityItems
                                  let filterItem = this.GetStringFromMemberPath(item, "CityName")
                                  let index= CityItems.IndexOf(item)
                                  where filterItem.StartsWith(filterInfo.Text, StringComparison.CurrentCultureIgnoreCase) && !filteredlist.Contains(index)
                                  select CityItems.IndexOf(item));
            return filteredlist;
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