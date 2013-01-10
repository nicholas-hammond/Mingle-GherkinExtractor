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
            string text = null;
            Gherkin gherkin = null;

            "Given some html in a known format"
                .Context(() =>
                             {
                                 
                                 var html = Resource.GetString("GoodGherkin.htm");
                                 text = Resource.GetString("GoodGherkin.txt");
                                 card = new GherkinCard("My Test Feature", new[]{"Test1", "Test2"}, html, "http://mingle");
                             });

            "When creating from html".Do(() => gherkin = Gherkin.FromHtml(card));

            "Expect the gherkin string to be same as the good text gherkin"
                .Assert(() => gherkin.ToString().Should().Be(text));
        }

        [Specification]
        public void CreatingWithoutFeatureTags()
        {
            GherkinCard card = null;
            string text = null;
            Gherkin gherkin = null;

            "Given some html in a known format without any feature tags"
                .Context(() =>
                            {
                                var html = Resource.GetString("GoodGherkin.htm");
                                text = Resource.GetString("GoodGherkinWithoutFeatureTags.txt");
                                card = new GherkinCard("My Test Feature", new string[] { }, html, "http://mingle");
                            });

            "When creating from html".Do(() => gherkin = Gherkin.FromHtml(card));

            "Expect the gherkin string to be same as the good text gherkin excluding feature tags"
                .Assert(() => gherkin.ToString().Should().Be(text));
        }

      
    }
}