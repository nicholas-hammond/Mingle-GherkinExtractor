using System;
using System.IO;
using System.Linq;
using EnvDTE;

namespace Mingle.GherkinExtractor
{
    public static class ProjectExtensions
    {
        public static bool TryFindFile(this Project project, string fileName, out FileInfo file)
        {
            var item = project.ProjectItems.Cast<ProjectItem>().FirstOrDefault(x => x.Name.Equals(fileName, StringComparison.InvariantCultureIgnoreCase));

            if (item != null)
            {
                var path = item.FileNames[0];
                file = new FileInfo(path);
                return true;
            }

            file = null;

            return false;

        }

        public static FileInfo FindMingleConfigurationFile(this Project project)
        {
            return project.FindFile("Mingle.config");
        }

        public static FileInfo FindFile(this Project project, string fileName)
        {
            var item = project.ProjectItems.Cast<ProjectItem>().FirstOrDefault(x => x.Name.Equals(fileName, StringComparison.InvariantCultureIgnoreCase));

            if (item != null)
            {
                var path = item.FileNames[0];
                return  new FileInfo(path);
            }

            return null;
        }

       
    }
}