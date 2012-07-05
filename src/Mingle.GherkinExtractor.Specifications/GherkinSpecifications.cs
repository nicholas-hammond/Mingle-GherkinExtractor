using FluentAssertions;
using Mingle.GherkinExtractor.Specifications.SubSpec;

namespace Mingle.GherkinExtractor.Specifications
{
    public class GherkinSpecifications : SpecificationsBase
    {
        [Specification]
        public void CreatingFromHtml()
        {
            GherkinCard card = null;
            string html = null;
            string text = null;
            Gherkin gherkin = null;

            "Given some html in a known format"
                .Context(() =>
                             {
                                 
                                 html = Resource.GetString("GoodGherkin.htm");
                                 text = Resource.GetString("GoodGherkin.txt");
                                 card = new GherkinCard("My Test Feature", html, "http://mingle");
                             });

            "When creating from html"
                .Do(() =>
                        {
                            gherkin = Gherkin.FromHtml(card);
                        });

            "Expect the gherkin string to be same as the good text gherkin"
                .Assert(() =>
                            {
                                gherkin.ToString().Should().Be(text);
                            });
        }

      
    }
}