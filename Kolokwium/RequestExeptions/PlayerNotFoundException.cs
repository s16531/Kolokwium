using System;
namespace Kolokwium.RequestExeptions
{
    public class PlayerNotFoundException : Exception
    {
        public PlayerNotFoundException(String warning)
            : base(warning)
        {
        }
    }
}
