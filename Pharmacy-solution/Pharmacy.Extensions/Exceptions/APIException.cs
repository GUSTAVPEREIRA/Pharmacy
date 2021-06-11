using System;
using System.Net;

namespace Pharmacy.Extensions.Exceptions
{
    public class APIException : Exception
    {
        private readonly HttpStatusCode _statusCode;

        public APIException(string message, HttpStatusCode statusCode) : base(message)
        {
            _statusCode = statusCode;
        }

        public APIException(string message, HttpStatusCode statusCode, Exception innerException) : base(message, innerException)
        {
            _statusCode = statusCode;
        }

        public HttpStatusCode StatusCode
        {
            get
            {
                return _statusCode;
            }
        }
    }
}