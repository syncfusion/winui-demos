#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Syncfusion.KanbanDemos.WinUI
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Microsoft.UI.Xaml.Controls;
    using Microsoft.UI.Xaml.Media.Imaging;
    using Syncfusion.UI.Xaml.Kanban;

    /// <summary>
    /// Represents a ViewModel that manages the task details for a swimlane in a Kanban board. 
    /// </summary>
    public class SwimlaneViewModel : INotifyPropertyChanged, IDisposable
    {
        #region Fields

        /// <summary>
        /// Stores the collection of <see cref="KanbanModel"/> objects.
        /// </summary>
        private ObservableCollection<KanbanModel> taskDetails;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the collection of <see cref="KanbanModel"/> objects representing tasks in various stages.
        /// </summary>
        public ObservableCollection<KanbanModel> TaskDetails
        {
            get
            {
                return this.taskDetails;
            }
            set
            {
                this.taskDetails = value;
                this.OnPropertyChanged(nameof(TaskDetails));
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SwimlaneViewModel"/> class.
        /// </summary>
        public SwimlaneViewModel()
        {
            this.TaskDetails = this.GetTaskDetails();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Method to get the kanban model collections.
        /// </summary>
        /// <returns>The kanban model collections.</returns>
        private ObservableCollection<KanbanModel> GetTaskDetails()
        {
            var taskDetails = new ObservableCollection<KanbanModel>();

            string path = @"ms-appx:///";
#if Main_SB
            path = @"ms-appx:///kanban/";
#endif
            KanbanModel taskDetail = new KanbanModel();
            taskDetail.Title = "Application performance";
            taskDetail.Id = "1001";
            taskDetail.Assignee = "Adeline Elena";
            taskDetail.Description = "Improve application performance.";
            taskDetail.Category = "Open";
            taskDetail.IndicatorColorKey = "Normal";
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle17.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "Analysis";
            taskDetail.Id = "1002";
            taskDetail.Assignee = "Daniel Williams";
            taskDetail.Description = "Analyze SQL Server 2008 connection.";
            taskDetail.Category = "In Progress";
            taskDetail.IndicatorColorKey = "Low";
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle23.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "Editing";
            taskDetail.Id = "1003";
            taskDetail.Assignee = "Laura Callahan";
            taskDetail.Description = "Enhance editing functionality.";
            taskDetail.Category = "Review";
            taskDetail.IndicatorColorKey = "High";
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle13.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "Editing";
            taskDetail.Id = "1004";
            taskDetail.Assignee = "Andrew Fuller";
            taskDetail.Description = "Add input validation for editing.";
            taskDetail.Category = "Review";
            taskDetail.IndicatorColorKey = "Normal";
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle14.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "Customer meeting";
            taskDetail.Id = "1005";
            taskDetail.Assignee = "James Williams";
            taskDetail.Description = "Arrange a web meeting with the customer to show filtering demo.";
            taskDetail.Category = "Closed";
            taskDetail.IndicatorColorKey = "Low";
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle5.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "Filtering issue";
            taskDetail.Id = "1006";
            taskDetail.Assignee = "Adeline Elena";
            taskDetail.Description = "Fix the filtering issues reported in Safari.";
            taskDetail.Category = "Closed";
            taskDetail.IndicatorColorKey = "Normal";
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle17.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "Filtering feature";
            taskDetail.Id = "1007";
            taskDetail.Assignee = "Stephen Addison";
            taskDetail.Description = "Enhance filtering feature.";
            taskDetail.Category = "Closed";
            taskDetail.IndicatorColorKey = "Normal";
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle31.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "Customer meeting";
            taskDetail.Id = "1008";
            taskDetail.Assignee = "Adeline Elena";
            taskDetail.Description = "Arrange a web meeting with the customer to get new requirements.";
            taskDetail.Category = "Open";
            taskDetail.IndicatorColorKey = "Normal";
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle17.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "Edge browser issues";
            taskDetail.Id = "1009";
            taskDetail.Assignee = "Adeline Elena";
            taskDetail.Description = "Fix the issues reported in the Edge browser.";
            taskDetail.Category = "In Progress";
            taskDetail.IndicatorColorKey = "Low";
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle17.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "SQL error";
            taskDetail.Id = "1010";
            taskDetail.Assignee = "Daniel Williams";
            taskDetail.Description = "Fix cannot open user's default database SQL error.";
            taskDetail.Category = "In Progress";
            taskDetail.IndicatorColorKey = "Normal";
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle23.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "Chrome issue";
            taskDetail.Id = "1011";
            taskDetail.Assignee = "James Williams";
            taskDetail.Description = "Fix editing issues reported in chrome.";
            taskDetail.Category = "In Progress";
            taskDetail.IndicatorColorKey = "High";
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle5.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "Data binding issues";
            taskDetail.Id = "1012";
            taskDetail.Assignee = "Andrew Fuller";
            taskDetail.Description = "Fix the issues reported in data binding.";
            taskDetail.Category = "Review";
            taskDetail.IndicatorColorKey = "High";
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle14.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "Customer issues";
            taskDetail.Id = "1013";
            taskDetail.Assignee = "Stephen Addison";
            taskDetail.Description = "Fix the editing issues reported by customer.";
            taskDetail.Category = "Review";
            taskDetail.IndicatorColorKey = "Low";
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle31.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "Analysis";
            taskDetail.Id = "1014";
            taskDetail.Assignee = "Daniel Williams";
            taskDetail.Description = "Analyze stored procedures.";
            taskDetail.Category = "Closed";
            taskDetail.IndicatorColorKey = "Normal";
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle23.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "Editing feature";
            taskDetail.Id = "1015";
            taskDetail.Assignee = "Adeline Elena";
            taskDetail.Description = "Test editing feature in the IE browser.";
            taskDetail.Category = "Closed";
            taskDetail.IndicatorColorKey = "High";
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle17.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "Filtering feature";
            taskDetail.Id = "1016";
            taskDetail.Assignee = "Daniel Williams";
            taskDetail.Description = "Test filtering in the IE browser.";
            taskDetail.Category = "Closed";
            taskDetail.IndicatorColorKey = "Normal";
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle23.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "Responsive support";
            taskDetail.Id = "1017";
            taskDetail.Assignee = "Laura Callahan";
            taskDetail.Description = "Add responsive support to application.";
            taskDetail.Category = "In Progress";
            taskDetail.IndicatorColorKey = "Normal";
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle13.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "Filtering feature";
            taskDetail.Id = "1018";
            taskDetail.Assignee = "Laura Callahan";
            taskDetail.Description = "Check filtering validation.";
            taskDetail.Category = "Review";
            taskDetail.IndicatorColorKey = "Normal";
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle13.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "Login validation";
            taskDetail.Id = "1019";
            taskDetail.Assignee = "Stephen Addison";
            taskDetail.Description = "Login page validation.";
            taskDetail.Category = "Closed";
            taskDetail.IndicatorColorKey = "Low";
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle31.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "Data in Grid";
            taskDetail.Id = "1020";
            taskDetail.Assignee = "Andrew Fuller";
            taskDetail.Description = "Show the retrieved data from the server in grid control.";
            taskDetail.Category = "Open";
            taskDetail.IndicatorColorKey = "Normal";
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle14.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "Filtering issues";
            taskDetail.Id = "1021";
            taskDetail.Assignee = "Daniel Williams";
            taskDetail.Description = "Fix filtering issues reported in the IE browser.";
            taskDetail.Category = "In Progress";
            taskDetail.IndicatorColorKey = "Low";
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle23.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "Testing";
            taskDetail.Id = "1022";
            taskDetail.Assignee = "James Williams";
            taskDetail.Description = "Test the application in the IE browser.";
            taskDetail.Category = "Closed";
            taskDetail.IndicatorColorKey = "Normal";
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle5.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "Analysis";
            taskDetail.Id = "1023";
            taskDetail.Assignee = "Andrew Fuller";
            taskDetail.Description = "Analyze grid control.";
            taskDetail.Category = "Closed";
            taskDetail.IndicatorColorKey = "Normal";
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle14.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "Customer meeting";
            taskDetail.Id = "1024";
            taskDetail.Assignee = "Stephen Addison";
            taskDetail.Description = "Arrange a web meeting with the customer to get new filtering requirements.";
            taskDetail.Category = "Closed";
            taskDetail.IndicatorColorKey = "Normal";
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle31.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "Testing";
            taskDetail.Id = "1025";
            taskDetail.Assignee = "James Williams";
            taskDetail.Description = "Check login page validation.";
            taskDetail.Category = "Review";
            taskDetail.IndicatorColorKey = "Normal";
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle5.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "Customer meeting";
            taskDetail.Id = "1026";
            taskDetail.Assignee = "Stephen Addison";
            taskDetail.Description = "Arrange a web meeting with the customer to get the login page requirements.";
            taskDetail.Category = "Closed";
            taskDetail.IndicatorColorKey = "Normal";
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle31.png"))
            };

            taskDetails.Add(taskDetail);

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
                if (this.TaskDetails != null)
                {
                    this.TaskDetails.Clear();
                    this.TaskDetails = null;
                }
            }
        }

        #endregion

        #region PropertyChanged

        /// <summary>
        /// Event that is raised when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Method to raise the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}