#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Syncfusion.UI.Xaml.Editors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.EditorDemos.WinUI.Views.MaskedTextBox
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ErrorIndicationView : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorIndicationView"/> class.
        /// </summary>
        public ErrorIndicationView()
        {
            this.InitializeComponent();
        }
        ErrorType errorType = ErrorType.None;

        private void errorTypeMaskTextBox_ValueChanging(object sender, MaskedTextBoxValueChangingEventArgs e)
        {
            errorTypeMaskTextBox.ErrorType = e.IsValid ? ErrorType.Success : errorType;
        }

        private void noneRadioButton_Click(object sender, RoutedEventArgs e)
        {
            errorTypeMaskTextBox.ErrorType = errorType = ErrorType.None;
        }

        private void defaultRadioButton_Click(object sender, RoutedEventArgs e)
        {
            errorTypeMaskTextBox.ErrorType = errorType = ErrorType.Default;
        }

        private void informationRadioButton_Click(object sender, RoutedEventArgs e)
        {
            errorTypeMaskTextBox.ErrorType = errorType = ErrorType.Information;
        }

        private void criticalRadioButton_Click(object sender, RoutedEventArgs e)
        {
            errorTypeMaskTextBox.ErrorType = errorType = ErrorType.Critical;
        }

        private void warningRadioButton_Click(object sender, RoutedEventArgs e)
        {
            errorTypeMaskTextBox.ErrorType = errorType = ErrorType.Warning;
        }

        private void SfDropDownColorPalette_SelectedBrushChanged(object sender, SelectedBrushChangedEventArgs e)
        {
            customErrorTypeMaskTextBox.CustomErrorBorderBrush = (SolidColorBrush)e.NewBrush;
        }

        private void customErrorTypeMaskTextBox_ValueChanging(object sender, MaskedTextBoxValueChangingEventArgs e)
        {
            customErrorTypeMaskTextBox.ErrorType = e.IsValid ? ErrorType.Success : ErrorType.Custom;
        }
    }
}
