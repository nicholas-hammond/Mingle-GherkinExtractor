using System.Xml.Serialization;

namespace Mingle.GherkinExtractor
{
    public class MingleServerConfiguration
    {
        [XmlAttribute("hostUrl")]
        public string HostUrl { get; set; }

        [XmlAttribute("loginName")]
        public string LoginName { get; set; }

        [XmlAttribute("password")]
        public string Password { get; set; }
    }
}