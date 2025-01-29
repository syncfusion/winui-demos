#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Syncfusion.SchedulerDemos.WinUI
{
    using Microsoft.UI.Xaml;
    using Microsoft.UI.Xaml.Controls;
    using Syncfusion.UI.Xaml.Chat;
    using System;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SmartScheduler : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmartScheduler"/> class.
        /// </summary>
        public SmartScheduler()
        {
            this.InitializeComponent();
            var viewModel = this.DataContext as SmartSchedulerViewModel;
            viewModel.Scheduler = this.scheduler;
            viewModel.InitializeDefaultAppointments();
            viewModel.InitializeAIService();
        }

        /// <summary>
        /// Method to handle the click event of the AI button.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private void OnAIButtonClick(object sender, RoutedEventArgs e)
        {
            this.assistView.Visibility = Visibility.Visible;
            this.headerView.Visibility = Visibility.Visible;
            this.assistViewBorder.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Method to handle the suggestion selected event of the chat control.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private void OnChatSuggestionSelected(object sender, UI.Xaml.Chat.SuggestionClickedEventArgs e)
        {
            var viewModel = this.assistView.DataContext as SmartSchedulerViewModel;
            viewModel.Chats.Add(new TextMessage { Text = e.Item.ToString(), DateTime = DateTime.Now, Author = assistView.CurrentUser });
        }

        /// <summary>
        /// Method to handle the close button click event of the chat control.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private void OnCloseButtonClick(object sender, RoutedEventArgs e)
        {
            this.assistView.Visibility = Visibility.Collapsed;
            this.headerView.Visibility = Visibility.Collapsed;
            this.assistViewBorder.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Method to handle the refresh button click event of the chat control.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private void OnRefreshButtonClick(object sender, RoutedEventArgs e)
        {
            var viewModel = this.assistView.DataContext as SmartSchedulerViewModel;

            // To do: Clear the chat messages using this code, once fix included from chat team will remove this code.
            int i = viewModel.Chats.Count;

            for (int j = 0; j < i; j++)
            {
                viewModel.Chats.RemoveAt(0);
            }

            viewModel.Suggestion.Clear();
        }

        /// <summary>
        /// Method to handle the tapped event of the options list view.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private void OnOptionstListViewTapped(object sender, Microsoft.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            var viewModel = this.DataContext as SmartSchedulerViewModel;
            string requestText = string.Empty;
            if (e.OriginalSource is TextBlock textBlock)
            {
                requestText = textBlock.Text;
            }

            viewModel.HandleOfflineAppointmentChat(requestText);
        }
    }
}