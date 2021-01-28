#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace syncfusion.editordemos.winui.Views.DatePicker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Customization : Page
    {
        public Customization()
        {
            this.InitializeComponent();
            this.BlackoutPicker.SelectedDate = new DateTime(2020, 12, 14);
        }

        private void OnDateFieldPrepared(object sender, Syncfusion.UI.Xaml.Editors.DateTimeFieldPreparedEventArgs e)
        {
            if (e.Column != null && e.Column.Field == Syncfusion.UI.Xaml.Editors.DateTimeField.Day)
            {
                e.Column.Format = "ddd dd";
            }
        }

        private void OnDateFieldItemPrepared(object sender, Syncfusion.UI.Xaml.Editors.DateTimeFieldItemPreparedEventArgs e)
        {
            if (e.ItemInfo != null && e.ItemInfo.Field == Syncfusion.UI.Xaml.Editors.DateTimeField.Day &&
                e.ItemInfo.DateTime.Value != null && (e.ItemInfo.DateTime.Value.DayOfWeek == DayOfWeek.Saturday ||
                e.ItemInfo.DateTime.Value.DayOfWeek == DayOfWeek.Sunday))
            {
                e.ItemInfo.IsBlackout = true;
                e.Element.ContentTemplate = this.Resources["BlackoutWeekendTemplate"] as DataTemplate;
            }
        }
    }
}
