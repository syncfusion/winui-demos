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

namespace Syncfusion.TreeViewDemos.WinUI
{
    /// <summary>
    /// Reprsents the class <see cref="GettingStartedModel"/> that contains the data for <see cref="Syncfusion.UI.Xaml.TreeView.TreeViewItem"/>. 
    /// </summary>
    public class GettingStartedModel : NotificationObject
    {
        #region Fields
        /// <summary>
        /// Maintains the string for header.
        /// </summary>
        private string header = string.Empty;

        /// <summary>
        /// Represents the ObservableCollection with DranAndDropModel.
        /// </summary>
        private ObservableCollection<GettingStartedModel> childs;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="DragAndDropModel"/> class.
        /// </summary>
        public GettingStartedModel()
        {
            Childs = new ObservableCollection<GettingStartedModel>();
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
                this.RaisePropertyChanged(nameof(Header));
            }
        }

        /// <summary>
        /// Gets or sets the collection for childs.
        /// </summary>
        public ObservableCollection<GettingStartedModel> Childs
        {
            get
            {
                return childs;
            }
            internal set
            {
                childs = value;
                this.RaisePropertyChanged(nameof(Childs));
            }
        }
        #endregion
    }
}
