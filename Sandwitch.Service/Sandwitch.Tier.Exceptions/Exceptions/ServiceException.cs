﻿using System;

namespace Sandwitch.Tier.Exceptions.Exceptions
{
    /// <summary>
    /// Represents a <see cref="ServiceException"/> class. Inherits <see cref="Exception"/>
    /// </summary>
    public class ServiceException : Exception
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="ServiceException"/>
        /// </summary>
        public ServiceException() : base() { }

        /// <summary>
        /// Initializes a new Instance of <see cref="ServiceException"/>
        /// </summary>
        /// <param name="message">Instance of <see cref="string"/></param>
        public ServiceException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new Instance of <see cref="ServiceException"/>
        /// </summary>
        /// <param name="message">Instance of <see cref="string"/></param>
        /// <param name="innerException">Instance of <see cref="ServiceException"/>></param>
        public ServiceException(string message, ServiceException innerException) : base(message, innerException) { }
    }
}
