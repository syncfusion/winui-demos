#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
    /// <summary>
    /// Represents an employee with basic information such as name, profile picture, designation, country, and an ID.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the profile picture of the employee as a BitmapImage.
        /// </summary>
        public BitmapImage ProfilePicture { get; set; }

        /// <summary>
        /// Gets or sets the job designation of the employee.
        /// </summary>
        public string Designation { get; set; }

        /// <summary>
        /// Gets or sets the country of the employee.
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Gets or sets the unique identifier for the employee.
        /// </summary>
        public string ID { get; set; }
    }

    /// <summary>
    /// Represents information about a country, including its name, ID, and flag image.
    /// </summary>
    public class CountryInfo
    {
        /// <summary>
        /// Gets or sets the name of the country.
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the country.
        /// </summary>
        public string CountryID { get; set; }

        /// <summary>
        /// Gets or sets the flag image of the country as a BitmapImage.
        /// </summary>
        public BitmapImage FlagImage { get; set; }
    }

    /// <summary>
    /// Represents a state within a country, identified by its name, country ID, and state ID.
    /// </summary>
    public class State
    {
        /// <summary>
        /// Gets or sets the name of the state.
        /// </summary>
        public string StateName { get; set; }

        /// <summary>
        /// Gets or sets the ID of the country this state belongs to.
        /// </summary>
        public string CountryID { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the state.
        /// </summary>
        public string StateID { get; set; }
    }

    /// <summary>
    /// Represents a city within a state, identified by its name, state ID, and city ID.
    /// </summary>
    public class City
    {
        /// <summary>
        /// Gets or sets the name of the city.
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// Gets or sets the ID of the state this city belongs to.
        /// </summary>
        public string StateID { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the city.
        /// </summary>
        public string CityID { get; set; }
    }
    
    /// <summary>
    /// Represents information about a city, including its name, country name, and whether it is a capital city.
    /// </summary>
    public class CityInfo
    {
        /// <summary>
        /// Gets or sets the name of the city.
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// Gets or sets the name of the country the city is in.
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this city is a capital city.
        /// </summary>
        public bool IsCapital { get; set; }
    }

    /// <summary>
    /// Represents a sport or game, identified by its ID and name.
    /// </summary>
    public class Sport
    {
        /// <summary>
        /// Gets or sets the unique identifier for the sport.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the name of the sport or game.
        /// </summary>
        public string Game { get; set; }
    }

    /// <summary>
    /// Represents a vegetable with its name and category.
    /// </summary>
    public class Vegetable
    {
        /// <summary>
        /// Gets or sets the name of the vegetable.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the category the vegetable belongs to (e.g., root, leafy).
        /// </summary>
        public string Category { get; set; }
    }

    /// <summary>
    /// Represents a mapping between a country and its continent.
    /// </summary>
    public class ContinentInfo
    {
        /// <summary>
        /// Gets or sets the name of the country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the name of the continent the country is located in.
        /// </summary>
        public string Continent { get; set; }
    }

    /// <summary>
    /// Represents a person with their employee name and email address.
    /// This class inherits from <see cref="NotificationObject"/> to support property change notifications.
    /// </summary>
    public class Person : NotificationObject
    {
        #region Private members

        private string _name;
        private string _mail;


        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class with a specified name and email.
        /// </summary>
        /// <param name="name">The employee's name.</param>
        /// <param name="mail">The employee's email address.</param>
        public Person(string name, string mail)
        { 
            EmployeeName = name;
            Mail = mail;
        }

        /// <summary>
        /// Gets or sets the employee's name. Notifies listeners when the name changes.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the employee's email address. Notifies listeners when the email changes.
        /// </summary>
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
