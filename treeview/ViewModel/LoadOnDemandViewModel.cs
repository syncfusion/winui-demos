#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media.Imaging;
using Syncfusion.UI.Xaml.Core;
using Syncfusion.UI.Xaml.TreeView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Syncfusion.TreeViewDemos.WinUI
{
    /// <summary>
    /// Represents the < see cref="LoadOnDemandViewModel"/ > class that contains the collection of items used to populate the <see cref="Syncfusion.UI.Xaml.TreeView"/>.
    /// </summary>
    public class LoadOnDemandViewModel
    {
        #region Fields
        /// <summary>
        /// Maintains the collections for items.
        /// </summary>
        private ObservableCollection<LoadOnDemandModel> menu;
   
        /// <summary>
        /// Represents the the <see cref="DelegateCommand"/> which will be executed when tap on the expander. 
        /// </summary>
        private DelegateCommand treeViewOnDemandCommand;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MusicInfoRepository"/> class.
        /// </summary>
        public LoadOnDemandViewModel()
        {
            this.Menu = GetMenuItems();
            TreeViewOnDemandCommand = new DelegateCommand(ExecuteOnDemandLoading, CanExecuteOnDemandLoading);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the collections for items.
        /// </summary>
        public ObservableCollection<LoadOnDemandModel> Menu
        {
            get { return menu; }
            internal set { menu = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="DelegateCommand"/> which will be executed when tap on the expander. 
        /// </summary>
        public DelegateCommand TreeViewOnDemandCommand
        {
            get { return treeViewOnDemandCommand; }
            set { treeViewOnDemandCommand = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// set the collection for child items.
        /// </summary>
        /// <param name="iD">The value of ID.</param>
        /// <returns>Returns the collection.</returns>
        public static IEnumerable<LoadOnDemandModel> GetSubMenu(int iD)
        {
            ObservableCollection<LoadOnDemandModel> menuItems = new ObservableCollection<LoadOnDemandModel>();
            if (iD == 1)
            {
                menuItems.Add(new LoadOnDemandModel() { ItemName = "Hot Singles", HasChildNodes = false, ID = 11 });
                menuItems.Add(new LoadOnDemandModel() { ItemName = "Rising Artists", HasChildNodes = false, ID = 12 });
                menuItems.Add(new LoadOnDemandModel() { ItemName = "Live Music", HasChildNodes = false, ID = 13 });
                menuItems.Add(new LoadOnDemandModel() { ItemName = "More in Music", HasChildNodes = true, ID = 14 });
            }
            else if (iD == 2)
            {
                menuItems.Add(new LoadOnDemandModel() { ItemName = "100 Albums - $10 Each", HasChildNodes = false, ID = 21 });
                menuItems.Add(new LoadOnDemandModel() { ItemName = "Hip-Hop and R&B Sale", HasChildNodes = false, ID = 22 });
                menuItems.Add(new LoadOnDemandModel() { ItemName = "CD Deals", HasChildNodes = false, ID = 23 });
            }
            else if (iD == 3)
            {
                menuItems.Add(new LoadOnDemandModel() { ItemName = "Songs", HasChildNodes = false, ID = 31 });
                menuItems.Add(new LoadOnDemandModel() { ItemName = "Bestselling Albums", HasChildNodes = false, ID = 32 });
                menuItems.Add(new LoadOnDemandModel() { ItemName = "New Releases", HasChildNodes = false, ID = 33 });
                menuItems.Add(new LoadOnDemandModel() { ItemName = "MP3 Albums", HasChildNodes = false, ID = 34 });

            }
            else if (iD == 4)
            {
                menuItems.Add(new LoadOnDemandModel() { ItemName = "Rock Music", HasChildNodes = false, ID = 41 });
                menuItems.Add(new LoadOnDemandModel() { ItemName = "Gospel", HasChildNodes = false, ID = 42 });
                menuItems.Add(new LoadOnDemandModel() { ItemName = "Latin Music", HasChildNodes = false, ID = 43 });
                menuItems.Add(new LoadOnDemandModel() { ItemName = "Jazz", HasChildNodes = false, ID = 44 });
            }
            else if (iD == 5)
            {
                menuItems.Add(new LoadOnDemandModel() { ItemName = "Hunger Games", HasChildNodes = false, ID = 51 });
                menuItems.Add(new LoadOnDemandModel() { ItemName = "Pride and Prejudice", HasChildNodes = false, ID = 52 });
                menuItems.Add(new LoadOnDemandModel() { ItemName = "Harry Potter", HasChildNodes = false, ID = 53 });
                menuItems.Add(new LoadOnDemandModel() { ItemName = "Game of Thrones", HasChildNodes = false, ID = 54 });
            }
            else if (iD == 14)
            {
                menuItems.Add(new LoadOnDemandModel() { ItemName = "Music Trade-In", HasChildNodes = false, ID = 141 });
                menuItems.Add(new LoadOnDemandModel() { ItemName = "Redeem a Gift Card", HasChildNodes = false, ID = 142 });
                menuItems.Add(new LoadOnDemandModel() { ItemName = "Band T-Shirts", HasChildNodes = false, ID = 143 });
            }
            return menuItems;
        }

        /// <summary>
        /// CanExecute method is called before expanding and initialization of node. Returns whether the node has child nodes or not.
        /// Based on return value, expander visibility of the node is handled.  
        /// </summary>
        /// <param name="sender">TreeViewNode is passed as default parameter </param>
        /// <returns>Returns true, if the specified node has child items to load on demand and expander icon is displayed for that node, else returns false and icon is not displayed.</returns>
        private bool CanExecuteOnDemandLoading(object sender)
        {
            var haschildnodes = ((sender as TreeViewNode).Content as LoadOnDemandModel).HasChildNodes;
            if (haschildnodes)
            {
                if ((sender as TreeViewNode).ChildNodes.Count > 0)
                    return false;
                else
                    return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Execute method is called when any item is requested for load-on-demand items.
        /// </summary>
        /// <param name="obj">TreeViewNode is passed as default parameter </param>
        private void ExecuteOnDemandLoading(object obj)
        {
            var node = obj as TreeViewNode;
            node.ShowExpanderAnimation = true;
            LoadOnDemandModel loadOnDemandModel = node.Content as LoadOnDemandModel;
            Application.Current.Resources.DispatcherQueue.TryEnqueue(() =>
            { 
                var items = GetSubMenu(loadOnDemandModel.ID);
                node.PopulateChildNodes(items);
                if (items.Any())
                    node.IsExpanded = true;
                node.ShowExpanderAnimation = false;
            });
        }

        /// <summary>
        /// set the collections for root nodes.
        /// </summary>
        /// <returns>Returns the collection.</returns>
        private static ObservableCollection<LoadOnDemandModel> GetMenuItems()
        {
            ObservableCollection<LoadOnDemandModel> menuItems = new ObservableCollection<LoadOnDemandModel>();
            menuItems.Add(new LoadOnDemandModel() { ItemName = "Discover Music", HasChildNodes = true, ID = 1 });
            menuItems.Add(new LoadOnDemandModel() { ItemName = "Sales and Events", HasChildNodes = true, ID = 2 });
            menuItems.Add(new LoadOnDemandModel() { ItemName = "Categories", HasChildNodes = true, ID = 3 });
            menuItems.Add(new LoadOnDemandModel() { ItemName = "MP3 Albums", HasChildNodes = true, ID = 4 });
            menuItems.Add(new LoadOnDemandModel() { ItemName = "Fiction Book Lists", HasChildNodes = true, ID = 5 });
            return menuItems;
        }
        #endregion
    }
}