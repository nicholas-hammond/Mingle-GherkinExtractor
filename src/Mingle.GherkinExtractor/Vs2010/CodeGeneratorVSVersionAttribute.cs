using System;
using System.Collections;

namespace Mingle.GherkinExtractor.Vs2010
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class CodeGeneratorVSVersionAttribute : Attribute
    {
        private readonly Version version;

        public CodeGeneratorVSVersionAttribute(int major, int minor)
        {
            version = new Version(major, minor);
        }

        public static Version[] Get(Type type)
        {
            object[] attributes = type.GetCustomAttributes(
                typeof (CodeGeneratorVSVersionAttribute), false);
         
            var result = new ArrayList(attributes.Length);
            foreach (CodeGeneratorVSVersionAttribute vsVersionAttribute in attributes)
            {
                result.Add(vsVersionAttribute.version);
            }
            return (Version[]) result.ToArray(typeof (Version));
        }
    }
}