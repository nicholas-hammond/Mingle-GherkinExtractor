using System.Linq;
using System.Runtime.InteropServices;
using EnvDTE;

namespace Mingle.GherkinExtractor.Specifications
{
    public static class VisualStudio
    {
        public static DTE Instance
        {
            get { return (DTE) Marshal.GetActiveObject("VisualStudio.DTE"); }
        }

        public static Project ThisProject
        {
            get
            {
                return ((Instance.ActiveSolutionProjects) as object[])
                    .Cast<Project>().FirstOrDefault();
            }
        }
    }
}