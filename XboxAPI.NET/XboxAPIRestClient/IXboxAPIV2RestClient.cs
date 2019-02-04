using System.Net;
using System.Threading.Tasks;

namespace XboxAPI.NET.XboxAPIRestClient
{
    internal interface IXboxAPIV2RestClient
    {
        //Task<string> AccountProfile();
        //Task<string> AccountXuid();
        //Task<string> Gamercard();
        Task<XboxAPIRestResponse> GamertagXuid(string gamertag);
        //Task<string> GameStats();
        //Task<string> Presence();
        Task<XboxAPIRestResponse> Profile(string xuid);
        //Task<string> Xbox360GameAchievements();
        Task<XboxAPIRestResponse> Xbox360Games(string xuid);
        //Task<string> XboxOneGameAchievements();
        Task<XboxAPIRestResponse> XboxOneGames(string xuid);
        Task<XboxAPIRestResponse> XuidGamertag(string xuid);
    }
}
