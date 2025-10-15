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
    using System.Collections.ObjectModel;
    using System.Linq;
    using Microsoft.UI.Xaml;
    using Microsoft.UI.Xaml.Controls;
    using Microsoft.UI.Xaml.Controls.Primitives;
    using Microsoft.UI.Xaml.Media;
    using Microsoft.UI.Xaml.Media.Imaging;
    using Syncfusion.UI.Xaml.Kanban;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DialogEditing : Page, IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets or sets the instance of <see cref="SwimlaneViewModel"/> that serves as the data context for this dialog.
        /// </summary>
        public SwimlaneViewModel ViewModel { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DialogEditing"/> class.
        /// </summary>
        public DialogEditing()
        {
            this.InitializeComponent();
            this.ViewModel = this.DataContext as SwimlaneViewModel;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handles the event when the "Add New Card" button is clicked, typically to create a new task on the Kanban board.
        /// </summary>
        /// <param name="sender">The object.</param>
        /// <param name="e">The routed event args.</param>
        private async void OnAddNewCardButtonClicked(object sender, RoutedEventArgs e)
        {
            var addCardDialog = new ContentDialog
            {
                Title = "Add New Card",
                PrimaryButtonText = "Save",
                CloseButtonText = "Cancel",
                DefaultButton = ContentDialogButton.Primary,
                RequestedTheme = this.kanban.ActualTheme,
                Content = new StackPanel
                {
                    Spacing = 10,
                    Children =
                    {
                        new TextBox { Name = "TitleTextBox", Header = "Title", Width = 350},
                        new ComboBox
                        {
                            Name = "StatusComboBox",
                            Header = "Status",
                            SelectedIndex = 0,
                            Width = 350,
                            Items =
                            {
                                new ComboBoxItem { Content = "Open" },
                                new ComboBoxItem { Content = "In Progress" },
                                new ComboBoxItem { Content = "Review" },
                                new ComboBoxItem { Content = "Closed" }
                            }
                        },
                        new ComboBox
                        {
                            Name = "AssigneeComboBox",
                            Header = "Assignee",
                            SelectedIndex = 0,
                            Width = 350,
                            Items =
                            {
                                new ComboBoxItem { Content = "Andrew Fuller" },
                                new ComboBoxItem { Content = "Daniel Williams" },
                                new ComboBoxItem { Content = "Laura Callahan" },
                                new ComboBoxItem { Content = "Stephen Addison" },
                                new ComboBoxItem { Content = "James Williams" },
                                new ComboBoxItem { Content = "Adeline Elena" }
                            }
                        },
                        new ComboBox
                        {
                            Name = "PriorityComboBox",
                            Header = "Priority",
                            SelectedIndex = 1,
                            Width = 350,
                            Items = { new ComboBoxItem { Content = "Low" },
                                new ComboBoxItem { Content = "Normal" },
                                new ComboBoxItem { Content = "High" } }
                        },
                        new TextBox
                        {
                            Name = "SummaryTextBox",
                            Header = "Summary",
                            PlaceholderText = "Summary",
                            AcceptsReturn = true,
                            Width = 350,
                            TextWrapping = TextWrapping.Wrap,
                            Height = 100,
                        }
                    }
                }
            };

            addCardDialog.XamlRoot = this.XamlRoot;
            var result = await addCardDialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                var stackPanel = addCardDialog.Content as StackPanel;

                var titleTextBox = stackPanel.Children.OfType<TextBox>().FirstOrDefault(t => t.Name == "TitleTextBox");
                var statusComboBox = stackPanel.Children.OfType<ComboBox>().FirstOrDefault(c => c.Name == "StatusComboBox");
                var assigneeComboBox = stackPanel.Children.OfType<ComboBox>().FirstOrDefault(c => c.Name == "AssigneeComboBox");
                var priorityComboBox = stackPanel.Children.OfType<ComboBox>().FirstOrDefault(c => c.Name == "PriorityComboBox");
                var summaryTextBox = stackPanel.Children.OfType<TextBox>().FirstOrDefault(t => t.Name == "SummaryTextBox");

                string title = "";
                string status = "";
                string assignee = "";
                string priority = "";
                string summary = "";

                if (titleTextBox != null)
                {
                    title = titleTextBox.Text;
                }

                if (statusComboBox != null)
                {
                    status = ((ComboBoxItem)statusComboBox.SelectedItem).Content.ToString();
                }

                if (assigneeComboBox != null)
                {
                    assignee = ((ComboBoxItem)assigneeComboBox.SelectedItem).Content.ToString();
                }

                if (priorityComboBox != null)
                {
                    priority = ((ComboBoxItem)priorityComboBox.SelectedItem).Content.ToString();
                }

                if (summaryTextBox != null)
                {
                    summary = summaryTextBox.Text;
                }

                this.CreateNewTask(title, status, assignee, priority, summary);
            }
        }

        /// <summary>
        /// Creates a new task on the Kanban board with the specified details.
        /// </summary>
        /// <param name="title">The title of the task.</param>
        /// <param name="status">The current status of the task (e.g., "To Do", "In Progress", "Completed").</param>
        /// <param name="assignee">The person or team responsible for carrying out the task.</param>
        /// <param name="priority">The priority level of the task (e.g., "High", "Medium", "Low").</param>
        /// <param name="summary">A brief description providing more context for the task.</param>
        /// <remarks>
        /// This method is used to create a new task that will be added to the Kanban board.
        /// </remarks>
        private void CreateNewTask(string title, string status, string assignee, string priority, string summary)
        {
            string path = @"ms-appx:///";
#if Main_SB
            path = @"ms-appx:///kanban/";
#endif
            if (this.ViewModel == null)
            {
                return;
            }

            ObservableCollection<KanbanModel> taskdetails = this.ViewModel.TaskDetails;
            KanbanModel newTask = new KanbanModel
            {
                Title = title,
                Assignee = assignee,
                Description = summary,
                Category = status,
                IndicatorColorKey = priority,
            };

            switch (assignee)
            {
                case "Stephen Addison":
                    {
                        newTask.Image = new Image
                        {
                            Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle31.png"))
                        };

                        break;
                    }
                case "James Williams":
                    {
                        newTask.Image = new Image
                        {
                            Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle5.png"))
                        };
                        break;
                    }
                case "Andrew Fuller":
                    {
                        newTask.Image = new Image
                        {
                            Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle14.png"))
                        };
                        break;
                    }
                case "Daniel Williams":
                    {
                        newTask.Image = new Image
                        {
                            Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle23.png"))
                        };
                        break;
                    }
                case "Laura Callahan":
                    {
                        newTask.Image = new Image
                        {
                            Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle13.png"))
                        };
                        break;
                    }
                case "Adeline Elena":
                    {
                        newTask.Image = new Image
                        {
                            Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle17.png"))
                        };
                        break;
                    }
            }

            taskdetails.Add(newTask);
        }

        /// <summary>
        /// Handles the event when a card is tapped on the Kanban board, typically to display a context menu with options to edit or delete the card.
        /// </summary>
        /// <param name="sender">The object.</param>
        /// <param name="e">The card tapped event args.</param>
        private void OnKanbanCardTapped(object sender, KanbanCardTappedEventArgs e)
        {
            var selectedcard = e.SelectedCard;
            if (selectedcard == null || selectedcard.Content == null)
            {
                return;
            }

            var menuFlyout = new MenuFlyout();
            menuFlyout.Placement = FlyoutPlacementMode.RightEdgeAlignedTop;
            menuFlyout.AreOpenCloseAnimationsEnabled = true;

            var editMenuItem = new MenuFlyoutItem
            {
                Text = "Edit",
                Icon = new FontIcon() { Glyph = "\uE70F", FontFamily = new FontFamily("Segoe MDL2 Assets") }
            };

            editMenuItem.Click += (s, args) =>
            {
                this.ShowCardEditDialog(selectedcard.Content as KanbanModel);
            };

            menuFlyout.Items.Add(editMenuItem);
            if (e.SelectedCard is FrameworkElement cardElement)
            {
                menuFlyout.ShowAt(cardElement);
            }
        }

        /// <summary>
        /// Shows the edit dialog for the selected card.
        /// </summary>
        /// <param name="selectedcard">The selected card.</param>
        private async void ShowCardEditDialog(KanbanModel cardContent)
        {
            if (this.ViewModel == null)
            {
                return;
            }

            string path = @"ms-appx:///";
#if Main_SB
            path = @"ms-appx:///kanban/";
#endif

            var Editdialog = new ContentDialog
            {
                Title = "Edit Card Details",
                PrimaryButtonText = "Save",
                CloseButtonText = "Cancel",
                SecondaryButtonText = "Delete",
                DefaultButton = ContentDialogButton.Primary,
                RequestedTheme = this.kanban.ActualTheme,
                Content = new StackPanel
                {
                    Spacing = 10,
                    Children =
                    {
                          new TextBox { Name = "TitleTextBox", Header = "Title", Text = cardContent.Title, Width = 350 },
                          new ComboBox
                          {
                              Name = "StatusComboBox",
                              Header = "Status",
                              Width = 350,
                              SelectedValue = cardContent.Category,
                              Items =
                              {
                                  new ComboBoxItem { Content = "Open" },
                                  new ComboBoxItem { Content = "In Progress" },
                                  new ComboBoxItem { Content = "Review" },
                                  new ComboBoxItem { Content = "Closed" }
                              }
                          },

                          new ComboBox
                          {
                              Name = "AssigneeComboBox",
                              Header = "Assignee",
                              SelectedValue = cardContent.Assignee,
                              Width = 350,
                              SelectedItem = cardContent.Assignee,
                              Items =
                              {
                                  new ComboBoxItem { Content = "Andrew Fuller" },
                                  new ComboBoxItem { Content = "Daniel Williams" },
                                  new ComboBoxItem { Content = "Laura Callahan" },
                                  new ComboBoxItem { Content = "Stephen Addison" },
                                  new ComboBoxItem { Content = "James Williams" },
                                  new ComboBoxItem { Content = "Adeline Elena" }
                              }
                          },

                          new ComboBox
                          {
                              Name = "PriorityComboBox",
                              Header = "Priority",
                              SelectedValue = cardContent.IndicatorColorKey,
                              Width = 350,
                              Items =
                              {
                                  new ComboBoxItem { Content = "Low" },
                                  new ComboBoxItem { Content = "Normal" },
                                  new ComboBoxItem { Content = "High" }
                              }
                          },

                          new TextBox
                          {
                              Name = "SummaryTextBox",
                              Header = "Summary",
                              Width = 350,
                              Text = cardContent.Description,
                              AcceptsReturn = true,
                              TextWrapping = TextWrapping.Wrap,
                              Height = 100,
                          }
                    }
                }
            };

            var stackPanel = (StackPanel)Editdialog.Content;

            var statusComboBox = (ComboBox)stackPanel.Children[1];
            statusComboBox.SelectedItem = statusComboBox.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == cardContent.Category.ToString());

            var assigneeComboBox = (ComboBox)stackPanel.Children[2];
            assigneeComboBox.SelectedItem = assigneeComboBox.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == cardContent.Assignee);

            var priorityComboBox = (ComboBox)stackPanel.Children[3];
            priorityComboBox.SelectedItem = priorityComboBox.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == cardContent.IndicatorColorKey.ToString());

            Editdialog.XamlRoot = this.XamlRoot;
            var result = await Editdialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                ObservableCollection<KanbanModel> taskDetails = this.ViewModel.TaskDetails;

                var titleTextBox = (TextBox)stackPanel.Children[0];
                statusComboBox = (ComboBox)stackPanel.Children[1];
                assigneeComboBox = (ComboBox)stackPanel.Children[2];
                priorityComboBox = (ComboBox)stackPanel.Children[3];
                var summaryTextBox = (TextBox)stackPanel.Children[4];

                var card = new KanbanModel()
                {
                    Title = titleTextBox.Text,
                    Category = (statusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString(),
                    Assignee = (assigneeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString(),
                    IndicatorColorKey = (priorityComboBox.SelectedItem as ComboBoxItem)?.Content.ToString(),
                    Description = summaryTextBox.Text,
                };

                card.Image = new Image
                {
                    Source = new BitmapImage(new Uri(path + (card.Assignee switch
                    {
                        "Stephen Addison" => "Assets/Kanban/People_Circle31.png",
                        "James Williams" => "Assets/Kanban/People_Circle5.png",
                        "Andrew Fuller" => "Assets/Kanban/People_Circle14.png",
                        "Daniel Williams" => "Assets/Kanban/People_Circle23.png",
                        "Laura Callahan" => "Assets/Kanban/People_Circle13.png",
                        "Adeline Elena" => "Assets/Kanban/People_Circle17.png",
                        _ => "Assets/Kanban/People_Circle_0.png" // Default image.
                    })))
                };

                taskDetails.Remove(cardContent);
                taskDetails.Add(card);
            }
            else if (result == ContentDialogResult.Secondary)
            {
                ObservableCollection<KanbanModel> tasks = this.ViewModel.TaskDetails;
                tasks.Remove(cardContent);
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

            if (this.DataContext != null && this.DataContext is SwimlaneViewModel viewModel)
            {
                viewModel.Dispose();
                this.DataContext = null;
            }
        }

        #endregion
    }
}