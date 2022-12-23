#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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
    public class ImageDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate SadTemplate { get; set; }
        public DataTemplate ExcitedTemplate { get; set; }
        public DataTemplate HappyTemplate { get; set; }
        public DataTemplate NeutralTemplate { get; set; }
        public DataTemplate UnhappyTemplate { get; set; }
        public DataTemplate SadUnselectedTemplate { get; set; }
        public DataTemplate ExcitedUnselectedTemplate { get; set; }
        public DataTemplate HappyUnselectedTemplate { get; set; }
        public DataTemplate NeutralUnselectedTemplate { get; set; }
        public DataTemplate UnhappyUnselectedTemplate { get; set; }
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

