#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
            //Results that match the search word.
            var suggestions = MainViewModel.SearchDemos(filterInfo.Text);

            //Results found through the fuzzy search logic.
            List<DemoInfo> fuzzySuggestions = FuzzySearch(filterInfo.Text);
            if (suggestions.Count == 0 && fuzzySuggestions.Count == 0)
            {
                DemoInfo demoInfo = new DemoInfo();
                demoInfo.SearchItem = "No results found";
                suggestions.Add(demoInfo);
                return await Task.FromResult((object)suggestions);
            }
            else
            {
                return await Task.FromResult((object)suggestions.Union(fuzzySuggestions));
            }
        }

        /// <summary>
        /// Method for Fuzzy Search logic, which will return the list of words that are similar to the search word.
        /// Here, the search word can be either the Demo name or the Control name.
        /// </summary>
        /// <returns>Search results similar to the search key</returns>
        public List<DemoInfo> FuzzySearch(string searchWord)
        {
            //To allow words with more differences, you can decrease the value.
            double requiredMatchingFactor = 0.4;

            //To get the list of all the controls name along with the demo name.
            List<DemoInfo> actualWords = MainViewModel.SearchDemos("/");

            List<DemoInfo> foundWords = new List<DemoInfo>();
            foreach (var item in actualWords)
            {
                //If the matching factor is higher than the required matching factor, we will include that word.
                //The lower the required matching factor, the more difference between the words will be allowed.
                if (1.0 - (double)LevenshteinDistance(item.Name, searchWord) / Math.Max(searchWord.Length, item.Name.Length) > requiredMatchingFactor ||
                    1.0 - (double)LevenshteinDistance(string.Format("{0}", item.SearchItem.Split('/')[0].Trim()), searchWord) / Math.Max(searchWord.Length, string.Format("{0}", item.SearchItem.Split('/')[0].Trim()).Length) > requiredMatchingFactor)
                {
                    foundWords.Add(item);
                }
            }
            return foundWords;
        }

        public int LevenshteinDistance(string searchWord, string actualWord)
        {
            //Forming a table that has a length one higher in both rows and columns.
            var matrix = new int[searchWord.Length + 1, actualWord.Length + 1];

            if (searchWord.Length == 0)
                return actualWord.Length;

            if (actualWord.Length == 0)
                return searchWord.Length;

            //Initializing with indices.
            for (var i = 0; i <= searchWord.Length; matrix[i, 0] = i++) { }
            for (var j = 0; j <= actualWord.Length; matrix[0, j] = j++) { }

            for (var i = 1; i <= searchWord.Length; i++)
            {
                for (var j = 1; j <= actualWord.Length; j++)
                {
                    //If the characters do not match, we will add 1.
                    var cost = (actualWord[j - 1] == searchWord[i - 1]) ? 0 : 1;

                    //Minimum of the 3 cells + above cost.
                    matrix[i, j] = Math.Min(Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1), matrix[i - 1, j - 1] + cost);
                }
            }
            // Return the value at the bottom right. 
            return matrix[searchWord.Length, actualWord.Length];
        }
    }
}
