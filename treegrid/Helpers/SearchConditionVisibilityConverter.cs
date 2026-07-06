using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeGrid
{
    public class SearchConditionVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var index = value as int?;
            string text = parameter.ToString();
            if (text.Equals("NumericComboBox"))
            {
                if (index == 3 || index == 6)
                    return Visibility.Visible;
            }
            else if (text.Equals("StringComboBox"))
            {
                if (index == 1 || index == 2 || index == 4 || index == 5)
                    return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
