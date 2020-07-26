using System;
using System.Diagnostics.CodeAnalysis;

namespace BioEngine.BRC.Common.Twitter.Exceptions
{
    [SuppressMessage("Readability", "RCS1194", Justification = "Reviewed")]
    public class TwitterException : Exception
    {
        public TwitterException(string message) : base(message)
        {
        }
    }
}