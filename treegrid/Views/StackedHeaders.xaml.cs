using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Syncfusion.UI.Xaml.TreeGrid;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TreeGrid
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StackedHeaders : Page, IDisposable
    {
        public StackedHeaders()
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
