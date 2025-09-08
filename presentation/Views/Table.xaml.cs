#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Data;
using System.IO;
using System.Reflection;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.Pdf;
using Syncfusion.Presentation;
using Syncfusion.PresentationRenderer;

namespace EssentialPresentation
{
    /// <summary>
    /// Integration logic for xaml.
    /// </summary>
    public sealed partial class Table : Page
    {
        #region Constructor
        /// <summary>
        /// Initializes component.
        /// </summary>
        public Table()
        {
            this.InitializeComponent();
        }
        #endregion

        #region Events
        /// <summary>
        /// Add table in a PowerPoint Presentation file.
        /// </summary>
        private void BtnCreatePresn_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            //Creates a new instance of the PowerPoint Presentation file.
            using IPresentation presentation = Syncfusion.Presentation.Presentation.Create();
            #region Slide1
            //Adds a slide to PowerPoint presentation.
            ISlide slide = presentation.Slides.Add(SlideLayoutType.TitleOnly);
            //Sets the table title in a slide.
            SetTableTitle(slide);
            //Gets table data from xml file.
            DataSet dataSet = new();
            Assembly assembly = typeof(Table).GetTypeInfo().Assembly;
            string path = "Syncfusion.PresentationDemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.Presentation.";
#endif

            string resourcePath = path + "Assets.Presentation.TableData.xml";
            using (Stream fileStream = assembly.GetManifestResourceStream(resourcePath))
            {
                dataSet.ReadXml(fileStream);
            }
            int columnCount = dataSet.Tables[0].Rows.Count + 1;
            int rowCount = dataSet.Tables.Count - 1;
            //Adds a new table in slide.
            ITable table = slide.Shapes.AddTable(rowCount, columnCount, 61.92, 95.76, 856.8, 378.72);
            //Sets the style for the table.
            table.BuiltInStyle = BuiltInTableStyle.MediumStyle2Accent6;

            //Sets category title
            SetCategoryTitle(table);
            //Iterates and sets the values to the table cells.
            for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
            {
                IRow row = table.Rows[rowIndex];
                if (rowIndex == 0)
                    AddHeaderRow(row, dataSet.Tables[0].Rows);
                else
                    AddCell(row, dataSet.Tables[rowIndex + 1]);
            }
            #endregion
            //Saves the presentation to the memory stream.
            using MemoryStream stream = new();
            if (presentationdoc.IsChecked == true)
            {
                presentation.Save(stream);
                stream.Position = 0;
                //Saves the memory stream as file.
                SaveAndLaunch.Save("Table.pptx", stream);
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
                SaveAndLaunch.Save("Table.pdf", stream);
            }
        }
        #endregion

        #region Helper methods    
        /// <summary>
        /// Sets the table title.
        /// </summary>
        private static void SetTableTitle(ISlide slide)
        {
            IShape shape = slide.Shapes[0] as IShape;
            shape.Left = 84.24;
            shape.Top = 0;
            shape.Width = 792;
            shape.Height = 126.72;
            ITextBody textFrame = shape.TextBody;
            IParagraphs paragraphs = textFrame.Paragraphs;
            paragraphs.Add();
            IParagraph paragraph = paragraphs[0];
            paragraph.HorizontalAlignment = HorizontalAlignmentType.Center;

            //Adds textparts in paragraph.
            ITextParts textParts = paragraph.TextParts;
            textParts.Add();
            ITextPart textPart = textParts[0];
            textPart.Text = "Target ";
            IFont font = textPart.Font;
            font.FontName = "Arial";
            font.FontSize = 28;
            font.Bold = true;
            font.CapsType = TextCapsType.All;
            textParts.Add();

            //Creates a textpart and assigns value to it.
            textPart = textParts[1];
            textPart.Text = "Vs ";
            font = textPart.Font;
            font.FontName = "Arial";
            font.FontSize = 18;
            textParts.Add();

            //Creates a textpart and assigns value to it.
            textPart = textParts[2];
            textPart.Text = "PERFORMANCE";
            font = textPart.Font;
            font.FontName = "Arial";
            font.FontSize = 28;
            font.Bold = true;
        }

        /// <summary>
        /// Adds the cell content to the table.
        /// </summary>
        private static void AddCell(IRow row, DataTable dataTable)
        {
            DataRowCollection dataRowCollection = dataTable.Rows;
            for (int cellIndex = 0; cellIndex < row.Cells.Count; cellIndex++)
            {
                ICell cell = row.Cells[cellIndex];
                //Instance to hold paragraphs in cell.
                IParagraphs paragraphs = cell.TextBody.Paragraphs;
                paragraphs.Add();
                IParagraph paragraph = paragraphs[0];
                paragraph.HorizontalAlignment = HorizontalAlignmentType.Left;
                ITextParts textParts = paragraph.TextParts;
                textParts.Add();

                //Creates a textpart and assigns value to it.
                ITextPart textPart = textParts[0];
                if (cellIndex == 0)
                    textPart.Text = dataTable.TableName;
                else
                    textPart.Text = dataRowCollection[cellIndex - 1].ItemArray[0].ToString();
                IFont font = textPart.Font;
                font.FontName = "Arial";
                font.FontSize = 14;
            }
        }

        /// <summary>
        /// Adds the content for the row and column of the table.
        /// </summary>
        private static void AddHeaderRow(IRow row, DataRowCollection dataRowCollections)
        {
            for (int cellIndex = 1; cellIndex < row.Cells.Count; cellIndex++)
            {
                ICell cell = row.Cells[cellIndex];
                cell.TextBody.VerticalAlignment = VerticalAlignmentType.Middle;
                //Adds a paragraph inside cell.
                IParagraphs paragraphs = cell.TextBody.Paragraphs;
                if (paragraphs.Count == 0)
                    paragraphs.Add();
                IParagraph paragraph = paragraphs[0];
                paragraph.HorizontalAlignment = HorizontalAlignmentType.Center;
                ITextParts textParts = paragraph.TextParts;
                if (textParts.Count == 0)
                    textParts.Add();

                //Creates a textpart and assigns value to it.
                ITextPart textPart = textParts[0];
                textPart.Text = dataRowCollections[cellIndex - 1].ItemArray[0].ToString();
                IFont font = textPart.Font;
                font.FontName = "Arial";
                font.FontSize = 14;
                font.Bold = true;
            }
        }

        /// <summary>
        /// Sets the title for the category in the table.
        /// </summary>
        static void SetCategoryTitle(ITable table)
        {
            //Instance to hold rows in the table.
            table.Rows[0].Height = 81.44;
            //Sets text alignment type inside cell.
            table.Rows[0].Cells[0].TextBody.VerticalAlignment = VerticalAlignmentType.Middle;

            //Adds a paragraph inside cell.
            IParagraphs paragraphs = table.Rows[0].Cells[0].TextBody.Paragraphs;
            paragraphs.Add();
            IParagraph paragraph = paragraphs[0];
            paragraph.HorizontalAlignment = HorizontalAlignmentType.Center;
            ITextParts textParts = paragraph.TextParts;
            textParts.Add();

            //Creates a textpart and assigns value to it.
            ITextPart textPart = textParts[0];
            textPart.Text = "Month";
            IFont font = textPart.Font;
            font.FontName = "Arial";
            font.FontSize = 14;
            font.Bold = true;
        }
        #endregion
    }
}
