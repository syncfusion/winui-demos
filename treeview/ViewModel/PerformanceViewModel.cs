#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System.ComponentModel;
using System;
using System.Xml.Linq;
using System.Windows.Input;
using System.Windows;
using Syncfusion.UI.Xaml.TreeView;
using System.Collections.Generic;
using System.Collections;
using Microsoft.UI.Xaml;
using Syncfusion.UI.Xaml.Core;
using System.Threading.Tasks;


namespace Syncfusion.TreeViewDemos.WinUI
{
    /// <summary>
    /// Represents the < see cref="PerformanceViewModel"/ > class that contains the collection of items used to populate the <see cref="Syncfusion.UI.Xaml.TreeView"/>.
    /// </summary>
    public class PerformanceViewModel : NotificationObject
    {
        #region Fields
        /// <summary>
        /// Determines whether the Progerss Ring is loaded or not.
        /// </summary>
        private bool isBusy;

        /// <summary>
        /// Maintains the visibilty of SfTreeView.
        /// </summary>
        private Visibility treeViewVisibility = Visibility.Collapsed;
       
        /// <summary>
        /// Represents the ObservableCollection with PerformanceModel.
        /// </summary>
        private ObservableCollection<PerformanceModel> items = new ObservableCollection<PerformanceModel>();

        /// <summary>
        /// Represents the the <see cref="DelegateCommand"/> which will be executed when tap on the expander. 
        /// </summary>
        private DelegateCommand treeViewOnDemandCommand;

        /// <summary>
        /// Represents the the <see cref="DelegateCommand"/> which will be executed when tap on the button. 
        /// </summary>
        private DelegateCommand clickCommand;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PerformanceViewModel"/> class.
        /// </summary>
        public PerformanceViewModel()
        {
            ClickCommand = new DelegateCommand(ExecuteClickAction, CanExecuteClickCommand);
            TreeViewOnDemandCommand = new DelegateCommand(ExecuteOnDemandLoading, CanExecuteOnDemandLoading);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the value that indicating IsActive status in Progerss Ring.
        /// </summary>
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                RaisePropertyChanged(nameof(IsBusy));
            }
        }

        /// <summary>
        /// Gets or sets the visibility of SfTreeView.
        /// </summary>
        public Visibility TreeViewVisibility
        {
            get { return treeViewVisibility; }
            set
            {
                treeViewVisibility = value;
                RaisePropertyChanged(nameof(TreeViewVisibility));
            }
        }

        /// <summary>
        /// Gets or sets the collection for Items.
        /// </summary>
        public ObservableCollection<PerformanceModel> Items
        {
            get { return items; }
            internal set { items = value; this.RaisePropertyChanged(nameof(Items)); }
        }
        #endregion

        #region Command
        /// <summary>
        /// Gets or sets the <see cref="DelegateCommand"/> which will be executed when tap on the expander. 
        /// </summary>
        public DelegateCommand TreeViewOnDemandCommand
        {
            get { return treeViewOnDemandCommand; }
            set { treeViewOnDemandCommand = value; }
        }
        
        /// <summary>
        /// Gets or sets the <see cref="DelegateCommand"/> which will be executed when tap on the button. 
        /// </summary>
        public DelegateCommand ClickCommand
        {
            get { return clickCommand; }
            set { clickCommand = value; }
        }
        #endregion

        #region Methods 
        /// <summary>
        /// Sets the collection for the SfTreeView.
        /// </summary>
        /// <param name="count">Represents the Items count.</param>
        /// <returns>Returns the collection.</returns>
        private static ObservableCollection<PerformanceModel> GetCollection(int count)
        {
            ObservableCollection<PerformanceModel> collection = new ObservableCollection<PerformanceModel>();
            for (int i = 0; i < count; i++)
            {
                collection.Add(new PerformanceModel() { Header = "Module " + (i + 1) });
            }

            return collection;
        }

        /// <summary>
        /// Sets the collection for the child items.
        /// </summary>
        /// <param name="item">Represents the PerformanceModel.</param>
        /// <returns>Returns the collection.</returns>
        private static ObservableCollection<PerformanceModel> GetChildItems(PerformanceModel item)
        {
            ObservableCollection<PerformanceModel> childItems = new ObservableCollection<PerformanceModel>();
            for (int i = 0; i < 500; i++)
            {
                childItems.Add(new PerformanceModel() { Header = item.Header + "." + (i+1) });
            }
            
            return childItems;
        }

        /// <summary>
        /// CanExecute method is called before expanding and initialization of node. Returns whether the node has child nodes or not.
        /// Based on return value, expander visibility of the node is handled.  
        /// </summary>
        /// <param name="sender">TreeViewNode is passed as default parameter.</param>
        /// <returns>Returns true, if the specified node has child items to load on demand and expander icon is displayed for that node, else returns false and icon is not displayed.</returns>
        private bool CanExecuteOnDemandLoading(object sender)
        {
            var node = sender as TreeViewNode;
            if (node.Level < 3)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Execute method is called when any item is requested for load-on-demand items.
        /// </summary>
        /// <param name="obj">TreeViewNode is passed as default parameter </param>
#if WinUI_Desktop
        private void ExecuteOnDemandLoading(object obj)
#else
        private async void ExecuteOnDemandLoading(object obj)
#endif
        {
            var node = obj as TreeViewNode;

            // Skip the repeated population of child items when every time the node expands.
            if (node.ChildNodes.Count > 0)
            {
                node.IsExpanded = true;
                return;
            }
            var item = node.Content as PerformanceModel;

            //Animation starts for expander to show progressing of load on demand
            node.ShowExpanderAnimation = true;

#if WinUI_Desktop
            Application.Current.Resources.DispatcherQueue.TryEnqueue(() =>
            {
#else
            await Application.Current.Resources.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
            {
                await Task.Delay(2000).ConfigureAwait(true);
#endif
                var childItems = GetChildItems(item);
                node.PopulateChildNodes(childItems);
                if (childItems.Count > 0)
                    node.IsExpanded = true;
                //Stop the animation after load on demand is executed, if animation not stopped, it remains still after execution of load on demand.
                node.ShowExpanderAnimation = false;
            });
        }

        /// <summary>
        /// CanExecute method is called before clicking the button. 
        /// </summary>
        /// <param name="sender">button is passed as default parameter,</param>
        /// <returns>Returns a boolean value.</returns>
        private bool CanExecuteClickCommand(object sender)
        {
            return true;
        }

        /// <summary>
        /// Execute method is called when button is clicked.
        /// </summary>
        /// <param name="obj">TreeViewNode is passed as default parameter </param>
#if WinUI_Desktop
        private void ExecuteClickAction(object obj)
#else
        private async void ExecuteClickAction(object obj)
#endif
        {
            var button = obj as Microsoft.UI.Xaml.Controls.Button;
            button.Visibility = Visibility.Collapsed;
            this.IsBusy = true;
           
#if WinUI_Desktop
            Application.Current.Resources.DispatcherQueue.TryEnqueue(() =>
            {
#else
            await Application.Current.Resources.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
            {
                await Task.Delay(2000).ConfigureAwait(true);
#endif
                this.Items = GetCollection(100000); ;
                this.IsBusy = false;
                this.TreeViewVisibility = Visibility.Visible;
            });
        } 
        #endregion
    }
}
