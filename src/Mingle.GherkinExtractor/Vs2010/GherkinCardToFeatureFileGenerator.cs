using System;
using System.Reflection;
using System.Runtime.InteropServices;
using EnvDTE;
using Microsoft.VisualStudio.Shell;

namespace Mingle.GherkinExtractor.Vs2010
{
    [Guid("365b4095-8e2a-44aa-9bc2-d917ee97c33c")]
    [ProgId("GherkinCardToFeatureFileGenerator")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    [CodeGeneratorName("GherkinCardToFeatureFileGenerator")]
    [CodeGeneratorLanguage("{FAE04EC1-301F-11D3-BF4B-00C04F79EFBC}",
        "Generator for converting mingle cards containing Gherkin syntax to feature files")]
    [CodeGeneratorVSVersion(10, 0)]
    [ProvideObject(typeof (GherkinCardToFeatureFileGenerator))]
    public class GherkinCardToFeatureFileGenerator : SingleFileGeneratorBase
    {
        static GherkinCardToFeatureFileGenerator()
        {
            typeof(GherkinCardToFeatureFileGenerator).Assembly.LoadDependencies();
        }   

        public GherkinCardToFeatureFileGenerator() : base(".card")
        {
           
        }


        protected override bool GenerateInternal(string inputFilePath, string inputFileContent, Project project,
                                                 string defaultNamespace, Action<SingleFileGeneratorError> onError,
                                                 out string generatedContent)
        {
            GherkinCardConfiguration gherkinCardConfiguration = GherkinCardConfiguration.CreateFromFile(inputFilePath);
            MingleConfiguration mingleConfiguration =
                MingleConfiguration.CreateFromFile(project.FindMingleConfigurationFile().FullName);

            var downloader = new GherkinCardDownloader();

            var gherkinCard  = downloader.Download(mingleConfiguration, gherkinCardConfiguration);

            if (gherkinCard.HasNoContent)
            {
                throw new MingleCardNoContentException();
            }
            

            var gherkin = Gherkin.FromHtml(gherkinCard.Content); 

            generatedContent = gherkin.ToString();


            return true;
        }

        protected override string GetDefaultExtension()
        {
            return ".feature";
        }

        
    }
}