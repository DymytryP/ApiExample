using System;
using System.Runtime.Serialization;

namespace Billing.Infrastructure.Common.Exceptions
{
    public class FailedToReceiveDataFromProductsApiException : Exception
    {
        public FailedToReceiveDataFromProductsApiException()
        {
        }

        public FailedToReceiveDataFromProductsApiException(string message)
            : base(message)
        {
        }

        public FailedToReceiveDataFromProductsApiException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected FailedToReceiveDataFromProductsApiException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
