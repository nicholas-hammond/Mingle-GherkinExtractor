using ThoughtWorksMingleLib;

namespace Mingle.GherkinExtractor
{
    public static class MingleWebExeptionExtensions
    {
        private const string Unauthorized = "(401)";

        public static bool IsHttpUnauthorized(this MingleWebException exception)
        {
            return exception.Message.Contains(Unauthorized);
        }
    }
}