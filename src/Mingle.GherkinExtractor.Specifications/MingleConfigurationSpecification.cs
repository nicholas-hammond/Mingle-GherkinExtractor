using System;
using System.IO;
using FluentAssertions;
using Mingle.GherkinExtractor.Specifications.SubSpec;
using Xunit;

namespace Mingle.GherkinExtractor.Specifications
{
    public class MingleConfigurationSpecification
    {

        [Specification]
        public void CreatingWithAGoodFile()
        {
            FileInfo file = null;
            MingleConfiguration configuration = null;

            "Given an xml file that is valid"
                .Context(() =>
                             {
                                 file = new FileInfo("Mingle.xml");
                             });

            "When creating"
                .Do(() =>
                        {
                            configuration = MingleConfiguration.CreateFromFile(file.FullName);
                        });

            "Expect the project to id to be set"
                .Assert(() => configuration.Project.Id.Should().Be("my_easyjet"));


            "Expect the server url to be set"
                .Assert(() => configuration.Server.HostUrl.Should().Be("http://172.16.100.137:8080"));

            "Expect the server login name to be set"
                .Assert(() => configuration.Server.LoginName.Should().Be("fred"));

            "Expect the server password to be set"
               .Assert(() => configuration.Server.Password.Should().Be("somepassword"));
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
                            exception = Record.Exception((() => MingleConfiguration.CreateFromFile(file.FullName))) ;
                        });

            "Expect a file not found exception"
                .Assert(() => exception.Should().BeOfType<FileNotFoundException>());
        }

       
    }
}