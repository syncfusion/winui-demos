#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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

namespace Syncfusion.EditorDemos.WinUI.Views.AutoComplete
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MultiSelection : Page, IDisposable
    {
        public MultiSelection()
        {
            this.InitializeComponent();
            customAutoComplete.TextSearchMode = AutoCompleteTextSearchMode.Contains;
        }

        private async void customAutoComplete_TextSubmitted(object sender, AutoCompleteInputSubmittedEventArgs e)
        {
            e.Handled = true;
            var cd = new ContentDialog
            {
                Content = "Enter a valid country.",
                CloseButtonText = "Close"
            };

            cd.XamlRoot = this.Content.XamlRoot;
            var result = await cd.ShowAsync();
        }
      

        private async void MultiSelectionAutoComplete_TextSubmitted(object sender, AutoCompleteInputSubmittedEventArgs e)
        {
            e.Handled = true;
            var cd = new ContentDialog
            {
                Content = "Enter a valid Mail-Id",
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
            if (MultiSelectionAutoComplete != null)
            {
                this.MultiSelectionAutoComplete.Dispose();
            }
            if (customAutoComplete != null)
            {
                this.customAutoComplete.Dispose();
            }
            this.Resources.Clear();
            this.DataContext = null;
        }

    }
}
