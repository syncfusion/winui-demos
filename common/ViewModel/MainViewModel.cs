#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Syncfusion.UI.Xaml.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Syncfusion.DemosCommon.WinUI
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
        private BitmapImage bannerImage;
        private object subCategorySelectedItem;
        private object documentItemSource;
        private bool isNavigationPaneOpen = true;
        private bool showInfoPanel;
        private bool isValidating;

        /// <summary>
        /// Gets or sets the error text.
        /// </summary>
        private string errorText;

        /// <summary>
        /// Gets or sets the model name.
        /// </summary>
        private string modelName;

        /// <summary>
        /// Gets or sets the end point.
        /// </summary>
        private string endPoint;

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        private string key;

        #endregion private variables

        #region Properties

        /// <summary>
        /// Gets the application title.
        /// </summary>
        public static string AppTitleText
        {
            get
            {
                return string.Empty;
            }
        }
        
        /// <summary>
        /// Gets or sets the banner image.
        /// </summary>
		public BitmapImage BannerImage 
        {
            get { return bannerImage; }
            set
            {
                bannerImage = value;
                RaisePropertyChanged(nameof(BannerImage));
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
                    this.OnNavigationSelectionChanged(false);
                }
            }
        }

        public object SubCategorySelectedItem
        {
            get { return subCategorySelectedItem; }
            set
            {
                if (subCategorySelectedItem != value)
                {
                    subCategorySelectedItem = value;
                    RaisePropertyChanged(nameof(SubCategorySelectedItem));
                    this.OnSubDemoSelectedItemChanged();
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
                IsSectionHeaderVisible = isHeaderVisible;
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
                    this.OnNavigationSelectionChanged(true);
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
                if (demoInfo != null)
                {
                    this.DocumentItemSource = demoInfo.SubCategoryDemos?.Count >= 1 ? demoInfo.SubCategoryDemos[0].Documentation : demoInfo.Documentation;
                    this.ShowInfoPanel = demoInfo.SubCategoryDemos?.Count >= 1 ? demoInfo.SubCategoryDemos[0].ShowInfoPanel : demoInfo.ShowInfoPanel;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether NavigationPane is opened or not.
        /// </summary>
        public bool IsNavigationPaneOpen
        {
            get { return isNavigationPaneOpen; }
            set
            {
                isNavigationPaneOpen = value;
                RaisePropertyChanged(nameof(IsNavigationPaneOpen));
            }
        }

        /// <summary>
        /// Gets or sets the header of section pages.
        /// </summary>
        public string SectionHeader { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether section header is visible or not.
        /// </summary>
        public bool IsSectionHeaderVisible { get; set; }

        /// <summary>
        /// Gets or sets the value of the document information containing the Syncfusion help link hyperlink.
        /// </summary>
        public object DocumentItemSource
        {
            get { return documentItemSource; }
            set
            {
                documentItemSource = value;
                RaisePropertyChanged(nameof(DocumentItemSource));                
            }
        }

        /// <summary>
        /// Gets or sets the value indicating whether to show or hide documentation panel in DemoView.
        /// </summary>
        public bool ShowInfoPanel 
        { 
            get { return showInfoPanel; }
            set
            {
                showInfoPanel = value;
                RaisePropertyChanged(nameof(ShowInfoPanel));
            }
        }

        internal double ScrollViewerVerticalOffset { get; set; }

        /// <summary>
        /// Gets or sets the model name in the AI Setup Window.
        /// </summary>
        public string ErrorText
        {
            get { return errorText; }
            set
            {
                errorText = value;
                RaisePropertyChanged("ErrorText");
            }
        }

        /// <summary>
        /// Gets or sets the model name in the AI Setup Window.
        /// </summary>
        public string ModelName
        {
            get { return modelName; }
            set
            {
                modelName = value;
                RaisePropertyChanged("ModelName");
            }
        }

        /// <summary>
        /// Gets or sets the end point in the AI Setup Window.
        /// </summary>
        public string EndPoint
        {
            get { return endPoint; }
            set
            {
                endPoint = value;
                RaisePropertyChanged("EndPoint");
            }
        }

        /// <summary>
        /// Gets or sets the key in the AI Setup Window.
        /// </summary>
        public string Key
        {
            get { return key; }
            set
            {
                key = value;
                RaisePropertyChanged("Key");
            }
        }

        /// <summary>
        /// Gets or sets the value whether the Validation is visible or not in the AI Setup Window.
        /// </summary>
        public bool IsValidating
        {
            get { return isValidating; }
            set 
            { 
                isValidating = value;
                RaisePropertyChanged("IsValidating");
            }
        }
        #endregion Properties

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            this.bannerImage = new BitmapImage();
#if Main_SB
            bannerImage.UriSource = new Uri("ms-appx:///Common/Assets/BannerImageDesktop.png");
#else
            bannerImage.UriSource = new Uri("ms-appx:///Syncfusion.DemosCommon.WinUI/Assets/BannerImageDesktop.png");
#endif
            _ = new DemoInfoDataSource();
            InitiateDefaultValues();
            if (DemoHelper.AIDemos.Count > 0)
            {
                var ai = new ControlInfo()
                {
                    Control = DemoControl.SmartAISolutions,
                    ControlCategory = ControlCategory.SmartComponents,
                    ControlBadge = ControlBadge.None,
                    Description = "Showcasing how Syncfusion components work with AI tools to enhance functionality and deliver smarter solutions.",
                    Glyph = "\uE726",
                    ImageSource = "SmartAISolution.png",
                };

                DemoHelper.ControlInfos.Insert(0, ai);
            }
                
            this.SelectedRootMenuItem = this.RootMenuItems.FirstOrDefault(x=> (x as BrowserModel).Name == Constants.HomeName);
        }

        #endregion Constructor

        #region Methods
        /// <summary>
        /// Method to initialize a default values.
        /// </summary>
        private void InitiateDefaultValues()
        {
            if (DemoHelper.ShowCaseDemos.Count > 0)
                RootMenuItems.Add(new BrowserModel() { Content = Constants.Showcase, Name = Constants.Showcase, Icon = "M4.77639 1.32918C5.03048 0.821004 5.54988 0.5 6.11803 0.5H9.88197C10.4501 0.5 10.9695 0.821003 11.2236 1.32918L11.809 2.5H14C15.1046 2.5 16 3.39543 16 4.5V13.5C16 14.6046 15.1046 15.5 14 15.5H2C0.895431 15.5 0 14.6046 0 13.5V4.5C0 3.39543 0.895431 2.5 2 2.5H4.19098L4.77639 1.32918ZM6.11803 1.5C5.92865 1.5 5.75552 1.607 5.67082 1.77639L4.94721 3.22361C4.86252 3.393 4.68939 3.5 4.5 3.5H2C1.44772 3.5 1 3.94772 1 4.5V13.5C1 14.0523 1.44772 14.5 2 14.5H14C14.5523 14.5 15 14.0523 15 13.5V4.5C15 3.94772 14.5523 3.5 14 3.5H11.5C11.3106 3.5 11.1375 3.393 11.0528 3.22361L10.3292 1.77639C10.2445 1.607 10.0714 1.5 9.88197 1.5H6.11803ZM8 5.5C6.34315 5.5 5 6.84315 5 8.5C5 10.1569 6.34315 11.5 8 11.5C9.65685 11.5 11 10.1569 11 8.5C11 6.84315 9.65685 5.5 8 5.5ZM4 8.5C4 6.29086 5.79086 4.5 8 4.5C10.2091 4.5 12 6.29086 12 8.5C12 10.7091 10.2091 12.5 8 12.5C5.79086 12.5 4 10.7091 4 8.5Z" });

            RootMenuItems.Add(new BrowserModel() { Content = Constants.Home, Name = Constants.HomeName, Icon = "M5.93934 1.3534C6.52513 0.767615 7.47488 0.767617 8.06066 1.3534L13.5607 6.8534C13.842 7.13471 14 7.51624 14 7.91406V13.9998C14 15.1044 13.1046 15.9998 12 15.9998H8.5C8.22386 15.9998 8 15.776 8 15.4998V10.9998H6V15.4998C6 15.776 5.77614 15.9998 5.5 15.9998H2C0.895431 15.9998 0 15.1044 0 13.9998V7.91406C0 7.51624 0.158035 7.13471 0.43934 6.8534L5.93934 1.3534ZM7.35355 2.06051C7.15829 1.86525 6.84171 1.86525 6.64645 2.06051L1.14645 7.56051C1.05268 7.65428 1 7.78145 1 7.91406V13.9998C1 14.5521 1.44772 14.9998 2 14.9998H5V10.4998C5 10.2237 5.22386 9.99985 5.5 9.99985H8.5C8.77614 9.99985 9 10.2237 9 10.4998V14.9998H12C12.5523 14.9998 13 14.5521 13 13.9998V7.91406C13 7.78145 12.9473 7.65428 12.8536 7.56051L7.35355 2.06051Z" });

            if (DemoHelper.WhatsNewDemos.Count > 0)
                RootMenuItems.Add(new BrowserModel() { Content = Constants.WhatsNew, Name = Constants.WhatsNewName, Icon = "M14.069 0.907018C15.0314 0.618292 16 1.33896 16 2.34376V13.568C16 14.6106 14.9625 15.3352 13.9836 14.9763L8.90833 13.1153C8.60953 14.2017 7.61463 14.9997 6.43333 14.9997H6C4.34315 14.9997 3 13.6566 3 11.9997V10.9489L0.983617 10.2096C0.392791 9.99297 0 9.43058 0 8.80129V6.24376C0 5.58134 0.434502 4.99736 1.06898 4.80702L14.069 0.907018ZM4 11.3156V11.9997C4 13.1043 4.89543 13.9997 6 13.9997H6.43333C7.18325 13.9997 7.81011 13.4728 7.96389 12.769L4 11.3156ZM15 2.34376C15 2.00883 14.6771 1.7686 14.3563 1.86484L1.35633 5.76484C1.14483 5.82829 1 6.02295 1 6.24376V8.80129C1 9.01105 1.13093 9.19852 1.32787 9.27073L14.3279 14.0374C14.6542 14.157 15 13.9155 15 13.568V2.34376Z" });

            if (DemoHelper.AIDemos.Count > 0)
                RootMenuItems.Add(new BrowserModel() { Content = Constants.AIDemos, Name = Constants.AIDemosName, Icon = "M4.5 1C3.67157 1 3 1.67157 3 2.5V11.5C3 12.3284 3.67157 13 4.5 13H13.5C14.3284 13 15 12.3284 15 11.5V2.5C15 1.67157 14.3284 1 13.5 1H4.5ZM2 2.5C2 1.11929 3.11929 0 4.5 0H13.5C14.8807 0 16 1.11929 16 2.5V11.5C16 12.8807 14.8807 14 13.5 14H4.5C3.11929 14 2 12.8807 2 11.5V2.5ZM7.22277 2.15592C7.45448 2.16169 7.65184 2.32595 7.69959 2.55275L7.80567 3.05662C7.98784 3.92189 8.64798 4.60724 9.50582 4.8217L10.1415 4.98062C10.3558 5.0342 10.5096 5.22208 10.5197 5.44277C10.5299 5.66346 10.3939 5.86464 10.1854 5.93762L9.29792 6.24826C8.55331 6.50888 7.9932 7.13148 7.8125 7.89941L7.69703 8.39015C7.64506 8.61102 7.45087 8.7692 7.22406 8.77543C6.99724 8.78167 6.79466 8.63439 6.73064 8.4167L6.54389 7.78175C6.33772 7.08075 5.81202 6.51863 5.12638 6.26602L4.22754 5.93486C4.02272 5.8594 3.89052 5.6598 3.90096 5.44178C3.9114 5.22376 4.06206 5.0377 4.27315 4.98215L4.9125 4.81391C5.71775 4.60201 6.34664 3.97312 6.55854 3.16787L6.72678 2.52852C6.78577 2.30437 6.99107 2.15014 7.22277 2.15592ZM0.5 2.5C0.776142 2.5 1 2.72386 1 3V11C1 11.2761 0.776142 11.5 0.5 11.5C0.223858 11.5 0 11.2761 0 11V3C0 2.72386 0.223858 2.5 0.5 2.5ZM7.19514 4.22821C6.88423 4.76962 6.42543 5.21338 5.87225 5.50597C6.42511 5.79758 6.88224 6.23905 7.19296 6.77617C7.50251 6.23896 7.95883 5.79621 8.51205 5.50332C7.96085 5.21023 7.5045 4.76714 7.19514 4.22821ZM11.4051 6.78482C11.6368 6.7906 11.8341 6.95485 11.8819 7.18166L11.9614 7.55956C12.0882 8.16169 12.5476 8.63862 13.1445 8.78785L13.6213 8.90704C13.8356 8.96062 13.9894 9.14851 13.9995 9.3692C14.0097 9.58988 13.8737 9.79106 13.6652 9.86404L12.9996 10.097C12.4814 10.2784 12.0917 10.7116 11.9659 11.246L11.8793 11.6141C11.8273 11.835 11.6332 11.9931 11.4063 11.9994C11.1795 12.0056 10.9769 11.8583 10.9129 11.6406L10.7729 11.1644C10.6294 10.6766 10.2636 10.2854 9.78644 10.1097L9.1123 9.86129C8.90749 9.78583 8.77529 9.58623 8.78573 9.3682C8.79617 9.15018 8.94683 8.96412 9.15791 8.90858L9.63743 8.78239C10.1978 8.63493 10.6354 8.1973 10.7829 7.63694L10.9091 7.15743C10.968 6.93328 11.1733 6.77905 11.4051 6.78482ZM11.3812 8.69902C11.1842 8.98719 10.931 9.23334 10.6369 9.42218C10.9305 9.61019 11.1828 9.85487 11.3794 10.1408C11.5756 9.85438 11.8278 9.60889 12.1218 9.42011C11.829 9.23133 11.5772 8.98583 11.3812 8.69902Z" });

            List<object> menuItems = new List<object>();
            menuItems.Add(new AllControlsButtonInfo() { Content = "All Controls" });
            foreach (ControlInfo controlInfo in DemoHelper.ControlInfos)
            {
                var categories = controlInfo.Demos.GroupBy(x => x.Category);
                if (categories.Count() > 1)
                {
                    foreach (var category in categories)
                    {
                        var featureGroup = new CategoryGroup() { Category = category.Key };
                        controlInfo.ChildMenuItems.Add(featureGroup);
                        controlInfo.ChildMenuItems.AddRange(category.ToList());
                    }
                }
                else
                {
                    controlInfo.ChildMenuItems.AddRange(controlInfo.Demos);
                }

                menuItems.Add(controlInfo);
            }

            this.MenuItems = menuItems;
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
            ScrollViewerVerticalOffset = 0;
            if (selectedItem == null)
                return;

            DemoInfo demoInfo = selectedItem as DemoInfo;
            if (demoInfo != null && demoInfo.SearchItem != "No results found")
            {
                var controlInfo = DemoHelper.GetControlInfo(demoInfo);
                this.SelectedItem = demoInfo;
                controlInfo.IsChildSelected = true;
                controlInfo.IsExpanded = true;
            }
            else if (demoInfo == null && selectedItem is ControlInfo contrInfo && contrInfo.Name == "Smart AI Solutions" )
            {
                foreach(BrowserModel browserModel in this.RootMenuItems)
                {
                    if (browserModel.Name == "Smart Components")
                    {
                        this.SelectedRootMenuItem = browserModel;
                        break;
                    }
                }
            }
            else if (selectedItem is ControlInfo controlInfo)
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
                controlInfo.IsExpanded = true;
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

            foreach (var item in this.MenuItems)
            {
                AllControlsButtonInfo allControlsButton = item as AllControlsButtonInfo;
                ControlInfo controlInfo = item as ControlInfo;
                if (controlInfo != null)
                {
                    controlInfo.Visibility = Visibility.Visible;
                    controlInfo.IsChildSelected = false;
                    controlInfo.IsExpanded = false;
                }
                else if (allControlsButton != null)
                {
                    allControlsButton.Visibility = Visibility.Collapsed;
                }
            }

            this.IsThemeVisible = false;
            this.SelectedItem = null;
            this.DemoInfo = null;

            var selectedItem = this.SelectedRootMenuItem as BrowserModel;
            if (selectedItem.Content.ToString() == Constants.Showcase)
            {
                this.SectionHeader = Constants.Showcase;
                this.IsHeaderVisible = false;
                NavigationService.Frame.Navigate(typeof(SectionPage), this);
            }
            else if (selectedItem.Content.ToString() == Constants.Home || selectedItem.Content.ToString() == Constants.WhatsNew)
            {
                this.SectionHeader = selectedItem.Content.ToString() == Constants.Home ? Constants.HomeName : Constants.WhatsNewName;
                this.IsHeaderVisible = false;
                NavigationService.Frame.Navigate(typeof(SectionGroupPage), this);
            }
            else if (selectedItem.Content.ToString() == Constants.AIDemos)
            {
                this.SectionHeader = Constants.AIDemosName;
                this.IsHeaderVisible = false;
                NavigationService.Frame.Navigate(typeof(SectionGroupPage), this);
            }
        }

        /// <summary>
        /// Method which gets invoked when navigation selection gets changed.
        /// </summary>
        private void OnNavigationSelectionChanged(bool isThemeSwitchClicked)
        {
            if (isThemeSwitchClicked)
            {
                OnThemeSelection();
                return;
            }
            if (this.SelectedItem == null)
                return;

            this.SelectedRootMenuItem = null;
            if (this.SelectedItem is ControlInfo contrInfo && contrInfo.Name == "Smart AI Solutions")
            {
                this.SectionHeader = Constants.AIDemosName;
                this.IsHeaderVisible = false;
                NavigationService.Frame.Navigate(typeof(SectionGroupPage), this);
                return;
            }

            else if (this.SelectedItem is ControlInfo controlInfo)
            {
                var demoInfo = controlInfo.Demos.Contains(this.DemoInfo) ? this.DemoInfo : controlInfo.Demos[0];
                if (this.DemoInfo != demoInfo)
                {
                    this.DemoInfo = demoInfo;
                }                
            }
            else if (this.SelectedItem is DemoInfo demoInfo)
            {
                this.IsHeaderVisible = true;
                this.IsThemeVisible = true;
                this.Header = demoInfo.Name;
                this.DemoInfo = demoInfo;
                NavigationService.Frame.Navigate(typeof(DemoPage), this);
            }
            else if (this.SelectedItem is AllControlsButtonInfo && (this.SelectedItem as AllControlsButtonInfo).Content != null && (this.SelectedItem as AllControlsButtonInfo).Content.ToString() == "All Controls")
            {
                ControlInfo nextSelectedItem = null;
                foreach (var item in this.MenuItems)
                {
                    ControlInfo controlInfoItem = item as ControlInfo;
                    if (controlInfoItem != null)
                    {
                        controlInfoItem.Visibility = Visibility.Visible;
                        controlInfoItem.IsChildSelected = false;
                        controlInfoItem.IsExpanded = false;
                        if (controlInfoItem.Demos.Contains(DemoInfo))
                        {
                            nextSelectedItem = controlInfoItem;
                        }
                    }                    
                }                
                nextSelectedItem.IsSelected = true;
            }
            else if(this.SelectedItem is NavigationViewItem && (this.SelectedItem as NavigationViewItem).Content.ToString() == Constants.Settings)
            {
                foreach (var item in this.MenuItems)
                {
                    AllControlsButtonInfo allControlsButton = item as AllControlsButtonInfo;
                    ControlInfo controlDetails = item as ControlInfo;
                    if (controlDetails != null)
                    {
                        controlDetails.Visibility = Visibility.Visible;
                        controlDetails.IsChildSelected = false;
                        controlDetails.IsExpanded = false;
                    }
                    else if (allControlsButton != null)
                    {
                        allControlsButton.Visibility = Visibility.Collapsed;
                    }
                }

                this.Header = Constants.Settings;
                this.IsThemeVisible = false;
                this.IsHeaderVisible = true;
                NavigationService.Frame.Navigate(typeof(SettingsPage), this);
            }
        }

        /// <summary>
        /// Method which gets invoked when subDemo selection gets changed.
        /// </summary>
        private void OnSubDemoSelectedItemChanged()
        {
            if (this.SubCategorySelectedItem != null && this.SubCategorySelectedItem is DemoInfo demoInfo)
            {
                DocumentItemSource = demoInfo.Documentation;
                ShowInfoPanel = demoInfo.ShowInfoPanel;
                this.Header = demoInfo.Name;
                if (demoInfo.DemoView != null)
                {
                    NavigationService.DemoPageFrame.Navigate(demoInfo.DemoView);
                }

                OnThemeSelection();
            }
        }

        private void OnThemeSelection()
        {
            if (NavigationService.DemoPageFrame != null && NavigationService.DemoPageFrame.Content is FrameworkElement frameworkElement)
            {
                var demoLayouts = VisualTree.FindDescendants<DemoLayout>(frameworkElement);
                if (demoLayouts != null)
                {
                    Enum.TryParse(typeof(ElementTheme), this.CurrentTheme.ToString(), out object theme);
                    foreach (var demoLayout in demoLayouts)
                    {
                        demoLayout.IsCodeSnippetAvailable = string.IsNullOrEmpty(demoLayout.Xaml) && string.IsNullOrEmpty(demoLayout.XamlSource) &&
                                                         string.IsNullOrEmpty(demoLayout.CSharp) && string.IsNullOrEmpty(demoLayout.CSharpSource) ? Visibility.Collapsed : Visibility.Visible;
                        demoLayout.ExampleContainer.RequestedTheme = (ElementTheme)theme;
                    }
                }
            }
        }

        #endregion Methods
    }
}
