using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrderService.Tests.IntegrationTests
{
    [TestFixture]
    public class OrderControllerTests
    {
        private TestServer _server;
        private HttpClient _client;

        [SetUp]
        public void SetUp()
        {
            var builder = new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<Startup>();

            _server = new TestServer(builder);
            _client = _server.CreateClient();
        }

        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
            _server.Dispose();
        }

        [Test]
        public async Task GetOrderById_ReturnsOrder_WhenOrderExists()
        {
            var response = await _client.GetAsync("/api/order/1");
            Assert.IsNotNull(response);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
