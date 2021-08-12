using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static CopyProjectTemplates.Classes.SystemJson;

namespace CopyProjectTemplates.Classes
{
    public class FileHelpers
    {
        #region Event for listeners to get immediate results

        public delegate void OnCopyFileReadLine(string fileName);
        public static event OnCopyFileReadLine CopyFileHandler;

        #endregion

        /// <summary>
        /// Location of Visual Studio project templates
        /// </summary>
        public static string TemplateFolder => $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\{TemplatePath()}";
        
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
            /*
             * Local path/file name to file name
             */
            var remoteFile = "";
            
            try
            {
                foreach (var file in LocalCompressedFiles())
                {
                    remoteFile = $"{TemplateFolder}\\{Path.GetFileName(file)}";
                    
                    File.Copy(file, remoteFile, true);
                    
                    CopyFileHandler?.Invoke($"* {remoteFile}");
                }

                /*
                 * Does file count in local template folder match file count in Visual Studio template folder?
                 */
                return (LocalCompressedFiles().Count == RemoteCompressedFiles().Count, null)!;
            }
            catch (Exception exception)
            {
                /*
                 * Exception raised, report it
                 */
                CopyFileHandler?.Invoke($"X {remoteFile}");
                
                return (false, exception);
            }
        }

        /// <summary>
        /// For testing purposes only
        /// </summary>
        /// <returns></returns>
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
        
        /// <summary>
        /// Get list of project template files in <see cref="TemplateFolder"/>
        /// </summary>
        /// <returns>List of project files</returns>
        public static List<string> RemoteCompressedFiles() => Directory.GetFiles(TemplateFolder, "*.zip").ToList();
        
        
    }
}