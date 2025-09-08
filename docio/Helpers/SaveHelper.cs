#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Popups;

namespace Syncfusion.DocIODemos.WinUI.Helpers
{
    /// <summary>
    /// Helper class to save the file.
    /// </summary>
    class SaveHelper
    {
        /// <summary>
        /// Saves and launch the file.
        /// </summary>
        /// <param name="filename">File name.</param>
        /// <param name="stream">Stream to save.</param>
        public static async void SaveAndLaunch(string filename, MemoryStream stream)
        {
            StorageFile storageFile;
            string extension = Path.GetExtension(filename);
            //Gets process windows handle to open the dialog in application process.
            IntPtr windowHandle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            if (!Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                FileSavePicker savePicker = new();
                if (extension == ".docx")
                {
                    savePicker.DefaultFileExtension = ".docx";
                    savePicker.SuggestedFileName = filename;
                    //Saves the file as Docx file.
                    savePicker.FileTypeChoices.Add("DOCX", new List<string>() { ".docx" });
                }
                else if (extension == ".doc")
                {
                    savePicker.DefaultFileExtension = ".doc";
                    savePicker.SuggestedFileName = filename;
                    //Saves the file as Doc file.
                    savePicker.FileTypeChoices.Add("DOC", new List<string>() { ".doc" });
                }
                else if (extension == ".md")
                {
                    savePicker.DefaultFileExtension = ".md";
                    savePicker.SuggestedFileName = filename;
                    //Saves the file as markdown file.
                    savePicker.FileTypeChoices.Add("Markdown", new List<string>() { ".md" });
                }
                else if (extension == ".rtf")
                {
                    savePicker.DefaultFileExtension = ".rtf";
                    savePicker.SuggestedFileName = filename;
                    //Saves the file as Xml file.
                    savePicker.FileTypeChoices.Add("RTF", new List<string>() { ".rtf" });
                }
                else if (extension == ".pdf")
                {
                    savePicker.DefaultFileExtension = ".pdf";
                    savePicker.SuggestedFileName = filename;
                    //Saves the file as Pdf file.
                    savePicker.FileTypeChoices.Add("PDF", new List<string>() { ".pdf" });
                }
                else if (extension == ".html")
                {
                    savePicker.DefaultFileExtension = ".html";
                    savePicker.SuggestedFileName = filename;
                    //Saves the file as Pdf file.
                    savePicker.FileTypeChoices.Add("HTML", new List<string>() { ".html" });
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
                try
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
                        if(extension == ".md")
                        {
                           Windows.System.LauncherOptions options = new Windows.System.LauncherOptions();
                           options.DisplayApplicationPicker = true;
                           // Launch the file with "Open with" option.
                           await Windows.System.Launcher.LaunchFileAsync(storageFile, options);
                        }
                        else
                        //Launch the saved file. 
                        await Windows.System.Launcher.LaunchFileAsync(storageFile);
                    }
                }
                catch (Exception ex)
                {
                    if(ex.Message.Contains("Access is denied."))
                    {
                        //Creates message dialog box.
                        MessageDialog msgDialogBox = new("Access to the given path is denied. Please enable permission to save the file in that folder or save the file in another location." , "Access Denied");
                        UICommand okCmd = new("Ok");
                        msgDialogBox.Commands.Add(okCmd);
                        WinRT.Interop.InitializeWithWindow.Initialize(msgDialogBox, windowHandle);
                        //Showing a dialog box. 
                        IUICommand msgCmd = await msgDialogBox.ShowAsync();
                    }    
                }
            }
        }
    }
}
