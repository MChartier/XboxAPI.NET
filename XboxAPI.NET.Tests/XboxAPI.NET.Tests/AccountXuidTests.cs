//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using RestSharp;

//namespace XboxAPI.NET.Tests
//{
//    [TestClass]
//    public class AccountXuidTests
//    {
//        private Mock<IRestClientFactory> mockRestClientFactory;
//        private Mock<IRestClient> mockRestClient;

//        [TestInitialize]
//        public void TestInitialize()
//        {
//            this.mockRestClient = new Mock<IRestClient>();

//            this.mockRestClientFactory = new Mock<IRestClientFactory>();
//            this.mockRestClientFactory.Setup(x => x.BuildRestClient()).Returns(this.mockRestClient.Object);
//        }

//        [TestMethod]
//        public void AccountXuid_Success()
//        {
//            this.mockRestClient.Setup(x => x.)
//        }
//    }
//}
