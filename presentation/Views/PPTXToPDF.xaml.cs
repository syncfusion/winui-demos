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
using Syncfusion.Pdf;
using Syncfusion.PresentationRenderer;
using Syncfusion.Presentation;

namespace EssentialPresentation
{
    /// <summary>
    /// Integration logic for xaml.
    /// </summary>
    public sealed partial class PPTXToPDF : Page
    {
        #region Constructor
        /// <summary>
        /// Initializes component.
        /// </summary>
        public PPTXToPDF()
        {
            this.InitializeComponent();
        }
        #endregion

        #region Events        
        /// <summary>
        /// Converts a PowerPoint Presentation to PDF.
        /// </summary>
        private void Convert_BtnClick(System.Object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            string path = "Syncfusion.PresentationDemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.Presentation.";
#endif

            //Gets the input PowerPoint Presentation file.
            Assembly assembly = typeof(PPTXToPDF).GetTypeInfo().Assembly;
            string resourcePath = path + "Assets.Presentation.Template.pptx";
            using Stream fileStream = assembly.GetManifestResourceStream(resourcePath);
            //Opens an existing PowerPoint Presentation file.
            using IPresentation presentation = Syncfusion.Presentation.Presentation.Open(fileStream);
            //Creates the MemoryStream to save the converted PDF.
            using MemoryStream pdfStream = new();
            PresentationToPdfConverterSettings settings = new PresentationToPdfConverterSettings();
            //Enables a flag to preserve document structured tags in the converted tagged PDF.
            if (checkBox1.IsChecked == true)
                settings.AutoTag = true;
            //Converts the PowerPoint Presentation to PDF document.
            using (PdfDocument pdfDocument = PresentationToPdfConverter.Convert(presentation,settings))
            {
                //Saves the converted PDF document to MemoryStream.
                pdfDocument.Save(pdfStream);
                pdfStream.Position = 0;
            }
            //Saves the memory stream as file.
            SaveAndLaunch.Save("PPTXToPDF.pdf", pdfStream);
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
            Assembly assembly = typeof(PPTXToPDF).GetTypeInfo().Assembly;
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
