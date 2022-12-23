#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.IO;
using Microsoft.UI.Xaml.Controls;
using System.Reflection;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using Syncfusion.DocIODemos.WinUI.Helpers;

namespace DocIO
{
    /// <summary>
    /// Integration logic for xaml.
    /// </summary>
    public sealed partial class WordToMarkdown : Page
    {
        #region Fields
        readonly Assembly assembly = typeof(WordToMarkdown).GetTypeInfo().Assembly;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes component.
        /// </summary>
        public WordToMarkdown()
        {
            this.InitializeComponent();
        }
        #endregion

        #region Events
        /// <summary>
        /// Converts Word document to Markdown.
        /// </summary>
        private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            string path;
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.DocIO.";
#else
            path = "Syncfusion.DocIODemos.WinUI.";
#endif
            //Gets the input Word document.
            string resourcePath = path+"Assets.DocIO.WordtoMD.docx";
            using Stream fileStream = assembly.GetManifestResourceStream(resourcePath);
            //Loads an existing Word document.
            using WordDocument document = new(fileStream, FormatType.Automatic);
           
            using MemoryStream ms = new();
            //Saves the Markdown document to the memory stream.
            document.Save(ms, FormatType.Markdown);
            ms.Position = 0;
            //Saves the memory stream as file.
            SaveHelper.SaveAndLaunch("WordtoMD.md", ms);
        }

        /// <summary>
        /// Opens the input template Word document.
        /// </summary>
        private void ButtonView_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            string path;
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.DocIO.";
#else
            path = "Syncfusion.DocIODemos.WinUI.";
#endif
            //Gets the input Word document.
            string resourcePath = path + "Assets.DocIO.WordtoMD.docx";
            using Stream fileStream = assembly.GetManifestResourceStream(resourcePath);
            using MemoryStream ms = new();
            fileStream.CopyTo(ms);
            ms.Position = 0;
            //Saves the memory stream as file.
            SaveHelper.SaveAndLaunch("WordtoMD.docx", ms);
        }
        #endregion
    }
}
