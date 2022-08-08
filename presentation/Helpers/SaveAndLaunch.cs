#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using EssentialPresentation;
using System.Runtime.CompilerServices;
using Windows.UI.Popups;

namespace EssentialPresentation
{
    /// <summary>
    /// Helper class to save and launch the file.
    /// </summary>
    class SaveAndLaunch
    {
        /// <summary>
        /// Saves and launch the file.
        /// </summary>
        /// <param name="filename">File name.</param>
        /// <param name="stream">Stream to save.</param>
        public static async void Save(string filename, MemoryStream stream)
        {
            StorageFile storageFile;
            string extension = Path.GetExtension(filename);
            //Gets process windows handle to open the dialog in application process.
            IntPtr windowHandle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            if (!Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                FileSavePicker savePicker = new();
                if (extension == ".pdf")
                {
                    savePicker.DefaultFileExtension = ".pdf";
                    savePicker.SuggestedFileName = filename;
                    //Saves the file as PDF file.
                    savePicker.FileTypeChoices.Add("PDF", new List<string>() { ".pdf" });
                }
                else if (extension== ".pptx")
                {
                    savePicker.DefaultFileExtension = ".pptx";
                    savePicker.SuggestedFileName = filename;
                    //Saves the file as PPTX file.
                    savePicker.FileTypeChoices.Add("Presentation", new List<string>() { ".pptx" });
                }
                else
                {
                    savePicker.DefaultFileExtension = ".jpg";
                    savePicker.SuggestedFileName = filename;
                    //Saves the file as JPG file.
                    savePicker.FileTypeChoices.Add("Image", new List<string>() { ".jpg" });
                }

                WinRT.Interop.InitializeWithWindow.Initialize(savePicker, windowHandle);
                storageFile = await savePicker.PickSaveFileAsync();
            }
            else
            {
                StorageFolder local = ApplicationData.Current.LocalFolder;
                storageFile = await local.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            }
            if (storageFile != null)
            {
                using (IRandomAccessStream zipStream = await storageFile.OpenAsync(FileAccessMode.ReadWrite))
                {
                    //Writes compressed data from memory to file.
                    using Stream outstream = zipStream.AsStreamForWrite();
					outstream.SetLength(0);
                    byte[] buffer = stream.ToArray();
                    outstream.Write(buffer, 0, buffer.Length);
                    outstream.Flush();
                }

                //Creates message dialog box. 
                MessageDialog msgDialog = new("Do you want to view the Document?", "File has been created successfully");
                UICommand yesCmd = new("Yes");
                msgDialog.Commands.Add(yesCmd);
                UICommand noCmd = new("No");
                msgDialog.Commands.Add(noCmd);

                WinRT.Interop.InitializeWithWindow.Initialize(msgDialog, windowHandle);

                //Showing a dialog box. 
                IUICommand cmd = await msgDialog.ShowAsync();
                if (cmd.Label == yesCmd.Label)
                {
                    //Launch the saved file. 
                    await Windows.System.Launcher.LaunchFileAsync(storageFile);
                }
            }
        }
    }
}
