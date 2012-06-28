using System;
using System.Collections;

namespace Mingle.GherkinExtractor.Vs2010
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class CodeGeneratorLanguageAttribute : Attribute
    {
        public readonly string Description;
        public readonly string Guid;

        public CodeGeneratorLanguageAttribute(string guid, string description)
        {
            Guid = guid;
            Description = description;
        }

        public static ICollection Get(Type type)
        {
            object[] attributes = type.GetCustomAttributes(
                typeof (CodeGeneratorLanguageAttribute), false);
            return attributes;
        }
    }
}