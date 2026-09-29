using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.Editors;

namespace Syncfusion.EditorDemos.WinUI.Views.AutoComplete
{
    /// <summary>
    /// AutoComplete auto append demo class
    /// </summary>
    public sealed partial class AutoAppend : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoAppend"/> class.
        /// </summary>
        public AutoAppend()
        {
            this.InitializeComponent();
        }

        private void appendTypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (appendType.SelectedIndex == 0)
            {
                autoAppendAutoComplete.AppendType = AutoCompleteAutoAppendType.TextWithSelection;
            }
            else
            {
                autoAppendAutoComplete.AppendType = AutoCompleteAutoAppendType.Text;
            }
        }
    }
}
