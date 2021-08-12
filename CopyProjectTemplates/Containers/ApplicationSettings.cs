using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CopyProjectTemplates.Classes;

namespace CopyProjectTemplates.Containers
{
    public class ApplicationSettings
    {
        /// <summary>
        /// Location for Visual Studio project templates
        /// </summary>
        public string TemplateFolder { get; set; }

        public string Developer { get; set; }
        
    }

    public class Mocking
    {
        public static void Create()
        {
            string fileName = "appsettings.json";
            ApplicationSettings settings = new() {Developer = "Karen Payne", TemplateFolder = "\\Documents\\Visual Studio 2019\\Templates\\ProjectTemplates1"};

            var (success, exception) = settings.JsonToFile(fileName);


        }
    }
}
