#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.IO;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.Presentation;
using System.Reflection;

namespace EssentialPresentation
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
        /// Encrypts and decrypts the presentation.
        /// </summary>
        private void BtnCreatePresn_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            string path = "Syncfusion.PresentationDemos.WinUI.";
#if Main_SB
            path = "Syncfusion.SampleBrowser.WinUI.Presentation.";
#endif

            string fileName;
            //Gets the input PowerPoint Presentation file.
            Assembly assembly = typeof(EncryptAndDecrypt).GetTypeInfo().Assembly;
            string resourcePath = path + "Assets.Presentation.SyncfusionPresentation.pptx";
            using Stream fileStream = assembly.GetManifestResourceStream(resourcePath);
            //Opens an existing PowerPoint Presentation file.
            using IPresentation presentation = Syncfusion.Presentation.Presentation.Open(fileStream);
            using MemoryStream ms = new();
            if (rdEncrypt.IsChecked == true)
            {
                //Encrypts the PowerPoint Presentation file.
                presentation.Encrypt("syncfusion");
                fileName = "Encrypt.pptx";
            }
            else
            {
                //Decrypts the PowerPoint Presentation file.
                presentation.RemoveEncryption();
                fileName = "Decrypt.pptx";
            }
            //Saves the presentation to the memory stream.
            presentation.Save(ms);
            ms.Position = 0;
            //Saves the memory stream as file.
            SaveAndLaunch.Save(fileName, ms);
        }
        #endregion
    }
}
