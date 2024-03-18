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
                RootMenuItems.Add(new BrowserModel() { Content = Constants.Showcase, Name = Constants.Showcase, Icon = "\uE722" });

            RootMenuItems.Add(new BrowserModel() { Content = Constants.Home, Name = Constants.HomeName, Icon = "\uE8FD" });

            if (DemoHelper.WhatsNewDemos.Count > 0)
                RootMenuItems.Add(new BrowserModel() { Content = Constants.WhatsNew, Name = Constants.WhatsNewName, Icon = "\uE789" });

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

            if (this.SelectedItem is ControlInfo controlInfo)
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
