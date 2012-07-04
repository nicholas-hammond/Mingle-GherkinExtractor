using System;
using System.Text;
using System.Web;
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

        public static Gherkin FromHtml(string name, string html)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);
            var nodes = document.DocumentNode.SelectNodes("//pre[@class='Gherkin']");

            StringBuilder builder = new StringBuilder();

        	builder.Append("Feature: ");
        	builder.Append(name);
        	builder.Append("\n\n");
        	
            foreach (var node in nodes)
            {
                var innerText = node.InnerText;
                var gherkinContent = HttpUtility.HtmlDecode(innerText);
                builder.AppendLine(gherkinContent);
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