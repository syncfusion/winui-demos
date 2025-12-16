#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Text;
using System.Windows.Input;
using Syncfusion.UI.Xaml.Core;
using Syncfusion.UI.Xaml.Ribbon;
using System;
using System.Collections.Generic;
using Windows.UI.Text;

namespace Syncfusion.RibbonDemos.WinUI
{
    /// <summary>
    /// A view model class for ribbon view.
    /// </summary>
    public class ViewModel : NotificationObject
    {
        /// <summary>
        /// Gets or sets the command that is executed when the Close button is clicked
        /// </summary>
        public ICommand CloseButtonCommand { get; set; }
        /// <summary>
        /// Gets or sets the command that is executed when the save button is clickes
        /// </summary>
        public ICommand SaveCommand { get; set; }
        /// <summary>
        /// Gets or sets the command that is executed when the Option is clicked
        /// </summary>
        public ICommand OptionCommand { get; set; }
        /// <summary>
        /// Gets or sets the command that is executed when the Button is selected
        /// </summary>
        public ICommand ButtonCommand { get; set; }

        private string status;
        /// <summary>
        /// Gets or sets the status message, which is often displayed in a status bar or a text block.
        /// </summary>
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                RaisePropertyChanged("Status");
            }
        }
        private List<FontStyleInfo> fontStyles;
        /// <summary>
        /// Gets or sets the collection of font style information objects.
        /// </summary>
        public List<FontStyleInfo> FontStyles
        {
            get { return fontStyles; }
            set { fontStyles = value; }
        }

        private object selectedItem;
        /// <summary>
        /// Gets or sets the currently selected item, which can be a <see cref="RibbonGalleryItem"/> or a <see cref="FontStyleInfo"/> object.
        /// Handles updating related text properties based on the selected item's type.
        /// </summary>
        public object SelectedItem
        {
            get { return selectedItem; }
            set 
            { 
                selectedItem = value;
                if (selectedItem is RibbonGalleryItem)
                {
                    if ((SelectedItem as RibbonGalleryItem).Content is TextBlock textBlock)
                    {
                        this.CellStyleText = textBlock.Text;
                    }
                    else if (VisualTree.FindDescendant<TextBlock>((SelectedItem as RibbonGalleryItem)?.ContentTemplateRoot) is TextBlock textBlock1)
                    {
                        this.CellStyleText = textBlock1.Text;
                    }
                    else
                    {
                        this.CellStyleText = (string)(SelectedItem as RibbonGalleryItem).Content;
                    }
                }
                else
                {
                    this.FontStyleText = (string)(SelectedItem as FontStyleInfo).FontDescription;
                }
                RaisePropertyChanged(nameof(SelectedItem));
            }
        }

        private string fontStyleText;
        /// <summary>
        /// Gets or sets the text representing the selected font style description.
        /// </summary>
        public string FontStyleText
        {
            get { return fontStyleText; }
            set 
            { 
                fontStyleText = value; 
                RaisePropertyChanged(nameof(FontStyleText)); 
            }
        }

        private string cellStyleText;
        /// <summary>
        /// Gets or sets the text representing a cell style, potentially from a RibbonGalleryItem.
        /// </summary>
        public string CellStyleText
        {
            get { return cellStyleText; }
            set 
            { 
                cellStyleText = value; 
                RaisePropertyChanged(nameof(CellStyleText)); 
            }
        }
        private double fontSize=14;
        /// <summary>
        /// Gets or sets the font size for text elements.
        /// </summary>
        public double FontSize
        {
            get { return fontSize; }
            set
            {
                fontSize = value;
                RaisePropertyChanged(nameof(FontSize));
            }
        }

        private FontWeight fontWeight= FontWeights.Normal;
        /// <summary>
        /// Gets or sets the font weight (e.g., Normal, Bold).
        /// </summary>
        public FontWeight FontWeight
        {
            get { return fontWeight; }
            set
            {
                fontWeight = value;
                RaisePropertyChanged(nameof(FontWeight));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// Sets up commands, initializes the font styles collection, and populates it with sample data.
        /// </summary>
        public ViewModel()
        {
            this.fontStyles = new List<FontStyleInfo>();
            this.CloseButtonCommand = new DelegateCommand(ExecuteCloseAsync, CanExecuteCommand);
            this.SaveCommand = new DelegateCommand(ExecuteSaveAsync, CanExecuteCommand);
            this.OptionCommand = new DelegateCommand(ExecuteOption, CanExecuteCommand);
            this.ButtonCommand = new DelegateCommand(ExecuteButtonCommand, CanExecuteCommand);
            this.fontStyles = GetFontStyleCollection();
        }

        /// <summary>
        /// Generates a collection of <see cref="FontStyleInfo"/> objects for demonstration purposes.
        /// This includes various font styles, sizes, weights, and margins.
        /// </summary>
        /// <returns>A list of <see cref="FontStyleInfo"/> objects.</returns>
        private List<FontStyleInfo> GetFontStyleCollection()
        {
            fontStyles.Add(new FontStyleInfo() { FontText = "AaBbCcDd", FontDescription = "Normal", FontWeight = FontWeights.Normal });
            fontStyles.Add(new FontStyleInfo() { FontText = "AaBbCcDd", FontDescription = "No Spacing", FontWeight = FontWeights.Normal });
            fontStyles.Add(new FontStyleInfo() { FontText = "AaBbCcDd", FontDescription = "Heading 1", FontSize = 17 });
            fontStyles.Add(new FontStyleInfo() { FontText = "AaBbCcDd", FontDescription = "Heading 2" });
            fontStyles.Add(new FontStyleInfo() { FontText = "AaB", FontDescription = "Title", FontWeight = FontWeights.SemiBold, FontSize = 26, Margin = new Microsoft.UI.Xaml.Thickness() { Left = 0, Top = -10, Right = 2, Bottom = 0 } });
            fontStyles.Add(new FontStyleInfo() { FontText = "AaBbCcDd", FontDescription = "Subtile" });
            fontStyles.Add(new FontStyleInfo() { FontText = "AaBbCcDd", FontDescription = "Subtle Emphasis", FontStyle = FontStyle.Italic });
            fontStyles.Add(new FontStyleInfo() { FontText = "AaBbCcDd", FontDescription = "Emphasis" });
            fontStyles.Add(new FontStyleInfo() { FontText = "AaBbCcDd", FontDescription = "Intense Emphasis", FontStyle = FontStyle.Italic });
            fontStyles.Add(new FontStyleInfo() { FontText = "AaBbCcDd", FontDescription = "Strong", FontWeight = FontWeights.Bold });
            fontStyles.Add(new FontStyleInfo() { FontText = "AaBbCcDd", FontDescription = "Quote", FontStyle = FontStyle.Italic });
            fontStyles.Add(new FontStyleInfo() { FontText = "AaBbCcDd", FontDescription = "Intense Quote" });
            fontStyles.Add(new FontStyleInfo() { FontText = "AaBbCcDd", FontDescription = "Subtle Referrence" });
            fontStyles.Add(new FontStyleInfo() { FontText = "AaBbCcDd", FontDescription = "Intense Referrence" });
            fontStyles.Add(new FontStyleInfo() { FontText = "AaBbCcDd", FontDescription = "Book Title", FontStyle = FontStyle.Italic, FontWeight = FontWeights.Bold });
            fontStyles.Add(new FontStyleInfo() { FontText = "AaBbCcDd", FontDescription = "List Paragraph" });
            
            return fontStyles;
        }

        private bool CanExecuteCommand(object parameter)
        {
            return true;
        }

        private async void ExecuteCloseAsync(object parameter)
        {
            ContentDialog contentDialog1 = new ContentDialog();
            contentDialog1.XamlRoot = (parameter as SfRibbon).XamlRoot;
            contentDialog1.Title = "The application closing window is initialized.";
            contentDialog1.PrimaryButtonText = "Exit";
            await contentDialog1.ShowAsync();
        }

        private async void ExecuteSaveAsync(object parameter)
        {
            ContentDialog contentDialog1 = new ContentDialog();
            contentDialog1.XamlRoot = (parameter as SfRibbon).XamlRoot;
            contentDialog1.Title = "The file has been saved.";
            contentDialog1.PrimaryButtonText = "Close";
            await contentDialog1.ShowAsync();
        }

        private async void ExecuteOption(object parameter)
        {
            ContentDialog contentDialog1 = new ContentDialog();
            contentDialog1.XamlRoot = (parameter as SfRibbon).XamlRoot;
            contentDialog1.Title = "The options window is intialized.";
            contentDialog1.PrimaryButtonText = "Close";
            await contentDialog1.ShowAsync();
        }

        private void ExecuteButtonCommand(object parameter)
        {
            this.Status = $" {parameter}";
        }
    }
}
