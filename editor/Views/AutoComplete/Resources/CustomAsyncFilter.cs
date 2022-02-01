#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Syncfusion.UI.Xaml.Editors;

namespace syncfusion.editordemos.winui
{
    public class CustomAsyncFilter : IAutoCompleteFilterBehavior
    {
        /// <summary>
        /// Gets the cancellation token source.
        /// </summary>
        CancellationTokenSource cancellationTokenSource;

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
                for (int i = 1; i < 100000; i++)
                {
                    list.Add(filterInfo.Text + i);
                }

                return list;
            }, token);
        }
    }
}
