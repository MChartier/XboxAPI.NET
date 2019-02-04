using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using XboxAPI.NET.XboxAPIRestClient;
using XboxAPIClient.Models.V2;

// Make internals visible to unit test project
[assembly: InternalsVisibleTo("XboxAPI.NET.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace XboxAPI.NET
{
    /// <summary>
    /// Client wrapper for the unofficial XboxAPI hosted at http://xboxapi.com/.
    /// </summary>
    public class XboxAPI
    {
        private readonly string apiKey;
        private readonly IXboxAPIV2RestClient xboxApiRestClient;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey"></param>
        public XboxAPI(string apiKey)
        {
            this.apiKey = apiKey;
            this.xboxApiRestClient = new XboxAPIV2RestClient(apiKey);
        }

        /// <summary>
        /// Internal constructor allowing dependency injection for unit testing.
        /// Avoids exposing internal IXboxAPIV2RestClient interface through public constructor.
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="xboxApiRestClient"></param>
        internal XboxAPI(string apiKey, IXboxAPIV2RestClient xboxApiRestClient = null)
        {
            this.apiKey = apiKey;
            this.xboxApiRestClient = xboxApiRestClient ?? new XboxAPIV2RestClient(apiKey);
        }

        public async Task<string> GamertagXuid(string gamertag)
        {
            XboxAPIRestResponse response = await xboxApiRestClient.GamertagXuid(gamertag);
            return response.Content;
        }

        public async Task<Profile> Profile(string xuid)
        {
            XboxAPIRestResponse response = await xboxApiRestClient.Profile(xuid);
            return JsonConvert.DeserializeObject<Profile>(response.Content);
        }

        public async Task<Xbox360Games> Xbox360Games(string xuid)
        {
            XboxAPIRestResponse response = await xboxApiRestClient.Xbox360Games(xuid);
            return JsonConvert.DeserializeObject<Xbox360Games>(response.Content);
        }

        public async Task<XboxOneGames> XboxOneGames(string xuid)
        {
            XboxAPIRestResponse response = await xboxApiRestClient.XboxOneGames(xuid);
            return JsonConvert.DeserializeObject<XboxOneGames>(response.Content);
        }

        public async Task<XuidGamertag> XuidGamertag(string xuid)
        {
            XboxAPIRestResponse response = await xboxApiRestClient.XuidGamertag(xuid);
            return JsonConvert.DeserializeObject<XuidGamertag>(response.Content);
        }
    }
}