#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;
using System.Collections.Generic;

namespace DocIO
{
    /// <summary>
    /// Integration logic for xaml.
    /// </summary>
    public sealed partial class DocumentProtection : Page
    {
        #region Fields
        readonly Assembly assembly = typeof(DocumentProtection).GetTypeInfo().Assembly;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes component.
        /// </summary>
        public DocumentProtection()
        {
            this.InitializeComponent();
        }
        #endregion

        #region Events
        /// <summary>
        /// Creates a Word document.
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
            string resourcePath = path + "Assets.DocIO.TemplateReading.docx";
            using Stream fileStream = assembly.GetManifestResourceStream(resourcePath);
            //Creates a new Word document instance.
            using WordDocument document = new();
            //Opens an existing word document.
            document.Open(fileStream, FormatType.Docx);
			
			// Access the paragraph
            WParagraph paragraph = document.Sections[0].Body.ChildEntities[5] as WParagraph;
            // Create a new editable range start
            EditableRangeStart editableRangeStart = new EditableRangeStart(document);
            // Insert the editable range start at the beginning of the selected paragraph
            paragraph.ChildEntities.Insert(0, editableRangeStart);
            // Set the editor group for the editable range to allow everyone to edit
            editableRangeStart.EditorGroup = EditorType.Everyone;
            // Append an editable range end to close the editable region
            paragraph.AppendEditableRangeEnd();
            
            // Access the first table in the first section of the document
            WTable table = document.Sections[0].Tables[0] as WTable;
            // Access the paragraph in the third row and third column of the table
            paragraph = table[2, 2].ChildEntities[0] as WParagraph;
            // Create a new editable range start for the table cell paragraph
            editableRangeStart = new EditableRangeStart(document);
            // Insert the editable range start at the beginning of the paragraph
            paragraph.ChildEntities.Insert(0, editableRangeStart);
            // Set the editor group for the editable range to allow everyone to edit
            editableRangeStart.EditorGroup = EditorType.Everyone;
            // Apply editable range to second column only
            editableRangeStart.FirstColumn = 1;
            editableRangeStart.LastColumn = 1;
            // Access the paragraph
            paragraph = table[5, 2].ChildEntities[0] as WParagraph;
            // Append an editable range end to close the editable region
            paragraph.AppendEditableRangeEnd();
			
            //Sets the protection with password and it allows only to modify the form fields type
            document.Protect(ProtectionType.AllowOnlyReading, "syncfusion");

            #region Document SaveOption
            using MemoryStream ms = new();
            //Saves the Word document to the memory stream.
            document.Save(ms, FormatType.Docx);
            ms.Position = 0;
            //Saves the memory stream as file.
            SaveHelper.SaveAndLaunch("DocumentProtection.docx", ms);
            #endregion Document SaveOption
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
            string resourcePath = path + "Assets.DocIO.TemplateReading.docx";
            using Stream fileStream = assembly.GetManifestResourceStream(resourcePath);
            using MemoryStream ms = new();
            fileStream.CopyTo(ms);
            ms.Position = 0;
            //Saves the memory stream as file.
            SaveHelper.SaveAndLaunch("TemplateReading.docx", ms);
        }
        #endregion
    }
}
