#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;

namespace Syncfusion.EditorDemos.WinUI.Views.MaskedTextBox
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GettingStartedView : Page
    {
        public GettingStartedView()
        {
            this.InitializeComponent();
        }

        private void PromptCharComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (promptCharComboBox.SelectedIndex)
            {
                case 0:
                    emailMask.PromptChar = '_';
                    dateMask.PromptChar = '_';
                    timeMask.PromptChar = '_';
                    phoneMask.PromptChar = '_';
                    ipMask.PromptChar = '_';
                    debitMask.PromptChar = '_';
                    break;
                case 1:
                    emailMask.PromptChar = '*';
                    dateMask.PromptChar = '*';
                    timeMask.PromptChar = '*';
                    phoneMask.PromptChar = '*';
                    ipMask.PromptChar = '*';
                    debitMask.PromptChar = '*';
                    break;
                case 2:
                    emailMask.PromptChar = '#';
                    dateMask.PromptChar = '#';
                    timeMask.PromptChar = '#';
                    phoneMask.PromptChar = '#';
                    ipMask.PromptChar = '#';
                    debitMask.PromptChar = '#';
                    break;
            }
        }
    }
}
