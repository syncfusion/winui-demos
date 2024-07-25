#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
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
    public sealed partial class CompareDocuments : Page
    {
        #region Fields
        readonly Assembly assembly = typeof(CompareDocuments).GetTypeInfo().Assembly;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes component.
        /// </summary>
        public CompareDocuments()
        {
            this.InitializeComponent();
        }
        #endregion

        #region Events
        /// <summary>
        /// Compare Word documents.
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
            string resourcePath1 = path + "Assets.DocIO.OriginalDocument.docx";
            string resourcePath2 = path + "Assets.DocIO.RevisedDocument.docx";
            //Loads the original document.
            using (Stream originalDocumentStreamPath = assembly.GetManifestResourceStream(resourcePath1))
            {
                using (WordDocument originalDocument = new WordDocument(originalDocumentStreamPath, FormatType.Docx))
                {
                    //Loads the revised document.
                    using (Stream revisedDocumentStreamPath = assembly.GetManifestResourceStream(resourcePath2))
                    {
                        using (WordDocument revisedDocument = new WordDocument(revisedDocumentStreamPath, FormatType.Automatic))
                        {
                            if (checkBox.IsChecked.Value)
                            {
                                //Compares the original document with revised document
                                originalDocument.Compare(revisedDocument, "Nancy Davolio", DateTime.Now.AddDays(-1));
                            }
                            else
                            {
                                //Disable the flag to ignore the formatting changes while comparing the documents
                                ComparisonOptions comparisonOptions = new ComparisonOptions();
                                comparisonOptions.DetectFormatChanges = false;
                                originalDocument.Compare(revisedDocument, "Nancy Davolio", DateTime.Now.AddDays(-1), comparisonOptions);
                            }
                        }
                    }
                    using MemoryStream ms = new();
                    //Saves the document to the memory stream.
                    originalDocument.Save(ms, FormatType.Docx);
                    ms.Position = 0;
                    //Saves the memory stream as file.
                    SaveHelper.SaveAndLaunch("CompareDocuments.docx", ms);
                }
            }
        }
        #endregion
    }
}
