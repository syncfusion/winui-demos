#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Syncfusion.KanbanDemos.WinUI
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Microsoft.UI.Xaml.Controls;
    using Microsoft.UI.Xaml.Media.Imaging;

    /// <summary>
    /// Represents a view model for managing a customizable menu of pizza items, including their details, categories, and order states.
    /// </summary>
    public class CustomizationViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the collection of <see cref="MenuItem"/> representing the different pizza items available in the menu.
        /// </summary>
        public ObservableCollection<MenuItem> MenuItems { get; set;}

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomizationViewModel"/> class.
        /// </summary>
        public CustomizationViewModel()
        {
            this.MenuItems = this.GetMenuItems();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Method to get the kanban model collections.
        /// </summary>
        /// <returns>The kanban model collections.</returns>
        private ObservableCollection<MenuItem> GetMenuItems()
        {
            var menuItems = new ObservableCollection<MenuItem>();
            string path = @"ms-appx:///";
#if Main_SB
            path = @"ms-appx:///kanban/";
#endif
            MenuItem item = new MenuItem();
            item.Category = "Menu";
            item.ItemName = "Double Cheese Margherita";
            item.Description = "The minimalist classic with a double helping of cheese.";
            item.Ingredients = new List<string>() { "Basil", "Tomatoes", "Cheese" };
            item.Rating = 5;
            item.Image = new Image()
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/DoubleCheeseMargherita.png"))
            };

            menuItems.Add(item);

            item = new MenuItem();
            item.Category = "Menu";
            item.ItemName = "Bucolic Pie";
            item.Description = "The pizza you daydream about to escape city life. Onions, peppers, and tomatoes.";
            item.Ingredients = new List<string>() { "Onions", "Bell Pepper", "Tomatoes" };
            item.Rating = 3;
            item.Image = new Image()
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/Bucolicpie.png"))
            };

            menuItems.Add(item);

            item = new MenuItem();
            item.Category = "Menu";
            item.ItemName = "Bumper Crop";
            item.Description = "Can't get enough veggies? Eat this. Carrots, mushrooms, potatoes, and way more.";
            item.Ingredients = new List<string>() { "Onions", "Bell Pepper", "Mushrooms" };
            item.Rating = 3;
            item.Image = new Image()
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/Bumpercrop.png"))
            };

            menuItems.Add(item);

            item = new MenuItem();
            item.Category = "Menu";
            item.ItemName = "Spice of Life";
            item.Description = "Thrill-seeking, heat-seeking pizza people only. It's hot. Trust us.";
            item.Ingredients = new List<string>() { "Onions", "Bell Pepper", "Pepperoni" };
            item.Rating = 4;
            item.Image = new Image()
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/Spiceoflife.png"))
            };

            menuItems.Add(item);

            item = new MenuItem();
            item.Category = "Order";
            item.ItemName = "Very Nicoise";
            item.Description = "Anchovies, Dijon vinaigrette, shallots, red peppers, and potatoes.";
            item.Ingredients = new List<string>() { "Onions", "Bell Pepper", "Fish" };
            item.Rating = 4;
            item.Image = new Image()
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/Verynicoise.png"))
            };

            menuItems.Add(item);

            item = new MenuItem();
            item.Category = "Menu";
            item.ItemName = "Margherita";
            item.Description = "The classic. Fresh tomatoes, garlic, olive oil, and basil. For pizza purists and minimalists only.";
            item.Ingredients = new List<string>() { "Basil", "Mozzarella", "Tomatoes" };
            item.Rating = 4.5;
            item.Image = new Image()
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/Margherita.png"))
            };

            menuItems.Add(item);

            item = new MenuItem();
            item.Category = "Menu";
            item.ItemName = "Very Nicoise";
            item.Description = "Anchovies, Dijon vinaigrette, shallots, red peppers, and potatoes.";
            item.Ingredients = new List<string>() { "Onions", "Bell Pepper", "Fish" };
            item.Rating = 3.8;
            item.Image = new Image()
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/Verynicoise.png"))
            };

            menuItems.Add(item);

            item = new MenuItem();
            item.Category = "Menu";
            item.ItemName = "Salad Daze";
            item.Description = "Pretty much salad on a pizza. Broccoli, olives, cherry tomatoes, red onion.";
            item.Ingredients = new List<string>() { "Onions", "Bell Pepper", "Mushrooms" };
            item.Rating = 3.5;
            item.Image = new Image()
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/Saladdaze.png"))
            };

            menuItems.Add(item);

            item = new MenuItem();
            item.Category = "Ready to Serve";
            item.ItemName = "Margherita";
            item.OrderState = "Dining";
            item.Description = "The classic. Fresh tomatoes, garlic, olive oil, and basil. For pizza purists and minimalists only.";
            item.Ingredients = new List<string>() { "Basil", "Mozzarella", "Tomatoes" };
            item.OrderID = 1600;
            item.Image = new Image()
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/Margherita.png"))
            };

            menuItems.Add(item);

            item = new MenuItem();
            item.Category = "Ready to Delivery";
            item.ItemName = "Salad Daze";
            item.OrderState = "Delivery";
            item.Description = "Pretty much salad on a pizza. Broccoli, olives, cherry tomatoes, red onion.";
            item.Ingredients = new List<string>() { "Onions", "Bell Pepper", "Olives" };
            item.OrderID = 1601;
            item.Image = new Image()
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/Saladdaze.png"))
            };

            menuItems.Add(item);

            return menuItems;
        }

        /// <summary>
        /// Method to dispose the objects.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the managed resources used by the class.
        /// </summary>
        /// <param name="isdisposable">A boolean value indicating whether to release managed resources.</param>
        protected virtual void Dispose(bool isdisposable)
        {
            if (isdisposable)
            {
                if (this.MenuItems != null)
                {
                    this.MenuItems.Clear();
                    this.MenuItems = null;
                }
            }
        }

        #endregion
    }
}