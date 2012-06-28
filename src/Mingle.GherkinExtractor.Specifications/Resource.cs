using System;
using System.IO;
using System.Reflection;
using System.Linq;

namespace Mingle.GherkinExtractor.Specifications
{
    public static class Resource
    {
         public static Stream GetStream(string name)
         {
             var assembly = Assembly.GetExecutingAssembly();

             var fullName =
                 assembly.GetManifestResourceNames().First(
                     x => x.EndsWith(name, StringComparison.InvariantCultureIgnoreCase));

             return assembly.GetManifestResourceStream(fullName);
         }

         public static string GetString(string name)
         {
             using (var stream = GetStream(name))
             {
                 using (var reader = new StreamReader(stream))
                 {
                     return reader.ReadToEnd();
                 }
             }
             
         }

    }
}