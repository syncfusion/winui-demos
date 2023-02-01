#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

namespace Syncfusion.DemosCommon.WinUI
{
    /// <summary>
    /// Represent a template selector class for navigation item
    /// </summary>
    public class NavigationItemTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Gets or sets a value of header template to display the control name.
        /// </summary>
        public DataTemplate HeaderTemplate { get; set; }

        public DataTemplate ControlItemTemplate { get; set; }
        public DataTemplate DemoItemTemplate { get; set; }

        public DataTemplate CategoryItemTemplate { get; set; }

        /// <summary>
        /// A method to select the navigation item template.
        /// </summary>
        /// <param name="item">Browser model</param>
        /// <returns>Data template</returns>
        protected override DataTemplate SelectTemplateCore(object item)
        {
            if(item is ControlInfo)
            {
                return ControlItemTemplate;
            }
            if(item is DemoInfo)
            {
                return DemoItemTemplate;
            }
            if(item is CategoryGroup)
            {
                return CategoryItemTemplate;
            }
            if (item is BrowserModel model)
            {
                return HeaderTemplate;
            }
            throw new NotImplementedException();
        }
    }
}
