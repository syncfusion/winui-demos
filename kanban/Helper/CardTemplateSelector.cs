#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Syncfusion.KanbanDemos.WinUI
{
    using Microsoft.UI.Xaml.Controls;
    using Microsoft.UI.Xaml;

    /// <summary>
    /// A custom DataTemplateSelector that selects a DataTemplate based on the Category of a MenuItem.
    /// </summary>
    public class CardTemplateSelector : DataTemplateSelector
    {
        #region Customization sample properties

        /// <summary>
        /// Gets or sets the <see cref="DataTemplate"/> used for items with the "Ready to Delivery" category.
        /// </summary>
        public DataTemplate DeliveryCardTemplate { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DataTemplate"/> used for items with the "Menu" category.
        /// </summary>
        public DataTemplate MenuCardTemplate { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DataTemplate"/> used for items with the "Ready to Serve" category.
        /// </summary>
        public DataTemplate ReadyToServeCardTemplate { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DataTemplate"/> used for items with the "Order" category.
        /// </summary>
        public DataTemplate OrderCardTemplate { get; set; }

        #endregion

        #region Sorting sample properties

        /// <summary>
        /// Gets or sets the DataTemplate used for items with the "Open" category.
        /// </summary>
        public DataTemplate ToDoTemplate { get; set; }

        /// <summary>
        /// Gets or sets the DataTemplate used for items with the "In Progress" category.
        /// </summary>
        public DataTemplate InProgressTemplate { get; set; }

        /// <summary>
        /// Gets or sets the DataTemplate used for items with the "Code Review" category.
        /// </summary>
        public DataTemplate ReviewTemplate { get; set; }

        /// <summary>
        /// Gets or sets the DataTemplate used for items with the "Done" category.
        /// </summary>
        public DataTemplate DoneTemplate { get; set; }

        #endregion

        /// <summary>
        /// Selects a DataTemplate based on the Category property of the item.
        /// </summary>
        /// <param name="item">The item info.</param>
        /// <param name="container">The bindable objects.</param>
        /// <returns>The data template.</returns>
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            // Return data template for kanban sorting demo.
            if (item is CardDetails cardDetails)
            {
                if (cardDetails == null || cardDetails.Category == null)
                {
                    return base.SelectTemplateCore(item, container);
                }

                var category = cardDetails.Category as string;
                return category == "Open" ? ToDoTemplate :
                       category == "In Progress" ? InProgressTemplate :
                       category == "Code Review" ? ReviewTemplate :
                       (category == "Done" ? DoneTemplate :
                       base.SelectTemplateCore(item, container));
            }

            // Return data template for kanban customization demo.
            if (item is MenuItem menuItem)
            {
                if (menuItem == null || menuItem.Category == null)
                {
                    return base.SelectTemplateCore(item, container);
                }

                var category = menuItem.Category as string;
                return category == "Menu" ? MenuCardTemplate :
                       category == "Ready to Delivery" ? DeliveryCardTemplate :
                       category == "Ready to Serve" ? ReadyToServeCardTemplate :
                       (category == "Dining" || category == "Delivery") ? OrderCardTemplate :
                       base.SelectTemplateCore(item, container);
            }

            return null;
        }
    }
}