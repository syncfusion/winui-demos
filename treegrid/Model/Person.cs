#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Data;
using Syncfusion.UI.Xaml.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections;
#if WinUI_Desktop
using System.ComponentModel;
#endif

namespace TreeGrid
{
    public class Person : NotificationObject, INotifyDataErrorInfo, IDisposable
    {
        #region Private Fields

        private static int _globalId;
        private int _id;
        private string _firstName;
        private string _lastName;
        private DateTime? _doj;
        private double? _salary;
        private string city;
        private string contactNumber;
        private string _email;
        private ObservableCollection<Person> _children;
        Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        /// <value>The children.</value>
        public ObservableCollection<Person> Children
        {
            get
            {
                return _children;
            }
            set
            {
                _children = value;
            }
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public int EmployeeID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                RaisePropertyChanged(nameof(EmployeeID));
            }
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                RaisePropertyChanged(nameof(FirstName));
            }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                RaisePropertyChanged(nameof(LastName));
            }
        }

        /// <summary>
        /// Gets or sets the DOJ.
        /// </summary>
        /// <value>The DOJ.</value>
        public DateTime? DOJ
        {
            get
            {
                return _doj;
            }
            set
            {
                _doj = value;
                RaisePropertyChanged(nameof(DOJ));
            }
        }

        /// <summary>
        /// Gets or sets the Salary.
        /// </summary>
        /// <value>Salary</value>
        [Range(10000, 70000, ErrorMessage = "The “Salary” field can range from 10000 through 70000.")]
        public double? Salary
        {
            get { return _salary; }
            set
            {
                _salary = value;
                RaisePropertyChanged(nameof(Salary));
            }
        }
        /// <summary>
        /// Gets or sets the City.
        /// </summary>
        /// <value>City</value>      

        public string City
        {
            get { return city; }
            set
            {
                city = value;
                RaisePropertyChanged(nameof(City));
            }
        }

        /// <summary>
        /// Gets or sets the ContactNumber.
        /// </summary>
        /// <value>The ContactNumber.</value>   
        [StringLength(14, ErrorMessage = "The “ContactNo” field must be a string with a maximum length of 14.")]
        public string ContactNumber
        {
            get { return contactNumber; }
            set
            {
                contactNumber = value;
                RaisePropertyChanged(nameof(ContactNumber));
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
                RaisePropertyChanged(nameof(EMail));
            }
        }

        #endregion

        #region Constructors


        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeInfo"/> class.
        /// </summary>
        public Person()
            : this("Enter FirstName", "Enter LastName", new DateTime(2008, 10, 26), 78998, "Mexico", "8692782389"," Enter Mail ID", null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeInfo"/> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="eyecolor">The eyecolor.</param>
        /// <param name="doj">The doj.</param>
        /// <param name="maxGenerations">The max generations.</param>
        public Person(string firstName, string lastName, DateTime doj, double? sal, string empCity, string contactnum, string mailid, ObservableCollection<Person> child)
        {
            FirstName = firstName;
            LastName = lastName;
            DOJ = doj;
            Salary = sal;
            EmployeeID = _globalId++;
            City = empCity;
            ContactNumber = contactnum;
            EMail = mailid;
            _children = child;
        }

        #endregion

        #region INotifyDataErrorInfo

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

#if WinUI_Desktop
        IEnumerable INotifyDataErrorInfo.GetErrors(string propertyName)
#else
        public IEnumerable<object> GetErrors(string propertyName)
#endif
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

            if (Children != null)
            {
                foreach (var child in Children)
                    (child as Person).Dispose();
                Children.Clear();
            }

            if (emailRegex != null)
                emailRegex = null;
        }
        #endregion
    }
}
