#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Syncfusion.UI.Xaml.Core;
using System;

namespace syncfusion.ribbondemos.winui
{
    /// <summary>
    /// A view model class for ribbon view.
    /// </summary>
    public class ViewModel : NotificationObject
    {
        public ICommand CloseButtonCommand { get; set; }

        public ICommand SaveCommand { get; set; }

        public ICommand OptionCommand { get; set; }

        public ICommand ButtonCommand { get; set; }

        private string status;

        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                RaisePropertyChanged("Status");
            }
        }

        public ViewModel()
        {
            this.CloseButtonCommand = new DelegateCommand(ExecuteCloseAsync, CanExecuteCommand);
            this.SaveCommand = new DelegateCommand(ExecuteSaveAsync, CanExecuteCommand);
            this.OptionCommand = new DelegateCommand(ExecuteOption, CanExecuteCommand);
            this.ButtonCommand = new DelegateCommand(ExecuteButtonCommand, CanExecuteCommand);
        }


        private bool CanExecuteCommand(object parameter)
        {
            return true;
        }

        private async void ExecuteCloseAsync(object parameter)
        {
            ContentDialog contentDialog1 = new ContentDialog();
            contentDialog1.Title = "Close button clicked";
            contentDialog1.PrimaryButtonText = "Exit";
            await contentDialog1.ShowAsync();
        }

        private async void ExecuteSaveAsync(object parameter)
        {
            ContentDialog contentDialog1 = new ContentDialog();
            contentDialog1.Title = "Save button clicked";
            contentDialog1.PrimaryButtonText = "Close";
            await contentDialog1.ShowAsync();
        }

        private async void ExecuteOption(object parameter)
        {
            ContentDialog contentDialog1 = new ContentDialog();
            contentDialog1.Title = "Option button clicked";
            contentDialog1.PrimaryButtonText = "Close";
            await contentDialog1.ShowAsync();
        }

        private void ExecuteButtonCommand(object parameter)
        {
            this.Status = $" {parameter}";
        }
    }
}
