using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid
{
    public sealed partial class RowDragDrop : Page, IDisposable
    {
        public RowDragDrop()
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
        }
    }
}