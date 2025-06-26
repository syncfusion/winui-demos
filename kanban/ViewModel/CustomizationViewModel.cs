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
    using Syncfusion.UI.Xaml.Kanban;

    /// <summary>
    /// Represents a ViewModel that manages the customization options for pizzas in the pizza shop. 
    /// It holds a collection of Kanban models, each representing a different pizza menu item with its description, tags, and images.
    /// The view model initializes this collection with predefined pizza options and provides access to them for the UI.
    /// </summary>
    public class CustomizationViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the collection of <see cref="KanbanModel"/> representing the different pizza items available in the menu.
        /// </summary>
        public ObservableCollection<KanbanModel> MenuItems
        {
            get;
            set;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomizationViewModel"/> class.
        /// </summary>
        public CustomizationViewModel()
        {
            this.MenuItems = this.GetKanbanModels();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Method to get the kanban model collections.
        /// </summary>
        /// <returns>The kanban model collections.</returns>
        private ObservableCollection<KanbanModel> GetKanbanModels()
        {
            var taskDetails = new ObservableCollection<KanbanModel>();
            string path = @"ms-appx:///";
#if Main_SB
            path = @"ms-appx:///kanban/";
#endif
            KanbanModel kanbanModel = new KanbanModel();
            kanbanModel.Category = "Menu";
            kanbanModel.Title = "Double Cheese Margherita";
            kanbanModel.Description = "The minimalist classic with a double helping of cheese";
            kanbanModel.Tags = new List<string>() { "Basil", "Tomatoes", "Cheese" };
            kanbanModel.Image = new Image()
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/DoubleCheeseMargherita.png"))
            };

            taskDetails.Add(kanbanModel);

            kanbanModel = new KanbanModel();
            kanbanModel.Category = "Menu";
            kanbanModel.Title = "Bucolic Pie";
            kanbanModel.Description = "The pizza you daydream about to escape city life. Onions, peppers, and tomatoes";
            kanbanModel.Tags = new List<string>() { "Onions", "Bell Pepper", "Tomatoes" };
            kanbanModel.Image = new Image()
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/Bucolicpie.png"))
            };

            taskDetails.Add(kanbanModel);

            kanbanModel = new KanbanModel();
            kanbanModel.Category = "Menu";
            kanbanModel.Title = "Bumper Crop";
            kanbanModel.Description = "Can't get enough veggies? Eat this. Carrots, mushrooms, potatoes, and way more";
            kanbanModel.Tags = new List<string>() { "Onions", "Bell Pepper", "Mushrooms" };
            kanbanModel.Image = new Image()
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/Bumpercrop.png"))
            };

            taskDetails.Add(kanbanModel);

            kanbanModel = new KanbanModel();
            kanbanModel.Category = "Menu";
            kanbanModel.Title = "Spice of Life";
            kanbanModel.Description = "Thrill-seeking, heat-seeking pizza people only. It's hot. Trust us";
            kanbanModel.Tags = new List<string>() { "Onions", "Bell Pepper", "Pepperoni" };
            kanbanModel.Image = new Image()
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/Spiceoflife.png"))
            };

            taskDetails.Add(kanbanModel);

            kanbanModel = new KanbanModel();
            kanbanModel.Category = "Order";
            kanbanModel.Title = "Very Nicoise";
            kanbanModel.Description = "Anchovies, Dijon vinaigrette, shallots, red peppers, and potatoes";
            kanbanModel.Tags = new List<string>() { "Onions", "Bell Pepper", "Fish" };
            kanbanModel.Image = new Image()
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/Verynicoise.png"))
            };

            taskDetails.Add(kanbanModel);

            kanbanModel = new KanbanModel();
            kanbanModel.Category = "Menu";
            kanbanModel.Title = "Margherita";
            kanbanModel.Description = "The classic. Fresh tomatoes, garlic, olive oil, and basil. For pizza purists and minimalists only";
            kanbanModel.Tags = new List<string>() { "Basil", "Mozzarella", "Tomatoes" };
            kanbanModel.Image = new Image()
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/Margherita.png"))
            };

            taskDetails.Add(kanbanModel);

            kanbanModel = new KanbanModel();
            kanbanModel.Category = "Menu";
            kanbanModel.Title = "Very Nicoise";
            kanbanModel.Description = "Anchovies, Dijon vinaigrette, shallots, red peppers, and potatoes";
            kanbanModel.Tags = new List<string>() { "Onions", "Bell Pepper", "Fish" };
            kanbanModel.Image = new Image()
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/Verynicoise.png"))
            };

            taskDetails.Add(kanbanModel);

            kanbanModel = new KanbanModel();
            kanbanModel.Category = "Ready to Serve";
            kanbanModel.Title = "Margherita";
            kanbanModel.Description = "The classic. Fresh tomatoes, garlic, olive oil, and basil. For pizza purists and minimalists only";
            kanbanModel.IndicatorColorKey = "Ready";
            kanbanModel.Tags = new List<string>() { "Basil", "Mozzarella", "Tomatoes" };
            kanbanModel.Image = new Image()
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/Margherita.png"))
            };

            taskDetails.Add(kanbanModel);

            kanbanModel = new KanbanModel();
            kanbanModel.Category = "Ready to Delivery";
            kanbanModel.Title = "Salad Daze";
            kanbanModel.Description = "Pretty much salad on a pizza. Broccoli, olives, cherry tomatoes, red onion";
            kanbanModel.Tags = new List<string>() { "Onions", "Bell Pepper", "Olives" };
            kanbanModel.IndicatorColorKey = "Delivery";
            kanbanModel.Image = new Image()
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/Saladdaze.png"))
            };

            taskDetails.Add(kanbanModel);

            kanbanModel = new KanbanModel();
            kanbanModel.Category = "Menu";
            kanbanModel.Title = "Salad Daze";
            kanbanModel.Description = "Pretty much salad on a pizza. Broccoli, olives, cherry tomatoes, red onion";
            kanbanModel.Tags = new List<string>() { "Onions", "Bell Pepper", "Mushrooms" };
            kanbanModel.Image = new Image()
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/Saladdaze.png"))
            };

            taskDetails.Add(kanbanModel);
            return taskDetails;
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