using syncfusion.demoscommon.winui;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

namespace syncfusion.treeviewdemos.winui
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DragAndDrop_Page : Page, IDisposable
    {
        public DragAndDrop_Page()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Dispose all the allocated resources.
        /// </summary>
        public void Dispose()
        {
            // Release all managed resources
            if (this.treeView1 != null)
            {
                this.treeView1 = null;
            }
            if (this.treeView2 != null)
            {
                this.treeView2 = null;
            }
        }
    }
}
