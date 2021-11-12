#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace syncfusion.editordemos.winui.Views.ComboBox
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GettingStarted : Page, IDisposable
    {
        public GettingStarted()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// To dispose objects.
        /// </summary>
        public void Dispose()
        {
            if (this.SimpleComboBox != null)
            {
                this.SimpleComboBox.Dispose();
            }

            if (this.CustomizationComboBox != null)
            {
                this.CustomizationComboBox.Dispose();
            }

            if (this.country != null)
            {
                this.country.Dispose();
            }

            if (this.state != null)
            {
                this.state.Dispose();
            }

            if (this.city != null)
            {
                this.city.Dispose();
            }

            if (this.customSelectionBox != null)
            {
                this.customSelectionBox.Dispose();
            }

            this.Resources.Clear();
            this.DataContext = null;
        }
    }
}
