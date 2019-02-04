using System.Net;

namespace XboxAPI.NET.XboxAPIRestClient
{
    internal class XboxAPIRestResponse
    {
        public string Content;
        public HttpStatusCode StatusCode;

        public XboxAPIRestResponse(HttpStatusCode statusCode, string content)
        {
            this.StatusCode = statusCode;
            this.Content = content;
        }
    }
}