using System.IO;
using System.Xml.Serialization;

namespace Mingle.GherkinExtractor
{
    [XmlRoot("card")]
    public class GherkinCardConfiguration
    {
        [XmlAttribute("number")]
        public int Number { get; set; }

        [XmlAttribute("url")]
        public string Url { get; set; }


        public static GherkinCardConfiguration CreateFromFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Unable to load the card file ", path);
            }

            var serializer = new XmlSerializer(typeof(GherkinCardConfiguration));

            var stream = new FileStream(path, FileMode.Open);

            using (stream)
            {
                return (GherkinCardConfiguration)serializer.Deserialize(stream);
            }
        }

        public  void Save(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Unable to load the card file ", path);
            }

            var serializer = new XmlSerializer(typeof(GherkinCardConfiguration));

            var stream = new FileStream(path, FileMode.Open);

            using (stream)
            {
                serializer.Serialize(stream, this);
            }
        }
    }
}