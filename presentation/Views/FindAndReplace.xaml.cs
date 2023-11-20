#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.IO;
using Microsoft.UI.Xaml.Controls;
using System.Reflection;
using Syncfusion.Presentation;
using System.Text.RegularExpressions;

namespace EssentialPresentation
{
    /// <summary>
    /// Integration logic for xaml.
    /// </summary>
    public sealed partial class FindAndReplace : Page
    {
        #region Fields
        readonly Assembly assembly = typeof(FindAndReplace).GetTypeInfo().Assembly;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes component.
        /// </summary>
        public FindAndReplace()
        {
            this.InitializeComponent();
            this.FindTextBox.Text = "{product}";
            this.FindRegexTextBox.Text = "{[A-Za-z]+}";
            this.ReplaceTextBox.Text = "Service";
        }
        #endregion

        #region Events
        /// <summary>
        /// Replaces a specific text in the PowerPoint Presentation with another text using the Find and Replace.
        /// </summary>
        private void Button_Click(System.Object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
			
            string path = "Syncfusion.PresentationDemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.Presentation.";
#endif
            string resourcePath = path + "Assets.Presentation.Input Template.pptx";
           
            using Stream fileStream = assembly.GetManifestResourceStream(resourcePath);
            //Opens an existing PowerPoint Presentation file.
            using IPresentation presentation = Syncfusion.Presentation.Presentation.Open(fileStream);
                //Replaces only the first occurrence of the text
                if (chkBoxReplaceFirst.IsChecked.Value)
                {
                    ITextSelection textSelection = null;
                    if (comboBoxFindUsing.SelectedIndex == 0)
                    {
                        //Finds the first occurrence of a particular text
                        textSelection = presentation.Find(FindTextBox.Text, chkBoxMatchCase.IsChecked.Value, chkBoxWholeWord.IsChecked.Value);
                    }
                    else
                    {
                        //Finds the first occurrence of a particular pattern
                        textSelection = presentation.Find(new Regex(FindRegexTextBox.Text));
                    }
                    if(textSelection != null)
                    {
                        //Gets the found text as single text part
                        ITextPart textPart = textSelection.GetAsOneTextPart();
                        //Replace the text
                        textPart.Text = ReplaceTextBox.Text;
                    }
                }
                else
                {
                    ITextSelection[] textSelections = null;
                    if (comboBoxFindUsing.SelectedIndex == 0)
                    {
                        //Finds all the occurrences of a particular text
                        textSelections = presentation.FindAll(FindTextBox.Text, chkBoxMatchCase.IsChecked.Value, chkBoxWholeWord.IsChecked.Value);
                    }
                    else
                    {
                        //Finds all the occurrences of a particular pattern
                        textSelections = presentation.FindAll(new Regex(FindRegexTextBox.Text));
                    }
                    if (textSelections != null)
                    {
                        foreach (ITextSelection textSelection in textSelections)
                        {
                            //Gets the found text as single text part
                            ITextPart textPart = textSelection.GetAsOneTextPart();
                            //Replace the text
                            textPart.Text = ReplaceTextBox.Text;
                        }
                    }
                }
				
                using MemoryStream ms = new();
				//Saves the presentation to the memory stream.
                presentation.Save(ms);
                ms.Position = 0;
            //Saves the memory stream as file.
            SaveAndLaunch.Save("FindandReplace.pptx", ms); 
        }
        /// <summary>
        /// Opens the input template PowerPoint Presentation file.
        /// </summary>
        private void ButtonView_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            string path = "Syncfusion.PresentationDemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.Presentation.";
#endif
            //Gets the input PowerPoint document.
            string resourcePath = path + "Assets.Presentation.Input Template.pptx";
            using Stream fileStream = assembly.GetManifestResourceStream(resourcePath);
            using MemoryStream ms = new();
            fileStream.CopyTo(ms);
            ms.Position = 0;
			//Saves the memory stream as file.
            SaveAndLaunch.Save("Input Template.pptx", ms);
        }
        /// <summary>
        /// Modifies the required changes if combo box value changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxSelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            //If none author selected disable the radio button, otherwise enabled
            if (comboBoxFindUsing.SelectedIndex != 0)
            {
                if (chkBoxMatchCase != null || chkBoxReplaceFirst != null || chkBoxWholeWord != null)
                {
                    chkBoxMatchCase.IsChecked = false;
                    chkBoxReplaceFirst.IsChecked = false;
                    chkBoxWholeWord.IsChecked = false;
                    chkBoxMatchCase.IsEnabled = false;
                    chkBoxWholeWord.IsEnabled = false;
                    chkBoxReplaceFirst.IsChecked = false;
                }
                if (FindRegexTextBox != null && stackPnlOptions2 != null)
                {
                    stackPnlOptions1.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
                    stackPnlOptions2.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
                }
            }
            else
            {
                if (chkBoxMatchCase != null || chkBoxReplaceFirst != null || chkBoxWholeWord != null)
                {
                    chkBoxMatchCase.IsChecked = false;
                    chkBoxReplaceFirst.IsChecked = false;
                    chkBoxWholeWord.IsChecked = false;
                    chkBoxMatchCase.IsEnabled = true;
                    chkBoxWholeWord.IsEnabled = true;
                }
                if (FindTextBox != null && stackPnlOptions1 != null)
                {
                    stackPnlOptions1.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
                    stackPnlOptions2.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
                }
            }
        }
        #endregion
    }
}
