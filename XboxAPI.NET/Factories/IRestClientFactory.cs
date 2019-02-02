using RestSharp;

namespace XboxAPI.NET.Factories
{
    public interface IRestClientFactory
    {
        IRestClient BuildRestClient();
    }
}