#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.Editors;
using System;
using Windows.UI.Popups;

namespace Syncfusion.EditorDemos.WinUI.Views.MaskedTextBox
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InputValidationView : Page
    {

        private bool accountIsValid;
        private bool amountIsValid;
        private bool emailIsValid;
        private bool phoneIsValid;

        public InputValidationView()
        {
            this.InitializeComponent();           
        }

        private async void SubmitButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            if (!accountIsValid || !amountIsValid || !emailIsValid || !phoneIsValid || DescriptionTextBox.Text == string.Empty)
            {
                var contentDialog = new ContentDialog
                {
                    Content = "Please enter all the required data.",
                    CloseButtonText = "Close"
                };
                contentDialog.XamlRoot = this.Content.XamlRoot;
                await contentDialog.ShowAsync();
            }
            else
            {
                var contentDialog = new ContentDialog
                {
                    Content = string.Format("Amount of {0} has been transferred successfully!", AmountMaskedTextBox.Value),
                    CloseButtonText = "Close"
                };
                contentDialog.XamlRoot = this.Content.XamlRoot;
                await contentDialog.ShowAsync();
            }
        }

        private void AccountMaskedTextBox_ValueChanging(object sender, MaskedTextBoxValueChangingEventArgs e)
        {
            accountIsValid = e.IsValid;
        }

        private void AmountMaskedTextBox_ValueChanging(object sender, MaskedTextBoxValueChangingEventArgs e)
        {
            amountIsValid = e.IsValid;
        }

        private void EmailMaskedTextBox_ValueChanging(object sender, MaskedTextBoxValueChangingEventArgs e)
        {
            emailIsValid = e.IsValid;
        }

        private void PhoneMaskedTextBox_ValueChanging(object sender, MaskedTextBoxValueChangingEventArgs e)
        {
            phoneIsValid = e.IsValid;
        }
    }
}
