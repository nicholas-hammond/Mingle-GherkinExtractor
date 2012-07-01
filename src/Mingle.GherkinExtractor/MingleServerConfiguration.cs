using System.Xml.Serialization;

namespace Mingle.GherkinExtractor
{
    public class MingleServerConfiguration
    {
        [XmlAttribute("hostUrl")]
        public string HostUrl { get; set; }
    }
}