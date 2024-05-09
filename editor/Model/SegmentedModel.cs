#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syncfusion.EditorDemos.WinUI
{
    /// <summary>
    /// Reprsents the class <see cref="Segment"/> that contains the data for <see cref="Syncfusion.UI.Xaml.Editors.SegmentedItem"/>. 
    /// </summary>
    public class Segment : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// Maintains the string value for name.
        /// </summary>
        private string name;

        /// <summary>
        /// Maintains the string value for icon.
        /// </summary>
        public string icon;

        /// <summary>
        /// Maintains the brush for background.
        /// </summary>
        private Brush background;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value for Name.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        /// <summary>
        /// Gets or sets the brush for Background.
        /// </summary>
        public Brush Background
        {
            get { return background; }
            set { background = value; OnPropertyChanged("Background"); }
        }

        /// <summary>
        /// Gets or sets the icon for the SegmentedItem.
        /// </summary>
        public string Icon
        {
            get { return icon; }
            set { icon = value; OnPropertyChanged("Icon"); }
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        /// <summary>
        /// Method used to raise the property changed event.
        /// </summary>
        /// <param name="parameter">Represents the property name.</param>
        private void OnPropertyChanged(string parameter)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(parameter));
        }

        #endregion
    }
}
