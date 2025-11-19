#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Media.Imaging;

namespace Syncfusion.RibbonDemos.WinUI
{
    /// <summary>
    /// Represents an employee with basic information.
    /// This model is likely used for displaying employee details in a list or grid.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the job designation of the employee.
        /// </summary>
        public string Designation { get; set; }

        /// <summary>
        /// Gets or sets the employee's profile picture, represented as a <see cref="BitmapImage"/>.
        /// </summary>
        public BitmapImage ProfilePicture { get; set; }

        /// <summary>
        /// Gets or sets the country where the employee is located or associated with.
        /// </summary>
        public string Country { get; set; }
    }
}
