using RestSharp;

namespace XboxAPI.NET.Factories
{
    public class RestClientFactory : IRestClientFactory
    {
        private const string baseUrl = "https://www.xboxapi.com/";

        public IRestClient BuildRestClient()
        {
            return new RestClient(baseUrl);
        }
    }
}