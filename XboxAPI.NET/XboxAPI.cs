using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Threading.Tasks;
using XboxAPI.NET.XboxAPIRestClient;
using XboxAPIClient.Models.V2;

namespace XboxAPI.NET
{
    /// <summary>
    /// Client wrapper for the unofficial XboxAPI hosted at http://xboxapi.com/.
    /// </summary>
    public class XboxAPI
    {
        private readonly string apiKey;
        private readonly IXboxAPIV2RestClient xboxApiRestClient;

        public XboxAPI(string apiKey, IXboxAPIV2RestClient xboxApiRestClient = null)
        {
            this.apiKey = apiKey;
            this.xboxApiRestClient = xboxApiRestClient ?? new XboxAPIV2RestClient(apiKey);
        }

        public async Task<GamertagXuid> GamertagXuid(string gamertag)
        {
            string json = await xboxApiRestClient.GamertagXuid(gamertag);
            return JsonConvert.DeserializeObject<GamertagXuid>(json);
        }

        public async Task<Profile> Profile(string xuid)
        {
            string json = await xboxApiRestClient.Profile(xuid);
            return JsonConvert.DeserializeObject<Profile>(json);
        }

        public async Task<Xbox360Games> Xbox360Games(string xuid)
        {
            string json = await xboxApiRestClient.Xbox360Games(xuid);
            return JsonConvert.DeserializeObject<Xbox360Games>(json);
        }

        public async Task<XboxOneGames> XboxOneGames(string xuid)
        {
            string json = await xboxApiRestClient.XboxOneGames(xuid);
            return JsonConvert.DeserializeObject<XboxOneGames>(json);
        }

        public async Task<XuidGamertag> XuidGamertag(string xuid)
        {
            string json = await xboxApiRestClient.XuidGamertag(xuid);
            return JsonConvert.DeserializeObject<XuidGamertag>(json);
        }
    }
}