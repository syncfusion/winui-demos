#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel;
using Syncfusion.DemosCommon.WinUI;
using System;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;

namespace DataGrid
{
    /// <summary>
    /// Provides access to the SemanticKernel service for performing AI operations.
    /// </summary>
    public class SemanticKernelAI
    {
        /// <summary>
        /// Holds the IChatCompletionService instance.
        /// </summary>
        private IChatCompletionService chatCompletionService;

        /// <summary>
        /// Holds the Kernel instance.
        /// </summary>
        private Kernel kernel;

        private bool _isDialogOpen = false;

        /// <summary>
        /// Method to get the response from GPT using the semantic kernel
        /// </summary>
        /// <param name="prompt">Prompt for the system message</param>
        /// <returns>The AI results.</returns>
        public async Task<string> GetResponseFromGPT(string prompt)
        {
            try
            {
                var builder = Kernel.CreateBuilder().AddAzureOpenAIChatCompletion(AISettings.ModelName, AISettings.EndPoint, AISettings.Key);
                kernel = builder.Build();
                chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

                var history = new ChatHistory();
                history.AddSystemMessage(prompt);
                OpenAIPromptExecutionSettings openAIPromptExecutionSettings = new OpenAIPromptExecutionSettings();
                openAIPromptExecutionSettings.ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions;
                var result = await chatCompletionService.GetChatMessageContentAsync(
                history,
                executionSettings: openAIPromptExecutionSettings,
                kernel: kernel);

                return result.ToString();
            }
            catch(Exception ex)
            {
                // Return null if an exception occurs
                ShowErrorMessage("An error occurred : " + ex.Message);
                return null;
            }
        }
       
        internal async void ShowErrorMessage(string errorMessage)
        {
            if (_isDialogOpen)
                return; // Exit if a dialog is already open

            _isDialogOpen = true;
            ContentDialog errorDialog = new ContentDialog
            {
                Title = "Error",
                Content = errorMessage,
                CloseButtonText = "OK",
                DefaultButton = ContentDialogButton.Close
            };

            errorDialog.XamlRoot = NavigationService.Frame.XamlRoot; ;

            await errorDialog.ShowAsync();
            _isDialogOpen = false;
        }

        /// <summary>
        /// Method to verify the credentials.
        /// </summary>
        /// <returns><b>true</b> if the credentials are valid;otherwise <b>false</b></returns>
        internal bool IsCredentialsValid()
        {
            if (!AISettings.IsCredentialValid)
            {
                AISettings.ShowAISettingsWindow();
            }
            return AISettings.IsCredentialValid;
        }
    }
}
