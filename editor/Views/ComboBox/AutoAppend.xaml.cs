#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.Editors;
using System;

namespace Syncfusion.EditorDemos.WinUI.Views.ComboBox
{
    /// <summary>
    /// ComboBox auto append demo class
    /// </summary>
    public sealed partial class AutoAppend : Page, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoAppend"/> class.
        /// </summary>
        public AutoAppend()
        {
            this.InitializeComponent();
        }

        private void autoAppendTypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (autoAppendType.SelectedIndex == 0)
            {
                comboBoxAutoAppend.AutoAppendType = ComboBoxAutoAppendType.TextWithSelection;
            }
            else
            {
                comboBoxAutoAppend.AutoAppendType = ComboBoxAutoAppendType.Text;
            }
        }

        /// <summary>
        /// To dispose objects.
        /// </summary>
        public void Dispose()
        {
            if (this.comboBoxAutoAppend != null)
            {
                this.comboBoxAutoAppend.Dispose();
            }

            this.Resources.Clear();
            this.DataContext = null;
        }
    }
}
