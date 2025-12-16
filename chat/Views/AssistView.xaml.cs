#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
using Microsoft.Win32;
using Syncfusion.DemosCommon.WinUI;
using Syncfusion.UI.Xaml.Chat;
using Syncfusion.UI.Xaml.Editors;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.NetworkOperators;
using Windows.Storage;
using Windows.Storage.Pickers;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.ChatDemos.WinUI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AssistView : Page
    {
        bool isSuggestionSelected = false;
        public AssistView()
        {
            this.InitializeComponent();
            var msgs = this.DataContext as AIAssistViewModel;
            msgs.InitAI();
        }

        private void Chat_SuggestionSelected(object sender, SuggestionClickedEventArgs e)
        {
            var msgs = chat.DataContext as AIAssistViewModel;
            msgs.Chats.Add(new TextMessage { Text = e.Item.ToString(), DateTime = DateTime.Now, Author = chat.CurrentUser });
            isSuggestionSelected = true;
        }

        private void chat_StopResponding(object sender, EventArgs e)
        {
            var msgs = chat.DataContext as AIAssistViewModel;
            msgs.isStopResponding = true;
        }

        private void chat_ResponseToolbarItemClicked(object sender, ResponseToolbarItemClickedEventArgs e)
        {
            var msgs = chat.DataContext as AIAssistViewModel;
            msgs.ResponseToolbarItemClicked(e);
        }

        private async void chat_InputToolbarItemClicked(object sender, InputToolbarItemClickedEventArgs e)
        {
            var openPicker = new FileOpenPicker();
            foreach (var ext in new[] { ".xml", ".txt", ".html", ".htm", ".md" , ".json" })
                openPicker.FileTypeFilter.Add(ext);
            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(ThemeHelper.CurrentApplicationWindow);
            WinRT.Interop.InitializeWithWindow.Initialize(openPicker, hwnd);
            var file = await openPicker.PickSingleFileAsync();

            var viewModel = this.DataContext as AIAssistViewModel;
            if (file != null)
            {
                // Get file details
                var properties = await file.GetBasicPropertiesAsync();
                var size = properties.Size;

                string fileSize = size < 1024 ? $"{size} B" 
                                : size < (1024 * 1024) ? $"{size / 1024} KB"
                                : $"{size / (1024 * 1024)} MB";

                var UploadedFile = new FileInfo();
                // Update ViewModel
                UploadedFile.Path = file.Path;
                UploadedFile.Name = file.Name;
                UploadedFile.Size = fileSize;

                viewModel.Files.Add(UploadedFile);

            }
        }

        private void Chat_PromptRequest(object sender, PromptRequestEventArgs e)
        {
            if(isSuggestionSelected)
            {
                isSuggestionSelected = false;
                return; 
            }
            e.Handled = true;
            var assistViewModel = chat.DataContext as AIAssistViewModel;
            ObservableCollection<FileInfo> uploadedFile = new ObservableCollection<FileInfo>();
            ITextMessage textMessage = e.InputMessage as ITextMessage;

            foreach (var msg in assistViewModel.Files)
            {
                uploadedFile.Add(new FileInfo { Name = msg.Name, Size = msg.Size, Path = msg.Path });
            }

            if (uploadedFile.Count > 0)
            {
                assistViewModel.Chats.Add(new FileItemMessage
                {

                    Text = textMessage.Text.ToString(),
                    DateTime = DateTime.Now,
                    Author = chat.CurrentUser,
                    Files = uploadedFile

                });
            }
            else
            {
                assistViewModel.Chats.Add(new TextMessage
                {
                    Text = textMessage.Text.ToString(),
                    DateTime = DateTime.Now,
                    Author = chat.CurrentUser,

                });
            }

            if (assistViewModel.Files != null)
            {
                assistViewModel.Files.Clear();
            }             
        }
    }
}
