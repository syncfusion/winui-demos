#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
    public class BubbleChartViewModel
    {
        public ObservableCollection<BubbleChartModel> GDPGrowthCollection { get; set; }
        public ObservableCollection<BubbleChartModel> ActionData { get; set; }
        public ObservableCollection<BubbleChartModel> HorrorData { get; set; }
        public ObservableCollection<BubbleChartModel> ScienceFictionData { get; set; }
        public ObservableCollection<BubbleChartModel> ThrillerData { get; set; }
        public BubbleChartViewModel()
        {
            //Default Bubble
            GDPGrowthCollection = new ObservableCollection<BubbleChartModel>()
        {
         new BubbleChartModel("China",96.8,15134,1.41),
         new BubbleChartModel("India",74.3,6518.8,1.36),
         new BubbleChartModel( "Indonesia", 95.6, 11371.7, 0.26),
         new BubbleChartModel( "Italy", 99.1, 42045.92, 0.05),
         new BubbleChartModel( "Malaysia", 94.8, 27577.37, 0.03),
         new BubbleChartModel( "Romania", 98.8, 28523.45, 0.01),
         new BubbleChartModel( "Russia", 99.7, 26656.41, 0.14),
         new BubbleChartModel( "Mexico", 95.3, 19928.4, 0.12),
         new BubbleChartModel( "Uganda", 76.5, 2124.792, 0.04),
         new BubbleChartModel( "Nigeria", 62, 5155.076, 0.19),
         new BubbleChartModel( "Algeria", 81.4, 11630.68, 0.04),
         new BubbleChartModel( "Greece", 97.9, 29141.17, 0.01),
         new BubbleChartModel( "Jordan", 98.2, 10013.4, 0.01),
         new BubbleChartModel( "Colombia", 95, 14314.86, 0.04),
         new BubbleChartModel( "Mongolia", 98.4, 12028.64, 0.003),
         new BubbleChartModel( "Brazil", 93.2, 14668.26, 0.21),
         new BubbleChartModel( "Nepal", 67.9, 3773.716,  0.02),
         new BubbleChartModel( "Sudan", 60.6, 4369.762,  0.04),
        };
            //Gradient Bubble
            ActionData = new ObservableCollection<BubbleChartModel>()
        {
                new BubbleChartModel("Transformers II",150,836,369,6),
                new BubbleChartModel("Skyfall",200,1109,599,7.7),
                new BubbleChartModel("The Avengers",220,1520,1205,8),
                new BubbleChartModel("Spider-Man 3",258,891,471,6.2),
                new BubbleChartModel("Transformers III",195,1124,371,6.2),
                new BubbleChartModel("The Dark Knight Rises",250,1085,1418,8.4),
                new BubbleChartModel("The Dark Knight",185,1005,2127,9),
                new BubbleChartModel("Inception",160,826,1888,8.8),

        };

            HorrorData = new ObservableCollection<BubbleChartModel>()
        {
                new BubbleChartModel("Interview with the Vampire",60,224,83, 6.9),
                new BubbleChartModel("Scream",14,173,268,7.2),
                new BubbleChartModel("I Know What You Did Last Summer", 17,126, 126,5.7),
                new BubbleChartModel("The Ring", 48,249, 303,7.1),
                new BubbleChartModel("Van Helsing", 160,300,233,6.1),
                new BubbleChartModel("Scream 2", 24,172, 148,6.2),
                new BubbleChartModel("The Conjuring", 13,318,410,7.5),
                new BubbleChartModel("Flatliners",26,61,76,6.6),

        };

            ScienceFictionData = new ObservableCollection<BubbleChartModel>()
        {
                new BubbleChartModel("Armageddon",140,554,377,6.7),
                new BubbleChartModel("Star Wars: Episode I",115,924,667,6.5),
                new BubbleChartModel("Star Wars: Episode II",120,649,587,6.6),
                new BubbleChartModel("The Matrix Reloaded", 150,739,487,7.2),
                new BubbleChartModel("Star Wars: Episode III", 113,850,654,7.5),
                new BubbleChartModel("War of the Worlds", 132,592,394,6.5),
                new BubbleChartModel("World War Z", 200,532, 564,7),
                new BubbleChartModel("Dawn of the Planet of the Apes", 170,711,395,7.6),
        };

            ThrillerData = new ObservableCollection<BubbleChartModel>()
        {
                new BubbleChartModel("Men in Black",90,589,487,7.3),
                new BubbleChartModel("Godzilla",130,379,175,5.4),
                new BubbleChartModel("The Sixth Sense",40,673,860,8.1),
                new BubbleChartModel("Ocean's Eleven",85,451,482,7.8),
                new BubbleChartModel("Terminator 3",200,435,357,6.3),
                new BubbleChartModel("Casino Royale",150,599,547,8),
                new BubbleChartModel("Live Free or Die Hard",110,384,375,7.1),
                new BubbleChartModel("Clash of the Titans",125,493,260,5.8),
                new BubbleChartModel("Mission: Impossible",145,695,435,7.4),
                new BubbleChartModel("Godzilla",160,529,359,6.4),
        };
        }

    }
}
