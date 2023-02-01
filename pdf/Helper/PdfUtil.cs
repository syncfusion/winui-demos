#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.IO;
using System.Collections.Generic;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Popups;

namespace Syncfusion.PdfDemos.WinUI
{
    class PdfUtil
    {
        /// <summary>
        /// Save the stream into a PDF file with provided file name. 
        /// </summary>
        public async static void Save(string filename, MemoryStream stream)
        {
            StorageFile stFile;

            //Get process windows handle to open the dialog in application process. 
            IntPtr windowHandle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            if (!Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                //Create file save picker to save a PDF file. 
                FileSavePicker savePicker = new FileSavePicker();
                savePicker.DefaultFileExtension = ".pdf";
                savePicker.SuggestedFileName = filename;
                savePicker.FileTypeChoices.Add("PDF document files", new List<string>() { ".pdf" });
                WinRT.Interop.InitializeWithWindow.Initialize(savePicker, windowHandle);
                stFile = await savePicker.PickSaveFileAsync();
            }
            else
            {
                StorageFolder local = ApplicationData.Current.LocalFolder;
                stFile = await local.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            }

            if (stFile != null)
            {
                using (IRandomAccessStream zipStream = await stFile.OpenAsync(FileAccessMode.ReadWrite))
                {
                    //Write compressed data from memory to file
                    using (Stream outstream = zipStream.AsStreamForWrite())
                    {
                        outstream.SetLength(0);
                        //Save the stream as PDF file.
                        byte[] buffer = stream.ToArray();
                        outstream.Write(buffer, 0, buffer.Length);
                        outstream.Flush();
                    }
                }

                //Create message dialog box. 
                MessageDialog msgDialog = new MessageDialog("Do you want to view the document?", "File created");
                UICommand yesCmd = new UICommand("Yes");
                msgDialog.Commands.Add(yesCmd);
                UICommand noCmd = new UICommand("No");
                msgDialog.Commands.Add(noCmd);

                WinRT.Interop.InitializeWithWindow.Initialize(msgDialog, windowHandle);

                //Showing a dialog box. 
                IUICommand cmd = await msgDialog.ShowAsync();
                if (cmd.Label == yesCmd.Label)
                {
                    // Launch the saved PDF file. 
                    await Windows.System.Launcher.LaunchFileAsync(stFile);
                }
            }
        }

        /// <summary>
        /// Show the dialog box with provided content and title. 
        /// </summary>
        public async static void ShowDialog(string content, string title)
        {
            //Get process windows handle to open the dialog in application process. 
            IntPtr windowHandle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            //Create message dialog box. 
            MessageDialog msgDialog = new MessageDialog(content, title);
            UICommand yesCmd = new UICommand("Close");
            msgDialog.Commands.Add(yesCmd);

            WinRT.Interop.InitializeWithWindow.Initialize(msgDialog, windowHandle);
            //Showing a dialog box. 
            await msgDialog.ShowAsync();
        }
       
    }
}
