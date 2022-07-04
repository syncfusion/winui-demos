#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Core;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Syncfusion.ChartDemos.WinUI
{
    public class TooltipViewModel
    {
        public TooltipViewModel()
        {
            this.DataPoints = new ObservableCollection<TooltipModel>();
            DateTime year = new DateTime(2005, 5, 1);

            DataPoints.Add(new TooltipModel() { Year = "2005", Germany = 21, England = 28 });
            DataPoints.Add(new TooltipModel() { Year = "2006", Germany = 24, England = 44 });
            DataPoints.Add(new TooltipModel() { Year = "2007", Germany = 36, England = 48 });
            DataPoints.Add(new TooltipModel() { Year = "2008", Germany = 38, England = 50 });
            DataPoints.Add(new TooltipModel() { Year = "2009", Germany = 54, England = 66 });
            DataPoints.Add(new TooltipModel() { Year = "2010", Germany = 57, England = 78 });
            DataPoints.Add(new TooltipModel() { Year = "2011", Germany = 70, England = 84 });
        }

        public ObservableCollection<TooltipModel> DataPoints
        {
            get;
        }
    }
}
