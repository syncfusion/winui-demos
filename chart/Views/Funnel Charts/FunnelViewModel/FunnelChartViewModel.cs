#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;

namespace Syncfusion.ChartDemos.WinUI
{
    public class FunnelChartViewModel : IDisposable
    {
        public ObservableCollection<FunnelChartModel> DefaultData
        {
            get;
            set;
        }

        public ObservableCollection<FunnelChartModel> LegendData
        {
            get;
            set;
        } 
        public ObservableCollection<FunnelChartModel> TooltipData
        {
            get;
            set;
        }
        public FunnelChartViewModel()
        {
            //Default funnel
            this.DefaultData = new ObservableCollection<FunnelChartModel>();
            DefaultData.Add(new FunnelChartModel() { Category = "Renewed", Percentage = 18 });
            DefaultData.Add(new FunnelChartModel() { Category = "Subscribed", Percentage = 34 });
            DefaultData.Add(new FunnelChartModel() { Category = "Contacted Support", Percentage = 52 });
            DefaultData.Add(new FunnelChartModel() { Category = "Downloaded a Trial", Percentage = 68 });
            DefaultData.Add(new FunnelChartModel() { Category = "Visited the Website", Percentage = 100 });

            //Legend Customization
            this.LegendData = new ObservableCollection<FunnelChartModel>();
            LegendData.Add(new FunnelChartModel() { Category = "Candidates Recruited", Percentage = 150,Value=30 });
            LegendData.Add(new FunnelChartModel() { Category = "HR Interview", Percentage = 220,Value=44 });
            LegendData.Add(new FunnelChartModel() { Category = "Technical Interview", Percentage = 341,Value=68.2 });
            LegendData.Add(new FunnelChartModel() { Category = "Aptitude Test", Percentage = 446,Value= 89.2 });
            LegendData.Add(new FunnelChartModel() { Category = "Candidates Applied", Percentage = 500,Value=100 });

            //Tooltip Customization 
            this.TooltipData = new ObservableCollection<FunnelChartModel>();
            TooltipData.Add(new FunnelChartModel() { Category = "Closed Deals", Percentage = 80, PercentageValue = "80% of 100" });
            TooltipData.Add(new FunnelChartModel() { Category = "Negotiations", Percentage = 100, PercentageValue = "67% of 150" });
            TooltipData.Add(new FunnelChartModel() { Category = "Proposal", Percentage = 150, PercentageValue = "75% of 200" });
            TooltipData.Add(new FunnelChartModel() { Category = "Needs Analysis", Percentage =  200 , PercentageValue = "50% of 400" });
            TooltipData.Add(new FunnelChartModel() { Category = "Qualified Leads", Percentage = 400,PercentageValue= "80% of 500" });
            TooltipData.Add(new FunnelChartModel() { Category = "Lead Generation", Percentage = 500,PercentageValue= "100%" });

        }

        public void Dispose()
        {
            if(DefaultData != null)
                DefaultData.Clear();

            if(LegendData != null)
                LegendData.Clear();

            if(TooltipData != null) 
                TooltipData.Clear();
        }
    }
}
