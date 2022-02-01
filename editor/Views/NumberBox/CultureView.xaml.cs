#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.Editors;
using System;
using System.Globalization;
using System.Threading;
using Windows.Globalization;
using Windows.Globalization.NumberFormatting;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace syncfusion.editordemos.winui.Views.NumberBox
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CultureView : Page
    {
        //Culture variable that will be applied to the application.
        CultureInfo ci;

        public CultureView()
        {
            this.InitializeComponent();
            this.cultureComboBox.SelectionChanged += this.OnCultureSelectionChanged;
        }

        /// <summary>
        /// Occurs when culture option is changed.
        /// </summary>
        private void OnCultureSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (cultureComboBox != null && cultureComboBox.SelectedValue != null)
            {
                //Setting selected culture to the application.
                ci = new CultureInfo(cultureComboBox.SelectedValue.ToString());
                currencyNumberBox.Culture = ci;
                decimalNumberBox.Culture = ci;
                percentNumberBox.Culture = ci;

            }
        }
     
    }
}