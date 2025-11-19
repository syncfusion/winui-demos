#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.Editors;

namespace Syncfusion.EditorDemos.WinUI.Views.MaskedTextBox
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LiteralsAndPromptView : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LiteralsAndPromptView"/> class.
        /// </summary>
        public LiteralsAndPromptView()
        {
            this.InitializeComponent();
        }

        private void PromptCharComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (promptCharComboBox.SelectedIndex)
            {
                case 0:
                    productKeyMask.PromptChar = '_';
                    break;
                case 1:
                    productKeyMask.PromptChar = '*';
                    break;
                case 2:
                    productKeyMask.PromptChar = '#';
                    break;
            }
        }

        private void MaskFormatComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (maskFormatComboBox.SelectedIndex)
            {
                case 0:
                    maskFormatHeading.Text = "Value : ";
                    text.Text = "Text : ";
                    productKeyMask.ValueMaskFormat = MaskedTextBoxMaskFormat.IncludePromptAndLiterals;
                    break;
                case 1:
                    maskFormatHeading.Text = "Value : ";
                    text.Text = "Text : ";
                    productKeyMask.ValueMaskFormat = MaskedTextBoxMaskFormat.IncludePrompt;
                    break;
                case 2:
                    maskFormatHeading.Text = "Value : ";
                    text.Text = "Text : ";
                    productKeyMask.ValueMaskFormat = MaskedTextBoxMaskFormat.IncludeLiterals;
                    break;
                case 3:
                    maskFormatHeading.Text = "Value : ";
                    text.Text = "Text : ";
                    productKeyMask.ValueMaskFormat = MaskedTextBoxMaskFormat.ExcludePromptAndLiterals;
                    break;
            }
        }
    }
}
