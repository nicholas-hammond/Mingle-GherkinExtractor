using System;
using System.IO;
using FluentAssertions;
using Mingle.GherkinExtractor.Specifications.SubSpec;
using Xunit;

namespace Mingle.GherkinExtractor.Specifications
{
    public class GherkinCardConfigurationSpecification
    {
        [Specification]
        public void CreatingWithAGoodFile()
        {
            FileInfo file = null;
            GherkinCardConfiguration gherkinCardConfiguration = null;

            "Given an xml file that is valid"
                .Context(() =>
                             {
                                 file = new FileInfo("StoryCard.xml");
                             });

            "When creating"
                .Do(() =>
                        {
                            gherkinCardConfiguration = GherkinCardConfiguration.CreateFromFile(file.FullName);
                        });

            "Expect the number to be set"
                .Assert(() => gherkinCardConfiguration.Number.Should().Be(15389));


           
        }

        [Specification]
        public void CreatingWithAFileThatDoesNotExist()
        {
            FileInfo file = null;
            Exception exception = null;

            "Given a file path that does not exist "
                .Context(() =>
                             {
                                 file = new FileInfo(@"G:\Blahblah.xml");
                             });

            "When creating"
                .Do(() =>
                        {
                            exception = Record.Exception((() => GherkinCardConfiguration.CreateFromFile(file.FullName)));
                        });

            "Expect a file not found exception"
                .Assert(() => exception.Should().BeOfType<FileNotFoundException>());
        }

    }
}