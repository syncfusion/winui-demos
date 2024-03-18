#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
using Syncfusion.UI.Xaml.Data;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DataGrid
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomGrouping : Page, IDisposable
    {
        public CustomGrouping()
        {
            this.InitializeComponent();

            this.sfDataGrid.Loaded += SfDataGrid_Loaded;
        }
        private void SfDataGrid_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            var group = sfDataGrid.View.CollectionGroups[0] as Group;
            var group2 = sfDataGrid.View.CollectionGroups[2] as Group;
            this.sfDataGrid.ExpandGroup(group);
            this.sfDataGrid.ExpandGroup(group2);
        }

        public void Dispose()
        {
            this.Resources.Clear();
            if (this.sfDataGrid != null)
            {
                this.sfDataGrid.Loaded -= SfDataGrid_Loaded;
                this.sfDataGrid.Dispose();
            }
        }
    }
}
