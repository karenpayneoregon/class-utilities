using CopyProjectTemplates.Classes;

namespace CopyProjectTemplates.Containers
{
    /// <summary>
    /// To create initial appsettings.json file
    /// </summary>
    /// <remarks>
    /// 1. ProjectTemplates1 is for testing, ProjectTemplates is for running live
    /// 2. If the version of Visual Studio changes, change the path
    /// </remarks>
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