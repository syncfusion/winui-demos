#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using syncfusion.demoscommon.winui;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
using Microsoft.UI.Input;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DataGrid
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchPanel : Page, IDisposable
    {
        public SearchPanel()
        {
            Resources.MergedDictionaries.Add(SearchControlResource.Resource);
            this.InitializeComponent();
        }

        /// <summary>Invoked when the <see cref="UIElement.KeyDown"/> attached event raised in SfDataGrid.</summary>
        /// <param name="e"> The <see cref="Microsoft.UI.Xaml.Input.KeyRoutedEventArgs"/> that contains the event data.</param>
        /// <remarks>Handling the keydown operations of SfDataGrid.</remarks>
        private void sfDataGrid_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if ((e.Key == VirtualKey.F) && InputKeyboardSource.GetKeyStateForCurrentThread(VirtualKey.Control).HasFlag(CoreVirtualKeyStates.Down))
                searchControl.UpdateSearchControlVisiblity(true);
            else if (e.Key == VirtualKey.Escape)
                searchControl.UpdateSearchControlVisiblity(false);
        }

        /// <summary>
        /// Used to dispose the all unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Resources.Clear();
            if (this.sfDataGrid != null)
            {
                this.sfDataGrid.Dispose();
            }
            if(this.searchControl != null)
            {
                this.searchControl.Dispose();
                this.searchControl = null;
            }
        }   
    }
}
