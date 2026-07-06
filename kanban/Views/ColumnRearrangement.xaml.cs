namespace Syncfusion.KanbanDemos.WinUI
{
    using System;
    using System.Collections.Generic;
    using Microsoft.UI.Xaml.Controls;
    using Syncfusion.UI.Xaml.Kanban;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ColumnRearrangement : Page, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnRearrangement"/> class.
        /// </summary>
        public ColumnRearrangement()
        {
            this.InitializeComponent();
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

            if (this.DataContext != null && this.DataContext is GettingStartedViewModel viewModel)
            {
                viewModel.Dispose();
                this.DataContext = null;
            }
        }
    }
}