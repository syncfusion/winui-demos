#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Syncfusion.UI.Xaml.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid
{
   public class EmployeeViewModel : INotifyPropertyChanged, IDisposable
    {
        public EmployeeViewModel()
        {
            PopulateData();
            employees = this.GetEmployeeDetails(2000);
            titleCollection = GetTitles();
        }

        private ObservableCollection<Employee> employees;
        /// <summary>
        /// Get or set the EmployeeDetails
        /// </summary>
        public ObservableCollection<Employee> Employees
        {
            get
            {
                return employees;
            }
            
        }

        private ObservableCollection<string> titleCollection;
        /// <summary>
        /// Get or set the EmployeeDetails
        /// </summary>
        public ObservableCollection<string> TitleCollection
        {
            get
            {
                return titleCollection;
            }

        }

        private bool canAllowSorting = true;

        public bool CanAllowSorting
        {
            get
            {
                return canAllowSorting;
            }
            set
            {
                canAllowSorting = value;
            }
        }

        private bool canAllowFiltering = true;

        public bool CanAllowFiltering
        {
            get
            {
                return canAllowFiltering;
            }
            set
            {
                canAllowFiltering = value;
            }
        }
        private bool canAllowBlankFilters = true;

        public bool CanAllowBlankFilters
        {
            get
            {
                return canAllowBlankFilters;
            }
            set
            {
                canAllowBlankFilters = value;
            }
        }
        private bool canImmediateUpdateColumnFilter;

        public bool CanImmediateUpdateColumnFilter
        {
            get
            {
                return canImmediateUpdateColumnFilter;
            }
            set
            {
                canImmediateUpdateColumnFilter = value;
            }
        }

        Random r = new Random();
        Dictionary<string, string> loginID = new Dictionary<string, string>();
        Dictionary<string, string> gender = new Dictionary<string, string>();

        /// <summary>
        /// Get the EmployeeDetails
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public ObservableCollection<Employee> GetEmployeeDetails(int count)
        {
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

            for (int i = 1; i < count; i++)
            {
                var name = employeeName[r.Next(employeeName.Length - 1)];
                var emp = new Employee()
                {
                    EmployeeID = 1000 + i,
                    Name = name,
                    NationalIDNumber = r.Next(14417807, 112457891),
                    ContactID = r.Next(1001, 2000),
                    ManagerID = r.Next(3, 70),
                    LoginID = loginID[name],
                    Gender = gender[name],
                    Title = title[r.Next(title.Length - 1)],
                    MaritalStatus = r.Next(10, 60) % 2 == 0 ? "Single" : "Married",
                    HireDate = new DateTime(r.Next(1995, 2005), r.Next(1, 12), r.Next(1, 28)),
                    BirthDate = new DateTime(r.Next(1975, 1985), r.Next(1, 12), r.Next(1, 28)),
                    SickLeaveHours = r.Next(15, 70),
                    Salary = Math.Round(r.NextDouble() * 6000.5, 2),
                    EmployeeStatus = r.Next() % 2 == 0 ? true : false,
                    Rating = r.Next(1, 11)
                };
                employees.Add(emp);
            }
            return employees;
        }

        private static ObservableCollection<string> GetTitles()
        {
            ObservableCollection<string> titles = new ObservableCollection<string>();
            titles.Add("Marketing Assistant");
            titles.Add("Engineering Manager");
            titles.Add("Senior Tool Designer");
            titles.Add("Tool Designer");
            titles.Add("Marketing Manager");
            titles.Add("Design Engineer");
            titles.Add("Vice President of Engineering");
            titles.Add("Network Administrator");
            titles.Add("Human Resources Manager");
            titles.Add("Stocker");
            titles.Add("Information Services Manager");
            titles.Add("Recruiter");
            titles.Add("Quality Assurance Supervisor");
            titles.Add("Production Technician - WC45");
            titles.Add("Maintenance Supervisor");

            return titles;
        }
        /// <summary>
        /// Populate the data for Gender
        /// </summary>
        private void PopulateData()
        {
            gender.Add("Sean Jacobson", "Male");
            gender.Add("Phyllis Allen", "Male");
            gender.Add("Marvin Allen", "Male");
            gender.Add("Michael Allen", "Male");
            gender.Add("Cecil Allison", "Male");
            gender.Add("Oscar Alpuerto", "Male");
            gender.Add("Sandra Altamirano", "Female");
            gender.Add("Selena Alvarad", "Female");
            gender.Add("Emilio Alvaro", "Female");
            gender.Add("Maxwell Amland", "Male");
            gender.Add("Mae Anderson", "Male");
            gender.Add("Ramona Antrim", "Female");
            gender.Add("Sabria Appelbaum", "Male");
            gender.Add("Hannah Arakawa", "Male");
            gender.Add("Kyley Arbelaez", "Male");
            gender.Add("Tom Johnston", "Female");
            gender.Add("Thomas Armstrong", "Female");
            gender.Add("John Arthur", "Male");
            gender.Add("Chris Ashton", "Female");
            gender.Add("Teresa Atkinson", "Male");
            gender.Add("John Ault", "Male");
            gender.Add("Robert Avalos", "Male");
            gender.Add("Stephen Ayers", "Male");
            gender.Add("Phillip Bacalzo", "Male");
            gender.Add("Gustavo Achong", "Male");
            gender.Add("Catherine Abel", "Male");
            gender.Add("Kim Abercrombie", "Male");
            gender.Add("Humberto Acevedo", "Male");
            gender.Add("Pilar Ackerman", "Male");
            gender.Add("Frances Adams", "Female");
            gender.Add("Margar Smith", "Male");
            gender.Add("Carla Adams", "Male");
            gender.Add("Jay Adams", "Male");
            gender.Add("Ronald Adina", "Female");
            gender.Add("Samuel Agcaoili", "Male");
            gender.Add("James Aguilar", "Female");
            gender.Add("Robert Ahlering", "Male");
            gender.Add("Francois Ferrier", "Male");
            gender.Add("Kim Akers", "Male");
            gender.Add("Lili Alameda", "Female");
            gender.Add("Amy Alberts", "Male");
            gender.Add("Anna Albright", "Female");
            gender.Add("Milton Albury", "Male");
            gender.Add("Paul Alcorn", "Male");
            gender.Add("Gregory Alderson", "Male");
            gender.Add("J. Phillip Alexander", "Male");
            gender.Add("Michelle Alexander", "Male");
            gender.Add("Daniel Blanco", "Male");
            gender.Add("Cory Booth", "Male");
            gender.Add("James Bailey", "Female");

            loginID.Add("Sean Jacobson", "sean2");
            loginID.Add("Phyllis Allen", "phyllis0");
            loginID.Add("Marvin Allen", "marvin0");
            loginID.Add("Michael Allen", "michael10");
            loginID.Add("Cecil Allison", "cecil0");
            loginID.Add("Oscar Alpuerto", "oscar0");
            loginID.Add("Sandra Altamirano", "sandra1");
            loginID.Add("Selena Alvarad", "selena0");
            loginID.Add("Emilio Alvaro", "emilio0");
            loginID.Add("Maxwell Amland", "maxwell0");
            loginID.Add("Mae Anderson", "mae0");
            loginID.Add("Ramona Antrim", "ramona0");
            loginID.Add("Sabria Appelbaum", "sabria0");
            loginID.Add("Hannah Arakawa", "hannah0");
            loginID.Add("Kyley Arbelaez", "kyley0");
            loginID.Add("Tom Johnston", "tom1");
            loginID.Add("Thomas Armstrong", "thomas1");
            loginID.Add("John Arthur", "john6");
            loginID.Add("Chris Ashton", "chris3");
            loginID.Add("Teresa Atkinson", "teresa0");
            loginID.Add("John Ault", "john7");
            loginID.Add("Robert Avalos", "robert2");
            loginID.Add("Stephen Ayers", "stephen1");
            loginID.Add("Phillip Bacalzo", "phillip0");
            loginID.Add("Gustavo Achong", "gustavo0");
            loginID.Add("Catherine Abel", "catherine0");
            loginID.Add("Kim Abercrombie", "kim2");
            loginID.Add("Humberto Acevedo", "humberto0");
            loginID.Add("Pilar Ackerman", "pilar1");
            loginID.Add("Frances Adams", "frances0");
            loginID.Add("Margar Smith", "margaret0");
            loginID.Add("Carla Adams", "carla0");
            loginID.Add("Jay Adams", "jay1");
            loginID.Add("Ronald Adina", "ronald0");
            loginID.Add("Samuel Agcaoili", "samuel0");
            loginID.Add("James Aguilar", "james2");
            loginID.Add("Robert Ahlering", "robert1");
            loginID.Add("Francois Ferrier", "françois1");
            loginID.Add("Kim Akers", "kim3");
            loginID.Add("Lili Alameda", "lili0");
            loginID.Add("Amy Alberts", "amy1");
            loginID.Add("Anna Albright", "anna0");
            loginID.Add("Milton Albury", "milton0");
            loginID.Add("Paul Alcorn", "paul2");
            loginID.Add("Gregory Alderson", "gregory0");
            loginID.Add("J. Phillip Alexander", "jphillip0");
            loginID.Add("Michelle Alexander", "michelle0");
            loginID.Add("Daniel Blanco", "daniel0");
            loginID.Add("Cory Booth", "cory0");
            loginID.Add("James Bailey", "james3");

        }

        string[] title = new string[]
   {
            "Marketing Assistant",
            "Engineering Manager",
            "Senior Tool Designer",
            "Tool Designer",
            "Marketing Manager",
            "Production Supervisor - WC60",
            "Production Technician - WC10",
            "Design Engineer",
            "Production Technician - WC10",
            "Design Engineer",
            "Vice President of Engineering",
            "Production Technician - WC10",
            "Production Supervisor - WC50",
            "Production Technician - WC10",
            "Production Supervisor - WC60",
            "Production Technician - WC10",
            "Production Supervisor - WC60",
            "Production Technician - WC10",
            "Production Technician - WC30",
            "Production Control Manager",
            "Production Technician - WC45",
            "Production Technician - WC45",
            "Production Technician - WC30",
            "Production Supervisor - WC10",
            "Production Technician - WC20",
            "Production Technician - WC40",
            "Network Administrator",
            "Production Technician - WC50",
            "Human Resources Manager",
            "Production Technician - WC40",
            "Production Technician - WC30",
            "Production Technician - WC30",
            "Stocker",
            "Shipping and Receiving Clerk",
            "Production Technician - WC50",
            "Production Technician - WC60",
            "Production Supervisor - WC50",
            "Production Technician - WC20",
            "Production Technician - WC45",
            "Quality Assurance Supervisor",
            "Information Services Manager",
            "Production Technician - WC50",
            "Master Scheduler",
            "Production Technician - WC40",
            "Marketing Specialist",
            "Recruiter",
            "Production Technician - WC50",
            "Maintenance Supervisor",
            "Production Technician - WC30",
   };

        string[] employeeName = new string[]
        {
            "Sean Jacobson",
            "Phyllis Allen",
            "Marvin Allen",
            "Michael Allen",
            "Cecil Allison",
            "Oscar Alpuerto",
            "Sandra Altamirano",
            "Selena Alvarad",
            "Emilio Alvaro",
            "Maxwell Amland",
            "Mae Anderson",
            "Ramona Antrim",
            "Sabria Appelbaum",
            "Hannah Arakawa",
            "Kyley Arbelaez",
            "Tom Johnston",
            "Thomas Armstrong",
            "John Arthur",
            "Chris Ashton",
            "Teresa Atkinson",
            "John Ault",
            "Robert Avalos",
            "Stephen Ayers",
            "Phillip Bacalzo",
            "Gustavo Achong",
            "Catherine Abel",
            "Kim Abercrombie",
            "Humberto Acevedo",
            "Pilar Ackerman",
            "Frances Adams",
            "Margar Smith",
            "Carla Adams",
            "Jay Adams",
            "Ronald Adina",
            "Samuel Agcaoili",
            "James Aguilar",
            "Robert Ahlering",
            "Francois Ferrier",
            "Kim Akers",
            "Lili Alameda",
            "Amy Alberts",
            "Anna Albright",
            "Milton Albury",
            "Paul Alcorn",
            "Gregory Alderson",
            "J. Phillip Alexander",
            "Michelle Alexander",
            "Daniel Blanco",
            "Cory Booth",
            "James Bailey"
        };

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isdisposable)
        {
            if (Employees != null)
            {
                Employees.Clear();
            }
        }
    }

}
