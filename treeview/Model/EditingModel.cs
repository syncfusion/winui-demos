#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Syncfusion.TreeViewDemos.WinUI
{
    public class EditingModel : INotifyPropertyChanged, IEditableObject
    {
        #region Fields

        private string name;
        internal EditingModel backUpData;
        private EditingModel currentData;

        private string header = string.Empty;
        private bool isexpanded = true;
        private DataTemplate imageTemplate;
        private ObservableCollection<EditingModel> childs = null;

        #endregion

        #region Constructor

        public EditingModel()
        {
            
        }

        public EditingModel(string name):base()
        {
            Childs = new ObservableCollection<EditingModel>();
            this.currentData = new EditingModel();
            this.currentData.name = name;            
        }

        #endregion

        #region Properties
        public string Header
        {
            get
            {               
                return currentData.name;
            }
            set
            {
                currentData.name = value;
                this.RaisePropertyChanged("Header");
            }
        }

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
        
        public DataTemplate ImageTemplate
        {
            get { return imageTemplate; }
            set { imageTemplate = value; }
        }

        public ObservableCollection<EditingModel> Childs
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

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string _PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_PropertyName));                
            }
        }

        #endregion

        #region IEditableObject

        public void BeginEdit()
        {
            backUpData = new EditingModel();
            backUpData.name = this.currentData.name;
        }
        
        public void EndEdit()
        {
            
        }

        public void CancelEdit()
        {
            this.currentData = backUpData;
        }
        
        #endregion
    }
}
