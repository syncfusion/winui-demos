#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Syncfusion.UI.Xaml.Core;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Microsoft.UI.Xaml.Media.Imaging;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using Syncfusion.UI.Xaml.Chat;
using System.Threading.Tasks;
using Syncfusion.DemosCommon.WinUI;
using Windows.ApplicationModel.DataTransfer;

namespace Syncfusion.ChatDemos.WinUI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Overview : Page
    {
        public Overview()
        {
            this.InitializeComponent();
            var msgs = this.DataContext as OverviewViewModel;
            msgs.InitAI();
        }

        private void chat_MenuItemClicked(object sender, MenuItemClickedEventArgs e)
        {
            var msgs = chat.DataContext as OverviewViewModel;
            msgs.chat_MenuItemClicked(e);
            if (e.MenuType == MenuItemType.Copy)
            {
                oneNote.Text = oneNote.Text + "\n\n" + (e.ChatItem.DataContext as AIMessage).Solution;
                AssistFlyOut.Hide();
            }
        }

        private void chat_SuggestionSelected(object sender, SuggestionClickedEventArgs e)
        {
            var msgs = chat.DataContext as OverviewViewModel;
            msgs.Chats.Add(new TextMessage { Text = e.Item.ToString(), DateTime = DateTime.Now, Author = chat.CurrentUser });
        }
    }
}