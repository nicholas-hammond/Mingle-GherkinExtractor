using System.Reflection;

namespace Mingle.GherkinExtractor.Specifications
{
    public abstract class SpecificationsBase
    {
        protected SpecificationsBase()
        {
            typeof(Gherkin).Assembly.LoadDependencies();
        }
    }
}