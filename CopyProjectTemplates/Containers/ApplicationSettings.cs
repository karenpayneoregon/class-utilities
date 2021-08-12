using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
