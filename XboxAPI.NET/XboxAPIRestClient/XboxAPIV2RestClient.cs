using RestSharp;
using System.Threading.Tasks;

namespace XboxAPI.NET.XboxAPIRestClient
{
    internal class XboxAPIV2RestClient : IXboxAPIV2RestClient
    {
        private const string XboxApiBaseUrl = "https://xboxapi.com";

        private IRestClient restClient;

        public XboxAPIV2RestClient(string apiKey)
        {
            this.restClient = new RestClient(baseUrl: XboxApiBaseUrl);
            this.restClient.AddDefaultHeader("X-AUTH", apiKey);
        }

        public async Task<XboxAPIRestResponse> AccountProfile()
        {
            RestRequest request = new RestRequest("/v2/profile");
            return await executeRequest(request);
        }

        public async Task<XboxAPIRestResponse> AccountXuid()
        {
            RestRequest request = new RestRequest("/v2/accountXuid");
            return await executeRequest(request);
        }


        public async Task<XboxAPIRestResponse> Gamercard(string xuid)
        {
            RestRequest request = new RestRequest("/v2/{xuid}/gamercard");
            request.AddUrlSegment("xuid", xuid);
            return await executeRequest(request);
        }

        public async Task<XboxAPIRestResponse> GamertagXuid(string gamertag)
        {
            RestRequest request = new RestRequest("/v2/xuid/{gamertag}");
            request.AddUrlSegment("gamertag", gamertag);
            return await executeRequest(request);
        }

        public async Task<XboxAPIRestResponse> GameStats(string xuid, string titleId)
        {
            RestRequest request = new RestRequest("/v2/{xuid}/game-stats/{titleId}");
            request.AddUrlSegment("xuid", xuid);
            request.AddUrlSegment("titleId", titleId);
            return await executeRequest(request);
        }

        public async Task<XboxAPIRestResponse> Presence(string xuid)
        {
            RestRequest request = new RestRequest("/v2/{xuid}/presence");
            request.AddUrlSegment("xuid", xuid);
            return await executeRequest(request);
        }

        public async Task<XboxAPIRestResponse> Profile(string xuid)
        {
            RestRequest request = new RestRequest("/v2/{xuid}/profile");
            request.AddUrlSegment("xuid", xuid);
            return await executeRequest(request);
        }

        public async Task<XboxAPIRestResponse> Xbox360Games(string xuid)
        {
            RestRequest request = new RestRequest("/v2/{xuid}/xbox360games");
            request.AddUrlSegment("xuid", xuid);
            return await executeRequest(request);
        }

        public async Task<XboxAPIRestResponse> XboxGameAchievements(string xuid, string titleId)
        {
            RestRequest request = new RestRequest("/v2/{xuid}/achievements/{titleId}");
            request.AddUrlSegment("xuid", xuid);
            request.AddUrlSegment("titleId", titleId);
            return await executeRequest(request);
        }

        public async Task<XboxAPIRestResponse> XboxOneGames(string xuid)
        {
            RestRequest request = new RestRequest("/v2/{xuid}/xboxonegames");
            request.AddUrlSegment("xuid", xuid);
            return await executeRequest(request);
        }

        public async Task<XboxAPIRestResponse> XuidGamertag(string xuid)
        {
            RestRequest request = new RestRequest("/v2/gamertag/{xuid}");
            request.AddUrlSegment("xuid", xuid);
            return await executeRequest(request);
        }

        private async Task<XboxAPIRestResponse> executeRequest(RestRequest request)
        {
            TaskCompletionSource<IRestResponse> taskCompletion = new TaskCompletionSource<IRestResponse>();

            RestRequestAsyncHandle handle = restClient.ExecuteAsync(request, r => taskCompletion.SetResult(r));
            IRestResponse response = (await taskCompletion.Task);
            return new XboxAPIRestResponse(response.StatusCode, response.Content);
        }
    }
}