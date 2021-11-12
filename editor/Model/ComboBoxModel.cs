#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Media.Imaging;
using System.Collections.ObjectModel;

namespace syncfusion.editordemos.winui
{
    public class Employee
    {
        public string Name { get; set; }

        public BitmapImage ProfilePicture { get; set; }

        public string Designation { get; set; }

        public string Country { get; set; }
    }

    public class CountryInfo
    {
        public string CountryName { get; set; }

        public string CountryID { get; set; }

        public BitmapImage FlagImage { get; set; }
    }

    public class State
    {
        public string StateName { get; set; }

        public string CountryID { get; set; }

        public string StateID { get; set; }
    }

    public class City
    {
        public string CityName { get; set; }

        public string StateID { get; set; }

        public string CityID { get; set; }
    }

    public class Sport
    {
        public string ID { get; set; }

        public string Game { get; set; }
    }

    public class Vegetable
    {
        public string Name { get; set; }

        public string Category { get; set; }
    }
}
