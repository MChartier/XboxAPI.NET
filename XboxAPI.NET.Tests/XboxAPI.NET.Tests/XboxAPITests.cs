using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using XboxAPI.NET.Models.V2;
using XboxAPI.NET.XboxAPIRestClient;
using XboxAPIClient.Models.V2;

namespace XboxAPI.NET.Tests
{
    [TestClass]
    public class XboxAPITests
    {
        const string Gamertag = "Major Nelson";
        const long Xuid = 2584878536129841; // Major Nelson

        private const string Xbox360GameTitleId = "1297287142"; // Halo 3
        private const string XboxOneGameTitleId = "219630713"; // Halo 5: Guardians

        private Mock<IXboxAPIV2RestClient> mockXboxApiRestClient;
        private XboxAPI xboxAPI;

        [TestInitialize]
        public void TestInitialize()
        {
            // Setup mock rest client
            mockXboxApiRestClient = new Mock<IXboxAPIV2RestClient>();
            this.xboxAPI = new XboxAPI(apiKey: null, xboxApiRestClient: mockXboxApiRestClient.Object);
        }

        [TestMethod]
        public void AccountProfile()
        {
            mockXboxApiRestClient.Setup(x => x.AccountProfile())
                .Returns(readTestResponse("AccountProfile/Success.json"));

            AccountProfile result = xboxAPI.AccountProfile().GetAwaiter().GetResult();
            Assert.AreEqual(Xuid, result.userXuid);
        }

        [TestMethod]
        public void AccountXuid()
        {
            mockXboxApiRestClient.Setup(x => x.AccountXuid()).Returns(readTestResponse("AccountXuid/Success.json"));

            AccountXuid result = xboxAPI.AccountXuid().GetAwaiter().GetResult();
            Assert.AreEqual(Xuid, result.xuid);
        }

        [TestMethod]
        public void Gamercard()
        {
            mockXboxApiRestClient.Setup(x => x.Gamercard(Xuid.ToString()))
                .Returns(readTestResponse("Gamercard/Success.json"));

            Gamercard result = xboxAPI.Gamercard(Xuid.ToString()).GetAwaiter().GetResult(); ;
            Assert.AreEqual("Major Nelson", result.gamertag);
        }

        [TestMethod]
        public void GamertagXuid()
        {
            mockXboxApiRestClient.Setup(x => x.GamertagXuid(Gamertag))
                .Returns(readTestResponse("GamertagXuid/Success.json"));

            string result = xboxAPI.GamertagXuid(Gamertag).GetAwaiter().GetResult();
            Assert.AreEqual(Xuid.ToString(), result);
        }

        [TestMethod]
        public void GameStats()
        {
            mockXboxApiRestClient.Setup(x => x.GameStats(Xuid.ToString(), XboxOneGameTitleId))
                .Returns(readTestResponse("GameStats/Success.json"));

            GameStats result = xboxAPI.GameStats(Xuid.ToString(), XboxOneGameTitleId).GetAwaiter().GetResult();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Presence()
        {
            mockXboxApiRestClient.Setup(x => x.Presence(Xuid.ToString())).Returns(readTestResponse("Presence/Success.json"));

            Presence result = xboxAPI.Presence(Xuid.ToString()).GetAwaiter().GetResult();
            Assert.AreEqual(Xuid, result.xuid);
        }

        [TestMethod]
        public void Profile()
        {
            const string Xuid = "2584878536129841";
            mockXboxApiRestClient.Setup(x => x.Profile(Xuid)).Returns(readTestResponse("Profile/Success.json"));

            Profile result = xboxAPI.Profile(Xuid).GetAwaiter().GetResult(); ;
            Assert.AreEqual("Major Nelson", result.Gamertag);
        }

        [TestMethod]
        public void Xbox360GameAchievements()
        {
            mockXboxApiRestClient.Setup(x => x.XboxGameAchievements(Xuid.ToString(), Xbox360GameTitleId))
                .Returns(readTestResponse("Xbox360GameAchievements/Success.json"));

            Xbox360GameAchievement[] result = xboxAPI.Xbox360GameAchievements(Xuid.ToString(), Xbox360GameTitleId)
                .GetAwaiter().GetResult();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Xbox360Games()
        {
            mockXboxApiRestClient.Setup(x => x.Xbox360Games(Xuid.ToString()))
                .Returns(readTestResponse("Xbox360Games/Success.json"));

            Xbox360Games result = xboxAPI.Xbox360Games(Xuid.ToString()).GetAwaiter().GetResult();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void XboxOneGameAchievements()
        {
            mockXboxApiRestClient.Setup(x => x.XboxGameAchievements(Xuid.ToString(), XboxOneGameTitleId))
                .Returns(readTestResponse("XboxOneGameAchievements/Success.json"));

            XboxOneGameAchievement[] result = xboxAPI.XboxOneGameAchievements(Xuid.ToString(), XboxOneGameTitleId)
                .GetAwaiter().GetResult();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void XboxOneGames()
        {
            mockXboxApiRestClient.Setup(x => x.XboxOneGames(Xuid.ToString())).Returns(readTestResponse("XboxOneGames/Success.json"));

            XboxOneGames result = xboxAPI.XboxOneGames(Xuid.ToString()).GetAwaiter().GetResult(); ;
            Assert.IsNotNull(result);
        }

        private Task<XboxAPIRestResponse> readTestResponse(string fileName)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Responses\V2", fileName);
            string content = File.ReadAllText(filePath);
            return Task.FromResult(new XboxAPIRestResponse(HttpStatusCode.OK, content));
        }
    }
}