#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Core;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace syncfusion.treeviewdemos.winui
{
    /// <summary>
    /// Reprsents the class <see cref="PerformanceModel"/> that contains the data for <see cref="Syncfusion.UI.Xaml.TreeView.TreeViewItem"/>. 
    /// </summary>
    public class PerformanceModel : NotificationObject
    {
        #region Fields
        /// <summary>
        /// Maintains the collection with PerformanceModel.
        /// </summary>
        private ObservableCollection<PerformanceModel> subItems;

        /// <summary>
        /// Maintains the string value for Header.
        /// </summary>
        private string header;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PerformanceModel"/> class.
        /// </summary>
        public PerformanceModel()
        {
            subItems = new ObservableCollection<PerformanceModel>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the collection for subItems.
        /// </summary>
        public ObservableCollection<PerformanceModel> SubItems
        {
            get
            {
                return subItems;
            }

            internal set
            {
                subItems = value;
                RaisePropertyChanged(nameof(SubItems));
            }
        }
       
        /// <summary>
        /// Gets or sets a value indicating the Header of the TreeViewItemAdv.
        /// </summary>        
        public string Header
        {
            get
            {
                return header;
            }

            set
            {
                header = value;
                this.RaisePropertyChanged(nameof(Header));
            }
        }
        #endregion
    }
}
