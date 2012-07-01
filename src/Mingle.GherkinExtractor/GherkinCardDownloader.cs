using ThoughtWorksMingleLib;

namespace Mingle.GherkinExtractor
{
    public class GherkinCardDownloader
    {
        public GherkinCard Download(MingleConfiguration mingleConfiguration,
                                    GherkinCardConfiguration gherkinCardConfiguration)
        {
            MingleServerConfiguration serverConfig = mingleConfiguration.Server;
            MingleProjectConfiguration projectConfig = mingleConfiguration.Project;


            var credential = new MingleCredential();

            if (credential.Exists())
            {
                credential.Load();
            }
            else
            {
                credential.Prompt();
            }


            while (true)
            {
                IMingleServer server = new MingleServer(serverConfig.HostUrl, credential.Username,
                                                        credential.SecurePassword);
                MingleProject project = server.GetProject(projectConfig.Id);

                try
                {
                    MingleCard card = project.GetCard(gherkinCardConfiguration.Number);
                    return new GherkinCard(card.Description, card.Url);
                }
                catch (MingleWebException e)
                {
                    if (e.IsHttpUnauthorized() && !credential.Prompt())
                    {
                        throw;
                    }

                    throw;
                }
            }
        }
    }
}