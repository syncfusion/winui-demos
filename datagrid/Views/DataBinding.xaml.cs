#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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

namespace DataGrid
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DataBinding : Page, IDisposable
    {
        ListBinding listBinding;
        ObservableCollectionBinding observableCollectionBinding;
        DynamicObjectsBinding dynamicObjectsBinding;
        public DataBinding()
        {
            this.InitializeComponent();
            observableCollectionBinding = dataBindArea.Content as ObservableCollectionBinding;
            listBinding = new ListBinding();
            dynamicObjectsBinding = new DynamicObjectsBinding();
            this.DataContext = new DataBindingViewModel();
            this.dataBindingComboBox.SelectionChanged += OnSelectionChanged;
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.DispatcherQueue.TryEnqueue
             (()=> 
             {
                 if (dataBindArea != null)
                 {
                     if (!(dataBindArea.Content is ListBinding) && ((ComboBox)sender).SelectedIndex == 0)
                         dataBindArea.Content = listBinding;
                     else if (!(dataBindArea.Content is ObservableCollectionBinding) && ((ComboBox)sender).SelectedIndex == 1)
                         dataBindArea.Content = observableCollectionBinding;
                     else if (!(dataBindArea.Content is DynamicObjectsBinding) && ((ComboBox)sender).SelectedIndex == 2)
                         dataBindArea.Content = dynamicObjectsBinding;
                 }
             });
        }

        /// <summary>
        /// Dispose of unmanaged resources.
        /// </summary>
        public  void Dispose()
        {
            this.listBinding = null;
            this.observableCollectionBinding = null;
            this.dynamicObjectsBinding = null;
            this.Resources.Clear();
            this.dataBindingComboBox.SelectionChanged -= OnSelectionChanged;
            if (dataBindArea.Content is ListBinding)
            {
                (dataBindArea.Content as ListBinding).Dispose();
                ((dataBindArea.Content as ListBinding).Content as Grid).Children.Clear();
            }
            else if(dataBindArea.Content is ObservableCollectionBinding)
            {
                (dataBindArea.Content as ObservableCollectionBinding).Dispose();
                ((dataBindArea.Content as ObservableCollectionBinding).Content as Grid).Children.Clear();
            }
            else
            {
                (dataBindArea.Content as DynamicObjectsBinding).Dispose();
                ((dataBindArea.Content as DynamicObjectsBinding).Content as Grid).Children.Clear();
            }
            dataBindArea = null;
            if (this.dataBindingComboBox != null)
                this.dataBindingComboBox = null;
        }
    }
}
