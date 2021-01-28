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
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Graphics.Printing.OptionDetails;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DataGrid
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Printing : Page, IDisposable
    {
        public Printing()
        {
            this.InitializeComponent();
            this.sfDataGrid.PrintTaskRequested += SfDataGrid_PrintTaskRequested;
        }

        private void SfDataGrid_PrintTaskRequested(object sender, Syncfusion.UI.Xaml.DataGrid.Print.DataGridPrintTaskRequestedEventArgs e)
        {
            e.PrintTask = e.Request.CreatePrintTask("DataGrid", sourceRequested =>
            {
                PrintTaskOptionDetails printDetailedOptions = PrintTaskOptionDetails.GetFromPrintTaskOptions(e.PrintTask.Options);
                IList<string> displayedOptions = printDetailedOptions.DisplayedOptions;
                displayedOptions.Add(Windows.Graphics.Printing.StandardPrintTaskOptions.CustomPageRanges);
                e.PrintTask.Options.PageRangeOptions.AllowCurrentPage = true;
                e.PrintTask.Options.PageRangeOptions.AllowAllPages = true;
                e.PrintTask.Options.PageRangeOptions.AllowCustomSetOfPages = true;
                sourceRequested.SetSource(e.PrintDocumentSource);
            });
        }

        private void OnPrintBtnClick(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            if (sfDataGrid != null)
                this.sfDataGrid.Print();
        }

        private void OnAllowFitColumnsChecked(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            if (sfDataGrid != null)
                this.sfDataGrid.PrintSettings.FitColumnsOnSinglePage = true;
        }

        private void OnAllowFitColumnsUnChecked(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            if (sfDataGrid != null)
                this.sfDataGrid.PrintSettings.FitColumnsOnSinglePage = false;
        }

        private void OnAllowRepeatHeaderChecked(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            if (sfDataGrid != null)
                this.sfDataGrid.PrintSettings.CanRepeatHeaders = true;
        }

        private void OnAllowRepeatHeaderUnChecked(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            if (sfDataGrid != null)
                this.sfDataGrid.PrintSettings.CanRepeatHeaders = false;
        }

        private void CanPrintStackedHeaderChecked(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            if (sfDataGrid != null)
                this.sfDataGrid.PrintSettings.CanPrintStackedHeaders = true;
        }

        private void CanPrintStackedHeaderUnChecked(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            if (sfDataGrid != null)
                this.sfDataGrid.PrintSettings.CanPrintStackedHeaders = false;
        }

        public void Dispose()
        {
            if (this.sfDataGrid != null)
            {
                this.sfDataGrid.Dispose();
                this.sfDataGrid = null;
                this.DataContext = null;
            }
        }        
    }
}
