
using Syncfusion.UI.Xaml.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Syncfusion.TreeViewDemos.WinUI
{
    /// <summary>
    /// Reprsents the class <see cref="LoadOnDemandModel"/> that contains the data for <see cref="Syncfusion.UI.Xaml.TreeView.TreeViewItem"/>. 
    /// </summary>
    public class LoadOnDemandModel : NotificationObject
    {
        #region Fields
        /// <summary>
        /// Maintains the string value for itemName.
        /// </summary>
        private string itemName;

        /// <summary>
        /// Maintains the int value for ID
        /// </summary>
        private int id;

        /// <summary>
        /// Determines whether the root nodes has childs or not.
        /// </summary>
        private bool hasChildNodes;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the value for item name.
        /// </summary>
        public string ItemName
        {
            get { return itemName; }
            set
            {
                itemName = value;
                RaisePropertyChanged(nameof(ItemName));
            }
        }

        /// <summary>
        /// Gets or sets the value for ID.
        /// </summary>
        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                RaisePropertyChanged(nameof(ID));
            }
        }

        /// <summary>
        /// Gets or sets the value that node has childs or not.
        /// </summary>
        public bool HasChildNodes
        {
            get { return hasChildNodes; }
            set
            {
                hasChildNodes = value;
                RaisePropertyChanged(nameof(HasChildNodes));
            }
        }
        #endregion
    }
}
