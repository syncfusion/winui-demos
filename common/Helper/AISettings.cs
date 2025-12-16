#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Extensions.AI;
using Azure.AI.OpenAI;
using Azure;

namespace Syncfusion.DemosCommon.WinUI
{
    /// <summary>
    /// Represents a helper class that contain API related to AI Services.
    /// </summary>
    public static class AISettings
    {
        static string modelName = string.Empty;
        static string key = string.Empty;
        static string endPoint = string.Empty;
        static bool isValidationProgress = false;
        private static AISettingsWindow aISetUpWindow;
        static IChatClient clientAI;

        /// <summary>
        /// Gets or sets an instance of the ContentDialog.
        /// </summary>
        public static ContentDialog ContentDialog
        {
            get; private set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the AI Credentials is valid or not.
        /// </summary>
        public static bool IsCredentialValid
        {
            get; private set;
        }

        /// <summary>
        /// Gets or sets a value indicating the AI chat client.
        /// </summary>
        public static IChatClient ClientAI
        {
            get
            {
                return clientAI;
            }
            set
            {
                clientAI = value;
            }
        }

        /// <summary>
        /// Gets or sets the model name in the AI Setup Window.
        /// </summary>
        public static string ModelName
        {
            get
            {
                return modelName;
            }
            set
            {
                if (ModelName != value)
                {
                    modelName = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the end point in the AI Setup Window.
        /// </summary>
        public static string EndPoint
        {
            get
            {
                return endPoint;
            }
            set
            {
                if (endPoint != value)
                {
                    endPoint = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the key in the AI Setup Window.
        /// </summary>
        public static string Key
        {
            get
            {
                return key;
            }
            set
            {
                if (key != value)
                {
                    key = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating DataContext of MainWindow. 
        /// </summary>
        internal static MainViewModel MainViewModel
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating the error message details.
        /// </summary>
        internal static string ErrorMessage
        {
            get;
            set;
        }

        /// <summary>
        /// Helps to show AISettingsWindow.
        /// </summary>
        public async static Task<ContentDialogResult> ShowAISettingsWindow()
        {
            MainViewModel.ErrorText = String.Empty;
            MainViewModel.ModelName = ModelName;
            MainViewModel.Key = Key;
            MainViewModel.EndPoint = EndPoint;
            aISetUpWindow = new AISettingsWindow();
            aISetUpWindow.DataContext = MainViewModel;
            ContentDialog = new ContentDialog
            {
                Content = aISetUpWindow,
                CloseButtonText = "Submit",
                PrimaryButtonText = "Cancel",
                Title = "Essential Studio® AI Setup",
            };

            ContentDialog.DefaultButton = ContentDialogButton.Close;
            ContentDialog.PrimaryButtonClick += CancelButtonClick;
            ContentDialog.CloseButtonClick += SubmitButtonClick;
            ContentDialog.Closing += ContentDialogClosing;
            ContentDialog.Closed += ContentDialogClosed;
            ContentDialog.XamlRoot = NavigationService.Frame.XamlRoot;
            ContentDialog.RequestedTheme = ThemeHelper.RootTheme;
            var result = await ContentDialog.ShowAsync();
            return result;
        }

        /// <summary>
        /// Occurs after the dialog is closed.
        /// </summary>
        private static void ContentDialogClosed(ContentDialog sender, ContentDialogClosedEventArgs args)
        {
            MainViewModel.IsValidating = false;
            ContentDialog.PrimaryButtonClick -= CancelButtonClick;
            ContentDialog.CloseButtonClick -= SubmitButtonClick;
            ContentDialog.Closing -= ContentDialogClosing;
            ContentDialog.Closed -= ContentDialogClosed;
        }

        /// <summary>
        /// Occurs after the dialog starts to close, but before it is closed and before the Closed event occurs.
        /// </summary>
        private static void ContentDialogClosing(ContentDialog sender, ContentDialogClosingEventArgs args)
        {
            if (isValidationProgress)
            {
                args.Cancel = true;
            }
        }

        /// <summary>
        /// Occurs after the cancel button is clicked.
        /// </summary>
        private static void CancelButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            MainViewModel.ModelName = ModelName;
            MainViewModel.Key = Key;
            MainViewModel.EndPoint = EndPoint;
            ContentDialog.Hide();
        }

        /// <summary>
        /// Occurs after the submit button is clicked.
        /// </summary>
        private static async void SubmitButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            MainViewModel.IsValidating = true;
            await AISettings.ValidateCredentials();
            MainViewModel.IsValidating = false;
            if (string.IsNullOrEmpty(AISettings.ErrorMessage))
            {
                MainViewModel.ErrorText = string.Empty;
                AISettings.CloseAISettingsWindow();
            }
            else
            {
                MainViewModel.ErrorText = AISettings.ErrorMessage + " !!!";
                args.Cancel = true;
            }
        }

        /// <summary>
        /// Helps to close the AISettingsWindow.
        /// </summary>
        internal static void CloseAISettingsWindow()
        {
            ModelName = MainViewModel.ModelName;
            Key = MainViewModel.Key;
            EndPoint = MainViewModel.EndPoint;
            ContentDialog.Hide();
        }

        /// <summary>
        /// Validates the AI credentials and initializes the AI client.
        /// </summary>
        public static async Task<bool> ValidateCredentials()
        {
            isValidationProgress = true;
            ErrorMessage = string.Empty;
            Uri uriResult;
            bool isValidUri = Uri.TryCreate(MainViewModel.EndPoint, UriKind.Absolute, out uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if (!isValidUri || !MainViewModel.EndPoint.Contains("http"))
            {
                ErrorMessage = "Please enter valid EndPoint.";
            }
            else
            {
                try
                {
                    clientAI = new AzureOpenAIClient(new Uri(MainViewModel.EndPoint), new AzureKeyCredential(MainViewModel.Key)).AsChatClient(modelId: MainViewModel.ModelName);

                    if (ClientAI != null)
                    {
                        await ClientAI.CompleteAsync("Hello, Test Check");
                    }
                }
                catch (Exception ex)
                {
                    //Check the error message and display the appropriate message
                    if (ex.Message.Contains("API deployment"))
                    {
                        ErrorMessage = "Please enter valid ModelName.";
                    }
                    else if (ex.Message.Contains("Access denied"))
                    {
                        ErrorMessage = "Please enter valid Key.";
                    }
                    else
                    {
                        ErrorMessage = "Please enter valid EndPoint.";
                    }
                }
            }
            

            IsCredentialValid = string.IsNullOrEmpty(ErrorMessage) ? true : false;
            isValidationProgress = false;

            return IsCredentialValid;

        }
    }
}