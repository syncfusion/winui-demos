#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syncfusion.ChartDemos.WinUI
{
    public class ChartAxisViewModel
    {
        public ObservableCollection<ChartAxisModel> CategoryAxisData { get; }
        public ObservableCollection<ChartAxisModel> NumericAxisData { get; }
        public ChartAxisViewModel() 
        {
            // Category Axis
            this.CategoryAxisData = new ObservableCollection<ChartAxisModel>();
            CategoryAxisData.Add(new ChartAxisModel() { Name = "Mexico", Value = 60 });
            CategoryAxisData.Add(new ChartAxisModel() { Name = "Japan", Value = 93 });
            CategoryAxisData.Add(new ChartAxisModel() { Name = "France", Value = 79 });
            CategoryAxisData.Add(new ChartAxisModel() { Name = "China", Value = 53 });
            CategoryAxisData.Add(new ChartAxisModel() { Name = "Sweden", Value = 90 });

            //Numeric Axis
            this.NumericAxisData = new ObservableCollection<ChartAxisModel>();
            NumericAxisData.Add(new ChartAxisModel() { Name = "1", IndiaValue = 240,AustraliaValue= 236 });
            NumericAxisData.Add(new ChartAxisModel() { Name = "2", IndiaValue = 250, AustraliaValue = 242 });
            NumericAxisData.Add(new ChartAxisModel() { Name = "3", IndiaValue = 281, AustraliaValue = 313 });
            NumericAxisData.Add(new ChartAxisModel() { Name = "4", IndiaValue = 358, AustraliaValue = 359 });
            NumericAxisData.Add(new ChartAxisModel() { Name = "5", IndiaValue = 237, AustraliaValue = 272 });

        }
    }
}
