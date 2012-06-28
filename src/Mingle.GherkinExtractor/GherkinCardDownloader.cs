using ThoughtWorksMingleLib;

namespace Mingle.GherkinExtractor
{
    public class GherkinCardDownloader
    {

        public GherkinCard Download(MingleConfiguration mingleConfiguration, GherkinCardConfiguration gherkinCardConfiguration)
        {
            var serverConfig = mingleConfiguration.Server;
            var projectConfig = mingleConfiguration.Project;
            

            IMingleServer server = new MingleServer(serverConfig.HostUrl, serverConfig.LoginName, serverConfig.Password);
            var project = server.GetProject(projectConfig.Id);
            var card = project.GetCard(gherkinCardConfiguration.Number);

            return new GherkinCard(card.Description, card.Url);

        }
    }


}