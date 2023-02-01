#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;

namespace Syncfusion.TreeViewDemos.WinUI
{
    public class EnumToItemsSourceConverter : ObservableCollection<object>
    {
        private Type enumType;

        public Type EnumType
        {
            get
            {
                return enumType;
            }
            set
            {
                if (enumType != value)
                {
                    enumType = value;
                    UpdateItems();
                }
            }
        }

        public void UpdateItems()
        {
            this.Clear(); ;
            foreach (var value in Enum.GetValues(EnumType))
            {
                this.Add(value);
            }
        }
    }
}
