using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public static Gherkin FromHtml(GherkinCard card)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(card.Content);
            var nodes = document.DocumentNode.SelectNodes("//pre[@class='Gherkin']");

            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("# {0}\n", card.Url);
            builder.Append(String.Join(" ", card.FeatureTags.Select(t => string.Format("@{0}", t.ToLowerInvariant()))));
            builder.Append("\n");
        	builder.Append("Feature: ");
        	builder.Append(card.Name);
        	builder.Append("\n\n");
        	
            foreach (var node in nodes)
            {
                var innerText = node.InnerText;
                var gherkinContent = HttpUtility.HtmlDecode(innerText);
                gherkinContent = Regex.Replace(gherkinContent, "@[A-Za-z0-9]*", match => match.Value.ToLowerInvariant());
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