#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TreeGrid
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OnDemandLoading : Page, IDisposable
    {
        EmployeeViewModel viewModel;
        public OnDemandLoading()
        {
            this.InitializeComponent();
            this.viewModel = this.DataContext as EmployeeViewModel;
            this.sfTreeGrid.Loaded += SfTreeGrid_Loaded;
            this.sfTreeGrid.Unloaded += SfTreeGrid_Unloaded;
        }

        private void SfTreeGrid_Unloaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            this.sfTreeGrid.RequestTreeItems -= treeGrid_RequestChildSource;
            this.sfTreeGrid.RepopulateTree();
        }

        private void SfTreeGrid_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            this.sfTreeGrid.RequestTreeItems += treeGrid_RequestChildSource;
            this.sfTreeGrid.RepopulateTree();
        }

        private void treeGrid_RequestChildSource(object sender, Syncfusion.UI.Xaml.TreeGrid.TreeGridRequestTreeItemsEventArgs e)
        {
            if (e.ParentItem == null)
            {
                //get the root list - get all employees who have no boss 
                e.ChildItems = viewModel.Employees.Where(x => x.ReportsTo == -1); //get all employees whose boss's id is -1 (no boss)
            }
            else //if ParentItem not null, then set args.ChildList to the child items for the given ParentItem.
            {   //get the children of the parent object
                Employee emp = e.ParentItem as Employee;
                if (emp != null)
                {
                    //get all employees that report to the parent employee
                    e.ChildItems = viewModel.GetReportees(emp.ID);
                }
            }
        }        

        public void Dispose()
        {
            this.Resources.Clear();
            this.sfTreeGrid.RequestTreeItems -= treeGrid_RequestChildSource;
            this.sfTreeGrid.Loaded -= SfTreeGrid_Loaded;
            this.sfTreeGrid.Unloaded -= SfTreeGrid_Unloaded;
            this.sfTreeGrid.Dispose();           

            if (this.btnExpand != null)
                this.btnExpand = null;

            if(this.btnCollapse != null)
                this.btnCollapse = null;
        }
    }
}
