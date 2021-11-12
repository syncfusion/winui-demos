#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.chartdemos.winui
{
    public class PyramidChartViewModel
    {
        public PyramidChartViewModel()
        {
            this.Data = new List<PyramidChartModel>();


            Data.Add(new PyramidChartModel() { Category = "Avacado", Percentage = 25d });
            Data.Add(new PyramidChartModel() { Category = "Mushrooms", Percentage = 14d });
            Data.Add(new PyramidChartModel() { Category = "Black beans", Percentage = 16d });
            Data.Add(new PyramidChartModel() { Category = "Soybeans", Percentage = 13d });
            Data.Add(new PyramidChartModel() { Category = "Almonds", Percentage = 21d });
            Data.Add(new PyramidChartModel() { Category = "Walnuts", Percentage = 15d });
            Data.Add(new PyramidChartModel() { Category = "Others", Percentage = 18d });
        }

        public IList<PyramidChartModel> Data
        {
            get;
            set;
        }
    }
}
