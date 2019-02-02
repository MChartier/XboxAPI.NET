using System.Threading.Tasks;

namespace XboxAPI.NET.XboxAPIRestClient
{
    public interface IXboxAPIV2RestClient
    {
        //Task<string> AccountProfile();
        //Task<string> AccountXuid();
        //Task<string> Gamercard();
        Task<string> GamertagXuid(string gamertag);
        //Task<string> GameStats();
        //Task<string> Presence();
        //Task<string> Profile();
        //Task<string> Xbox360GameAchievements();
        Task<string> Xbox360Games(string xuid);
        //Task<string> XboxOneGameAchievements();
        Task<string> XboxOneGames(string xuid);
        Task<string> XuidGamertag(string xuid);
    }
}
