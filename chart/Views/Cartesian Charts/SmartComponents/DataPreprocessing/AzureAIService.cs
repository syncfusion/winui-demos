using Microsoft.Extensions.AI;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.DemosCommon.WinUI;
using System;
using System.Threading.Tasks;

namespace Syncfusion.ChartDemos.WinUI
{
    public class AzureAIService
    {
        private bool _isDialogOpen = false;

        /// <summary>
        /// Method to get the response from GPT using the Azure AI.
        /// </summary>
        /// <param name="prompt">Prompt for the system message</param>
        /// <returns>The AI results.</returns>
        public async Task<string> GetResponseFromGPT(string prompt)
        {
            try
            {
                if (AISettings.ClientAI != null)
                {
                    //// Send the chat completion request to the AzureAI API and await the response.
                    var response = await AISettings.ClientAI.CompleteAsync(prompt);
                    return response.ToString();
                }
            }
            catch (Exception ex)
            {
                // Return null if an exception occurs
                ShowErrorMessage("An error occurred : " + ex.Message);
                return null;
            }
            return string.Empty;
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

        internal bool IsCredentialsValid()
        {
            if (!AISettings.IsCredentialValid)
            {
                _ = AISettings.ShowAISettingsWindow();
            }
            return AISettings.IsCredentialValid;
        }
    }
}
