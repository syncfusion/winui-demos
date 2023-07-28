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
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.DataGrid;
using Syncfusion.UI.Xaml.Data;
using Syncfusion.UI.Xaml.DataGrid.Helpers;
using Syncfusion.UI.Xaml.Grids;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DataGrid
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UnboundRows : Page , IDisposable
    {
        // totalSales used to store sumamry of each column.
        Dictionary<string, double> totalSales;
        // totalSelectedSales used to store selected rows.
        Dictionary<string, double> totalSelectedSales;
        public UnboundRows()
        {
            this.InitializeComponent();

            totalSales = new Dictionary<string, double>();
            totalSelectedSales = new Dictionary<string, double>();

            // Hooks event here.
            this.sfDataGrid.Loaded += SfDataGrid_Loaded;
            this.sfDataGrid.QueryRowHeight += SfDataGrid_QueryRowHeight;
            this.sfDataGrid.QueryUnboundRow += SfDataGrid_QueryUnboundRow;
            this.sfDataGrid.SelectionChanged += SfDataGrid_SelectionChanged;
            this.sfDataGrid.CurrentCellEndEdit += SfDataGrid_CurrentCellEndEdit;
        }

        private void SfDataGrid_CurrentCellEndEdit(object sender, Syncfusion.UI.Xaml.DataGrid.CurrentCellEndEditEventArgs e)
        {
            // Updates the totals with edited values.
            foreach (GridColumn column in this.sfDataGrid.Columns)
            {
                if(column.MappingName != "Year")
                    totalSales[column.MappingName] = GetSummaryValue(column.MappingName);
            }

            foreach (GridColumn column in this.sfDataGrid.Columns)
            {
                if(column.MappingName != "Year")
                    totalSelectedSales[column.MappingName] = GetSummaryValue(column.MappingName, false);
            }

            // Refresh unboundRow after complete editing.
            this.sfDataGrid.InValidateUnboundRow(this.sfDataGrid.UnboundRows[0]);
            this.sfDataGrid.InValidateUnboundRow(this.sfDataGrid.UnboundRows[1]);
            this.sfDataGrid.InValidateUnboundRow(this.sfDataGrid.UnboundRows[2]);

            var visualContainer = this.sfDataGrid.GetType().GetProperty("VisualContainer", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(this.sfDataGrid) as VisualContainer;
            if (visualContainer != null)
                visualContainer.InvalidateMeasureInfo();
        }

        private void SfDataGrid_SelectionChanged(object sender, GridSelectionChangedEventArgs e)
        {
            // Populate selected rows summary values.
            foreach (GridColumn column in this.sfDataGrid.Columns)
            {
                if(column.MappingName != "Year" )
                    totalSelectedSales[column.MappingName] = GetSummaryValue(column.MappingName, false);
            }

            // Refresh the UnBound rows.
            this.sfDataGrid.InValidateUnboundRow(this.sfDataGrid.UnboundRows[1]);
            this.sfDataGrid.InValidateUnboundRow(this.sfDataGrid.UnboundRows[2]);

            var visualContainer = this.sfDataGrid.GetType().GetProperty("VisualContainer", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(this.sfDataGrid) as VisualContainer;
            if (visualContainer != null)
                visualContainer.InvalidateMeasureInfo();
        }

        private void SfDataGrid_QueryUnboundRow(object sender, Syncfusion.UI.Xaml.DataGrid.GridUnboundRowEventsArgs e)
        {
            if (!(totalSales.ContainsKey(e.Column.MappingName)))
                return;

            if (e.UnboundAction == UnboundActions.QueryData)
            {
                if (e.RowColumnIndex.RowIndex == 1)
                {
                    if (e.RowColumnIndex.ColumnIndex == 0)
                    {
                        e.Value = "Total Sales By Month";
                        e.CellTemplate = this.Resources["UnboundCellTemplate"] as DataTemplate;
                    }
                    else
                    {
                        e.Value = totalSales[e.Column.MappingName];
                        e.CellTemplate = this.Resources["UnboundRowCellTemplate"] as DataTemplate;
                    }
                }
                else if (e.GridUnboundRow.UnboundRowIndex == 0 && e.GridUnboundRow.Position == UnboundRowsPosition.Bottom && e.GridUnboundRow.ShowBelowSummary == true)
                {
                    if (e.RowColumnIndex.ColumnIndex == 0)
                    {
                        e.Value = "Summary of Selected Rows";
                        e.CellTemplate = this.Resources["UnboundCellTemplate"] as DataTemplate;
                    }
                    else
                    {
                        if (!(totalSelectedSales.ContainsKey(e.Column.MappingName)))
                            return;

                        e.Value = totalSelectedSales[e.Column.MappingName];
                        e.CellTemplate = this.Resources["UnboundRowCellTemplate"] as DataTemplate;
                    }
                }

                else if (e.GridUnboundRow.UnboundRowIndex == 1 && e.GridUnboundRow.Position == UnboundRowsPosition.Bottom && e.GridUnboundRow.ShowBelowSummary == true)
                {
                    int count = this.sfDataGrid.SelectedItems.Count;
                    if (e.RowColumnIndex.ColumnIndex == 0)
                    {
                        e.Value = "Average of Selected Rows";
                        e.CellTemplate = this.Resources["UnboundCellTemplate"] as DataTemplate;
                    }
                    else
                    {
                        if (!(totalSelectedSales.ContainsKey(e.Column.MappingName)))
                            return;

                        e.Value = (totalSelectedSales[e.Column.MappingName] / count);
                        e.Value = double.IsNaN((double)e.Value) ? 0.0 : e.Value;
                        e.CellTemplate = this.Resources["UnboundRowCellTemplate"] as DataTemplate;

                        if (e.RowColumnIndex.ColumnIndex > 7)
                            e.CellTemplate = null;
                    }
                }
                e.Handled = true;
            }
        }

        private void SfDataGrid_QueryRowHeight(object sender, Syncfusion.UI.Xaml.DataGrid.QueryRowHeightEventArgs e)
        {
            if (e.RowIndex == 0)
            {
                e.Height = 40;
                e.Handled = true;
            }
            // Which customize the height of UnBoundRow.
            else if (this.sfDataGrid.IsUnboundRow(e.RowIndex))
            {
                e.Height = 45;
                e.Handled = true;
            }
            else
            {
                e.Height = this.sfDataGrid.RowHeight;
                e.Handled = true;
            }
        }

        private void SfDataGrid_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            // populate the totalSales by summary value.
            foreach (GridColumn column in this.sfDataGrid.Columns)
            {
                if(column.MappingName != "Year")
                    totalSales[column.MappingName] = GetSummaryValue(column.MappingName);
            }
            // Refresh the UnboundRows.
            this.sfDataGrid.InValidateUnboundRow(this.sfDataGrid.UnboundRows[0]);
            var visualContainer = this.sfDataGrid.GetType().GetProperty("VisualContainer", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(this.sfDataGrid) as VisualContainer;
            if (visualContainer != null)
                visualContainer.InvalidateMeasureInfo();

            var collection = this.sfDataGrid.DataContext as SalesViewModel;
            foreach (Sales sales in collection.YearlySales.Skip(3).Take(3))
                this.sfDataGrid.SelectedItems.Add(sales);
        }

        // Calculates summary value based on column names.
        double GetSummaryValue(string column, bool totalSummary = true)
        {
            double summary = 0.0;
            var view = this.sfDataGrid.View;
            if (this.sfDataGrid.SelectedItems.Count != 0 && !totalSummary)
            {
                foreach (var data in this.sfDataGrid.SelectedItems)
                {
                    if (column.Equals("QS1"))
                        summary += (data as Sales).QS1;
                    else if (column.Equals("QS2"))
                        summary += (data as Sales).QS2;
                    else if (column.Equals("QS3"))
                        summary += (data as Sales).QS3;
                    else if (column.Equals("QS4"))
                        summary += (data as Sales).QS4;
                    else if (column.Equals("Total"))
                        summary += (data as Sales).Total;
                }
            }
            else if (totalSummary)
            {
                foreach (var data in view.Records)
                {
                    if (column.Equals("QS1"))
                        summary += ((data as RecordEntry).Data as Sales).QS1;
                    else if (column.Equals("QS2"))
                        summary += ((data as RecordEntry).Data as Sales).QS2;
                    else if (column.Equals("QS3"))
                        summary += ((data as RecordEntry).Data as Sales).QS3;
                    else if (column.Equals("QS4"))
                        summary += ((data as RecordEntry).Data as Sales).QS4;
                    else if (column.Equals("Total"))
                        summary += ((data as RecordEntry).Data as Sales).Total;
                }
            }
            return summary;
        }

        public void Dispose()
        {
            this.Resources.Clear();
            this.sfDataGrid.Loaded -= SfDataGrid_Loaded;
            this.sfDataGrid.CurrentCellEndEdit -= SfDataGrid_CurrentCellEndEdit;
            this.sfDataGrid.QueryRowHeight -= SfDataGrid_QueryRowHeight;
            this.sfDataGrid.QueryUnboundRow -= SfDataGrid_QueryUnboundRow;
            this.sfDataGrid.SelectionChanged -= SfDataGrid_SelectionChanged;
            if (this.sfDataGrid != null)
            {
                this.sfDataGrid.Dispose();
            }
        }
        
    }
}
