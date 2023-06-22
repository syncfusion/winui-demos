#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Data;
using Syncfusion.UI.Xaml.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid
{
    public class Person : NotificationObject, IDisposable
    {
        #region Private members

        private bool _selected;
        private string _name;
        private string _designation;
        private string _mail;
        private string _trust;
        private string _status;
        private double _proficiency;
        private int _rating;
        private double _salary;
        private string _address;
        private string _gender;


        #endregion

        public Person(bool selected, string name, string designation, string mail, string location, string trust, int rating, string status, double proficiency, double salary, string address, string gender)
        {
            Selected = selected;
            EmployeeName = name;
            Designation = designation;
            Mail = mail;
            Location = location;
            Trustworthiness = trust;
            Rating = rating;
            Status = status;
            SoftwareProficiency = proficiency / 100;
            Salary = salary;
            Address = address;
            Gender = gender;
        }

        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                RaisePropertyChanged(nameof(Selected));
            }
        }
        /// <summary>
        /// Gets or sets the employee name.
        /// </summary>        
        [Display(Name = "Employee Name ")]
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
        /// Gets or sets the designation.
        /// </summary>        
        [Display(Name = "Designation ")]
        public string Designation
        {
            get
            {
                return _designation;
            }
            set
            {
                _designation = value;
                RaisePropertyChanged(nameof(Designation));
            }
        }

        /// <summary>
        /// Gets or sets the mail ID.
        /// </summary>        
        [Display(Name = "Mail")]
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

        /// <summary>
        /// Gets or sets the location.
        /// </summary>        
        [Display(Name = "Location")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the Trustworthiness.
        /// </summary>        
        [Display(Name = "Trustworthiness")]
        public string Trustworthiness
        {
            get
            {
                return _trust;
            }
            set
            {
                _trust = value;
                RaisePropertyChanged(nameof(Trustworthiness));
            }
        }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>        
        [Display(Name = "Rating")]
        public int Rating
        {
            get
            {
                return _rating;
            }
            set
            {
                _rating = value;
                RaisePropertyChanged(nameof(Rating));
            }
        }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>        
        [Display(Name = "Status")]
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                RaisePropertyChanged(nameof(Status));
            }
        }

        /// <summary>
        /// Gets or sets the software proficiency .
        /// </summary>        
        [Display(Name = "Software Proficiency")]
        public double SoftwareProficiency
        {
            get
            {
                return _proficiency;
            }
            set
            {
                _proficiency = value;
                RaisePropertyChanged(nameof(SoftwareProficiency));
            }
        }

        /// <summary>
        /// Gets or sets the salary.
        /// </summary>        
        [Display(Name = "Salary")]
        public double Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                _salary = value;
                RaisePropertyChanged(nameof(Salary));
            }
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>        
        [Display(Name = "Address")]
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                RaisePropertyChanged(nameof(Address));
            }
        }

        /// <summary>
        /// Gets or sets the Gender.
        /// </summary>        
        [Display(Name = "Gender")]
        public string Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
                RaisePropertyChanged(nameof(Gender));
            }
        }

        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isdisposable)
        {

        }
        #endregion

    }
}
