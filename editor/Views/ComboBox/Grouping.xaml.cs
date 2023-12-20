#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.EditorDemos.WinUI.Views.ComboBox
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Grouping : Page, IDisposable
    {
        public Grouping()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// To dispose objects.
        /// </summary>
        public void Dispose()
        {
            if (this.GroupingComboBox != null)
            {
                this.GroupingComboBox.Dispose();
            }

            this.Resources.Clear();
            this.DataContext = null;
        }
    }
}
