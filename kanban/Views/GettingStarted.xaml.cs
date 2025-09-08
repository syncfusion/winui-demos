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
    using Microsoft.UI.Xaml.Controls;
    using Syncfusion.UI.Xaml.Kanban;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GettingStarted : Page, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GettingStarted"/> class.
        /// </summary>
        public GettingStarted()
        {
            this.InitializeComponent();
            this.kanban.Workflows = new List<KanbanWorkflow>()
            {
                 new KanbanWorkflow() { Category = "Open", AllowedTransitions ={ "In Progress", "Closed", "Closed No Changes", "Won't Fix"} },
                 new KanbanWorkflow() { Category = "Postponed", AllowedTransitions ={ "Open", "In Progress", "Closed", "Closed No Changes", "Won't Fix"} },
                 new KanbanWorkflow() { Category = "Review", AllowedTransitions ={ "In Progress", "Closed", "Postponed" } },
                 new KanbanWorkflow() { Category = "In Progress", AllowedTransitions ={ "Review", "Postponed"} },
            };
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