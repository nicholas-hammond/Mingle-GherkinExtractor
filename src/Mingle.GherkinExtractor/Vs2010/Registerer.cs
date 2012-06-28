using System;
using System.Diagnostics;
using Microsoft.Win32;

namespace Mingle.GherkinExtractor.Vs2010
{
    public class Registerer
    {
        public static void Register(Type type)
        {
            foreach (CodeGeneratorLanguageAttribute languageAttribute in 
                CodeGeneratorLanguageAttribute.Get(type))
            {
                foreach (Version version in CodeGeneratorVSVersionAttribute.Get(type))
                {
                    string codeGeneratorName = CodeGeneratorNameAttribute.Get(type);
                    Register(type, languageAttribute.Guid,
                             languageAttribute.Description, version, codeGeneratorName);
                }
            }
        }

        private static void Register(Type type, string languageGuid,
                                     string description, Version vsVersion, string codeGeneratorName)
        {
            Debug.Assert(languageGuid != null);
            Debug.Assert(languageGuid.Length != 0);
            Debug.Assert(description != null);

            // Register only if base key is found.
            string baseKeyPath = CombineKeyPath(GetGeneratorsRegKeyPath(vsVersion), languageGuid);
            RegistryKey baseKey = Registry.LocalMachine.OpenSubKey(baseKeyPath, true);
            if (baseKey == null)
                return;

            using (baseKey)
            {
                using (RegistryKey toolKey = Registry.LocalMachine.CreateSubKey(
                    CombineKeyPath(baseKeyPath, codeGeneratorName)))
                {
                    toolKey.SetValue(string.Empty, description);
                    toolKey.SetValue("CLSID", type.GUID.ToString("B").ToUpper());
                    toolKey.SetValue("GeneratesDesignTimeSource", 1);
                }
            }
        }


        public static void Unregister(Type type)
        {
            foreach (CodeGeneratorLanguageAttribute languageAttribute in 
                CodeGeneratorLanguageAttribute.Get(type))
            {
                foreach (Version version in CodeGeneratorVSVersionAttribute.Get(type))
                {
                    string codeGeneratorName = CodeGeneratorNameAttribute.Get(type);
                    Unregister(languageAttribute.Guid, version, codeGeneratorName);
                }
            }
        }

        private static void Unregister(string languageGuid,
                                       Version vsVersion, string codeGeneratorName)
        {
            Debug.Assert(languageGuid != null);
            Debug.Assert(languageGuid.Length != 0);

            string keyPath = CombineKeyPath(GetGeneratorsRegKeyPath(vsVersion),
                                            CombineKeyPath(languageGuid, codeGeneratorName));
            Registry.LocalMachine.DeleteSubKey(keyPath, false);
        }


        private static string GetGeneratorsRegKeyPath(Version vsVersion)
        {
            return string.Format(@"SOFTWARE\Microsoft\VisualStudio\{0}.{1}\Generators",
                                 vsVersion.Major.ToString(), vsVersion.Minor.ToString());
        }

        private static string CombineKeyPath(string leftPart, string rightPart)
        {
            Debug.Assert(leftPart != null);
            Debug.Assert(leftPart.Length != 0);
            Debug.Assert(rightPart != null);
            Debug.Assert(rightPart.Length != 0);

            if (leftPart[leftPart.Length - 1] == '\\')
                return leftPart + rightPart;

            return string.Concat(leftPart, @"\", rightPart);
        }
    }
}