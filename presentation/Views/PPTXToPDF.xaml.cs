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
using Syncfusion.PresentationToPdfConverter;
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
            //Gets the input PowerPoint Presentation file.
            Assembly assembly = typeof(PPTXToPDF).GetTypeInfo().Assembly;
            string resourcePath = "syncfusion.presentationdemos.winui.Assets.Presentation.Template.pptx";
            using Stream fileStream = assembly.GetManifestResourceStream(resourcePath);
            //Opens an existing PowerPoint Presentation file.
            using IPresentation presentation = Syncfusion.Presentation.Presentation.Open(fileStream);
            //Creates the MemoryStream to save the converted PDF.
            using MemoryStream pdfStream = new();
            //Converts the PowerPoint Presentation to PDF document.
            using (PdfDocument pdfDocument = PresentationToPdfConverter.Convert(presentation))
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
            //Gets the input PowerPoint Presentation file.
            Assembly assembly = typeof(PPTXToPDF).GetTypeInfo().Assembly;
            string resourcePath = "syncfusion.presentationdemos.winui.Assets.Presentation.Template.pptx";
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
