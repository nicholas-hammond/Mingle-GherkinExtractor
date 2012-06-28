namespace Mingle.GherkinExtractor
{
    /// <summary>
    /// Represents a card in mingle that has Gherkin syntax in its content
    /// </summary>
    public class GherkinCard
    {
        public GherkinCard(string content, string url)
        {
            Url = url;
            Content = content;
        }

        public string Content { get; private set; }
        public string Url { get; private set; }

        public bool HasNoContent
        {
            get { return string.IsNullOrEmpty(Content); }
        }

    }
}