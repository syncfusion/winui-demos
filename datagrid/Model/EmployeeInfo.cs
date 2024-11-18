#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid
{
    public class EmployeeInfo : NotificationObject
    {
        private string _name;
        private int _contactID;
        private string _title;
        private DateTime _birthDate;
        private string _gender;
        private double _sickLeaveHours;
        private decimal _salary;
        private int _employeeID;
        private int _rating;

        [Display(Name = "Employee ID")]
        public int EmployeeID
        {
            get { return this._employeeID; }
            set
            {
                this._employeeID = value;
                this.RaisePropertyChanged("EmployeeID");
            }
        }

        public string Name
        {
            get { return this._name; }
            set
            {
                this._name = value;
                this.RaisePropertyChanged("Name");
            }
        }

        public string Title
        {
            get { return this._title; }
            set
            {
                this._title = value;
                this.RaisePropertyChanged("Title");
            }
        }

        public int Rating
        {
            get { return _rating; }
            set
            {
                _rating = value;
                this.RaisePropertyChanged("Rating");
            }
        }

        [Display(Name = "Contact ID")]
        public int ContactID
        {
            get { return this._contactID; }
            set
            {
                this._contactID = value;
                this.RaisePropertyChanged("ContactID");
            }
        }

        [Display(Name = "Birth Date")]
        public DateTime BirthDate
        {
            get { return this._birthDate; }
            set
            {
                this._birthDate = value;
                this.RaisePropertyChanged("BirthDate");
            }
        }

        public string Gender
        {
            get { return this._gender; }
            set
            {
                this._gender = value;
                this.RaisePropertyChanged("Gender");
            }
        }

        [Display(Name = "Sick Leave Hours")]
        public double SickLeaveHours
        {
            get { return this._sickLeaveHours; }
            set
            {
                this._sickLeaveHours = value;
                this.RaisePropertyChanged("SickLeaveHours");
            }
        }

        public decimal Salary
        {
            get { return this._salary; }
            set
            {
                this._salary = value;
                this.RaisePropertyChanged("Salary");
            }
        }
    }
}
