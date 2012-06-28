using System.IO;
using System.Xml.Serialization;

namespace Mingle.GherkinExtractor
{
    [XmlRoot("mingle")]
    public class MingleConfiguration
    {
        public MingleConfiguration()
        {
            Server = new MingleServerConfiguration();
            Project = new MingleProjectConfiguration();
        }

        public static MingleConfiguration CreateFromFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Unable to load the mingle configuration file", path);
            }

            var serializer = new XmlSerializer(typeof (MingleConfiguration));

            var stream = new FileStream(path, FileMode.Open);

            using (stream)
            {
              return (MingleConfiguration)  serializer.Deserialize(stream);
            }
        }

        [XmlElement("server")]
        public MingleServerConfiguration Server { get; set; }

        [XmlElement("project")]
        public MingleProjectConfiguration Project { get; set; }
        
    }
}