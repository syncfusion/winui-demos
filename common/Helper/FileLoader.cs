using System;
using System.Reflection;
using System.Threading.Tasks;
using Windows.Storage;

namespace Syncfusion.DemosCommon.WinUI
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
#if !Main_SB
            source = $"{source.Split('/', 2)[1]}";
#endif

            string path = $"ms-appx:///{source}";
            return path;
        }
    }
}
