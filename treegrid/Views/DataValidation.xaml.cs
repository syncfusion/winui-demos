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
    public sealed partial class DataValidation : Page, IDisposable
    {
        public DataValidation()
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

            if (this.ValidationCombo != null)
                this.ValidationCombo = null;
        }
    }
}
