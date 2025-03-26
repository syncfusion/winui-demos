#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using DataGrid;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.DataGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid
{
    public class CustomCellStyleSelector : StyleSelector
    {
        internal Conditionalstyling conditionalStyling;
        protected override Style SelectStyleCore(object item, DependencyObject container)
        {
            var data = item as Sales;

            if (conditionalStyling == null)
                conditionalStyling = (Conditionalstyling)Activator.CreateInstance(typeof(Conditionalstyling));

            if (data != null)
            {
                var mappingName = (container as GridCell).ColumnBase.GridColumn.MappingName;

                if (mappingName == "QS1")
                    return SelectStyle(data.QS1);
                else if (mappingName == "QS2")
                    return SelectStyle(data.QS2);
                else if (mappingName == "QS3")
                    return SelectStyle(data.QS3);
                else if (mappingName == "QS4")
                    return SelectStyle(data.QS4);
            }
            return base.SelectStyleCore(item, container);
        }

        private Style SelectStyle(double value)
        {
            if (value < 1000)
                return conditionalStyling.Resources["darkRedCellStyle"] as Style;
            else if (value >= 1000 && value < 2000)
                return conditionalStyling.Resources["redCellStyle"] as Style;
            else if (value >= 2000 && value < 3000)
                return conditionalStyling.Resources["lightRedCellStyle"] as Style;
            else if (value >= 3000 && value < 4000)
                return conditionalStyling.Resources["darkYellowCellStyle"] as Style;
            else if (value >= 4000 && value < 5000)
                return conditionalStyling.Resources["yellowCellStyle"] as Style;
            else if (value >= 5000 && value < 6000)
                return conditionalStyling.Resources["lightYellowCellStyle"] as Style;
            else if (value >= 6000 && value < 7000)
                return conditionalStyling.Resources["darkVioletCellStyle"] as Style;
            else if (value >= 7000 && value < 8000)
                return conditionalStyling.Resources["violetCellStyle"] as Style;
            else if (value >= 8000 && value < 9000)
                return conditionalStyling.Resources["lightVioletCellStyle"] as Style;
            else if (value >= 9000 && value < 10000)
                return conditionalStyling.Resources["greenCellStyle"] as Style;
            else 
                return conditionalStyling.Resources["lightGreenCellStyle"] as Style; 
        }
    }
}