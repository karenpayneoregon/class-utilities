using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using CopyProjectTemplates.Containers;

namespace CopyProjectTemplates.Classes
{
    /// <summary>
    /// Language extension methods for <see cref="System.Text.Json"/>
    /// </summary>
    public static class SystemJson
    {

        /// <summary>
        /// Convert a json string to a list of T
        /// </summary>
        /// <typeparam name="T">Type to deserialize</typeparam>
        /// <param name="jsonString">Valid json</param>
        /// <returns>List&lt;T&gt;</returns>
        public static List<T> JSonToList<T>(this string jsonString) => JsonSerializer.Deserialize<List<T>>(jsonString);
        /// <summary>
        /// Convert a json string to an instance of T
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="jsonString">text file containing valid data for deserializing to object</param>
        /// <returns></returns>
        public static T JSonToItem<T>(this string jsonString) => JsonSerializer.Deserialize<T>(jsonString);

        /// <summary>
        /// Partial location of Visual Studio project templates which is appended to the user folder
        /// </summary>
        /// <returns></returns>
        public static string TemplatePath() => JSonToItem<ApplicationSettings>(File.ReadAllText("appsettings.json")).TemplateFolder;

        /// <summary>
        /// Save List&lt;T&gt; to file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sender">Type to save</param>
        /// <param name="fileName">File to save too</param>
        /// <param name="format">true to format json, false not to format json</param>
        /// <returns>
        /// name value tuple, success of operation and a exception on failure
        /// </returns>
        public static (bool result, Exception exception) JsonToFile<T>(this T sender, string fileName, bool format = true)
        {

            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                File.WriteAllText(fileName, JsonSerializer.Serialize(sender, format ? options : null));

                return (true, null);

            }
            catch (Exception exception)
            {
                return (false, exception);
            }

        }

    }
}
