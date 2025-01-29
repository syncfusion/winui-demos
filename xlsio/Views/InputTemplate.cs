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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;

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
            if (stFile != null)
            {
                using (IRandomAccessStream zipStream = await stFile.OpenAsync(FileAccessMode.ReadWrite))
                {
                    //Write compressed data from memory to file
                    using (Stream outstream = zipStream.AsStreamForWrite())
                    {
                        byte[] buffer = stream.ToArray();
                        outstream.Write(buffer, 0, buffer.Length);
                        outstream.Flush();
                    }
                }
                //Launch the saved Excel file
                await Windows.System.Launcher.LaunchFileAsync(stFile);
            }
            input.Dispose();
            stream.Dispose();
        }
    }
}
