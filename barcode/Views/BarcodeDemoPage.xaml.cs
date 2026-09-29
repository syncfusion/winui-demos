using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.Barcode;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Syncfusion.BarcodeDemos.WinUI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BarcodeDemoPage : Page, IDisposable
    {
        public BarcodeDemoPage()
        {
            this.InitializeComponent();
        }

        public void Dispose()
        {
            if (barcode != null)
            {
                barcode = null;
            }
            if (uniDimesionalBarcode != null)
            {
                uniDimesionalBarcode = null;
            }
            if (dataMatrixBarcode != null)
            {
                dataMatrixBarcode = null;
            }
            if (qrBarcode != null)
            {
                qrBarcode = null;
            }
        }
    }
}
