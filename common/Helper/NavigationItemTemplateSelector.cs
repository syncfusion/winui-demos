#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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

        /// <summary>
        /// Gets or sets the <see cref="DataTemplate"/> used for displaying individual control items.
        /// Typically used for items of type <see cref="ControlInfo"/>.
        /// </summary>
        public DataTemplate ControlItemTemplate { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DataTemplate"/> used for displaying individual demo items.
        /// Typically used for items of type <see cref="DemoInfo"/>.
        /// </summary>
        public DataTemplate DemoItemTemplate { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DataTemplate"/> used for displaying category group headers.
        /// Typically used for items of type <see cref="CategoryGroup"/>.
        /// </summary>
        public DataTemplate CategoryItemTemplate { get; set; }

        /// <summary>
        /// Gets or sets a value of AllControlsButtonTemplate to display the All Controls Button.
        /// </summary>
        public DataTemplate AllControlsButtonTemplate { get; set; }

        /// <summary>
        /// Selects the appropriate <see cref="DataTemplate"/> based on the type of the data item.
        /// </summary>
        /// <param name="item">The data item for which to select a template. Expected types include <see cref="ControlInfo"/>, <see cref="DemoInfo"/>, <see cref="CategoryGroup"/>, <see cref="BrowserModel"/>, and <see cref="AllControlsButtonInfo"/>.</param>
        /// <returns>The <see cref="DataTemplate"/> to use for the item.</returns>
        /// <exception cref="NotImplementedException">Thrown if the type of the item is not handled by this selector.</exception>
        protected override DataTemplate SelectTemplateCore(object item)
        {
            if (item is ControlInfo)
            {
                return ControlItemTemplate;
            }
            if (item is DemoInfo)
            {
                return DemoItemTemplate;
            }
            if (item is CategoryGroup)
            {
                return CategoryItemTemplate;
            }
            if (item is BrowserModel model)
            {
                return HeaderTemplate;
            }
            if (item is AllControlsButtonInfo)
            {
                return AllControlsButtonTemplate;
            }
            throw new NotImplementedException();
        }
    }
}