#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Syncfusion.UI.Xaml.Core;

namespace Syncfusion.DemosCommon.WinUI
{
    /// <summary>
    /// A model class represent a control information.
    /// </summary>
    public class ControlInfo : NotificationObject, ITileInfo
    {
        #region Variables

        private Visibility visibility = Visibility.Visible;
        private bool isChildSelected;
        private bool isExpanded;
        private bool isSelected;

        #endregion Variables

        #region Properties

        /// <summary>
        /// Gets or set a name of control from <see cref="DemoControl"/> enum.
        /// </summary>
        public DemoControl Control { get; set; }

        /// <summary>
        /// Gets a value of name in string format converted from <see cref="DemoControl"/> enum.
        /// </summary>
        public string Name
        {
            get
            {
                return (string)new EnumDisplayNameConverter().Convert(Control, null, null, null);
            }
        }

        /// <summary>
        /// Gets or sets a value of <see cref="Syncfusion.DemosCommon.WinUI.ControlBadge"/>.
        /// </summary>
        public ControlBadge ControlBadge { get; set; }

        /// <summary>
        /// Gets or set a value of <see cref="ControlCategory"/> where the control belong to its group.
        /// </summary>
        public ControlCategory ControlCategory { get; set; }

        /// <summary>
        /// Gets the display name of the control's category, converted from its corresponding <see cref="ControlCategory"/> enum value.
        /// Setting this property is not supported and will throw an exception; use the <see cref="ControlCategory"/> property instead.
        /// </summary>
        public string Category
        {
            get
            {
                return (string)new EnumDisplayNameConverter().Convert(ControlCategory, null, null, null);
            }
            set
            {
                throw new Exception("Set FeatureCategory for ControlInfo using API ControlCategory");
            }
        }

        /// <summary>
        /// Gets or set a value of description which explains about the control and its feature.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or set a value of glyph to represent the control.
        /// </summary>
        public string Glyph { get; set; }

        /// <summary>
        /// Gets or sets the visibility for the control items.
        /// </summary>
        public Visibility Visibility 
        { 
            get
            {
                return visibility;
            }
            set
            {
                visibility = value;
                RaisePropertyChanged(nameof(Visibility));
            }
        }

        /// <summary>
        /// Gets or set a value indicating whether the control is in preview or not.
        /// </summary>
        public bool IsPreview { get; set; }

        /// <summary>
        /// Gets a list of demo information falls under its <see cref="ControlInfo"/>.
        /// </summary>
        public List<DemoInfo> Demos { get; } = new List<DemoInfo>();

        /// <summary>
        /// Gets a value of badge which may be any of the <see cref="DemoTypes"/>.
        /// </summary>
        public string Badge
        {
            get
            {
                if (ControlBadge == ControlBadge.New)
                {
                    return Constants.New;
                }
                else if (ControlBadge == ControlBadge.Updated)
                {
                    return Constants.Updated;
                }
                else if (Demos != null && Demos.Count > 0)
                {
                    if (Demos.All(demo => demo.DemoType == DemoTypes.New))
                    {
                        return Constants.New;
                    }
                    else if (Demos.Any(demo => demo.DemoType == DemoTypes.New) || Demos.Any(demo => demo.DemoType == DemoTypes.Updated))
                    {
                        return Constants.Updated;
                    }
                }

                return string.Empty;
            }
        }
        /// <summary>
        /// Gets or set a value of ImageSource to represent the control.
        /// </summary>
        private string imageSource { get; set; }

        /// <summary>
        /// Gets or sets a string representing the image source path for the control.
        /// The path is automatically prefixed based on the build configuration (Main_SB or otherwise).
        /// </summary>
        public string ImageSource
        {
            get
            {
                return imageSource;
            }
            set
            {
#if Main_SB
                imageSource = $"ms-appx:///Common/Assets/Control Images/{value}";
#else
                imageSource = $"ms-appx:///Syncfusion.DemosCommon.WinUI/Assets/Control Images/{value}";
#endif
            }
        }

        /// <summary>
        /// A list of demo items for the control item. 
        /// </summary>
        public List<object> ChildMenuItems { get; } = new List<object>();

        /// <summary>
        /// Gets or sets a value indicating whether the demo item is selected or not when control item is expanded in NavigationView's compact mode.
        /// </summary>
        public bool IsChildSelected
        {
            get { return isChildSelected; }
            set
            {
                isChildSelected = value;
                RaisePropertyChanged(nameof(IsChildSelected));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the parent item is selected or not.
        /// </summary>
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                RaisePropertyChanged(nameof(IsSelected));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control item is expanded or not.
        /// </summary>
        public bool IsExpanded
        {
            get { return isExpanded; }
            set
            {
                isExpanded = value;
                RaisePropertyChanged(nameof(IsExpanded));
                OnIsExpandedChanged();
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Method which gets invoked when the control item expand state gets changed.
        /// </summary>
        public void OnIsExpandedChanged()
        {
            Button button = null;
            if (NavigationService.Frame != null && NavigationService.Frame.XamlRoot != null)
            {
                button = FocusManager.GetFocusedElement(NavigationService.Frame.XamlRoot) as Button;
            }

            if (NavigationService.ViewModel == null || NavigationService.ViewModel.SelectedItem == null || (button != null && button.Name == "TogglePaneButton" && button.FocusState == FocusState.Pointer && button.IsPointerOver))
            {
                return;
            }

            AllControlsButtonInfo allControlsButton = null;
            bool isExpanded = NavigationService.ViewModel.IsNavigationPaneOpen ? this.IsExpanded : this.IsChildSelected;
            foreach (var item in NavigationService.ViewModel.MenuItems)
            {
                if (item is AllControlsButtonInfo)
                {
                    allControlsButton = item as AllControlsButtonInfo;
                }
                
                ControlInfo controlInfo = item as ControlInfo;
                if (controlInfo != null)
                {
                    if (isExpanded)
                    {
                        controlInfo.Visibility = (NavigationService.ViewModel.SelectedItem != controlInfo && !controlInfo.Demos.Contains(NavigationService.ViewModel.SelectedItem)) ? Visibility.Collapsed : Visibility.Visible;
                    }
                    else
                    {
                        controlInfo.Visibility = Visibility.Visible;
                    }
                }
                else if (allControlsButton != null)
                {
                    allControlsButton.Visibility = isExpanded ? Visibility.Visible : Visibility.Collapsed;
                }

                if (NavigationService.ViewModel.SelectedRootMenuItem == null && !NavigationService.ViewModel.IsNavigationPaneOpen && allControlsButton != null && allControlsButton.Visibility == Visibility.Collapsed)
                {
                    NavigationService.ViewModel.SelectedItem = NavigationService.ViewModel.DemoInfo;
                }
            }
        }

        #endregion Methods
    }
}
