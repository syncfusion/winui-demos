#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Syncfusion.UI.Xaml.Core;
using Syncfusion.UI.Xaml.DataGrid;
using Syncfusion.UI.Xaml.TreeGrid;
using Syncfusion.UI.Xaml.TreeGrid.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListSortDirection = Syncfusion.UI.Xaml.Data.SortDirection;
using Windows.ApplicationModel.DataTransfer;
using System.Collections;
using TreeGrid;
using Syncfusion.UI.Xaml.Grids;

namespace TreeGrid
{
    public class PersonViewModel : IDisposable
    {
        private static Random random = new Random(123123);
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public PersonViewModel()
        {
            _gridCutCommand = new DelegateCommand(Cut);
            _gridCopyCommand = new DelegateCommand(Copy);
            _gridPasteCommand = new DelegateCommand(Paste);
            _gridDeleteCommand = new DelegateCommand(Delete);
            _expandCommand = new DelegateCommand(Expand);
            _collapseCommand = new DelegateCommand(Collapse);
            _sortAscendingCommand = new DelegateCommand(SortAscending);
            _sortDescendingCommand = new DelegateCommand(SortDescending);
            _clearSortingCommand = new DelegateCommand(ClearSorting);
            _bestFitCommand = new DelegateCommand(BestFit);
            _addAboveCommand = new DelegateCommand(AddAbove);
            _addBelowCommand = new DelegateCommand(AddBelow);
            _addAsChildCommand = new DelegateCommand(AddAsChild);

            persons = this.CreateGenericPersonData(5, 8);
            cityCollection = new ObservableCollection<string>();
            foreach (var item in city)
            {
                CityCollection.Add(item);
            }
        }

        private ObservableCollection<Person> persons;

        /// <summary>
        /// Gets or sets the person details.
        /// </summary>
        /// <value>The person details.</value>
        public ObservableCollection<Person> Persons
        {
            get { return persons; }
        }

        private ObservableCollection<string> cityCollection;

        public ObservableCollection<string> CityCollection
        {
            get { return cityCollection; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="maxGenerations">The max generations.</param>
        public PersonViewModel(int count, int maxGenerations)
        {
            CreateGenericPersonData(count, maxGenerations);
        }

        /// <summary>
        /// Creates the child list.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="maxGenerations">The max generations.</param>
        /// <param name="lastName">The last name.</param>
        /// <returns></returns>
        public ObservableCollection<Person> CreateChildList(int count, int maxGenerations)
        {
            ObservableCollection<Person> _children = new ObservableCollection<Person>();
            if (count > 0 && maxGenerations > 0)
            {
                _children = CreateGenericPersonData(count, maxGenerations - 1);
            }
            return _children;
        }

        /// <summary>
        /// Creates the generic person data.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="maxGenerations">The max generations.</param>
        /// <returns></returns>
        public ObservableCollection<Person> CreateGenericPersonData(int count, int maxGenerations)
        {
            var personList = new ObservableCollection<Person>();
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    var contactNo = contactNos[random.Next(0, contactNos.Count() - 1)];
                    var lastname = names2[random.Next(names2.GetLength(0))];
                    var emailId = names[random.Next(names.Length - 1)] + "@" + mail[random.Next(0, mail.Count() - 1)];
                    personList.Add(new Person(names1[random.Next(names1.GetLength(0))], lastname, new DateTime(random.Next(2008, 2012), random.Next(1, 12), random.Next(1, 28)), 30000d + random.Next(9) * 10000, city[random.Next(city.GetLength(0))], contactNo, emailId, this.CreateChildList(count, (int)Math.Max(0, maxGenerations - 1))));
                }
            }
            return personList;
        }

        #region Array Collection

        string[] city = new string[]
        {
            "NewYork",
            "San Francisco",
            "Delhi",
            "Brisbane",
            "Tokyo",
            "Rome",
            "Durban",
            "Canberra",
            "Sydney",
            "London",
            "Manchester",
            "Birmingham",
            "Liverpool",
            "Cardiff",
            "Adelaide",
            "Perth",
            "Zurich",
            "Madrid",
            "Barcelona"
        };

        private static string[] names1 = new string[]{
            "George","John","Thomas","James","Andrew","Martin","William","Zachary",
            "Millard","Franklin","Abraham","Ulysses","Rutherford","Chester","Grover","Benjamin",
            "Theodore","Woodrow","Warren","Calvin","Herbert","Franklin","Harry","Dwight","Lyndon",
            "Richard","Gerald","Jimmy","Ronald","George","Bill", "Barack", "Warner","Peter", "Larry"
        };

        private static string[] names2 = new string[]{
             "Washington","Adams","Jefferson","Madison","Monroe","Jackson","Van Buren","Harrison","Tyler",
             "Polk","Taylor","Fillmore","Pierce","Buchanan","Lincoln","Johnson","Grant","Hayes","Garfield",
             "Arthur","Cleveland","Harrison","McKinley","Roosevelt","Taft","Wilson","Harding","Coolidge",
             "Hoover","Truman","Eisenhower","Kennedy","Johnson","Nixon","Ford","Carter","Reagan","Bush",
             "Clinton","Bush","Obama","Smith","Jones","Stogner"
        };

        string[] mail = new string[]
        {
            "arpy.com", "sample.com", "rpy.com", "jourrapide.com"
        };

        string[] names = new string[]
        {
            "Hatomlor", "Anech",    "Polormundara", "Omemiaore-Yon",    "Moreng",   "Sernn",    "Dariech Jhon",
            "Vesrisum", "Tai'aty",  "Omat", "Drashther",    "Umm-que",  "Kinyer",   "Orothe",
            "Belawpol", "Sedlor*",  "Orgar",    "Serem",    "Oslory",   "Isia"
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

        #endregion

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
        /// Specifies the <see cref="Syncfusion.UI.Xaml.TreeGrid.TreeGridNodeContextFlyoutInfo"/>.
        /// </param>
        public void Cut(object param)
        {
            if (param is TreeGridNodeContextFlyoutInfo)
            {
                var grid = (param as TreeGridNodeContextFlyoutInfo).TreeGrid;
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
        /// Specifies the <see cref="Syncfusion.UI.Xaml.TreeGrid.TreeGridNodeContextFlyoutInfo"/>.
        /// </param>
        public void Copy(object param)
        {
            if (param is TreeGridNodeContextFlyoutInfo)
            {
                var grid = (param as TreeGridNodeContextFlyoutInfo).TreeGrid;
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
        /// Specifies the <see cref="Syncfusion.UI.Xaml.TreeGrid.TreeGridNodeContextFlyoutInfo"/>.
        /// </param>
        public void Paste(object param)
        {
            if (param is TreeGridNodeContextFlyoutInfo)
            {
                var grid = (param as TreeGridNodeContextFlyoutInfo).TreeGrid;
                grid.ClipboardController.Paste();
            }
        }

        /// <summary>
        /// Determines whether the paste command can be executed.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.TreeGrid.TreeGridNodeContextMenuInfo"/>
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
        /// Gets and sets the delete command
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
        /// Delete the specified record.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.TreeGrid.TreeGridNodeContextFlyoutInfo"/>.
        /// </param>
        private void Delete(object param)
        {
            if (param is TreeGridNodeContextFlyoutInfo)
            {
                var grid = (param as TreeGridNodeContextFlyoutInfo).TreeGrid;
                var record = (param as TreeGridNodeContextFlyoutInfo).TreeNode.Item as Person;
                if (record != null)
                    (grid.DataContext as PersonViewModel).Persons.Remove(record);
                grid.View.Refresh();
            }
        }

        #endregion Delete

        #region Expand

        private DelegateCommand _expandCommand;

        /// <summary>
        /// Gets and sets the expand command
        /// </summary>
        public DelegateCommand ExpandCommand
        {
            get
            {
                if (_expandCommand != null)
                    _expandCommand = new DelegateCommand(Expand, CanExpand);
                return _expandCommand;
            }
            set { _expandCommand = value; }
        }

        /// <summary>
        /// Expand node in treegrid.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.TreeGrid.TreeGridNodeContextFlyoutInfo"/>.
        /// </param>
        public void Expand(object param)
        {
            var contextMenuInfo = param as TreeGridNodeContextFlyoutInfo;
            if (contextMenuInfo == null)
                return;
            var grid = contextMenuInfo.TreeGrid;
            grid.ExpandNode(contextMenuInfo.TreeNode);            
        }

        /// <summary>
        /// Determines whether the Expand command can be executed..
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.TreeGrid.TreeGridNodeContextFlyoutInfo"/>.
        /// </param>
        /// <returns>
        /// <b>true</b> if the Specified treegrid can expand, Otherwise <b>false</b>
        /// </returns>
        public bool CanExpand(object param)
        {
            var contextMenuInfo = param as TreeGridNodeContextFlyoutInfo;
            if (contextMenuInfo == null)
                return false;            
            var node = contextMenuInfo.TreeNode;
            return !node.IsExpanded;            
        }

        #endregion Expand

        #region Collapse

        private DelegateCommand _collapseCommand;

        /// <summary>
        /// Gets and sets the collapse command
        /// </summary>
        public DelegateCommand CollapseCommand
        {
            get
            {
                if (_collapseCommand != null)
                    _collapseCommand = new DelegateCommand(Collapse, CanCollapse);

                return _collapseCommand;
            }
            set { _collapseCommand = value; }
        }

        /// <summary>
        /// Collapse node in treegrid.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.TreeGrid.TreeGridNodeContextFlyoutInfo"/>.
        /// </param>
        public void Collapse(object param)
        {
            var contextMenuInfo = param as TreeGridNodeContextFlyoutInfo;
            if (contextMenuInfo == null)
                return;
            var grid = contextMenuInfo.TreeGrid;
            var node = contextMenuInfo.TreeNode;
            grid.CollapseNode(node);           
        }

        /// <summary>
        /// Determines whether the collapse command can be executed.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.TreeGrid.TreeGridContextFlyoutInfo"/>.
        /// </param>
        /// <returns>
        /// <b>true</b> if the specified treegrid can collapse, Otherwise <b>false</b>
        /// </returns>
        private bool CanCollapse(object param)
        {
            var contextMenuInfo = param as TreeGridNodeContextFlyoutInfo;
            if (contextMenuInfo == null)
                return false;            
            var treeNode = contextMenuInfo.TreeNode;
            return treeNode.IsExpanded;            
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
        /// Specifies the <see cref="Syncfusion.UI.Xaml.TreeGrid.TreeGridColumnContextFlyoutInfo"/>.
        /// </param>
        private void SortAscending(object param)
        {
            var contextMenuInfo = param as TreeGridColumnContextFlyoutInfo;
            if (contextMenuInfo == null)
                return;
            var grid = contextMenuInfo.TreeGrid;
            var column = contextMenuInfo.Column;
            if (grid.SortColumnDescriptions != null)
            {
                grid.SortColumnDescriptions.Clear();
                grid.SortColumnDescriptions.Add(new SortColumnDescription() { ColumnName = column.MappingName, SortDirection = ListSortDirection.Ascending });
            }            
        }

        /// <summary>
        /// Determines whether the sort ascending command can be executed.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.TreeGrid.TreeGridColumnContextFlyoutInfo"/>.
        /// </param>
        /// <returns>
        /// <b>true</b> if the specific column can be sort in ascending order, Otherwise<b>false</b>
        /// </returns>
        private static bool CanSortAscending(object param)
        {
            var contextMenuInfo = param as TreeGridColumnContextFlyoutInfo;
            if (contextMenuInfo == null)
                return false;
            var grid = contextMenuInfo.TreeGrid;
            var column = contextMenuInfo.Column;
            if (grid.SortColumnDescriptions != null)
            {
                var sortColumn = grid.SortColumnDescriptions.FirstOrDefault(x => x.ColumnName == column.MappingName);
                if (sortColumn != null)
                {
                    if ((sortColumn as SortColumnDescription).SortDirection == ListSortDirection.Ascending)
                        return false;
                }
            }
            return grid.AllowSorting;            
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
        /// Specifies the <see cref="Syncfusion.UI.Xaml.TreeGrid.TreeGridColumnContextFlyoutInfo"/>.
        /// </param>
        private void SortDescending(object param)
        {
            var contextMenuInfo = param as TreeGridColumnContextFlyoutInfo;
            if (contextMenuInfo == null)
                return;
            var grid = contextMenuInfo.TreeGrid;
            var column = contextMenuInfo.Column;
            if (grid.SortColumnDescriptions != null)
            {
                grid.SortColumnDescriptions.Clear();
                grid.SortColumnDescriptions.Add(new SortColumnDescription() { ColumnName = column.MappingName, SortDirection = ListSortDirection.Descending });
            }            
        }

        /// <summary>
        /// Determines whether the sort descending command can be executed.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.TreeGrid.TreeGridColumnContextFlyoutInfo"/>.
        /// </param>
        /// <returns>
        ///  <b>true</b> if the specific column can be sort in descending order, Otherwise<b>false</b>
        /// </returns>
        private bool CanSortDescending(object param)
        {
            var contextMenuInfo = param as TreeGridColumnContextFlyoutInfo;
            if (contextMenuInfo == null)
                return false;
            var grid = contextMenuInfo.TreeGrid;
            var column = contextMenuInfo.Column;
            if (grid.SortColumnDescriptions != null)
            {
                var sortColumn = grid.SortColumnDescriptions.FirstOrDefault(x => x.ColumnName == column.MappingName);
                if (sortColumn != null)
                {
                    if ((sortColumn as SortColumnDescription).SortDirection == ListSortDirection.Descending)
                        return false;
                }
            }
            return grid.AllowSorting;            
        }

        #endregion SortDescending
        
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
                _clearSortingCommand = value;
            }
        }

        /// <summary>
        /// Clears sorting from specified column.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.TreeGrid.TreeGridColumnContextFlyoutInfo"/>.
        /// </param>
        private void ClearSorting(object param)
        {
            var contextMenuInfo = param as TreeGridColumnContextFlyoutInfo;
            if (contextMenuInfo == null)
                return;

            var grid = contextMenuInfo.TreeGrid;
            var column = contextMenuInfo.Column;
            if (grid.SortColumnDescriptions != null && grid.SortColumnDescriptions.Any(x => x.ColumnName == column.MappingName))
                grid.SortColumnDescriptions.Remove(grid.SortColumnDescriptions.FirstOrDefault(x => x.ColumnName == column.MappingName));            
        }

        /// <summary>
        /// Determines whether the clear sorting command can be executed.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.TreeGrid.TreeGridColumnContextFlyoutInfo"/>.
        /// </param>
        /// <returns>
        ///  <b>true</b> if the specific column sorted, Otherwise<b>false</b>
        /// </returns>
        private bool CanClearSorting(object param)
        {
            if (param == null)
                return false;
            var contextMenuInfo = param as TreeGridColumnContextFlyoutInfo;
            var grid = contextMenuInfo.TreeGrid;
            var column = contextMenuInfo.Column;
            if (grid.SortColumnDescriptions == null)
                return false;

            return grid.SortColumnDescriptions.Any(x => x.ColumnName == column.MappingName);            
        }

        #endregion ClearSorting

        #region BestFit

        private DelegateCommand _bestFitCommand;

        /// <summary>
        /// Gets and sets the bestfit command
        /// </summary>
        public DelegateCommand BestFitCommand
        {
            get
            {
                if (_bestFitCommand != null)
                    _bestFitCommand = new DelegateCommand(BestFit);
                return _bestFitCommand;
            }
            set
            {
                _bestFitCommand = value;
            }
        }

        /// <summary>
        /// Best fit from specified column.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.TreeGrid.TreeGridColumnContextFlyoutInfo"/>.
        /// </param>
        private void BestFit(object param)
        {
            var contextMenuInfo = param as TreeGridColumnContextFlyoutInfo;
            if (contextMenuInfo == null)
                return;            
            var column = contextMenuInfo.Column;
            column.ColumnSizer = Syncfusion.UI.Xaml.Grids.ColumnWidthMode.Auto;
        }

        #endregion BestFit

        #region AddAbove

        private DelegateCommand _addAboveCommand;

        /// <summary>
        /// Gets and sets the add above command
        /// </summary>
        public DelegateCommand AddAboveCommand
        {
            get
            {
                if (_addAboveCommand != null)
                    _addAboveCommand = new DelegateCommand(AddAbove);
                return _addAboveCommand;
            }
            set
            {
                _addAboveCommand = value;
            }
        }

        /// <summary>
        /// Add above the data in treegrid.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.TreeGrid.TreeGridColumnContextFlyoutInfo"/>.
        /// </param>
        private void AddAbove(object param)
        {
            var contextMenuInfo = param as TreeGridNodeContextFlyoutInfo;
            if (contextMenuInfo == null)
                return;
            Random random = new Random(123123);
            var treeGrid = contextMenuInfo.TreeGrid;
            var treeNode = contextMenuInfo.TreeNode;
            var parentNode = treeNode.ParentNode;
            var item = treeNode.Item as Person;
            var newItem = new Person() { FirstName = names1[random.Next(names1.GetLength(0))], Children = new System.Collections.ObjectModel.ObservableCollection<Person>(), LastName = names2[random.Next(names2.GetLength(0))], DOJ = new DateTime(random.Next(2008, 2012), random.Next(1, 12), random.Next(1, 28)), Salary = 30000d + random.Next(9) * 10000, City = city[random.Next(city.GetLength(0))], ContactNumber = contactNos[random.Next(0, contactNos.Count() - 1)], EMail = names[random.Next(names.Length - 1)] + "@" + mail[random.Next(0, mail.Count() - 1)] };
            IList collection = null;
            if (treeNode.ParentNode != null)
            {
                collection = treeGrid.View.GetPropertyAccessProvider().GetValue(parentNode.Item, treeGrid.ChildPropertyName) as IList;
            }
            else
                collection = treeGrid.ItemsSource as IList;

            var itemIndex = collection.IndexOf(item);
            collection.Insert(itemIndex, newItem);
        }

        #endregion AddAbove

        #region AddBelow

        private DelegateCommand _addBelowCommand;

        /// <summary>
        /// Gets and sets the add below command
        /// </summary>
        public DelegateCommand AddBelowCommand
        {
            get
            {
                if (_addBelowCommand != null)
                    _addBelowCommand = new DelegateCommand(AddBelow);
                return _addBelowCommand;
            }
            set
            {
                _addBelowCommand = value;
            }
        }

        /// <summary>
        /// Add below the data in treegrid.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.TreeGrid.TreeGridNodeContextFlyoutInfo"/>.
        /// </param>
        private void AddBelow(object param)
        {
            var contextMenuInfo = param as TreeGridNodeContextFlyoutInfo;
            if (contextMenuInfo == null)
                return;
            Random random = new Random(123123);
            var treeGrid = contextMenuInfo.TreeGrid;
            var treeNode = contextMenuInfo.TreeNode;
            var parentNode = treeNode.ParentNode;
            var item = treeNode.Item as Person;
            var newItem = new Person() { FirstName = names1[random.Next(names1.GetLength(0))], Children = new System.Collections.ObjectModel.ObservableCollection<Person>(), LastName = names2[random.Next(names2.GetLength(0))], DOJ = new DateTime(random.Next(2008, 2012), random.Next(1, 12), random.Next(1, 28)), Salary = 30000d + random.Next(9) * 10000, City = city[random.Next(city.GetLength(0))], ContactNumber = contactNos[random.Next(0, contactNos.Count() - 1)], EMail = names[random.Next(names.Length - 1)] + "@" + mail[random.Next(0, mail.Count() - 1)] };
            IList collection = null;
            if (treeNode.ParentNode != null)
            {
                collection = treeGrid.View.GetPropertyAccessProvider().GetValue(parentNode.Item, treeGrid.ChildPropertyName) as IList;
            }
            else
                collection = treeGrid.ItemsSource as IList;

            var itemIndex = collection.IndexOf(item);

            collection.Insert(itemIndex + 1, newItem);
        }

        #endregion AddBelow

        #region AddAsChild

        private DelegateCommand _addAsChildCommand;

        /// <summary>
        /// Gets and sets the addaschild command
        /// </summary>
        public DelegateCommand AddAsChildCommand
        {
            get
            {
                if (_addAsChildCommand != null)
                    _addAsChildCommand = new DelegateCommand(AddAsChild);
                return _addAsChildCommand;
            }
            set
            {
                _addAsChildCommand = value;
            }
        }

        /// <summary>
        /// Add as child data in treegrid.
        /// </summary>
        /// <param name="param">
        /// Specifies the <see cref="Syncfusion.UI.Xaml.TreeGrid.TreeGridNodeContextFlyoutInfo"/>.
        /// </param>
        private void AddAsChild(object param)
        {
            var contextMenuInfo = param as TreeGridNodeContextFlyoutInfo;
            if (contextMenuInfo == null)
                return;
            Random random = new Random(123123);
            var treeGrid = contextMenuInfo.TreeGrid;
            var treeNode = contextMenuInfo.TreeNode;
            var item = treeNode.Item as Person;
            var newItem = new Person() { FirstName = names1[random.Next(names1.GetLength(0))], Children = new System.Collections.ObjectModel.ObservableCollection<Person>(), LastName = names2[random.Next(names2.GetLength(0))], DOJ = new DateTime(random.Next(2008, 2012), random.Next(1, 12), random.Next(1, 28)), Salary = 30000d + random.Next(9) * 10000, City = city[random.Next(city.GetLength(0))], ContactNumber = contactNos[random.Next(0, contactNos.Count() - 1)], EMail = names[random.Next(names.Length - 1)] + "@" + mail[random.Next(0, mail.Count() - 1)] };
            var rowIndex = treeGrid.ResolveToRowIndex(treeNode);
            var collection = treeGrid.View.GetPropertyAccessProvider().GetValue(treeNode.Item, treeGrid.ChildPropertyName) as IList;

            collection.Insert(collection.Count, newItem);
            if (!treeNode.HasChildNodes)
            {
                treeGrid.ResetNode(treeNode);
                //treeGrid.UpdateDataRow(rowIndex);
            }
        }

        #endregion AddAsChild

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
            ExpandCommand = null;
            CollapseCommand = null;
            SortAscendingCommand = null;
            SortDescendingCommand = null;
            ClearSortingCommand = null;
            BestFitCommand = null;
            AddAboveCommand = null;
            AddBelowCommand = null;
            AddAsChildCommand = null;
            if (Persons != null)
            {
                Persons.Clear();
            }
        }
    }
}
