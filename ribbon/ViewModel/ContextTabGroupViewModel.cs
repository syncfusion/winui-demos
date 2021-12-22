#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using Microsoft.UI.Xaml.Media.Imaging;
using Syncfusion.UI.Xaml.Core;

namespace syncfusion.ribbondemos.winui
{
    public class ContextTabGroupViewModel : NotificationObject
    {
        private Employee selectedEmployee;

        public ContextTabGroupViewModel()
        {
            this.PopulateEmployeesData();
            this.selectedEmployee = Employees[0];
        }

        public ObservableCollection<Employee> Employees { get; set; }

        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                if (selectedEmployee != value)
                {
                    selectedEmployee = value;
                    this.RaisePropertyChanged(nameof(SelectedEmployee));
                }
            }
        }

        private void PopulateEmployeesData()
        {
            this.Employees = new ObservableCollection<Employee>();
            this.Employees.Add(new Employee
            {
                Name = "Anne Dodsworth",
                ProfilePicture = new BitmapImage(new Uri(@"ms-appx:///Assets/Ribbon/Employees/Employee1.png", UriKind.RelativeOrAbsolute)),
                Designation = "Developer",
                Country = "United States",
            });
            this.Employees.Add(new Employee
            {
                Name = "Andrew Fuller",
                ProfilePicture = new BitmapImage(new Uri(@"ms-appx:///Assets/Ribbon/Employees/Employee7.png", UriKind.RelativeOrAbsolute)),
                Designation = "Team Lead",
                Country = "England",
            });
            this.Employees.Add(new Employee
            {
                Name = "Emilio Alvaro",
                ProfilePicture = new BitmapImage(new Uri(@"ms-appx:///Assets/Ribbon/Employees/Employee5.png", UriKind.RelativeOrAbsolute)),
                Designation = "Product Manager",
                Country = "England",
            });
            this.Employees.Add(new Employee
            {
                Name = "Janet Leverling",
                ProfilePicture = new BitmapImage(new Uri(@"ms-appx:///Assets/Ribbon/Employees/Employee3.png", UriKind.RelativeOrAbsolute)),
                Designation = "Human Resource",
                Country = "United States",
            });
            this.Employees.Add(new Employee
            {
                Name = "Laura Callahan",
                ProfilePicture = new BitmapImage(new Uri(@"ms-appx:///Assets/Ribbon/Employees/Employee2.png", UriKind.RelativeOrAbsolute)),
                Designation = "Product Manager",
                Country = "United States",
            });
            this.Employees.Add(new Employee
            {
                Name = "Margaret Peacock",
                ProfilePicture = new BitmapImage(new Uri(@"ms-appx:///Assets/Ribbon/Employees/Employee6.png", UriKind.RelativeOrAbsolute)),
                Designation = "Developer",
                Country = "United States",
            });
            this.Employees.Add(new Employee
            {
                Name = "Michael Suyama",
                ProfilePicture = new BitmapImage(new Uri(@"ms-appx:///Assets/Ribbon/Employees/Employee9.png", UriKind.RelativeOrAbsolute)),
                Designation = "Team Lead",
                Country = "United States",
            });
            this.Employees.Add(new Employee
            {
                Name = "Nancy Davolio",
                ProfilePicture = new BitmapImage(new Uri(@"ms-appx:///Assets/Ribbon/Employees/Employee4.png", UriKind.RelativeOrAbsolute)),
                Designation = "Developer",
                Country = "United States",
            });
            this.Employees.Add(new Employee
            {
                Name = "Robert King",
                ProfilePicture = new BitmapImage(new Uri(@"ms-appx:///Assets/Ribbon/Employees/Employee8.png", UriKind.RelativeOrAbsolute)),
                Designation = "Developer",
                Country = "England",
            });
            this.Employees.Add(new Employee
            {
                Name = "Steven Buchanan",
                ProfilePicture = new BitmapImage(new Uri(@"ms-appx:///Assets/Ribbon/Employees/Employee10.png", UriKind.RelativeOrAbsolute)),
                Designation = "CEO",
                Country = "England",
            });
        }
    }
}
