using System;

namespace Billing.Infrastructure.Common.Exceptions
{
    /// <summary>
    /// Represents the billing business exception class.
    /// </summary>
    public class BusinessException : Exception
    {
        public BusinessException()
        {
        }

        /// <summary>
        /// Initializes the instance of BusinessException.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public BusinessException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes the instance of BusinessException.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="inner">The inner exception.</param>
        public BusinessException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
