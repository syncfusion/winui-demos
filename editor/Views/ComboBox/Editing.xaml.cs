#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Syncfusion.UI.Xaml.Core;
using System;
using Windows.System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.EditorDemos.WinUI.Views.ComboBox
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Editing : Page, IDisposable
    {
        public Editing()
        {
            this.InitializeComponent();
        }

        /// <inheritdoc cref="Control.OnPreviewKeyDown(KeyRoutedEventArgs)"/>
        private void OnEditingComboBoxPreviewKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (this.DropDownOpenCheckBox.IsChecked == true && !this.EditingComboBox.IsDropDownOpen)
            {
                bool allowOpenDropDown = e.Key != VirtualKey.Enter && e.Key != VirtualKey.Tab &&
                                         e.Key != VirtualKey.F4 && e.Key != VirtualKey.Escape && 
                                         e.Key != VirtualKey.Shift;

                TextBox editingTextBox = VisualTree.FindDescendant(this.EditingComboBox, typeof(TextBox)) as TextBox;
                if (allowOpenDropDown && editingTextBox != null && editingTextBox.FocusState != Microsoft.UI.Xaml.FocusState.Unfocused)
                {
                    this.EditingComboBox.IsDropDownOpen = true;
                }
            }
        }

        /// <summary>
        /// Occurs when the user submits some text that does not correspond to an item in the ComboBox dropdown list.
        /// </summary>
        private async void OnEditingComboBoxTextSubmitted(object sender, Syncfusion.UI.Xaml.Editors.ComboBoxInputSubmittedEventArgs e)
        {
            e.Handled = true;
            var cd = new ContentDialog
            {
                Content = "Enter a game from the list.",
                CloseButtonText = "Close"
            };


            cd.XamlRoot = this.Content.XamlRoot;
            var result = await cd.ShowAsync();
        }

        /// <summary>
        /// To dispose objects.
        /// </summary>
        public void Dispose()
        {
            if (this.EditingComboBox != null)
            {
                this.EditingComboBox.Dispose();
            }

            this.Resources.Clear();
            this.DataContext = null;
        }
    }
}
