using System.Threading.Tasks;

namespace XboxAPI.NET.XboxAPIRestClient
{
    internal interface IXboxAPIV2RestClient
    {
        Task<XboxAPIRestResponse> AccountProfile();

        Task<XboxAPIRestResponse> AccountXuid();

        Task<XboxAPIRestResponse> Gamercard(string xuid);

        Task<XboxAPIRestResponse> GamertagXuid(string gamertag);

        Task<XboxAPIRestResponse> GameStats(string xuid, string titleId);

        Task<XboxAPIRestResponse> Presence(string xuid);

        Task<XboxAPIRestResponse> Profile(string xuid);

        Task<XboxAPIRestResponse> Xbox360Games(string xuid);

        Task<XboxAPIRestResponse> XboxGameAchievements(string xuid, string titleId);

        Task<XboxAPIRestResponse> XboxOneGames(string xuid);

        Task<XboxAPIRestResponse> XuidGamertag(string xuid);
    }
}