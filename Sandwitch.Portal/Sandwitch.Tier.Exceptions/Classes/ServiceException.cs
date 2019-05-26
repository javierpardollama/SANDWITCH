using System;

namespace Sandwitch.Tier.Exceptions.Classes
{
    public class ServiceException : Exception
    {
        public ServiceException(string message) : base(message) { }
    }
}
