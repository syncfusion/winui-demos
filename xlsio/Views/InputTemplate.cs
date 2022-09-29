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
using Windows.UI.Popups;

namespace Syncfusion.XlsIODemos.WinUI.Views
{
    internal class InputTemplate
    {
        public async void GetInputTeamplate(Stream input, string filename, string extension)
        {
            MemoryStream stream = new MemoryStream();
            input.CopyTo(stream);
            stream.Position = 0;

            StorageFile stFile;
            FileSavePicker savePicker = new FileSavePicker();
            savePicker.DefaultFileExtension = extension;
            savePicker.SuggestedFileName = filename;
            savePicker.FileTypeChoices.Add("Excel Documents", new List<string>() { extension });

            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
            stFile = await local.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            try
            {
                if (stFile != null)
                {
                    using (IRandomAccessStream zipStream = await stFile.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        //Write compressed data from memory to file
                        using (Stream outstream = zipStream.AsStreamForWrite())
                        {
                            outstream.SetLength(0);
                            byte[] buffer = stream.ToArray();
                            outstream.Write(buffer, 0, buffer.Length);
                            outstream.Flush();
                        }
                    }
                    //Launch the saved Excel file
                    await Windows.System.Launcher.LaunchFileAsync(stFile);
                }

            }
            catch (Exception ex)
            {
                //Gets process windows handle to open the dialog in application process.
                IntPtr windowHandle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;

                if (ex.Message.Contains("Access is denied."))
                {
                    //Creates message dialog box.
                    MessageDialog msgDialogBox = new("The file cannot be saved in this location due to access being denied." +
                        " Kindly provide permission to save the file in this location or save the file in another location.", "File Access Denied");
                    UICommand okCmd = new("Ok");
                    msgDialogBox.Commands.Add(okCmd);
                    WinRT.Interop.InitializeWithWindow.Initialize(msgDialogBox, windowHandle);
                    //Showing a dialog box. 
                    IUICommand msgCmd = await msgDialogBox.ShowAsync();
                }
            }
            input.Dispose();
            stream.Dispose();
        }
    }
}
