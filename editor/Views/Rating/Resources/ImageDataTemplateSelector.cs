#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.Editors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Syncfusion.EditorDemos.WinUI
{
    /// <summary>
    /// Selects a <see cref="DataTemplate"/> based on the type of the data item provided.
    /// This is useful for displaying different visual representations for different data types within a single list or collection.
    /// </summary>
    public class ImageDataTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Properties to hold DataTemplate for Sad
        /// </summary>
        public DataTemplate SadTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Exicted
        /// </summary>
        public DataTemplate ExcitedTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Happy
        /// </summary>
        public DataTemplate HappyTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Neutral
        /// </summary>
        public DataTemplate NeutralTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Unhappy
        /// </summary>
        public DataTemplate UnhappyTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Sad Unselected
        /// </summary>
        public DataTemplate SadUnselectedTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Excited Unselected
        /// </summary>
        public DataTemplate ExcitedUnselectedTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Happy Unselected
        /// </summary>
        public DataTemplate HappyUnselectedTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Neutal Unselected
        /// </summary>
        public DataTemplate NeutralUnselectedTemplate { get; set; }
        /// <summary>
        /// Properties to hold DataTemplate for Unhappy Unselected
        /// </summary>
        public DataTemplate UnhappyUnselectedTemplate { get; set; }
        /// <summary>
        /// Selects the appropriate <see cref="DataTemplate"/> for the given data item.
        /// </summary>
        /// <param name="item">The data item for which to select a template.</param>
        /// <param name="container">The UI element container.</param>
        /// <returns>The selected <see cref="DataTemplate"/> for the item.</returns>
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            SfRating rating = container as SfRating;
            SfRatingItem ratingItem = item as SfRatingItem;
            if (ratingItem == null)
                return null;
            if (rating.Items.IndexOf(ratingItem) + 1 == rating.Value)
            {
                if (rating.Items.IndexOf(ratingItem) == 0)
                    return SadTemplate;
                if (rating.Items.IndexOf(ratingItem) == 1)
                    return UnhappyTemplate;
                if (rating.Items.IndexOf(ratingItem) == 2)
                    return NeutralTemplate;
                if (rating.Items.IndexOf(ratingItem) == 3)
                    return HappyTemplate;
                if (rating.Items.IndexOf(ratingItem) == 4)
                    return ExcitedTemplate;
            }
            else
            {
                if (rating.Items.IndexOf(ratingItem) == 0)
                    return SadUnselectedTemplate;
                if (rating.Items.IndexOf(ratingItem) == 1)
                    return UnhappyUnselectedTemplate;
                if (rating.Items.IndexOf(ratingItem) == 2)
                    return NeutralUnselectedTemplate;
                if (rating.Items.IndexOf(ratingItem) == 3)
                    return HappyUnselectedTemplate;
                if (rating.Items.IndexOf(ratingItem) == 4)
                    return ExcitedUnselectedTemplate;
            }
            return null;
        }
    }
}

