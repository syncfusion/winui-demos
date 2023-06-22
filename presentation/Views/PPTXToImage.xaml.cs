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
using Syncfusion.PresentationRenderer;
using Syncfusion.Presentation;

namespace EssentialPresentation
{
    /// <summary>
    /// Integration logic for xaml.
    /// </summary>
    public sealed partial class PPTXToImage : Page
    {
        #region Constructor
        /// <summary>
        /// Initializes component.
        /// </summary>
        public PPTXToImage()
        {
            this.InitializeComponent();
        }
        #endregion

        #region Events
        /// <summary>
        /// Converts the PowerPoint slide to an image.
        /// </summary>
        private void Convert_BtnClick(System.Object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            string path = "Syncfusion.PresentationDemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.Presentation.";
#endif

            //Gets the input PowerPoint Presentation file.
            Assembly assembly = typeof(PPTXToImage).GetTypeInfo().Assembly;
            string resourcePath = path + "Assets.Presentation.Template.pptx";
            using Stream fileStream = assembly.GetManifestResourceStream(resourcePath);
            //Opens an existing PowerPoint Presentation file.
            using IPresentation presentation = Syncfusion.Presentation.Presentation.Open(fileStream);
            //Initializes PresentationRenderer to perform image conversion.
            presentation.PresentationRenderer = new PresentationRenderer();
            //Converts PowerPoint slide to image stream.
            using MemoryStream stream = (MemoryStream)presentation.Slides[0].ConvertToImage(Syncfusion.Presentation.ExportImageFormat.Jpeg);
            stream.Position = 0;
            //Saves the memory stream as image.
            SaveAndLaunch.Save("Slide.jpg", stream);
        }

        /// <summary>
        /// Opens the input template PowerPoint Presentation file.
        /// </summary>
        private void Open_BtnClick(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            string path = "Syncfusion.PresentationDemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.Presentation.";
#endif

            //Gets the input PowerPoint Presentation file.
            Assembly assembly = typeof(PPTXToImage).GetTypeInfo().Assembly;
            string resourcePath = path + "Assets.Presentation.Template.pptx";
            using Stream fileStream = assembly.GetManifestResourceStream(resourcePath);
            using MemoryStream ms = new();
            fileStream.CopyTo(ms);
            ms.Position = 0;
            //Saves the memory stream as file.
            SaveAndLaunch.Save("Template.pptx", ms);
        }
        #endregion
    }
}
