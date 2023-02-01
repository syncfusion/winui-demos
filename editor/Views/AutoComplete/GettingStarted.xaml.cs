#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
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
    public sealed partial class GettingStarted : Page, IDisposable
    {
        public GettingStarted()
        {
            this.InitializeComponent();
        }

        private void sfautocomplete1_SelectionChanged(object sender, Syncfusion.UI.Xaml.Editors.AutoCompleteSelectionChangedEventArgs e)
        {
            if(CustomAutoComplete.SelectedItem!=null)
            {
                selecteditem.Visibility = Visibility.Visible;
                employeeImage.Source = (CustomAutoComplete.SelectedItem as Employee).ProfilePicture;
                employeeName.Text = (CustomAutoComplete.SelectedItem as Employee).Name;
            }
            else
            {
                selecteditem.Visibility = Visibility.Collapsed;
            }
        }

        private void sfautocomplete1_TextSubmitted(object sender, Syncfusion.UI.Xaml.Editors.AutoCompleteInputSubmittedEventArgs e)
        {
            string path = @"ms-appx:///";
#if Main_SB
            path = @"ms-appx:///Editor/";
#endif

            e.Item = new Employee() { Name = e.Text,
                                    ProfilePicture= new BitmapImage(new Uri(path + "Assets/ComboBox/Employees/NewEmployee.png", UriKind.RelativeOrAbsolute)) };

        }

        /// <summary>
        /// To dispose objects.
        /// </summary>
        public void Dispose()
        {
            if (this.sfautocomplete != null)
            {
                this.sfautocomplete.Dispose();
            }
            if (this.CustomAutoComplete != null)
            {
                this.CustomAutoComplete.Dispose();
            }
            this.Resources.Clear();
            this.DataContext = null;
        }
    }
}
