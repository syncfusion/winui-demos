#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Core;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace syncfusion.chartdemos.winui
{
    public class CustomToolTipViewModel : NotificationObject
    {
        public static Array HorizontalAlignments
        {
            get
            {
                return new string[] { "Left", "Center", "Right" };
            }
        }

        public string HorizontalOffset
        {
            get
            {
                return horizontalOffset;
            }

            set
            {
                double result;
                if (double.TryParse(value, out result) || value == ".")
                    horizontalOffset = value;
                RaisePropertyChanged(nameof(HorizontalOffset));
            }
        }

        public string VerticalOffset
        {
            get
            {
                return verticalOffset;
            }

            set
            {
                double result;
                if (double.TryParse(value, out result) || value == ".")
                    verticalOffset = value;
                RaisePropertyChanged(nameof(VerticalOffset));
            }
        }

        public static Array VerticalAlignments
        {
            get
            {
                return new string[] { "Top", "Center", "Bottom" };
            }
        }

        public ObservableCollection<CustomToolTipModel> CompanyDetails { get; }
       
        private string horizontalOffset;
        private string verticalOffset;

        public CustomToolTipViewModel()
        {
            CompanyDetails = new ObservableCollection<CustomToolTipModel>();

            CompanyDetails.Add(new CustomToolTipModel()
            {
                CompanyName = "Mercedes",
                YTD = 823.502,
                Rank = 16,
                ImagePath = new Uri("ms-appx:///Assets/Chart/benz.png", UriKind.RelativeOrAbsolute)
            });

            CompanyDetails.Add(new CustomToolTipModel()
            {
                CompanyName = "Audi",
                YTD = 1030.393,
                Rank = 12,
                ImagePath = new Uri("ms-appx:///Assets/Chart/audi.png", UriKind.RelativeOrAbsolute)
            });

            CompanyDetails.Add(new CustomToolTipModel()
            {
                CompanyName = "BMW",
                YTD = 450.330,
                Rank = 11,
                ImagePath = new Uri("ms-appx:///Assets/Chart/bmw.png", UriKind.RelativeOrAbsolute)
            });

            CompanyDetails.Add(new CustomToolTipModel()
            {
                CompanyName = "Skoda",
                YTD = 590.897,
                Rank = 24,
                ImagePath = new Uri("ms-appx:///Assets/Chart/skoda.png", UriKind.RelativeOrAbsolute)
            });

            CompanyDetails.Add(new CustomToolTipModel()
            {
                CompanyName = "Volvo",
                YTD = 250.758,
                Rank = 43,
                ImagePath = new Uri("ms-appx:///Assets/Chart/volvo.png", UriKind.RelativeOrAbsolute)
            });

            HorizontalOffset = "10";
            VerticalOffset = "10";
        }
    }
}
