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

namespace DocIO
{
    /// <summary>
    /// Integration logic for xaml.
    /// </summary>
    public sealed partial class EncryptAndDecrypt : Page
    {
        #region Constructor
        /// <summary>
        /// Initializes component.
        /// </summary>
        public EncryptAndDecrypt()
        {
            this.InitializeComponent();
        }
        #endregion

        #region Events
        /// <summary>
        /// Encrypts and decrypts the Word document.
        /// </summary>
        private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            string path;
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.DocIO.";
#else
            path = "Syncfusion.DocIODemos.WinUI.";
#endif
            string filename;
            WordDocument document;
            Assembly assembly = typeof(EncryptAndDecrypt).GetTypeInfo().Assembly;
            string dataFileName = rdEncrypt.IsChecked.Value ? "Adventure.docx" : "Decrypt.docx";
            //Gets the input Word document.
            using Stream fileStream = assembly.GetManifestResourceStream(path+"Assets.DocIO." + dataFileName);
            if (rdEncrypt.IsChecked.Value)
            {
                //Loads an existing Word document.
                document = new WordDocument(fileStream, FormatType.Docx);
                //Encrypts the document by giving password.
                document.EncryptDocument("syncfusion");
                filename = "Encrypt.docx";
            }
            else
            {
                //Loads an existing Word document which is protected with password.
                document = new WordDocument(fileStream, FormatType.Docx, "syncfusion");
                filename = "Decrypt.docx";
            }
            using MemoryStream ms = new();
            //Saves the Word document to the memory stream.
            document.Save(ms, FormatType.Docx);
            document.Close();
            ms.Position = 0;
            //Saves the memory stream as file.
            SaveHelper.SaveAndLaunch(filename, ms);
        }
        #endregion
    }
}