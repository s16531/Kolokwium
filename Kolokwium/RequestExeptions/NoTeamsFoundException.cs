using System;
namespace Kolokwium.RequestExeptions
{
    public class NoTeamsFoundException : Exception
    {
        public NoTeamsFoundException(String warning)
            : base(warning)
        {
        }
    }
}
