#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.DemosCommon.WinUI;
using System;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Syncfusion.ChartDemos.WinUI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DataCleaning_Preprocessing : Page, IDisposable
    {
        private readonly AzureAIService azureAIService;
        public DataCleaning_Preprocessing()
        {
            this.InitializeComponent();
            azureAIService = new AzureAIService();
            viewModel.IsVisible = Visibility.Visible;
            viewModel.IsBusy = true;
            this.azureAIService.IsCredentialsValid();

            if (AISettings.IsCredentialValid)
            {
                LoadAICleanedData();
            }
            else
            {
                AISettings.ContentDialog.Closed += (s, e) => ClosedButtonClicked();
            }
        }

        public void Dispose()
        {
            Chart.Dispose();
            parentGrid.Children.Clear();
        }

        private void ClosedButtonClicked()
        {
            LoadAICleanedData();
        }

        private async void LoadAICleanedData()
        {
            await Task.Delay(1000);
            await viewModel.LoadCleanedDataAsync();
        }
    }
}
