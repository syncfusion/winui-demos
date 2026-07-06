using Microsoft.UI.Xaml.Controls;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.EditorDemos.WinUI.Views.ComboBox
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Filtering : Page, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Filtering"/> class.
        /// </summary>
        public Filtering()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// To dispose objects.
        /// </summary>
        public void Dispose()
        {
            if (this.FilterComboBox != null)
            {
                this.FilterComboBox.Dispose();
            }

            this.Resources.Clear();
            this.DataContext = null;
        }
    }
}
