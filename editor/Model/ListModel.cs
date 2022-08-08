#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Media.Imaging;
using Syncfusion.UI.Xaml.Core;
using System.Collections.ObjectModel;

namespace Syncfusion.EditorDemos.WinUI
{
    public class Employee
    {
        public string Name { get; set; }

        public BitmapImage ProfilePicture { get; set; }

        public string Designation { get; set; }

        public string Country { get; set; }
        public string ID { get; set; }
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
    
    public class CityInfo
    {
        public string CityName { get; set; }

        public string CountryName { get; set; }

        public bool IsCapital { get; set; }
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

    public class ContinentInfo
    {
        public string Country { get; set; }

        public string Continent { get; set; }
    }

    public class Person : NotificationObject
    {
        #region Private members

        private string _name;
        private string _mail;


        #endregion

        public Person(string name, string mail)
        { 
            EmployeeName = name;
            Mail = mail;
        }
        public string EmployeeName
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChanged(nameof(EmployeeName));
            }
        }
        public string Mail
        {
            get
            {
                return _mail;
            }
            set
            {
                _mail = value;
                RaisePropertyChanged(nameof(Mail));
            }
        }

    }
}
