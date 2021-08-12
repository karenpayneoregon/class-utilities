using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CopyProjectTemplates.Classes
{
    public partial class FileHelpers
    {
        public delegate void OnCopyFileReadLine(string fileName);
        public static event OnCopyFileReadLine CopyFileHandler;
        /// <summary>
        /// Location of Visual Studio project templates
        /// </summary>
        public static string TemplateFolder => $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\Documents\\Visual Studio 2019\\Templates\\ProjectTemplates1";
        /// <summary>
        /// Assert Visual Studio project templates folder exists
        /// </summary>
        public static bool TemplateFolderExists => Directory.Exists(TemplateFolder);
        /// <summary>
        /// Location of project templates to copy to <see cref="TemplateFolder"/>
        /// </summary>
        /// <returns></returns>
        public static List<string> LocalCompressedFiles() => Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates"), "*.zip").ToList();
        /// <summary>
        /// Perform copy of local project template files to <see cref="TemplateFolder"/>
        /// </summary>
        /// <returns></returns>
        public static (bool success, Exception exception) CopyLocalFilesToProjectTemplateFolder()
        {
            var remoteFile = "";
            try
            {
                foreach (var file in LocalCompressedFiles())
                {
                    remoteFile = $"{TemplateFolder}\\{Path.GetFileName(file)}";
                    File.Copy(file, remoteFile, true);
                    CopyFileHandler?.Invoke($"* {remoteFile}");
                }

                return (LocalCompressedFiles().Count == RemoteCompressedFiles().Count, null)!;
            }
            catch (Exception exception)
            {
                CopyFileHandler?.Invoke($"X {remoteFile}");
                return (false, exception);
            }
        }

        public static (bool success, Exception exception) RemoveTemplateFolderFiles()
        {
            try
            {
                Directory.GetFiles(TemplateFolder).ToList().ForEach(File.Delete);
                return (true, null);
            }
            catch (Exception exception)
            {
                return (false, exception);
            }
        }
    }

    public partial class FileHelpers
    {
        public static List<string> RemoteCompressedFiles() => Directory.GetFiles(TemplateFolder, "*.zip").ToList();
    }
}