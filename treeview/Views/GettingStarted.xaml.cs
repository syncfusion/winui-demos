#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Syncfusion.UI.Xaml.Core;
using Microsoft.UI.Xaml.Media.Imaging;
using System.Collections.ObjectModel;
using Syncfusion.UI.Xaml.TreeView;
using Syncfusion.TreeViewDemos.WinUI;

namespace Syncfusion.TreeViewDemos.WinUI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GettingStartedPage : Page, IDisposable
    {
        public GettingStartedPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Dispose all the allocated resources.
        /// </summary>
        public void Dispose()
        {
            // Release all managed resources
            if (this.treeView != null)
            {
                this.treeView.Dispose();
                this.treeView = null;
                this.DataContext = null;
            }
            if (this.unboundTreeView != null)
            {
                this.unboundTreeView.Dispose();								
                this.unboundTreeView = null;
            }
            if (this.showLinesCheckBox != null)
            {
                this.showLinesCheckBox = null;
            }
            if (this.allowEditingCheckbox != null)
            {
                this.allowEditingCheckbox = null;
            }
            if (this.fullRowSelectCheckBox != null)
            {
                this.fullRowSelectCheckBox = null;
            }
            if (this.showAnimationCheckBox != null)
            {
                this.showAnimationCheckBox = null;
            }
            if (this.expandNodeButton != null)
            {
                this.expandNodeButton = null;
            }
            if (this.collapseNodeButton != null)
            {
                this.collapseNodeButton = null;
            }
            if (this.selectionComboBox != null)
            {
                this.selectionComboBox = null;
            }
        }
    }
}
