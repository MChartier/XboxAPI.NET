using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using XboxAPI.NET.XboxAPIRestClient;
using XboxAPIClient.Models.V2;

namespace XboxAPI.NET.Tests
{
    [TestClass]
    public class XboxAPITests
    {
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
        public void GamertagXuid()
        {
            const string Gamertag = "P3";
            const string ExpectedXuid = "2584878536129841";
            mockXboxApiRestClient.Setup(x => x.GamertagXuid(Gamertag)).Returns(readTestResponse("GamertagXuid/Success.json"));

            string result = xboxAPI.GamertagXuid(Gamertag).GetAwaiter().GetResult(); ;
            Assert.AreEqual(ExpectedXuid, result);
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
        public void Xbox360Games()
        {
            const string Xuid = "2584878536129841";
            mockXboxApiRestClient.Setup(x => x.Xbox360Games(Xuid)).Returns(readTestResponse("Xbox360Games/Success.json"));

            Xbox360Games result = xboxAPI.Xbox360Games(Xuid).GetAwaiter().GetResult(); ;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void XboxOneGames()
        {
            const string Xuid = "2584878536129841";
            mockXboxApiRestClient.Setup(x => x.XboxOneGames(Xuid)).Returns(readTestResponse("Xbox360Games/Success.json"));

            XboxOneGames result = xboxAPI.XboxOneGames(Xuid).GetAwaiter().GetResult(); ;
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