#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Microsoft.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Syncfusion.CalendarDemos.WinUI.Views.Calendar
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StylesAndTemplates : Page, IDisposable
    {
        public StylesAndTemplates()
        {
            this.InitializeComponent();
            this.styleAndTemplatesViewPanel.PointerPressed += OnStyleAndTemplatesViewPanelPointerPressed;
        }

        private void OnStyleAndTemplatesViewPanelPointerPressed(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            // To restrict the focus on first control when clicking on empty area.
            e.Handled = true;
        }

        public void Dispose()
        {
            this.styleAndTemplatesViewPanel.PointerPressed -= OnStyleAndTemplatesViewPanelPointerPressed;
            if (this.calendar7 != null)
            {
                this.calendar7.Dispose();
                this.calendar7 = null;
            }

            if (this.calendar8 != null)
            {
                this.calendar8.Dispose();
                this.calendar8 = null;
            }
        }
    }
}
