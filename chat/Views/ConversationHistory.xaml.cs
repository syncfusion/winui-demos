using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.DemosCommon.WinUI;
using Syncfusion.UI.Xaml.Chat;
using System;

namespace Syncfusion.ChatDemos.WinUI.Views
{
    /// <summary>
    /// Code-behind for the Conversation History sample. Wires up the
    /// <see cref="SfAIAssistView"/> events to the
    /// <see cref="ConversationHistoryViewModel"/> and ensures the first stored
    /// conversation is loaded on entry.
    /// </summary>
    public sealed partial class ConversationHistory : Page
    {
        public ConversationHistory()
        {
            this.InitializeComponent();
            this.Loaded += ConversationHistory_Loaded;
        }

        private void ConversationHistory_Loaded(object sender, RoutedEventArgs e)
        {
            // Defer initialization until after the SfAIAssistView template has been
            // applied. Otherwise the initial messages can be dropped before the
            // ChatItemsView template child is available.
            var msgs = this.DataContext as ConversationHistoryViewModel;
            if (msgs != null)
            {
                // Only initialize the AI service. Chats is left empty so the
                // EmptyView (welcome content) is displayed until the user picks
                // a past conversation or types a new prompt.
                msgs.InitAI();
            }
        }

        private void Chat_StopResponding(object sender, EventArgs e)
        {
            var msgs = chat.DataContext as ConversationHistoryViewModel;
            msgs.isStopResponding = true;
        }

        private void Chat_ResponseToolbarItemClicked(object sender, ResponseToolbarItemClickedEventArgs e)
        {
            var msgs = chat.DataContext as ConversationHistoryViewModel;
            msgs.ResponseToolbarItemClicked(e);
        }

        private async void Chat_PromptRequest(object sender, PromptRequestEventArgs e)
        {
            e.Handled = true;
            var assistViewModel = chat.DataContext as ConversationHistoryViewModel;
            ITextMessage textMessage = e.InputMessage as ITextMessage;

            string userText = textMessage.Text.ToString();

            assistViewModel.Chats.Add(new TextMessage
            {
                Text = userText,
                DateTime = DateTime.Now,
                Author = chat.CurrentUser,
            });

            // Manually trigger the AI response for the newly-typed prompt. This is
            // the only path that shows the typing indicator and adds a bot reply.
            await assistViewModel.SendUserMessageAsync(userText);
        }
    }
}
