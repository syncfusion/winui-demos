using System;
using System.IO;
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
            string fullPath = Path.Combine(
                    AppContext.BaseDirectory,
                    relativeFilePath.Replace("ms-appx:///", string.Empty).Replace('/', Path.DirectorySeparatorChar));
            return await File.ReadAllTextAsync(fullPath);
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
