using Microsoft.UI.Xaml.Controls;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.EditorDemos.WinUI.Views.ComboBox
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GettingStarted : Page, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GettingStarted"/> class.
        /// </summary>
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
