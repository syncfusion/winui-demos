namespace Syncfusion.KanbanDemos.WinUI
{
    using System;
    using Microsoft.UI.Xaml.Controls;
    using Syncfusion.UI.Xaml.Kanban;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Selection : Page, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Selection"/> class.
        /// </summary>
        public Selection()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Occurs when the selection mode is changed.
        /// </summary>
        /// <param name="sender">The source object (ComboBox).</param>
        /// <param name="e">The event arguments.</param>
        private void OnSelectionModeChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.kanban == null || this.sortBySelection.SelectedItem == null)
            {
                return;
            }

            string selectedItem = this.sortBySelection.SelectedItem.ToString();
            switch (selectedItem)
            {
                case "None":
                    this.kanban.CardSelectionType = KanbanCardSelectionType.None;
                    break;

                case "Single":
                    this.kanban.CardSelectionType = KanbanCardSelectionType.Single;
                    break;

                case "Multiple":
                    this.kanban.CardSelectionType = KanbanCardSelectionType.Multiple;
                    break;

                default:
                    // Optional: handle unexpected values gracefully
                    this.kanban.CardSelectionType = KanbanCardSelectionType.None;
                    break;
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

            if (this.DataContext != null && this.DataContext is SelectionViewModel viewModel)
            {
                viewModel.Dispose();
                this.DataContext = null;
            }
        }
    }
}