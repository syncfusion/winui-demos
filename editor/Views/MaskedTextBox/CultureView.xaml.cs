#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;
using System.Globalization;

namespace Syncfusion.EditorDemos.WinUI.Views.MaskedTextBox
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CultureView : Page
    {
        public CultureView()
        {
            this.InitializeComponent();
        }

        private void CultureComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(cultureComboBox.SelectedIndex)
            {
                case 0:
                    cultureMask.Culture = new CultureInfo("en-US");
                    break;
                case 1:
                    cultureMask.Culture = new CultureInfo("ru-RU");
                    break;
                case 2:
                    cultureMask.Culture = new CultureInfo("fr-FR");
                    break;
            }
        }
    }
}
