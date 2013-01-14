using System;
using System.IO;
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
					var uri = new Uri(new Uri(serverConfig.HostUrl), "/projects/" + project.ProjectId + Path.ChangeExtension(card.Url, ""));
                    
                    return new GherkinCard(card.Name, GetFeatureTags(card.CardProperties),  card.Description, uri.ToString());
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

        private string[] GetFeatureTags(MingleCardPropertyCollection mingleCardPropertyCollection)
        {
            var tags = new string[] {};
            
            if(mingleCardPropertyCollection.ContainsKey("FeatureTag") && !mingleCardPropertyCollection["FeatureTag"].IsValueNil)
            {
                tags = mingleCardPropertyCollection["FeatureTag"].Value.Split(',', ' ');
            }
            
            return tags;
        }
    }
}