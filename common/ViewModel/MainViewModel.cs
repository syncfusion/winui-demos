#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace syncfusion.demoscommon.winui
{
    /// <summary>
    /// Represent a view model class for <see cref="MainPage"/>
    /// </summary>
    public class MainViewModel : NotificationObject
    {
        #region private variables

        private IList menuItems;
        private object selectedItem;
        private object selectedRootMenuItem;
        private string header;
        private bool isHeaderVisible;
        private ElementTheme currentTheme = ElementTheme.Default;
        private bool isThemeVisible;
        private DemoInfo demoInfo;

        #endregion private variables

        #region Properties

        /// <summary>
        /// Gets the application title.
        /// </summary>
        public static string AppTitleText
        {
            get
            {
#if WinUI_Desktop
                return string.Empty;
#else
             return "Syncfusion WinUI Project Reunion Controls Gallery (Beta)"; 
#endif
             }
        }

        /// <summary>
        /// Gets the place hold text of search text box.
        /// </summary>
        public static string SearchString
        {
            get { return Constants.SearchString; }
        }

        /// <summary>
        /// Gets a value of menu items.
        /// </summary>
        public IList MenuItems
        {
            get { return menuItems; }
            private set
            {
                menuItems = value;
                RaisePropertyChanged(nameof(MenuItems));
            }
        }

        /// <summary>
        /// Gets or sets a value of selected item.
        /// </summary>
        public object SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    RaisePropertyChanged(nameof(SelectedItem));
                    this.OnNavigationSelectionChanged();
                }
            }
        }

        /// <summary>
        /// Gets a list of root menu items.
        /// </summary>
        public List<object> RootMenuItems { get; } = new List<object>();
        
        /// <summary>
        /// Gets or sets a value of selected root menu items.
        /// </summary>
        public object SelectedRootMenuItem
        {
            get { return selectedRootMenuItem; }
            set
            {
                selectedRootMenuItem = value;
                RaisePropertyChanged(nameof(SelectedRootMenuItem));
                RootMenuItemSelectionChanged();
            }
        }

        /// <summary>
        /// Gets or sets a value of header.
        /// </summary>
        public string Header
        {
            get { return header; }
            set
            {
                header = value;
                RaisePropertyChanged(nameof(Header));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether header is visible or not.
        /// </summary>
        public bool IsHeaderVisible
        {
            get { return isHeaderVisible; }
            set
            {
                isHeaderVisible = value;
                RaisePropertyChanged(nameof(IsHeaderVisible));
            }
        }

        /// <summary>
        /// Gets or sets a value of current theme applied in a demo area.
        /// </summary>
        public ElementTheme CurrentTheme
        {
            get { return currentTheme; }
            set
            {
                if (currentTheme != value)
                {
                    currentTheme = value;
                    RaisePropertyChanged(nameof(CurrentTheme));
                    this.OnNavigationSelectionChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value of indicating whether theme option is visible.
        /// </summary>
        public bool IsThemeVisible
        {
            get { return isThemeVisible; }
            set
            {
                isThemeVisible = value;
                RaisePropertyChanged(nameof(IsThemeVisible));
            }
        }

        /// <summary>
        /// Gets or sets a value of demo information.
        /// </summary>
        public DemoInfo DemoInfo
        {
            get { return demoInfo; }
            set
            {
                demoInfo = value;
                RaisePropertyChanged(nameof(DemoInfo));
            }
        }

        #endregion Properties

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            _ = new DemoInfoDataSource();
            InitiateDefaultValues();
            this.SelectedRootMenuItem = this.RootMenuItems.FirstOrDefault(x=> (x as BrowserModel).Name == Constants.AllControlsName);
        }

        #endregion Constructor

        #region Methods
        /// <summary>
        /// Method to initialize a default values.
        /// </summary>
        private void InitiateDefaultValues()
        {    
            if(DemoHelper.ShowCaseDemos.Count > 0)
                RootMenuItems.Add(new BrowserModel() { Content = Constants.Showcase, Name = Constants.Showcase, Icon = "\uE722"});
            
                RootMenuItems.Add(new BrowserModel() { Content = Constants.AllControls, Name = Constants.AllControlsName, Icon = "\uE8FD" });

            if(DemoHelper.WhatsNewDemos.Count > 0)
                RootMenuItems.Add(new BrowserModel() { Content = Constants.WhatsNew, Name = Constants.WhatsNewName, Icon = "\uE789" });
             
            this.MenuItems = DemoHelper.ControlInfos;
        }

        /// <summary>
        /// Method which gets invoked anytime the text in the AutoSuggestBox gets updated.
        /// </summary>
        /// <param name="query">Search text</param>
        /// <returns></returns>
        internal static List<DemoInfo> SearchDemos(string query)
        {
            var suggestions = new List<DemoInfo>();
            var querySplit = query.Split(" ");

            foreach (var controlInfo in DemoHelper.ControlInfos)
            {
                var matchingItems = controlInfo.Demos.Where(
                    DemoInfo =>
                    {
                        bool flag = true;
                        foreach (string queryToken in querySplit)
                        {
                            DemoInfo.SearchItem = controlInfo.Name + " / " + DemoInfo.Name;
                            if (DemoInfo.SearchItem.IndexOf(queryToken, StringComparison.CurrentCultureIgnoreCase) < 0)
                            {
                                flag = false;
                            }
                        }

                        return flag;
                    });
                foreach (var item in matchingItems)
                {
                    suggestions.Add(item);
                }
            }
            return suggestions.OrderByDescending(i => i.SearchItem.StartsWith(query, StringComparison.CurrentCultureIgnoreCase)).ThenBy(i => i.SearchItem).ToList();
        }

        /// <summary>
        /// Method which gets invoked when demo is selected.
        /// </summary>
        /// <param name="control"></param>
        internal void SelectDemo(DemoInfo control)
        {
            this.SelectedItem = control;
            this.OnTileSelected(control);
        }

        /// <summary>
        /// Method which gets invoked when tile is selected.
        /// </summary>
        /// <param name="controlInfo"></param>
        internal void OnTileSelected(object selectedItem)
        {
            if (selectedItem == null)
                return;

            DemoInfo demoInfo = selectedItem as DemoInfo;
            if (demoInfo != null)
            {
                var controlInfo = DemoHelper.GetControlInfo(demoInfo);
                var menuItems = new List<object>();
                menuItems.Add(new CategoryGroup() { Category = controlInfo.Name });

                var categories = controlInfo.Demos.GroupBy(x => x.Category);
                if (categories.Count() > 1)
                {
                    foreach (var category in categories)
                    {
                        var featureGroup = new CategoryGroup() { Category = category.Key };
                        menuItems.Add(featureGroup);
                        menuItems.AddRange(category.ToList());
                    }
                }
                else
                {
                    menuItems.AddRange(controlInfo.Demos);
                }
                this.MenuItems = menuItems;
                this.SelectedItem = demoInfo;
            }
            else if(selectedItem is ControlInfo controlInfo)
            {
                //var menuItems = new List<object>();
                //menuItems.Add(controlInfo);

                //var categories = controlInfo.Demos.GroupBy(x => x.Category);
                //if (categories.Count() > 1)
                //{
                //    foreach (var category in categories)
                //    {
                //        var featureGroup = new CategoryGroup() { CategoryName = category.Key };
                //        menuItems.Add(featureGroup);
                //        menuItems.AddRange(category.ToList());
                //    }
                //}
                //this.MenuItems = menuItems;
                this.SelectedItem = controlInfo;
            }
        }

        /// <summary>
        /// Method which gets invoked when root menu items selection gets changed.
        /// </summary>
        private void RootMenuItemSelectionChanged()
        {
            if (this.SelectedRootMenuItem == null)
            {
                return;
            }

            this.IsThemeVisible = false;
            this.SelectedItem = null;
            this.DemoInfo = null;

            var selectedItem = this.SelectedRootMenuItem as BrowserModel;
            if (selectedItem.Content.ToString() == Constants.Showcase)
            {
                this.Header = string.Empty;
                this.IsHeaderVisible = false;
                NavigationService.Frame.Navigate(typeof(SectionPage), this);
            }
            else if (selectedItem.Content.ToString() == Constants.AllControls || selectedItem.Content.ToString() == Constants.WhatsNew)
            {
                this.Header = selectedItem.Content.ToString();
                this.IsHeaderVisible = false;
                NavigationService.Frame.Navigate(typeof(SectionGroupPage), this);
            }

            this.MenuItems = DemoHelper.ControlInfos;
        }

        /// <summary>
        /// Method which gets invoked when navigation selection gets changed.
        /// </summary>
        private void OnNavigationSelectionChanged()
        {
            if (this.SelectedItem == null)
                return;

            this.SelectedRootMenuItem = null;

            if (this.SelectedItem is ControlInfo controlInfo)
            {
                this.IsThemeVisible = false;
                this.Header = controlInfo.Name;
                this.IsHeaderVisible = true;
                NavigationService.Frame.Navigate(typeof(SectionGroupPage), this);
            }
            else if (this.SelectedItem is DemoInfo demoInfo)
            {
                this.Header = demoInfo.Name;
                this.IsHeaderVisible = true;
                this.IsThemeVisible = true;
                this.DemoInfo = demoInfo;
                NavigationService.Frame.Navigate(typeof(DemoPage), this);
            }
            else if((this.SelectedItem as NavigationViewItem).Content.ToString() == Constants.Settings)
            {
                this.Header = Constants.Settings;
                this.IsThemeVisible = false;
                this.IsHeaderVisible = true;
                NavigationService.Frame.Navigate(typeof(SettingsPage), this);
            }
        }

        #endregion Methods
    }
}
