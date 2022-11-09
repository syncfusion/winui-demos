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
        public DataTemplate SelectedTemplate { get; set; }
        public DataTemplate ChildTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            SfRating Rating = container as SfRating;
            SfRatingItem RatingItem = item as SfRatingItem;
            if (RatingItem == null)
                return null;
            if (Rating.Items.IndexOf(RatingItem) + 1 == Rating.Value)
            {
                if (Rating.Items.IndexOf(RatingItem) == 0)
                    return SadTemplate;
                if (Rating.Items.IndexOf(RatingItem) == 1)
                    return UnhappyTemplate;
                if (Rating.Items.IndexOf(RatingItem) == 2)
                    return NeutralTemplate;
                if (Rating.Items.IndexOf(RatingItem) == 3)
                    return HappyTemplate;
                if (Rating.Items.IndexOf(RatingItem) == 4)
                    return ExcitedTemplate;
            }
            else
            {
                if (Rating.Items.IndexOf(RatingItem) == 0)
                    return SadUnselectedTemplate;
                if (Rating.Items.IndexOf(RatingItem) == 1)
                    return UnhappyUnselectedTemplate;
                if (Rating.Items.IndexOf(RatingItem) == 2)
                    return NeutralUnselectedTemplate;
                if (Rating.Items.IndexOf(RatingItem) == 3)
                    return HappyUnselectedTemplate;
                if (Rating.Items.IndexOf(RatingItem) == 4)
                    return ExcitedUnselectedTemplate;
            }
            return null;
        }
    }
}

