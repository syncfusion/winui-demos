#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Markup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [ContentProperty(Name = "NavigationItemTemplate")]
    public class NavigationMenuItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate NavigationItemTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            var model = item as BrowserModel;
            return model.Tag == "Separator" ? SeparatorTemplate : model.Tag == "Header" ? HeaderTemplate : MenuItemTemplate;
        }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var model = item as BrowserModel;
            return model.Tag == "Separator" ? SeparatorTemplate : model.Tag == "Header" ? HeaderTemplate : MenuItemTemplate;
        }

        internal DataTemplate HeaderTemplate = (DataTemplate)XamlReader.Load(
            @"<DataTemplate xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'>
                   <NavigationViewItemHeader Content='{Binding Name}' />
                  </DataTemplate>");

        internal DataTemplate SeparatorTemplate = (DataTemplate)XamlReader.Load(
            @"<DataTemplate xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'>
                    <NavigationViewItemSeparator />
                  </DataTemplate>");

        internal DataTemplate MenuItemTemplate = (DataTemplate)XamlReader.Load(
           @"<DataTemplate xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'>
                    <TextBlock Text='{Binding Name}' />
                </DataTemplate>");
    }
}
