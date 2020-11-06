#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Syncfusion.UI.Xaml.Data;
using Syncfusion.UI.Xaml.DataGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid
{
   
    public class GroupSummaryStyleSelector : StyleSelector
    {
        protected override Style SelectStyleCore(object item, DependencyObject container)
        {
            var res = new DataGrid.Summaries();
            var summaryRecordEntry = item as SummaryRecordEntry;
            if (summaryRecordEntry != null && summaryRecordEntry.SummaryRow.ShowSummaryInRow)
                return res.Resources["groupSummaryCell"] as Style;
            return res.Resources["normalgroupSummaryCell"] as Style;
        }
        
    }

    public class TableSummaryStyleSelector : StyleSelector
    {

        protected override Style SelectStyleCore(object item, DependencyObject container)
        {
            var res = new DataGrid.Summaries();
            var summaryRecordEntry = item as SummaryRecordEntry;
            if (summaryRecordEntry != null && summaryRecordEntry.SummaryRow.ShowSummaryInRow)
                return res.Resources["tableSummaryCell"] as Style;
            return res.Resources["normaltableSummaryCell"] as Style;
        }
        
    }

    internal class StatusConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="info">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;
            if ((string)value == "Active")
                return new SolidColorBrush(Colors.Green);
            else if ((string)value == "Inactive")
                return new SolidColorBrush(Colors.Red);
            return new SolidColorBrush(Colors.Black);
        }

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="info">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
