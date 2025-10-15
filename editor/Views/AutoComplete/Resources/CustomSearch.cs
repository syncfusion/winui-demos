#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Editors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Syncfusion.EditorDemos.WinUI
{
    public class CustomSearch : IAutoCompleteFilterBehavior
    {
        public CustomSearch()
        {
            _ = GetGoogleSuggestions("test");
        }

        public Task<object> GetMatchingItemsAsync(SfAutoComplete source, AutoCompleteFilterInfo filterInfo)
        {
            return GetGoogleSuggestions(filterInfo.Text);
        }

        private async Task<object> GetGoogleSuggestions(string query)
        {
            if (string.IsNullOrEmpty(query) || string.IsNullOrWhiteSpace(query))
            {
                return new List<string>();
            }

            string xmlSuggestions;

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var searchQuery = String.Format("https://www.google.com/complete/search?output=toolbar&q={0}", query);
                    xmlSuggestions = await client.GetStringAsync(searchQuery);
                }
                catch
                {
                    return null;
                }
            }

            XDocument doc = XDocument.Parse(xmlSuggestions);
            var suggestions = doc.Descendants("CompleteSuggestion")
                                    .Select(
                                        item => item.Element("suggestion").Attribute("data").Value);

            return suggestions.ToList();
        }
    }
}
