#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.TreeGridDemos.WinUI;
using Syncfusion.UI.Xaml.DataGrid;
using Syncfusion.UI.Xaml.TreeGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeGrid;

namespace TreeGrid
{
    public class CellStyleSelector : StyleSelector
    {
        internal ConditionalStyling conditionalStyling;

        protected override Style SelectStyleCore(object item, DependencyObject container)
        { 
            var data = item as Employee;

            if (conditionalStyling == null)
                conditionalStyling = (ConditionalStyling)Activator.CreateInstance(typeof(ConditionalStyling));

           if(data!=null)
           {
                var mappingName = (container as TreeGridCell).ColumnBase.TreeGridColumn.MappingName;

                if (mappingName == "Salary")
                {
                    if (data.Salary < 100000 && data.Salary > 50000)
                        return conditionalStyling.Resources["darkRedCellStyle"] as Style;
                    else if (data.Salary < 50000 && data.Salary > 10000)
                        return conditionalStyling.Resources["redCellStyle"] as Style;
                    else
                        return conditionalStyling.Resources["lightRedCellStyle"] as Style;
                } 
                else if (mappingName == "Title")
                {
                    if (data.Title == "Engineering Manager" || data.Title == "Production Control Manager" || data.Title == "Recruiter" || data.Title == "Information Services Manager" || data.Title == "Master Scheduler")
                        return conditionalStyling.Resources["darkVioletCellStyle"] as Style;
                    else if (data.Title == "Network Administrator" || data.Title == "Marketing Specialist" || data.Title == "Quality Assurance Supervisor" || data.Title == "Maintenance Supervisor")
                        return conditionalStyling.Resources["violetCellStyle"] as Style;
                    else
                        return conditionalStyling.Resources["lightVioletCellStyle"] as Style;
                }
           } 
           return base.SelectStyleCore(item, container);
        }
    } 
}
