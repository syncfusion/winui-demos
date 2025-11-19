#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Syncfusion.UI.Xaml.Editors;

namespace Syncfusion.EditorDemos.WinUI
{
    /// <summary>
    /// Implements an asynchronous filtering behavior for the <see cref="SfAutoComplete"/> control. This allows for potentially long-running filter operations to be performed off the UI thread.
    /// It also incorporates cancellation support to abort previous filter operations if a new search is initiated.
    /// </summary>
    public class CustomAsyncFilter : IAutoCompleteFilterBehavior
    {
        /// <summary>
        /// Gets the cancellation token source.
        /// </summary>
        CancellationTokenSource cancellationTokenSource;
        /// <summary>
        /// Asynchronously filters the data source based on the provided text and returns matching items. This method simulates an asynchronous operation
        /// by running the filtering logic in a separate task. It also manages cancellation tokens to allow canceling previous search operations.
        /// </summary>
        /// <param name="source">The <see cref="SfAutoComplete"/> control initiating the filter.</param>
        /// <param name="filterInfo">Information about the filter text and other parameters.</param>
        /// <returns>A task representing the asynchronous operation. The result is an object containing the list of matching items.</returns>
        public async Task<object> GetMatchingItemsAsync(SfAutoComplete source, AutoCompleteFilterInfo filterInfo)
        {
            if (this.cancellationTokenSource != null)
            {
                this.cancellationTokenSource.Cancel();
                this.cancellationTokenSource.Dispose();
            }

            this.cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = this.cancellationTokenSource.Token;

            return await Task.Run(() =>
            {
                List<string> list = new List<string>();
                for (int i = 1; i < 100; i++)
                {
                    list.Add(filterInfo.Text + i);
                }

                return list;
            }, token);
        }
    }
}
