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
    using Syncfusion.UI.Xaml.Kanban;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Customization : Page, IDisposable
    {
        /// <summary>
        /// Stores the next available unique identifier to be assigned to a newly created order item.
        /// </summary>
        private double orderID = 1602;

        /// <summary>
        /// Gets or sets the selected card. 
        /// </summary>
        private MenuItem SelectedCard;

        /// <summary>
        /// Initializes a new instance of the <see cref="Customization"/> class.
        /// </summary>
        public Customization()
        {
            this.InitializeComponent();
            this.kanban.Workflows = new List<KanbanWorkflow>()
            {
                new KanbanWorkflow() { Category = "Menu", AllowedTransitions = { "Dining", "Delivery" }},
                new KanbanWorkflow() { Category = "Dining", AllowedTransitions = { "Ready to Serve" }},
                new KanbanWorkflow() { Category = "Delivery", AllowedTransitions = { "Ready to Delivery" }},
            };

            this.SelectedCard = new MenuItem();
        }

        /// <summary>
        /// Invokes when the card is being dragged.
        /// </summary>
        /// <param name="sender">The object.</param>
        /// <param name="e">The event args.</param>
        private void OnKanbanCardDragStarting(object sender, KanbanCardDragStartingEventArgs e)
        {
            if (e.Column.HeaderText.ToString() == "Menu")
            {
                e.KeepCard = true;
            }

            this.SelectedCard = e.Card.Content as MenuItem;
        }

        /// <summary>
        /// Invokes when the card is dropped;
        /// </summary>
        /// <param name="sender">The object.</param>
        /// <param name="e">The event args.</param>
        private void OnKanbanCardDrop(object sender, KanbanCardDropEventArgs e)
        {
            if (e.SourceColumn.HeaderText.ToString() == "Menu" && e.SourceColumn != e.TargetColumn && e.TargetColumn.HeaderText.ToString() == "Order" && SelectedCard != null)
            {
                e.Cancel = true;

                MenuItem model = new MenuItem();
                model.Category = e.TargetColumn.AllowedTransitionCategory;
                model.Description = SelectedCard.Description;
                model.OrderID = this.orderID;
                model.Image = SelectedCard.Image;
                model.OrderState = e.TargetColumn.AllowedTransitionCategory;
                model.Ingredients = SelectedCard.Ingredients;
                model.ItemName = SelectedCard.ItemName;
                (this.kanban.ItemsSource as ObservableCollection<MenuItem>).Add(model);

                this.orderID += 1;
            }
        }

        /// <summary>
        /// Dispose all the allocated resources.
        /// </summary>
        public void Dispose()
        {
            if (this.kanban != null)
            {
                this.kanban.Dispose();
                this.kanban = null;
            }

            if (this.DataContext != null && this.DataContext is CustomizationViewModel viewModel)
            {
                viewModel.Dispose();
                this.DataContext = null;
            }
        }
    }
}