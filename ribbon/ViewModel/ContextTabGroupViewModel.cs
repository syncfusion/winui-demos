#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using Microsoft.UI.Xaml.Media.Imaging;
using Syncfusion.UI.Xaml.Core;

namespace Syncfusion.RibbonDemos.WinUI
{
    /// <summary>
    /// ViewModel for managing data related to employees, used in contexts that might involve contextual tabs or grouped displays.
    /// It holds a collection of employees and manages the currently selected employee.
    /// This class inherits from <see cref="NotificationObject"/> to support property change notifications.
    /// </summary>
    public class ContextTabGroupViewModel : NotificationObject
    {
        private Employee selectedEmployee;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContextTabGroupViewModel"/> class.
        /// Populates the employee data and sets the first employee as the initially selected one.
        /// </summary>
        public ContextTabGroupViewModel()
        {
            this.PopulateEmployeesData();
            this.selectedEmployee = Employees[0];
        }

        /// <summary>
        /// Gets or sets the observable collection of employee data.
        /// </summary>
        public ObservableCollection<Employee> Employees { get; set; }

        /// <summary>
        /// Gets or sets the currently selected employee from the collection. Notifies listeners when the selection changes.
        /// </summary>
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

        /// <summary>
        /// Populates the <see cref="Employees"/> collection with sample employee data. Includes details like name, profile picture, designation, and country.
        /// Image paths are adjusted based on the `Main_SB` preprocessor directive.
        /// </summary>
        private void PopulateEmployeesData()
        {
            string path = @"ms-appx:///";
#if Main_SB
            path = @"ms-appx:///Ribbon/";
#endif
            this.Employees = new ObservableCollection<Employee>();
            this.Employees.Add(new Employee
            {
                Name = "Anne Dodsworth",
                ProfilePicture = new BitmapImage(new Uri(path +"Assets/Ribbon/Employees/Employee1.png", UriKind.RelativeOrAbsolute)),
                Designation = "Developer",
                Country = "United States",
            });
            this.Employees.Add(new Employee
            {
                Name = "Andrew Fuller",
                ProfilePicture = new BitmapImage(new Uri(path + "Assets/Ribbon/Employees/Employee7.png", UriKind.RelativeOrAbsolute)),
                Designation = "Team Lead",
                Country = "England",
            });
            this.Employees.Add(new Employee
            {
                Name = "Emilio Alvaro",
                ProfilePicture = new BitmapImage(new Uri(path + "Assets/Ribbon/Employees/Employee5.png", UriKind.RelativeOrAbsolute)),
                Designation = "Product Manager",
                Country = "England",
            });
            this.Employees.Add(new Employee
            {
                Name = "Janet Leverling",
                ProfilePicture = new BitmapImage(new Uri(path + "Assets/Ribbon/Employees/Employee3.png", UriKind.RelativeOrAbsolute)),
                Designation = "Human Resource",
                Country = "United States",
            });
            this.Employees.Add(new Employee
            {
                Name = "Laura Callahan",
                ProfilePicture = new BitmapImage(new Uri(path + "Assets/Ribbon/Employees/Employee2.png", UriKind.RelativeOrAbsolute)),
                Designation = "Product Manager",
                Country = "United States",
            });
            this.Employees.Add(new Employee
            {
                Name = "Margaret Peacock",
                ProfilePicture = new BitmapImage(new Uri(path + "Assets/Ribbon/Employees/Employee6.png", UriKind.RelativeOrAbsolute)),
                Designation = "Developer",
                Country = "United States",
            });
            this.Employees.Add(new Employee
            {
                Name = "Michael Suyama",
                ProfilePicture = new BitmapImage(new Uri(path + "Assets/Ribbon/Employees/Employee9.png", UriKind.RelativeOrAbsolute)),
                Designation = "Team Lead",
                Country = "United States",
            });
            this.Employees.Add(new Employee
            {
                Name = "Nancy Davolio",
                ProfilePicture = new BitmapImage(new Uri(path + "Assets/Ribbon/Employees/Employee4.png", UriKind.RelativeOrAbsolute)),
                Designation = "Developer",
                Country = "United States",
            });
            this.Employees.Add(new Employee
            {
                Name = "Robert King",
                ProfilePicture = new BitmapImage(new Uri(path + "Assets/Ribbon/Employees/Employee8.png", UriKind.RelativeOrAbsolute)),
                Designation = "Developer",
                Country = "England",
            });
            this.Employees.Add(new Employee
            {
                Name = "Steven Buchanan",
                ProfilePicture = new BitmapImage(new Uri(path + "Assets/Ribbon/Employees/Employee10.png", UriKind.RelativeOrAbsolute)),
                Designation = "CEO",
                Country = "England",
            });
        }
    }
}
