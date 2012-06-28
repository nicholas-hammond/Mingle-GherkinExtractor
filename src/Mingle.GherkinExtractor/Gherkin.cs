using System;
using System.Text;
using HtmlAgilityPack;

namespace Mingle.GherkinExtractor
{
    public class Gherkin
    {
        private readonly string _content;

        public Gherkin(string content)
        {
            _content = content;
        }

        public static Gherkin FromHtml(string html)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);
            var nodes = document.DocumentNode.SelectNodes("//pre[@class='Gherkin']");

            StringBuilder builder = new StringBuilder();

            foreach (var node in nodes)
            {
                builder.AppendLine(node.InnerText);
            }

            var text = builder.ToString().TrimEnd(Environment.NewLine.ToCharArray());

            return new Gherkin(text);
        }

        public override string ToString()
        {
            return _content;
        }
    }
}