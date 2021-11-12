#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
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
#if !WinUI_Desktop
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
#endif

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TreeGrid
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CheckBoxSelection : Page, IDisposable
    {
        public CheckBoxSelection()
        {
            this.InitializeComponent();
            this.sfTreeGrid.Loaded += SfTreeGrid_Loaded;
            
        }

        private void SfTreeGrid_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            for (int i = 1; i < 20;)
            {
                var treeNode = sfTreeGrid.View.Nodes[i];
                i = i + 2;
                treeNode.SetCheckedState(true);
            }
        }

        public void Dispose()
        {
            this.Resources.Clear();
            if (this.sfTreeGrid != null)
            {
                this.sfTreeGrid.Dispose();
            }

            if (this.CkbRecurisveCheck != null)
                this.CkbRecurisveCheck = null;

            if (this.checkBox1 != null)
                this.checkBox1 = null;

            if (this.cmbSelectionMode != null)
                this.cmbSelectionMode = null;

        }

    }
}
