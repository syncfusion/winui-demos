namespace Syncfusion.KanbanDemos.WinUI
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Microsoft.UI.Xaml.Controls;
    using Microsoft.UI.Xaml.Media.Imaging;
    using Syncfusion.UI.Xaml.Kanban;

    /// <summary>
    /// Represents a ViewModel that designed to manage a collection of kanban tasks in a software project management system, typically used in kanban boards.
    /// </summary>
    public class SelectionViewModel: IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets or sets the collection of <see cref="KanbanModel"/> objects representing tasks in various stages.
        /// </summary>
        public ObservableCollection<KanbanModel> TaskDetails { get; set; }

        /// <summary>
        /// Gets or sets the selection mode for the Kanban board, which determines how users can select tasks (e.g., single selection, multiple selection).
        /// </summary>
        public ObservableCollection<string> SelectionMode { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectionViewModel"/> class.
        /// </summary>
        public SelectionViewModel()
        {
            this.TaskDetails = this.GetTaskDetails();
            this.SelectionMode = this.GetSelectionModes();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Method to retrieve a predefined collection of selection modes for the Kanban board.
        /// </summary>
        /// <returns>The collection of selection modes.</returns>
        private ObservableCollection<string> GetSelectionModes()
        {
            return new ObservableCollection<string>()
            {
                "Single",
                "Multiple",
                "None",
            };
        }

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
            taskDetail.Title = "UWP Issue";
            taskDetail.Id = "6593";
            taskDetail.Description = "Sorting is not working properly in DateTimeAxis";
            taskDetail.Category = "Postponed";
            taskDetail.IndicatorColorKey = "High";
            taskDetail.Tags = new List<string>() { "Bug Fixing" };
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle1.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "New Feature";
            taskDetail.Id = "6593";
            taskDetail.Description = "Need to create code base for Gantt control";
            taskDetail.Category = "Postponed";
            taskDetail.IndicatorColorKey = "Low";
            taskDetail.Tags = new List<string>() { "GanttControl UWP" };
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle2.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "UG";
            taskDetail.Id = "6516";
            taskDetail.Description = "Need to do post-processing work for closed incidents";
            taskDetail.Category = "Postponed";
            taskDetail.IndicatorColorKey = "Normal";
            taskDetail.Tags = new List<string>() { "Post-processing" };
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle3.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "UWP Issue";
            taskDetail.Id = "651";
            taskDetail.Description = "Crosshair label template not visible in UWP";
            taskDetail.Category = "Open";
            taskDetail.IndicatorColorKey = "High";
            taskDetail.Tags = new List<string>() { "Bug Fixing" };
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle4.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "WinUI Issue";
            taskDetail.Id = "646";
            taskDetail.Description = "AxisLabel cropped when rotating the axis label";
            taskDetail.Category = "Open";
            taskDetail.IndicatorColorKey = "Low";
            taskDetail.Tags = new List<string>() { "Bug Fixing" };
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle5.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "WPF Issue";
            taskDetail.Id = "23822";
            taskDetail.Description = "Need to implement tooltip support for histogram series";
            taskDetail.Category = "Open";
            taskDetail.IndicatorColorKey = "High";
            taskDetail.Tags = new List<string>() { "Bug Fixing" };
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle6.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "Kanban Feature";
            taskDetail.Id = "25678";
            taskDetail.Description = "Provide drag and drop support";
            taskDetail.Category = "In Progress";
            taskDetail.IndicatorColorKey = "Low";
            taskDetail.Tags = new List<string>() { "New control" };
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle7.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "WF Issue";
            taskDetail.Id = "1254";
            taskDetail.Description = "HorizontalAlignment for tooltip is not working";
            taskDetail.Category = "In Progress";
            taskDetail.IndicatorColorKey = "High";
            taskDetail.Tags = new List<string>() { "Bug fixing" };
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle8.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "WPF Issue";
            taskDetail.Id = "28066";
            taskDetail.Description = "In minimized state, first and last segments have incorrect spacing";
            taskDetail.Category = "Review";
            taskDetail.IndicatorColorKey = "Normal";
            taskDetail.Tags = new List<string>() { "Bug Fixing" };
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle9.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "WinUI Issue";
            taskDetail.Id = "29477";
            taskDetail.Description = "Null reference exception thrown in line chart";
            taskDetail.Category = "Review";
            taskDetail.IndicatorColorKey = "Normal";
            taskDetail.Tags = new List<string>() { "Bug Fixing" };
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle10.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "WPF Issue";
            taskDetail.Id = "29574";
            taskDetail.Description = "Minimum and maximum properties are not working in dynamic update";
            taskDetail.Category = "Review";
            taskDetail.IndicatorColorKey = "High";
            taskDetail.Tags = new List<string>() { "Bug Fixing" };
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle11.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "Kanban Feature";
            taskDetail.Id = "29574";
            taskDetail.Description = "Need to implement tooltip support for Kanban";
            taskDetail.Category = "Review";
            taskDetail.IndicatorColorKey = "High";
            taskDetail.Tags = new List<string>() { "New Control" };
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle12.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "New Feature";
            taskDetail.Id = "29574";
            taskDetail.Description = "Dragging events support for Kanban";
            taskDetail.Category = "Closed";
            taskDetail.IndicatorColorKey = "Normal";
            taskDetail.Tags = new List<string>() { "New Control" };
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle13.png"))
            };

            taskDetails.Add(taskDetail);

            taskDetail = new KanbanModel();
            taskDetail.Title = "New Feature";
            taskDetail.Id = "29574";
            taskDetail.Description = "Swimlane support for Kanban";
            taskDetail.Category = "Open";
            taskDetail.IndicatorColorKey = "Low";
            taskDetail.Tags = new List<string>() { "New Control" };
            taskDetail.Image = new Image
            {
                Source = new BitmapImage(new Uri(path + "Assets/Kanban/People_Circle14.png"))
            };

            taskDetails.Add(taskDetail);
            return taskDetails;
        }

        /// <summary>
        /// Releases the managed resources used by the class.
        /// </summary>
        /// <param name="isDisposable">A boolean value indicating whether to release managed resources.</param>
        protected virtual void Dispose(bool isDisposable)
        {
            if (isDisposable)
            {
                if (this.TaskDetails != null)
                {
                    this.TaskDetails.Clear();
                    this.TaskDetails = null;
                }

                if(this.SelectionMode != null)
                {
                    this.SelectionMode.Clear();
                    this.SelectionMode = null;
                }
            }
        }

        /// <summary>
        /// Method to dispose the objects.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}