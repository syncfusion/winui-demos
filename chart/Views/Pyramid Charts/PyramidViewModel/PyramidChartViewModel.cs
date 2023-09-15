#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace Syncfusion.ChartDemos.WinUI
{
    public class PyramidChartViewModel
    {
        public IList<PyramidChartModel> DefaultData
        {
            get; set;
        }

        public IList<PyramidChartModel> LegendData
        {
            get; set;
        }

        public IList<PyramidChartModel> TooltipData
        {
            get; set;
        }

        public PyramidChartViewModel()
        {
            //Default Pyramid
            this.DefaultData = new List<PyramidChartModel>();
            DefaultData.Add(new PyramidChartModel() { Category = "CD/Cassette", Percentage = 10 });
            DefaultData.Add(new PyramidChartModel() { Category = "Digital files", Percentage = 18 });
            DefaultData.Add(new PyramidChartModel() { Category = "Streaming", Percentage = 32 });
            DefaultData.Add(new PyramidChartModel() { Category = "Radio", Percentage = 36 });

            //Customized Legend
            this.LegendData = new List<PyramidChartModel>();
            LegendData.Add(new PyramidChartModel() { Category = "Retail", Percentage = 62, Value = 10 });
            LegendData.Add(new PyramidChartModel() { Category = "Manufacturing", Percentage = 85, Value = 14.25 });
            LegendData.Add(new PyramidChartModel() { Category = "Marketing", Percentage = 106, Value = 17.82 });
            LegendData.Add(new PyramidChartModel() { Category = "Shipping", Percentage = 144, Value = 24.51 });
            LegendData.Add(new PyramidChartModel() { Category = "R&D", Percentage = 193, Value = 32.71 });

            //Default Pyramid
            this.TooltipData = new List<PyramidChartModel>();
            TooltipData.Add(new PyramidChartModel
            {
                Category = "Passive Verbal",
                Percentage = 50,
                LearningCategories = new List<Learning>
               {
                    new Learning("Attending Lecture", new SolidColorBrush(Color.FromArgb(0xFF, 0x10, 0x60, 0xDC))),
                    new Learning("Reading Books",new SolidColorBrush(Color.FromArgb(0xFF, 0x10, 0x60, 0xDC))),
                    new Learning("Listening to Others", new SolidColorBrush(Color.FromArgb(0xFF, 0x10, 0x60, 0xDC))),
                    new Learning("Multimedia Listening",new SolidColorBrush(Color.FromArgb(0xFF, 0x10, 0x60, 0xDC))),
               }
            });

            TooltipData.Add(new PyramidChartModel
            {
                Category = "Discussion",
                Percentage = 50,
                LearningCategories = new List<Learning>
               {
                    new Learning("Attend Exhibits", new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0xB5, 0x53))),
                    new Learning("Group Discussion", new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0xB5, 0x53))),
                    new Learning("Watch a Demonstration", new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0xB5, 0x53))),
               }
            });

            TooltipData.Add(new PyramidChartModel
            {
                Category = "Practice",
                Percentage = 75,
                LearningCategories = new List<Learning>
               {
                    new Learning("Hands-on-Workshop", new SolidColorBrush(Color.FromArgb(0xFF, 0xDA, 0x69, 0x02))),
                    new Learning("Develop a Class Project", new SolidColorBrush(Color.FromArgb(0xFF, 0xDA, 0x69, 0x02))),
               }
            });

            TooltipData.Add(new PyramidChartModel
            {
                Category = "Teach Others",
                Percentage = 90,
                LearningCategories = new List<Learning>
               {
                    new Learning("Simulate Model", new SolidColorBrush(Color.FromArgb(0xFF, 0xC7, 0x19, 0x69))),
                    new Learning("Do the Real Thing", new SolidColorBrush(Color.FromArgb(0xFF, 0xC7, 0x19, 0x69))),
               }
            });
        }
    }

    public class Learning
    {
        public Brush Color { get; set; }
        public string Category { get; set; }
        
        public Learning(string category, Brush color)
        {
            Category = category;
            Color = color;
        }
    }
}
