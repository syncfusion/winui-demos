#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Extensions.AI;
using Syncfusion.DemosCommon.WinUI;
using System;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;

namespace DataGrid
{
    /// <summary>
    /// Provides access to the Azure AI service for performing AI operations.
    /// </summary>
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
            catch(Exception ex)
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

        /// <summary>
        /// Method to verify the credentials.
        /// </summary>
        /// <returns><b>true</b> if the credentials are valid;otherwise <b>false</b></returns>
        internal async Task<bool> IsCredentialsValid()
        {
            if (!AISettings.IsCredentialValid)
            {
                await AISettings.ShowAISettingsWindow();
            }
            return AISettings.IsCredentialValid;
        }
    }
}
