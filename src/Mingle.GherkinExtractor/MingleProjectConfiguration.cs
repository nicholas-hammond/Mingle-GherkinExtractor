using System.Xml.Serialization;

namespace Mingle.GherkinExtractor
{
    public class MingleProjectConfiguration
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
    }
}