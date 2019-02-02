using RestSharp;
using System.Threading.Tasks;

namespace XboxAPI.NET.XboxAPIRestClient
{
    public class XboxAPIV2RestClient : IXboxAPIV2RestClient
    {
        private const string XboxApiBaseUrl = "https://www.xboxapi.com";

        private IRestClient restClient;

        public XboxAPIV2RestClient(string apiKey)
        {
            this.restClient = new RestClient(baseUrl: XboxApiBaseUrl);
            this.restClient.AddDefaultHeader("X-AUTH", apiKey);
        }

        public async Task<string> GamertagXuid(string gamertag)
        {
            RestRequest request = new RestRequest("/v2/xuid/{gamertag}");
            request.AddUrlSegment("gamertag", gamertag);
            return await executeRequest(request);
        }

        public async Task<string> Xbox360Games(string xuid)
        {
            RestRequest request = new RestRequest("/v2/{xuid}/xbox360games");
            request.AddUrlSegment("xuid", xuid);
            return await executeRequest(request);
        }

        public async Task<string> XboxOneGames(string xuid)
        {
            RestRequest request = new RestRequest("/v2/{xuid}/xboxonegames");
            request.AddUrlSegment("xuid", xuid);
            return await executeRequest(request);
        }

        public async Task<string> XuidGamertag(string xuid)
        {
            RestRequest request = new RestRequest("/v2/gamertag/{xuid}");
            request.AddUrlSegment("xuid", xuid);
            return await executeRequest(request);
        }

        private async Task<string> executeRequest(RestRequest request)
        {
            TaskCompletionSource<IRestResponse> taskCompletion = new TaskCompletionSource<IRestResponse>();

            RestRequestAsyncHandle handle = restClient.ExecuteAsync(request, r => taskCompletion.SetResult(r));

            IRestResponse response = (await taskCompletion.Task);
            return response.Content;
        }
    }
}
