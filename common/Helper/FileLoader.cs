#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Reflection;
using System.Threading.Tasks;
using Windows.Storage;

namespace syncfusion.demoscommon.winui
{
    internal static class FileLoader
    {
        /// <summary>
        /// A method to load a string from file
        /// </summary>
        /// <param name="relativeFilePath">file path</param>
        /// <returns></returns>
        public static async Task<string> LoadText(string relativeFilePath)
        {
            Uri sourceUri = new Uri(relativeFilePath);
            var file = await StorageFile.GetFileFromApplicationUriAsync(sourceUri);
            return await FileIO.ReadTextAsync(file);
        }

        /// <summary>
        /// A method to get a file path based on the assembly.
        /// </summary>
        /// <param name="source">file path</param>
        /// <returns>formatted file path</returns>
        public static string GetFilePath(string source)
        {
            string assemblyName = Assembly.GetEntryAssembly().GetName().Name;
            if (assemblyName != "syncfusion.samplebrowser.winui")
            {
                source = $"{source.Split('/', 2)[1]}";
            }

            string path = $"ms-appx:///{source}";
            return path;
        }
    }
}
