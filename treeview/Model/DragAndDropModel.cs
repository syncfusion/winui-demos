#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Media.Imaging;
using Syncfusion.UI.Xaml.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace syncfusion.treeviewdemos.winui
{
    /// <summary>
    /// Reprsents the class <see cref="DragAndDropModel"/> that contains the data for <see cref="Syncfusion.UI.Xaml.TreeView.TreeViewItem"/>. 
    /// </summary>
    public class DragAndDropModel : NotificationObject
    {
        #region Fields
        /// <summary>
        /// Maintains the string for header.
        /// </summary>
        private string header = string.Empty;

        /// <summary>
        /// Represents the BitmapImage for images.
        /// </summary>
        private BitmapImage imageSource = null;

        /// <summary>
        /// Determines whether the node is isexpanded or not.
        /// </summary>
        private bool isexpanded = true;

        /// <summary>
        /// Represents the ObservableCollection with DranAndDropModel.
        /// </summary>
        private ObservableCollection<DragAndDropModel> childs = null;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="DragAndDropModel"/> class.
        /// </summary>
        public DragAndDropModel()
        {
            Childs = new ObservableCollection<DragAndDropModel>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the Header of the Item.
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
                this.RaisePropertyChanged("Header");
            }
        }
    
        /// <summary>
        /// Gets or sets the Image.
        /// </summary>
        public BitmapImage Image
        {
            get
            {
                return imageSource;
            }
            set
            {
                imageSource = value;
                this.RaisePropertyChanged("Image");
            }
        }
        
        /// <summary>
        /// Gets or sets the value that node is expanded or not.
        /// </summary>
        public bool IsExpanded
        {
            get
            {
                return isexpanded;
            }
            set
            {
                isexpanded = value;
                this.RaisePropertyChanged("IsExpanded");
            }
        }

        /// <summary>
        /// Gets or sets the collection for childs.
        /// </summary>
        public ObservableCollection<DragAndDropModel> Childs
        {
            get
            {
                return childs;
            }
            set
            {
                childs = value;
                this.RaisePropertyChanged("Childs");
            }
        }
        #endregion
    }
}
