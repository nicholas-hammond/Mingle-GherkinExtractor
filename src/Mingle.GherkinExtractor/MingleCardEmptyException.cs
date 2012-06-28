using System;

namespace Mingle.GherkinExtractor
{
    public class MingleCardNoContentException : Exception
    {
        public MingleCardNoContentException()
            : base("The card in mingle does not have any content")
        {
            
        }
    }
}