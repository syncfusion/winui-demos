#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
    public class Stacking100ChartViewModel
    {
        public ObservableCollection<Stacking100ChartModel> CloudData { get; set; }
        public ObservableCollection<Stacking100ChartModel> EmissionData { get; set; }
        public ObservableCollection<Stacking100ChartModel> MonthlyExpense { get;set; }
        
        public Stacking100ChartViewModel()
        {
            //Column100 
            this.CloudData = new ObservableCollection<Stacking100ChartModel>()
            {
                new Stacking100ChartModel() { Cloud = "Microsoft", SoutheastAsia = 31, NorthAmerica = 37, Europe = 32, Others = 18 },
                new Stacking100ChartModel() { Cloud = "Amazon", SoutheastAsia = 21, NorthAmerica = 25, Europe = 18, Others = 12 },
                new Stacking100ChartModel() { Cloud = "Google", SoutheastAsia = 24, NorthAmerica = 25, Europe = 18, Others = 6 },
               new Stacking100ChartModel() { Cloud = "Alibaba", SoutheastAsia = 49, NorthAmerica = 4, Europe = 4, Others = 3 },
                new Stacking100ChartModel() { Cloud = "IBM", SoutheastAsia = 8, NorthAmerica = 28, Europe = 18, Others = 6 },
            };

            //Area100
            this.EmissionData = new ObservableCollection<Stacking100ChartModel>()
            {
                new Stacking100ChartModel() { Year = "2000", Peru = 20, Canada = 32, Ethiopia = 16, Mali = 24 },
                new Stacking100ChartModel() { Year = "2001", Peru = 13, Canada = 34, Ethiopia = 17, Mali = 32 },
                new Stacking100ChartModel() { Year = "2002", Peru = 14, Canada = 38, Ethiopia = 31, Mali = 27 },
                new Stacking100ChartModel() { Year = "2003", Peru = 17, Canada = 44, Ethiopia = 27, Mali = 34 },
                new Stacking100ChartModel() { Year = "2004", Peru = 16, Canada = 48, Ethiopia = 28, Mali = 43 },
                new Stacking100ChartModel() { Year = "2005", Peru = 23, Canada = 41, Ethiopia = 32, Mali = 45 },
                new Stacking100ChartModel() { Year = "2006", Peru = 23, Canada = 40, Ethiopia = 46, Mali = 51 },
                new Stacking100ChartModel() { Year = "2007", Peru = 27, Canada = 40, Ethiopia = 47, Mali = 76 },
                new Stacking100ChartModel() { Year = "2008", Peru = 27, Canada = 40, Ethiopia = 51, Mali = 85 },
                new Stacking100ChartModel() { Year = "2009", Peru = 32, Canada = 35, Ethiopia = 55, Mali = 86 },
                new Stacking100ChartModel() { Year = "2010", Peru = 40, Canada = 35, Ethiopia = 58, Mali = 87 },
            };

            //Line100
            this.MonthlyExpense = new ObservableCollection<Stacking100ChartModel>();
            MonthlyExpense.Add(new Stacking100ChartModel() { Name = "Food", Father = 55, Mother = 40, Son = 45, Daughter = 48 });
            MonthlyExpense.Add(new Stacking100ChartModel() { Name = "Transport", Father = 33, Mother = 45, Son = 54, Daughter = 28 });
            MonthlyExpense.Add(new Stacking100ChartModel() { Name = "Medical", Father = 43, Mother = 23, Son = 20, Daughter = 34 });
            MonthlyExpense.Add(new Stacking100ChartModel() { Name = "Clothes", Father = 32, Mother = 54, Son = 23, Daughter = 54 });
            MonthlyExpense.Add(new Stacking100ChartModel() { Name = "Books", Father = 56, Mother = 18, Son = 43, Daughter = 55 });
            MonthlyExpense.Add(new Stacking100ChartModel() { Name = "Others", Father = 23, Mother = 54, Son = 33, Daughter = 56 });
        }
    }
}
