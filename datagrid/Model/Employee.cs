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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections;
using System.ComponentModel;

namespace DataGrid
{
    public class Employee : NotificationObject, INotifyDataErrorInfo, IDisposable
    {
        private double _EmployeeID;
        private string _Name;
        private int _age;
        private string _designation;
        private string _location;
        private long _NationalIDNumber;
        private int _ContactID;
        private string _LoginID;
        private int _ManagerID;
        private string _Title;
        private DateTimeOffset? _BirthDate;
        private string _MaritalStatus;
        private string _Gender;
        private DateTimeOffset? _HireDate;
        private int _SickLeaveHours;
        private double _Salary;
        private bool employeeStatus;
        private int _rating;
        private string _email;
        private string _contactnos;
        private string _city;
        private DateTimeOffset? _CheckInTime;
        Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");


        /// <summary>
        /// Gets or sets the employee ID.
        /// </summary>
        /// <value>The employee ID.</value>
        public double EmployeeID
        {
            get
            {
                return this._EmployeeID;
            }
            set
            {
                this._EmployeeID = value;
                this.RaisePropertyChanged(nameof(EmployeeID));
            }
        }

#nullable enable
        private string? _genderType;

        /// <summary>
        /// Gets or sets the gender type.
        /// </summary>
        /// <value>The gender type.</value>
        public string? GenderType
        {
            get
            {
                return this._genderType;
            }
            set
            {
                this._genderType = value;
                this.RaisePropertyChanged(nameof(GenderType));
            }
        }
#nullable disable
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
                this.RaisePropertyChanged(nameof(Name));
            }
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public long NationalIDNumber
        {
            get
            {
                return this._NationalIDNumber;
            }
            set
            {
                this._NationalIDNumber = value;
                this.RaisePropertyChanged(nameof(NationalIDNumber));
            }
        }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        /// <value>The age.</value>
        public int Age
        {
            get
            {
                return this._age;
            }
            set
            {
                this._age = value;
                this.RaisePropertyChanged(nameof(Age));
            }
        }

        /// <summary>
        /// Gets or sets the Location.
        /// </summary>
        /// <value>The location.</value>
        public string Location
        {
            get
            {
                return this._location;
            }
            set
            {
                this._location = value;
                this.RaisePropertyChanged(nameof(Location));
            }
        }

        /// <summary>
        /// Gets or sets the Designation.
        /// </summary>
        /// <value>The designation.</value>
        public string Designation
        {
            get
            {
                return this._designation;
            }
            set
            {
                this._designation = value;
                this.RaisePropertyChanged(nameof(Designation));
            }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                this._Title = value;
                this.RaisePropertyChanged(nameof(Title));
            }
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public int ContactID
        {
            get
            {
                return this._ContactID;
            }
            set
            {
                this._ContactID = value;
                this.RaisePropertyChanged(nameof(ContactID));
            }
        }

        /// <summary>
        /// Gets or sets the BirthDate.
        /// </summary>
        /// <value>The BirthDate.</value>
        public DateTimeOffset? BirthDate
        {
            get
            {
                return this._BirthDate;
            }
            set
            {
                this._BirthDate = value;
                this.RaisePropertyChanged(nameof(BirthDate));
            }
        }

        /// <summary>
        /// Gets or sets the MaritalStatus.
        /// </summary>
        /// <value>The MaritalStatus.</value>
        public string MaritalStatus
        {
            get
            {
                return this._MaritalStatus;
            }
            set
            {
                this._MaritalStatus = value;
                this.RaisePropertyChanged(nameof(MaritalStatus));
            }
        }

        /// <summary>
        /// Gets or sets the Gender.
        /// </summary>
        /// <value>The Gender.</value>
        public string Gender
        {
            get
            {
                return this._Gender;
            }
            set
            {
                this._Gender = value;
                this.RaisePropertyChanged(nameof(Gender));
            }
        }

        /// <summary>
        /// Gets or sets the HireDate.
        /// </summary>
        /// <value>The HireDate.</value>
        public DateTimeOffset? HireDate
        {
            get
            {
                return this._HireDate;
            }
            set
            {
                this._HireDate = value;
                this.RaisePropertyChanged(nameof(HireDate));
            }
        }

        /// <summary>
        /// Gets or sets the CheckInTime.
        /// </summary>
        /// <value>The CheckInTime.</value>
        public DateTimeOffset? CheckInTime
        {
            get
            {
                return this._CheckInTime;
            }
            set
            {
                this._CheckInTime = value;
                this.RaisePropertyChanged(nameof(CheckInTime));
            }
        }

        /// <summary>
        /// Gets or sets the SickLeaveHours.
        /// </summary>
        /// <value>The SickLeaveHours.</value>
        public int SickLeaveHours
        {
            get
            {
                return this._SickLeaveHours;
            }
            set
            {
                this._SickLeaveHours = value;
                this.RaisePropertyChanged(nameof(SickLeaveHours));
            }
        }

        /// <summary>
        /// Gets or sets the Salary.
        /// </summary>
        /// <value>The Salary.</value>
        [Range(2000, 5000, ErrorMessage = "The “Salary” field can range from 2000 through 5000.")]
        public double Salary
        {
            get
            {
                return this._Salary;
            }
            set
            {
                this._Salary = value;
                this.RaisePropertyChanged(nameof(Salary));
            }
        }

        /// <summary>
        /// Gets or sets the LoginID.
        /// </summary>
        /// <value>The LogID.</value>
        public string LoginID
        {
            get
            {
                return _LoginID;
            }
            set
            {
                _LoginID = value;
                this.RaisePropertyChanged(nameof(LoginID));
            }
        }

        /// <summary>
        /// Gets or sets the ManagerID.
        /// </summary>
        /// <value>The ManagerID.</value>
        public int ManagerID
        {
            get
            {
                return _ManagerID;
            }
            set
            {
                _ManagerID = value;
                this.RaisePropertyChanged(nameof(ManagerID));
            }
        }

        /// <summary>
        /// Gets or sets the EmployeeStatus.
        /// </summary>
        /// <value>The EmployeeStatus.</value>
        public bool EmployeeStatus
        {
            get
            {
                return employeeStatus;
            }
            set
            {
                employeeStatus = value;
                this.RaisePropertyChanged(nameof(EmployeeStatus));
            }
        }

        /// <summary>
        /// Gets or sets the Rating.
        /// </summary>
        /// <value>The Rating.</value>
        public int Rating
        {
            get { return _rating; }
            set
            {
                _rating = value;
                this.RaisePropertyChanged(nameof(Rating));
            }
        }

        /// <summary>
        /// Gets or sets the EMail.
        /// </summary>
        /// <value>The EMail.</value>
        public string EMail
        {
            get { return _email; }
            set
            {
                _email = value;
                this.RaisePropertyChanged(nameof(EMail));
            }
        }

        /// <summary>
        /// Gets or sets the ContactNo.
        /// </summary>
        /// <value>The ContactNo.</value>
        [StringLength(14, ErrorMessage = "The “ContactNo” field must be a string with a maximum length of 14.")]
        public string ContactNo
        {
            get { return _contactnos; }
            set
            {
                _contactnos = value;
                this.RaisePropertyChanged(nameof(ContactNo));
            }
        }

        /// <summary>
        /// Gets or sets the City.
        /// </summary>
        /// <value>The City.</value>
        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                this.RaisePropertyChanged(nameof(City));
            }
        }

#region INotifyDataErrorInfo

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public IEnumerable GetErrors(string propertyName)
        {
            if (propertyName == "EMail")
            {
                if (!emailRegex.IsMatch(this.EMail))
                {
                    List<string> errorList = new List<string>();
                    errorList.Add("Email ID is invalid!");
                    NotifyErrorsChanged(propertyName);
                    return errorList;
                }
            }
            return null;
        }    

        private void NotifyErrorsChanged(string propertyName)
        {
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public bool HasErrors
        {
            get { return !emailRegex.IsMatch(this.EMail); }
        }
        
#endregion

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
