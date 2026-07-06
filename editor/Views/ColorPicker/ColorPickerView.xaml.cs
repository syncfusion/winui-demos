using Microsoft.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Syncfusion.EditorDemos.WinUI.Views.ColorPicker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ColorPickerView : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ColorPickerView"/> class.
        /// This constructor calls <see cref="InitializeComponent"/> to load the XAML UI definitions
        /// and subscribes to the PointerPressed event for the `colorPaletteViewPanel`.
        /// </summary>
        public ColorPickerView()
        {
            this.InitializeComponent();
            this.colorPickerViewPanel.PointerPressed += OnColorPickerViewPanelPointerPressed;
        }

        private void OnColorPickerViewPanelPointerPressed(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            // To restrict the focus on first control when clicking on empty area.
            e.Handled = true;
        }
    }
}
