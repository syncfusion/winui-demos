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

namespace Syncfusion.TreeViewDemos.WinUI
{
    /// <summary>
    /// Represents the < see cref="GettingStartedViewModel"/ > class that contains the collection of items used to populate the <see cref="Syncfusion.UI.Xaml.TreeView"/>.
    /// </summary>
    public class GettingStartedViewModel : NotificationObject
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
        public GettingStartedViewModel()
        {
            Collections = new ObservableCollection<GettingStartedModel>();
            ExpandCommand = new DelegateCommand(ExpandNodes);
            CollapseCommand = new DelegateCommand(CollapseNodes);
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
        public ObservableCollection<GettingStartedModel> Collections { get; internal set; }

        /// <summary>
        /// Gets or sets the collection for Selected Nodes.
        /// </summary>
        public ObservableCollection<object> SelectedNodes { get; internal set; }
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
        void PopulateCollections()
        {
            var RootNode1 = new GettingStartedModel { Header = "Work Documents"};
            var RootNode2 = new GettingStartedModel { Header = "Personal Folder"};

            var ChildNode1 = new GettingStartedModel { Header = "Functional Specifications"};
            var ChildNode2 = new GettingStartedModel { Header = "TreeView spec"};
            var ChildNode3 = new GettingStartedModel { Header = "Feature Schedule"};
            var ChildNode4 = new GettingStartedModel { Header = "Overall Project Plan"};
            var ChildNode5 = new GettingStartedModel { Header = "Feature Resource Allocation"};
            var ChildNode6 = new GettingStartedModel { Header = "Home Remodel Folder"};
            var ChildNode7 = new GettingStartedModel { Header = "Contractor Contact Info"};
            var ChildNode8 = new GettingStartedModel { Header = "Paint Color Scheme"};
            var ChildNode9 = new GettingStartedModel { Header = "Flooring Woodgrain type"};
            var ChildNode10 = new GettingStartedModel { Header = "Kitchen Cabinet Style"};

            var ChildNode11 = new GettingStartedModel { Header = "My Network Places"};
            var ChildNode12 = new GettingStartedModel { Header = "Server"};
            var ChildNode13 = new GettingStartedModel { Header = "My Folders"};

            var ChildNode14 = new GettingStartedModel { Header = "My Computer"};
            var ChildNode15 = new GettingStartedModel { Header = "Music"};
            var ChildNode16 = new GettingStartedModel { Header = "Videos"};
            var ChildNode17 = new GettingStartedModel { Header = "Wallpaper.png"};
            var ChildNode18 = new GettingStartedModel { Header = "My Banner.png"};

            

            var ChildNode19 = new GettingStartedModel { Header = "Favourites"};
            var ChildNode20 = new GettingStartedModel { Header = "Image3.png"};
            var ChildNode21 = new GettingStartedModel { Header = "Image4.png"};
            var ChildNode22 = new GettingStartedModel { Header = "Image5.png"};

            var ChildNode23 = new GettingStartedModel { Header = "Image1.png"};
            var ChildNode24 = new GettingStartedModel { Header = "Image2.png"};

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
