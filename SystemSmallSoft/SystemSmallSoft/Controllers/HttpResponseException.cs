using System;
using System.Net.Http;
using System.Runtime.Serialization;

namespace SystemSmallSoft.Controllers
{
    [Serializable]
    internal class HttpResponseException : Exception
    {
        private HttpResponseMessage httpResponseMessage;

        public HttpResponseException()
        {
        }

        public HttpResponseException(HttpResponseMessage httpResponseMessage)
        {
            this.httpResponseMessage = httpResponseMessage;
        }

        public HttpResponseException(string message) : base(message)
        {
        }

        public HttpResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HttpResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}