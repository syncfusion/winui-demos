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

namespace EssentialPresentation
{
    /// <summary>
    /// Integration logic for xaml.
    /// </summary>
    public sealed partial class FindAndHighlight : Page
    {
        #region Fields
        readonly Assembly assembly = typeof(FindAndHighlight).GetTypeInfo().Assembly;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes component.
        /// </summary>
        public FindAndHighlight()
        {
            this.InitializeComponent();
        }
        #endregion

        #region Events
        /// <summary>
        /// Highlight a specific text in the PowerPoint Presentation using the Find and Highlight.
        /// </summary>
        private void Button_Click(System.Object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
			
            string path = "Syncfusion.PresentationDemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.Presentation.";
#endif
            string resourcePath = path + "Assets.Presentation.FindAndHighlightInput.pptx";
           
            using Stream fileStream = assembly.GetManifestResourceStream(resourcePath);
            //Opens an existing PowerPoint Presentation file.
            using IPresentation presentation = Syncfusion.Presentation.Presentation.Open(fileStream);
                //Highlight only the first occurrence of the text
                if (chkBoxHighlightFirst.IsChecked.Value)
                {
                    //Finds the first occurrence of a particular text
                    ITextSelection textSelection = presentation.Find(HighlightTextBox.Text, chkBoxMatchCase.IsChecked.Value, chkBoxWholeWord.IsChecked.Value);
                    if(textSelection != null)
                    {
                        //Gets the found text containing text parts
                        foreach (ITextPart textPart in textSelection.GetTextParts())
                        {
                           //Sets highlight color
                           textPart.Font.HighlightColor = ColorObject.Yellow;
                        }
                    }
                }
                else
                {
                    //Finds all the occurrences of a particular text
                    ITextSelection[] textSelections = presentation.FindAll(HighlightTextBox.Text, chkBoxMatchCase.IsChecked.Value, chkBoxWholeWord.IsChecked.Value);
                    if(textSelections != null)
                    {
                        foreach (ITextSelection textSelection in textSelections)
                        {
                            //Gets the found text containing text parts
                            foreach (ITextPart textPart in textSelection.GetTextParts())
                            {
                                //Sets highlight color
                                textPart.Font.HighlightColor = ColorObject.Yellow;
                            }
                        }
                    }
                }
				
                using MemoryStream ms = new();
				//Saves the presentation to the memory stream.
                presentation.Save(ms);
                ms.Position = 0;
            //Saves the memory stream as file.
            SaveAndLaunch.Save("FindandHighlight.pptx", ms); 
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
            string resourcePath = path + "Assets.Presentation.FindAndHighlightInput.pptx";
            using Stream fileStream = assembly.GetManifestResourceStream(resourcePath);
            using MemoryStream ms = new();
            fileStream.CopyTo(ms);
            ms.Position = 0;
			//Saves the memory stream as file.
            SaveAndLaunch.Save("Input Template.pptx", ms);
        }
        #endregion
    }
}
