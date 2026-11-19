using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.DataGrid;
using Syncfusion.UI.Xaml.Grids;
using System;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TreeGrid
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RowDragDrop : Page, IDisposable
    {
        public RowDragDrop()
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
        }
    }
}
