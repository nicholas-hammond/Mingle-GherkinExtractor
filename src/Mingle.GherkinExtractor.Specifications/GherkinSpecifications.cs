using FluentAssertions;
using Mingle.GherkinExtractor.Specifications.SubSpec;

namespace Mingle.GherkinExtractor.Specifications
{
    public class GherkinSpecifications
    {
        [Specification]
        public void CreatingFromHtml()
        {
            string html = null;
            string text = null;
            Gherkin gherkin = null;

            "Given some html in a known format"
                .Context(() =>
                             {
                                 html = Resource.GetString("GoodGherkin.htm");
                                 text = Resource.GetString("GoodGherkin.txt");
                             });

            "When creating from html"
                .Do(() =>
                        {
                            gherkin = Gherkin.FromHtml(html);
                        });

            "Expect the gherkin string to be same as the good text gherkin"
                .Assert(() =>
                            {
                                gherkin.ToString().Should().Be(text);
                            });
        }

      
    }
}