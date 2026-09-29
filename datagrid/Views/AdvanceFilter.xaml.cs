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

namespace DataGrid
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdvanceFilter : Page, IDisposable
    {
        public AdvanceFilter()
        {
            this.InitializeComponent();
        }

        public void Dispose()
        {
            this.Resources.Clear();
            if (this.sfDataGrid != null)
            {
                this.sfDataGrid.Dispose();
            }
            if (this.ckbAllowFilters != null)
                this.ckbAllowFilters = null;

            if (this.ckbAllowBlankFiltersGender != null)
                this.ckbAllowBlankFiltersGender = null;

            if (this.ckbAllowFilterBirthDate != null)
                this.ckbAllowFilterBirthDate = null;

            if (this.ckbAllowFilterEmployeeID != null)
                this.ckbAllowFilterEmployeeID = null;

            if (this.ckbImmediateUpdateColumnFilterBirthDate != null)
                this.ckbImmediateUpdateColumnFilterBirthDate = null;

            if (this.ckbImmediateUpdateColumnFilterEmployeeID != null)
                this.ckbImmediateUpdateColumnFilterEmployeeID = null;
        }
    }
}
