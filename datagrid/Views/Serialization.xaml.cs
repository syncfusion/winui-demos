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
using Syncfusion.UI.Xaml.DataGrid;
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
using Windows.Storage;
using Syncfusion.UI.Xaml.DataGrid.Serialization;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DataGrid
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Serialization : Page, IDisposable
    {
        public Serialization()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Dispose of unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            serializebtn.Click -= OnSerializeDataGrid;
            deserializebtn.Click -= OnDeserializeDataGrid;
            this.Resources.Clear();
            if (this.sfDataGrid != null)
            {
                this.sfDataGrid.Dispose();
            }

            if (this.serializebtn != null)
                this.serializebtn = null;

            if (this.SerializeColumns != null)
                this.SerializeColumns = null;

            if (this.SerializeGrouping != null)
                this.SerializeGrouping = null;

            if (this.SerializeSorting != null)
                this.SerializeSorting = null;

            if (this.SerializeFiltering != null)
                this.SerializeFiltering = null;

            if (this.SerializeGroupSummaries != null)
                this.SerializeGroupSummaries = null;

            if (this.SerializeTableSummaries != null)
                this.SerializeTableSummaries = null;

            if (this.SerializeStackedHeaders != null)
                this.SerializeStackedHeaders = null;

            if (this.deserializebtn != null)
                this.deserializebtn = null;

            if (this.DeserializeColumns != null)
                this.DeserializeColumns = null;

            if (this.DeserializeGrouping != null)
                this.DeserializeGrouping = null;

            if (this.DeserializeSorting != null)
                this.DeserializeSorting = null;

            if (this.DeserializeFiltering != null)
                this.DeserializeFiltering = null;

            if (this.DeserializeGroupSummaries != null)
                this.DeserializeGroupSummaries = null;

            if (this.DeserializeTableSummaries != null)
                this.DeserializeTableSummaries = null;

            if (this.DeserializeStackedHeaders != null)
                this.DeserializeStackedHeaders = null;
        }       

        private async void OnDeserializeDataGrid(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            var folder = ApplicationData.Current.LocalFolder;
            try
            {
                var storageFile = await folder.GetFileAsync("DataGrid.xml");
                var options = new DeserializationOptions()
                {
                    DeserializeColumns = (bool)this.DeserializeColumns.IsChecked,
                    DeserializeFiltering = (bool)this.DeserializeFiltering.IsChecked,
                    DeserializeSorting = (bool)this.DeserializeSorting.IsChecked,
                    DeserializeGrouping = (bool)this.DeserializeGrouping.IsChecked,
                    DeserializeGroupSummaries = (bool)this.DeserializeGroupSummaries.IsChecked,
                    DeserializeTableSummaries = (bool)this.DeserializeTableSummaries.IsChecked,
                    DeserializeStackedHeaders = (bool)this.DeserializeStackedHeaders.IsChecked
                };
                this.sfDataGrid.Deserialize(storageFile, options);
            }
            catch (Exception)
            {

            }
        }

        private async void OnSerializeDataGrid(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            var folder = ApplicationData.Current.LocalFolder;
            try
            {
                var storageFile = await folder.CreateFileAsync("DataGrid.xml", CreationCollisionOption.ReplaceExisting);
                var options = new SerializationOptions()
                {
                    SerializeColumns = (bool)this.SerializeColumns.IsChecked,
                    SerializeFiltering = (bool)this.SerializeFiltering.IsChecked,
                    SerializeGrouping = (bool)this.SerializeGrouping.IsChecked,
                    SerializeSorting = (bool)this.SerializeSorting.IsChecked,
                    SerializeGroupSummaries = (bool)this.SerializeGroupSummaries.IsChecked,
                    SerializeTableSummaries = (bool)this.SerializeTableSummaries.IsChecked,
                    SerializeStackedHeaders = (bool)this.SerializeStackedHeaders.IsChecked
                };
                this.sfDataGrid.Serialize(storageFile, options);
            }
            catch (Exception)
            {

            }
        }
    }
}
