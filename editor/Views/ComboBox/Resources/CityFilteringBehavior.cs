#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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