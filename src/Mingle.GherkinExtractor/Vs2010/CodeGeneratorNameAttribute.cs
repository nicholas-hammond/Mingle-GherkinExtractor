using System;
using System.Diagnostics;

namespace Mingle.GherkinExtractor.Vs2010
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CodeGeneratorNameAttribute : Attribute
    {
        private readonly string codeGeneratorName;

        public CodeGeneratorNameAttribute(string codeGeneratorName)
        {
            this.codeGeneratorName = codeGeneratorName;
        }

        public static string Get(Type type)
        {
            object[] attributes = type.GetCustomAttributes(
                typeof (CodeGeneratorNameAttribute), false);
            Debug.Assert(attributes.Length == 1);
            return ((CodeGeneratorNameAttribute) attributes[0]).codeGeneratorName;
        }
    }
}