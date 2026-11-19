#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TreeGrid
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdvancedFiltering : Page, IDisposable
    {
        public AdvancedFiltering()
        {
            this.InitializeComponent();
        }
        public void Dispose()
        {
            this.Resources.Clear();
            if (this.sfTreeGrid != null)
            {
                this.sfTreeGrid.Dispose();
            }

            if (this.ckbAllowBlankFiltersLastName != null)
                this.ckbAllowBlankFiltersLastName = null;

            if (this.ckbAllowFilterEmployeeID != null)
                this.ckbAllowFilterEmployeeID = null;

            if (this.ckbAllowFilterFirstName != null)
                this.ckbAllowFilterFirstName = null;

            if (this.ckbAllowFilters != null)
                this.ckbAllowFilters = null;

            if (this.ckbImmediateUpdateColumnFilterEmployeeID != null)
                this.ckbImmediateUpdateColumnFilterEmployeeID = null;

            if (this.ckbImmediateUpdateColumnFilterFirstName != null)
                this.ckbImmediateUpdateColumnFilterFirstName = null;

            if (this.filterLevelComboBox != null)
                this.filterLevelComboBox = null;
        }


    }
}
