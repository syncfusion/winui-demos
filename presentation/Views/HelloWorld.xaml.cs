#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.IO;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.Presentation;
using System.Reflection;
using Syncfusion.PresentationRenderer;
using Syncfusion.Pdf;

namespace EssentialPresentation
{
    /// <summary>
    /// Integration logic for xaml.
    /// </summary>
    public sealed partial class HelloWorld : Page
    {
        #region Constructor
        /// <summary>
        /// Initializes component.
        /// </summary>
        public HelloWorld()
        {
            this.InitializeComponent();
        }
        #endregion

        #region Events
        /// <summary>
        /// Creates slides with simple text in a PowerPoint Presentation.
        /// </summary>
        private void BtnCreatePresn_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            string path = "Syncfusion.PresentationDemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.Presentation.";
#endif

            //Gets the input PowerPoint Presentation file.
            Assembly assembly = typeof(HelloWorld).GetTypeInfo().Assembly;
            string resourcePath = path + "Assets.Presentation.HelloWorld.pptx";
            using Stream fileStream = assembly.GetManifestResourceStream(resourcePath);
            //Opens an existing PowerPoint Presentation file.
            using IPresentation presentation = Syncfusion.Presentation.Presentation.Open(fileStream);
            //Creates slides in PowerPoint Presentation file.
            CreateDefaultSlide(presentation);

            //Saves the presentation to the memory stream.
            using MemoryStream stream = new();
            if (presentationdoc.IsChecked == true)
            {
                presentation.Save(stream);
                stream.Position = 0;
                //Saves the memory stream as file.
                SaveAndLaunch.Save("HelloWorld.pptx", stream);
            }
            else
            {
                //Converts the PowerPoint Presentation to PDF document.
                using (PdfDocument pdfDocument = PresentationToPdfConverter.Convert(presentation))
                {
                    //Saves the converted PDF document to MemoryStream.
                    pdfDocument.Save(stream);
                    stream.Position = 0;
                }
                //Saves the memory stream as file.
                SaveAndLaunch.Save("HelloWorld.pdf", stream);
            }
        }
        #endregion

        #region Helper methods
        /// <summary>
        /// Creates slides in PowerPoint Presentation file.
        /// </summary>
        private static void CreateDefaultSlide(IPresentation presentation)
        {
            //Retrieves the first slide of the presentation.
            ISlide slide1 = presentation.Slides[0];
            //Retrieves the first shape of the slide.
            IShape titleShape = slide1.Shapes[0] as IShape;
            //Sets the size and position of the shape.
            titleShape.Left = 0.33 * 72;
            titleShape.Top = 0.58 * 72;
            titleShape.Width = 12.5 * 72;
            titleShape.Height = 1.75 * 72;

            //Retrieves the text body of the shape.
            ITextBody textFrame1 = (slide1.Shapes[0] as IShape).TextBody;
            IParagraphs paragraphs1 = textFrame1.Paragraphs;
            //Adds a new paragraph.
            IParagraph paragraph = paragraphs1.Add();
            //Sets the horizontal alignment type for the paragraph.
            paragraph.HorizontalAlignment = HorizontalAlignmentType.Center;
            //Adds a text part.
            ITextPart textPart1 = paragraph.AddTextPart();
            //Adds text to the text part.
            textPart1.Text = "Essential Presentation";
            //Sets the font properties for the text part.
            textPart1.Font.CapsType = TextCapsType.All;
            textPart1.Font.FontName = "Adobe Garamond Pro";
            textPart1.Font.Bold = true;
            textPart1.Font.FontSize = 40;

            //Retrieves the second shape of the slide.
            IShape subtitle = slide1.Shapes[1] as IShape;
            //Sets the size and position of the shape.
            subtitle.Left = 1.33 * 72;
            subtitle.Top = 2.67 * 72;
            subtitle.Width = 10 * 72;
            subtitle.Height = 1.7 * 72;

            //Retrieves the text body of the shape.
            ITextBody textFrame2 = (slide1.Shapes[1] as IShape).TextBody;
            textFrame2.VerticalAlignment = VerticalAlignmentType.Top;
            IParagraphs paragraphs2 = textFrame2.Paragraphs;
            //Adds a new paragraph.
            IParagraph para = paragraphs2.Add();
            //Sets the horizontal alignment type for the paragraph.
            para.HorizontalAlignment = HorizontalAlignmentType.Left;
            //Adds a text part.
            ITextPart textPart2 = para.AddTextPart();
            //Adds text to the text part.
            textPart2.Text = "Adventure Works Cycles, the fictitious company on which the Adventure Works sample databases are based, is a large, multinational manufacturing company. The company manufactures and sells metal and composite bicycles to North American, European and Asian commercial markets.";
            textPart2.Font.FontName = "Adobe Garamond Pro";
            textPart2.Font.FontSize = 21;

            //Adds a new paragraph.
            para = paragraphs2.Add();
            //Sets the horizontal alignment type for the paragraph.
            para.HorizontalAlignment = HorizontalAlignmentType.Left;
            //Adds a text part.
            textPart2 = para.AddTextPart();
            //Adds text to the text part.
            textPart2.Text = "In 2000, Adventure Works Cycles bought a small manufacturing plant, Importadores Neptuno, located in Mexico. Importadores Neptuno manufactures several critical subcomponents for the Adventure Works Cycles product line. These subcomponents are shipped to the Bothell location for final product assembly.";
            //Sets the font properties.
            textPart2.Font.FontName = "Adobe Garamond Pro";
            textPart2.Font.FontSize = 21;
        }
        #endregion
    }
}
