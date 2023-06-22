#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Syncfusion.UI.Xaml.Core;
using Syncfusion.UI.Xaml.DataGrid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ListSortDirection = Syncfusion.UI.Xaml.Data.SortDirection;
using Windows.ApplicationModel.DataTransfer;
using Microsoft.UI.Xaml;
using Syncfusion.UI.Xaml.Grids;
using Windows.Globalization.NumberFormatting;
using System.ComponentModel;

namespace DataGrid
{
   public class EmployeeViewModel : INotifyPropertyChanged, IDisposable
    {
        public EmployeeViewModel()
        {
            _gridCutCommand = new DelegateCommand(Cut);
            _gridCopyCommand = new DelegateCommand(Copy);
            _gridPasteCommand = new DelegateCommand(Paste);
            _gridDeleteCommand = new DelegateCommand(Delete);
            _expandAllCommand = new DelegateCommand(ExpandAll);
            _collapseAllCommand = new DelegateCommand(CollapseAll);
            _sortAscendingCommand = new DelegateCommand(SortAscending);
            _sortDescendingCommand = new DelegateCommand(SortDescending);
            _clearSummaryCommand = new DelegateCommand(ClearSummary);
            _groupColumnCommand = new DelegateCommand(GroupColumn);
            _showGroupDropAreaCommand = new DelegateCommand(ShowGroupDropArea);
            _clearSortingCommand = new DelegateCommand(ClearSorting);
            _clearFilteringCommand = new DelegateCommand(ClearFiltering);
            _clearGroupingCommand = new DelegateCommand(ClearGrouping);
            PopulateData();
            employees = this.GetEmployeeDetails(200);
            titleCollection = GetTitles();
            keySelector = (string ColumnName, object o) =>
            {
                var dt = DateTime.Now;
                var item = (o as Employee).HireDate;
                var days = (int)Math.Floor((dt - item).Value.TotalDays);
                var dayOfWeek = (int)dt.DayOfWeek;
                var difference = days - dayOfWeek;
                if (days <= dayOfWeek)
                {
                    if (days == 0)
                        return "TODAY";
                    if (days == 1)
                        return "YESTERDAY";
                    return item.Value.DayOfWeek.ToString().ToUpper();
                }
                if (difference > 0 && difference <= 7)
                    return "LAST WEEK";
                if (difference > 7 && difference <= 14)
                    return "TWO WEEKS AGO";
                if (difference > 14 && difference <= 21)
                    return "THREE WEEKS AGO";
                if (dt.Year == item.Value.Year && dt.Month == item.Value.Month)
                    return "EARLIER THIS MONTH";
                if (DateTime.Now.AddMonths(-1).Month == item.Value.Month)
                    return "LAST MONTH";
                return "OLDER";
            };
        }

        private Func<string, object, object> keySelector;

        public Func<string, object, object> KeySelector
        {
            get
            {
                return keySelector;
            }
            set
            {
                keySelector = value;
            }
        }
        /// <summary>
        /// Used to set the system default currency to numeric column NumberFormatter.
        /// </summary>
        public CurrencyFormatter SystemCurrency
        {
            get
            {
                return new CurrencyFormatter(Windows.System.UserProfile.GlobalizationPreferences.Currencies[0]);
            }
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

            for (int i = 1; i <= count; i++)
            {
                var name = employeeName[r.Next(employeeName.Length - 1)];
                var emp = new Employee()
                {
                    EmployeeID = 1000 + i,
                    Name = name,
                    Designation = designation[r.Next(1, 6)],
                    Location = location[r.Next(1, 8)],
                    NationalIDNumber = r.Next(14417807, 112457891),
                    ContactID = r.Next(1001, 2000),
                    ManagerID = r.Next(3, 70),
                    LoginID = loginID[name],
                    Gender = gender[name],
                    GenderType = (i == 10 || i == 20) ? null : gender[name],
                    Title = title[r.Next(title.Length - 1)],
                    MaritalStatus = r.Next(10, 60) % 2 == 0 ? "Single" : "Married",
                    HireDate = new DateTimeOffset(DateTime.Today.AddDays(r.Next(-50, 1))),
                    BirthDate = new DateTimeOffset(new DateTime(r.Next(1975, 1985), r.Next(1, 12), r.Next(1, 28))),
                    CheckInTime = new DateTimeOffset(new DateTime(r.Next(1975, 1985), r.Next(1, 12), r.Next(1, 28),r.Next(1,24),r.Next(1,60),r.Next(1,60))),
                    EMail = names[r.Next(names.Length - 1)] + "@" + mail[r.Next(0, mail.Count() - 1)],
                    ContactNo = contactNos[r.Next(0, contactNos.Count() - 1)],
                    City=cityNames[r.Next(0, cityNames.Count() - 1)],
                    SickLeaveHours = r.Next(15, 70),
                    Salary = Math.Round(r.NextDouble() * 6000.5, 2),
                    EmployeeStatus = r.Next() % 2 == 0 ? true : false,
                    Rating = r.Next(1, 11)
                };
                emp.Age = DateTime.Now.Year-emp.BirthDate.Value.Year;
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
            titles.Add("Production Supervisor");
            titles.Add("Production Technician");
            titles.Add("Design Engineer");
            titles.Add("Vice President");
            titles.Add("Product Manager");
            titles.Add("Network Administrator");
            titles.Add("HR Manager");
            titles.Add("Stocker");
            titles.Add("Clerk");
            titles.Add("QA Supervisor");
            titles.Add("Services Manager");
            titles.Add("Master Scheduler");
            titles.Add("Marketing Specialist");
            titles.Add("Recruiter");
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
            "Production Supervisor",
            "Production Technician",
            "Design Engineer",
            "Vice President",
            "Product Manager",
            "Network Administrator",
            "HR Manager",
            "Stocker",
            "Clerk",
            "QA Supervisor",
            "Services Manager",
            "Master Scheduler",
            "Marketing Specialist",
            "Recruiter",
            "Maintenance Supervisor",
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

        string[] designation = new string[] { "Manager", "CFO", "Designer", "Developer", "Program Directory", "System Analyst", "Project Lead" };

        string[] location = new string[] { "UK", "USA", "Sweden", "France", "Canada", "Argentina", "Austria", "Germany", "Mexico" };

        string[] mail = new string[]
        {
            "arpy.com", "sample.com", "rpy.com", "jourrapide.com"
        };

        string[] contactNos = new string[] {
        "(833) 215-6503",
        "(855) 727-4387",
        "(844) 479-2783",
        "(855) 055-5922",
        "(899) 378-8810",
        "(833) 389-76618",
        "(855) 313-1072",
        "(899) 287-1193",
        "(844) 613-4240",
        "(833) 293-9651",
        "(899) 751-7249",
        "(833) 266-3598",
        "(855) 117-36707",
        "(811) 638-39931",
        "(833) 444-7832",
        "(899) 995-59379",
        "(899) 544-1240",
        "(811) 892-78532",
        "(844) 080-8130",
        "(899) 256-2942"
        };
        string[] cityNames = new string[]
        {
            "Candelaria",
            "McGuffey",
            "Daguao",
            "Driscoll",
            "Lake Wylie",
            "Evans Mills",
            "Maumelle",
            "Ripley",
            "Talbotton",
            "Makakilo",
            "Lorain",
            "Chunchula",
            "Newburg",
            "Joiner",
            "Fort Atkinson",
            "Matawan",
            "Council",
            "Copenhagen",
            "Sciotodale"
        };

        string[] names = new string[]
        {
            "Hatomlor", "Anech",    "Polormundara", "Omemiaore-Yon",    "Moreng",   "Sernn",    "Dariech Jhon",
"Vesrisum", "Tai'aty",  "Omat", "Drashther",    "Umm-que",  "Kinyer",   "Orothe",
"Belawpol", "Sedlor*",  "Orgar",    "Serem",    "Oslory",   "Isia"

        };

        #region Cut

        private DelegateCommand _gridCutCommand;

        /// <summary>
        /// Gets and sets the cut command
        /// </summary>
        public DelegateCommand GridCutCommand
        {
            get { return _gridCutCommand; }
            set { _gridCutCommand = value; }
        }

        /// <summary>
        /// Cut the specified record.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.DataGrid.GridRecordContextFlyoutInfo"/>.
        /// </param>
        public void Cut(object param)
        {
            if (param is GridRecordContextFlyoutInfo)
            {
                var grid = (param as GridRecordContextFlyoutInfo).DataGrid;
                var copypasteoption = grid.CopyOption;
                grid.CopyOption = GridCopyOptions.CutData;
                grid.ClipboardController.Cut();
                grid.CopyOption = copypasteoption;
            }
        }

        #endregion Cut

        #region Copy

        private DelegateCommand _gridCopyCommand;

        /// <summary>
        /// Gets and sets the copy command
        /// </summary>
        public DelegateCommand GridCopyCommand
        {
            get { return _gridCopyCommand; }
            set { _gridCopyCommand = value; }
        }

        /// <summary>
        /// Copy the specified record.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.DataGrid.GridRecordContextFlyoutInfo"/>.
        /// </param>
        public void Copy(object param)
        {
            if (param is GridRecordContextFlyoutInfo)
            {
                var grid = (param as GridRecordContextFlyoutInfo).DataGrid;
                grid.ClipboardController.Copy();
            }
        }

        #endregion Copy

        #region Paste

        private DelegateCommand _gridPasteCommand;

        /// <summary>
        /// Gets and sets the paste command
        /// </summary>
        public DelegateCommand GridPasteCommand
        {
            get
            {
                if (_gridPasteCommand != null)
                    _gridPasteCommand = new DelegateCommand(Paste, CanPaste);

                return _gridPasteCommand;
            }
            set { _gridPasteCommand = value; }
        }

        /// <summary>
        /// Paste the specified record.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.DataGrid.GridRecordContextFlyoutInfo"/>.
        /// </param>
        public void Paste(object param)
        {
            if (param is GridRecordContextFlyoutInfo)
            {
                var grid = (param as GridRecordContextFlyoutInfo).DataGrid;
                grid.ClipboardController.Paste();
            }
        }

        /// <summary>
        /// Determines whether the paste command can be executed.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.DataGrid.GridRecordContextMenuInfo"/>
        /// </param>
        /// <returns>
        /// <b>true</b> if the clipboard has content, Otherwise <b>false</b>
        /// </returns>
        public bool CanPaste(object param)
        {
            var content = Clipboard.GetContent();
            if (content != null && (content.Contains(StandardDataFormats.Text)))
                return true;
            return false;
        }

        #endregion Paste

        #region Delete

        private DelegateCommand _gridDeleteCommand;

        /// <summary>
        /// Gets and sets the expand command
        /// </summary>
        public DelegateCommand DeleteCommand
        {
            get
            {
                if (_gridDeleteCommand != null)
                    _gridDeleteCommand = new DelegateCommand(Delete);
                return _gridDeleteCommand;
            }
            set { _gridDeleteCommand = value; }
        }

        /// <summary>
        /// Expand the specified record in group caption menu.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.DataGrid.GridRecordContextFlyoutInfo"/>.
        /// </param>
        private void Delete(object param)
        {
            if (param is GridRecordContextFlyoutInfo)
            {
                var grid = (param as GridRecordContextFlyoutInfo).DataGrid;
                var record = (param as GridRecordContextFlyoutInfo).Record as Employee;
                if (record != null)
                    (grid.DataContext as EmployeeViewModel).Employees.Remove(record);
                grid.View.Refresh();

            }
        }

        #endregion Delete

        #region ExpandAll

        private DelegateCommand _expandAllCommand;

        /// <summary>
        /// Gets and sets the expandall command
        /// </summary>
        public DelegateCommand ExpandAllCommand
        {
            get
            {
                if (_expandAllCommand != null)
                    _expandAllCommand = new DelegateCommand(ExpandAll, CanExpandAll);
                return _expandAllCommand;
            }
            set { _expandAllCommand = value; }
        }

        /// <summary>
        /// Expand all groups in datagrid.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.DataGrid.GridContextMenuInfo"/>.
        /// </param>
        public void ExpandAll(object param)
        {
            if (param is Syncfusion.UI.Xaml.DataGrid.GridContextFlyoutInfo)
            {
                var grid = (param as Syncfusion.UI.Xaml.DataGrid.GridContextFlyoutInfo).DataGrid;
                grid.ExpandAllGroup();
            }
        }

        /// <summary>
        /// Determines whether the Expand all command can be executed..
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.DataGrid.GridContextFlyoutInfo"/>.
        /// </param>
        /// <returns>
        /// <b>true</b> if the Specified datagrid can expand, Otherwise <b>false</b>
        /// </returns>
        public bool CanExpandAll(object param)
        {
            if (param is Syncfusion.UI.Xaml.DataGrid.GridContextFlyoutInfo)
            {
                var grid = (param as Syncfusion.UI.Xaml.DataGrid.GridContextFlyoutInfo).DataGrid;
                if (grid.View.TopLevelGroup != null && grid.View.TopLevelGroup.Groups.Count > 0)
                    return grid.View.TopLevelGroup.Groups.Any(x => !x.IsExpanded);
            }
            return false;
        }

        #endregion ExpandAll

        #region CollapseAll

        private DelegateCommand _collapseAllCommand;

        /// <summary>
        /// Gets and sets the remove command
        /// </summary>
        public DelegateCommand CollapseAllCommand
        {
            get
            {
                if (_collapseAllCommand != null)
                    _collapseAllCommand = new DelegateCommand(CollapseAll, CanCollapseAll);

                return _collapseAllCommand;
            }
            set { _collapseAllCommand = value; }
        }

        /// <summary>
        /// Collapse all groups in datagrid.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.DataGrid.GridContextFlyoutInfo"/>.
        /// </param>
        public void CollapseAll(object param)
        {
            if (param is GridContextFlyoutInfo)
            {
                var grid = (param as GridContextFlyoutInfo).DataGrid;
                grid.CollapseAllGroup();
            }
        }

        /// <summary>
        /// Determines whether the collapse all command can be executed.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.DataGrid.GridContextMenuInfo"/>.
        /// </param>
        /// <returns>
        /// <b>true</b> if the specified datagrid can collapse,Otherwise <b>false</b>
        /// </returns>
        private bool CanCollapseAll(object param)
        {
            if (param is Syncfusion.UI.Xaml.DataGrid.GridContextFlyoutInfo)
            {
                var grid = (param as Syncfusion.UI.Xaml.DataGrid.GridContextFlyoutInfo).DataGrid;
                if (grid.View.TopLevelGroup != null && grid.View.TopLevelGroup.Groups.Count > 0)
                    return grid.View.TopLevelGroup.Groups.Any(x => x.IsExpanded);
            }
            return false;
        }

        #endregion CollapseAll

        #region SortAscending

        private DelegateCommand _sortAscendingCommand;

        /// <summary>
        /// Gets and sets the sort ascending command
        /// </summary>
        public DelegateCommand SortAscendingCommand
        {
            get
            {
                if (_sortAscendingCommand != null)
                    _sortAscendingCommand = new DelegateCommand(SortAscending, CanSortAscending);

                return _sortAscendingCommand;
            }
            set { _sortAscendingCommand = value; }
        }

        /// <summary>
        /// Sort the specific column in ascending order.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.DataGrid.GridColumnContextFlyoutInfo"/>.
        /// </param>
        private void SortAscending(object param)
        {
            if (param is GridColumnContextFlyoutInfo)
            {
                var grid = (param as GridContextFlyoutInfo).DataGrid;
                var column = (param as GridColumnContextFlyoutInfo).Column;
                grid.SortColumnDescriptions.Clear();
                grid.SortColumnDescriptions.Add(new SortColumnDescription() { ColumnName = column.MappingName, SortDirection = ListSortDirection.Ascending });
            }
        }

        /// <summary>
        /// Determines whether the sort ascending command can be executed.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.DataGrid.GridColumnContextFlyoutInfo"/>.
        /// </param>
        /// <returns>
        /// <b>true</b> if the specific column can be sort in ascending order, Otherwise<b>false</b>
        /// </returns>
        private static bool CanSortAscending(object param)
        {
            if (param is GridColumnContextFlyoutInfo)
            {
                var grid = (param as GridContextFlyoutInfo).DataGrid;
                var column = (param as GridColumnContextFlyoutInfo).Column;
                var sortColumn = grid.SortColumnDescriptions.FirstOrDefault(x => x.ColumnName == column.MappingName);
                if (sortColumn != null)
                {
                    if ((sortColumn as SortColumnDescription).SortDirection == ListSortDirection.Ascending)
                        return false;
                }
                return grid.AllowSorting;
            }
            return false;
        }

        #endregion SortAscending

        #region SortDescending

        private DelegateCommand _sortDescendingCommand;

        /// <summary>
        /// Gets and sets the sort descending command
        /// </summary>
        public DelegateCommand SortDescendingCommand
        {
            get
            {
                if (_sortDescendingCommand != null)
                    _sortDescendingCommand = new DelegateCommand(SortDescending, CanSortDescending);

                return _sortDescendingCommand;
            }
            set { _sortDescendingCommand = value; }
        }

        /// <summary>
        /// Sort the specified column in descending order.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.DataGrid.GridColumnContextFlyoutInfo"/>.
        /// </param>
        private void SortDescending(object param)
        {
            if (param is GridColumnContextFlyoutInfo)
            {
                var grid = (param as GridContextFlyoutInfo).DataGrid;
                var column = (param as GridColumnContextFlyoutInfo).Column;
                grid.SortColumnDescriptions.Clear();
                grid.SortColumnDescriptions.Add(new SortColumnDescription() { ColumnName = column.MappingName, SortDirection = ListSortDirection.Descending });
            }
        }

        /// <summary>
        /// Determines whether the sort descending command can be executed.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.DataGrid.GridColumnContextFlyoutInfo"/>.
        /// </param>
        /// <returns>
        ///  <b>true</b> if the specific column can be sort in descending order, Otherwise<b>false</b>
        /// </returns>
        private bool CanSortDescending(object param)
        {
            if (param is GridColumnContextFlyoutInfo)
            {
                var grid = (param as GridContextFlyoutInfo).DataGrid;
                var column = (param as GridColumnContextFlyoutInfo).Column;
                var sortColumn = grid.SortColumnDescriptions.FirstOrDefault(x => x.ColumnName == column.MappingName);
                if (sortColumn != null)
                {
                    if ((sortColumn as SortColumnDescription).SortDirection == ListSortDirection.Descending)
                        return false;
                }
                return grid.AllowSorting;
            }
            return false;
        }

        #endregion SortDescending

        #region clearSummary

        private DelegateCommand _clearSummaryCommand;

        /// <summary>
        /// Gets and sets the clear summary command
        /// </summary>
        public DelegateCommand ClearSummaryCommand
        {
            get { return _clearSummaryCommand; }
            set { _clearSummaryCommand = value; }
        }

        /// <summary>
        /// Clears group summary from each group.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.DataGrid.GridRecordContextMenuInfo"/>.
        /// </param>
        private void ClearSummary(object param)
        {
            if (param is GridRecordContextFlyoutInfo)
            {
                var grid = (param as GridRecordContextFlyoutInfo).DataGrid;
                if (grid.GroupSummaryRows.Any())
                    grid.GroupSummaryRows.Clear();
            }
        }

        #endregion clearSummary

        #region GroupColumn

        private DelegateCommand _groupColumnCommand;

        /// <summary>
        /// Gets and sets the group column command
        /// </summary>
        public DelegateCommand GroupColumnCommand
        {
            get
            {
                if (_groupColumnCommand != null)
                    _groupColumnCommand = new DelegateCommand(GroupColumn, CanGroupColumn);
                return _groupColumnCommand;
            }
            set
            {
                _groupColumnCommand = value;
            }
        }

        /// <summary>
        /// Determines whether the group column command can be executed.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.DataGrid.GridColumnContextFlyoutInfo"/>.
        /// </param>
        /// <returns>
        ///  <b>true</b> if the specific column can group, Otherwise<b>false</b>
        /// </returns>
        public bool CanGroupColumn(object param)
        {
            if (param is GridColumnContextFlyoutInfo)
            {
                var grid = (param as GridColumnContextFlyoutInfo).DataGrid;
                var column = (param as GridColumnContextFlyoutInfo).Column;
                bool canGroup = false;
                if (!grid.GroupColumnDescriptions.Any(x => x.ColumnName == column.MappingName))
                {
                    var groupcolumn = column.ReadLocalValue(GridColumn.AllowGroupingProperty);
                    if (grid.AllowGrouping)
                        canGroup = true;
                    if (groupcolumn != DependencyProperty.UnsetValue || canGroup)
                        canGroup = column.AllowGrouping;
                }
                return canGroup;
            }
            return false;
        }

        /// <summary>
        /// Group the specified column.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.DataGrid.GridColumnContextFlyoutInfo"/>.
        /// </param>
        public void GroupColumn(object param)
        {
            if (param is GridColumnContextFlyoutInfo)
            {
                var grid = (param as GridColumnContextFlyoutInfo).DataGrid;
                var column = (param as GridColumnContextFlyoutInfo).Column;
                if (!grid.GroupColumnDescriptions.Any(x => x.ColumnName == column.MappingName))
                    grid.GroupColumnDescriptions.Add(new GroupColumnDescription() { ColumnName = column.MappingName });
            }
        }

        #endregion GroupColumn

        #region ShowGroupDropArea

        private DelegateCommand _showGroupDropAreaCommand;

        /// <summary>
        /// Gets and sets the show group drop area command
        /// </summary>
        public DelegateCommand ShowGroupDropAreaCommand
        {
            get { return _showGroupDropAreaCommand; }
            set { _showGroupDropAreaCommand = value; }
        }

        /// <summary>
        /// Show group drop area of the datagrid.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.DataGrid.GridColumnContextFlyoutInfo"/>.
        /// </param>
        private void ShowGroupDropArea(object param)
        {
            if (param is GridColumnContextFlyoutInfo)
            {
                var grid = (param as GridColumnContextFlyoutInfo).DataGrid;
                grid.IsGroupDropAreaExpanded = !grid.IsGroupDropAreaExpanded;
            }
        }

        #endregion ShowGroupDropArea

        #region ClearSorting

        private DelegateCommand _clearSortingCommand;

        /// <summary>
        /// Gets and sets the clear sorting command
        /// </summary>
        public DelegateCommand ClearSortingCommand
        {
            get
            {
                if (_clearSortingCommand != null)
                    _clearSortingCommand = new DelegateCommand(ClearSorting, CanClearSorting);
                return _clearSortingCommand;
            }
            set
            {
                _groupColumnCommand = value;
            }
        }

        /// <summary>
        /// Clears sorting from specified column.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.DataGrid.GridColumnContextFlyoutInfo"/>.
        /// </param>
        private void ClearSorting(object param)
        {
            if (param is GridColumnContextFlyoutInfo)
            {
                var grid = (param as GridContextFlyoutInfo).DataGrid;
                var column = (param as GridColumnContextFlyoutInfo).Column;
                if (grid.SortColumnDescriptions.Any(x => x.ColumnName == column.MappingName))
                    grid.SortColumnDescriptions.Remove(grid.SortColumnDescriptions.FirstOrDefault(x => x.ColumnName == column.MappingName));
            }
        }

        /// <summary>
        /// Determines whether the clear sorting command can be executed.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.DataGrid.GridColumnContextFlyoutInfo"/>.
        /// </param>
        /// <returns>
        ///  <b>true</b> if the specific column sorted, Otherwise<b>false</b>
        /// </returns>
        private bool CanClearSorting(object param)
        {
            if (param == null)
                return false;

            var grid = (param as GridColumnContextFlyoutInfo).DataGrid;
            var column = (param as GridColumnContextFlyoutInfo).Column;
            return grid.SortColumnDescriptions.Any(x => x.ColumnName == column.MappingName);
        }

        #endregion ClearSorting

        #region ClearFiltering

        private DelegateCommand _clearFilteringCommand;

        /// <summary>
        /// Gets and sets the clear filtering command
        /// </summary>
        public DelegateCommand ClearFilteringCommand
        {
            get
            {
                if (_clearFilteringCommand != null)
                    _clearFilteringCommand = new DelegateCommand(ClearFiltering, CanClearFiltering);
                return _clearFilteringCommand;
            }
            set
            {
                _clearFilteringCommand = value;
            }
        }

        /// <summary>
        /// Clears filter from specified column.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.DataGrid.GridColumnContextFlyoutInfo"/>.
        /// </param>
        private void ClearFiltering(object param)
        {
            if (param is GridColumnContextFlyoutInfo)
            {
                var column = (param as GridColumnContextFlyoutInfo).Column;
                if (column.FilterPredicates.Any())
                    column.FilterPredicates.Clear();
            }
        }

        /// <summary>
        /// Determines whether the clear filtering command can be executed.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.DataGrid.GridColumnContextFlyoutInfo"/>.
        /// </param>
        /// <returns>
        ///  <b>true</b> if the specific column filtered, Otherwise<b>false</b>
        /// </returns>
        private bool CanClearFiltering(object param)
        {
            if (param is GridColumnContextFlyoutInfo)
            {
                var column = (param as GridColumnContextFlyoutInfo).Column;
                return column.FilterPredicates.Any();
            }
            return false;
        }

        #endregion ClearFiltering

        #region Filtering
        internal delegate void FilterChanged();
        internal FilterChanged filterChanged;

        private bool MakeStringFilter(Employee o, string option, string condition)
        {
            var value = (o.GetType().GetTypeInfo()).GetDeclaredProperty(option);
            var exactValue = value.GetValue(o);
            exactValue = exactValue.ToString().ToLower();
            string text = FilterText.ToLower();
            var methods = (typeof(string).GetTypeInfo()).GetDeclaredMethods(condition);
            if (methods.Count() != 0)
            {
                var methodInfo = methods.FirstOrDefault();
                bool result1 = (bool)methodInfo.Invoke(exactValue, new object[] { text });
                return result1;
            }
            else
                return false;
        }

        private bool MakeNumericFilter(Employee o, string option, string condition)
        {
            var value = (o.GetType().GetTypeInfo()).GetDeclaredProperty(option);
            var exactValue = value.GetValue(o);
            double res;
            bool checkNumeric = double.TryParse(exactValue.ToString(), out res);
            if (checkNumeric)
            {
                switch (condition)
                {
                    case "Equals":
                        if (Convert.ToDouble(exactValue) == (Convert.ToDouble(FilterText)))
                            return true;
                        break;
                    case "Greater Than":
                        if (Convert.ToDouble(exactValue) > Convert.ToDouble(FilterText))
                            return true;
                        break;
                    case "Less Than":
                        if (Convert.ToDouble(exactValue) < Convert.ToDouble(FilterText))
                            return true;
                        break;
                    case "Not Equals":
                        if (Convert.ToDouble(FilterText) != Convert.ToDouble(exactValue))
                            return true;
                        break;
                }
            }
            return false;
        }

        public bool FilerRecords(object o)
        {
            double res;
            bool checkNumeric = double.TryParse(FilterText, out res);
            var item = o as Employee;
            if (item != null && FilterText.Equals(""))
            {
                return true;
            }
            else
            {
                if (item != null)
                {
                    if (checkNumeric && !FilterOption.Equals("AllColumns"))
                    {
                        if (FilterCondition == null || FilterCondition.Equals("Contains") || FilterCondition.Equals("StartsWith") || FilterCondition.Equals("EndsWith"))
                            FilterCondition = "Equals";
                        bool result = MakeNumericFilter(item, FilterOption, FilterCondition);
                        return result;
                    }
                    else if (FilterOption.Equals("AllColumns"))
                    {
                        if (item.Name.ToLower().Contains(FilterText.ToLower()) ||
                            item.Title.ToLower().Contains(FilterText.ToLower()) ||
                            item.Salary.ToString().ToLower().Contains(FilterText.ToLower()) ||
                            item.EmployeeID.ToString().ToLower().Contains(FilterText.ToLower()) ||
                            item.Age.ToString().ToLower().Contains(FilterText.ToLower()) ||
                            item.Designation.ToString().ToLower().Contains(FilterText.ToLower()) ||
                            item.MaritalStatus.ToString().ToLower().Contains(FilterText.ToLower()) ||
                            item.Location.ToString().ToLower().Contains(FilterText.ToLower()) ||
                            item.Gender.ToLower().Contains(FilterText.ToLower()))
                            return true;
                        return false;
                    }
                    else
                    {
                        if (FilterCondition == null || FilterCondition.Equals("Equals") || FilterCondition.Equals("Less Than") || FilterCondition.Equals("Greater Than") || FilterCondition.Equals("Not Equals"))
                            FilterCondition = "Contains";
                        bool result = MakeStringFilter(item, FilterOption, FilterCondition);
                        return result;
                    }
                }
            }
            return false;
        }

        private string filterOption = "AllColumns";

        /// <summary>
        /// Get or set the FilterOption
        /// </summary>
        public string FilterOption
        {
            get { return filterOption; }
            set
            {
                filterOption = value.Replace(" ", "");
                if (filterChanged != null)
                    filterChanged();
                OnPropertyChanged("FilterOption");
            }
        }

        private string filterText = string.Empty;
        /// <summary>
        /// Get or set the FilterText
        /// </summary>
        public string FilterText
        {
            get { return filterText; }
            set
            {
                filterText = value;
                OnPropertyChanged("FilterText");
            }
        }

        private string filterCondition;
        /// <summary>
        /// Get or set the FilterCondition
        /// </summary>
        public string FilterCondition
        {
            get { return filterCondition; }
            set
            {
                filterCondition = value;
                OnPropertyChanged("FilterCondition");
            }
        }

        #endregion
        #region ClearGroups

        private DelegateCommand _clearGroupingCommand;

        /// <summary>
        /// Gets and sets the clear groups command
        /// </summary>
        public DelegateCommand ClearGroupingCommand
        {
            get
            {
                if (_clearGroupingCommand != null)
                    _clearGroupingCommand = new DelegateCommand(ClearGrouping, CanClearGrouping);
                return _clearGroupingCommand;
            }
            set
            {
                _clearGroupingCommand = value;
            }
        }

        /// <summary>
        /// Clear all groups from datagrid.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.DataGrid.GridContextFlyoutInfo"/>.
        /// </param>
        private void ClearGrouping(object param)
        {
            if (param is GridContextFlyoutInfo)
            {
                var grid = (param as GridContextFlyoutInfo).DataGrid;
                grid.GroupColumnDescriptions.Clear();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.DataGrid.GridContextFlyoutInfo"/>.
        /// </param>
        /// <returns></returns>
        private bool CanClearGrouping(object param)
        {
            if (param is GridContextFlyoutInfo)
            {
                var grid = (param as GridContextFlyoutInfo).DataGrid;
                return grid.GroupColumnDescriptions.Any();
            }
            return false;
        }

        #endregion ClearGroups

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
            GridCutCommand = null;
            GridCopyCommand = null;
            GridPasteCommand = null;
            DeleteCommand = null;
            ExpandAllCommand = null;
            CollapseAllCommand = null;
            SortAscendingCommand = null;
            SortDescendingCommand = null;
            ClearSummaryCommand = null;
            GroupColumnCommand = null;
            ShowGroupDropAreaCommand = null;
            ClearSortingCommand = null;
            ClearFilteringCommand = null;
            ClearGroupingCommand = null;
            if (Employees != null)
            {
                foreach (var employee in Employees)
                    (employee as Employee).Dispose();
                Employees.Clear();
            }

            if (TitleCollection != null)
                TitleCollection.Clear();
        }
    }

}
