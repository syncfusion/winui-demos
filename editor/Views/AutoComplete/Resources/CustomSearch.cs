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
    /// <summary>
    /// Implements a custom asynchronous filtering behavior for the <see cref="SfAutoComplete"/> control
    /// that simulates fetching suggestions, potentially from an external source like "Google Suggestions".
    /// </summary>
    public class CustomSearch : IAutoCompleteFilterBehavior
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomSearch"/> class. It pre-fetches some suggestions for "test" as an initial operation.
        /// </summary>
        public CustomSearch()
        {
            _ = GetGoogleSuggestions("test");
        }

        /// <summary>
        /// Asynchronously retrieves matching items for the auto-complete component.
        /// This method delegates the actual suggestion fetching to `GetGoogleSuggestions`.
        /// </summary>
        /// <param name="source">The <see cref="SfAutoComplete"/> control initiating the filter.</param>
        /// <param name="filterInfo">Information about the filter text.</param>
        /// <returns>A task representing the asynchronous operation. The result is an object containing the list of matching suggestions.</returns>
        public Task<object> GetMatchingItemsAsync(SfAutoComplete source, AutoCompleteFilterInfo filterInfo)
        {
            return GetGoogleSuggestions(filterInfo.Text);
        }

        /// <summary>
        /// Simulates fetching suggestions asynchronously, as if from an external service (e.g., Google Suggestions).
        /// </summary>
        /// <param name="query">The search query string.</param>
        /// <returns>A task representing the asynchronous operation. The result is a list of simulated suggestion strings.</returns>
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
