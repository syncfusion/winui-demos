#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Media.Imaging;
using Syncfusion.UI.Xaml.Core;
using Syncfusion.UI.Xaml.TreeView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.treeviewdemos.winui
{
    /// <summary>
    /// Represents the < see cref="DragAndDropViewModel"/ > class that contains the collection of items used to populate the <see cref="Syncfusion.UI.Xaml.TreeView"/>.
    /// </summary>
    public class DragAndDropViewModel : NotificationObject
    {
        #region Fields
        /// <summary>
        /// Represents the the <see cref="DelegateCommand"/> which will be executed when tap on the button. 
        /// </summary>
        private DelegateCommand expandCommand;

        /// <summary>
        /// Represents the the <see cref="DelegateCommand"/> which will be executed when tap on the button. 
        /// </summary>
        private DelegateCommand collapseCommand;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="DranAndDropViewModel"/> class.
        /// </summary>
        public DragAndDropViewModel()
        {
            Items = new ObservableCollection<DragAndDropModel>();
            Collections = new ObservableCollection<DragAndDropModel>();
            ExpandCommand = new DelegateCommand(ExpandNodes);
            CollapseCommand = new DelegateCommand(CollapseNodes);

            // Generate source for SfTreeView1
            PopulateItems();
            // Generate source for SfTreeView2
            PopulateCollections();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the <see cref="DelegateCommand"/> which will be executed when tap on the button. 
        /// </summary>
        public DelegateCommand ExpandCommand
        {
            get { return expandCommand; }
            set { expandCommand = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="DelegateCommand"/> which will be executed when tap on the button. 
        /// </summary>
        public DelegateCommand CollapseCommand
        {
            get { return collapseCommand; }
            set { collapseCommand = value; }
        }

        /// <summary>
        /// Gets or sets the collections for items.
        /// </summary>
        public ObservableCollection<DragAndDropModel> Items { get; set; }

        /// <summary>
        /// Gets or sets the collections for items.
        /// </summary>
        public ObservableCollection<DragAndDropModel> Collections { get; set; }

        /// <summary>
        /// Gets or sets the collection for Selected Nodes.
        /// </summary>
        public ObservableCollection<object> SelectedNodes { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Method used to Expand all the nodes.
        /// </summary>
        /// <param name="sender"></param>
        private void ExpandNodes(object sender)
        {
            var treeview = sender as SfTreeView;
            treeview.ExpandAll();
        }

        /// <summary>
        /// Method used to collapse all the nodes.
        /// </summary>
        /// <param name="sender"></param>
        private void CollapseNodes(object sender)
        {
            var treeview = sender as SfTreeView;
            treeview.CollapseAll();
        }

        /// <summary>
        /// populate the items in collection.
        /// </summary>
        private void PopulateItems()
        {
            var RootNode1 = new DragAndDropModel { Header = "Discover Music", IsExpanded = true };
            var RootNode2 = new DragAndDropModel { Header = "Sales and Events", IsExpanded = true };
            var RootNode3 = new DragAndDropModel { Header = "MP3 Albums", IsExpanded = true };
            var RootNode4 = new DragAndDropModel { Header = "Fiction Book Lists", IsExpanded = true };
            var RootNode5 = new DragAndDropModel { Header = "Wallpapers.png", IsExpanded = false };

            var ChildNode1 = new DragAndDropModel { Header = "Live Music", IsExpanded = true };
            var ChildNode2 = new DragAndDropModel { Header = "More in Music", IsExpanded = true };
            var ChildNode3 = new DragAndDropModel { Header = "Rising Artists", IsExpanded = false };
            var ChildNode4 = new DragAndDropModel { Header = "Hot Singles", IsExpanded = false };

            var ChildNode5 = new DragAndDropModel { Header = "100 Albums - $10 Each", IsExpanded = false };
            var ChildNode6 = new DragAndDropModel { Header = "Hip-Hop and R&B Sale", IsExpanded = true };
            var ChildNode7 = new DragAndDropModel { Header = "CD Deals", IsExpanded = false };
            var ChildNode8 = new DragAndDropModel { Header = "Tamil Albums", IsExpanded = false };

            var ChildNode9 = new DragAndDropModel { Header = "Rock Music", IsExpanded = false };
            var ChildNode10 = new DragAndDropModel { Header = "Gospel", IsExpanded = false };            
            var ChildNode11 = new DragAndDropModel { Header = "Latin Music", IsExpanded = true };
            var ChildNode12 = new DragAndDropModel { Header = "Jazz", IsExpanded = false };

            var ChildNode13 = new DragAndDropModel { Header = "Hunger Games", IsExpanded = false };
            var ChildNode14 = new DragAndDropModel { Header = "Pride and Prejudice", IsExpanded = true };
            var ChildNode15 = new DragAndDropModel { Header = "Harry Potter", IsExpanded = false };
            var ChildNode16 = new DragAndDropModel { Header = "Game of Thrones", IsExpanded = false };
                 
            var ChildNode17 = new DragAndDropModel { Header = "Sky.png", IsExpanded = true };
            var ChildNode18 = new DragAndDropModel { Header = "Nature.png", IsExpanded = false };
            var ChildNode19 = new DragAndDropModel { Header = "River.png", IsExpanded = false };
            var ChildNode20 = new DragAndDropModel { Header = "Sea.png", IsExpanded = false };

            RootNode1.Childs.Add(ChildNode1);
            RootNode1.Childs.Add(ChildNode2);
            RootNode1.Childs.Add(ChildNode3);

            RootNode2.Childs.Add(ChildNode5);
            RootNode2.Childs.Add(ChildNode6);
            RootNode2.Childs.Add(ChildNode7);
            RootNode2.Childs.Add(ChildNode8);

            RootNode3.Childs.Add(ChildNode9);
            RootNode3.Childs.Add(ChildNode10);
            RootNode3.Childs.Add(ChildNode11);
            RootNode3.Childs.Add(ChildNode12);

            RootNode4.Childs.Add(ChildNode13);
            RootNode4.Childs.Add(ChildNode14);
            RootNode4.Childs.Add(ChildNode15);
            RootNode4.Childs.Add(ChildNode16);

            RootNode5.Childs.Add(ChildNode17);
            RootNode5.Childs.Add(ChildNode18);
            RootNode5.Childs.Add(ChildNode19);
            RootNode5.Childs.Add(ChildNode20);

            ChildNode1.Childs.Add(ChildNode4);

            Items.Add(RootNode1);
            Items.Add(RootNode2);
            Items.Add(RootNode3);
            Items.Add(RootNode4);
            Items.Add(RootNode5);

        }

        /// <summary>
        /// populate the items in collection.
        /// </summary>
        void PopulateCollections()
        {
            var RootNode1 = new DragAndDropModel { Header = "Work Documents", IsExpanded = true };
            var RootNode2 = new DragAndDropModel { Header = "Personal Folder", IsExpanded = true };

            var ChildNode1 = new DragAndDropModel { Header = "Functional Specifications", IsExpanded = true };
            var ChildNode2 = new DragAndDropModel { Header = "TreeView spec", IsExpanded = true };
            var ChildNode3 = new DragAndDropModel { Header = "Feature Schedule", IsExpanded = false };
            var ChildNode4 = new DragAndDropModel { Header = "Overall Project Plan", IsExpanded = false };
            var ChildNode5 = new DragAndDropModel { Header = "Feature Resource Allocation", IsExpanded = false };
            var ChildNode6 = new DragAndDropModel { Header = "Home Remodel Folder", IsExpanded = true };
            var ChildNode7 = new DragAndDropModel { Header = "Contractor Contact Info", IsExpanded = false };
            var ChildNode8 = new DragAndDropModel { Header = "Paint Color Scheme", IsExpanded = false };
            var ChildNode9 = new DragAndDropModel { Header = "Flooring Woodgrain type", IsExpanded = false };
            var ChildNode10 = new DragAndDropModel { Header = "Kitchen Cabinet Style", IsExpanded = false };

            var ChildNode11 = new DragAndDropModel { Header = "My Network Places", IsExpanded = true };
            var ChildNode12 = new DragAndDropModel { Header = "Server", IsExpanded = false };
            var ChildNode13 = new DragAndDropModel { Header = "My Folders", IsExpanded = false };

            var ChildNode14 = new DragAndDropModel { Header = "My Computer", IsExpanded = true };
            var ChildNode15 = new DragAndDropModel { Header = "Music", IsExpanded = false };
            var ChildNode16 = new DragAndDropModel { Header = "Videos", IsExpanded = false };
            var ChildNode17 = new DragAndDropModel { Header = "Wallpaper.png", IsExpanded = false };
            var ChildNode18 = new DragAndDropModel { Header = "My Banner.png", IsExpanded = false };

            

            var ChildNode19 = new DragAndDropModel { Header = "Favourites", IsExpanded = true };
            var ChildNode20 = new DragAndDropModel { Header = "Image3.png", IsExpanded = false };
            var ChildNode21 = new DragAndDropModel { Header = "Image4.png", IsExpanded = false };
            var ChildNode22 = new DragAndDropModel { Header = "Image5.png", IsExpanded = false };

            var ChildNode23 = new DragAndDropModel { Header = "Image1.png", IsExpanded = false };
            var ChildNode24 = new DragAndDropModel { Header = "Image2.png", IsExpanded = false };

            RootNode1.Childs.Add(ChildNode1);
            RootNode1.Childs.Add(ChildNode3);
            RootNode1.Childs.Add(ChildNode4);
            RootNode1.Childs.Add(ChildNode5);
            RootNode2.Childs.Add(ChildNode6);

            RootNode2.Childs.Add(ChildNode11);
            RootNode2.Childs.Add(ChildNode14);
            RootNode2.Childs.Add(ChildNode19);

            ChildNode1.Childs.Add(ChildNode2);
            ChildNode6.Childs.Add(ChildNode7);
            ChildNode6.Childs.Add(ChildNode8);
            ChildNode6.Childs.Add(ChildNode9);
            ChildNode6.Childs.Add(ChildNode10);
            ChildNode11.Childs.Add(ChildNode12);
            ChildNode11.Childs.Add(ChildNode13);
            
            ChildNode11.Childs.Add(ChildNode23);
            ChildNode11.Childs.Add(ChildNode24);

            ChildNode14.Childs.Add(ChildNode15);
            ChildNode14.Childs.Add(ChildNode16);
            ChildNode14.Childs.Add(ChildNode17);
            ChildNode14.Childs.Add(ChildNode18);

            ChildNode19.Childs.Add(ChildNode20);
            ChildNode19.Childs.Add(ChildNode21);
            ChildNode19.Childs.Add(ChildNode22);

            SelectedNodes = new ObservableCollection<object>();
            SelectedNodes.Add(ChildNode1);
            SelectedNodes.Add(ChildNode4);
            SelectedNodes.Add(ChildNode8);
            Collections.Add(RootNode1);
            Collections.Add(RootNode2);
        }
        #endregion
    }
}
