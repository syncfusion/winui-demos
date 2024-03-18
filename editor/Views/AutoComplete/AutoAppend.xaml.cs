#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.Editors;

namespace Syncfusion.EditorDemos.WinUI.Views.AutoComplete
{
    /// <summary>
    /// AutoComplete auto append demo class
    /// </summary>
    public sealed partial class AutoAppend : Page
    {
        public AutoAppend()
        {
            this.InitializeComponent();
        }

        private void appendTypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (appendType.SelectedIndex == 0)
            {
                autoAppendAutoComplete.AppendType = AutoCompleteAutoAppendType.TextWithSelection;
            }
            else
            {
                autoAppendAutoComplete.AppendType = AutoCompleteAutoAppendType.Text;
            }
        }
    }
}
