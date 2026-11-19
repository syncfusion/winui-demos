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
