#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using Syncfusion.UI.Xaml.Editors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syncfusion.EditorDemos.WinUI
{
    /// <summary>
    /// Selects a <see cref="DataTemplate"/> for displaying items within a Rating control,
    /// differentiating between selected and unselected states.
    /// </summary>
    public class PathDataTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Gets or sets the <see cref="DataTemplate"/> to be used when a rating item is selected.
        /// </summary>
        public DataTemplate SelectedTemplate { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DataTemplate"/> to be used when a rating item is not selected.
        /// </summary>
        public DataTemplate UnselectedTemplate { get; set; }

        /// <summary>
        /// Selects the appropriate <see cref="DataTemplate"/> based on the selection state of the rating item.
        /// </summary>
        /// <param name="item">The data item to select a template for; expected to be an <see cref="SfRatingItem"/>.</param>
        /// <param name="container">The UI element container.</param>
        /// <returns>The <see cref="SelectedTemplate"/> if the item is selected, <see cref="UnselectedTemplate"/> if not selected, or null if the item is not an <see cref="SfRatingItem"/>.</returns>
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            SfRatingItem ratingItem = item as SfRatingItem;
            if (ratingItem == null)
                return null;
            if (ratingItem.IsSelected)
                return SelectedTemplate;
            return UnselectedTemplate;
        }
    }
}
