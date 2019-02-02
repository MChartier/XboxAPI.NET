using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Threading.Tasks;
using XboxAPIClient.Models.V2;

namespace XboxAPI.NET
{
    /// <summary>
    /// Client wrapper for the unofficial XboxAPI hosted at http://xboxapi.com/.
    /// </summary>
    public class XboxAPI
    {
        // We will retry in case where Xbox API returns a 502 (BadGateway) response
        // These happen indeterminately and should be treated as retryable
        private const int MAX_ATTEMPTS = 2;

        private const string baseUrl = "https://xboxapi.com/";

        private string apiKey;

        public XboxAPI(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public Task<XboxAPIResponse<GamertagXuid>> GamertagXuid(string gamertag)
        {
            RestRequest request = new RestRequest("/v2/xuid/{gamertag}");
            request.AddUrlSegment("gamertag", gamertag);
            return executeAndDeserialize<GamertagXuid>(request);
        }

        public Task<XboxAPIResponse<Xbox360Games>> Xbox360Games(string xuid)
        {
            RestRequest request = new RestRequest("/v2/{xuid}/xbox360games");
            request.AddUrlSegment("xuid", xuid);
            return executeAndDeserialize<Xbox360Games>(request);
        }

        public Task<XboxAPIResponse<XboxOneGames>> XboxOneGames(string xuid)
        {
            RestRequest request = new RestRequest("/v2/{xuid}/xboxonegames");
            request.AddUrlSegment("xuid", xuid);
            return executeAndDeserialize<XboxOneGames>(request);
        }

        public Task<XboxAPIResponse<XuidGamertag>> XuidGamertag(string xuid)
        {
            RestRequest request = new RestRequest("/v2/gamertag/{xuid}");
            request.AddUrlSegment("xuid", xuid);
            return executeAndDeserialize<XuidGamertag>(request);
        }

        /// <summary>
        /// Executes the given request using this object's API key.
        /// </summary>
        /// <param name="request">The request to be executed.</param>
        private async Task<RestResponse> execute(RestRequest request)
        {
            RestClient client = new RestClient(baseUrl);
            client.AddDefaultHeader("X-AUTH", apiKey);

            TaskCompletionSource<IRestResponse> taskCompletion = new TaskCompletionSource<IRestResponse>();

            RestRequestAsyncHandle handle = client.ExecuteAsync(request, r => taskCompletion.SetResult(r));

            return (RestResponse)(await taskCompletion.Task);
        }

        /// <summary>
        /// Executes the given request using this object's API key, and deserializes the response.
        /// </summary>
        /// <typeparam name="T">The type of object to which the response should be deserialized</typeparam>
        /// <param name="request">The request to be executed.</param>
        /// <returns>The deserialized response object.</returns>
        private async Task<XboxAPIResponse<T>> executeAndDeserialize<T>(RestRequest request) where T : class
        {
            for (int attemptedRequestCount = 1; attemptedRequestCount <= MAX_ATTEMPTS; attemptedRequestCount++)
            {
                RestResponse restResponse = await execute(request);
                if (restResponse.IsSuccessful)
                {
                    // On success, return response with deserialized content
                    return new XboxAPIResponse<T>(attemptedRequestCount,
                        JsonConvert.DeserializeObject<T>(restResponse.Content));
                }
                else if (restResponse.StatusCode == HttpStatusCode.BadGateway)
                {
                    // If we received a BadGateway response, try again a fixed number of times
                    continue;
                }
                else
                {
                    // If we got some other failure response code, treat it as non-retryable and return immediately
                    return new XboxAPIResponse<T>(attemptedRequestCount, null);
                }
            }

            // If BadGateway retries are exhausted, return failure response
            return new XboxAPIResponse<T>(MAX_ATTEMPTS, null);
        }
    }
}