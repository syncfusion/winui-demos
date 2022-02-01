#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Syncfusion.UI.Xaml.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.treeviewdemos.winui
{
    /// <summary>
    /// Reprsents the class <see cref="Folder"/> that contains the data for <see cref="Syncfusion.UI.Xaml.TreeView.TreeViewItem"/>. 
    /// </summary>
    public class Folder : NotificationObject
    {
        #region Fields
        /// <summary>
        /// Maintains the string value for fileName.
        /// </summary>
        private string fileName;

        /// <summary>
        /// Holds the icon template for the TreeViewItem.
        /// </summary>
        private DataTemplate imageTemplate;
        
        /// <summary>
        /// Represents the ObservableCollection with File.
        /// </summary>
        private ObservableCollection<File> files;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Folder"/> class.
        /// </summary>
        public Folder()
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the collection for Files.
        /// </summary>
        public ObservableCollection<File> Files
        {
            get { return files; }
            internal set
            {
                files = value;
                RaisePropertyChanged(nameof(Files));
            }
        }

        /// <summary>
        /// Gets or sets the value for File Name.
        /// </summary>
        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
                RaisePropertyChanged(nameof(FileName));
            }
        }

        /// <summary>
        /// Gets or sets the icon template for the TreeViewItem.
        /// </summary>
        public DataTemplate ImageTemplate
        {
            get { return imageTemplate; }
            set { imageTemplate = value; }
        }
        #endregion
    }

    /// <summary>
    /// Reprsents the class <see cref="File"/> that contains the data for <see cref="Syncfusion.UI.Xaml.TreeView.TreeViewItem"/>. 
    /// </summary>
    public class File : NotificationObject
    {
        #region Fields
        /// <summary>
        /// Maintains the string value for fileName.
        /// </summary>
        private string fileName;

        /// <summary>
        /// Holds the icon template for the TreeViewItem.
        /// </summary>
        private DataTemplate imageTemplate;

        /// <summary>
        /// Represents the ObservableCollection with SubFile.
        /// </summary>
        private ObservableCollection<SubFile> subFiles;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="File"/> class.
        /// </summary>
        public File()
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the collection for SubFiles.
        /// </summary>
        public ObservableCollection<SubFile> SubFiles
        {
            get { return subFiles; }
            internal set
            {
                subFiles = value;
                RaisePropertyChanged(nameof(SubFiles));
            }
        }

        /// <summary>
        /// Gets or sets the value for File Name.
        /// </summary>
        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
                RaisePropertyChanged(nameof(FileName));
            }
        }

        /// <summary>
        /// Gets or sets the icon template for the TreeViewItem.
        /// </summary>
        public DataTemplate ImageTemplate
        {
            get { return imageTemplate; }
            set { imageTemplate = value; }
        }
        #endregion    
    }

    /// <summary>
    /// Reprsents the class <see cref="SubFile"/> that contains the data for <see cref="Syncfusion.UI.Xaml.TreeView.TreeViewItem"/>. 
    /// </summary>
    public class SubFile : NotificationObject
    {
        #region Fields
        /// <summary>
        /// Maintains the string value for fileName.
        /// </summary>
        private string fileName;

        /// <summary>
        /// Holds the icon template for the TreeViewItem.
        /// </summary>
        private DataTemplate imageTemplate;        
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SubFile"/> class.
        /// </summary>
        public SubFile()
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the value for File Name.
        /// </summary>
        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
                RaisePropertyChanged(nameof(FileName));
            }
        }

        /// <summary>
        /// Gets or sets the icon template for the TreeViewItem.
        /// </summary>
        public DataTemplate ImageTemplate
        {
            get { return imageTemplate; }
            set { imageTemplate = value; }
        }
        #endregion
    }

}
